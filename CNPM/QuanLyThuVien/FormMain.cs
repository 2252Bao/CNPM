using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private static FormMain instance;

        public static FormMain Instance { 
            get {
                return instance;
            } 
        }

        public void LoadForm(Form frm)
        {
            if (instance == null)
                instance = this;

            Utils.LoadForm(pnlContent, frm);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            LoadForm(new FormGioiThieu());
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            LoadForm(new FormCaiDat());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btnTrangChu_Click(sender, e);
        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
            LoadForm(new FormThongKeBaoCao());
        }

        private void btnMuonTraSach_Click(object sender, EventArgs e)
        {
            LoadForm(new FormMuonTraSach());
        }

        private void btnKhoSach_Click(object sender, EventArgs e)
        {
            LoadForm(new FormKhoSach());
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            LoadForm(new FormThongTinDocGia());
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            LoadForm(new FormTraSach());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Bạn muốn thoát ứng dụng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes)
                return;
            this.Close();
        }
    }
}
