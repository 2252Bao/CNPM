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
    public partial class FormKhoSach : Form
    {
        public FormKhoSach()
        {
            InitializeComponent();
        }

        private void FormKhoSach_Load(object sender, EventArgs e)
        {
            cboTheLoai.SelectedIndex = 0;
        }
    }
}
