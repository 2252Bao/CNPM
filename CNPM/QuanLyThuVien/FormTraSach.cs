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
    public partial class FormTraSach : Form
    {
        public FormTraSach()
        {
            InitializeComponent();
        }

        BindingSource _src = new BindingSource();
        private void FormTraSach_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.DataSource = _src;
            LoadComboTheLoai();
            cboTheLoai.SelectedIndex = 0;
            LoadGrid();
        }

        private void LoadGrid()
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY MaSach) AS STT, * FROM SACH";
            _src.DataSource = Utils.GetData(sql);
            _src.ResetBindings(true);
        }

        private void LoadComboTheLoai()
        {
            string sql = "SELECT * FROM THELOAI_SACH";
            cboTheLoai.DataSource = Utils.GetData(sql);
            cboTheLoai.ValueMember = "MaTheLoai";
            cboTheLoai.DisplayMember = "TenTheLoai";
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY MaSach) AS STT, * FROM SACH WHERE 1 = 1";
            
            if (!string.IsNullOrEmpty(txtTuKhoa.Text))
            {
                sql += " AND TenSach LIKE '%" + txtTuKhoa.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtTenSach.Text))
            {
                sql += " AND TenSach LIKE '%" + txtTenSach.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtTacGia.Text))
            {
                sql += " AND TacGia LIKE '%" + txtTacGia.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtNamXuatBan.Text))
            {
                sql += " AND NamXuatBan  = " + txtNamXuatBan.Text + "";
            }

            if (cboTheLoai.SelectedIndex >= 0)
            {
                sql += " AND MaTheLoai LIKE '%" + cboTheLoai.SelectedValue.ToString() + "%'";
            }

            _src.DataSource = Utils.GetData(sql);
            _src.ResetBindings(true);
        }
    }
}
