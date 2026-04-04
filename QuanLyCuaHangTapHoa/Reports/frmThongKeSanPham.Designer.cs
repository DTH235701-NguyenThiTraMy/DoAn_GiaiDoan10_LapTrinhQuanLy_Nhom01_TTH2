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
            reportViewer.Location = new Point(0, 168);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(1556, 774);
            reportViewer.TabIndex = 0;
            // 
            // panel1
            // 
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
            panel1.Size = new Size(1556, 168);
            panel1.TabIndex = 1;
            // 
            // cboSapXep
            // 
            cboSapXep.FormattingEnabled = true;
            cboSapXep.Items.AddRange(new object[] { "------chọn------", "Giá tăng dần", "Giá giảm dần", "Tồn kho tăng dần", "Tồn kho giảm dần" });
            cboSapXep.Location = new Point(1371, 27);
            cboSapXep.Name = "cboSapXep";
            cboSapXep.Size = new Size(242, 40);
            cboSapXep.TabIndex = 11;
            // 
            // btnSapXep
            // 
            btnSapXep.ImageIndex = 2;
            btnSapXep.ImageList = imageList1;
            btnSapXep.Location = new Point(1633, 22);
            btnSapXep.Name = "btnSapXep";
            btnSapXep.Size = new Size(60, 51);
            btnSapXep.TabIndex = 10;
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
            btnLoc.ImageIndex = 1;
            btnLoc.ImageList = imageList1;
            btnLoc.Location = new Point(1066, 22);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(56, 48);
            btnLoc.TabIndex = 9;
            btnLoc.UseVisualStyleBackColor = true;
            btnLoc.Click += btnLoc_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1262, 32);
            label3.Name = "label3";
            label3.Size = new Size(103, 32);
            label3.TabIndex = 8;
            label3.Text = "Sắp xếp:";
            // 
            // cboLoc
            // 
            cboLoc.FormattingEnabled = true;
            cboLoc.Items.AddRange(new object[] { "Tất cả", "Sắp hết hàng (<10)", "Còn nhiều (>50)" });
            cboLoc.Location = new Point(801, 27);
            cboLoc.Name = "cboLoc";
            cboLoc.Size = new Size(242, 40);
            cboLoc.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(650, 34);
            label2.Name = "label2";
            label2.Size = new Size(145, 32);
            label2.TabIndex = 6;
            label2.Text = "Lọc tồn kho:";
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Location = new Point(12, 92);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(19, 32);
            lblThongBao.TabIndex = 5;
            lblThongBao.Text = ".";
            // 
            // btnTim
            // 
            btnTim.BackgroundImageLayout = ImageLayout.Stretch;
            btnTim.ImageIndex = 0;
            btnTim.ImageList = imageList1;
            btnTim.Location = new Point(444, 24);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(52, 50);
            btnTim.TabIndex = 4;
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(182, 27);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.Size = new Size(241, 39);
            txtTuKhoa.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 34);
            label1.Name = "label1";
            label1.Size = new Size(170, 32);
            label1.TabIndex = 2;
            label1.Text = "Tìm sản phẩm:";
            // 
            // btnThoat
            // 
            btnThoat.ImageAlign = ContentAlignment.MiddleRight;
            btnThoat.Location = new Point(1915, 92);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 46);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.ImageAlign = ContentAlignment.MiddleRight;
            btnRefresh.Location = new Point(1915, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 46);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmThongKeSanPham
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1556, 942);
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
    }
}