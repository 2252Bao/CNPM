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
    public partial class FormCaiDat : Form
    {
        public FormCaiDat()
        {
            InitializeComponent();
        }

        private void btnCaiDatThongTinSach_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(pnlCaiDatContent, new FormCaiDatThongTinSach());
        }

        private void btnCaiDatQuyDinhTheDocGia_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(pnlCaiDatContent, new FormCaiDatQuyDinhTheDocGia());
        }

        private void FormCaiDat_Load(object sender, EventArgs e)
        {
            btnCaiDatQuyDinhTheDocGia_Click(sender, e);
        }
    }
}
