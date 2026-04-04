namespace QuanLyCuaHangTapHoa.Forms
{
    partial class ucSidebar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSidebar));
            pnlSidebar = new FlowLayoutPanel();
            btnMenu = new Button();
            imageList1 = new ImageList(components);
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            sidebarTimer = new System.Windows.Forms.Timer(components);
            btnTrangChu = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            panel3 = new Panel();
            button2 = new Button();
            panel4 = new Panel();
            button3 = new Button();
            panel5 = new Panel();
            button4 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlSidebar.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(28, 40, 51);
            pnlSidebar.Controls.Add(btnMenu);
            pnlSidebar.Location = new Point(3, 3);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 952);
            pnlSidebar.TabIndex = 1;
            // 
            // btnMenu
            // 
            btnMenu.BackgroundImageLayout = ImageLayout.Stretch;
            btnMenu.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenu.ImageIndex = 0;
            btnMenu.ImageList = imageList1;
            btnMenu.Location = new Point(3, 3);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(41, 37);
            btnMenu.TabIndex = 2;
            btnMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenu.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Kapilmatka _ sattamatka _ kalyan matka _ satta matka _ kapil matka _ matka result.jpg");
            imageList1.Images.SetKeyName(1, "Free download _ House Computer Icons Home Building, house, angle, building, triangle png.jpg");
            imageList1.Images.SetKeyName(2, "download (2).jpg");
            // 
            // sidebarTimer
            // 
            sidebarTimer.Interval = 10;
            sidebarTimer.Tick += sidebarTimer_Tick;
            // 
            // btnTrangChu
            // 
            btnTrangChu.BackColor = Color.FromArgb(28, 40, 51);
            btnTrangChu.Cursor = Cursors.Hand;
            btnTrangChu.Dock = DockStyle.Top;
            btnTrangChu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrangChu.ForeColor = Color.White;
            btnTrangChu.ImageAlign = ContentAlignment.MiddleLeft;
            btnTrangChu.ImageIndex = 1;
            btnTrangChu.ImageList = imageList1;
            btnTrangChu.Location = new Point(0, 0);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Padding = new Padding(25, 0, 0, 0);
            btnTrangChu.Size = new Size(220, 50);
            btnTrangChu.TabIndex = 2;
            btnTrangChu.Text = "Trang chủ";
            btnTrangChu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTrangChu.UseVisualStyleBackColor = false;
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnTrangChu);
            panel1.Location = new Point(0, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 50);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Location = new Point(665, 500);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 50);
            panel2.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(28, 40, 51);
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Top;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImageIndex = 2;
            button1.ImageList = imageList1;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Padding = new Padding(25, 0, 0, 0);
            button1.Size = new Size(220, 50);
            button1.TabIndex = 2;
            button1.Text = "Quản lý";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(button2);
            panel3.Location = new Point(284, 231);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 50);
            panel3.TabIndex = 5;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(28, 40, 51);
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImageIndex = 1;
            button2.ImageList = imageList1;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Padding = new Padding(25, 0, 0, 0);
            button2.Size = new Size(220, 50);
            button2.TabIndex = 2;
            button2.Text = "Báo cáo";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(button3);
            panel4.Location = new Point(357, 444);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 50);
            panel4.TabIndex = 6;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(28, 40, 51);
            button3.Cursor = Cursors.Hand;
            button3.Dock = DockStyle.Top;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.ImageIndex = 1;
            button3.ImageList = imageList1;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Padding = new Padding(25, 0, 0, 0);
            button3.Size = new Size(220, 50);
            button3.TabIndex = 2;
            button3.Text = "Tài khoản";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(button4);
            panel5.Location = new Point(665, 574);
            panel5.Name = "panel5";
            panel5.Size = new Size(220, 50);
            panel5.TabIndex = 7;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(28, 40, 51);
            button4.Cursor = Cursors.Hand;
            button4.Dock = DockStyle.Top;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.ImageIndex = 1;
            button4.ImageList = imageList1;
            button4.Location = new Point(0, 0);
            button4.Name = "button4";
            button4.Padding = new Padding(25, 0, 0, 0);
            button4.Size = new Size(220, 50);
            button4.TabIndex = 2;
            button4.Text = "Trợ giúp";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(28, 40, 40);
            flowLayoutPanel1.Location = new Point(686, 145);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(220, 329);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // ucSidebar
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(60, 0);
            Name = "ucSidebar";
            Size = new Size(1052, 958);
            pnlSidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel pnlSidebar;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button btnMenu;
        private ImageList imageList1;
        private System.Windows.Forms.Timer sidebarTimer;
        private Button btnTrangChu;
        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Panel panel3;
        private Button button2;
        private Panel panel4;
        private Button button3;
        private Panel panel5;
        private Button button4;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
