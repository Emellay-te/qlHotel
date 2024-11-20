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
    public partial class frmKhachHang : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable comdt = new DataTable();
        string sql, constr;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void grdData_Load(object sender, EventArgs e)
        {
            constr = "Data Source=LAPTOP-NOQB281J\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select MaKhachHang, TenKhachHang, CMND, SoDienThoai, Tuoi, GioiTinh From dbo.KhachHang";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
