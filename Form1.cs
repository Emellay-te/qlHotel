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

namespace qlHotel
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable comdt = new DataTable();
        string sql, constr;

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select MaKhachHang, TenKhachHang, CMND, SoDienThoai, Tuoi, GioiTinh From dbo.KhachHang";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            NapCT();
            LoadComboBox();
            LoadData(); // Tải dữ liệu vào DataGridView
        }
        public void NapCT()
        {
            int i = dataGridView1.CurrentRow.Index;
            txtMaKhachHang.Text = dataGridView1.Rows[i].Cells["MaKhachHang"].Value.ToString();
            txtTenKhachHang.Text = dataGridView1.Rows[i].Cells["TenKhachHang"].Value.ToString();
            txtCMND.Text = dataGridView1.Rows[i].Cells["CMND"].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.Rows[i].Cells["SoDienThoai"].Value.ToString();
            txtTuoi.Text = dataGridView1.Rows[i].Cells["Tuoi"].Value.ToString();
            // Xử lý giá trị "Giới tính"
            string gioiTinh = dataGridView1.Rows[i].Cells["GioiTinh"].Value.ToString();
            if (gioiTinh == "Nam")
            {
                rdoNam.Checked = true;
            }
            else if (gioiTinh == "Nữ")
            {
                rdoNu.Checked = true;
            }
            else
            {
                rdoNam.Checked = false;
                rdoNu.Checked = false;
            }
        }
        private void cboTimKiemKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã khách hàng từ ComboBox
            string MaKhachHang = cboTimKiemKhachHang.SelectedValue.ToString();

            // Tìm kiếm và hiển thị thông tin khách hàng
            try
            {
                string sql = "SELECT * FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Gán thông tin vào các TextBox
                    txtMaKhachHang.Text = reader["MaKhachHang"].ToString();
                    txtTenKhachHang.Text = reader["TenKhachHang"].ToString();
                    txtCMND.Text = reader["CMND"].ToString();
                    txtSoDienThoai.Text = reader["SoDienThoai"].ToString();
                    txtTuoi.Text = reader["Tuoi"].ToString();

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
                MessageBox.Show("Lỗi khi tìm thông tin khách hàng: " + ex.Message);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtTenKhachHang.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtCMND.Text = row.Cells["CMND"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtTuoi.Text = row.Cells["Tuoi"].Value.ToString();
                if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;
            }
            NapCT();
        }
        private void LoadComboBox()
        {
            try
            {
                // Câu lệnh SQL để lấy danh sách khách hàng
                string sql = "SELECT MaKhachHang, TenKhachHang FROM KhachHang";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gán dữ liệu vào ComboBox
                cboTimKiemKhachHang.DataSource = dt;
                cboTimKiemKhachHang.DisplayMember = "TenKhachHang"; // Hiển thị tên khách hàng
                cboTimKiemKhachHang.ValueMember = "MaKhachHang";   // Giá trị là mã khách hàng
                cboTimKiemKhachHang.SelectedIndex = -1; // Không chọn mặc định
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
                if (CheckMaKhachHang(txtMaKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "INSERT INTO KhachHang (MaKhachHang, TenKhachHang, CMND, SoDienThoai, Tuoi, GioiTinh) " +
                             "VALUES (@MaKhachHang, @TenKhachHang, @CMND, @SoDienThoai, @Tuoi, @GioiTinh)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@TenKhachHang", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@Tuoi", txtTuoi.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", rdoNam.Checked ? "Nam" : "Nữ");

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Làm mới dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
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
                if (!CheckMaKhachHang(txtMaKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng không tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, CMND = @CMND, SoDienThoai = @SoDienThoai, Tuoi = @Tuoi, GioiTinh = @GioiTinh " +
                             "WHERE MaKhachHang = @MaKhachHang";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@TenKhachHang", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@Tuoi", txtTuoi.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", rdoNam.Checked ? "Nam" : "Nữ");

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Làm mới dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
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
                if (!CheckMaKhachHang(txtMaKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng không tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKhachHang.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Làm mới dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "SELECT MaKhachHang, TenKhachHang, CMND, SoDienThoai, Tuoi, GioiTinh FROM KhachHang";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt; // Gán dữ liệu vào DataGridView
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

        private bool CheckMaKhachHang(string maKhachHang)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "SELECT COUNT(*) FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                int exists = (int)cmd.ExecuteScalar();
                return exists > 0; // Trả về true nếu tồn tại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã khách hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtCMND.Text = "";
            txtSoDienThoai.Text = "";
            txtTuoi.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM KhachHang WHERE TenKhachHang LIKE @TenKhachHang";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@TenKhachHang", "%" + cboTimKiemKhachHang.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

