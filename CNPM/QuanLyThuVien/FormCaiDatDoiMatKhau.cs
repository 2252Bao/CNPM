using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyThuVien.Helpers;

namespace QuanLyThuVien
{
    public partial class FormCaiDatDoiMatKhau : Form
    {
        public FormCaiDatDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            DoiMatKhau();
        }

        private void DoiMatKhau()
        {
            string currentPassword = txtMatKhauHienTai.Text;
            string newPassword = txtMatKhauMoi.Text;
            string confirmPassword = txtNhapLaiMatKhauMoi.Text;

            // Kiem tra nhap thong tin
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                string maTK = SessionManager.User.MaTK;
                string username = SessionManager.User.Username;

                // KET NOI DATABASE, DOI LAI VOI TUNG MAY
                using (SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=QUANLYTHUVIEN;User ID=sa;Password=1234"))
                {
                    con.Open();

                    // Kiem tra mat khau
                    string verifyQuery = "SELECT TK_Password FROM TAIKHOAN WHERE MaTK = @MaTK AND TK_Username = @Username";
                    SqlCommand verifyCmd = new SqlCommand(verifyQuery, con);
                    verifyCmd.Parameters.AddWithValue("@MaTK", maTK);
                    verifyCmd.Parameters.AddWithValue("@Username", username);

                    string storedPassword = verifyCmd.ExecuteScalar()?.ToString();

                    // Kiem tra mat khau cu
                    if (storedPassword == null || storedPassword != currentPassword)
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Kiem tra mat khau moi
                    if (newPassword != confirmPassword)
                    {
                        MessageBox.Show("Mật khẩu mới không khớp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Kiem tra mat khau cu co trung mat khau moi khong. 
                    if (currentPassword == newPassword)
                    {
                        MessageBox.Show("Mật khẩu mới không được giống mật khẩu hiện tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // Cap nhat mat khau
                    string updateQuery = "UPDATE TAIKHOAN SET TK_Password = @NewPassword WHERE MaTK = @MaTK";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    updateCmd.Parameters.AddWithValue("@MaTK", maTK);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Mật khẩu đã được thay đổi thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
