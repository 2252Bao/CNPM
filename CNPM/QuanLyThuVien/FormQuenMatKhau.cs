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
    public partial class FormQuenMatKhau : Form
    {
        public FormQuenMatKhau()
        {
            InitializeComponent();
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utils.GetConnectionString()))
            {
                con.Open();
                string combinedQuery = @"
                        SELECT TK.TK_Password
                        FROM TAIKHOAN TK
                        LEFT JOIN THE_DOCGIA DG ON TK.MaTK = DG.MaTaiKhoan
                        LEFT JOIN THUTHU TT ON TK.MaTK = TT.MaTaiKhoan
                        WHERE DG.Email = @Email OR TT.Email = @Email";
                SqlCommand cmd = new SqlCommand(combinedQuery, con);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string password = reader["TK_Password"].ToString();
                    MessageBox.Show("Mật khẩu của bạn là: " + password, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Email không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }  
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnXacNhan;
        }
    }
}
