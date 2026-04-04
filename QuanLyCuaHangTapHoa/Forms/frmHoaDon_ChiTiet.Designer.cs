namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmHoaDon_ChiTiet
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            txtGhiChuHoaDon = new TextBox();
            cboKhachHang = new ComboBox();
            cboNhanVien = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            SanPhamID = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            DonGiaBan = new DataGridViewTextBoxColumn();
            SoLuongBan = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            btnXoa = new Button();
            btnXacNhanBan = new Button();
            numDonGiaBan = new NumericUpDown();
            numSoLuongBan = new NumericUpDown();
            cboSanPham = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            btnLuuHoaDon = new Button();
            btnInHoaDon = new Button();
            btnThoat = new Button();
            lblTongTien = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(txtGhiChuHoaDon);
            groupBox1.Controls.Add(cboKhachHang);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1090, 196);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            // 
            // txtGhiChuHoaDon
            // 
            txtGhiChuHoaDon.Location = new Point(195, 129);
            txtGhiChuHoaDon.Name = "txtGhiChuHoaDon";
            txtGhiChuHoaDon.Size = new Size(805, 39);
            txtGhiChuHoaDon.TabIndex = 5;
            // 
            // cboKhachHang
            // 
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(712, 56);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(288, 40);
            cboKhachHang.TabIndex = 4;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(195, 56);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(295, 40);
            cboNhanVien.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 136);
            label3.Name = "label3";
            label3.Size = new Size(101, 32);
            label3.TabIndex = 2;
            label3.Text = "Ghi chú:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(550, 59);
            label2.Name = "label2";
            label2.Size = new Size(145, 32);
            label2.TabIndex = 1;
            label2.Text = "Khách hàng:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 56);
            label1.Name = "label1";
            label1.Size = new Size(129, 32);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnXacNhanBan);
            groupBox2.Controls.Add(numDonGiaBan);
            groupBox2.Controls.Add(numSoLuongBan);
            groupBox2.Controls.Add(cboSanPham);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(12, 226);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1090, 493);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết hóa đơn";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { SanPhamID, TenSanPham, DonGiaBan, SoLuongBan, ThanhTien });
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(3, 190);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 82;
            dataGridView.Size = new Size(1084, 300);
            dataGridView.TabIndex = 22;
            // 
            // SanPhamID
            // 
            SanPhamID.DataPropertyName = "SanPhamID";
            SanPhamID.HeaderText = "ID";
            SanPhamID.MinimumWidth = 10;
            SanPhamID.Name = "SanPhamID";
            SanPhamID.ReadOnly = true;
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Tên sản phẩm";
            TenSanPham.MinimumWidth = 10;
            TenSanPham.Name = "TenSanPham";
            TenSanPham.ReadOnly = true;
            // 
            // DonGiaBan
            // 
            DonGiaBan.DataPropertyName = "DonGiaBan";
            DonGiaBan.HeaderText = "Đơn giá";
            DonGiaBan.MinimumWidth = 10;
            DonGiaBan.Name = "DonGiaBan";
            DonGiaBan.ReadOnly = true;
            // 
            // SoLuongBan
            // 
            SoLuongBan.DataPropertyName = "SoLuongBan";
            SoLuongBan.HeaderText = "Số lượng";
            SoLuongBan.MinimumWidth = 10;
            SoLuongBan.Name = "SoLuongBan";
            SoLuongBan.ReadOnly = true;
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(0, 0, 192);
            ThanhTien.DefaultCellStyle = dataGridViewCellStyle1;
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 10;
            ThanhTien.Name = "ThanhTien";
            ThanhTien.ReadOnly = true;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(893, 99);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(184, 46);
            btnXoa.TabIndex = 21;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXacNhanBan
            // 
            btnXacNhanBan.Location = new Point(893, 31);
            btnXacNhanBan.Name = "btnXacNhanBan";
            btnXacNhanBan.Size = new Size(184, 56);
            btnXacNhanBan.TabIndex = 6;
            btnXacNhanBan.Text = "Xác nhận bán";
            btnXacNhanBan.UseVisualStyleBackColor = true;
            btnXacNhanBan.Click += button1_Click;
            // 
            // numDonGiaBan
            // 
            numDonGiaBan.Location = new Point(650, 105);
            numDonGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGiaBan.Name = "numDonGiaBan";
            numDonGiaBan.Size = new Size(184, 39);
            numDonGiaBan.TabIndex = 5;
            numDonGiaBan.ThousandsSeparator = true;
            // 
            // numSoLuongBan
            // 
            numSoLuongBan.Location = new Point(409, 106);
            numSoLuongBan.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuongBan.Name = "numSoLuongBan";
            numSoLuongBan.Size = new Size(181, 39);
            numSoLuongBan.TabIndex = 4;
            numSoLuongBan.ThousandsSeparator = true;
            // 
            // cboSanPham
            // 
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(29, 105);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(312, 40);
            cboSanPham.TabIndex = 3;
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(650, 67);
            label6.Name = "label6";
            label6.Size = new Size(98, 32);
            label6.TabIndex = 2;
            label6.Text = "Đơn giá";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(409, 67);
            label5.Name = "label5";
            label5.Size = new Size(110, 32);
            label5.TabIndex = 1;
            label5.Text = "Số lượng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 55);
            label4.Name = "label4";
            label4.Size = new Size(121, 32);
            label4.TabIndex = 0;
            label4.Text = "Sản phẩm";
            // 
            // btnLuuHoaDon
            // 
            btnLuuHoaDon.BackColor = SystemColors.Control;
            btnLuuHoaDon.Location = new Point(155, 744);
            btnLuuHoaDon.Name = "btnLuuHoaDon";
            btnLuuHoaDon.Size = new Size(198, 65);
            btnLuuHoaDon.TabIndex = 2;
            btnLuuHoaDon.Text = "Lưu hóa đơn";
            btnLuuHoaDon.UseVisualStyleBackColor = false;
            btnLuuHoaDon.Click += btnLuuHoaDon_Click;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.BackColor = SystemColors.Control;
            btnInHoaDon.ForeColor = Color.Green;
            btnInHoaDon.Location = new Point(435, 744);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(223, 65);
            btnInHoaDon.TabIndex = 3;
            btnInHoaDon.Text = "In hóa đơn";
            btnInHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.Control;
            btnThoat.Location = new Point(724, 744);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(185, 65);
            btnThoat.TabIndex = 24;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(15, 803);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(78, 32);
            lblTongTien.TabIndex = 25;
            lblTongTien.Text = "label7";
            lblTongTien.Visible = false;
            // 
            // frmHoaDon_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1105, 829);
            Controls.Add(lblTongTien);
            Controls.Add(btnThoat);
            Controls.Add(btnInHoaDon);
            Controls.Add(btnLuuHoaDon);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmHoaDon_ChiTiet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa đơn chi tiết";
            Load += frmHoaDon_ChiTiet_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private ComboBox cboNhanVien;
        private Label label3;
        private TextBox txtGhiChuHoaDon;
        private ComboBox cboKhachHang;
        private GroupBox groupBox2;
        private NumericUpDown numDonGiaBan;
        private NumericUpDown numSoLuongBan;
        private ComboBox cboSanPham;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnXacNhanBan;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn SanPhamID;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn DonGiaBan;
        private DataGridViewTextBoxColumn SoLuongBan;
        private DataGridViewTextBoxColumn ThanhTien;
        private Button btnXoa;
        private Button btnLuuHoaDon;
        private Button btnInHoaDon;
        private Button btnThoat;
        private Label lblTongTien;
    }
}