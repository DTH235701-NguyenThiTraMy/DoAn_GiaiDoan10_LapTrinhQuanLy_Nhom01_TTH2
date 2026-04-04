using QuanLyCuaHangTapHoa.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmDoiMatKhau : Form
    {
        QLTHDbContext db = new QLTHDbContext();
        int userId;
        public frmDoiMatKhau(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhan = txtXacNhan.Text.Trim();

            // ===== VALIDATE =====
            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!");
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                return;
            }            

            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!");
                return;
            }

            var nv = db.NhanVien.Find(userId);

            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản!");
                return;
            }

            // ===== KIỂM TRA MẬT KHẨU CŨ =====
            if (!BCrypt.Net.BCrypt.Verify(matKhauCu, nv.MatKhau))
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
                return;
            }

            // ===== CẬP NHẬT =====
            nv.MatKhau = BCrypt.Net.BCrypt.HashPassword(matKhauMoi);
            db.SaveChanges();

            MessageBox.Show("Đổi mật khẩu thành công!");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            char c = chkHienMatKhau.Checked ? '\0' : '*';

            txtMatKhauCu.PasswordChar = c;
            txtMatKhauMoi.PasswordChar = c;
            txtXacNhan.PasswordChar = c;
        }
    }
}
