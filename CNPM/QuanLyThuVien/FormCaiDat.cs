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
        private void FormCaiDat_Load(object sender, EventArgs e)
        {
            btnCaiDatQuyDinhTheDocGia_Click(sender, e);
        }

        // Mo Quy Dinh Doc Gia
        private void btnCaiDatQuyDinhTheDocGia_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(pnlCaiDatContent, new FormCaiDatQuyDinhTheDocGia());
        }

        //Mo Thong Tin Sach
        private void btnCaiDatThongTinSach_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(pnlCaiDatContent, new FormCaiDatThongTinSach());
        }
        
        //Mo Thong Tin Muon - Tra
        private void btnCaiDatThongTinMuonTraSach_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(pnlCaiDatContent, new FormCaiDatMuonTraSach());
        }

        //Mo Thong Tin Ca Nhan
        private void btnCaiDatThongTinCaNhan_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(pnlCaiDatContent, new FormCaiDatThongTinCaNhan());
        }

        //Mo Doi Mat Khau
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Utils.LoadForm(pnlCaiDatContent, new FormCaiDatDoiMatKhau());
        }
        

    }
}
