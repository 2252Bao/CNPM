using SixLabors.Fonts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;



namespace QuanLyThuVien
{
    public partial class FormKhoSach : Form
    {
        public FormKhoSach()
        {
            InitializeComponent();
        }

        BindingSource _src = new BindingSource();

        private void FormKhoSach_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.DataSource = _src;
            LoadComboTheLoai();
            cboTheLoai.SelectedIndex = 0;
            LoadGrid();
        }

        private void LoadGrid()
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY MaSach) AS STT, * FROM SACH";
            _src.DataSource = Utils.GetData(sql);
            _src.ResetBindings(true);
        }

        private void LoadComboTheLoai()
        {
            string sql = "SELECT * FROM THELOAI_SACH";
            cboTheLoai.DataSource = Utils.GetData(sql);
            cboTheLoai.ValueMember = "MaTheLoai";
            cboTheLoai.DisplayMember = "TenTheLoai";
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY MaSach) AS STT, * FROM SACH WHERE 1 = 1";
            if (!string.IsNullOrEmpty(txtTenSach.Text))
            {
                sql += " AND TenSach LIKE '%" + txtTenSach.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtTacGia.Text))
            {
                sql += " AND TacGia LIKE '%" + txtTacGia.Text + "%'";
            }

            if (cboTheLoai.SelectedIndex >= 0)
            {
                sql += " AND MaTheLoai LIKE '%" + cboTheLoai.SelectedValue.ToString() + "%'";
            }

            _src.DataSource = Utils.GetData(sql);
            _src.ResetBindings(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var current = _src.Current as DataRowView;
            
            if (current == null)
                return;

            string maSach = current.Row.Field<string>("MaSach");

            if (string.IsNullOrWhiteSpace(maSach))
            {
                MessageBox.Show("Không có cuốn sách nào được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            using (SqlConnection con = new SqlConnection(Utils.GetConnectionString()))
            {
                con.Open();
                string sql = "SELECT MaSach FROM SACH WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();

                    sql = "DELETE FROM SACH WHERE MaSach = @MaSach";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaSach", maSach);

                    var answer = MessageBox.Show("Bạn muốn xoá sách " + maSach + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                    if (answer)
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Xoá thông tin sách thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGrid();
                        }
                        else
                        {
                            MessageBox.Show("Xoá thông tin sách không thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                con.Close();
            }
        }

        private void btnNhapSachMoi_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportFromExcel(filePath);
            }
        }

        private void ImportFromExcel(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                    using (SqlConnection conn = new SqlConnection("Data Source=IPHONE5;Initial Catalog=QUANLYTHUVIEN;Integrated Security=True;Encrypt=False"))
                    {
                        conn.Open();

                        foreach (var row in rows)
                        {
                            try
                            {
                                string maSach = row.Cell(1).GetString();
                                string tenSach = row.Cell(2).GetString();
                                string maTheLoai = row.Cell(3).GetString();
                                string tacGia = row.Cell(4).GetString();
                                int namXuatBan = row.Cell(5).GetValue<int>();
                                string nhaXuatBan = row.Cell(6).GetString();
                                int soLuong = row.Cell(7).GetValue<int>();
                                decimal giaSach = row.Cell(8).GetValue<decimal>();

                                string query = "INSERT INTO SACH (MaSach, TenSach, MaTheLoai, TacGia, NamXuatBan, NhaXuatBan, SoLuong, GiaSach) VALUES (@MaSach, @TenSach, @MaTheLoai, @TacGia, @NamXuatBan, @NhaXuatBan, @SoLuong, @GiaSach)";
                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@MaSach", maSach);
                                    cmd.Parameters.AddWithValue("@TenSach", tenSach);
                                    cmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                                    cmd.Parameters.AddWithValue("@TacGia", tacGia);
                                    cmd.Parameters.AddWithValue("@NamXuatBan", namXuatBan);
                                    cmd.Parameters.AddWithValue("@NhaXuatBan", nhaXuatBan);
                                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                    cmd.Parameters.AddWithValue("@GiaSach", giaSach);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText("error_log.txt", $"Error processing row {row.RowNumber()}: {ex.Message}{Environment.NewLine}");
                                MessageBox.Show($"Error processing row {row.RowNumber()}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        conn.Close();
                    }
                }

                MessageBox.Show("Nhập sách mới từ file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                File.AppendAllText("error_log.txt", $"General error: {ex.Message}{Environment.NewLine}");
                MessageBox.Show("Đã xảy ra lỗi khi nhập sách từ file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
