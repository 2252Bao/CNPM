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
    public partial class FormThongTinDocGia : Form
    {
        public FormThongTinDocGia()
        {
            InitializeComponent();
        }

        BindingSource _src = new BindingSource();

        private void FormThongTinDocGia_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AllowUserToResizeRows = false;
            gridData.AllowUserToResizeColumns = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = _src;
            LoadComboTaiKhoan();
            cboLoaiDocGia.SelectedIndex = 0;
            LoadGridData();
            InitBindings();
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

        private void InitBindings()
        {
            txtMaDocGia.DataBindings.Add("Text", _src, "MaDG", false, DataSourceUpdateMode.Never);
            txtTenDocGia.DataBindings.Add("Text", _src, "HoTen", false, DataSourceUpdateMode.Never);
            cboLoaiDocGia.DataBindings.Add("SelectedValue",  _src, "MaTaiKhoan",  false, DataSourceUpdateMode.Never);
            txtNgayLapThe.DataBindings.Add("Text", _src, "NgayLapTheDocGia", true, DataSourceUpdateMode.Never, "", "dd/MM/yyyy");
        }

        private void LoadGridData()
        {
            using(SqlConnection con = new SqlConnection(Utils.GetConnectionString()))
            {
                con.Open();
                string sql = "SELECT ROW_NUMBER() OVER (ORDER BY MADG) AS STT, * FROM THE_DOCGIA";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable result = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
                _src.DataSource = result;
                _src.ResetBindings(true);
                con.Close();
            }
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDocGia.Text))
            { 
                MessageBox.Show("Không có độc giả nào được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            using (SqlConnection con = new SqlConnection(Utils.GetConnectionString()))
            {
                con.Open();
                string sql = "SELECT MaDG FROM THE_DOCGIA WHERE MADG = @MADG";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MADG", txtMaDocGia.Text);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();

                    sql = "DELETE FROM THE_DOCGIA WHERE MADG = @MADG";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MADG", txtMaDocGia.Text);

                    var answer = MessageBox.Show("Bạn muốn xoá độc giả được chọn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    
                    if (answer)
                    { 
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Xoá thông tin độc giả thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGridData();
                        }
                        else
                        {
                            MessageBox.Show("Xoá thông tin độc giả không thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                } 
                else
                {
                    MessageBox.Show("Không tìm thấy độc giả được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                con.Close();
            } 
        }

        private void btnLapTheDocGia_Click(object sender, EventArgs e)
        {
            FormTheDocGia frm = new FormTheDocGia();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadGridData();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utils.GetConnectionString()))
            {
                con.Open();
                string sql = "SELECT ROW_NUMBER() OVER (ORDER BY MADG) AS STT, * FROM THE_DOCGIA WHERE 1 = 1";
                
                if (!string.IsNullOrEmpty(txtMaDocGia.Text))
                {
                    sql = sql + " AND MADG LIKE '%" + txtMaDocGia.Text + "%'";
                }

                if (!string.IsNullOrEmpty(txtTenDocGia.Text))
                {
                    sql = sql + " AND HoTen LIKE '%" + txtTenDocGia.Text + "%'";
                } 
                
                if (cboLoaiDocGia.SelectedIndex >= 0)
                {
                    sql = sql + " AND MaTaiKhoan LIKE '%" + cboLoaiDocGia.SelectedValue.ToString() + "%'";
                } 

                //if (!string.IsNullOrEmpty(txtNgayLapThe.Text))
                //{
                //    sql = sql + " AND CAST(NgayLapTheDocGia AS DATE) = CAST('" + txtNgayLapThe.Text + "' AS DATE)";
                //} 

                SqlCommand cmd = new SqlCommand(sql, con);
                DataTable result = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                result.Load(reader);
                _src.DataSource = result;
                _src.ResetBindings(true);
                con.Close();
            } 
        }
    }
}
