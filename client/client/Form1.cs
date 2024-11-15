using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace client
{
    public partial class Form1 : Form
    {
        private readonly TcpClient client = new TcpClient();  // Tạo một đối tượng TcpClient để kết nối tới server
        private NetworkStream mainStream;  // Dùng để truyền dữ liệu thông qua network stream
        private int portNumber;  // Số cổng của server

        // Phương thức này dùng để lấy ảnh chụp màn hình hiện tại
        private static Image GrabDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;  // Lấy thông tin về màn hình chính
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);  // Tạo một bitmap mới với kích thước của màn hình
            Graphics graphics = Graphics.FromImage(screenshot);  // Lấy đối tượng Graphics từ bitmap để vẽ lên đó
            graphics.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);  // Chụp màn hình vào bitmap

            return screenshot;  // Trả về ảnh chụp màn hình
        }

        // Phương thức này để gửi ảnh chụp màn hình tới server
        private void SendDesktopImage()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();  // Sử dụng BinaryFormatter để tuần tự hóa ảnh
            mainStream = client.GetStream();  // Lấy stream từ client
            binFormatter.Serialize(mainStream, GrabDesktop());  // Gửi ảnh đã được tuần tự hóa thông qua stream
        }

        // Constructor của Form1
        public Form1()
        {
            ReceiveBroadcast(82);  // Gọi phương thức nhận broadcast từ cổng 82 khi khởi tạo form
        }

        // Phương thức để nhận broadcast từ cổng chỉ định
        private void ReceiveBroadcast(int port)
        {
            using (UdpClient udpClient = new UdpClient(port))  // Khởi tạo UdpClient để nhận broadcast
            {
                // Thiết lập để nhận broadcast từ bất kỳ địa chỉ IP nào
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

                Console.WriteLine($"Đang chờ nhận broadcast trên cổng {port}...");

                try
                {
                    while (true)
                    {
                        // Nhận dữ liệu từ mạng
                        byte[] receivedData = udpClient.Receive(ref endPoint);
                        string receivedMessage = Encoding.UTF8.GetString(receivedData);

                        // In ra thông tin nhận được
                        if (this.InvokeRequired)
                        {
                            // Nếu ở một luồng khác, sử dụng Invoke để cập nhật giao diện người dùng
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Nhận được gói tin(client): {receivedMessage}");
                                MessageBox.Show($"Từ địa chỉ IP(client): {endPoint.Address}, Cổng: {endPoint.Port}");

                                // Phân tích chuỗi tin nhắn nhận được để lấy IP và cổng
                                string[] parts = receivedMessage.Split(new[] { ", " }, StringSplitOptions.None);
                                string ipAddress = parts[0].Replace("IP: ", "");  // Lấy địa chỉ IP
                                string portString = parts[1].Replace("Port: ", "");  // Lấy số cổng
                            }));
                        }

                        // Phân tích chuỗi tin nhắn để lấy địa chỉ IP và cổng
                        string[] parts1 = receivedMessage.Split(new[] { ", " }, StringSplitOptions.None);
                        string ipAddress1 = parts1[0].Replace("IP: ", "");  // Lấy địa chỉ IP
                        string portString1 = parts1[1].Replace("Port: ", "");  // Lấy số cổng

                        // Khởi tạo giao diện người dùng và thiết lập địa chỉ IP cho TextBox
                        InitializeComponent();
                        txtIP.Text = ipAddress1;

                        portNumber = int.Parse(txtPort.Text);
                        client.Connect(txtIP.Text, portNumber);
                        timer1.Start();
                        
                        // Dừng vòng lặp sau khi nhận được gói tin
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi nhận broadcast: " + ex.Message);
                }
            }
        }

        // Sự kiện khi form tải lên
        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập một Timer để trì hoãn việc ẩn Form1
            Timer timer = new Timer();
            timer.Interval = 1; // Thiết lập thời gian trễ (ví dụ: 1000 ms = 1 giây)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // Xử lý sự kiện của Timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            timer.Stop();  // Dừng timer để ngăn chặn việc lặp lại

            this.Hide();  // Ẩn Form1
        }

        // Xử lý sự kiện khi nhấn nút kết nối
        private void btnConnect_Click(object sender, EventArgs e)
        {
            portNumber = int.Parse(txtPort.Text);
            try
            {
                client.Connect(txtIP.Text, portNumber);
                btnConnect.Text = "Connected";
                MessageBox.Show("Connected");
                btnConnect.Enabled = false;
                btnShare.Enabled = true;  // Cho phép chia sẻ màn hình khi kết nối thành công
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect..");
                btnConnect.Text = "Not Connected";
            }
        }

        // Xử lý sự kiện khi nhấn nút chia sẻ màn hình
        private void btnShare_Click(object sender, EventArgs e)
        {
            if (btnShare.Text.StartsWith("Share"))
            {
                timer1.Start();  // Bắt đầu chia sẻ màn hình
                btnShare.Text = "Stop Sharing";
            }
            else
            {
                timer1.Stop();  // Dừng chia sẻ màn hình
                btnShare.Text = "Share My Screen";
            }
        }

        // Xử lý sự kiện của Timer để gửi hình ảnh
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();  // Gửi ảnh màn hình mỗi khi Timer kích hoạt
        }

        // Xử lý sự kiện khi nhấn nút hiển thị thông tin phần mềm
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software created by sojeb sikder. (c)SojebSoft");
        }
    }
}
