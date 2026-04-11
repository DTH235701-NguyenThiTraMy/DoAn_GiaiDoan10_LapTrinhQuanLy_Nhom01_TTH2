using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using QuanLyCuaHangTapHoa.Data;
using QuanLyCuaHangTapHoa.Reports;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmMain : Form
    {
        QLTHDbContext db = new QLTHDbContext();

        frmDangNhap dangNhap = null;
        int currentUserId = 0;
        string hoVaTenNhanVien = "";

        public frmMain()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private void frmMain_Load(object sender, EventArgs e)
        {
            MoForm(new frmTrangChu());
            ChuaDangNhap();
            DangNhap();
        }

        // ================= MỞ FORM =================
        void MoForm(Form f)
        {
            foreach (Form child in this.MdiChildren)
                child.Close();

            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;

            f.Show();
        }

        // ================= MENU =================
        private void mnuSanPham_Click(object sender, EventArgs e)
            => MoForm(new frmSanPham());

        private void mnuKhachHang_Click(object sender, EventArgs e)
            => MoForm(new frmKhachHang());

        private void mnuNhanVien_Click(object sender, EventArgs e)
            => MoForm(new frmNhanVien());

        private void mnuHoaDon_Click(object sender, EventArgs e)
            => MoForm(new frmHoaDon());

        private void mnuNhapHang_Click(object sender, EventArgs e)
            => MoForm(new frmPhieuNhap());

        private void mnuThongKeSanPham_Click(object sender, EventArgs e)
            => MoForm(new frmThongKeSanPham());

        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
            => MoForm(new frmThongKeDoanhThu());

        // ================= ĐĂNG NHẬP =================
        private void DangNhap()
        {
            while (true)
            {
                if (dangNhap == null || dangNhap.IsDisposed)
                    dangNhap = new frmDangNhap();

                if (dangNhap.ShowDialog() != DialogResult.OK)
                    break;

                string user = dangNhap.txtTenDangNhap.Text.Trim();
                string pass = dangNhap.txtMatKhau.Text.Trim();

                if (user == "")
                {
                    MessageBox.Show("Vui lòng nhập tài khoản!");
                    continue;
                }

                if (pass == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                    continue;
                }

                var nv = db.NhanVien.AsEnumerable().FirstOrDefault(x => x.TenDangNhap == user);

                if (nv == null)
                {
                    MessageBox.Show("Sai tài khoản!");
                    continue;
                }

                if (!BCrypt.Net.BCrypt.Verify(pass, nv.MatKhau))
                {
                    MessageBox.Show("Sai mật khẩu!");
                    continue;
                }

                currentUserId = nv.ID;
                hoVaTenNhanVien = nv.HoVaTen;

                MessageBox.Show(
                    "Đăng nhập thành công!\nXin chào " + nv.HoVaTen,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                if (nv.QuyenHan)
                    QuyenQuanLy();
                else
                    QuyenNhanVien();

                break;
            }
        }

        // ================= PHÂN QUYỀN =================
        void ChuaDangNhap()
        {
            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;

            mnuSanPham.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuHoaDon.Enabled = false;
            mnuPhieuNhap.Enabled = false;
            mnuBaoCaoThongKe.Enabled = false;


            lblTrangThai.Text = "Chưa đăng nhập";
            lblLienKet.Visible = true;
        }

        void QuyenQuanLy()
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;

            mnuSanPham.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuPhieuNhap.Enabled = true;
            mnuBaoCaoThongKe.Enabled = true;

            lblTrangThai.Text = "Quản lý: " + hoVaTenNhanVien;
            lblLienKet.Visible = true;
        }

        void QuyenNhanVien()
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;

            mnuSanPham.Enabled = false;
            mnuNhanVien.Enabled = false;

            mnuKhachHang.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuPhieuNhap.Enabled = true;

            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
            lblLienKet.Visible = true;
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // 1. Hỏi xác nhận
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất tài khoản này?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // 2. Đóng tất cả các form con đang mở (sản phẩm, hóa đơn...)
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            // 3. Xóa bộ nhớ phiên đăng nhập cũ
            currentUserId = 0;
            hoVaTenNhanVien = "";

            // 4. Khóa chức năng trên Menu
            ChuaDangNhap();

            // 5. Trả giao diện về màn hình nền (Trang chủ)
            MoForm(new frmTrangChu());

            // 6. Hiển thị thông báo như bạn mong muốn
            MessageBox.Show("Đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Bạn có chắc muốn thoát chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblLienKet_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://fit.agu.edu.vn",
                UseShellExecute = true
            });
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://dth235701-nguyenthitramy.github.io/qlth-help/index.html",
                UseShellExecute = true
            });
        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://dth235701-nguyenthitramy.github.io/qlth-help/about.html",
                UseShellExecute = true
            });
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            dangNhap = new frmDangNhap();
            DangNhap();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (currentUserId == 0)
            {
                MessageBox.Show("Bạn chưa đăng nhập!");
                return;
            }

            using (frmDoiMatKhau f = new frmDoiMatKhau(currentUserId))
            {
                f.ShowDialog();
            }
        }

        private void mnuTrangChu_Click(object sender, EventArgs e)
        {
            MoForm(new frmTrangChu());
        }
        
        public string GetCurrentMatKhauHash()
        {
            using (var context = new QLTHDbContext())
            {
                var nv = context.NhanVien.Find(currentUserId);
                return nv != null ? nv.MatKhau : "";
            }
        }

        // Thêm hàm này để chặn trường hợp quản lý tự xóa chính tài khoản của mình
        public int GetCurrentUserId()
        {
            return currentUserId;
        }
    }

}
