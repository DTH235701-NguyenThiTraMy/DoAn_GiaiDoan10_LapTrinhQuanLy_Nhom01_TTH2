using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmPhieuNhap_ChiTiet : Form
    {
        private readonly QLTHDbContext _context;
        private readonly int _idPhieuNhap;
        private readonly BindingList<ChiTietPN> _chiTietList = new BindingList<ChiTietPN>();

        public frmPhieuNhap_ChiTiet(int id = 0)
        {
            InitializeComponent();
            _context = new QLTHDbContext();
            _idPhieuNhap = id;
        }

        private void frmPhieuNhap_ChiTiet_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            dataGridView.AutoGenerateColumns = false;
            dataGridView.DataSource = _chiTietList;

            if (_idPhieuNhap == 0)
            {
                txtMaPhieuNhap.Text = MaTuDong.SinhMaPhieuNhap();
                dtpNgayNhap.Value = DateTime.Now;
                txtMaPhieuNhap.Enabled = false;
            }
            else
            {
                LoadExistingPhieuNhap();
            }

            CapNhatTongTien();
        }

        private void LoadComboBoxes()
        {
            // Load Nhân viên
            cboNhanVien.DataSource = _context.NhanVien.AsNoTracking().ToList();
            cboNhanVien.DisplayMember = "HoVaTen";
            cboNhanVien.ValueMember = "ID";

            // Load Sản phẩm - Quan trọng: Gán null trước để UI reset
            cboSanPham.DataSource = null;
            cboSanPham.DataSource = _context.SanPham.AsNoTracking().ToList();
            cboSanPham.DisplayMember = "TenSanPham";
            cboSanPham.ValueMember = "ID";
            cboSanPham.SelectedIndex = -1;
        }

        private void LoadExistingPhieuNhap()
        {
            var pn = _context.PhieuNhap
                .Include(p => p.PhieuNhap_ChiTiet)
                .ThenInclude(ct => ct.SanPham)
                .FirstOrDefault(p => p.ID == _idPhieuNhap);

            if (pn == null) return;

            txtMaPhieuNhap.Text = pn.MaPhieuNhap;
            txtMaPhieuNhap.Enabled = false;
            cboNhanVien.SelectedValue = pn.NhanVienID;
            dtpNgayNhap.Value = pn.NgayNhap;
            txtGhiChu.Text = pn.GhiChu;

            _chiTietList.Clear();
            foreach (var ct in pn.PhieuNhap_ChiTiet)
            {
                _chiTietList.Add(new ChiTietPN
                {
                    SanPhamID = ct.SanPhamID,
                    TenSanPham = ct.SanPham?.TenSanPham ?? "",
                    SoLuong = ct.SoLuongNhap,
                    DonGia = ct.DonGiaNhap,
                    ThanhTien = ct.SoLuongNhap * ct.DonGiaNhap
                });
            }
        }

        // ====================== HELPER: HỎI XÁC NHẬN ======================
        private bool IsConfirm(string message)
        {
            return MessageBox.Show(message, "Xác nhận hành động",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // ====================== NÚT THÊM SẢN PHẨM MỚI (MỞ FORM CON) ======================
        private void btnCong_Click(object sender, EventArgs e)
        {
            if (!IsConfirm("Bạn có muốn mở form thêm sản phẩm mới không?")) return;

            var frm = new frmSanPham();

            if (this.MdiParent != null)
            {
                // TRƯỜNG HỢP CÓ FORM CHA (MDI)
                frm.MdiParent = this.MdiParent;

                // Đăng ký sự kiện: Khi form sản phẩm đóng lại thì chạy hàm bên dưới
                frm.FormClosed += (s, args) =>
                {
                    RefetchAndReload();
                };
                frm.Show();
            }
            else
            {
                // TRƯỜNG HỢP CHẠY ĐỘC LẬP
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefetchAndReload();
                }
            }
        }

        // Hàm bổ trợ để làm mới dữ liệu
        private void RefetchAndReload()
        {
            // Buộc DbContext bỏ qua cache và đọc trực tiếp từ Database
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                entry.Reload();
            }

            LoadComboBoxes();

            // Tự động chọn sản phẩm mới nhất vừa thêm
            var lastItem = _context.SanPham.OrderByDescending(x => x.ID).FirstOrDefault();
            if (lastItem != null)
            {
                cboSanPham.SelectedValue = lastItem.ID;
            }
        }

        // ====================== NÚT XÁC NHẬN THÊM VÀO LƯỚI ======================
        private void btnXacNhanNhap_Click(object sender, EventArgs e)
        {
            if (!ValidateThemSanPham()) return;
            if (!IsConfirm("Bạn có muốn thêm sản phẩm này vào danh sách nhập không?")) return;

            int maSP = (int)cboSanPham.SelectedValue;
            var existing = _chiTietList.FirstOrDefault(x => x.SanPhamID == maSP);

            if (existing != null)
            {
                existing.SoLuong += (int)numSoLuong.Value;
                existing.DonGia = (int)numDonGia.Value;
                existing.ThanhTien = existing.SoLuong * existing.DonGia;
            }
            else
            {
                _chiTietList.Add(new ChiTietPN
                {
                    SanPhamID = maSP,
                    TenSanPham = cboSanPham.Text,
                    SoLuong = (int)numSoLuong.Value,
                    DonGia = (int)numDonGia.Value,
                    ThanhTien = (int)(numSoLuong.Value * numDonGia.Value)
                });
            }

            dataGridView.Refresh();
            CapNhatTongTien();
        }

        // ====================== NÚT XÓA DÒNG ======================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (!IsConfirm("Bạn có chắc chắn muốn xóa sản phẩm này khỏi danh sách nhập tạm?")) return;

            var item = (ChiTietPN)dataGridView.CurrentRow.DataBoundItem;
            _chiTietList.Remove(item);
            CapNhatTongTien();
        }

        // ====================== NÚT LƯU PHIẾU ======================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateLuuPhieu()) return;
            if (!IsConfirm("Bạn có chắc chắn muốn lưu phiếu nhập này vào hệ thống?")) return;

            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    PhieuNhap pn;
                    if (_idPhieuNhap == 0)
                    {
                        pn = new PhieuNhap
                        {
                            MaPhieuNhap = txtMaPhieuNhap.Text.Trim(),
                            NhanVienID = (int)cboNhanVien.SelectedValue,
                            NgayNhap = dtpNgayNhap.Value.Date,
                            GhiChu = txtGhiChu.Text.Trim()
                        };
                        _context.PhieuNhap.Add(pn);
                        _context.SaveChanges();
                    }
                    else
                    {
                        pn = _context.PhieuNhap.Include(p => p.PhieuNhap_ChiTiet).FirstOrDefault(p => p.ID == _idPhieuNhap);
                        if (pn == null) return;

                        foreach (var old in pn.PhieuNhap_ChiTiet)
                        {
                            var sp = _context.SanPham.Find(old.SanPhamID);
                            if (sp != null) sp.SoLuongTon -= old.SoLuongNhap;
                        }
                        _context.PhieuNhap_ChiTiet.RemoveRange(pn.PhieuNhap_ChiTiet);

                        pn.NhanVienID = (int)cboNhanVien.SelectedValue;
                        pn.NgayNhap = dtpNgayNhap.Value.Date;
                        pn.GhiChu = txtGhiChu.Text.Trim();
                    }

                    foreach (var item in _chiTietList)
                    {
                        _context.PhieuNhap_ChiTiet.Add(new PhieuNhap_ChiTiet
                        {
                            PhieuNhapID = pn.ID,
                            SanPhamID = item.SanPhamID,
                            SoLuongNhap = item.SoLuong,
                            DonGiaNhap = item.DonGia
                        });

                        var sp = _context.SanPham.Find(item.SanPhamID);
                        if (sp != null)
                        {
                            sp.SoLuongTon += item.SoLuong;
                            sp.DonGiaBan = item.DonGia;
                        }
                    }

                    _context.SaveChanges();
                    transaction.Commit();

                    MessageBox.Show("Lưu phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================== CÁC HÀM BỔ TRỢ ======================
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue is int maSP)
            {
                var sp = _context.SanPham.Find(maSP);
                if (sp != null && sp.DonGiaBan > 0) numDonGia.Value = sp.DonGiaBan;
            }
        }

        private void CapNhatTongTien()
        {
            decimal tong = _chiTietList.Sum(x => x.ThanhTien);
            lblTongTien.Text = $"Tổng tiền: {tong:N0} VNĐ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (IsConfirm("Bạn có chắc chắn muốn thoát? Mọi thay đổi chưa lưu sẽ bị mất."))
            {
                this.Close();
            }
        }

        private bool ValidateThemSanPham()
        {
            if (cboSanPham.SelectedValue == null) { MessageBox.Show("Chọn sản phẩm!"); return false; }
            if (numSoLuong.Value <= 0) { MessageBox.Show("Số lượng > 0!"); return false; }
            return true;
        }

        private bool ValidateLuuPhieu()
        {
            if (cboNhanVien.SelectedValue == null) { MessageBox.Show("Chọn nhân viên!"); return false; }
            if (_chiTietList.Count == 0) { MessageBox.Show("Danh sách trống!"); return false; }
            return true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}