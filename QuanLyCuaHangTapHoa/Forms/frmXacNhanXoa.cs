using System;
using System.Windows.Forms;
using BCrypt.Net;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmXacNhanXoa : Form
    {
        private string _matKhauHash;

        public frmXacNhanXoa(string thongBao, string matKhauHash)
        {
            InitializeComponent();
            lblMessage.Text = thongBao;
            _matKhauHash = matKhauHash;
            
            this.AcceptButton = btnXacNhan;
            this.CancelButton = btnHuy;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string matKhauNhap = txtMatKhau.Text;

            if (string.IsNullOrEmpty(matKhauNhap))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (BCrypt.Net.BCrypt.Verify(matKhauNhap, _matKhauHash))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                this.DialogResult = DialogResult.None;

                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}