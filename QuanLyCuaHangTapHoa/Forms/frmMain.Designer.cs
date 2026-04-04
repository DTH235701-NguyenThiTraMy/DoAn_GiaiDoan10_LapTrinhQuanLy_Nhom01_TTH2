namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            menuStrip1 = new MenuStrip();
            mnuTrangChu = new ToolStripMenuItem();
            mnuHeThong = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            mnuThoat = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            mnuSanPham = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            mnuHoaDon = new ToolStripMenuItem();
            mnuPhieuNhap = new ToolStripMenuItem();
            mnuBaoCaoThongKe = new ToolStripMenuItem();
            mnuThongKeSanPham = new ToolStripMenuItem();
            mnuThongKeDoanhThu = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            mnuHuongDanSuDung = new ToolStripMenuItem();
            mnuThongTinPhanMem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblLienKet = new ToolStripStatusLabel();
            sidebarTimer = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuTrangChu, mnuHeThong, mnuQuanLy, mnuPhieuNhap, mnuBaoCaoThongKe, trợGiúpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1384, 44);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuTrangChu
            // 
            mnuTrangChu.DisplayStyle = ToolStripItemDisplayStyle.Image;
            mnuTrangChu.Image = (Image)resources.GetObject("mnuTrangChu.Image");
            mnuTrangChu.Margin = new Padding(2);
            mnuTrangChu.Name = "mnuTrangChu";
            mnuTrangChu.Size = new Size(52, 36);
            mnuTrangChu.Text = "     ";
            mnuTrangChu.Click += mnuTrangChu_Click;
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangNhap, mnuDangXuat, mnuDoiMatKhau, toolStripMenuItem1, mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(135, 40);
            mnuHeThong.Text = "&Hệ thống";
            // 
            // mnuDangNhap
            // 
            mnuDangNhap.Name = "mnuDangNhap";
            mnuDangNhap.Size = new Size(292, 44);
            mnuDangNhap.Text = "Đăng &nhập";
            mnuDangNhap.Click += mnuDangNhap_Click;
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(292, 44);
            mnuDangXuat.Text = "Đăng &xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuDoiMatKhau
            // 
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(292, 44);
            mnuDoiMatKhau.Text = "Đổi &mật khẩu";
            mnuDoiMatKhau.Click += mnuDoiMatKhau_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(289, 6);
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuThoat.Size = new Size(292, 44);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuKhachHang, mnuNhanVien, toolStripMenuItem2, mnuSanPham, toolStripMenuItem3, mnuHoaDon });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(117, 40);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(347, 44);
            mnuKhachHang.Text = "&Khách hàng ";
            mnuKhachHang.Click += mnuKhachHang_Click;
            // 
            // mnuNhanVien
            // 
            mnuNhanVien.Name = "mnuNhanVien";
            mnuNhanVien.Size = new Size(347, 44);
            mnuNhanVien.Text = "&Nhân viên";
            mnuNhanVien.Click += mnuNhanVien_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(344, 6);
            // 
            // mnuSanPham
            // 
            mnuSanPham.Name = "mnuSanPham";
            mnuSanPham.Size = new Size(347, 44);
            mnuSanPham.Text = "&Sản phẩm";
            mnuSanPham.Click += mnuSanPham_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(344, 6);
            // 
            // mnuHoaDon
            // 
            mnuHoaDon.Name = "mnuHoaDon";
            mnuHoaDon.Size = new Size(347, 44);
            mnuHoaDon.Text = "Hóa đơn bán hàng";
            mnuHoaDon.Click += mnuHoaDon_Click;
            // 
            // mnuPhieuNhap
            // 
            mnuPhieuNhap.Name = "mnuPhieuNhap";
            mnuPhieuNhap.Size = new Size(153, 40);
            mnuPhieuNhap.Text = "Nhậ&p hàng";
            mnuPhieuNhap.Click += mnuNhapHang_Click;
            // 
            // mnuBaoCaoThongKe
            // 
            mnuBaoCaoThongKe.DropDownItems.AddRange(new ToolStripItem[] { mnuThongKeSanPham, mnuThongKeDoanhThu });
            mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe";
            mnuBaoCaoThongKe.Size = new Size(243, 40);
            mnuBaoCaoThongKe.Text = "&Báo cáo - Thống kê";
            // 
            // mnuThongKeSanPham
            // 
            mnuThongKeSanPham.Name = "mnuThongKeSanPham";
            mnuThongKeSanPham.Size = new Size(366, 44);
            mnuThongKeSanPham.Text = "Thống kê &sản phẩm";
            mnuThongKeSanPham.Click += mnuThongKeSanPham_Click;
            // 
            // mnuThongKeDoanhThu
            // 
            mnuThongKeDoanhThu.Name = "mnuThongKeDoanhThu";
            mnuThongKeDoanhThu.Size = new Size(366, 44);
            mnuThongKeDoanhThu.Text = "Thống kê &doanh thu";
            mnuThongKeDoanhThu.Click += mnuThongKeDoanhThu_Click;
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuHuongDanSuDung, mnuThongTinPhanMem });
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(122, 40);
            trợGiúpToolStripMenuItem.Text = "&Trợ giúp";
            // 
            // mnuHuongDanSuDung
            // 
            mnuHuongDanSuDung.Name = "mnuHuongDanSuDung";
            mnuHuongDanSuDung.ShortcutKeys = Keys.Control | Keys.F1;
            mnuHuongDanSuDung.Size = new Size(453, 44);
            mnuHuongDanSuDung.Text = "&Hướng dẫn sử dụng";
            mnuHuongDanSuDung.Click += mnuHuongDanSuDung_Click;
            // 
            // mnuThongTinPhanMem
            // 
            mnuThongTinPhanMem.Name = "mnuThongTinPhanMem";
            mnuThongTinPhanMem.Size = new Size(453, 44);
            mnuThongTinPhanMem.Text = "&Thông tin phần mềm";
            mnuThongTinPhanMem.Click += mnuThongTinPhanMem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.Control;
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai, toolStripStatusLabel1, lblLienKet });
            statusStrip1.Location = new Point(0, 823);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1384, 42);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(191, 32);
            lblTrangThai.Text = "Chưa đăng nhập";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(977, 32);
            toolStripStatusLabel1.Spring = true;
            // 
            // lblLienKet
            // 
            lblLienKet.IsLink = true;
            lblLienKet.Name = "lblLienKet";
            lblLienKet.Size = new Size(139, 32);
            lblLienKet.Text = "© 2026 FIT ";
            lblLienKet.Click += lblLienKet_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 865);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý cửa hàng tạp hóa";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripMenuItem mnuQuanLy;
        private StatusStrip statusStrip1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem mnuSanPham;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem mnuHoaDon;
        private ToolStripMenuItem mnuPhieuNhap;
        private ToolStripMenuItem mnuBaoCaoThongKe;
        private ToolStripMenuItem mnuThongKeSanPham;
        private ToolStripMenuItem mnuThongKeDoanhThu;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private ToolStripMenuItem mnuHuongDanSuDung;
        private ToolStripMenuItem mnuThongTinPhanMem;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblLienKet;
        private System.Windows.Forms.Timer sidebarTimer;
        private ToolStripMenuItem mnuTrangChu;
    }
}