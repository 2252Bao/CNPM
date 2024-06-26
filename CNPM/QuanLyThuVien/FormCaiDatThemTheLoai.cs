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
    public partial class FormCaiDatThemTheLoai : Form
    {
        //KET NOI VOI DATABASE TREN MAY (CHINH LAI TREN TUNG MAY) 
        private string connectionString = @"Data Source=localhost;Initial Catalog=QUANLYTHUVIEN;User ID=sa;Password=1234";

        public FormCaiDatThemTheLoai()
        {
            InitializeComponent();
        }

        // Click 'Dong'
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Click 'Them' 
        private void btnThem_Click(object sender, EventArgs e)
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

                    // Kiem tra the loai da ton tai chua
                    string checkQuery = "SELECT COUNT(*) FROM THELOAI_SACH WHERE TenTheLoai = @TenTheLoai";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@TenTheLoai", newCategoryName);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Tên thể loại này đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Tao ma the loai cho the loai moi
                    string getLastCodeQuery = "SELECT TOP 1 MaTheLoai FROM THELOAI_SACH ORDER BY MaTheLoai DESC";
                    string newCategoryCode = "TL001"; // Default starting code
                    using (SqlCommand getLastCodeCmd = new SqlCommand(getLastCodeQuery, conn))
                    {
                        object lastCodeObj = getLastCodeCmd.ExecuteScalar();
                        if (lastCodeObj != null)
                        {
                            string lastCode = lastCodeObj.ToString();
                            int lastCodeNumber = int.Parse(lastCode.Substring(2)); 
                            newCategoryCode = "TL" + (lastCodeNumber + 1).ToString("D3");
                        }
                    }

                    // Them the loai moi
                    string insertQuery = "INSERT INTO THELOAI_SACH (MaTheLoai, TenTheLoai) VALUES (@MaTheLoai, @TenTheLoai)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@MaTheLoai", newCategoryCode);
                        insertCmd.Parameters.AddWithValue("@TenTheLoai", newCategoryName);
                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bạn đã thêm thể loại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
