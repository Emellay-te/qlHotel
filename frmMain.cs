using qlHotel.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlHotel
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.SuspendLayout();
            this.userControlKhachHang1 = new UserControlKhachHang();
            this.userControlKhachHang1.Visible = false;      // Ẩn ban đầu
            this.panelMain.Controls.Add(this.userControlKhachHang1); // Thêm vào panelMain

            this.userControlNhanVien1 = new UserControlNhanVien();
            this.userControlNhanVien1.Visible = false;      // Ẩn ban đầu
            this.panelMain.Controls.Add(this.userControlNhanVien1); // Thêm vào panelMain

            this.userControlDichVu1 = new UserControlDichVu();
            this.userControlDichVu1.Visible = false;      // Ẩn ban đầu
            this.panelMain.Controls.Add(this.userControlDichVu1); // Thêm vào panelMain

            this.userControlPhong1 = new UserControlPhong();
            this.userControlPhong1.Visible = false;      // Ẩn ban đầu
            this.panelMain.Controls.Add(this.userControlPhong1); // Thêm vào panelMain

            this.userControlDatPhong1 = new UserControlDatPhong();
            this.userControlDatPhong1.Visible = false;      // Ẩn ban đầu
            this.panelMain.Controls.Add(this.userControlDatPhong1); // Thêm vào panelMain

            this.userControlSDDichVu1 = new UserControlSDDichVu();
            this.userControlSDDichVu1.Visible = false; // Ẩn ban đầu
            this.panelMain.Controls.Add(this.userControlSDDichVu1); // Thêm vào panelMain

            this.userControlHoaDon1 = new UserControlHoaDon();
            this.userControlHoaDon1.Visible = false; // Ẩn ban đầu
            this.panelMain.Controls.Add(this.userControlHoaDon1); // Thêm vào panelMain

            this.userControlTongQuan1 = new UserControlTongQuan();
            this.userControlTongQuan1.Visible = false; // Ẩn ban đầu
            this.panelMain.Controls.Add(this.userControlTongQuan1); // Thêm vào panelMain


        }
        public string TenNhanVien { get; set; }
        private void MovePanel(Control btn)
        {
            panelSlide.Top = btn.Top;
            panelSlide.Height = btn.Height;
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void linkLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn muốn đăng xuất?",
        "Đăng xuất",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Tạm dừng timer nếu đang chạy
                timer1?.Stop();

                // Mở lại frmLogin
                frmLogin loginForm = new frmLogin();
                loginForm.Show();

                // Đóng frmMain
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
            if (!string.IsNullOrEmpty(TenNhanVien))
            {
                labelUserName.Text = $"{TenNhanVien}";
            }

        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            MovePanel(btnTongQuan);
            userControlKhachHang1.Hide();
            userControlNhanVien1.Hide();
            userControlDichVu1.Hide();
            userControlPhong1.Hide();
            userControlDatPhong1.Hide();
            userControlHoaDon1.Hide();
            // Kiểm tra nếu UserControl chưa được thêm vào panelMain
            if (!panelMain.Controls.Contains(userControlTongQuan1))
            {
                panelMain.Controls.Add(userControlTongQuan1); // Thêm UserControl vào Panel nếu chưa có
            }

            // Hiển thị UserControl và đưa nó ra trước
            userControlTongQuan1.Visible = true;
            userControlTongQuan1.BringToFront(); // Đảm bảo hiển thị trên cùng
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            MovePanel(btnKhachHang);
            // Kiểm tra nếu UserControl chưa được thêm vào panelMain
            if (!panelMain.Controls.Contains(userControlKhachHang1))
            {
                panelMain.Controls.Add(userControlKhachHang1); // Thêm UserControl vào Panel nếu chưa có
            }

            // Hiển thị UserControl và đưa nó ra trước
            userControlKhachHang1.Visible = true;
            userControlKhachHang1.BringToFront(); // Đảm bảo hiển thị trên cùng
            userControlNhanVien1.Hide();
            userControlDichVu1.Hide();
            userControlPhong1.Hide();
            userControlDatPhong1.Hide();
            userControlHoaDon1.Hide();
            userControlTongQuan1.Hide();


        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            MovePanel(btnPhong);
            userControlKhachHang1.Hide();
            userControlNhanVien1.Hide();
            userControlDichVu1.Hide();
            // Kiểm tra nếu UserControl chưa được thêm vào panelMain
            if (!panelMain.Controls.Contains(userControlPhong1))
            {
                panelMain.Controls.Add(userControlPhong1); // Thêm UserControl vào Panel nếu chưa có
            }

            // Hiển thị UserControl và đưa nó ra trước
            userControlPhong1.Visible = true;
            userControlPhong1.BringToFront(); // Đảm bảo hiển thị trên cùng
            userControlDatPhong1.Hide();
            userControlHoaDon1.Hide();
            userControlTongQuan1.Hide();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            MovePanel(btnDichVu);
            userControlKhachHang1.Hide();
            userControlNhanVien1.Hide();

            // Kiểm tra nếu UserControl chưa được thêm vào panelMain
            if (!panelMain.Controls.Contains(userControlDichVu1))
            {
                panelMain.Controls.Add(userControlDichVu1); // Thêm UserControl vào Panel nếu chưa có
            }

            // Hiển thị UserControl và đưa nó ra trước
            userControlDichVu1.Visible = true;
            userControlDichVu1.BringToFront(); // Đảm bảo hiển thị trên cùng
            userControlPhong1.Hide();
            userControlDatPhong1.Hide();
            userControlHoaDon1.Hide();
            userControlTongQuan1.Hide();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            MovePanel(btnDatPhong);
            userControlKhachHang1.Hide();
            userControlNhanVien1.Hide();
            userControlDichVu1.Hide();
            userControlPhong1.Hide();
            // Kiểm tra nếu UserControl chưa được thêm vào panelMain
            if (!panelMain.Controls.Contains(userControlDatPhong1))
            {
                panelMain.Controls.Add(userControlDatPhong1); // Thêm UserControl vào Panel nếu chưa có
            }

            // Hiển thị UserControl và đưa nó ra trước
            userControlDatPhong1.Visible = true;
            userControlDatPhong1.BringToFront(); // Đảm bảo hiển thị trên cùng
            userControlHoaDon1.Hide();
            userControlTongQuan1.Hide();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            MovePanel(btnHoaDon);
            userControlKhachHang1.Hide();
            userControlNhanVien1.Hide();
            userControlDichVu1.Hide();
            userControlPhong1.Hide();
            userControlDatPhong1.Hide();
            // Kiểm tra nếu UserControl chưa được thêm vào panelMain
            if (!panelMain.Controls.Contains(userControlHoaDon1))
            {
                panelMain.Controls.Add(userControlHoaDon1); // Thêm UserControl vào Panel nếu chưa có
            }

            // Hiển thị UserControl và đưa nó ra trước
            userControlHoaDon1.Visible = true;
            userControlHoaDon1.BringToFront(); // Đảm bảo hiển thị trên cùng
            userControlTongQuan1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void userControlKhachHang1_Load(object sender, EventArgs e)
        {

        }

        private void userControlKhachHang1_Load_1(object sender, EventArgs e)
        {

        }

        private void userControlKhachHang1_Load_2(object sender, EventArgs e)
        {

        }

        private void labelDateTime_Click(object sender, EventArgs e)
        {

        }

        private void userControlKhachHang1_Load_3(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControlNhanVien1_Load(object sender, EventArgs e)
        {

        }

        private void userControlKhachHang1_Load_4(object sender, EventArgs e)
        {

        }

        private void userControlNhanVien1_Load_1(object sender, EventArgs e)
        {

        }

        private void userControlNhanVien1_Load_2(object sender, EventArgs e)
        {

        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu UserControl chưa được thêm vào panelMain
            if (!panelMain.Controls.Contains(userControlNhanVien1))
            {
                panelMain.Controls.Add(userControlNhanVien1); // Thêm UserControl vào Panel nếu chưa có
            }

            // Hiển thị UserControl và đưa nó ra trước
            userControlNhanVien1.Visible = true;
            userControlNhanVien1.BringToFront(); // Đảm bảo hiển thị trên cùng
            userControlDichVu1.Hide();
            userControlKhachHang1.Hide();
            userControlPhong1.Hide();
            userControlDatPhong1.Hide();
            userControlHoaDon1.Hide();
            userControlTongQuan1.Hide();
        }
        public void ShowSDDichVu(string maKhachHang, string tenKhachHang, string maDatPhong)
        {
            // Ẩn tất cả các UserControl khác
            userControlKhachHang1.Hide();
            userControlNhanVien1.Hide();
            userControlDichVu1.Hide();
            userControlPhong1.Hide();
            userControlDatPhong1.Hide();


            // Kiểm tra nếu UserControl chưa được thêm vào panelMain
            if (!panelMain.Controls.Contains(userControlSDDichVu1))
            {
                panelMain.Controls.Add(userControlSDDichVu1); // Thêm UserControl vào Panel nếu chưa có
            }

            // Thiết lập thông tin chi tiết cần thiết từ đặt phòng
            userControlSDDichVu1.SetBookingDetails(tenKhachHang, maKhachHang, maDatPhong);

            // Hiển thị UserControl và đưa nó ra trước
            userControlSDDichVu1.Visible = true;
            userControlSDDichVu1.BringToFront(); // Đảm bảo hiển thị trên cùng
        }
        private void userControlNhanVien1_Load_3(object sender, EventArgs e)
        {

        }

        private void userControlDichVu1_Load(object sender, EventArgs e)
        {
           
        }

        private void userControlPhong1_Load(object sender, EventArgs e)
        {
            
        }

        private void userControlDichVu1_Load_1(object sender, EventArgs e)
        {

        }

        private void userControlPhong1_Load_1(object sender, EventArgs e)
        {

        }

        private void panelSlide_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
