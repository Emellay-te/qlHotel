using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlHotel.User_Control
{
    public partial class UserControlHoaDonReport : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr; private string reportPath;

       
        public UserControlHoaDonReport()
        {
            InitializeComponent();
            // Đường dẫn tới file báo cáo RDLC
            reportPath = Path.Combine(Application.StartupPath, "Reports", "ReportHoaDon.rdlc");
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            if (cboMaHoaDon.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn trước khi xem báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _maHoaDon = cboMaHoaDon.SelectedValue.ToString();
            LoadReport();
            string reportPath = Path.Combine(Application.StartupPath, "Reports", "rptHoaDon.rdlc");

            // Kiểm tra nếu mã hóa đơn chưa được nhập hoặc null
            if (string.IsNullOrEmpty(_maHoaDon))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn trước khi xem báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gọi hàm LoadReport() để hiển thị dữ liệu từ cơ sở dữ liệu
                LoadReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

            try
            {
                // Cấu hình ReportViewer
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = reportPath;
                ReportDataSource rds = new ReportDataSource("DataSet1", dt); // "DataSet1" phải khớp với RDLC
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Làm mới ReportViewer
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void LoadMaHoaDon()
        {
            try
            {
                string constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string query = "SELECT MaHoaDon FROM dbo.HoaDon";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboMaHoaDon.DataSource = dt;
                    cboMaHoaDon.DisplayMember = "MaHoaDon";
                    cboMaHoaDon.ValueMember = "MaHoaDon";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải mã hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        private string _maHoaDon;

        public void SetMaHoaDon(string maHoaDon)
        {
            _maHoaDon = maHoaDon;
            LoadReport(); // Gọi hàm tải dữ liệu khi mã hóa đơn được truyền
        }


        private void LoadReport()
        {
            if (string.IsNullOrEmpty(_maHoaDon))
            {
                MessageBox.Show("Mã hóa đơn chưa được cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(reportPath))
            {
                MessageBox.Show($"Không tìm thấy file báo cáo tại: {reportPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = GetDataForReport(_maHoaDon);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = reportPath;
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UserControlHoaDonReport_Load(object sender, EventArgs e)
        {
           
            LoadMaHoaDon();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Tìm Parent là panelMain
            Panel panelMain = this.Parent as Panel;

            if (panelMain != null)
            {
                // Loại bỏ UserControl hiện tại
                panelMain.Controls.Remove(this);

                // Khởi tạo UserControlHoaDon
                UserControlHoaDon ucHoaDon = new UserControlHoaDon();

                // Thêm UserControlHoaDon vào panelMain
                panelMain.Controls.Add(ucHoaDon);

                // Hiển thị toàn bộ UserControl
                ucHoaDon.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy panel chứa UserControl!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cboMaHoaDon.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHoaDon = cboMaHoaDon.SelectedItem.ToString();
            string constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";

            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string query = "UPDATE HoaDon SET LoaiThanhToan = 'Đã thanh toán' WHERE MaHoaDon = @MaHoaDon";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn để thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetDataForReport(string maHoaDon)
        {
            string connectionString = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";

            string query = @"
                SELECT 
                    hd.MaHoaDon,
                    kh.TenKhachHang,
                    p.TenPhong,
                    p.GiaPhong,
                    dp.NgayDen,
                    dp.NgayDi,
                    ISNULL(dv.TenDichVu, N'Không sử dụng') AS TenDichVu,
                    ISNULL(sddv.SoLuong, 0) AS SoLuong,
                    ISNULL(sddv.DonGia, 0) AS DonGia,
                    hd.GiamGia,
                    hd.LoaiThanhToan
                FROM dbo.HoaDon hd
                LEFT JOIN dbo.DatPhong dp ON hd.MaDatPhong = dp.MaDatPhong
                LEFT JOIN dbo.Phong p ON dp.MaPhong = p.MaPhong
                LEFT JOIN dbo.KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                LEFT JOIN dbo.SDDichVu sddv ON kh.MaKhachHang = sddv.MaKhachHang
                LEFT JOIN dbo.DichVu dv ON sddv.MaDichVu = dv.MaDichVu
                WHERE hd.MaHoaDon = @MaHoaDon";

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;

        }
    }
}
