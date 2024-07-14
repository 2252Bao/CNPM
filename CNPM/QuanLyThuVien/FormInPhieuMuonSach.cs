using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace QuanLyThuVien
{
    public partial class FormInPhieuMuonSach : Form
    {
        public FormInPhieuMuonSach()
        {
            InitializeComponent();
        }

        public FormInPhieuMuonSach(string maPhieuMuon)
            : this()
        {
            MaPhieuMuon = maPhieuMuon;
        }

        public string MaPhieuMuon { get; }

        private void txtQuayLai_Click(object sender, EventArgs e)
        {
            FormMain.Instance.LoadForm(new FormMuonTraSach());
        }

        private void FormInPhieuMuonSach_Load(object sender, EventArgs e)
        {
            string sql = "SELECT pm.MaPhieuMuon, pm.MaDG, dg.HoTen, pm.SoLuongSach FROM PHIEU_MUON_SACH pm INNER JOIN THE_DOCGIA dg ON pm.MaDG = dg.MaDG WHERE pm.MaPhieuMuon = N'" + MaPhieuMuon + "'";
            DataTable result = Utils.GetData(sql);
            if (result.Rows.Count > 0)
            {
                txtMaPhieuMuon.Text = result.Rows[0].Field<string>("MaPhieuMuon");
                txtTenDocGia.Text = result.Rows[0].Field<string>("HoTen");
                txtMaDocGia.Text = result.Rows[0].Field<string>("MaDG");
                txtSoLuong.Text = result.Rows[0].Field<int>("SoLuongSach").ToString();

                sql = "SELECT ROW_NUMBER() OVER(ORDER BY S.MaSach) AS STT, s.MaSach, s.TenSach, s.MaTheLoai, s.TacGia, pm.NgayMuon FROM CHITIET_MUONTRA ct INNER JOIN PHIEU_MUON_SACH pm ON ct.MaPhieuMuon = pm.MaPhieuMuon INNER JOIN SACH S ON ct.MaSach = S.MaSach WHERE pm.MaPhieuMuon = N'" + MaPhieuMuon + "'";
                result = Utils.GetData(sql);
                gridMuonSach.DataSource = null;
                gridMuonSach.DataSource = result;
                gridMuonSach.Refresh();
            }
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInPhieuMuonSach_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Save an Excel File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportToExcel(filePath);
            }
        }

        private void ExportToExcel(string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Phiếu Mượn Sách");

                // Lấy thông tin phiếu mượn sách
                worksheet.Cell(1, 1).Value = "Mã Phiếu Mượn";
                worksheet.Cell(1, 2).Value = txtMaPhieuMuon.Text;

                worksheet.Cell(2, 1).Value = "Tên Độc Giả";
                worksheet.Cell(2, 2).Value = txtTenDocGia.Text;

                worksheet.Cell(3, 1).Value = "Mã Độc Giả";
                worksheet.Cell(3, 2).Value = txtMaDocGia.Text;

                worksheet.Cell(4, 1).Value = "Số Lượng Sách";
                worksheet.Cell(4, 2).Value = txtSoLuong.Text;

                // Thêm dữ liệu sách mượn
                worksheet.Cell(6, 1).Value = "STT";
                worksheet.Cell(6, 2).Value = "Mã Sách";
                worksheet.Cell(6, 3).Value = "Tên Sách";
                worksheet.Cell(6, 4).Value = "Thể Loại";
                worksheet.Cell(6, 5).Value = "Tác Giả";
                worksheet.Cell(6, 6).Value = "Ngày Mượn";

                DataTable dt = (DataTable)gridMuonSach.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    worksheet.Cell(i + 7, 1).Value = Convert.ToInt32(dt.Rows[i]["STT"]);
                    worksheet.Cell(i + 7, 2).Value = dt.Rows[i]["MaSach"].ToString();
                    worksheet.Cell(i + 7, 3).Value = dt.Rows[i]["TenSach"].ToString();
                    worksheet.Cell(i + 7, 4).Value = dt.Rows[i]["MaTheLoai"].ToString();
                    worksheet.Cell(i + 7, 5).Value = dt.Rows[i]["TacGia"].ToString();
                    worksheet.Cell(i + 7, 6).Value = Convert.ToDateTime(dt.Rows[i]["NgayMuon"]).ToString("dd/MM/yyyy");
                }

                // Lưu file Excel
                workbook.SaveAs(filePath);
            }

            MessageBox.Show("Lưu ra file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
