using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace QuanLyThuVien
{
    public partial class FormCaiDatThongTinSach : Form
    {
        //KET NOI VOI DATABASE TREN MAY (CHINH LAI TREN TUNG MAY) 
        private SqlConnection conn;
        private string connectionString = Utils.GetConnectionString();

        public FormCaiDatThongTinSach()
        {
            InitializeComponent();
            this.Load += FormCaiDatThongTinSach_Load;
            dgvTheLoai.CellContentClick += DgvTheLoai_CellContentClick;

        }

        private void FormCaiDatThongTinSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //Fill data. 
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaTheLoai, TenTheLoai FROM THELOAI_SACH";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTheLoai.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvTheLoai.Rows.Add(false, row["MaTheLoai"], row["TenTheLoai"], "Chỉnh sửa");
                    }

                    txtSoLuongTheLoai.Text = dt.Rows.Count.ToString();

                    query = "SELECT So_Nam_Xuat_Ban FROM QUY_DINH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int soNamXuatBan = (int)cmd.ExecuteScalar();
                        txtNamXuatBanXaNhat.Text = soNamXuatBan.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // Them the loai
        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            FormCaiDatThemTheLoai newForm = new FormCaiDatThemTheLoai();
            newForm.ShowDialog();
            LoadData();
        }

        //Chinh sua the loai
        private void DgvTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTheLoai.Columns["colChinhSua"].Index && e.RowIndex >= 0)
            {
                string maTheLoai = dgvTheLoai.Rows[e.RowIndex].Cells["colMaTheLoai"].Value.ToString();
                string tenTheLoai = dgvTheLoai.Rows[e.RowIndex].Cells["colTheLoai"].Value.ToString();
                FormCaiDatChinhSuaTheLoai editForm = new FormCaiDatChinhSuaTheLoai(maTheLoai, tenTheLoai);
                editForm.ShowDialog(); 
                LoadData(); 
            }
        }

        //Xoa the loai
        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<string> maTheLoaiToDelete = new List<string>();
            foreach (DataGridViewRow row in dgvTheLoai.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chkSelect"].Value))
                {
                    maTheLoaiToDelete.Add(row.Cells["colMaTheLoai"].Value.ToString());
                }
            }
            //Kiem tra da chon the loai chua
            if (maTheLoaiToDelete.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một thể loại để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa các thể loại đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        bool anyError = false;
                        foreach (string maTheLoai in maTheLoaiToDelete)
                        {
                            // Kiem tra xem the loai co referenced trong bang SACH khong
                            string checkQuery = "SELECT COUNT(*) FROM dbo.SACH WHERE MaTheLoai = @MaTheLoai";
                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                                int count = (int)checkCmd.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show($"Không thể xóa thể loại {maTheLoai} vì đang được sử dụng trong bảng SACH.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    anyError = true;
                                    continue; 
                                }
                            }

                            // Neu khong referenced thi xoa
                            string deleteQuery = "DELETE FROM THELOAI_SACH WHERE MaTheLoai = @MaTheLoai";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }

                        if (!anyError)
                        {
                            MessageBox.Show("Xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Refresh the DataGridView
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Thay doi nam xuat ban
        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE QUY_DINH SET So_Nam_Xuat_Ban = @SoNamXuatBan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoNamXuatBan", int.Parse(txtNamXuatBanXaNhat.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thông tin được cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        private void dgvTheLoai_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
