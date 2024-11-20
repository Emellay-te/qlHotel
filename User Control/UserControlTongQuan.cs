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
    public partial class UserControlTongQuan : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable comdt = new DataTable();
        string sql, constr;
        public UserControlTongQuan()
        {
            InitializeComponent();
        }
        private void LoadCounts()
        {
            string connectionString = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Đếm số lượng phòng
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Phong", conn))
                    {
                        labelPhongCount.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Đếm số lượng nhân viên
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NhanVien", conn))
                    {
                        labelNhanVienCount.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Đếm số lượng khách hàng
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KhachHang", conn))
                    {
                        labelKhachHangCount.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Đếm số lượng dịch vụ
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DichVu", conn))
                    {
                        labelDichVuCount.Text = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UserControlTongQuan_Load(object sender, EventArgs e)
        {
            LoadCounts();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
