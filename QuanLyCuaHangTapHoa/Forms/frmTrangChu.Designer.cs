namespace QuanLyCuaHangTapHoa.Forms
{
    partial class frmTrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrangChu));
            pnlTrangChu = new Panel();
            pnlFooter = new Panel();
            label2 = new Label();
            pnlHeader = new Panel();
            lblDate = new Label();
            lblTime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            pnlTrangChu.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTrangChu
            // 
            pnlTrangChu.BackColor = SystemColors.Control;
            pnlTrangChu.BackgroundImage = (Image)resources.GetObject("pnlTrangChu.BackgroundImage");
            pnlTrangChu.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTrangChu.Controls.Add(pnlFooter);
            pnlTrangChu.Controls.Add(pnlHeader);
            pnlTrangChu.Dock = DockStyle.Fill;
            pnlTrangChu.Location = new Point(0, 0);
            pnlTrangChu.Name = "pnlTrangChu";
            pnlTrangChu.Padding = new Padding(20);
            pnlTrangChu.Size = new Size(1544, 910);
            pnlTrangChu.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.Transparent;
            pnlFooter.Controls.Add(label2);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(20, 809);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1504, 81);
            pnlFooter.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FloralWhite;
            label2.Location = new Point(971, 41);
            label2.Name = "label2";
            label2.Size = new Size(840, 40);
            label2.TabIndex = 0;
            label2.Text = "👤 Sinh viên: Nguyễn Thị Trà My | 📘 Lập trình quản lý | 💻 v1.0";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblTime);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1504, 289);
            pnlHeader.TabIndex = 2;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.Transparent;
            lblDate.Location = new Point(1224, 225);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(99, 50);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date";
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(1058, 53);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(369, 170);
            lblTime.TabIndex = 1;
            lblTime.Text = "Time";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // frmTrangChu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1544, 910);
            Controls.Add(pnlTrangChu);
            Name = "frmTrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmTrangChu";
            Load += frmDashboard_Load;
            pnlTrangChu.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTrangChu;
        private Panel pnlHeader;
        private Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private Label lblDate;
        private Panel pnlFooter;
        private Label label2;
    }
}