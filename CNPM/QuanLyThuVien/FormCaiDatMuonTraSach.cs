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
    public partial class FormCaiDatMuonTraSach : Form
    {
        //KET NOI VOI DATABASE TREN MAY (CHINH LAI TREN TUNG MAY) 
        private SqlConnection conn;
        private string connectionString = @"Data Source=localhost;Initial Catalog=QUANLYTHUVIEN;User ID=sa;Password=1234";

        public FormCaiDatMuonTraSach()
        {
            InitializeComponent();
        }


        private void FormCaiDatMuonTraSach_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadData();
        }

        //Fill data
        private void LoadData()
        {
            try
            {
                conn.Open();
                string query = "SELECT So_Sach_Doc_Gia_Muon_Duoc_Trong_Mot_ThoiGian, So_Ngay_Gioi_Han_So_Luong_Sach_Muon, Thoi_Han_Muon_Sach, Phi_Phat_Theo_Mot_Ngay_Tre FROM QUY_DINH";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtSoLuongToiDa.Text = reader["So_Sach_Doc_Gia_Muon_Duoc_Trong_Mot_ThoiGian"].ToString();
                    txtSoNgayToiDa.Text = reader["So_Ngay_Gioi_Han_So_Luong_Sach_Muon"].ToString();
                    txtThoiGianToiDa.Text = reader["Thoi_Han_Muon_Sach"].ToString();
                    txtTienPhat.Text = reader["Phi_Phat_Theo_Mot_Ngay_Tre"].ToString(); 
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
                string query = "UPDATE QUY_DINH SET So_Sach_Doc_Gia_Muon_Duoc_Trong_Mot_ThoiGian = @SoSacDocGiaMuonDuocTrongMotThoiGian, So_Ngay_Gioi_Han_So_Luong_Sach_Muon = @SoNgayGioiHanSoLuongSachMuon, Thoi_Han_Muon_Sach = @ThoiHanMuonSach, Phi_Phat_Theo_Mot_Ngay_Tre = @PhiPhatTheoMotNgayTre";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoSacDocGiaMuonDuocTrongMotThoiGian", int.Parse(txtSoLuongToiDa.Text));
                cmd.Parameters.AddWithValue("@SoNgayGioiHanSoLuongSachMuon", int.Parse(txtSoNgayToiDa.Text));
                cmd.Parameters.AddWithValue("@ThoiHanMuonSach", int.Parse(txtThoiGianToiDa.Text));
                cmd.Parameters.AddWithValue("@PhiPhatTheoMotNgayTre", int.Parse(txtTienPhat.Text));

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
