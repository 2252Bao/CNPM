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
            this.Email.Enter += new System.EventHandler(this.Email_Enter);
            this.Email.Leave += new System.EventHandler(this.Email_Leave);
        }

        private void Email_Enter(object sender, EventArgs e)
        {
            if (Email.Text == "Email")
            {
                Email.Text = "";
                Email.ForeColor = Color.Black;
            }
        }

        private void Email_Leave(object sender, EventArgs e)
        {
            if (Email.Text == "")
            {
                Email.Text = "Email";
                Email.ForeColor = Color.Gray;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=QUANLYTHUVIEN;User ID=sa;Password=1234");
            con.Open();
            string combinedQuery = @"
SELECT TK.TK_Password
FROM TAIKHOAN TK
LEFT JOIN THE_DOCGIA DG ON TK.MaTK = DG.MaTaiKhoan
LEFT JOIN THUTHU TT ON TK.MaTK = TT.MaTaiKhoan
WHERE DG.Email = @Email OR TT.Email = @Email";
            SqlCommand cmd = new SqlCommand(combinedQuery, con);
            cmd.Parameters.AddWithValue("@Email", Email.Text);

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

        private void button2_Click(object sender, EventArgs e)
        {
            FormDangNhap f = new FormDangNhap();
            f.Show();
            this.Hide();
        }

        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
        }
    }
}
