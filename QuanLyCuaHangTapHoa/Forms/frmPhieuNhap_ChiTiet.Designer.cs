namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmPhieuNhap_ChiTiet
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
            groupBox1 = new GroupBox();
            txtGhiChu = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            cboNhanVien = new ComboBox();
            txtMaPhieuNhap = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnCong = new Button();
            dataGridView = new DataGridView();
            SanPhamID = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            btnXoa = new Button();
            btnXacNhanNhap = new Button();
            numDonGia = new NumericUpDown();
            numSoLuong = new NumericUpDown();
            cboSanPham = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label7 = new Label();
            btnThoat = new Button();
            btnLuu = new Button();
            lblTongTien = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(dtpNgayNhap);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(txtMaPhieuNhap);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1098, 238);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(180, 176);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(897, 39);
            txtGhiChu.TabIndex = 7;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(649, 102);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(428, 39);
            dtpNgayNhap.TabIndex = 6;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(180, 104);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(268, 40);
            cboNhanVien.TabIndex = 5;
            // 
            // txtMaPhieuNhap
            // 
            txtMaPhieuNhap.Location = new Point(180, 38);
            txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            txtMaPhieuNhap.ReadOnly = true;
            txtMaPhieuNhap.Size = new Size(268, 39);
            txtMaPhieuNhap.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 179);
            label4.Name = "label4";
            label4.Size = new Size(101, 32);
            label4.TabIndex = 3;
            label4.Text = "Ghi chú:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(507, 107);
            label3.Name = "label3";
            label3.Size = new Size(136, 32);
            label3.TabIndex = 2;
            label3.Text = "Ngày nhập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 107);
            label2.Name = "label2";
            label2.Size = new Size(129, 32);
            label2.TabIndex = 1;
            label2.Text = "Nhân viên:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 41);
            label1.Name = "label1";
            label1.Size = new Size(91, 32);
            label1.TabIndex = 0;
            label1.Text = "Mã PN:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(btnCong);
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnXacNhanNhap);
            groupBox2.Controls.Add(numDonGia);
            groupBox2.Controls.Add(numSoLuong);
            groupBox2.Controls.Add(cboSanPham);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(12, 270);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1098, 491);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết phiếu nhập";
            // 
            // btnCong
            // 
            btnCong.Location = new Point(275, 97);
            btnCong.Name = "btnCong";
            btnCong.Size = new Size(50, 50);
            btnCong.TabIndex = 25;
            btnCong.Text = "+";
            btnCong.UseVisualStyleBackColor = true;
            btnCong.Click += btnCong_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { SanPhamID, TenSanPham, SoLuong, DonGia, ThanhTien });
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(3, 188);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 82;
            dataGridView.Size = new Size(1092, 300);
            dataGridView.TabIndex = 24;
            // 
            // SanPhamID
            // 
            SanPhamID.DataPropertyName = "SanPhamID";
            SanPhamID.HeaderText = "ID";
            SanPhamID.MinimumWidth = 10;
            SanPhamID.Name = "SanPhamID";
            SanPhamID.ReadOnly = true;
            SanPhamID.Visible = false;
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Sản phẩm";
            TenSanPham.MinimumWidth = 10;
            TenSanPham.Name = "TenSanPham";
            TenSanPham.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 10;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn giá";
            DonGia.MinimumWidth = 10;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 10;
            ThanhTien.Name = "ThanhTien";
            ThanhTien.ReadOnly = true;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(875, 94);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(202, 46);
            btnXoa.TabIndex = 23;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXacNhanNhap
            // 
            btnXacNhanNhap.Location = new Point(875, 26);
            btnXacNhanNhap.Name = "btnXacNhanNhap";
            btnXacNhanNhap.Size = new Size(202, 56);
            btnXacNhanNhap.TabIndex = 22;
            btnXacNhanNhap.Text = "Xác nhận nhập";
            btnXacNhanNhap.UseVisualStyleBackColor = true;
            btnXacNhanNhap.Click += btnXacNhanNhap_Click;
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(648, 100);
            numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(184, 39);
            numDonGia.TabIndex = 11;
            numDonGia.ThousandsSeparator = true;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(363, 101);
            numSoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(181, 39);
            numSoLuong.TabIndex = 10;
            numSoLuong.ThousandsSeparator = true;
            // 
            // cboSanPham
            // 
            cboSanPham.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboSanPham.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(27, 100);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(242, 40);
            cboSanPham.TabIndex = 9;
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(648, 62);
            label6.Name = "label6";
            label6.Size = new Size(98, 32);
            label6.TabIndex = 8;
            label6.Text = "Đơn giá";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(363, 62);
            label5.Name = "label5";
            label5.Size = new Size(110, 32);
            label5.TabIndex = 7;
            label5.Text = "Số lượng";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 50);
            label7.Name = "label7";
            label7.Size = new Size(121, 32);
            label7.TabIndex = 6;
            label7.Text = "Sản phẩm";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(712, 792);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(180, 70);
            btnThoat.TabIndex = 26;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(280, 792);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(180, 70);
            btnLuu.TabIndex = 25;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(15, 764);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(78, 32);
            lblTongTien.TabIndex = 27;
            lblTongTien.Text = "label8";
            // 
            // frmPhieuNhap_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(1134, 874);
            Controls.Add(lblTongTien);
            Controls.Add(btnThoat);
            Controls.Add(groupBox2);
            Controls.Add(btnLuu);
            Controls.Add(groupBox1);
            Name = "frmPhieuNhap_ChiTiet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Phiếu nhập Chi tiết";
            Load += frmPhieuNhap_ChiTiet_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtGhiChu;
        private DateTimePicker dtpNgayNhap;
        private ComboBox cboNhanVien;
        private TextBox txtMaPhieuNhap;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private NumericUpDown numDonGia;
        private NumericUpDown numSoLuong;
        private ComboBox cboSanPham;
        private Label label6;
        private Label label5;
        private Label label7;
        private Button btnXoa;
        private Button btnXacNhanNhap;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn SanPhamID;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn ThanhTien;
        private Button btnThoat;
        private Button btnLuu;
        private Label lblTongTien;
        private Button btnCong;
    }
}