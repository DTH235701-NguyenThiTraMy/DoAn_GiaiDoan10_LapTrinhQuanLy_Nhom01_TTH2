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
            LoadDataToGrid();
        }

        /// <summary>
        /// Load dữ liệu + hỗ trợ tìm kiếm
        /// </summary>
        private void LoadDataToGrid(string keyword = "")
        {
            try
            {
                // Bước 1: Query cơ bản
                var query = _context.PhieuNhap.AsNoTracking();

                // Bước 2: Lọc từ khóa (nếu có)
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    string k = keyword.ToLower().Trim();

                    query = query.Where(p =>
                        (p.MaPhieuNhap != null && EF.Functions.Like(p.MaPhieuNhap, $"%{k}%")) ||
                        (p.NhanVien != null && p.NhanVien.HoVaTen != null && EF.Functions.Like(p.NhanVien.HoVaTen, $"%{k}%")));
                }

                // Bước 3: Include (phải đặt SAU Where)
                query = query
                    .Include(p => p.NhanVien)
                    .Include(p => p.PhieuNhap_ChiTiet);

                // Bước 4: Select dữ liệu
                var data = query
                    .OrderByDescending(p => p.ID)
                    .Select(p => new
                    {
                        p.ID,
                        p.MaPhieuNhap,
                        TenNhanVien = p.NhanVien != null ? p.NhanVien.HoVaTen : "N/A",
                        p.NgayNhap,
                        TongTien = p.PhieuNhap_ChiTiet.Sum(c => (decimal)c.SoLuongNhap * c.DonGiaNhap),
                        XemChiTiet = "Xem chi tiết"
                    })
                    .ToList();

                // Bước 5: Lọc bổ sung theo ngày (client-side)
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    var dateFiltered = data.Where(p =>
                        p.NgayNhap.ToString("dd/MM/yyyy").Contains(keyword) ||
                        p.NgayNhap.ToString("yyyy-MM-dd").Contains(keyword))
                        .ToList();

                    dataGridView.DataSource = dateFiltered.Any() ? dateFiltered : data;
                }
                else
                {
                    dataGridView.DataSource = data;
                }

                FormatGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridColumns()
        {
            if (dataGridView.Columns["ID"] != null)
                dataGridView.Columns["ID"].Visible = false;

            if (dataGridView.Columns["TongTien"] != null)
            {
                dataGridView.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView.Columns["TongTien"].HeaderText = "Tổng Tiền";
            }

            if (dataGridView.Columns["NgayNhap"] != null)
            {
                dataGridView.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDataToGrid();
        }

        // ====================== CÁC NÚT CHỨC NĂNG ======================
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var f = new frmPhieuNhap_ChiTiet())
            {
                f.ShowDialog();
                LoadDataToGrid(txtTimKiem.Text);
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
            // 1. Kiểm tra lựa chọn trên lưới
            if (dataGridView.CurrentRow == null) return;

            // 2. Xác nhận lần 1 bằng thông báo
            if (MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập này?\nLưu ý: Số lượng hàng trong kho sẽ bị trừ tương ứng.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            // 3. Xác nhận lần 2 bằng mật khẩu
            string matKhauHash = ((frmMain)this.MdiParent).GetCurrentMatKhauHash();

            using (var f = new frmXacNhanXoa("Vui lòng nhập mật khẩu để xác nhận trừ tồn kho và xóa phiếu nhập này.", matKhauHash))
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            int deleteId = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

            // 4. Thực hiện xóa trong Transaction
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    var pn = _context.PhieuNhap
                        .Include(p => p.PhieuNhap_ChiTiet)
                        .FirstOrDefault(p => p.ID == deleteId);

                    if (pn == null) return;

                    // Hoàn tồn kho: Xóa phiếu nhập thì phải TRỪ số lượng trong kho
                    foreach (var ct in pn.PhieuNhap_ChiTiet)
                    {
                        var sp = _context.SanPham.Find(ct.SanPhamID);
                        if (sp != null)
                        {
                            sp.SoLuongTon -= ct.SoLuongNhap;

                            // Kiểm tra nếu kho bị âm sau khi trừ
                            //if (sp.SoLuongTon < 0)
                            //{
                                
                            //}
                        }
                    }

                    // Xóa chi tiết và phiếu nhập
                    _context.PhieuNhap_ChiTiet.RemoveRange(pn.PhieuNhap_ChiTiet);
                    _context.PhieuNhap.Remove(pn);

                    _context.SaveChanges();
                    transaction.Commit(); 
                }

                MessageBox.Show("Xóa phiếu nhập và cập nhật tồn kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        // Sheet 1: Danh sách phiếu
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
                            dtPN.Rows.Add(pn.MaPhieuNhap, pn.NhanVien?.HoVaTen ?? "N/A",
                                pn.NgayNhap.ToString("dd/MM/yyyy"), tongTien);
                        }

                        var sheet1 = wb.Worksheets.Add(dtPN, "PhieuNhap");
                        sheet1.Row(1).Style.Font.Bold = true;
                        sheet1.Columns().AdjustToContents();
                        sheet1.Column("D").Style.NumberFormat.Format = "#,##0";

                        // Sheet 2: Chi tiết
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
                                ct.SanPham?.TenSanPham ?? "N/A",
                                ct.SoLuongNhap,
                                ct.DonGiaNhap,
                                ct.SoLuongNhap * ct.DonGiaNhap);
                        }

                        var sheet2 = wb.Worksheets.Add(dtCT, "PhieuNhap_ChiTiet");
                        sheet2.Row(1).Style.Font.Bold = true;
                        sheet2.Columns().AdjustToContents();
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

        // Xem chi tiết khi click cột "Xem chi tiết"
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID"].Value);

                using (var f = new frmPhieuNhap_ChiTiet(id))
                {
                    f.ShowDialog();
                }

                LoadDataToGrid(txtTimKiem.Text);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}