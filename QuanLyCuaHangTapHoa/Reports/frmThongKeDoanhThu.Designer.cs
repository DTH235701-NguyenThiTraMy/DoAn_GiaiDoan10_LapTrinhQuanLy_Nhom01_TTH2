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
            btnThoat = new Button();
            btnTatCa = new Button();
            btnXem = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
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
            panel1.Size = new Size(1592, 147);
            panel1.TabIndex = 0;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1852, 30);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 70);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Visible = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnTatCa
            // 
            btnTatCa.Location = new Point(1657, 30);
            btnTatCa.Name = "btnTatCa";
            btnTatCa.Size = new Size(150, 70);
            btnTatCa.TabIndex = 5;
            btnTatCa.Text = "Hiện tất cả";
            btnTatCa.UseVisualStyleBackColor = true;
            btnTatCa.Click += btnTatCa_Click;
            // 
            // btnXem
            // 
            btnXem.Location = new Point(1411, 30);
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
            dtpDenNgay.Location = new Point(906, 42);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(233, 39);
            dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(444, 42);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(204, 39);
            dtpTuNgay.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(778, 49);
            label2.Name = "label2";
            label2.Size = new Size(122, 32);
            label2.TabIndex = 1;
            label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(333, 49);
            label1.Name = "label1";
            label1.Size = new Size(105, 32);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày:";
            // 
            // reportViewer
            // 
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.Location = new Point(0, 147);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(1592, 524);
            reportViewer.TabIndex = 1;
            // 
            // frmThongKeDoanhThu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1592, 671);
            Controls.Add(reportViewer);
            Controls.Add(panel1);
            Name = "frmThongKeDoanhThu";
            Text = "frmThongKeDoanhThu";
            Load += frmThongKeDoanhThu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
    }
}