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
    public partial class FormMuonTraSach : Form
    {
        public FormMuonTraSach()
        {
            InitializeComponent();
        }

        BindingSource _srcTraSach = new BindingSource();
        BindingSource _srcMuonSach = new BindingSource();

        private void FormMuonTraSach_Load(object sender, EventArgs e)
        {
            gridMuonSach.DataSource = _srcMuonSach;
            gridTraSach.DataSource = _srcTraSach;
            LoadGridMuonSach();
            LoadGridTraSach();
        }

        private void LoadGridTraSach()
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY pt.MaPhieuTra) AS STT, pt.MaPhieuTra, dg.HoTen, pt.SoLuongSach as SoLuong FROM PHIEU_TRA_SACH pt INNER JOIN THE_DOCGIA dg ON pt.MaDG = dg.MaDG";
            _srcTraSach.DataSource = Utils.GetData(sql);
            _srcTraSach.ResetBindings(true);
        }

        private void LoadGridMuonSach()
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY pm.MaPhieuMuon) AS STT, pm.MaPhieuMuon, dg.HoTen, pm.SoLuongSach as SoLuong FROM PHIEU_MUON_SACH pm INNER JOIN THE_DOCGIA dg ON pm.MaDG = dg.MaDG";
            _srcMuonSach.DataSource = Utils.GetData(sql);
            _srcMuonSach.ResetBindings(true);
        }

        private void btnTimPhieuMuon_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY pm.MaPhieuMuon) AS STT, pm.MaPhieuMuon, dg.HoTen, pm.SoLuongSach as SoLuong FROM PHIEU_MUON_SACH pm INNER JOIN THE_DOCGIA dg ON pm.MaDG = dg.MaDG WHERE 1 = 1";
            if (!string.IsNullOrEmpty(txtMaPhieuMuon.Text))
            {
                sql += " AND pm.MaPhieuMuon LIKE '%" + txtMaPhieuMuon.Text + "%'";
            }
            _srcMuonSach.DataSource = Utils.GetData(sql);
            _srcMuonSach.ResetBindings(true);
        }

        private void btnTimPhieuTra_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY pt.MaPhieuTra) AS STT, pt.MaPhieuTra, dg.HoTen, pt.SoLuongSach as SoLuong FROM PHIEU_TRA_SACH pt INNER JOIN THE_DOCGIA dg ON pt.MaDG = dg.MaDG";
            if (!string.IsNullOrEmpty(txtMaPhieuTra.Text))
            {
                sql += " AND pt.MaPhieuTra LIKE '%" + txtMaPhieuMuon.Text + "%'";
            }
            _srcTraSach.DataSource = Utils.GetData(sql);
            _srcTraSach.ResetBindings(true);
        }

        private void btnInPhieuMuon_Click(object sender, EventArgs e)
        {
            var r = _srcMuonSach.Current as DataRowView;
            
            if (r == null)
            {
                MessageBox.Show("Không có phiếu nào được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maPhieuMuon = r.Row.Field<string>("MaPhieuMuon");

            if (string.IsNullOrWhiteSpace(maPhieuMuon))
            {
                MessageBox.Show("Không tìm thấy phiếu mượn được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            FormMain.Instance.LoadForm(new FormInPhieuMuonSach(maPhieuMuon));
        }

        private void btnInPhieuTra_Click(object sender, EventArgs e)
        {
            var r = _srcTraSach.Current as DataRowView;

            if (r == null)
            {
                MessageBox.Show("Không có phiếu nào được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maPhieuTra = r.Row.Field<string>("MaPhieuTra");

            if (string.IsNullOrWhiteSpace(maPhieuTra))
            {
                MessageBox.Show("Không tìm thấy phiếu trả được chọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormMain.Instance.LoadForm(new FormInPhieuTraSach(maPhieuTra));
        }
    }
}
