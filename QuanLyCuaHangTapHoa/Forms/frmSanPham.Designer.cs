namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmSanPham
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            btnDoiAnh = new Button();
            btnXuat = new Button();
            btnNhap = new Button();
            btnLuu = new Button();
            btnThoat = new Button();
            btnHuy = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            numDonGiaBan = new NumericUpDown();
            numSoLuongTon = new NumericUpDown();
            txtMoTa = new TextBox();
            txtTenSanPham = new TextBox();
            txtMaSanPham = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            picHinhAnh = new PictureBox();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            MaSanPham = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            MoTa = new DataGridViewTextBoxColumn();
            SoLuongTon = new DataGridViewTextBoxColumn();
            DonGiaBan = new DataGridViewTextBoxColumn();
            HinhAnh = new DataGridViewImageColumn();
            txtTimKiem = new TextBox();
            label8 = new Label();
            btnLamMoi = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongTon).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(btnDoiAnh);
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuy);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(numDonGiaBan);
            groupBox1.Controls.Add(numSoLuongTon);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(txtTenSanPham);
            groupBox1.Controls.Add(txtMaSanPham);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1580, 465);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.Location = new Point(1416, 55);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(150, 70);
            btnDoiAnh.TabIndex = 26;
            btnDoiAnh.Text = "Chọn ảnh";
            btnDoiAnh.UseVisualStyleBackColor = true;
            btnDoiAnh.Click += btnDoiAnh_Click;
            // 
            // btnXuat
            // 
            btnXuat.BackColor = Color.LightGreen;
            btnXuat.ForeColor = Color.Green;
            btnXuat.Location = new Point(1671, 358);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(150, 70);
            btnXuat.TabIndex = 25;
            btnXuat.Text = "Xuất Excel";
            btnXuat.UseVisualStyleBackColor = false;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(1416, 358);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(150, 70);
            btnNhap.TabIndex = 24;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = SystemColors.HotTrack;
            btnLuu.Location = new Point(940, 358);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(150, 70);
            btnLuu.TabIndex = 23;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1416, 155);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 70);
            btnThoat.TabIndex = 22;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Visible = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(1173, 358);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(150, 70);
            btnHuy.TabIndex = 21;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(698, 358);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 70);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(461, 358);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 70);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(239, 358);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 70);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // numDonGiaBan
            // 
            numDonGiaBan.Location = new Point(811, 143);
            numDonGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGiaBan.Name = "numDonGiaBan";
            numDonGiaBan.Size = new Size(193, 39);
            numDonGiaBan.TabIndex = 9;
            numDonGiaBan.ThousandsSeparator = true;
            // 
            // numSoLuongTon
            // 
            numSoLuongTon.Location = new Point(811, 55);
            numSoLuongTon.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuongTon.Name = "numSoLuongTon";
            numSoLuongTon.Size = new Size(193, 39);
            numSoLuongTon.TabIndex = 8;
            numSoLuongTon.ThousandsSeparator = true;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(239, 252);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(765, 39);
            txtMoTa.TabIndex = 7;
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Location = new Point(239, 143);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(366, 39);
            txtTenSanPham.TabIndex = 6;
            // 
            // txtMaSanPham
            // 
            txtMaSanPham.Enabled = false;
            txtMaSanPham.Location = new Point(239, 58);
            txtMaSanPham.Name = "txtMaSanPham";
            txtMaSanPham.Size = new Size(366, 39);
            txtMaSanPham.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(672, 143);
            label5.Name = "label5";
            label5.Size = new Size(103, 32);
            label5.TabIndex = 4;
            label5.Text = "Đơn giá:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(672, 57);
            label4.Name = "label4";
            label4.Size = new Size(115, 32);
            label4.TabIndex = 3;
            label4.Text = "Số lượng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 252);
            label3.Name = "label3";
            label3.Size = new Size(193, 32);
            label3.TabIndex = 2;
            label3.Text = "Mô tả sản phẩm:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 146);
            label2.Name = "label2";
            label2.Size = new Size(168, 32);
            label2.TabIndex = 1;
            label2.Text = "Tên sản phẩm:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 57);
            label1.Name = "label1";
            label1.Size = new Size(164, 32);
            label1.TabIndex = 0;
            label1.Text = "Mã sản phẩm:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(picHinhAnh);
            groupBox3.Location = new Point(1041, 27);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(296, 289);
            groupBox3.TabIndex = 27;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hình ảnh";
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(32, 33);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(234, 234);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 10;
            picHinhAnh.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new Point(12, 615);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1580, 222);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, MaSanPham, TenSanPham, MoTa, SoLuongTon, DonGiaBan, HinhAnh });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 35);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 82;
            dataGridView.Size = new Size(1574, 184);
            dataGridView.TabIndex = 0;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 10;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // MaSanPham
            // 
            MaSanPham.DataPropertyName = "MaSanPham";
            MaSanPham.HeaderText = "Mã sản phẩm";
            MaSanPham.MinimumWidth = 10;
            MaSanPham.Name = "MaSanPham";
            MaSanPham.ReadOnly = true;
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Tên sản phẩm";
            TenSanPham.MinimumWidth = 10;
            TenSanPham.Name = "TenSanPham";
            TenSanPham.ReadOnly = true;
            // 
            // MoTa
            // 
            MoTa.DataPropertyName = "MoTa";
            MoTa.HeaderText = "Mô tả";
            MoTa.MinimumWidth = 10;
            MoTa.Name = "MoTa";
            MoTa.ReadOnly = true;
            // 
            // SoLuongTon
            // 
            SoLuongTon.DataPropertyName = "SoLuongTon";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            SoLuongTon.DefaultCellStyle = dataGridViewCellStyle1;
            SoLuongTon.HeaderText = "Số lượng tồn";
            SoLuongTon.MinimumWidth = 10;
            SoLuongTon.Name = "SoLuongTon";
            SoLuongTon.ReadOnly = true;
            // 
            // DonGiaBan
            // 
            DonGiaBan.DataPropertyName = "DonGiaBan";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            DonGiaBan.DefaultCellStyle = dataGridViewCellStyle2;
            DonGiaBan.HeaderText = "Đơn giá";
            DonGiaBan.MinimumWidth = 10;
            DonGiaBan.Name = "DonGiaBan";
            DonGiaBan.ReadOnly = true;
            // 
            // HinhAnh
            // 
            HinhAnh.DataPropertyName = "HinhAnh";
            HinhAnh.HeaderText = "Hình ảnh";
            HinhAnh.MinimumWidth = 10;
            HinhAnh.Name = "HinhAnh";
            HinhAnh.ReadOnly = true;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(170, 523);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(690, 39);
            txtTimKiem.TabIndex = 28;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(46, 526);
            label8.Name = "label8";
            label8.Size = new Size(118, 32);
            label8.TabIndex = 27;
            label8.Text = "Tìm kiếm:";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(952, 507);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 70);
            btnLamMoi.TabIndex = 29;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(1601, 849);
            Controls.Add(btnLamMoi);
            Controls.Add(txtTimKiem);
            Controls.Add(groupBox2);
            Controls.Add(label8);
            Controls.Add(groupBox1);
            Name = "frmSanPham";
            Text = "Sản phẩm";
            Load += frmSanPham_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongTon).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox picHinhAnh;
        private NumericUpDown numDonGiaBan;
        private NumericUpDown numSoLuongTon;
        private TextBox txtMoTa;
        private TextBox txtTenSanPham;
        private TextBox txtMaSanPham;
        private Label label5;
        private Button btnXuat;
        private Button btnNhap;
        private Button btnLuu;
        private Button btnThoat;
        private Button btnHuy;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnDoiAnh;
        private GroupBox groupBox2;
        private DataGridView dataGridView;
        private TextBox txtTimKiem;
        private Label label8;
        private Button btnLamMoi;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn MaSanPham;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn MoTa;
        private DataGridViewTextBoxColumn SoLuongTon;
        private DataGridViewTextBoxColumn DonGiaBan;
        private DataGridViewImageColumn HinhAnh;
        private GroupBox groupBox3;
    }
}