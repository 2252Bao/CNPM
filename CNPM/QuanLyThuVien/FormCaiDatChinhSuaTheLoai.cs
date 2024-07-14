using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormCaiDatChinhSuaTheLoai : Form
    {
        //KET NOI VOI DATABASE TREN MAY (CHINH LAI TREN TUNG MAY) 
        private string connectionString = Utils.GetConnectionString();
        private string maTheLoai;

        public FormCaiDatChinhSuaTheLoai(string maTheLoai, string tenTheLoai)
        {
            InitializeComponent();
            this.maTheLoai = maTheLoai;
            txtTenTheLoai.Text = tenTheLoai;
        }

        // Click 'Dong'
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Click 'Luu'
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string newCategoryName = txtTenTheLoai.Text.Trim();

            if (string.IsNullOrEmpty(newCategoryName))
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiem tra ten the loai da ton tai chua?
                    string checkQuery = "SELECT COUNT(*) FROM THELOAI_SACH WHERE TenTheLoai = @TenTheLoai AND MaTheLoai != @MaTheLoai";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@TenTheLoai", newCategoryName);
                        checkCmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Tên thể loại này đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Neu chua thi update ten moi
                    string updateQuery = "UPDATE THELOAI_SACH SET TenTheLoai = @TenTheLoai WHERE MaTheLoai = @MaTheLoai";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@TenTheLoai", newCategoryName);
                        updateCmd.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                        updateCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bạn đã chỉnh sửa thể loại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
