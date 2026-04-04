using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTapHoa.Data;
using QuanLyCuaHangTapHoa.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static QuanLyCuaHangTapHoa.Data.HoaDon;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmHoaDon : Form
    {
        QLTHDbContext db = new QLTHDbContext();
        int id;
        public frmHoaDon()
        {
            InitializeComponent();
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;

            var ds = db.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                MaHoaDon = r.MaHoaDon,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                HoVaTenKhachHang = r.KhachHang != null ? r.KhachHang.HoVaTen : "",
                NgayLap = r.NgayLap,
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(c => c.SoLuongBan * c.DonGiaBan),
                XemChiTiet = "Xem chi tiết"
            }).ToList();

            dataGridView.DataSource = ds;

            // Định dạng cột Tổng tiền
            if (dataGridView.Columns["TongTienHoaDon"] != null)
            {
                dataGridView.Columns["TongTienHoaDon"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["TongTienHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dataGridView.Columns["ID"] != null)
                dataGridView.Columns["ID"].Visible = false;
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet f = new frmHoaDon_ChiTiet())
            {
                f.ShowDialog();
            }
            frmHoaDon_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

            using (frmHoaDon_ChiTiet f = new frmHoaDon_ChiTiet(id))
            {
                f.ShowDialog();
            }

            frmHoaDon_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Xóa hóa đơn này (và toàn bộ chi tiết)?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

                var hd = db.HoaDon.Find(id);

                if (hd != null)
                {
                    var chiTiet = db.HoaDon_ChiTiet.Where(c => c.HoaDonID == id).ToList();

                    // Trả lại tồn kho
                    foreach (var item in chiTiet)
                    {
                        var sp = db.SanPham.Find(item.SanPhamID);
                        if (sp != null)
                            sp.SoLuongTon += item.SoLuongBan;
                    }

                    db.HoaDon_ChiTiet.RemoveRange(chiTiet);
                    db.HoaDon.Remove(hd);

                    db.SaveChanges();
                }

                frmHoaDon_Load(sender, e);
            }
        }
        // ================== XEM CHI TIẾT ==================
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID"].Value);

                using (frmHoaDon_ChiTiet f = new frmHoaDon_ChiTiet(id))
                {
                    f.ShowDialog();
                }

                frmHoaDon_Load(sender, e);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel (*.xlsx)|*.xlsx";
            save.FileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // ================= SHEET 1: HÓA ĐƠN =================
                        DataTable dtHoaDon = new DataTable();

                        dtHoaDon.Columns.Add("MaHoaDon");
                        dtHoaDon.Columns.Add("NhanVien");
                        dtHoaDon.Columns.Add("KhachHang");
                        dtHoaDon.Columns.Add("NgayLap");
                        dtHoaDon.Columns.Add("TongTien");

                        var dsHoaDon = db.HoaDon
                         .Include(h => h.NhanVien)
                         .Include(h => h.KhachHang)
                         .Include(h => h.HoaDon_ChiTiet)
                         .ToList();

                        foreach (var hd in dsHoaDon)
                        {
                            int tong = hd.HoaDon_ChiTiet.Sum(x => x.SoLuongBan * x.DonGiaBan);

                            dtHoaDon.Rows.Add(
                                hd.MaHoaDon,
                                hd.NhanVien.HoVaTen,
                                hd.KhachHang.HoVaTen,
                                hd.NgayLap.ToString("dd/MM/yyyy"),
                                tong
                            );
                        }

                        var sheet1 = wb.Worksheets.Add(dtHoaDon, "HoaDon");
                        sheet1.Row(1).Style.Font.Bold = true;
                        sheet1.Columns().AdjustToContents();

                        // ================= SHEET 2: CHI TIẾT =================
                        DataTable dtCT = new DataTable();

                        dtCT.Columns.Add("MaHoaDon");
                        dtCT.Columns.Add("SanPham");
                        dtCT.Columns.Add("SoLuong");
                        dtCT.Columns.Add("DonGia");
                        dtCT.Columns.Add("ThanhTien");

                        var dsCT = db.HoaDon_ChiTiet
                            .Include(c => c.HoaDon)
                            .Include(c => c.SanPham)
                            .ToList();

                        foreach (var ct in dsCT)
                        {
                            dtCT.Rows.Add(
                                ct.HoaDon.MaHoaDon,
                                ct.SanPham.TenSanPham,
                                ct.SoLuongBan,
                                ct.DonGiaBan,
                                ct.SoLuongBan * ct.DonGiaBan
                            );
                        }

                        var sheet2 = wb.Worksheets.Add(dtCT, "HoaDon_ChiTiet");
                        sheet2.Row(1).Style.Font.Bold = true;
                        sheet2.Columns().AdjustToContents();

                        // ================= LƯU FILE =================
                        wb.SaveAs(save.FileName);
                    }

                    MessageBox.Show("Xuất hóa đơn thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmInHoaDon inHoaDon = new frmInHoaDon(id))
            {
                inHoaDon.ShowDialog();
            }
            if (dataGridView.CurrentRow != null)
            {
                var value = dataGridView.CurrentRow.Cells["ID"].Value;

                if (value != null && int.TryParse(value.ToString(), out int id))
                {
                    using (frmInHoaDon inHoaDon = new frmInHoaDon(id))
                    {
                        inHoaDon.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Không lấy được ID hóa đơn!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!");
            }
        }
    }
}
