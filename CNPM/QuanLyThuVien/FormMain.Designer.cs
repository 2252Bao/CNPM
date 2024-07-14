namespace QuanLyThuVien
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnKhoSach = new Guna.UI2.WinForms.Guna2Button();
            this.btnTrangChu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMuonTraSach = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongKeBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnTraSach = new Guna.UI2.WinForms.Guna2Button();
            this.btnCaiDat = new Guna.UI2.WinForms.Guna2Button();
            this.btnDocGia = new Guna.UI2.WinForms.Guna2Button();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.guna2Panel1.SuspendLayout();
            this.layoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKhoSach
            // 
            this.btnKhoSach.BorderRadius = 10;
            this.btnKhoSach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoSach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhoSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhoSach.FillColor = System.Drawing.Color.AliceBlue;
            this.btnKhoSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btnKhoSach.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoSach.Image")));
            this.btnKhoSach.ImageSize = new System.Drawing.Size(32, 32);
            this.btnKhoSach.Location = new System.Drawing.Point(3, 178);
            this.btnKhoSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnKhoSach.Name = "btnKhoSach";
            this.btnKhoSach.Size = new System.Drawing.Size(293, 58);
            this.btnKhoSach.TabIndex = 3;
            this.btnKhoSach.Text = "Kho sách";
            this.btnKhoSach.Click += new System.EventHandler(this.btnKhoSach_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BorderRadius = 10;
            this.btnTrangChu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTrangChu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTrangChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTrangChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTrangChu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(228)))), ((int)(((byte)(255)))));
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btnTrangChu.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.Image")));
            this.btnTrangChu.ImageSize = new System.Drawing.Size(32, 32);
            this.btnTrangChu.Location = new System.Drawing.Point(3, 52);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(293, 58);
            this.btnTrangChu.TabIndex = 3;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.guna2Panel1.Controls.Add(this.btnMuonTraSach);
            this.guna2Panel1.Controls.Add(this.btnDangXuat);
            this.guna2Panel1.Controls.Add(this.btnThongKeBaoCao);
            this.guna2Panel1.Controls.Add(this.btnTraSach);
            this.guna2Panel1.Controls.Add(this.btnCaiDat);
            this.guna2Panel1.Controls.Add(this.btnKhoSach);
            this.guna2Panel1.Controls.Add(this.btnDocGia);
            this.guna2Panel1.Controls.Add(this.btnTrangChu);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(2, 2);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(296, 718);
            this.guna2Panel1.TabIndex = 1;
            // 
            // btnMuonTraSach
            // 
            this.btnMuonTraSach.BorderRadius = 10;
            this.btnMuonTraSach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMuonTraSach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMuonTraSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMuonTraSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMuonTraSach.FillColor = System.Drawing.Color.AliceBlue;
            this.btnMuonTraSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuonTraSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btnMuonTraSach.Image = ((System.Drawing.Image)(resources.GetObject("btnMuonTraSach.Image")));
            this.btnMuonTraSach.ImageSize = new System.Drawing.Size(32, 32);
            this.btnMuonTraSach.Location = new System.Drawing.Point(3, 302);
            this.btnMuonTraSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnMuonTraSach.Name = "btnMuonTraSach";
            this.btnMuonTraSach.Size = new System.Drawing.Size(293, 58);
            this.btnMuonTraSach.TabIndex = 3;
            this.btnMuonTraSach.Text = "Mượn / Trả sách";
            this.btnMuonTraSach.Click += new System.EventHandler(this.btnMuonTraSach_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.BorderRadius = 10;
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btnDangXuat.ImageSize = new System.Drawing.Size(32, 32);
            this.btnDangXuat.Location = new System.Drawing.Point(30, 641);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(216, 50);
            this.btnDangXuat.TabIndex = 3;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThongKeBaoCao
            // 
            this.btnThongKeBaoCao.BorderRadius = 10;
            this.btnThongKeBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKeBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKeBaoCao.FillColor = System.Drawing.Color.AliceBlue;
            this.btnThongKeBaoCao.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btnThongKeBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKeBaoCao.Image")));
            this.btnThongKeBaoCao.ImageSize = new System.Drawing.Size(32, 32);
            this.btnThongKeBaoCao.Location = new System.Drawing.Point(3, 364);
            this.btnThongKeBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.btnThongKeBaoCao.Name = "btnThongKeBaoCao";
            this.btnThongKeBaoCao.Size = new System.Drawing.Size(293, 58);
            this.btnThongKeBaoCao.TabIndex = 3;
            this.btnThongKeBaoCao.Text = "Thống kê - báo cáo";
            this.btnThongKeBaoCao.Click += new System.EventHandler(this.btnThongKeBaoCao_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.BorderRadius = 10;
            this.btnTraSach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTraSach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTraSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTraSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTraSach.FillColor = System.Drawing.Color.AliceBlue;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btnTraSach.Image = ((System.Drawing.Image)(resources.GetObject("btnTraSach.Image")));
            this.btnTraSach.ImageSize = new System.Drawing.Size(32, 32);
            this.btnTraSach.Location = new System.Drawing.Point(3, 240);
            this.btnTraSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(293, 58);
            this.btnTraSach.TabIndex = 3;
            this.btnTraSach.Text = "Tra sách";
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.BorderRadius = 10;
            this.btnCaiDat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCaiDat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCaiDat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCaiDat.FillColor = System.Drawing.Color.AliceBlue;
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaiDat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btnCaiDat.Image = ((System.Drawing.Image)(resources.GetObject("btnCaiDat.Image")));
            this.btnCaiDat.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCaiDat.Location = new System.Drawing.Point(3, 426);
            this.btnCaiDat.Margin = new System.Windows.Forms.Padding(2);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(293, 58);
            this.btnCaiDat.TabIndex = 3;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // btnDocGia
            // 
            this.btnDocGia.BorderRadius = 10;
            this.btnDocGia.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDocGia.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDocGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDocGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDocGia.FillColor = System.Drawing.Color.AliceBlue;
            this.btnDocGia.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btnDocGia.Image = ((System.Drawing.Image)(resources.GetObject("btnDocGia.Image")));
            this.btnDocGia.ImageSize = new System.Drawing.Size(32, 32);
            this.btnDocGia.Location = new System.Drawing.Point(3, 115);
            this.btnDocGia.Margin = new System.Windows.Forms.Padding(2);
            this.btnDocGia.Name = "btnDocGia";
            this.btnDocGia.Size = new System.Drawing.Size(293, 58);
            this.btnDocGia.TabIndex = 3;
            this.btnDocGia.Text = "Đọc giả";
            this.btnDocGia.Click += new System.EventHandler(this.btnDocGia_Click);
            // 
            // layoutMain
            // 
            this.layoutMain.BackColor = System.Drawing.Color.AliceBlue;
            this.layoutMain.ColumnCount = 2;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Controls.Add(this.guna2Panel1, 0, 0);
            this.layoutMain.Controls.Add(this.pnlContent, 1, 0);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 1;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Size = new System.Drawing.Size(1439, 722);
            this.layoutMain.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(300, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1139, 722);
            this.pnlContent.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 722);
            this.Controls.Add(this.layoutMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ THƯ VIỆN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.layoutMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnKhoSach;
        private Guna.UI2.WinForms.Guna2Button btnTrangChu;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnDocGia;
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Button btnCaiDat;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private Guna.UI2.WinForms.Guna2Button btnThongKeBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnMuonTraSach;
        private Guna.UI2.WinForms.Guna2Button btnTraSach;
    }
}