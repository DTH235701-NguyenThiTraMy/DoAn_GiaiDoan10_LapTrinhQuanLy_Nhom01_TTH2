using QuanLyCuaHangTapHoa.Data;
using System;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmPhieuNhap : Form
    {
        QLTHDbContext db = new QLTHDbContext();
        int id;
        public frmPhieuNhap()
        {
            InitializeComponent();
        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;

            var ds = db.PhieuNhap
                .OrderByDescending(p => p.ID) // mới nhất lên đầu
                .Select(p => new
                {
                    p.ID,
                    p.MaPhieuNhap,
                    TenNhanVien = p.NhanVien.HoVaTen,
                    p.NgayNhap,
                    TongTien = p.PhieuNhap_ChiTiet.Sum(c => c.SoLuongNhap * c.DonGiaNhap)
                })
                .ToList();

            dataGridView.DataSource = ds;

            // Ẩn ID
            if (dataGridView.Columns["ID"] != null)
                dataGridView.Columns["ID"].Visible = false;

            // Format tiền
            if (dataGridView.Columns["TongTien"] != null)
            {
                dataGridView.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["TongTien"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }

            // Format ngày
            if (dataGridView.Columns["NgayNhap"] != null)
            {
                dataGridView.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmPhieuNhap_ChiTiet f = new frmPhieuNhap_ChiTiet())
            {
                f.ShowDialog();
                frmPhieuNhap_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

            using (frmPhieuNhap_ChiTiet f = new frmPhieuNhap_ChiTiet(id))
            {
                f.ShowDialog();
                frmPhieuNhap_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

                var pn = db.PhieuNhap.Find(id);
                if (pn != null)
                {
                    var chiTiet = db.PhieuNhap_ChiTiet
                        .Where(c => c.PhieuNhapID == id)
                        .ToList();

                    // ❗ Trừ lại tồn kho
                    foreach (var c in chiTiet)
                    {
                        var sp = db.SanPham.Find(c.SanPhamID);
                        if (sp != null)
                            sp.SoLuongTon -= c.SoLuongNhap;
                    }

                    db.PhieuNhap_ChiTiet.RemoveRange(chiTiet);
                    db.PhieuNhap.Remove(pn);

                    db.SaveChanges();
                }

                frmPhieuNhap_Load(sender, e);
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
            save.FileName = "PhieuNhap_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // ================= SHEET 1 =================
                        DataTable dtPN = new DataTable();

                        dtPN.Columns.Add("MaPhieuNhap");
                        dtPN.Columns.Add("NhanVien");
                        dtPN.Columns.Add("NgayNhap");
                        dtPN.Columns.Add("TongTien");

                        var dsPN = db.PhieuNhap
                            .Include(x => x.NhanVien)
                            .Include(x => x.PhieuNhap_ChiTiet)
                            .ToList();

                        foreach (var pn in dsPN)
                        {
                            int tong = pn.PhieuNhap_ChiTiet
                                .Select(x => (int?)x.SoLuongNhap * x.DonGiaNhap)
                                .Sum() ?? 0;

                            dtPN.Rows.Add(
                                pn.MaPhieuNhap,
                                pn.NhanVien.HoVaTen,
                                pn.NgayNhap.ToString("dd/MM/yyyy"),
                                tong
                            );
                        }

                        var sheet1 = wb.Worksheets.Add(dtPN, "PhieuNhap");
                        sheet1.Row(1).Style.Font.Bold = true;
                        sheet1.Columns().AdjustToContents();
                        sheet1.SheetView.FreezeRows(1);

                        // ================= SHEET 2 =================
                        DataTable dtCT = new DataTable();

                        dtCT.Columns.Add("MaPhieuNhap");
                        dtCT.Columns.Add("SanPham");
                        dtCT.Columns.Add("SoLuongNhap");
                        dtCT.Columns.Add("DonGiaNhap");
                        dtCT.Columns.Add("ThanhTien");

                        var dsCT = db.PhieuNhap_ChiTiet
                            .Include(x => x.PhieuNhap)
                            .Include(x => x.SanPham)
                            .ToList();

                        foreach (var ct in dsCT)
                        {
                            dtCT.Rows.Add(
                                ct.PhieuNhap.MaPhieuNhap,
                                ct.SanPham.TenSanPham,
                                ct.SoLuongNhap,
                                ct.DonGiaNhap,
                                ct.SoLuongNhap * ct.DonGiaNhap
                            );
                        }

                        var sheet2 = wb.Worksheets.Add(dtCT, "PhieuNhap_ChiTiet");
                        sheet2.Row(1).Style.Font.Bold = true;
                        sheet2.Columns().AdjustToContents();
                        sheet2.SheetView.FreezeRows(1);

                        // format tiền
                        sheet1.Column("D").Style.NumberFormat.Format = "#,##0";
                        sheet2.Column("E").Style.NumberFormat.Format = "#,##0";

                        wb.SaveAs(save.FileName);
                    }

                    MessageBox.Show("Xuất phiếu nhập thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
