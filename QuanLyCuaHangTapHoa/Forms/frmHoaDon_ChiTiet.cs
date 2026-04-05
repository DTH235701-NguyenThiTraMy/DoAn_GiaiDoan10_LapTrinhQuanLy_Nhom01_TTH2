using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTapHoa.Data;
using QuanLyCuaHangTapHoa.Reports;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static QuanLyCuaHangTapHoa.Data.HoaDon_ChiTiet;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmHoaDon_ChiTiet : Form
    {
        QLTHDbContext db = new QLTHDbContext();
        int idHoaDon = 0;                                   
        BindingList<DanhSachHoaDon_ChiTiet> chiTietList = new BindingList<DanhSachHoaDon_ChiTiet>();

        public frmHoaDon_ChiTiet(int maHoaDon = 0)
        {
            InitializeComponent();
            idHoaDon = maHoaDon;
        }

        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            dataGridView.AutoGenerateColumns = false;

            if (idHoaDon != 0)
            {
                this.Text = "Cập nhật hóa đơn";
                LoadHoaDonCu();
            }
            else
            {
                this.Text = "Lập hóa đơn mới";
            }

            dataGridView.DataSource = chiTietList;
            CapNhatTrangThaiUI();
        }

        // ================= COMBOBOX =================
        private void LoadComboboxData()
        {
            using (var db = new QLTHDbContext())
            {
                cboNhanVien.DataSource = db.NhanVien.AsNoTracking().ToList();
                cboNhanVien.DisplayMember = "HoVaTen";
                cboNhanVien.ValueMember = "ID";

                cboKhachHang.DataSource = db.KhachHang.AsNoTracking().ToList();
                cboKhachHang.DisplayMember = "HoVaTen";
                cboKhachHang.ValueMember = "ID";

                cboSanPham.DataSource = db.SanPham.AsNoTracking().ToList();
                cboSanPham.DisplayMember = "TenSanPham";
                cboSanPham.ValueMember = "ID";
                cboSanPham.SelectedIndex = -1; // Mặc định không chọn
            }
        }

        private void LoadHoaDonCu()
        {
            using (var db = new QLTHDbContext())
            {
                var hd = db.HoaDon.Find(idHoaDon);
                if (hd != null)
                {
                    cboNhanVien.SelectedValue = hd.NhanVienID;
                    cboKhachHang.SelectedValue = hd.KhachHangID;
                    txtGhiChuHoaDon.Text = hd.GhiChu;

                    var ds = db.HoaDon_ChiTiet
                        .Where(c => c.HoaDonID == idHoaDon)
                        .Select(c => new DanhSachHoaDon_ChiTiet
                        {
                            ID = c.ID,
                            SanPhamID = c.SanPhamID,
                            TenSanPham = c.SanPham.TenSanPham,
                            DonGiaBan = c.DonGiaBan,
                            SoLuongBan = (short)c.SoLuongBan,
                            ThanhTien = c.SoLuongBan * c.DonGiaBan
                        }).ToList();

                    chiTietList = new BindingList<DanhSachHoaDon_ChiTiet>(ds);
                }
            }
            CapNhatTongTien();
        }

        void CapNhatTrangThaiUI()
        {
            btnLuuHoaDon.Enabled = chiTietList.Count > 0;
            btnXoa.Enabled = chiTietList.Count > 0;
        }

        void CapNhatTongTien()
        {
            decimal tong = chiTietList.Sum(x => (decimal)x.ThanhTien);
            lblTongTien.Text = string.Format("{0:N0} VNĐ", tong);
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue != null && int.TryParse(cboSanPham.SelectedValue.ToString(), out int maSP))
            {
                using (var db = new QLTHDbContext())
                {
                    var sp = db.SanPham.Find(maSP);
                    if (sp != null) numDonGiaBan.Value = sp.DonGiaBan;
                }
            }
        }

        // ======================= CRUD =======================

        // ================= NÚT XÁC NHẬN BÁN =================
        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            // 1. Ràng buộc chọn sản phẩm
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSanPham.Focus();
                return;
            }

            // 2. Ràng buộc số lượng >= 1
            if (numSoLuongBan.Value < 1)
            {
                MessageBox.Show("Số lượng bán phải lớn hơn hoặc bằng 1!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numSoLuongBan.Focus();
                return;
            }

            int maSP = (int)cboSanPham.SelectedValue;
            int soLuongMoi = (int)numSoLuongBan.Value;

            using (var db = new QLTHDbContext())
            {
                var sp = db.SanPham.Find(maSP);
                if (sp == null) return;

                // Kiểm tra tồn kho thực tế
                if (sp.SoLuongTon < soLuongMoi)
                {
                    MessageBox.Show($"Kho không đủ hàng! Tồn hiện tại: {sp.SoLuongTon}", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                var existing = chiTietList.FirstOrDefault(x => x.SanPhamID == maSP);
                if (existing != null)
                {
                    existing.SoLuongBan += (short)soLuongMoi;
                    existing.ThanhTien = existing.SoLuongBan * (int)numDonGiaBan.Value;
                }
                else
                {
                    chiTietList.Add(new DanhSachHoaDon_ChiTiet
                    {
                        SanPhamID = maSP,
                        TenSanPham = cboSanPham.Text,
                        DonGiaBan = (int)numDonGiaBan.Value,
                        SoLuongBan = (short)soLuongMoi,
                        ThanhTien = soLuongMoi * (int)numDonGiaBan.Value
                    });
                }
            }

            dataGridView.Refresh();
            CapNhatTrangThaiUI();
            CapNhatTongTien();
            numSoLuongBan.Value = 1;
        }

        // ================= NÚT XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Xóa sản phẩm này khỏi danh sách chờ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int rowIndex = dataGridView.CurrentRow.Index;
                chiTietList.RemoveAt(rowIndex);
                CapNhatTrangThaiUI();
                CapNhatTongTien();
            }
        }

        // ================= NÚT LƯU =================
        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (ThucHienLuuHoaDon()) // Gọi hàm lưu chung
            {
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Lưu xong thì đóng form
            }
        }
        
        private bool ThucHienLuuHoaDon()
        {            
            if (cboNhanVien.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Nhân viên!"); return false; }
            if (cboKhachHang.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Khách hàng!"); return false; }
            if (chiTietList.Count == 0) { MessageBox.Show("Vui lòng thêm sản phẩm!"); return false; }

            try
            {
                using (var db = new QLTHDbContext())
                {
                    HoaDon hd;
                    if (idHoaDon == 0)
                    {
                        hd = new HoaDon { MaHoaDon = MaTuDong.SinhMaHoaDon(), NgayLap = DateTime.Now };
                        db.HoaDon.Add(hd);
                    }
                    else
                    {
                        hd = db.HoaDon.Include(h => h.HoaDon_ChiTiet).FirstOrDefault(h => h.ID == idHoaDon);
                        foreach (var c in hd.HoaDon_ChiTiet)
                        {
                            var sp = db.SanPham.Find(c.SanPhamID);
                            if (sp != null) sp.SoLuongTon += c.SoLuongBan;
                        }
                        db.HoaDon_ChiTiet.RemoveRange(hd.HoaDon_ChiTiet);
                    }

                    hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue);
                    hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue);
                    hd.GhiChu = txtGhiChuHoaDon.Text;
                    hd.TongTien = chiTietList.Sum(x => x.ThanhTien);

                    foreach (var item in chiTietList)
                    {
                        db.HoaDon_ChiTiet.Add(new HoaDon_ChiTiet
                        {
                            HoaDon = hd,
                            SanPhamID = item.SanPhamID,
                            SoLuongBan = item.SoLuongBan,
                            DonGiaBan = item.DonGiaBan
                        });
                        var sp = db.SanPham.Find(item.SanPhamID);
                        if (sp != null) sp.SoLuongTon -= item.SoLuongBan;
                    }

                    db.SaveChanges();
                    
                    idHoaDon = hd.ID;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return false;
            }
        }

        // ================= NÚT THOÁT =================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (chiTietList.Count > 0)
            {
                if (MessageBox.Show("Dữ liệu chưa được lưu, bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            this.Close();
        }

        // ================= NÚT IN HÓA ĐƠN =================
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Nếu hóa đơn mới (id=0), bắt buộc lưu trước
            if (idHoaDon == 0)
            {
                var res = MessageBox.Show("Bạn cần lưu hóa đơn trước khi in. Lưu ngay?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (!ThucHienLuuHoaDon()) return; // Lưu thất bại thì dừng
                }
                else return; // Không lưu thì không in
            }

            // Thực hiện in
            frmInHoaDon fIn = new frmInHoaDon(idHoaDon);

            if (this.MdiParent != null)
            {
                fIn.MdiParent = this.MdiParent;
                fIn.WindowState = FormWindowState.Maximized;
                fIn.Show();
                this.Close(); // In xong thì đóng form chi tiết
            }
            else
            {
                fIn.ShowDialog();
            }
        }
    }
}
