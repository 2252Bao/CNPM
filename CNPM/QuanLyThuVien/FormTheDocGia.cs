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

namespace QuanLyThuVien
{
    public partial class FormTheDocGia : Form
    {
        public FormTheDocGia()
        {
            InitializeComponent();
        }

        private void btnLapThe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Tên độc giả không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (cboLoaiDocGia.SelectedIndex < 0)
            {
                MessageBox.Show("Tài khoản chưa được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            using (SqlConnection con = new SqlConnection(Utils.GetConnectionString()))
            {
                con.Open();
                string sql = "INSERT INTO THE_DOCGIA(MADG, HOTEN, Email, MaTaiKhoan, NgaySinh, Sdt, DiaChi, NgayLapTheDocGia, NgayHetHan) VALUES (@MaDG, @HoTen, @Email, @MaTaiKhoan, @NgaySinh, @Sdt, @DiaChi, @NgayLapTheDocGia, @NgayHetHan)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaDG", "DG" + (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                cmd.Parameters.AddWithValue(@"HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MaTaiKhoan", cboLoaiDocGia.SelectedValue.ToString());
                cmd.Parameters.AddWithValue(@"NgaySinh", dtNgaySinh.Value);
                cmd.Parameters.AddWithValue("@Sdt", txtSdt.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@NgayLapTheDocGia", dtNgayLapThe.Value);
                cmd.Parameters.AddWithValue("@NgayHetHan", dtNgayLapThe.Value.AddMonths(6));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm mới độc giả thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm mới độc giả không thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                con.Close();
            }
        }

        private void FormTheDocGia_Load(object sender, EventArgs e)
        {
            dtNgaySinh.Value = DateTime.Now.AddYears(-18);
            dtNgayLapThe.Value = DateTime.Now;
            LoadComboTaiKhoan();
        }

        private void LoadComboTaiKhoan()
        {
            using (SqlConnection con = new SqlConnection(Utils.GetConnectionString()))
            {
                con.Open();
                string sql = "SELECT * FROM TAIKHOAN";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable result = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
                cboLoaiDocGia.DataSource = result;
                cboLoaiDocGia.DisplayMember = "MaTK";
                cboLoaiDocGia.ValueMember = "MaTK";
                con.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
