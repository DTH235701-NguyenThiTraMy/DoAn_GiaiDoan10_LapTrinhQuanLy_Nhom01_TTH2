using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmPhieuNhap : Form
    {
        private readonly QLTHDbContext _context;

        public frmPhieuNhap()
        {
            InitializeComponent();
            _context = new QLTHDbContext();
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            LoadDataToGrid();   // Load ban đầu
        }

        /// <summary>
        /// Load dữ liệu phiếu nhập + hỗ trợ tìm kiếm
        /// </summary>
        private void LoadDataToGrid(string keyword = "")
        {
            try
            {
                // 1. Tạo query cơ bản (Server-side)
                var query = _context.PhieuNhap.AsNoTracking();

                // 2. Lọc theo từ khóa (Nếu có)
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    string k = keyword.ToLower().Trim();

                    // Lưu ý: Kiểm tra null trước khi ToLower để tránh crash
                    query = query.Where(p =>
                        (p.MaPhieuNhap != null && p.MaPhieuNhap.ToLower().Contains(k)) ||
                        (p.NhanVien != null && p.NhanVien.HoVaTen != null && p.NhanVien.HoVaTen.ToLower().Contains(k))
                    );
                }

                // 3. Thực hiện Select và Sum (EF Core sẽ dịch cái này sang SQL SUM cực nhanh)
                var data = query
                    .OrderByDescending(p => p.ID)
                    .Select(p => new
                    {
                        p.ID,
                        p.MaPhieuNhap,
                        // Dùng toán tử điều kiện để tránh null Nhân viên
                        TenNhanVien = p.NhanVien != null ? p.NhanVien.HoVaTen : "N/A",
                        p.NgayNhap,
                        // Tính tổng tiền ngay trên Server
                        TongTien = p.PhieuNhap_ChiTiet.Sum(c => (double?)c.SoLuongNhap * c.DonGiaNhap) ?? 0
                    })
                    .ToList(); // Đổ dữ liệu về RAM ở đây

                // 4. Lọc bổ sung theo Ngày (Client-side) - Chỉ chạy nếu bước trên chưa tìm thấy gì bằng chữ
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu tìm theo mã/tên không ra, ta thử lọc kết quả 'data' theo ngày
                    var filteredByDate = data.Where(p =>
                        p.NgayNhap.ToString("dd/MM/yyyy").Contains(keyword) ||
                        p.NgayNhap.ToString("yyyy-MM-dd").Contains(keyword)
                    ).ToList();

                    // Nếu tìm theo ngày có kết quả thì ưu tiên hiển thị
                    if (filteredByDate.Any())
                    {
                        dataGridView.DataSource = filteredByDate;
                    }
                    else
                    {
                        dataGridView.DataSource = data;
                    }
                }
                else
                {
                    dataGridView.DataSource = data;
                }

                // 5. Định dạng lại Grid (Giữ nguyên code cũ của bạn)
                FormatGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tách hàm định dạng riêng cho sạch code
        private void FormatGridColumns()
        {
            if (dataGridView.Columns["ID"] != null) dataGridView.Columns["ID"].Visible = false;

            if (dataGridView.Columns["TongTien"] != null)
            {
                dataGridView.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView.Columns["TongTien"].HeaderText = "Tổng Tiền";
            }

            if (dataGridView.Columns["NgayNhap"] != null)
            {
                dataGridView.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dataGridView.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            }

            if (dataGridView.Columns["TenNhanVien"] != null)
                dataGridView.Columns["TenNhanVien"].HeaderText = "Nhân Viên";

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ====================== TÌM KIẾM ======================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGrid(txtTimKiem.Text);
        }

        // ====================== CÁC NÚT CHỨC NĂNG ======================
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var f = new frmPhieuNhap_ChiTiet())
            {
                f.ShowDialog();
                LoadDataToGrid(txtTimKiem.Text);   // Giữ từ khóa tìm kiếm sau khi thêm
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

            using (var f = new frmPhieuNhap_ChiTiet(id))
            {
                f.ShowDialog();
                LoadDataToGrid(txtTimKiem.Text);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập này?\nTất cả chi tiết và tồn kho sẽ được hoàn lại.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    var pn = _context.PhieuNhap
                        .Include(p => p.PhieuNhap_ChiTiet)
                        .FirstOrDefault(p => p.ID == id);

                    if (pn == null) return;

                    // Hoàn tồn kho
                    foreach (var ct in pn.PhieuNhap_ChiTiet)
                    {
                        var sp = _context.SanPham.Find(ct.SanPhamID);
                        if (sp != null)
                            sp.SoLuongTon -= ct.SoLuongNhap;
                    }

                    _context.PhieuNhap_ChiTiet.RemoveRange(pn.PhieuNhap_ChiTiet);
                    _context.PhieuNhap.Remove(pn);

                    _context.SaveChanges();
                    transaction.Commit();
                }

                MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToGrid(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ====================== XUẤT EXCEL ======================
        private void btnXuat_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = $"PhieuNhap_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            })
            {
                if (save.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // ==================== SHEET 1: DANH SÁCH PHIẾU ====================
                        var dtPN = new DataTable();
                        dtPN.Columns.Add("MaPhieuNhap");
                        dtPN.Columns.Add("Nhân viên");
                        dtPN.Columns.Add("Ngày nhập");
                        dtPN.Columns.Add("Tổng tiền");

                        var dsPN = _context.PhieuNhap
                            .AsNoTracking()
                            .Include(x => x.NhanVien)
                            .Include(x => x.PhieuNhap_ChiTiet)
                            .ToList();

                        foreach (var pn in dsPN)
                        {
                            var tongTien = pn.PhieuNhap_ChiTiet.Sum(c => (decimal)c.SoLuongNhap * c.DonGiaNhap);
                            dtPN.Rows.Add(
                                pn.MaPhieuNhap,
                                pn.NhanVien.HoVaTen,
                                pn.NgayNhap.ToString("dd/MM/yyyy"),
                                tongTien
                            );
                        }

                        var sheet1 = wb.Worksheets.Add(dtPN, "PhieuNhap");
                        sheet1.Row(1).Style.Font.Bold = true;
                        sheet1.Columns().AdjustToContents();
                        sheet1.SheetView.FreezeRows(1);
                        sheet1.Column("D").Style.NumberFormat.Format = "#,##0";

                        // ==================== SHEET 2: CHI TIẾT ====================
                        var dtCT = new DataTable();
                        dtCT.Columns.Add("MaPhieuNhap");
                        dtCT.Columns.Add("Sản phẩm");
                        dtCT.Columns.Add("Số lượng");
                        dtCT.Columns.Add("Đơn giá");
                        dtCT.Columns.Add("Thành tiền");

                        var dsCT = _context.PhieuNhap_ChiTiet
                            .AsNoTracking()
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
                        sheet2.Column("E").Style.NumberFormat.Format = "#,##0";

                        wb.SaveAs(save.FileName);
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDataToGrid();
        }
    }
}