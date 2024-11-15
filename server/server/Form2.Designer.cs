namespace server
{
    partial class Form2
    {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        
        private System.ComponentModel.IContainer components = null;// Biến để chứa các thành phần của form.

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        
        protected override void Dispose(bool disposing)// Phương thức giải phóng tài nguyên khi form đóng.
        {
            if (disposing && (components != null))// Nếu form đang sử dụng các tài nguyên thì giải phóng chúng.
            {
                components.Dispose();// Giải phóng các thành phần của form.
            }
            base.Dispose(disposing);// Gọi phương thức Dispose của lớp cha.
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        // Phương thức khởi tạo các thành phần giao diện.
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();//các điều khiển PictureBox dùng để hiển thị hình ảnh trên form.
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();//điều khiển chia form thành hai panel có thể thay đổi kích thước (Panel1 và Panel2).
            this.button2 = new System.Windows.Forms.Button();//các nút bấm mà người dùng có thể nhấn để thực hiện hành động
            this.button1 = new System.Windows.Forms.Button();//các nút bấm mà người dùng có thể nhấn để thực hiện hành động
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();//điều khiển dùng để sắp xếp các điều khiển khác theo dạng lưới với các hàng và cột.
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();  // Tạm ngưng layout để thiết lập thuộc tính.
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;//Thiết lập màu xám cho PictureBox
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;//hiết lập chế độ Dock cho PictureBox
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);//vị trí của PictureBox trong container chứa nó (được tính từ góc trên bên trái)
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);//khoảng cách giữa PictureBox và các điều khiển xung quanh nó
            this.pictureBox1.Name = "pictureBox1";// Tên của nút.
            this.pictureBox1.Size = new System.Drawing.Size(386, 254);// Kích thước nút.
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;//Chế độ thay đổi kích thước của hình ảnh bên trong PictureBox
            this.pictureBox1.TabIndex = 0;// Chỉ số tab cho nút.
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);// Sự kiện khi nhấn nút.
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;//Thiết lập chế độ Dock
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);// vị trí của SplitContainer trong container
            this.splitContainer1.Name = "splitContainer1";// Tên
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;//Chỉ định hướng
            // 
            // splitContainer1.Panel1
            // 
            //được hiển thị trong phần đầu của SplitContainer.
            this.splitContainer1.Panel1.Controls.Add(this.button2);//Controls.Add: Thêm các điều khiển
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 592);//kích thước của SplitContainer
            this.splitContainer1.SplitterDistance = 63;//Xác định khoảng cách (chiều cao hoặc chiều rộng, tùy theo hướng của SplitContainer) giữa Panel1 và Panel2
            this.splitContainer1.TabIndex = 1;//thứ tự của SplitContainer khi người dùng nhấn phím Tab để di chuyển qua các điều khiển trên form
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);// vị trí của button2 trên form
            this.button2.Name = "button2";//tên của button2
            this.button2.Size = new System.Drawing.Size(125, 38);//kích thước của nút
            this.button2.TabIndex = 1;//thứ tự của nút trong chuỗi tab
            this.button2.Text = "< Quay lại";//văn bản hiển thị trên nút
            this.button2.UseVisualStyleBackColor = true;//thuộc tính của nút xác định liệu nó có sử dụng kiểu dáng hệ thống mặc định (Visual Style) cho màu nền của nút hay không
            this.button2.Click += new System.EventHandler(this.button2_Click);//sự kiện Click cho nút
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));//Thuộc tính Anchor giúp nút giữ vị trí và kích thước tương đối khi form thay đổi kích thước
            this.button1.Location = new System.Drawing.Point(1054, 12);//vị trí của button1 trên form
            this.button1.Name = "button1";//tên của button1
            this.button1.Size = new System.Drawing.Size(118, 38);// kích thước của nút.
            this.button1.TabIndex = 0;//thứ tự của nút trong chuỗi tab
            this.button1.Text = "Tải Lại";//Văn bản hiển thị trên nút.
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);//Click này đăng ký một phương thức xử lý khi người dùng nhấp vào nút
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;//Xác định số lượng cột trong tableLayoutPanel1
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));//Mỗi cột trong tableLayoutPanel1 được cấu hình với một kiểu ColumnStyle, sử dụng tỷ lệ phần trăm (33.33333%)
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));//Mỗi cột trong tableLayoutPanel1 được cấu hình với một kiểu ColumnStyle, sử dụng tỷ lệ phần trăm (33.33333%)
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));//Mỗi cột trong tableLayoutPanel1 được cấu hình với một kiểu ColumnStyle, sử dụng tỷ lệ phần trăm (33.33333%)
            this.tableLayoutPanel1.Controls.Add(this.pictureBox6, 2, 1);// thêm các điều khiển vào các ô trong tableLayoutPanel1.
            this.tableLayoutPanel1.Controls.Add(this.pictureBox5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);//vị trí của tableLayoutPanel1 trong form 
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";//tên của tableLayoutPanel1
            this.tableLayoutPanel1.RowCount = 2;//số lượng hàng
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));//Các hàng trong tableLayoutPanel1 được cấu hình với tỷ lệ phần trăm (50%) 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));//Các hàng trong tableLayoutPanel1 được cấu hình với tỷ lệ phần trăm (50%) 
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 525);// kích thước của tableLayoutPanel1
            this.tableLayoutPanel1.TabIndex = 3;//thứ tự tab khi người dùng di chuyển
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Gray;
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Location = new System.Drawing.Point(792, 266);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(388, 255);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Gray;
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Location = new System.Drawing.Point(398, 266);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(386, 255);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Gray;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(4, 266);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(386, 255);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Gray;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(792, 4);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(388, 254);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gray;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(398, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(386, 254);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);//thiết lập kích thước cơ bản
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 592);//kích thước của vùng làm việc (client area) của cửa sổ
            this.Controls.Add(this.splitContainer1);//Thêm splitContainer1 vào các điều khiển của form
            this.Margin = new System.Windows.Forms.Padding(4);//khoảng cách (margin) xung quanh form
            this.Name = "Form2";//tên của form. 
            this.Text = "Server-Viewer";//tiêu đề của cửa sổ form,
            this.Load += new System.EventHandler(this.Form2_Load);//Load cho form
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);//điều khiển trong form được hiển thị sau khi thiết lập và không thực hiện sắp xếp lại tự động trong quá trình khởi tạo.

        }

        #endregion
            
        //khai báo các điều khiển trong form
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
