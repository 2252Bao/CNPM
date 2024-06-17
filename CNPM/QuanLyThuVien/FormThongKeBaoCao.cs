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
    public partial class FormThongKeBaoCao : Form
    {
        public FormThongKeBaoCao()
        {
            InitializeComponent();
        }

        private void FormThongKeBaoCao_Load(object sender, EventArgs e)
        {
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
        }
    }
}
