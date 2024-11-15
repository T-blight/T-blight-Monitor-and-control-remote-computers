namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;//một bộ chứa (container) quản lý các thành phần (components) trên Form, như các nút, textboxes, hoặc labels.
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //Hàm này được gọi để giải phóng tài nguyên. Nếu disposing là true, nó sẽ hủy tất cả các thành phần được quản lý bởi components
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
        //Phương thức này để khởi tạo giao diện.
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();//Khởi tạo container để chứa các thành phần trên Form
            this.btnConnect = new System.Windows.Forms.Button();//Tạo một nút với tên là btnConnect.Nút này có sự kiện Click gọi đến hàm btnConnect_Click 
            this.txtIP = new System.Windows.Forms.TextBox();//Tạo một hộp văn bản txtIP để nhập địa chỉ IP.
            this.txtPort = new System.Windows.Forms.TextBox();//Tạo hộp văn bản txtPort để nhập cổng.
            this.label1 = new System.Windows.Forms.Label();//Tạo nhãn label1 hiển thị "IP:"
            this.label2 = new System.Windows.Forms.Label();//Tạo nhãn label2 hiển thị "Port:"
            this.btnShare = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnConnect.Location = new System.Drawing.Point(37, 185);//Đặt vị trí nút trên form: tọa độ (37, 185) tính từ góc trái trên của form.
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 40);//Kích thước nút: rộng 75 pixel, cao 40 pixel.
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";//Gán chữ "Connect" làm nội dung hiển thị trên nút.
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);//Gán sự kiện btnConnect_Click khi nút được nhấn.
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.Black;
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtIP.ForeColor = System.Drawing.Color.DodgerBlue;//Màu nền của hộp văn bản là đen, chữ màu xanh dương nhạt.
            this.txtIP.Location = new System.Drawing.Point(37, 45);//Đặt vị trí hộp văn bản tại tọa độ (37, 45).
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(191, 26);//Kích thước hộp văn bản: rộng 191 pixel, cao 26 pixel.
            this.txtIP.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.Black;
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPort.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtPort.Location = new System.Drawing.Point(37, 108);//Đặt vị trí hộp văn bản tại tọa độ (37, 108).
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(191, 26);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "81";//Giá trị mặc định của hộp là "81".
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(34, 18);//hiển thị "IP:", đặt tại tọa độ (34, 18).
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(34, 81);//hiển thị "Port:", đặt tại tọa độ (34, 81).
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // btnShare
            //
            // Nút này dùng để chia sẻ màn hình. Khi nhấn, gọi hàm btnShare_Click.
            this.btnShare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShare.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnShare.Location = new System.Drawing.Point(145, 185);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(83, 40);
            this.btnShare.TabIndex = 5;
            this.btnShare.Text = "Share My Screen";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // timer1
            // 
            //timer1 là một bộ đếm thời gian. Mỗi khi đếm xong một khoảng thời gian, sự kiện timer1_Tick được kích hoạt.
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            //Nút này dùng để hiển thị thông tin (gắn với sự kiện button1_Click).
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(177, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;//Màu nền của form là đen.
            this.ClientSize = new System.Drawing.Size(263, 261);//Đặt kích thước form là 263 pixel (rộng) x 261 pixel (cao).
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Client";//Đặt tiêu đề cửa sổ là "Client".
            this.Load += new System.EventHandler(this.Form1_Load);//Khi form được tải, sự kiện Form1_Load sẽ được gọi.
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
            
        // Các thành phần giao diện
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}


