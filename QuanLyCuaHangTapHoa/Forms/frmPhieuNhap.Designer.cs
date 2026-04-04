namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmPhieuNhap
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
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            MaPhieuNhap = new DataGridViewTextBoxColumn();
            TenNhanVien = new DataGridViewTextBoxColumn();
            NgayNhap = new DataGridViewTextBoxColumn();
            TongTien = new DataGridViewTextBoxColumn();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            btnXuat = new Button();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnThoat = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Location = new Point(12, 179);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1216, 326);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách phiếu nhập";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, MaPhieuNhap, TenNhanVien, NgayNhap, TongTien });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 35);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 82;
            dataGridView.Size = new Size(1210, 288);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 10;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // MaPhieuNhap
            // 
            MaPhieuNhap.DataPropertyName = "MaPhieuNhap";
            MaPhieuNhap.HeaderText = "Mã phiếu nhập";
            MaPhieuNhap.MinimumWidth = 10;
            MaPhieuNhap.Name = "MaPhieuNhap";
            MaPhieuNhap.ReadOnly = true;
            // 
            // TenNhanVien
            // 
            TenNhanVien.DataPropertyName = "TenNhanVien";
            TenNhanVien.HeaderText = "Nhân viên";
            TenNhanVien.MinimumWidth = 10;
            TenNhanVien.Name = "TenNhanVien";
            TenNhanVien.ReadOnly = true;
            // 
            // NgayNhap
            // 
            NgayNhap.DataPropertyName = "NgayNhap";
            NgayNhap.HeaderText = "Ngày nhập";
            NgayNhap.MinimumWidth = 10;
            NgayNhap.Name = "NgayNhap";
            NgayNhap.ReadOnly = true;
            // 
            // TongTien
            // 
            TongTien.DataPropertyName = "TongTien";
            TongTien.HeaderText = "Tổng tiền";
            TongTien.MinimumWidth = 10;
            TongTien.Name = "TongTien";
            TongTien.ReadOnly = true;
            // 
            // btnXoa
            // 
            btnXoa.Dock = DockStyle.Fill;
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(754, 10);
            btnXoa.Margin = new Padding(150, 10, 150, 10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(2, 70);
            btnXoa.TabIndex = 16;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Dock = DockStyle.Fill;
            btnSua.Location = new Point(452, 10);
            btnSua.Margin = new Padding(150, 10, 150, 10);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(2, 70);
            btnSua.TabIndex = 15;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Dock = DockStyle.Fill;
            btnThem.Location = new Point(150, 10);
            btnThem.Margin = new Padding(150, 10, 150, 10);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(2, 70);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXuat
            // 
            btnXuat.BackColor = Color.LightGreen;
            btnXuat.Dock = DockStyle.Fill;
            btnXuat.ForeColor = Color.Green;
            btnXuat.Location = new Point(1056, 10);
            btnXuat.Margin = new Padding(150, 10, 150, 10);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(4, 70);
            btnXuat.TabIndex = 27;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = false;
            btnXuat.Click += btnXuat_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(9, 48);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(1216, 63);
            label1.TabIndex = 0;
            label1.Text = "PHIẾU NHẬP";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(btnXoa, 2, 0);
            tableLayoutPanel1.Controls.Add(btnSua, 1, 0);
            tableLayoutPanel1.Controls.Add(btnXuat, 3, 0);
            tableLayoutPanel1.Controls.Add(btnThem, 0, 0);
            tableLayoutPanel1.Location = new Point(15, 588);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1210, 90);
            tableLayoutPanel1.TabIndex = 28;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1103, 515);
            btnThoat.Margin = new Padding(60, 10, 60, 10);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(122, 70);
            btnThoat.TabIndex = 29;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Visible = false;
            // 
            // frmPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(1240, 698);
            Controls.Add(btnThoat);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "frmPhieuNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phiếu nhập";
            Load += frmPhieuNhap_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn MaPhieuNhap;
        private DataGridViewTextBoxColumn TenNhanVien;
        private DataGridViewTextBoxColumn NgayNhap;
        private DataGridViewTextBoxColumn TongTien;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnXuat;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnThoat;
    }
}