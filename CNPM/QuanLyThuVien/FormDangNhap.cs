using QuanLyThuVien.Models;
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
using QuanLyThuVien.Helpers;
using System.Web.Management;

namespace QuanLyThuVien
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            this.txtUserName.Enter += new System.EventHandler(this.Username_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.Username_Leave);
            this.txtPassword.Enter += new System.EventHandler(this.Password_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.Password_Leave);
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DataTable result = new DataTable();

            using (SqlConnection con = new SqlConnection(Utils.GetConnectionString()))
            {
                con.Open();
                string query = "SELECT * FROM TAIKHOAN WHERE TK_Username=@username AND TK_Password=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
                da.Dispose();
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
               
            if (result.Rows.Count > 0)
            {
                TaiKhoan tk = new TaiKhoan();
                tk.MaTK = result.Rows[0].Field<string>("MaTK");
                tk.TK_Username = result.Rows[0].Field<string>("TK_Username");
                tk.TK_Password = result.Rows[0].Field<string>("TK_Password");
                tk.LoaiTK = result.Rows[0].Field<string>("LoaiTK");
                SessionManager.User = tk;
                this.Hide();
                FormMain frm = new FormMain();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Username_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Tài Khoản")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black; // Optional: Change text color if needed
            }
        }

        private void Username_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Tài Khoản";
                txtUserName.ForeColor = Color.Gray; // Optional: Change text color to indicate placeholder
            }
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mật Khẩu")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black; // Optional: Change text color if needed
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Mật Khẩu";
                txtPassword.ForeColor = Color.Gray; // Optional: Change text color to indicate placeholder
            }
        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuenMatKhau frm = new FormQuenMatKhau();
            frm.ShowDialog();
            this.Show();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnDangNhap;
            txtUserName.Text = "librarian1";
            txtPassword.Text = "password21";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
