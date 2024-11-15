using System;                          // Sử dụng thư viện cơ bản của C#.
using System.Collections.Generic;       // Thư viện hỗ trợ các cấu trúc dữ liệu như List, Dictionary.
using System.ComponentModel;            // Thư viện hỗ trợ về các component và thuộc tính.
using System.Data;                      // Thư viện hỗ trợ xử lý dữ liệu.
using System.Drawing;                   // Thư viện hỗ trợ đồ họa, màu sắc.
using System.Linq;                      // Thư viện hỗ trợ các phương thức truy vấn LINQ.
using System.Net;                       // Thư viện cung cấp các lớp mạng.
using System.Net.Sockets;               // Thư viện hỗ trợ giao thức socket TCP và UDP.
using System.Text;                      // Thư viện hỗ trợ các phương thức mã hóa chuỗi.
using System.Threading.Tasks;           // Thư viện hỗ trợ các tác vụ bất đồng bộ.
using System.Windows.Forms;             // Thư viện hỗ trợ tạo giao diện người dùng WinForms.

namespace server                       // Định nghĩa namespace server, giúp tổ chức mã nguồn.
{
    public partial class Form1 : Form   // Định nghĩa lớp Form1 kế thừa từ Form (giao diện).
    {
        public Form1()                  // Constructor của Form1.
        {
            InitializeComponent();      // Khởi tạo các thành phần giao diện.
        }

        private void btnListen_Click(object sender, EventArgs e) // Hàm xử lý khi nút Listen được nhấn.
        {
            var ipAddress = GetLocalIPv4Address();             // Lấy địa chỉ IP của máy tính.
            BroadcastIPAddressAndPort(ipAddress, 82);          // Gửi địa chỉ IP và cổng đến mạng LAN.

            //int sendPort = 82;
            //string ipAddress = "127.0.0.1"; // Localhost or specify the receiver's IP address
            //string message = "Hello from Form1";

            //try
            //{
            //    using (TcpClient tcpClient = new TcpClient(ipAddress, sendPort))
            //    using (NetworkStream stream = tcpClient.GetStream())
            //    {
            //        byte[] data = Encoding.UTF8.GetBytes(message);
            //        stream.Write(data, 0, data.Length);
            //        MessageBox.Show("Message sent to port " + sendPort);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error sending message: " + ex.Message);
            //}


            //int port = int.Parse(txtPort.Text);
            //Form2 f2 = new Form2(port);
            //f2.Show();

            // Khởi tạo Form2 và truyền vào cổng từ txtPort để mở kết nối.
            new Form2(int.Parse(txtPort.Text)).Show();
            btnListen.Enabled = false;                         // Vô hiệu hóa nút Listen.
        }

        private string GetLocalIPv4Address()                   // Hàm lấy địa chỉ IPv4 của máy tính.
        {
            string hostName = Dns.GetHostName();               // Lấy tên máy tính.
            var ipAddresses = Dns.GetHostAddresses(hostName);  // Lấy danh sách các địa chỉ IP.

            // Tìm địa chỉ IP nào là IPv4.
            var ipv4Address = ipAddresses.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return ipv4Address?.ToString() ?? "Không tìm thấy địa chỉ IPv4."; // Trả về địa chỉ IPv4 hoặc thông báo lỗi.
        }

        // Gửi địa chỉ IP và cổng của máy chủ đến tất cả các thiết bị trong mạng LAN qua UDP
        private void BroadcastIPAddressAndPort(string ipAddress, int port)
        {
            using (UdpClient udpClient = new UdpClient())      // Tạo một UDP client để gửi dữ liệu.
            {
                IPEndPoint broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, port); // Địa chỉ phát sóng tới toàn mạng LAN (255.255.255.255).

                string message = $"IP: {ipAddress}, Port: {port}"; // Tạo chuỗi tin nhắn với IP và cổng.
                byte[] data = Encoding.UTF8.GetBytes(message);     // Mã hóa tin nhắn thành mảng byte.

                udpClient.EnableBroadcast = true;                 // Cho phép phát sóng qua UDP.

                try
                {
                    udpClient.Send(data, data.Length, broadcastEndPoint); // Gửi tin nhắn phát sóng đến mạng LAN.
                }
                catch (Exception ex)                               // Bắt lỗi nếu có lỗi khi gửi.
                {
                    Console.WriteLine("Lỗi khi gửi broadcast: " + ex.Message); // In ra lỗi.
                }
            }
        }
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    var ipAddress = GetLocalIPv4Address();
        //    BroadcastIPAddressAndPort(ipAddress, 82);
        //    new Form2(int.Parse(txtPort.Text)).Show();
        //    this.Hide();
        //}
        private void Form1_Load(object sender, EventArgs e)    // Sự kiện khi Form1 tải xong.
        {
            Timer timer = new Timer();                         // Tạo timer để trì hoãn đóng Form1.
            timer.Interval = 10;                               // Đặt thời gian trì hoãn (10ms).
            timer.Tick += Timer_Tick;                          // Gán sự kiện Tick cho Timer_Tick.
            timer.Start();                                     // Bắt đầu timer.
        }

        private void Timer_Tick(object sender, EventArgs e)    // Hàm xử lý khi Timer chạy.
        {
            Timer timer = sender as Timer;                     // Ép kiểu sender về Timer.
            timer.Stop();                                      // Dừng timer để tránh lặp lại.

            this.Hide();                                       // Ẩn Form1.

            var ipAddress = GetLocalIPv4Address();             // Lấy địa chỉ IP của máy.
            BroadcastIPAddressAndPort(ipAddress, 82);          // Gửi địa chỉ IP và cổng tới mạng LAN.
            new Form2(int.Parse(txtPort.Text)).Show();         // Mở Form2 với cổng từ txtPort.
        }

        private void txtPort_TextChanged(object sender, EventArgs e) // Hàm xử lý khi nội dung txtPort thay đổi.
        {
            // Không có thao tác nào.
        }
    }
}
