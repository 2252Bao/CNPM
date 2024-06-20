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
    public partial class FormCaiDatQuyDinhTheDocGia : Form
    {
        public FormCaiDatQuyDinhTheDocGia()
        {
            InitializeComponent();
        }

        private void FormCaiDatQuyDinhTheDocGia_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            txtMinAge.Text = Properties.Settings.Default.MinAge.ToString();
            txtMaxAge.Text = Properties.Settings.Default.MaxAge.ToString();
            txtCardValidity.Text = Properties.Settings.Default.CardValidity.ToString();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            int minAge;
            int maxAge;
            int cardValidity;

            // Kiểm tra và lưu cài đặt
            if (int.TryParse(txtMinAge.Text, out minAge) && int.TryParse(txtMaxAge.Text, out maxAge) && int.TryParse(txtCardValidity.Text, out cardValidity))
            {
                if (minAge > 0 && maxAge > minAge && cardValidity > 0)
                {
                    Properties.Settings.Default.MinAge = minAge;
                    Properties.Settings.Default.MaxAge = maxAge;
                    Properties.Settings.Default.CardValidity = cardValidity;
                    Properties.Settings.Default.Save();

                    MessageBox.Show("Cài đặt đã được lưu thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập các giá trị hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập các giá trị hợp lệ.");
            }
        }
    }
}
