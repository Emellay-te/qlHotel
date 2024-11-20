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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace qlHotel
{
    public partial class frmLogin : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string sql, constr;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDN.Text;
            string matKhau = txtMatKhau.Text;

            string connectionString = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TenNhanVien FROM TaiKhoan WHERE TenDN = @TenDN AND MatKhau = @MatKhau";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDN", tenDN);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        string tenNhanVien = cmd.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(tenNhanVien))
                        {
                            // Đăng nhập thành công
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mở frmMain và truyền tên nhân viên
                            frmMain mainForm = new frmMain();
                            mainForm.TenNhanVien = tenNhanVien; // Truyền tên nhân viên
                            mainForm.Show();

                            this.Hide(); // Ẩn frmLogin
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Code xử lý khi form Login được load (nếu cần)
            txtTenDN.Focus(); // Đặt con trỏ vào ô nhập tên đăng nhập
        }

    }
}
