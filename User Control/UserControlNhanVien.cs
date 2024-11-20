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
    public partial class UserControlNhanVien : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public UserControlNhanVien()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT(); // Nạp dữ liệu vào các TextBox khi chọn hàng
        }

        private void UserControlNhanVien_Load(object sender, EventArgs e)
        {
            // Chuỗi kết nối
            constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select MaNhanVien, TenNhanVien, ChucVu, NgaySinh, NgayVaoLam, GioiTinh From dbo.NhanVien";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
            grdData.Refresh();
            NapCT();
            LoadData(); // Nạp dữ liệu vào DataGridView
            LoadComboBox(); // Nạp dữ liệu vào ComboBox
        }
        private void LoadData()
        {
            try
            {
                sql = "SELECT MaNhanVien, TenNhanVien, ChucVu, NgaySinh, NgayVaoLam, GioiTinh FROM NhanVien";
                da = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);
                grdData.DataSource = dt; // Gán dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBox()
        {
            try
            {
                sql = "SELECT MaNhanVien, TenNhanVien FROM NhanVien";
                da = new SqlDataAdapter(sql, conn);
                DataTable comboData = new DataTable();
                da.Fill(comboData);

                cboTimKiemNhanVien.DataSource = comboData;
                cboTimKiemNhanVien.DisplayMember = "TenNhanVien"; // Hiển thị tên nhân viên
                cboTimKiemNhanVien.ValueMember = "MaNhanVien";   // Giá trị là mã nhân viên
                cboTimKiemNhanVien.SelectedIndex = -1; // Không chọn mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, ChucVu, NgaySinh, GioiTinh, NgayVaoLam) " +
                      "VALUES (@MaNhanVien, @TenNhanVien, @ChucVu, @NgaySinh, @GioiTinh, @NgayVaoLam)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNhanVien.Text);
                cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNhanVien.Text);
                cmd.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", rdoNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("@NgayVaoLam", dtpNgayVaoLam.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "UPDATE NhanVien SET TenNhanVien = @TenNhanVien, ChucVu = @ChucVu, NgaySinh = @NgaySinh, " +
                      "GioiTinh = @GioiTinh, NgayVaoLam = @NgayVaoLam WHERE MaNhanVien = @MaNhanVien";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNhanVien.Text);
                cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNhanVien.Text);
                cmd.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", rdoNam.Checked ? "Nam" : "Nữ");
                cmd.Parameters.AddWithValue("@NgayVaoLam", dtpNgayVaoLam.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNhanVien.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM NhanVien WHERE TenNhanVien LIKE @TenNhanVien";
                da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@TenNhanVien", "%" + cboTimKiemNhanVien.Text + "%");
                DataTable searchResult = new DataTable();
                da.Fill(searchResult);

                grdData.DataSource = searchResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Làm mới dữ liệu trên DataGridView
            LoadData();

            // Xóa trắng các ô nhập liệu
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtChucVu.Text = "";
            dtpNgaySinh.Value = DateTime.Now; // Đặt về ngày hiện tại
            dtpNgayVaoLam.Value = DateTime.Now; // Đặt về ngày hiện tại
            rdoNam.Checked = false;
            rdoNu.Checked = false;

            // Đặt lại trạng thái mặc định cho ComboBox
            cboTimKiemNhanVien.SelectedIndex = -1;
        }

        private void cboTimKiemNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimKiemNhanVien.SelectedValue == null)
            {
                return; // Không làm gì nếu chưa chọn
            }

            string maNhanVien = cboTimKiemNhanVien.SelectedValue.ToString();

            try
            {
                string sql = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtMaNhanVien.Text = reader["MaNhanVien"].ToString();
                    txtTenNhanVien.Text = reader["TenNhanVien"].ToString();
                    txtChucVu.Text = reader["ChucVu"].ToString();
                    dtpNgaySinh.Value = DateTime.Parse(reader["NgaySinh"].ToString());
                    dtpNgayVaoLam.Value = DateTime.Parse(reader["NgayVaoLam"].ToString());

                    // Xử lý phần giới tính
                    string gioiTinh = reader["GioiTinh"].ToString();
                    rdoNam.Checked = gioiTinh == "Nam";
                    rdoNu.Checked = gioiTinh == "Nữ";
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm thông tin nhân viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void NapCT()
        {
            if (grdData.CurrentRow == null || grdData.CurrentRow.Index < 0) return;

            int i = grdData.CurrentRow.Index;
            txtMaNhanVien.Text = grdData.Rows[i].Cells["MaNhanVien"].Value.ToString();
            txtTenNhanVien.Text = grdData.Rows[i].Cells["TenNhanVien"].Value.ToString();
            txtChucVu.Text = grdData.Rows[i].Cells["ChucVu"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(grdData.Rows[i].Cells["NgaySinh"].Value);
            dtpNgayVaoLam.Value = Convert.ToDateTime(grdData.Rows[i].Cells["NgayVaoLam"].Value);

            string gioiTinh = grdData.Rows[i].Cells["GioiTinh"].Value.ToString();
            rdoNam.Checked = gioiTinh == "Nam";
            rdoNu.Checked = gioiTinh == "Nữ";
        }
    }
}
