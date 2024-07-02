using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyThuVien.Helpers;

namespace QuanLyThuVien
{
    public partial class FormCaiDatThongTinCaNhan : Form
    {
        public FormCaiDatThongTinCaNhan()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                // Use CurrentUser.MaTK to fetch user details
                string maTK = SessionManager.User.MaTK;

                using (SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=QUANLYTHUVIEN;User ID=sa;Password=1234"))
                {
                    con.Open();
                    string query = @"
                SELECT 
                    ISNULL(THUTHU.HoTen, THE_DOCGIA.HoTen) AS HoTen, 
                    ISNULL(THUTHU.NgaySinh, THE_DOCGIA.NgaySinh) AS NgaySinh, 
                    ISNULL(THUTHU.DiaChi, THE_DOCGIA.DiaChi) AS DiaChi, 
                    ISNULL(THUTHU.Email, THE_DOCGIA.Email) AS Email, 
                    LoaiTK
                FROM TAIKHOAN
                LEFT JOIN THUTHU ON TAIKHOAN.MaTK = THUTHU.MaTaiKhoan
                LEFT JOIN THE_DOCGIA ON TAIKHOAN.MaTK = THE_DOCGIA.MaTaiKhoan
                WHERE TAIKHOAN.MaTK = @MaTK";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MaTK", maTK);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtHoTen.Text = reader["HoTen"].ToString();
                        txtTaiKhoan.Text = SessionManager.User.Username;
                        dateTimePicker1.Value = DateTime.Parse(reader["NgaySinh"].ToString());
                        txtDiaChi.Text = reader["DiaChi"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message);
            }
        }




        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            SaveUserData();
        }

        private void SaveUserData()
        {
            try
            {
                // Use CurrentUser.MaTK to update user details
                string maTK = SessionManager.User.MaTK;

                using (SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=QUANLYTHUVIEN;User ID=sa;Password=1234"))
                {
                    con.Open();
                    string query = @"
                IF EXISTS (SELECT 1 FROM THUTHU WHERE MaTaiKhoan = @MaTK)
                BEGIN
                    UPDATE THUTHU SET HoTen = @HoTen, NgaySinh = @NgaySinh, DiaChi = @DiaChi, Email = @Email
                    WHERE MaTaiKhoan = @MaTK
                END
                ELSE IF EXISTS (SELECT 1 FROM THE_DOCGIA WHERE MaTaiKhoan = @MaTK)
                BEGIN
                    UPDATE THE_DOCGIA SET HoTen = @HoTen, NgaySinh = @NgaySinh, DiaChi = @DiaChi, Email = @Email
                    WHERE MaTaiKhoan = @MaTK
                END";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MaTK", maTK);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thay đổi đã được lưu", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user data: " + ex.Message);
            }
        }


    }
}
