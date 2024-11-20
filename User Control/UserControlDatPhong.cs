using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlHotel.User_Control
{
    public partial class UserControlDatPhong : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public UserControlDatPhong()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UserControlDatPhong_Load(object sender, EventArgs e)
        {
            try
            {
                // Chuỗi kết nối
                constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
                conn.ConnectionString = constr;
                conn.Open();

                // Tải dữ liệu từ bảng Đặt phòng
                LoadData();
                LoadComboBox(); // Gọi các hàm nạp dữ liệu
                NapCT(); // Gọi sau khi đã tải dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void LoadData()
        {
            try
            {
                sql = "SELECT MaDatPhong, MaKhachHang, TenKhachHang, MaPhong, NgayDen, NgayDi, TinhTrang, MaNhanVien, TenNhanVien, TenPhong FROM dbo.DatPhong";
                da = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);
                grdData.DataSource = dt;
                grdData.Refresh();

                if (dt.Rows.Count > 0)
                {
                    NapCT(); // Nạp chi tiết khi tải dữ liệu thành công
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckDatPhong(string maPhong, DateTime ngayDen, DateTime ngayDi)
        {
            try
            {
                string sqlCheck = "SELECT COUNT(*) FROM DatPhong WHERE MaPhong = @MaPhong AND ((@NgayDen BETWEEN NgayDen AND NgayDi) OR (@NgayDi BETWEEN NgayDen AND NgayDi) OR (NgayDen BETWEEN @NgayDen AND @NgayDi))";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@MaPhong", maPhong);
                cmdCheck.Parameters.AddWithValue("@NgayDen", ngayDen);
                cmdCheck.Parameters.AddWithValue("@NgayDi", ngayDi);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                int count = (int)cmdCheck.ExecuteScalar();
                return count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void LoadComboBox()
            {
            try
            {
                LoadComboBoxMaKhachHang();
                LoadComboBoxMaPhong();
                LoadComboBoxMaNhanVien();
                LoadComboBoxTimKiemDatPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ComboBox: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void LoadComboBoxMaKhachHang()
            {
            try
            {
                string sql = "SELECT MaKhachHang, TenKhachHang FROM dbo.KhachHang";
                SqlDataAdapter daKH = new SqlDataAdapter(sql, conn);
                DataTable dtKH = new DataTable();
                daKH.Fill(dtKH);

                cboMaKhachHang.DataSource = dtKH;
                cboMaKhachHang.DisplayMember = "TenKhachHang";
                cboMaKhachHang.ValueMember = "MaKhachHang";
                cboMaKhachHang.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu khách hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void LoadComboBoxMaPhong()
            {
            try
            {
                string sql = "SELECT MaPhong, TenPhong FROM dbo.Phong";
                SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
                DataTable dtPhong = new DataTable();
                daPhong.Fill(dtPhong);

                cboMaPhong.DataSource = dtPhong;
                cboMaPhong.DisplayMember = "TenPhong";
                cboMaPhong.ValueMember = "MaPhong";
                cboMaPhong.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void LoadComboBoxMaNhanVien()
            {
            try
            {
                string sql = "SELECT MaNhanVien, TenNhanVien FROM dbo.NhanVien";
                SqlDataAdapter daNV = new SqlDataAdapter(sql, conn);
                DataTable dtNV = new DataTable();
                daNV.Fill(dtNV);

                cboMaNhanVien.DataSource = dtNV;
                cboMaNhanVien.DisplayMember = "TenNhanVien";
                cboMaNhanVien.ValueMember = "MaNhanVien";
                cboMaNhanVien.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxTimKiemDatPhong()
        {
            try
            {
                string sql = "SELECT MaDatPhong FROM dbo.DatPhong";
                SqlDataAdapter daTimKiem = new SqlDataAdapter(sql, conn);
                DataTable dtTimKiem = new DataTable();
                daTimKiem.Fill(dtTimKiem);

                cboTimKiemDatPhong.DataSource = dtTimKiem;
                cboTimKiemDatPhong.DisplayMember = "MaDatPhong";
                cboTimKiemDatPhong.ValueMember = "MaDatPhong";
                cboTimKiemDatPhong.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp dữ liệu ComboBox Tìm kiếm Đặt phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
        
        }

        private void cboTimKiemDatPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimKiemDatPhong.SelectedValue == null)
            {
                return; // Không làm gì nếu chưa chọn
            }

            string maDatPhong = cboTimKiemDatPhong.SelectedValue.ToString();

            try
            {
                string sql = "SELECT MaDatPhong, MaKhachHang, TenKhachHang, MaPhong, NgayDen, NgayDi, TinhTrang, MaNhanVien, TenNhanVien, TenPhong FROM DatPhong WHERE MaDatPhong = @MaDatPhong";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtMaDatPhong.Text = reader["MaDatPhong"].ToString();
                    cboMaKhachHang.SelectedValue = reader["MaKhachHang"].ToString();
                    txtTenKhachHang.Text = reader["TenKhachHang"].ToString();
                    cboMaPhong.SelectedValue = reader["MaPhong"].ToString();
                    txtTenPhong.Text = reader["TenPhong"].ToString();
                    dtpNgayDen.Value = Convert.ToDateTime(reader["NgayDen"]);
                    dtpNgayDi.Value = Convert.ToDateTime(reader["NgayDi"]);
                    cboMaNhanVien.SelectedValue = reader["MaNhanVien"].ToString();
                    txtTenNhanVien.Text = reader["TenNhanVien"].ToString();
                    txtTinhTrang.Text = reader["TinhTrang"].ToString(); // Thêm dòng này để gán giá trị cho txtTinhTrang
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm thông tin đặt phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckDatPhong(cboMaPhong.SelectedValue.ToString(), dtpNgayDen.Value, dtpNgayDi.Value))
            {
                MessageBox.Show("Phòng đã được đặt trong khoảng thời gian này, vui lòng chọn phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                sql = "INSERT INTO DatPhong (MaDatPhong, MaKhachHang, MaPhong, NgayDen, NgayDi, TinhTrang, MaNhanVien) " +
                      "VALUES (@MaDatPhong, @MaKhachHang, @MaPhong, @NgayDen, @NgayDi, @TinhTrang, @MaNhanVien)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", txtMaDatPhong.Text);
                cmd.Parameters.AddWithValue("@MaKhachHang", cboMaKhachHang.SelectedValue);
                cmd.Parameters.AddWithValue("@MaPhong", cboMaPhong.SelectedValue);
                cmd.Parameters.AddWithValue("@NgayDen", dtpNgayDen.Value);
                cmd.Parameters.AddWithValue("@NgayDi", dtpNgayDi.Value);
                cmd.Parameters.AddWithValue("@TinhTrang", "Đặt mới");
                cmd.Parameters.AddWithValue("@MaNhanVien", cboMaNhanVien.SelectedValue);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm đặt phòng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đặt phòng: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "UPDATE DatPhong SET MaKhachHang = @MaKhachHang, MaPhong = @MaPhong, NgayDen = @NgayDen, NgayDi = @NgayDi, MaNhanVien = @MaNhanVien WHERE MaDatPhong = @MaDatPhong";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", txtMaDatPhong.Text);
                cmd.Parameters.AddWithValue("@MaKhachHang", cboMaKhachHang.SelectedValue);
                cmd.Parameters.AddWithValue("@MaPhong", cboMaPhong.SelectedValue);
                cmd.Parameters.AddWithValue("@NgayDen", dtpNgayDen.Value);
                cmd.Parameters.AddWithValue("@NgayDi", dtpNgayDi.Value);
                cmd.Parameters.AddWithValue("@MaNhanVien", cboMaNhanVien.SelectedValue);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật đặt phòng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật đặt phòng: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "DELETE FROM DatPhong WHERE MaDatPhong = @MaDatPhong";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", txtMaDatPhong.Text);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa đặt phòng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đặt phòng: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtMaDatPhong.Clear();
            cboMaKhachHang.SelectedIndex = -1;
            cboMaPhong.SelectedIndex = -1;
            dtpNgayDen.Value = DateTime.Now;
            dtpNgayDi.Value = DateTime.Now;
            cboMaNhanVien.SelectedIndex = -1;
            txtTenKhachHang.Clear();
            txtTenPhong.Clear();
            txtTenNhanVien.Clear();
            LoadComboBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboTimKiemDatPhong.SelectedValue == null)
            {
                return; // Nếu giá trị null, không làm gì cả
            }

            string maDatPhong = cboTimKiemDatPhong.SelectedValue.ToString();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Truy vấn SQL để lấy thông tin đặt phòng dựa trên Mã đặt phòng được chọn
                string sql = "SELECT * FROM DatPhong WHERE MaDatPhong = @MaDatPhong";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Hiển thị thông tin vào các TextBox và ComboBox
                    txtMaDatPhong.Text = reader["MaDatPhong"].ToString();
                    cboMaKhachHang.SelectedValue = reader["MaKhachHang"];
                    txtTenKhachHang.Text = reader["TenKhachHang"].ToString();
                    cboMaPhong.SelectedValue = reader["MaPhong"];
                    txtTenPhong.Text = reader["TenPhong"].ToString();
                    dtpNgayDen.Value = Convert.ToDateTime(reader["NgayDen"]);
                    dtpNgayDi.Value = Convert.ToDateTime(reader["NgayDi"]);
                    cboMaNhanVien.SelectedValue = reader["MaNhanVien"];
                    txtTenNhanVien.Text = reader["TenNhanVien"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm thông tin đặt phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grdData.Rows[e.RowIndex].Cells["MaDatPhong"].Value != null)
            {
                DataGridViewRow row = grdData.Rows[e.RowIndex];

                txtMaDatPhong.Text = row.Cells["MaDatPhong"].Value?.ToString() ?? "";
                cboMaKhachHang.SelectedValue = row.Cells["MaKhachHang"].Value;
                txtTenKhachHang.Text = row.Cells["TenKhachHang"].Value?.ToString() ?? "";
                cboMaPhong.SelectedValue = row.Cells["MaPhong"].Value;
                txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString() ?? "";
                dtpNgayDen.Value = Convert.ToDateTime(row.Cells["NgayDen"].Value);
                dtpNgayDi.Value = Convert.ToDateTime(row.Cells["NgayDi"].Value);
                cboMaNhanVien.SelectedValue = row.Cells["MaNhanVien"].Value;
                txtTenNhanVien.Text = row.Cells["TenNhanVien"].Value?.ToString() ?? "";
                txtTinhTrang.Text = row.Cells["TinhTrang"].Value?.ToString() ?? ""; // Thêm để hiển thị tình trạng
            }
            NapCT();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng frmMain (cần có quyền truy cập đến frmMain để điều khiển UserControlSDDichVu)
            var parentForm = this.FindForm() as frmMain;
            if (parentForm != null)
            {
                parentForm.ShowSDDichVu(cboMaKhachHang.Text, txtTenKhachHang.Text, txtMaDatPhong.Text);
            }
        }

        private void NapCT()
        {
            if (grdData == null || grdData.CurrentRow == null || grdData.CurrentRow.Index < 0)
            {
                return;
            }

            try
            {
                int i = grdData.CurrentRow.Index;

                txtMaDatPhong.Text = grdData.Rows[i].Cells["MaDatPhong"].Value?.ToString() ?? "";
                cboMaKhachHang.SelectedValue = grdData.Rows[i].Cells["MaKhachHang"].Value;
                txtTenKhachHang.Text = grdData.Rows[i].Cells["TenKhachHang"].Value?.ToString() ?? "";
                cboMaPhong.SelectedValue = grdData.Rows[i].Cells["MaPhong"].Value;
                txtTenPhong.Text = grdData.Rows[i].Cells["TenPhong"].Value?.ToString() ?? "";
                dtpNgayDen.Value = Convert.ToDateTime(grdData.Rows[i].Cells["NgayDen"].Value);
                dtpNgayDi.Value = Convert.ToDateTime(grdData.Rows[i].Cells["NgayDi"].Value);
                cboMaNhanVien.SelectedValue = grdData.Rows[i].Cells["MaNhanVien"].Value;
                txtTenNhanVien.Text = grdData.Rows[i].Cells["TenNhanVien"].Value?.ToString() ?? "";
                txtTinhTrang.Text = grdData.Rows[i].Cells["TinhTrang"].Value?.ToString() ?? ""; // Thêm để hiển thị tình trạng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp chi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        }
}
