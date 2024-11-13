namespace server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null; // Biến để chứa các thành phần của form.

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) // Phương thức giải phóng tài nguyên khi form đóng.
        {
            if (disposing && (components != null)) // Nếu form đang sử dụng các tài nguyên thì giải phóng chúng.
            {
                components.Dispose(); // Giải phóng các thành phần của form.
            }
            base.Dispose(disposing); // Gọi phương thức Dispose của lớp cha.
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() // Phương thức khởi tạo các thành phần giao diện.
        {
            this.btnListen = new System.Windows.Forms.Button();  // Khởi tạo nút btnListen.
            this.txtPort = new System.Windows.Forms.TextBox();    // Khởi tạo ô nhập txtPort.
            this.label1 = new System.Windows.Forms.Label();       // Khởi tạo nhãn label1.
            this.SuspendLayout();                                // Tạm ngưng layout để thiết lập thuộc tính.

            // 
            // btnListen
            // 
            this.btnListen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))); // Màu nền khi di chuột qua nút.
            this.btnListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;  // Thiết lập kiểu nút phẳng.
            this.btnListen.ForeColor = System.Drawing.SystemColors.MenuHighlight; // Thiết lập màu chữ cho nút.
            this.btnListen.Location = new System.Drawing.Point(24, 89); // Vị trí nút trên form.
            this.btnListen.Name = "btnListen";              // Tên của nút.
            this.btnListen.Size = new System.Drawing.Size(181, 33); // Kích thước nút.
            this.btnListen.TabIndex = 0;                     // Chỉ số tab cho nút.
            this.btnListen.Text = "Listen";                 // Văn bản trên nút.
            this.btnListen.UseVisualStyleBackColor = true;   // Cho phép sử dụng màu nền.
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click); // Sự kiện khi nhấn nút.

            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.Black; // Màu nền của ô nhập.
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Thiết lập font chữ.
            this.txtPort.ForeColor = System.Drawing.Color.DodgerBlue; // Màu chữ của ô nhập.
            this.txtPort.Location = new System.Drawing.Point(64, 37); // Vị trí của ô nhập trên form.
            this.txtPort.Name = "txtPort";                 // Tên của ô nhập.
            this.txtPort.Size = new System.Drawing.Size(141, 26); // Kích thước của ô nhập.
            this.txtPort.TabIndex = 1;                      // Chỉ số tab cho ô nhập.
            this.txtPort.Text = "81";                      // Văn bản mặc định trong ô nhập.

            // 
            // label1
            // 
            this.label1.AutoSize = true;                   // Thiết lập kích thước tự động cho nhãn.
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F); // Thiết lập font chữ cho nhãn.
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))); // Màu chữ của nhãn.
            this.label1.Location = new System.Drawing.Point(12, 40); // Vị trí của nhãn trên form.
            this.label1.Name = "label1";                   // Tên của nhãn.
            this.label1.Size = new System.Drawing.Size(46, 20); // Kích thước của nhãn.
            this.label1.TabIndex = 2;                      // Chỉ số tab cho nhãn.
            this.label1.Text = "Port :"; // Văn bản hiển thị trên nhãn.

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F); // Kích thước tỷ lệ tự động của form.
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // Kiểu tỷ lệ tự động.
            this.BackColor = System.Drawing.Color.Black;                 // Màu nền của form.
            this.ClientSize = new System.Drawing.Size(235, 153);         // Kích thước của form.
            this.Controls.Add(this.label1);                             // Thêm nhãn vào form.
            this.Controls.Add(this.txtPort);                            // Thêm ô nhập vào form.
            this.Controls.Add(this.btnListen);                          // Thêm nút vào form.
            this.Name = "Form1";                                       // Tên của form.
            this.Text = "Server";                                       // Tiêu đề của form.
            this.Load += new System.EventHandler(this.Form1_Load);      // Sự kiện khi form tải.
            this.ResumeLayout(false);                                   // Tiếp tục layout sau khi thiết lập xong.
            this.PerformLayout();                                       // Thiết lập lại layout.
        }

        #endregion

        private System.Windows.Forms.Button btnListen; // Khai báo nút Listen.
        private System.Windows.Forms.TextBox txtPort;   // Khai báo ô nhập Port.
        private System.Windows.Forms.Label label1;      // Khai báo nhãn Port.
    }
}
