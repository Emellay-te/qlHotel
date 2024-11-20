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
    public partial class UserControlDichVu : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public UserControlDichVu()
        {
            InitializeComponent();
        }

        private void UserControlDichVu_Load(object sender, EventArgs e)
        {
            constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select MaDichVu, TenDichVu, DonGia From dbo.DichVu";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
            grdData.Refresh();
            NapCT();
            LoadData();
            LoadComboBox();
        }
        private void LoadData()
        {
              try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    string sql = "SELECT MaDichVu, TenDichVu, DonGia FROM DichVu";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    grdData.DataSource = dt;
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
                sql = "SELECT MaDichVu, TenDichVu FROM dbo.DichVu";
                da = new SqlDataAdapter(sql, conn);
                DataTable comdt = new DataTable();
                da.Fill(comdt);
                cboTimKiemDichVu.DataSource = comdt;
                cboTimKiemDichVu.DisplayMember = "TenDichVu";
                cboTimKiemDichVu.ValueMember = "MaDichVu";
                cboTimKiemDichVu.SelectedIndex = -1;
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
                // Kiểm tra mã dịch vụ đã tồn tại chưa
                if (CheckMaDichVu(txtMaDichVu.Text))
                {
                    MessageBox.Show("Mã dịch vụ đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Đảm bảo kết nối mở
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Thêm dịch vụ
                string sql = "INSERT INTO DichVu (MaDichVu, TenDichVu, DonGia) VALUES (@MaDichVu, @TenDichVu, @DonGia)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDichVu", txtMaDichVu.Text.Trim());
                cmd.Parameters.AddWithValue("@TenDichVu", txtTenDichVu.Text.Trim());
                cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(txtDonGia.Text.Trim()));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới dữ liệu
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo đóng kết nối
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                // Kiểm tra mã dịch vụ có tồn tại hay không
                if (!CheckMaDichVu(txtMaDichVu.Text))
                {
                    MessageBox.Show("Mã dịch vụ không tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Đảm bảo kết nối mở
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Cập nhật dịch vụ
                string sql = "UPDATE DichVu SET TenDichVu = @TenDichVu, DonGia = @DonGia WHERE MaDichVu = @MaDichVu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDichVu", txtMaDichVu.Text.Trim());
                cmd.Parameters.AddWithValue("@TenDichVu", txtTenDichVu.Text.Trim());
                cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(txtDonGia.Text.Trim()));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới dữ liệu
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo đóng kết nối
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra mã dịch vụ có tồn tại hay không
                if (!CheckMaDichVu(txtMaDichVu.Text))
                {
                    MessageBox.Show("Mã dịch vụ không tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Đảm bảo kết nối mở
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Xóa dịch vụ
                string sql = "DELETE FROM DichVu WHERE MaDichVu = @MaDichVu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDichVu", txtMaDichVu.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới dữ liệu
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo đóng kết nối
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Làm mới dữ liệu
                LoadData();

                // Xóa trắng các TextBox
                txtMaDichVu.Text = "";
                txtTenDichVu.Text = "";
                txtDonGia.Text = "";

                cboTimKiemDichVu.SelectedIndex = -1; // Bỏ chọn ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM DichVu WHERE TenDichVu LIKE @TenDichVu";
                da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@TenDichVu", "%" + cboTimKiemDichVu.Text + "%");
                DataTable searchDt = new DataTable();
                da.Fill(searchDt);
                grdData.DataSource = searchDt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grdData.Rows[e.RowIndex];
                txtMaDichVu.Text = row.Cells["MaDichVu"].Value.ToString();
                txtTenDichVu.Text = row.Cells["TenDichVu"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            }
            NapCT();
        }

        private void cboTimKiemDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có giá trị nào được chọn
            if (cboTimKiemDichVu.SelectedValue == null)
            {
                return;
            }

            // Lấy mã dịch vụ từ ComboBox
            string maDichVu = cboTimKiemDichVu.SelectedValue.ToString();

            // Tìm kiếm và hiển thị thông tin dịch vụ
            try
            {
                string sql = "SELECT * FROM DichVu WHERE MaDichVu = @MaDichVu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDichVu", maDichVu);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Gán dữ liệu vào các TextBox
                    txtMaDichVu.Text = reader["MaDichVu"].ToString();
                    txtTenDichVu.Text = reader["TenDichVu"].ToString();
                    txtDonGia.Text = reader["DonGia"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm thông tin dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void NapCT()
        {
            if (grdData.CurrentRow == null || grdData.CurrentRow.Index < 0)
            {
                MessageBox.Show("Không có dữ liệu để nạp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy chỉ số dòng hiện tại
            int i = grdData.CurrentRow.Index;

            // Gán dữ liệu từ DataGridView vào các TextBox
            txtMaDichVu.Text = grdData.Rows[i].Cells["MaDichVu"].Value.ToString();
            txtTenDichVu.Text = grdData.Rows[i].Cells["TenDichVu"].Value.ToString();
            txtDonGia.Text = grdData.Rows[i].Cells["DonGia"].Value.ToString();
        }
        private bool CheckMaDichVu(string maDichVu)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string sql = "SELECT COUNT(*) FROM DichVu WHERE MaDichVu = @MaDichVu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDichVu", maDichVu);

                int exists = (int)cmd.ExecuteScalar();
                return exists > 0; // Trả về true nếu mã dịch vụ tồn tại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }

}
