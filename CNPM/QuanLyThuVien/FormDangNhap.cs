﻿using System;
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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            this.Username.Enter += new System.EventHandler(this.Username_Enter);
            this.Username.Leave += new System.EventHandler(this.Username_Leave);
            this.Password.Enter += new System.EventHandler(this.Password_Enter);
            this.Password.Leave += new System.EventHandler(this.Password_Leave);
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=TP4-LAPTOP;Initial Catalog=QUANLYTHUVIEN;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string query = "SELECT COUNT(*) FROM TAIKHOAN WHERE TK_Username=@username AND TK_Password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Username.Text);
            cmd.Parameters.AddWithValue("@password", Password.Text);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (count == 1)
            {
                FormMain f = new FormMain();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Username_Enter(object sender, EventArgs e)
        {
            if (Username.Text == "Tài Khoản")
            {
                Username.Text = "";
                Username.ForeColor = Color.Black; // Optional: Change text color if needed
            }
        }

        private void Username_Leave(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Username.Text = "Tài Khoản";
                Username.ForeColor = Color.Gray; // Optional: Change text color to indicate placeholder
            }
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            if (Password.Text == "Mật Khẩu")
            {
                Password.Text = "";
                Password.ForeColor = Color.Black; // Optional: Change text color if needed
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Text = "Mật Khẩu";
                Password.ForeColor = Color.Gray; // Optional: Change text color to indicate placeholder
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormQuenMatKhau form1 = new FormQuenMatKhau();
            form1.Show();
            this.Hide();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
        }
    }
}