namespace QuanLyCuaHangTapHoa.Reports
{
    partial class frmThongKeSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKeSanPham));
            reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1 = new Panel();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            cboSapXep = new ComboBox();
            btnSapXep = new Button();
            imageList1 = new ImageList(components);
            btnLoc = new Button();
            label3 = new Label();
            cboLoc = new ComboBox();
            label2 = new Label();
            lblThongBao = new Label();
            btnTim = new Button();
            txtTuKhoa = new TextBox();
            label1 = new Label();
            btnThoat = new Button();
            btnRefresh = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer
            // 
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.Location = new Point(0, 181);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(2188, 761);
            reportViewer.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpDenNgay);
            panel1.Controls.Add(dtpTuNgay);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cboSapXep);
            panel1.Controls.Add(btnSapXep);
            panel1.Controls.Add(btnLoc);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cboLoc);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblThongBao);
            panel1.Controls.Add(btnTim);
            panel1.Controls.Add(txtTuKhoa);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnRefresh);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(2188, 181);
            panel1.TabIndex = 1;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(176, 101);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(400, 39);
            dtpDenNgay.TabIndex = 15;
            dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(176, 32);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(400, 39);
            dtpTuNgay.TabIndex = 14;
            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 105);
            label5.Name = "label5";
            label5.Size = new Size(122, 32);
            label5.TabIndex = 13;
            label5.Text = "Đến ngày:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 38);
            label4.Name = "label4";
            label4.Size = new Size(105, 32);
            label4.TabIndex = 12;
            label4.Text = "Từ ngày:";
            // 
            // cboSapXep
            // 
            cboSapXep.FormattingEnabled = true;
            cboSapXep.Items.AddRange(new object[] { "------chọn------", "Giá tăng dần", "Giá giảm dần", "Tồn kho tăng dần", "Tồn kho giảm dần", "Bán chạy nhất" });
            cboSapXep.Location = new Point(1441, 33);
            cboSapXep.Name = "cboSapXep";
            cboSapXep.Size = new Size(242, 40);
            cboSapXep.TabIndex = 11;
            // 
            // btnSapXep
            // 
            btnSapXep.ImageAlign = ContentAlignment.MiddleRight;
            btnSapXep.ImageIndex = 2;
            btnSapXep.ImageList = imageList1;
            btnSapXep.Location = new Point(1701, 29);
            btnSapXep.Name = "btnSapXep";
            btnSapXep.Size = new Size(146, 50);
            btnSapXep.TabIndex = 10;
            btnSapXep.Text = "Sắp xếp";
            btnSapXep.TextAlign = ContentAlignment.MiddleLeft;
            btnSapXep.UseVisualStyleBackColor = true;
            btnSapXep.Click += btnSapXep_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "download (3).jpg");
            imageList1.Images.SetKeyName(1, "Free filter icon vector png - Pixsector_ Free vector images, mockups, PSDs and photos.jpg");
            imageList1.Images.SetKeyName(2, "sort.jpg");
            imageList1.Images.SetKeyName(3, "download (4).jpg");
            imageList1.Images.SetKeyName(4, "Logout free icons designed by SumberRejeki.jpg");
            // 
            // btnLoc
            // 
            btnLoc.ImageAlign = ContentAlignment.MiddleRight;
            btnLoc.ImageIndex = 1;
            btnLoc.ImageList = imageList1;
            btnLoc.Location = new Point(1701, 98);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(146, 50);
            btnLoc.TabIndex = 9;
            btnLoc.Text = "Lọc";
            btnLoc.TextAlign = ContentAlignment.MiddleLeft;
            btnLoc.UseVisualStyleBackColor = true;
            btnLoc.Click += btnLoc_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1332, 38);
            label3.Name = "label3";
            label3.Size = new Size(103, 32);
            label3.TabIndex = 8;
            label3.Text = "Sắp xếp:";
            // 
            // cboLoc
            // 
            cboLoc.FormattingEnabled = true;
            cboLoc.Items.AddRange(new object[] { "Tất cả", "Sắp hết hàng (<10)", "Còn nhiều (>50)" });
            cboLoc.Location = new Point(1441, 103);
            cboLoc.Name = "cboLoc";
            cboLoc.Size = new Size(242, 40);
            cboLoc.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1290, 108);
            label2.Name = "label2";
            label2.Size = new Size(145, 32);
            label2.TabIndex = 6;
            label2.Text = "Lọc tồn kho:";
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Location = new Point(687, 99);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(19, 32);
            lblThongBao.TabIndex = 5;
            lblThongBao.Text = ".";
            // 
            // btnTim
            // 
            btnTim.BackgroundImageLayout = ImageLayout.Stretch;
            btnTim.ImageAlign = ContentAlignment.MiddleRight;
            btnTim.ImageIndex = 0;
            btnTim.ImageList = imageList1;
            btnTim.Location = new Point(1115, 37);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(106, 50);
            btnTim.TabIndex = 4;
            btnTim.Text = "Tìm";
            btnTim.TextAlign = ContentAlignment.MiddleLeft;
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(857, 34);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.Size = new Size(241, 39);
            txtTuKhoa.TabIndex = 3;
            txtTuKhoa.TextChanged += txtTuKhoa_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(681, 45);
            label1.Name = "label1";
            label1.Size = new Size(170, 32);
            label1.TabIndex = 2;
            label1.Text = "Tìm sản phẩm:";
            // 
            // btnThoat
            // 
            btnThoat.ImageAlign = ContentAlignment.MiddleRight;
            btnThoat.Location = new Point(2026, 94);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 50);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Visible = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.ImageAlign = ContentAlignment.MiddleRight;
            btnRefresh.Location = new Point(2026, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 50);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmThongKeSanPham
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2188, 942);
            Controls.Add(reportViewer);
            Controls.Add(panel1);
            Name = "frmThongKeSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmThongKeSanPham";
            Load += frmThongKeSanPham_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private Panel panel1;
        private Button btnThoat;
        private Button btnRefresh;
        private Button btnTim;
        private TextBox txtTuKhoa;
        private Label label1;
        private Label lblThongBao;
        private ComboBox cboLoc;
        private Label label2;
        private Label label3;
        private Button btnSapXep;
        private Button btnLoc;
        private ComboBox cboSapXep;
        private ImageList imageList1;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private Label label5;
        private Label label4;
    }
}