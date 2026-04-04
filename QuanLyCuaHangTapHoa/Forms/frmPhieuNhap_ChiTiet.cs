using QuanLyCuaHangTapHoa.Data;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmPhieuNhap_ChiTiet : Form
    {
        QLTHDbContext db = new QLTHDbContext();
        int idPhieuNhap = 0;
        BindingList<ChiTietPN> chiTietList = new BindingList<ChiTietPN>();
        public frmPhieuNhap_ChiTiet(int id = 0)
        {
            InitializeComponent();
            idPhieuNhap = id;
        }
        private void frmPhieuNhap_ChiTiet_Load(object sender, EventArgs e)
        {
            // Load ComboBox
            cboNhanVien.DataSource = db.NhanVien.ToList();
            cboNhanVien.DisplayMember = "HoVaTen";
            cboNhanVien.ValueMember = "ID";

            cboSanPham.DataSource = db.SanPham.ToList();
            cboSanPham.DisplayMember = "TenSanPham";
            cboSanPham.ValueMember = "ID";

            // Tạo mã + ngày
            if (idPhieuNhap == 0)
            {
                txtMaPhieuNhap.Text = MaTuDong.SinhMaPhieuNhap();
                dtpNgayNhap.Value = DateTime.Now;
            }

            dataGridView.AutoGenerateColumns = false;

            // Nếu sửa
            if (idPhieuNhap != 0)
            {
                var pn = db.PhieuNhap.Find(idPhieuNhap);
                if (pn != null)
                {
                    txtMaPhieuNhap.Text = pn.MaPhieuNhap;
                    cboNhanVien.SelectedValue = pn.NhanVienID;
                    dtpNgayNhap.Value = pn.NgayNhap;
                    txtGhiChu.Text = pn.GhiChu;
                }

                var ct = db.PhieuNhap_ChiTiet
                    .Where(x => x.PhieuNhapID == idPhieuNhap)
                    .Select(x => new ChiTietPN
                    {
                        SanPhamID = x.SanPhamID,
                        TenSanPham = x.SanPham.TenSanPham,
                        SoLuong = x.SoLuongNhap,
                        DonGia = x.DonGiaNhap,
                        ThanhTien = x.SoLuongNhap * x.DonGiaNhap
                    }).ToList();

                chiTietList = new BindingList<ChiTietPN>(ct);
            }

            dataGridView.DataSource = chiTietList;

            CapNhatTongTien();
        }
        private void txtMaPhieuNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Chọn sản phẩm!");
                return;
            }

            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải > 0!");
                return;
            }

            int maSP = Convert.ToInt32(cboSanPham.SelectedValue);

            var existing = chiTietList.FirstOrDefault(x => x.SanPhamID == maSP);

            if (existing != null)
            {
                existing.SoLuong += (int)numSoLuong.Value;
                existing.DonGia = (int)numDonGia.Value;
                existing.ThanhTien = existing.SoLuong * existing.DonGia;
            }
            else
            {
                chiTietList.Add(new ChiTietPN
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            int maSP = Convert.ToInt32(dataGridView.CurrentRow.Cells["SanPhamID"].Value);
            var item = chiTietList.FirstOrDefault(x => x.SanPhamID == maSP);

            if (item != null)
                chiTietList.Remove(item);

            CapNhatTongTien();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Chọn nhân viên!");
                return;
            }

            if (chiTietList.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm!");
                return;
            }

            if (idPhieuNhap == 0)
            {
                // TẠO MỚI
                var pn = new PhieuNhap
                {
                    MaPhieuNhap = txtMaPhieuNhap.Text,
                    NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue),
                    NgayNhap = dtpNgayNhap.Value,
                    GhiChu = txtGhiChu.Text
                };

                db.PhieuNhap.Add(pn);
                db.SaveChanges();

                foreach (var item in chiTietList)
                {
                    db.PhieuNhap_ChiTiet.Add(new PhieuNhap_ChiTiet
                    {
                        PhieuNhapID = pn.ID,
                        SanPhamID = item.SanPhamID,
                        SoLuongNhap = item.SoLuong,
                        DonGiaNhap = item.DonGia
                    });

                    // ✅ CỘNG TỒN KHO
                    var sp = db.SanPham.Find(item.SanPhamID);
                    if (sp != null)
                        sp.SoLuongTon += item.SoLuong;
                }
            }
            else
            {
                // SỬA
                var pn = db.PhieuNhap.Find(idPhieuNhap);
                if (pn != null)
                {
                    pn.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue);
                    pn.NgayNhap = dtpNgayNhap.Value;
                    pn.GhiChu = txtGhiChu.Text;

                    var old = db.PhieuNhap_ChiTiet
                        .Where(x => x.PhieuNhapID == idPhieuNhap)
                        .ToList();

                    // trừ tồn cũ
                    foreach (var c in old)
                    {
                        var sp = db.SanPham.Find(c.SanPhamID);
                        if (sp != null)
                            sp.SoLuongTon -= c.SoLuongNhap;
                    }

                    db.PhieuNhap_ChiTiet.RemoveRange(old);

                    // thêm mới
                    foreach (var item in chiTietList)
                    {
                        db.PhieuNhap_ChiTiet.Add(new PhieuNhap_ChiTiet
                        {
                            PhieuNhapID = idPhieuNhap,
                            SanPhamID = item.SanPhamID,
                            SoLuongNhap = item.SoLuong,
                            DonGiaNhap = item.DonGia
                        });

                        var sp = db.SanPham.Find(item.SanPhamID);
                        if (sp != null)
                            sp.SoLuongTon += item.SoLuong;
                    }
                }
            }

            db.SaveChanges();

            MessageBox.Show("Lưu phiếu nhập thành công!");
            this.Close();
        }
        // ================== TỔNG TIỀN ==================
        private void CapNhatTongTien()
        {
            int tong = chiTietList.Sum(x => x.ThanhTien);
            lblTongTien.Text = "Tổng tiền: " + tong.ToString("N0") + " VNĐ";
        }
    }
}
