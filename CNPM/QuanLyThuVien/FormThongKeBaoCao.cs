using Guna.UI2.WinForms;
using ClosedXML.Excel;
using System.Windows.Forms.DataVisualization.Charting;
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
using System.IO;

namespace QuanLyThuVien
{
    public partial class FormThongKeBaoCao : Form
    {
        private string connectionString = Utils.GetConnectionString();
        public FormThongKeBaoCao()
        {
            InitializeComponent();
        }

        private void FormThongKeBaoCao_Load(object sender, EventArgs e)
        {
            cboThang.Items.Clear();
            
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString());
            }
            
            cboNam.Items.Clear();

            for (int i = 2021; i <= DateTime.Now.Year; i++)
            {
                cboNam.Items.Add(i.ToString());
            }
            
            cboThang.SelectedItem = DateTime.Now.Month.ToString();
            cboNam.SelectedItem = DateTime.Now.Year.ToString();

            gridDocGiaMuonNhieu.Visible = false;
            gridSachMuonNhieu.Visible = false;
            chartThongKeSachMuon.Visible = false;

            cboThongKeTheo.Items.Clear();
            cboThongKeTheo.Items.Add("Độc giả mượn nhiều sách nhất");
            cboThongKeTheo.Items.Add("Thống kê sách được mượn nhiều nhất");
            cboThongKeTheo.Items.Add("Lượng sách mượn theo thời gian");
            cboThongKeTheo.SelectedIndex = 0;
        }

        private void LoadGridDocGiaMuonNhieuSachNhat()
        {
            string query = @"SELECT TOP 15 ROW_NUMBER() OVER (ORDER BY DG.MADG) AS STT, DG.MaDG, DG.HoTen, DG.Sdt, DG.Email, DG.DiaChi, SUM(CTMT.SoLuong) AS TongSoLuongSachMuon
                FROM THE_DOCGIA DG 
                JOIN PHIEU_MUON_SACH PMS ON DG.MaDG = PMS.MaDG 
                JOIN CHITIET_MUONTRA CTMT ON PMS.MaPhieuMuon = CTMT.MaPhieuMuon
                WHERE YEAR(PMS.NgayMuon) = @Year AND MONTH(PMS.NgayMuon) = @Month
                GROUP BY DG.MaDG, DG.HoTen, DG.Sdt, DG.Email, DG.DiaChi
                ORDER BY TongSoLuongSachMuon DESC, DG.MaDG ASC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Month", cboThang.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Year", cboNam.SelectedItem.ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                da.Fill(tb);
                gridDocGiaMuonNhieu.DataSource = null;
                gridDocGiaMuonNhieu.DataSource = tb;
                gridDocGiaMuonNhieu.Refresh();
                gridDocGiaMuonNhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridDocGiaMuonNhieu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                connection.Close();
            }
        }

        private void LoadGridSachDuocMuonNhieuNhat()
        {
            string query = @"SELECT TOP 15 ROW_NUMBER() OVER (ORDER BY S.MaSach) AS STT, S.MaSach, S.TenSach, S.TacGia, S.NhaXuatBan, S.NamXuatBan, SUM(CTMT.SoLuong) AS TongSoLuongSachMuon
                FROM SACH S
                JOIN CHITIET_MUONTRA CTMT ON S.MaSach = CTMT.MaSach
                JOIN PHIEU_MUON_SACH PMS ON CTMT.MaPhieuMuon = PMS.MaPhieuMuon
                WHERE YEAR(PMS.NgayMuon) = @Year AND MONTH(PMS.NgayMuon) = @Month
                GROUP BY S.MaSach, S.TenSach, S.TacGia, S.NhaXuatBan, S.NamXuatBan
                ORDER BY TongSoLuongSachMuon DESC, S.MaSach ASC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Month", cboThang.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Year", cboNam.SelectedItem.ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                da.Fill(tb);
                gridSachMuonNhieu.DataSource = null;
                gridSachMuonNhieu.DataSource = tb;
                gridSachMuonNhieu.Refresh();
                gridSachMuonNhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridSachMuonNhieu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void UpdateView()
        {
            gridDocGiaMuonNhieu.Visible = false;
            gridSachMuonNhieu.Visible = false;
            chartThongKeSachMuon.Visible = false;


            switch (cboThongKeTheo.SelectedIndex)
            {
                case 0:
                    gridDocGiaMuonNhieu.Visible = true;
                    if (gridDocGiaMuonNhieu.Dock != DockStyle.Fill)
                        gridDocGiaMuonNhieu.Dock = DockStyle.Fill;
                    break;
                case 1:
                    gridSachMuonNhieu.Visible = true;
                    if (gridSachMuonNhieu.Dock != DockStyle.Fill)
                        gridSachMuonNhieu.Dock = DockStyle.Fill;
                    break;
                case 2:
                    chartThongKeSachMuon.Visible = true;
                    if (chartThongKeSachMuon.Dock != DockStyle.Fill)
                        chartThongKeSachMuon.Dock = DockStyle.Fill;
                    break;
            }
        }

        private void LoadChart()
        {
            chartThongKeSachMuon.Series.Clear();

            string query = @"
                SELECT PMS.NgayMuon, SUM(CTMT.SoLuong) AS TongSoLuongSachMuon
                FROM PHIEU_MUON_SACH PMS
                JOIN CHITIET_MUONTRA CTMT ON PMS.MaPhieuMuon = CTMT.MaPhieuMuon
                WHERE YEAR(PMS.NgayMuon) = @Year AND MONTH(PMS.NgayMuon) = @Month
                GROUP BY PMS.NgayMuon
                ORDER BY PMS.NgayMuon;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Month", cboThang.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Year", cboNam.SelectedItem.ToString());
                SqlDataReader reader = cmd.ExecuteReader();

                Series series = new Series("Xu hướng mượn");
                series.ChartType = SeriesChartType.Column;

                while (reader.Read())
                {
                    DateTime date = reader.GetFieldValue<DateTime>(0); // NgayMuon
                    int quantity = reader.GetFieldValue<int>(1); // TongSoLuongSachMuon

                    series.Points.AddXY(date, quantity);
                }
                chartThongKeSachMuon.Series.Clear();
                chartThongKeSachMuon.Series.Add(series);
                reader.Close();
                connection.Close();
            }
            chartThongKeSachMuon.ChartAreas[0].AxisX.Interval = 1;
            chartThongKeSachMuon.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy";
            chartThongKeSachMuon.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartThongKeSachMuon.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            
            string selectedOption = cboThongKeTheo.SelectedItem.ToString();

            
            gridDocGiaMuonNhieu.Visible = false;
            gridSachMuonNhieu.Visible = false;
            chartThongKeSachMuon.Visible = false;

            
            if (selectedOption == "Độc giả mượn nhiều sách nhất")
            {
                LoadGridDocGiaMuonNhieuSachNhat();
                gridDocGiaMuonNhieu.Visible = true;
            }
            else if (selectedOption == "Thống kê sách được mượn nhiều nhất")
            {
                LoadGridSachDuocMuonNhieuNhat();
                gridSachMuonNhieu.Visible = true;
            }
            else if (selectedOption == "Lượng sách mượn theo thời gian")
            {
                LoadChart();
                chartThongKeSachMuon.Visible = true;
            }
        }

        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                DataTable dt = new DataTable("DataGridView");
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    dt.Columns.Add(col.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    DataRow dRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dt.Rows.Add(dRow);
                }

                workbook.Worksheets.Add(dt, "Sheet1");
                workbook.SaveAs(filePath);
            }
        }

        private void SaveChartImage(Chart chart,string filePath)
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            chart.SaveImage(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = @"C:\thongke";
            saveDlg.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Xuất dữ liệu ra file";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = saveDlg.FileName;

                    string selectedOption = cboThongKeTheo.SelectedItem.ToString();

                    if (selectedOption == "Độc giả mượn nhiều sách nhất")
                    {
                        if (gridDocGiaMuonNhieu.Rows.Count <= 0)
                        {
                            MessageBox.Show("Không có dữ liệu thống kê !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        } 
                        ExportToExcel(gridDocGiaMuonNhieu, path);
                    }
                    else if (selectedOption == "Thống kê sách được mượn nhiều nhất")
                    {
                        if (gridSachMuonNhieu.Rows.Count <= 0)
                        {
                            MessageBox.Show("Không có dữ liệu thống kê !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ExportToExcel(gridSachMuonNhieu, path);
                    }
                    else if (selectedOption == "Lượng sách mượn theo thời gian")
                    {
                        if (chartThongKeSachMuon.Series.Count <= 0)
                        {
                            MessageBox.Show("Không có dữ liệu thống kê !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        path = path.Substring(0, path.LastIndexOf(".")) + ".png";
                        SaveChartImage(chartThongKeSachMuon, path);
                    }

                    MessageBox.Show("Lưu ra file thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void cboThongKeTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
