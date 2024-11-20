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
    public partial class UserControlSDDichVu : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public UserControlSDDichVu()
        {
            InitializeComponent();
        }

        private void UserControlSDDichVu_Load(object sender, EventArgs e)
        {
            constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = constr;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sql = "SELECT MaDichVu, TenDichVu, DonGia FROM dbo.DichVu";
                da = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);
                grdData.DataSource = dt;
                grdData.Refresh();

                LoadComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void SetBookingDetails(string tenKhachHang, string maKhachHang, string maDatPhong)
        {
            txtTenKhachHang.Text = tenKhachHang;
            cboMaKhachHang.SelectedValue = maKhachHang;
            txtMaDichVu.Text = maDatPhong;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sql = "INSERT INTO SuDungDichVu (MaDatPhong, MaDichVu, SoLuong) VALUES (@MaDatPhong, @MaDichVu, @SoLuong)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", txtMaDichVu.Text);
                cmd.Parameters.AddWithValue("@MaDichVu", cboTenDichVu.SelectedValue);
                cmd.Parameters.AddWithValue("@SoLuong", numSoLuong.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sql = "UPDATE SuDungDichVu SET SoLuong = @SoLuong WHERE MaDatPhong = @MaDatPhong AND MaDichVu = @MaDichVu";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", txtMaDichVu.Text);
                cmd.Parameters.AddWithValue("@MaDichVu", cboTenDichVu.SelectedValue);
                cmd.Parameters.AddWithValue("@SoLuong", numSoLuong.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sql = "DELETE FROM SuDungDichVu WHERE MaDatPhong = @MaDatPhong AND MaDichVu = @MaDichVu";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", txtMaDichVu.Text);
                cmd.Parameters.AddWithValue("@MaDichVu", cboTenDichVu.SelectedValue);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cảm ơn bạn đã sử dụng dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnToDatPhong();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnToDatPhong();
        }
        private void ReturnToDatPhong()
        {
            Panel parentPanel = this.Parent as Panel;
            if (parentPanel != null)
            {
                UserControlDatPhong ucDatPhong = new UserControlDatPhong();
                ucDatPhong.Dock = DockStyle.Fill;
                parentPanel.Controls.Clear();
                parentPanel.Controls.Add(ucDatPhong);
            }
        }

        private void cboTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenDichVu.SelectedValue != null)
            {
                DataRowView drv = cboTenDichVu.SelectedItem as DataRowView;
                if (drv != null)
                {
                    txtDonGia.Text = drv["DonGia"].ToString();
                }
            }
        }

        private void LoadComboBox()
        {
            try
            {
                sql = "SELECT MaDichVu, TenDichVu, DonGia FROM dbo.DichVu";
                da = new SqlDataAdapter(sql, conn);
                DataTable dtDichVu = new DataTable();
                da.Fill(dtDichVu);
                cboTenDichVu.DataSource = dtDichVu;
                cboTenDichVu.DisplayMember = "TenDichVu";
                cboTenDichVu.ValueMember = "MaDichVu";
                cboTenDichVu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu dịch vụ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData()
        {
            try
            {
                sql = "SELECT TenDichVu, SoLuong FROM SuDungDichVu INNER JOIN DichVu ON SuDungDichVu.MaDichVu = DichVu.MaDichVu WHERE MaDatPhong = @MaDatPhong";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", txtMaDichVu.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                grdData.DataSource = dt;
                grdData.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu dịch vụ đã sử dụng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Làm mới dữ liệu
                LoadData();

                // Xóa trắng các TextBox và ComboBox
                txtMaDichVu.Text = "";
                cboTenDichVu.SelectedIndex = -1;
                txtDonGia.Text = "";
                numSoLuong.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grdData.Rows[e.RowIndex];
                cboTenDichVu.SelectedValue = row.Cells["TenDichVu"].Value;
                numSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
            }
            NapCT();
        }

        private void NapCT()
        {
            if (grdData == null || grdData.CurrentRow == null || grdData.CurrentRow.Index < 0)
            {
                MessageBox.Show("Không có dữ liệu để nạp chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int i = grdData.CurrentRow.Index;

                cboTenDichVu.SelectedValue = grdData.Rows[i].Cells["TenDichVu"].Value;
                numSoLuong.Value = Convert.ToDecimal(grdData.Rows[i].Cells["SoLuong"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp chi tiết từ danh sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
