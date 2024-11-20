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
    public partial class UserControlPhong : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public UserControlPhong()
        {
            InitializeComponent();
        }

        private void UserControlPhong_Load(object sender, EventArgs e)
        {
            try
            {
                // Kết nối cơ sở dữ liệu
                constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
                conn.ConnectionString = constr;
                conn.Open();

                // Tải dữ liệu từ bảng Phòng và Nhân viên
                string sql = @"SELECT P.MaPhong, P.TenPhong, P.LoaiPhong, P.KieuPhong, P.TinhTrang, P.GiaPhong, 
                              P.MaNhanVien, NV.TenNhanVien
                       FROM dbo.Phong P
                       LEFT JOIN dbo.NhanVien NV ON P.MaNhanVien = NV.MaNhanVien";
                da = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);
                grdData.DataSource = dt;
                grdData.Refresh();

                // Gọi các hàm nạp dữ liệu
                LoadComboBox();
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
        

        private void LoadComboBox()
        {
            try
            {
                LoadComboBoxLoaiPhong();
                LoadComboBoxKieuPhong();
                LoadComboBoxTinhTrang();
                LoadComboBoxMaNhanVien();
                LoadComboBoxThongTinPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ComboBox: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                sql = @"SELECT P.MaPhong, P.TenPhong, P.LoaiPhong, P.KieuPhong, P.TinhTrang, 
                       P.GiaPhong, P.MaNhanVien, NV.TenNhanVien 
                FROM dbo.Phong P 
                LEFT JOIN dbo.NhanVien NV ON P.MaNhanVien = NV.MaNhanVien";
                da = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);
                grdData.DataSource = dt;
                grdData.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxLoaiPhong()
        {
            cboLoaiPhong.Items.Clear();
            cboLoaiPhong.Items.Add("Tiêu chuẩn");
            cboLoaiPhong.Items.Add("Trung bình");
            cboLoaiPhong.Items.Add("Cao cấp");
            cboLoaiPhong.Items.Add("Thương gia");
            cboLoaiPhong.SelectedIndex = -1;
        }
        private void LoadComboBoxKieuPhong()
        {
            cboKieuPhong.Items.Clear();
            cboKieuPhong.Items.Add("Giường đơn");
            cboKieuPhong.Items.Add("Giường đôi");
            cboKieuPhong.SelectedIndex = -1;
        }
        private void LoadComboBoxTinhTrang()
        {
            cboTinhTrang.Items.Clear();
            cboTinhTrang.Items.Add("Trống");
            cboTinhTrang.Items.Add("Đầy");
            cboTinhTrang.Items.Add("Bảo trì");
            cboTinhTrang.SelectedIndex = -1;
        }
        private void LoadComboBoxMaNhanVien()
        {
            try
            {
                string sql = "SELECT MaNhanVien FROM dbo.NhanVien";
                SqlDataAdapter daNV = new SqlDataAdapter(sql, conn);
                DataTable dtNV = new DataTable();
                daNV.Fill(dtNV);

                cboMaNhanVien.DataSource = dtNV;
                cboMaNhanVien.DisplayMember = "MaNhanVien";
                cboMaNhanVien.ValueMember = "MaNhanVien";
                cboMaNhanVien.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxThongTinPhong()
        {
            try
            {
                string sql = "SELECT MaPhong, TenPhong FROM dbo.Phong";
                SqlDataAdapter daThongTinPhong = new SqlDataAdapter(sql, conn);
                DataTable dtThongTinPhong = new DataTable();
                daThongTinPhong.Fill(dtThongTinPhong);

                cboThongTinPhong.DataSource = dtThongTinPhong;
                cboThongTinPhong.DisplayMember = "TenPhong";
                cboThongTinPhong.ValueMember = "MaPhong";
                cboThongTinPhong.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp dữ liệu ComboBox Thông Tin Phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NapCT()
        {
            // Kiểm tra nếu DataGridView không có dữ liệu
            if (grdData == null || grdData.CurrentRow == null || grdData.CurrentRow.Index < 0)
            {
                MessageBox.Show("Không có dữ liệu để nạp chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy chỉ số hàng hiện tại
                int i = grdData.CurrentRow.Index;

                // Gán giá trị từ hàng được chọn vào các TextBox và ComboBox
                txtMaPhong.Text = grdData.Rows[i].Cells["MaPhong"].Value?.ToString() ?? "";
                txtTenPhong.Text = grdData.Rows[i].Cells["TenPhong"].Value?.ToString() ?? "";
                cboLoaiPhong.Text = grdData.Rows[i].Cells["LoaiPhong"].Value?.ToString() ?? "";
                cboKieuPhong.Text = grdData.Rows[i].Cells["KieuPhong"].Value?.ToString() ?? "";
                cboTinhTrang.Text = grdData.Rows[i].Cells["TinhTrang"].Value?.ToString() ?? "";
                txtGiaPhong.Text = grdData.Rows[i].Cells["GiaPhong"].Value?.ToString() ?? "";
                cboMaNhanVien.Text = grdData.Rows[i].Cells["MaNhanVien"].Value?.ToString() ?? "";
                txtTenNhanVien.Text = grdData.Rows[i].Cells["TenNhanVien"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp chi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckMaPhong(txtMaPhong.Text))
                {
                    MessageBox.Show("Mã phòng đã tồn tại, vui lòng nhập mã khác!");
                    return;
                }

                sql = @"INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, KieuPhong, 
                                   TinhTrang, GiaPhong, MaNhanVien)
                VALUES (@MaPhong, @TenPhong, @LoaiPhong, @KieuPhong, 
                        @TinhTrang, @GiaPhong, @MaNhanVien)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                cmd.Parameters.AddWithValue("@TenPhong", txtTenPhong.Text);
                cmd.Parameters.AddWithValue("@LoaiPhong", cboLoaiPhong.Text);
                cmd.Parameters.AddWithValue("@KieuPhong", cboKieuPhong.Text);
                cmd.Parameters.AddWithValue("@TinhTrang", cboTinhTrang.Text);
                cmd.Parameters.AddWithValue("@GiaPhong", txtGiaPhong.Text);
                cmd.Parameters.AddWithValue("@MaNhanVien", cboMaNhanVien.Text);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm phòng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng: " + ex.Message);
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
                sql = @"UPDATE Phong 
                SET TenPhong = @TenPhong, LoaiPhong = @LoaiPhong, 
                    KieuPhong = @KieuPhong, TinhTrang = @TinhTrang, 
                    GiaPhong = @GiaPhong, MaNhanVien = @MaNhanVien 
                WHERE MaPhong = @MaPhong";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                cmd.Parameters.AddWithValue("@TenPhong", txtTenPhong.Text);
                cmd.Parameters.AddWithValue("@LoaiPhong", cboLoaiPhong.Text);
                cmd.Parameters.AddWithValue("@KieuPhong", cboKieuPhong.Text);
                cmd.Parameters.AddWithValue("@TinhTrang", cboTinhTrang.Text);
                cmd.Parameters.AddWithValue("@GiaPhong", txtGiaPhong.Text);
                cmd.Parameters.AddWithValue("@MaNhanVien", cboMaNhanVien.Text);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật phòng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phòng: " + ex.Message);
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
                sql = "DELETE FROM Phong WHERE MaPhong = @MaPhong";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa phòng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phòng: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            cboLoaiPhong.SelectedIndex = -1;
            cboKieuPhong.SelectedIndex = -1;
            cboTinhTrang.SelectedIndex = -1;
            txtGiaPhong.Clear();
            cboMaNhanVien.SelectedIndex = -1;
            txtTenNhanVien.Clear();
            LoadComboBox();
        }

        private void cboThongTinPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThongTinPhong.SelectedValue == null)
            {
                return; // Nếu giá trị null, không làm gì cả
            }

            string maPhong = cboThongTinPhong.SelectedValue.ToString();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Truy vấn SQL để lấy thông tin phòng dựa trên Mã phòng được chọn
                string sql = @"SELECT P.MaPhong, P.TenPhong, P.LoaiPhong, P.KieuPhong, P.TinhTrang, P.GiaPhong, 
                              P.MaNhanVien, NV.TenNhanVien
                       FROM dbo.Phong P
                       LEFT JOIN dbo.NhanVien NV ON P.MaNhanVien = NV.MaNhanVien
                       WHERE P.MaPhong = @MaPhong";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Hiển thị thông tin vào các TextBox và ComboBox
                    txtMaPhong.Text = reader["MaPhong"].ToString();
                    txtTenPhong.Text = reader["TenPhong"].ToString();
                    cboLoaiPhong.Text = reader["LoaiPhong"].ToString();
                    cboKieuPhong.Text = reader["KieuPhong"].ToString();
                    cboTinhTrang.Text = reader["TinhTrang"].ToString();
                    txtGiaPhong.Text = reader["GiaPhong"].ToString();
                    cboMaNhanVien.Text = reader["MaNhanVien"].ToString();
                    txtTenNhanVien.Text = reader["TenNhanVien"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    // Truy vấn SQL để tìm kiếm thông tin phòng theo Tên phòng
                    string sql = @"SELECT P.MaPhong, P.TenPhong, P.LoaiPhong, P.KieuPhong, P.TinhTrang, P.GiaPhong, 
                              P.MaNhanVien, NV.TenNhanVien
                       FROM dbo.Phong P
                       LEFT JOIN dbo.NhanVien NV ON P.MaNhanVien = NV.MaNhanVien
                       WHERE P.TenPhong LIKE @TenPhong";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TenPhong", "%" + cboThongTinPhong.Text + "%");

                    SqlDataAdapter daSearch = new SqlDataAdapter(cmd);
                    DataTable dtSearch = new DataTable();
                    daSearch.Fill(dtSearch);

                    // Hiển thị kết quả tìm kiếm trên DataGridView
                    grdData.DataSource = dtSearch;

                    if (dtSearch.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy phòng nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm thông tin phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                // Kiểm tra nếu hàng được chọn là hợp lệ
                if (e.RowIndex >= 0 && grdData.Rows[e.RowIndex].Cells["MaPhong"].Value != null)
                {
                    DataGridViewRow row = grdData.Rows[e.RowIndex];

                    // Nạp dữ liệu từ hàng được chọn vào các TextBox và ComboBox
                    txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString() ?? "";
                    txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString() ?? "";
                    cboLoaiPhong.Text = row.Cells["LoaiPhong"].Value?.ToString() ?? "";
                    cboKieuPhong.Text = row.Cells["KieuPhong"].Value?.ToString() ?? "";
                    cboTinhTrang.Text = row.Cells["TinhTrang"].Value?.ToString() ?? "";
                    txtGiaPhong.Text = row.Cells["GiaPhong"].Value?.ToString() ?? "";
                    cboMaNhanVien.Text = row.Cells["MaNhanVien"].Value?.ToString() ?? "";

                    // Nếu có cột Tên nhân viên
                    txtTenNhanVien.Text = row.Cells["TenNhanVien"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp chi tiết từ danh sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            NapCT();
        }

        private bool CheckMaPhong(string maPhong)
        {
            try
            {
                sql = "SELECT COUNT(*) FROM Phong WHERE MaPhong = @MaPhong";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                int exists = (int)cmd.ExecuteScalar();
                return exists > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra mã phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        }
}
