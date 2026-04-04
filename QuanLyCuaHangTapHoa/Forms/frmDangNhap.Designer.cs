namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            pictureBox2 = new PictureBox();
            btnDangNhap = new Button();
            btnHuyBo = new Button();
            chkHienMK = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 546);
            panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(3, 154);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(287, 189);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(448, 62);
            label1.Name = "label1";
            label1.Size = new Size(354, 71);
            label1.TabIndex = 1;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(383, 201);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 47);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(459, 201);
            txtTenDangNhap.Multiline = true;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(383, 47);
            txtTenDangNhap.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(459, 289);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(383, 46);
            txtMatKhau.TabIndex = 5;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ControlLightLight;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(383, 289);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 47);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.MidnightBlue;
            btnDangNhap.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(433, 424);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(174, 60);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.CornflowerBlue;
            btnHuyBo.ForeColor = SystemColors.ButtonHighlight;
            btnHuyBo.Location = new Point(653, 424);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(168, 60);
            btnHuyBo.TabIndex = 7;
            btnHuyBo.Text = "Hủy";
            btnHuyBo.UseVisualStyleBackColor = false;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // chkHienMK
            // 
            chkHienMK.AutoSize = true;
            chkHienMK.Location = new Point(459, 356);
            chkHienMK.Name = "chkHienMK";
            chkHienMK.Size = new Size(203, 36);
            chkHienMK.TabIndex = 8;
            chkHienMK.Text = "Hiện mật khẩu";
            chkHienMK.UseVisualStyleBackColor = true;
            chkHienMK.CheckedChanged += chkHienMK_CheckedChanged;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(943, 546);
            Controls.Add(chkHienMK);
            Controls.Add(btnHuyBo);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(pictureBox2);
            Controls.Add(txtTenDangNhap);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        public TextBox txtTenDangNhap;
        public TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnHuyBo;
        private PictureBox pictureBox3;
        private CheckBox chkHienMK;
    }
}