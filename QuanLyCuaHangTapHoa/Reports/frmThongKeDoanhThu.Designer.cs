namespace QuanLyCuaHangTapHoa.Reports
{
    partial class frmThongKeDoanhThu
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
            panel1 = new Panel();
            label5 = new Label();
            panel3 = new Panel();
            label4 = new Label();
            lblTongDonHang = new Label();
            panel2 = new Panel();
            label3 = new Label();
            lblTongDoanhThu = new Label();
            cboLocNhanh = new ComboBox();
            btnThoat = new Button();
            btnTatCa = new Button();
            btnXem = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(cboLocNhanh);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnTatCa);
            panel1.Controls.Add(btnXem);
            panel1.Controls.Add(dtpDenNgay);
            panel1.Controls.Add(dtpTuNgay);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1374, 170);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(964, 56);
            label5.Name = "label5";
            label5.Size = new Size(130, 32);
            label5.TabIndex = 13;
            label5.Text = "Lọc nhanh:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightSkyBlue;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(lblTongDonHang);
            panel3.Location = new Point(435, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(309, 90);
            panel3.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.WindowText;
            label4.Location = new Point(3, 3);
            label4.Name = "label4";
            label4.Size = new Size(291, 37);
            label4.TabIndex = 0;
            label4.Text = "TỔNG SỐ ĐƠN HÀNG";
            // 
            // lblTongDonHang
            // 
            lblTongDonHang.AutoSize = true;
            lblTongDonHang.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongDonHang.ForeColor = Color.Blue;
            lblTongDonHang.Location = new Point(9, 43);
            lblTongDonHang.Name = "lblTongDonHang";
            lblTongDonHang.Size = new Size(96, 37);
            lblTongDonHang.TabIndex = 8;
            lblTongDonHang.Text = "label3";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSeaGreen;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblTongDoanhThu);
            panel2.Location = new Point(34, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(288, 91);
            panel2.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.WindowText;
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(265, 37);
            label3.TabIndex = 0;
            label3.Text = "TỔNG DOANH THU";
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongDoanhThu.ForeColor = Color.DarkGreen;
            lblTongDoanhThu.Location = new Point(7, 44);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(96, 37);
            lblTongDoanhThu.TabIndex = 7;
            lblTongDoanhThu.Text = "label3";
            // 
            // cboLocNhanh
            // 
            cboLocNhanh.FormattingEnabled = true;
            cboLocNhanh.Items.AddRange(new object[] { " ------  Chọn  ------", "Hôm nay", "Tháng này", "Tất cả" });
            cboLocNhanh.Location = new Point(1110, 50);
            cboLocNhanh.Name = "cboLocNhanh";
            cboLocNhanh.Size = new Size(242, 40);
            cboLocNhanh.TabIndex = 10;
            cboLocNhanh.SelectedIndexChanged += cboLocNhanh_SelectedIndexChanged;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(345, 55);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(72, 35);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Visible = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnTatCa
            // 
            btnTatCa.Location = new Point(2283, 94);
            btnTatCa.Name = "btnTatCa";
            btnTatCa.Size = new Size(150, 70);
            btnTatCa.TabIndex = 5;
            btnTatCa.Text = "Hiện tất cả";
            btnTatCa.UseVisualStyleBackColor = true;
            btnTatCa.Click += btnTatCa_Click;
            // 
            // btnXem
            // 
            btnXem.Location = new Point(2283, 12);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(150, 70);
            btnXem.TabIndex = 4;
            btnXem.Text = "Lọc";
            btnXem.UseVisualStyleBackColor = true;
            btnXem.Click += btnXem_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(1970, 48);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(204, 39);
            dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(1597, 51);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(204, 39);
            dtpTuNgay.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1832, 53);
            label2.Name = "label2";
            label2.Size = new Size(122, 32);
            label2.TabIndex = 1;
            label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1472, 56);
            label1.Name = "label1";
            label1.Size = new Size(105, 32);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày:";
            // 
            // reportViewer
            // 
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.Location = new Point(0, 170);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(1374, 501);
            reportViewer.TabIndex = 1;
            // 
            // frmThongKeDoanhThu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 671);
            Controls.Add(reportViewer);
            Controls.Add(panel1);
            Name = "frmThongKeDoanhThu";
            Text = "frmThongKeDoanhThu";
            Load += frmThongKeDoanhThu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DateTimePicker dtpTuNgay;
        private Label label2;
        private Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private Button btnXem;
        private DateTimePicker dtpDenNgay;
        private Button btnTatCa;
        private Button btnThoat;
        private Label lblTongDoanhThu;
        private ComboBox cboLocNhanh;
        private Label lblTongDonHang;
        private Panel panel2;
        private Label label3;
        private Panel panel3;
        private Label label4;
        private Label label5;
    }
}