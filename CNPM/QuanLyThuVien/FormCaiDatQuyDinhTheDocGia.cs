using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormCaiDatQuyDinhTheDocGia : Form
    {
        //KET NOI VOI DATABASE TREN MAY (CHINH LAI TREN TUNG MAY) 
        private SqlConnection conn;
        private string connectionString = Utils.GetConnectionString();

        public FormCaiDatQuyDinhTheDocGia()
        {
            InitializeComponent();
        }

        private void FormCaiDatQuyDinhTheDocGia_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadData();
        }

        // Fill data
        private void LoadData()
        {
            try
            {
                conn.Open();
                string query = "SELECT MinAge, MaxAge, Thoi_Han_The_Doc_Gia FROM QUY_DINH";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtMinAge.Text = reader["MinAge"].ToString();
                    txtMaxAge.Text = reader["MaxAge"].ToString();
                    txtThoiHanTheDocGia.Text = reader["Thoi_Han_The_Doc_Gia"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //Thay doi noi dung va luu lai
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE QUY_DINH SET MinAge = @MinAge, MaxAge = @MaxAge, Thoi_Han_The_Doc_Gia = @ThoiHanTheDocGia";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MinAge", int.Parse(txtMinAge.Text));
                cmd.Parameters.AddWithValue("@MaxAge", int.Parse(txtMaxAge.Text));
                cmd.Parameters.AddWithValue("@ThoiHanTheDocGia", int.Parse(txtThoiHanTheDocGia.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thông tin được cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
