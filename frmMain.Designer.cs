using qlHotel.User_Control;

namespace qlHotel
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSlide = new System.Windows.Forms.Panel();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.linkLogOut = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.userControlKhachHang2 = new qlHotel.User_Control.UserControlKhachHang();
            this.userControlPhong2 = new qlHotel.User_Control.UserControlPhong();
            this.userControlHoaDon1 = new qlHotel.User_Control.UserControlHoaDon();
            this.userControlSDDichVu1 = new qlHotel.User_Control.UserControlSDDichVu();
            this.userControlDatPhong1 = new qlHotel.User_Control.UserControlDatPhong();
            this.userControlPhong1 = new qlHotel.User_Control.UserControlPhong();
            this.userControlTongQuan1 = new qlHotel.User_Control.UserControlTongQuan();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.panel1.Controls.Add(this.panelSlide);
            this.panel1.Controls.Add(this.btnTongQuan);
            this.panel1.Controls.Add(this.btnHoaDon);
            this.panel1.Controls.Add(this.btnDatPhong);
            this.panel1.Controls.Add(this.btnDichVu);
            this.panel1.Controls.Add(this.btnPhong);
            this.panel1.Controls.Add(this.btnKhachHang);
            this.panel1.Controls.Add(this.linkLogOut);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 863);
            this.panel1.TabIndex = 0;
            // 
            // panelSlide
            // 
            this.panelSlide.BackColor = System.Drawing.Color.White;
            this.panelSlide.Location = new System.Drawing.Point(0, 215);
            this.panelSlide.Name = "panelSlide";
            this.panelSlide.Size = new System.Drawing.Size(10, 63);
            this.panelSlide.TabIndex = 1;
            this.panelSlide.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSlide_Paint);
            // 
            // btnTongQuan
            // 
            this.btnTongQuan.FlatAppearance.BorderSize = 0;
            this.btnTongQuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTongQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongQuan.ForeColor = System.Drawing.Color.White;
            this.btnTongQuan.Image = global::qlHotel.Properties.Resources.Tổng_quan;
            this.btnTongQuan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTongQuan.Location = new System.Drawing.Point(11, 215);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Size = new System.Drawing.Size(254, 59);
            this.btnTongQuan.TabIndex = 1;
            this.btnTongQuan.Text = "       Tổng quan";
            this.btnTongQuan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTongQuan.UseVisualStyleBackColor = true;
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHoaDon.Image = global::qlHotel.Properties.Resources.invoice_image_resized_41x32;
            this.btnHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDon.Location = new System.Drawing.Point(11, 535);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(254, 59);
            this.btnHoaDon.TabIndex = 6;
            this.btnHoaDon.Text = "       Hóa đơn";
            this.btnHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.FlatAppearance.BorderSize = 0;
            this.btnDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatPhong.ForeColor = System.Drawing.Color.White;
            this.btnDatPhong.Image = global::qlHotel.Properties.Resources.booking_image_resized_41x32;
            this.btnDatPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatPhong.Location = new System.Drawing.Point(11, 475);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(254, 59);
            this.btnDatPhong.TabIndex = 5;
            this.btnDatPhong.Text = "       Đặt phòng";
            this.btnDatPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDatPhong.UseVisualStyleBackColor = true;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // btnDichVu
            // 
            this.btnDichVu.FlatAppearance.BorderSize = 0;
            this.btnDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDichVu.ForeColor = System.Drawing.Color.White;
            this.btnDichVu.Image = global::qlHotel.Properties.Resources.service_image_resized_41x32;
            this.btnDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDichVu.Location = new System.Drawing.Point(11, 410);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(254, 59);
            this.btnDichVu.TabIndex = 4;
            this.btnDichVu.Text = "       Dịch vụ";
            this.btnDichVu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDichVu.UseVisualStyleBackColor = true;
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            // 
            // btnPhong
            // 
            this.btnPhong.FlatAppearance.BorderSize = 0;
            this.btnPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhong.ForeColor = System.Drawing.Color.White;
            this.btnPhong.Image = global::qlHotel.Properties.Resources.room;
            this.btnPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhong.Location = new System.Drawing.Point(11, 345);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.Size = new System.Drawing.Size(254, 59);
            this.btnPhong.TabIndex = 3;
            this.btnPhong.Text = "       Phòng";
            this.btnPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhong.UseVisualStyleBackColor = true;
            this.btnPhong.Click += new System.EventHandler(this.btnPhong_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Image = global::qlHotel.Properties.Resources.customer_image_resized_41x32;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(11, 280);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(254, 59);
            this.btnKhachHang.TabIndex = 2;
            this.btnKhachHang.Text = "       Khách hàng";
            this.btnKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // linkLogOut
            // 
            this.linkLogOut.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLogOut.AutoSize = true;
            this.linkLogOut.BackColor = System.Drawing.Color.White;
            this.linkLogOut.DisabledLinkColor = System.Drawing.Color.White;
            this.linkLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogOut.ForeColor = System.Drawing.Color.White;
            this.linkLogOut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.linkLogOut.Location = new System.Drawing.Point(85, 805);
            this.linkLogOut.Name = "linkLogOut";
            this.linkLogOut.Size = new System.Drawing.Size(101, 25);
            this.linkLogOut.TabIndex = 0;
            this.linkLogOut.TabStop = true;
            this.linkLogOut.Text = "Đăng xuất";
            this.linkLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLogOut.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogOut_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::qlHotel.Properties.Resources.Log_out;
            this.pictureBox1.Location = new System.Drawing.Point(0, 785);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 202);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(97, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel Management";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::qlHotel.Properties.Resources.Home_Hotel;
            this.pictureBox2.Location = new System.Drawing.Point(98, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 97);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.labelUserName);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(291, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1436, 177);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnNhanVien);
            this.panel3.Controls.Add(this.labelDateTime);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1386, 89);
            this.panel3.TabIndex = 0;
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.btnNhanVien.Image = global::qlHotel.Properties.Resources.employee_image_resized_41x32;
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(912, 30);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(254, 59);
            this.btnNhanVien.TabIndex = 7;
            this.btnNhanVien.Text = "       Nhân viên";
            this.btnNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.labelDateTime.Location = new System.Drawing.Point(3, 64);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(23, 25);
            this.labelDateTime.TabIndex = 0;
            this.labelDateTime.Text = "?";
            this.labelDateTime.Click += new System.EventHandler(this.labelDateTime_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Xin chào:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(148, 95);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(25, 29);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "?";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.userControlTongQuan1);
            this.panelMain.Controls.Add(this.userControlKhachHang2);
            this.panelMain.Controls.Add(this.userControlPhong2);
            this.panelMain.Controls.Add(this.userControlHoaDon1);
            this.panelMain.Controls.Add(this.userControlSDDichVu1);
            this.panelMain.Controls.Add(this.userControlDatPhong1);
            this.panelMain.Controls.Add(this.userControlPhong1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMain.Location = new System.Drawing.Point(291, 180);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1169, 683);
            this.panelMain.TabIndex = 0;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // userControlKhachHang2
            // 
            this.userControlKhachHang2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.userControlKhachHang2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlKhachHang2.Location = new System.Drawing.Point(153, 100);
            this.userControlKhachHang2.Margin = new System.Windows.Forms.Padding(4);
            this.userControlKhachHang2.Name = "userControlKhachHang2";
            this.userControlKhachHang2.Size = new System.Drawing.Size(1000, 533);
            this.userControlKhachHang2.TabIndex = 0;
            this.userControlKhachHang2.Visible = false;
            // 
            // userControlPhong2
            // 
            this.userControlPhong2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlPhong2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.userControlPhong2.Location = new System.Drawing.Point(153, 100);
            this.userControlPhong2.Name = "userControlPhong2";
            this.userControlPhong2.Size = new System.Drawing.Size(1000, 533);
            this.userControlPhong2.TabIndex = 4;
            this.userControlPhong2.Visible = false;
            // 
            // userControlHoaDon1
            // 
            this.userControlHoaDon1.Location = new System.Drawing.Point(105, 67);
            this.userControlHoaDon1.Name = "userControlHoaDon1";
            this.userControlHoaDon1.Size = new System.Drawing.Size(1000, 533);
            this.userControlHoaDon1.TabIndex = 3;
            this.userControlHoaDon1.Visible = false;
            // 
            // userControlSDDichVu1
            // 
            this.userControlSDDichVu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.userControlSDDichVu1.Location = new System.Drawing.Point(105, 67);
            this.userControlSDDichVu1.Name = "userControlSDDichVu1";
            this.userControlSDDichVu1.Size = new System.Drawing.Size(767, 533);
            this.userControlSDDichVu1.TabIndex = 2;
            this.userControlSDDichVu1.Visible = false;
            // 
            // userControlDatPhong1
            // 
            this.userControlDatPhong1.Location = new System.Drawing.Point(105, 85);
            this.userControlDatPhong1.Name = "userControlDatPhong1";
            this.userControlDatPhong1.Size = new System.Drawing.Size(1000, 533);
            this.userControlDatPhong1.TabIndex = 1;
            this.userControlDatPhong1.Visible = false;
            // 
            // userControlPhong1
            // 
            this.userControlPhong1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.userControlPhong1.Location = new System.Drawing.Point(105, 85);
            this.userControlPhong1.Name = "userControlPhong1";
            this.userControlPhong1.Size = new System.Drawing.Size(1000, 533);
            this.userControlPhong1.TabIndex = 0;
            this.userControlPhong1.Visible = false;
            this.userControlPhong1.Load += new System.EventHandler(this.userControlPhong1_Load_1);
            // 
            // userControlTongQuan1
            // 
            this.userControlTongQuan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTongQuan1.Location = new System.Drawing.Point(0, 0);
            this.userControlTongQuan1.Name = "userControlTongQuan1";
            this.userControlTongQuan1.Size = new System.Drawing.Size(1169, 683);
            this.userControlTongQuan1.TabIndex = 0;
            this.userControlTongQuan1.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1460, 863);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLogOut;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTongQuan;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button btnPhong;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Panel panelSlide;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Panel panelMain;
        private UserControlKhachHang userControlKhachHang1;
        private System.Windows.Forms.Button btnNhanVien;
        private UserControlNhanVien userControlNhanVien1;
        private UserControlDichVu userControlDichVu1;
        private UserControlPhong userControlPhong1;
        private UserControlDatPhong userControlDatPhong1;
        private UserControlSDDichVu userControlSDDichVu1;
        private UserControlHoaDon userControlHoaDon1;
        private UserControlPhong userControlPhong2;
        private UserControlKhachHang userControlKhachHang2;
        private UserControlTongQuan userControlTongQuan1;
    }

}