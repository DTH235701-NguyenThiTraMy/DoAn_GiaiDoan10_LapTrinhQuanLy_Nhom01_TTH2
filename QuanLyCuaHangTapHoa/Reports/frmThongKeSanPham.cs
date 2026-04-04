using Microsoft.Reporting.WinForms;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.Linq;
using System.Windows.Forms;
using static QuanLyCuaHangTapHoa.Reports.QLTHDataSet;


namespace QuanLyCuaHangTapHoa.Reports
{
    public partial class frmThongKeSanPham : Form
    {
        QLTHDbContext db = new QLTHDbContext();
        QLTHDataSet.DanhSachSanPhamDataTable table = new QLTHDataSet.DanhSachSanPhamDataTable();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");

        string tuKhoa = "";
        int loc = 0;
        int sapXep = 0;
        public frmThongKeSanPham()
        {
            InitializeComponent();
        }
        // ================= LOAD FORM =================
        private void frmThongKeSanPham_Load(object sender, EventArgs e)
        {
            cboLoc.SelectedIndex = 0;
            cboSapXep.SelectedIndex = 0;
            LoadReport();
        }

        // ================= LOAD REPORT =================
        private void LoadReport(string tuKhoa = "", int loc = 0, int sapXep = 0)
        {
            try
            {
                var query = db.SanPham.AsQueryable();

                // ===== TÌM =====
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    query = query.Where(s => s.TenSanPham.Contains(tuKhoa));
                }

                // ===== LỌC =====
                if (loc == 1)
                {
                    query = query.Where(s => s.SoLuongTon < 10);
                }
                else if (loc == 2)
                {
                    query = query.Where(s => s.SoLuongTon > 50);
                }

                // ===== SẮP XẾP =====
                switch (sapXep)
                {
                    case 1:
                        query = query.OrderBy(s => s.DonGiaBan);
                        break;
                    case 2:
                        query = query.OrderByDescending(s => s.DonGiaBan);
                        break;
                    case 3:
                        query = query.OrderBy(s => s.SoLuongTon);
                        break;
                    case 4:
                        query = query.OrderByDescending(s => s.SoLuongTon);
                        break;
                }

                var data = query.ToList();

                // ===== THÔNG BÁO =====
                if (data.Count == 0)
                {
                    lblThongBao.Text = "Không tìm thấy sản phẩm!";
                    lblThongBao.ForeColor = Color.Red;
                }
                table.Clear();

                foreach (var s in data)
                {
                    table.AddDanhSachSanPhamRow(
                        s.ID,
                        s.MaSanPham,
                        s.TenSanPham,
                        s.DonGiaBan,
                        s.SoLuongTon
                    );
                }

                ReportDataSource rds = new ReportDataSource
                {
                    Name = "DanhSachSanPham",
                    Value = table
                };

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.LocalReport.ReportPath =
                    Path.Combine(reportsFolder, "rptThongKeSanPham.rdlc");

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;

                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load report: " + ex.Message);
            }
        }
        // ================= NÚT REFRESH =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reset biến
            tuKhoa = "";
            loc = 0;
            sapXep = 0;

            // Reset UI
            txtTuKhoa.Clear();
            cboLoc.SelectedIndex = 0;
            cboSapXep.SelectedIndex = 0;

            // Xóa thông báo
            lblThongBao.Text = "";

            // Load lại dữ liệu
            LoadReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTuKhoa.Text))
            {
                lblThongBao.Text = "Vui lòng nhập tên sản phẩm!";
                lblThongBao.ForeColor = Color.Red;
                txtTuKhoa.Focus();
                return;
            }

            tuKhoa = txtTuKhoa.Text.Trim();
            LoadReport(tuKhoa, loc, sapXep);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            loc = cboLoc.SelectedIndex;
            LoadReport(tuKhoa, loc, sapXep);
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            sapXep = cboSapXep.SelectedIndex;
            LoadReport(tuKhoa, loc, sapXep);
        }
    }
}