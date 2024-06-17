using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public static class Utils
    {
        public static void LoadForm(Panel content, Form frm)
        {
            if (frm == null)
                return;

            foreach (Control control in content.Controls)
                content.Controls.Remove(control);

            frm.TopLevel = false;
            content.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
