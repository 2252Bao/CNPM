using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormInPhieuTraSach : Form
    {
        public FormInPhieuTraSach()
        {
            InitializeComponent();
        }

        public FormInPhieuTraSach(string maPhieuTra)
            : this()
        {
            MaPhieuTra = maPhieuTra;
        }

        public string MaPhieuTra { get; }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gridMuonSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormInPhieuTraSach_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qUANLYTHUVIENDataSet.PHIEU_TRA_SACH' table. You can move, or remove it, as needed.
            this.pHIEU_TRA_SACHTableAdapter.Fill(this.qUANLYTHUVIENDataSet.PHIEU_TRA_SACH);

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FormMain.Instance.LoadForm(new FormMuonTraSach());
        }
    }
}
