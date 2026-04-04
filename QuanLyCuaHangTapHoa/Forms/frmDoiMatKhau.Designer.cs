namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmDoiMatKhau
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
            label1 = new Label();
            label2 = new Label();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            chkHienMatKhau = new CheckBox();
            txtXacNhan = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 34);
            label1.Name = "label1";
            label1.Size = new Size(216, 32);
            label1.TabIndex = 0;
            label1.Text = "Nhập mật khẩu cũ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 112);
            label2.Name = "label2";
            label2.Size = new Size(232, 32);
            label2.TabIndex = 1;
            label2.Text = "Nhập mật khẩu mới:";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(288, 31);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauCu.Size = new Size(343, 39);
            txtMatKhauCu.TabIndex = 2;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(288, 112);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(343, 39);
            txtMatKhauMoi.TabIndex = 3;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.ActiveCaption;
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(230, 299);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(172, 56);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = SystemColors.GradientInactiveCaption;
            btnHuy.ForeColor = SystemColors.ActiveCaptionText;
            btnHuy.Location = new Point(472, 299);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(159, 56);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(288, 247);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(203, 36);
            chkHienMatKhau.TabIndex = 6;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // txtXacNhan
            // 
            txtXacNhan.Location = new Point(288, 187);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.PasswordChar = '*';
            txtXacNhan.Size = new Size(343, 39);
            txtXacNhan.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 187);
            label3.Name = "label3";
            label3.Size = new Size(224, 32);
            label3.TabIndex = 7;
            label3.Text = "Xác nhận mật khẩu:";
            // 
            // frmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 367);
            Controls.Add(txtXacNhan);
            Controls.Add(label3);
            Controls.Add(chkHienMatKhau);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đổi mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private Button btnLuu;
        private Button btnHuy;
        private CheckBox chkHienMatKhau;
        private TextBox txtXacNhan;
        private Label label3;
    }
}