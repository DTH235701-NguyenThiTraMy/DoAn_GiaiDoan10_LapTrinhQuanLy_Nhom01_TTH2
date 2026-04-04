using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangTapHoa.Data;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap;
            this.CancelButton = btnHuyBo;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false; // hiện mật khẩu
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true; // ẩn mật khẩu
            }
        }
    }
}
