using QuanLyCuaHangTapHoa.Data;
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
        int idHoaDon = 0;                                   // 0 = tạo mới, >0 = sửa
        BindingList<DanhSachHoaDon_ChiTiet> chiTietList = new BindingList<DanhSachHoaDon_ChiTiet>();
        public frmHoaDon_ChiTiet(int maHoaDon = 0)
        {
            InitializeComponent();
            idHoaDon = maHoaDon;
        }
        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            LayNhanVien();
            LayKhachHang();
            LaySanPham();

            dataGridView.AutoGenerateColumns = false;

            if (idHoaDon != 0)
            {
                var hd = db.HoaDon.Find(idHoaDon);
                if (hd != null)
                {
                    cboNhanVien.SelectedValue = hd.NhanVienID;
                    cboKhachHang.SelectedValue = hd.KhachHangID;
                    txtGhiChuHoaDon.Text = hd.GhiChu;
                }

                var ds = db.HoaDon_ChiTiet
                    .Where(c => c.HoaDonID == idHoaDon)
                    .Select(c => new DanhSachHoaDon_ChiTiet
                    {
                        ID = c.ID,
                        SanPhamID = c.SanPhamID,
                        TenSanPham = c.SanPham != null ? c.SanPham.TenSanPham : "",
                        DonGiaBan = c.DonGiaBan,
                        SoLuongBan = (short)c.SoLuongBan,
                        ThanhTien = c.SoLuongBan * c.DonGiaBan
                    }).ToList();

                chiTietList = new BindingList<DanhSachHoaDon_ChiTiet>(ds);
            }

            dataGridView.DataSource = chiTietList;

            CapNhatTrangThaiNut();
            CapNhatTongTien();
        }

        // ================= COMBOBOX =================
        void LayNhanVien()
        {
            cboNhanVien.DataSource = db.NhanVien.ToList();
            cboNhanVien.DisplayMember = "HoVaTen";
            cboNhanVien.ValueMember = "ID";
        }

        void LayKhachHang()
        {
            cboKhachHang.DataSource = db.KhachHang.ToList();
            cboKhachHang.DisplayMember = "HoVaTen";
            cboKhachHang.ValueMember = "ID";
        }

        void LaySanPham()
        {
            cboSanPham.DataSource = db.SanPham.ToList();
            cboSanPham.DisplayMember = "TenSanPham";
            cboSanPham.ValueMember = "ID";
        }

        // ================= UI =================
        void CapNhatTrangThaiNut()
        {
            btnLuuHoaDon.Enabled = chiTietList.Count > 0;
            btnXoa.Enabled = dataGridView.CurrentRow != null;
        }

        void CapNhatTongTien()
        {
            lblTongTien.Text = chiTietList.Sum(x => x.ThanhTien).ToString("N0");
        }

        // ================= CHỌN SẢN PHẨM =================
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null ||
        !   int.TryParse(cboSanPham.SelectedValue.ToString(), out int maSP))
                return;

            var sp = db.SanPham.Find(maSP);

            if (sp != null)
            {
                numDonGiaBan.Value = sp.DonGiaBan;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null ||
                !int.TryParse(cboSanPham.SelectedValue.ToString(), out int maSP))
            {
                MessageBox.Show("Chọn sản phẩm!");
                return;
            }

            if (numSoLuongBan.Value <= 0)
            {
                MessageBox.Show("Số lượng phải > 0!");
                return;
            }

            var sp = db.SanPham.Find(maSP);
            if (sp == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại!");
                return;
            }

            int soLuongMoi = (int)numSoLuongBan.Value;
            var existing = chiTietList.FirstOrDefault(x => x.SanPhamID == maSP);

            if (existing != null)
            {
                int chenhlech = soLuongMoi - existing.SoLuongBan;

                if (sp.SoLuongTon < chenhlech)
                {
                    MessageBox.Show("Không đủ tồn!");
                    return;
                }

                existing.SoLuongBan = (short)soLuongMoi;
                existing.DonGiaBan = (int)numDonGiaBan.Value;
                existing.ThanhTien = existing.SoLuongBan * existing.DonGiaBan;
            }
            else
            {
                if (sp.SoLuongTon < soLuongMoi)
                {
                    MessageBox.Show($"Chỉ còn {sp.SoLuongTon} sản phẩm!");
                    return;
                }

                chiTietList.Add(new DanhSachHoaDon_ChiTiet
                {
                    SanPhamID = maSP,
                    TenSanPham = cboSanPham.Text,
                    DonGiaBan = (int)numDonGiaBan.Value,
                    SoLuongBan = (short)soLuongMoi,
                    ThanhTien = soLuongMoi * (int)numDonGiaBan.Value
                });
            }

            dataGridView.Refresh();
            CapNhatTrangThaiNut();
            CapNhatTongTien();

            numSoLuongBan.Value = 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            int maSP = Convert.ToInt32(dataGridView.CurrentRow.Cells["SanPhamID"].Value);
            var item = chiTietList.FirstOrDefault(x => x.SanPhamID == maSP);

            if (item != null)
                chiTietList.Remove(item);

            CapNhatTrangThaiNut();
            CapNhatTongTien();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Chọn nhân viên!");
                return;
            }

            if (idHoaDon == 0)
            {
                var hd = new HoaDon
                {
                    MaHoaDon = MaTuDong.SinhMaHoaDon(),
                    NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue),
                    KhachHangID = (int)(cboKhachHang.SelectedValue != null
                        ? Convert.ToInt32(cboKhachHang.SelectedValue)
                        : (int?)null),
                    NgayLap = DateTime.Now,
                    GhiChu = txtGhiChuHoaDon.Text,
                    TongTien = chiTietList.Sum(x => x.ThanhTien)
                };

                db.HoaDon.Add(hd);
                db.SaveChanges();

                foreach (var item in chiTietList)
                {
                    db.HoaDon_ChiTiet.Add(new HoaDon_ChiTiet
                    {
                        HoaDonID = hd.ID,
                        SanPhamID = item.SanPhamID,
                        SoLuongBan = item.SoLuongBan,
                        DonGiaBan = item.DonGiaBan
                    });

                    var sp = db.SanPham.Find(item.SanPhamID);
                    if (sp != null) sp.SoLuongTon -= item.SoLuongBan;
                }
            }
            else
            {
                var hd = db.HoaDon.Find(idHoaDon);
                if (hd != null)
                {
                    hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue);
                    hd.KhachHangID = (int)(cboKhachHang.SelectedValue != null
                        ? Convert.ToInt32(cboKhachHang.SelectedValue)
                        : (int?)null);
                    hd.GhiChu = txtGhiChuHoaDon.Text;
                    hd.TongTien = chiTietList.Sum(x => x.ThanhTien);

                    var old = db.HoaDon_ChiTiet.Where(c => c.HoaDonID == idHoaDon).ToList();

                    foreach (var c in old)
                    {
                        var sp = db.SanPham.Find(c.SanPhamID);
                        if (sp != null) sp.SoLuongTon += c.SoLuongBan;
                    }

                    db.HoaDon_ChiTiet.RemoveRange(old);

                    foreach (var item in chiTietList)
                    {
                        db.HoaDon_ChiTiet.Add(new HoaDon_ChiTiet
                        {
                            HoaDonID = idHoaDon,
                            SanPhamID = item.SanPhamID,
                            SoLuongBan = item.SoLuongBan,
                            DonGiaBan = item.DonGiaBan
                        });

                        var sp = db.SanPham.Find(item.SanPhamID);
                        if (sp != null) sp.SoLuongTon -= item.SoLuongBan;
                    }
                }
            }

            db.SaveChanges();
            MessageBox.Show("Lưu thành công!");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
