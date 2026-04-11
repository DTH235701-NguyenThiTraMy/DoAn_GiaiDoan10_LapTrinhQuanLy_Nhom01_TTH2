namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmXacNhanXoa
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
            lblMessage = new Label();
            txtMatKhau = new TextBox();
            btnXacNhan = new Button();
            btnHuy = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(639, 32);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(150, 136);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.PlaceholderText = "Nhập mật khẩu của bạn";
            txtMatKhau.Size = new Size(318, 39);
            txtMatKhau.TabIndex = 1;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(91, 228);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(150, 70);
            btnXacNhan.TabIndex = 2;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnHuy
            // 
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(384, 228);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(150, 70);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 84);
            label1.Name = "label1";
            label1.Size = new Size(224, 32);
            label1.TabIndex = 4;
            label1.Text = "Xác nhận mật khấu:";
            // 
            // frmXacNhanXoa
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(639, 347);
            Controls.Add(label1);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhan);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmXacNhanXoa";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Xác nhận xóa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private TextBox txtMatKhau;
        private Button btnXacNhan;
        private Button btnHuy;
        private Label label1;
    }
}