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
    public partial class FormThongTinDocGia : Form
    {
        public FormThongTinDocGia()
        {
            InitializeComponent();
        }

        private void FormThongTinDocGia_Load(object sender, EventArgs e)
        {
            cboLoaiDocGia.SelectedIndex = 0;
        }
    }
}
