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
    public partial class UserControlHoaDon : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public UserControlHoaDon()
        {
            InitializeComponent();
        }

        private void UserControlHoaDon_Load(object sender, EventArgs e)
        {
            constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = constr;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sql = "SELECT MaHoaDon, MaPhong, MaDatPhong, MaKhachHang, GiamGia, LoaiThanhToan FROM dbo.HoaDon";
                da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                grdData.DataSource = dt;
                grdData.Refresh();

                LoadData();
                LoadComboBox();
                NapCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    sql = "SELECT MaHoaDon, MaDatPhong, GiamGia, LoaiThanhToan FROM dbo.HoaDon";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sql = "INSERT INTO HoaDon (MaHoaDon, MaDatPhong, GiamGia, LoaiThanhToan) " +
                      "VALUES (@MaHoaDon, @MaDatPhong, @GiamGia, @LoaiThanhToan)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", txtMaHoaDon.Text);
                cmd.Parameters.AddWithValue("@MaDatPhong", cboMaDatPhong.SelectedValue);
                cmd.Parameters.AddWithValue("@GiamGia", txtGiamGia.Text);
                cmd.Parameters.AddWithValue("@LoaiThanhToan", cboLoaiThanhToan.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                sql = "UPDATE HoaDon SET MaDatPhong = @MaDatPhong, GiamGia = @GiamGia, LoaiThanhToan = @LoaiThanhToan WHERE MaHoaDon = @MaHoaDon";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", txtMaHoaDon.Text);
                cmd.Parameters.AddWithValue("@MaDatPhong", cboMaDatPhong.SelectedValue);
                cmd.Parameters.AddWithValue("@GiamGia", txtGiamGia.Text);
                cmd.Parameters.AddWithValue("@LoaiThanhToan", cboLoaiThanhToan.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                sql = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", txtMaHoaDon.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtMaHoaDon.Clear();
            cboMaDatPhong.SelectedIndex = -1;
            txtGiamGia.Clear();
            cboLoaiThanhToan.SelectedIndex = -1;
            LoadData();
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grdData.Rows[e.RowIndex];
                txtMaHoaDon.Text = row.Cells["MaHoaDon"].Value.ToString();
                cboMaDatPhong.SelectedValue = row.Cells["MaDatPhong"].Value.ToString();
                txtGiamGia.Text = row.Cells["GiamGia"].Value.ToString();
                cboLoaiThanhToan.Text = row.Cells["LoaiThanhToan"].Value.ToString();
            }
            NapCT();
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

                txtMaHoaDon.Text = grdData.Rows[i].Cells["MaHoaDon"].Value?.ToString() ?? "";
                cboMaDatPhong.SelectedValue = grdData.Rows[i].Cells["MaDatPhong"].Value;
                txtGiamGia.Text = grdData.Rows[i].Cells["GiamGia"].Value?.ToString() ?? "";
                cboLoaiThanhToan.Text = grdData.Rows[i].Cells["LoaiThanhToan"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp chi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string selectedMaHoaDon = txtMaHoaDon.Text;

            if (string.IsNullOrEmpty(selectedMaHoaDon))
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuyển tới UserControlHoaDonReport
            frmMain mainForm = (frmMain)this.FindForm();
            UserControlHoaDonReport reportControl = new UserControlHoaDonReport();

            // Truyền mã hóa đơn vào UserControlHoaDonReport
            reportControl.SetMaHoaDon(selectedMaHoaDon);

            mainForm.panelMain.Controls.Clear();
            mainForm.panelMain.Controls.Add(reportControl);
            reportControl.Dock = DockStyle.Fill;
        }

        private void LoadComboBox()
            {
                try
                {
                    // Load data for MaDatPhong
                    sql = "SELECT MaDatPhong FROM dbo.DatPhong";
                    da = new SqlDataAdapter(sql, conn);
                    DataTable dtDatPhong = new DataTable();
                    da.Fill(dtDatPhong);
                    cboMaDatPhong.DataSource = dtDatPhong;
                    cboMaDatPhong.DisplayMember = "MaDatPhong";
                    cboMaDatPhong.ValueMember = "MaDatPhong";
                    cboMaDatPhong.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu ComboBox: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
