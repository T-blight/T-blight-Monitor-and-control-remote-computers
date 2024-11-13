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
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.NetworkInformation;

namespace server
{
    public partial class Form2 : Form
    {
        private readonly int port; // Cổng kết nối server
        private TcpListener server; // Biến để khởi tạo server lắng nghe kết nối
        private List<TcpClient> clients; // Danh sách lưu trữ các client
        private readonly Thread Listening; // Luồng lắng nghe client mới
        private readonly Dictionary<TcpClient, PictureBox> clientPictureMap; // Bản đồ ánh xạ client và PictureBox
        private UserControl1 userControl1; // Đối tượng để quản lý hiển thị hình ảnh
        private System.Windows.Forms.Timer updateTimer; // Timer để cập nhật ảnh hiển thị
        public Form2(int Port)
        {
            port = Port; // Gán cổng truyền vào cho biến port
            server = new TcpListener(IPAddress.Any, port); // Khởi tạo server lắng nghe trên tất cả các IP và cổng
            clients = new List<TcpClient>(); // Khởi tạo danh sách client
            clientPictureMap = new Dictionary<TcpClient, PictureBox>(); // Khởi tạo bản đồ ánh xạ client - PictureBox
            Listening = new Thread(StartListening); // Tạo luồng mới để lắng nghe kết nối
            InitializeComponent(); // Khởi tạo các thành phần giao diện
            button2.Hide(); // Ẩn nút button2 khi khởi tạo form
        }

        private void StartListening()
        {
            server.Start(); // Bắt đầu lắng nghe kết nối
            while (true)
            {
                TcpClient client = server.AcceptTcpClient(); // Chấp nhận một kết nối client mới
                lock (clients) // Đảm bảo an toàn luồng khi truy cập danh sách clients
                {
                    clients.Add(client); // Thêm client vào danh sách
                }

                PictureBox assignedPictureBox = GetAvailablePictureBox(); // Tìm PictureBox khả dụng cho client
                if (assignedPictureBox != null)
                {
                    lock (clientPictureMap) // Đảm bảo an toàn khi cập nhật clientPictureMap
                    {
                        clientPictureMap[client] = assignedPictureBox; // Ánh xạ client với PictureBox
                    }
                }

                Thread clientThread = new Thread(() => ReceiveImage(client)); // Tạo luồng mới cho client
                clientThread.Start(); // Bắt đầu luồng nhận hình ảnh từ client
            }
        }

        private PictureBox GetAvailablePictureBox()
        {
            // Lock to ensure thread-safety when accessing shared resources
            lock (clientPictureMap)
            {
                // Check for available PictureBoxes, returning the first available one
                if (pictureBox1.Image == null && !clientPictureMap.Values.Contains(pictureBox1))
                {
                    return pictureBox1; // If pictureBox1 is free, return it
                }
                else if (pictureBox2.Image == null && !clientPictureMap.Values.Contains(pictureBox2))
                {
                    return pictureBox2; // If pictureBox2 is free, return it
                }
                else if (pictureBox3.Image == null && !clientPictureMap.Values.Contains(pictureBox3))
                {
                    return pictureBox3; // If pictureBox3 is free, return it
                }
                else if (pictureBox4.Image == null && !clientPictureMap.Values.Contains(pictureBox4))
                {
                    return pictureBox4; // If pictureBox4 is free, return it
                }
                else if (pictureBox5.Image == null && !clientPictureMap.Values.Contains(pictureBox5))
                {
                    return pictureBox5; // If pictureBox5 is free, return it
                }
                else if (pictureBox6.Image == null && !clientPictureMap.Values.Contains(pictureBox6))
                {
                    return pictureBox6; // If pictureBox6 is free, return it
                }
            }

            // Add more conditions if you have more PictureBox controls
            return null; // Return null if no PictureBox is available
        }



        // Method to receive and display images from each client
        private void ReceiveImage(TcpClient client)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            NetworkStream stream = client.GetStream();

            while (client.Connected)
            {
                try
                {
                    Image image = (Image)binFormatter.Deserialize(stream); // Deserialize the image

                    // Get the corresponding PictureBox for this client
                    if (clientPictureMap.ContainsKey(client))
                    {
                        PictureBox assignedPictureBox = clientPictureMap[client];

                        // Update the PictureBox in a thread-safe way on the UI thread
                        assignedPictureBox.Invoke(new Action(() => assignedPictureBox.Image = image));
                    }
                }
                catch (Exception)
                {
                    break; // Exit the loop if any error occurs (e.g., client disconnects)
                }
            }

            // Remove the client from the list when it disconnects
            lock (clients)
            {
                clients.Remove(client);
            }
            client.Close(); // Close the client connection
        }

        // Stops the server and closes all connections
        private void StopListening()
        {
            lock (clients)
            {
                foreach (var client in clients)
                {
                    client.Close();
                }
                clients.Clear();
            }
            server.Stop();
        }


        //lấy dddiaj chỉ mạng của máy chủ
        private string GetLocalIPv4Address()
        {
            string hostName = Dns.GetHostName(); // Lấy tên máy tính
            var ipAddresses = Dns.GetHostAddresses(hostName); // Lấy tất cả các địa chỉ IP

            // Tìm địa chỉ IPv4 đầu tiên
            var ipv4Address = ipAddresses.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return ipv4Address?.ToString() ?? "Không tìm thấy địa chỉ IPv4.";
        }


        //gửi thông tin máy chủ đến toàn LAN
        //private void BroadcastIPAddressAndPort(string ipAddress, int port)
        //{
        //    using (UdpClient udpClient = new UdpClient())
        //    {
        //        // Thiết lập broadcast (255.255.255.255) và port 82
        //        IPEndPoint broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, port);
        //        MessageBox.Show("kkkkkkkkk",IPAddress.Broadcast.ToString());
        //        string message = $"IP: {ipAddress}, Port: {port}";
        //        byte[] data = Encoding.UTF8.GetBytes(message);

        //        udpClient.EnableBroadcast = true;

        //        try
        //        {
        //            // Gửi tin nhắn broadcast chứa địa chỉ IP và cổng
        //            udpClient.Send(data, data.Length, broadcastEndPoint);
        //            Console.WriteLine($"Đã gửi thông tin IP: {ipAddress} và Port: {port} cho toàn mạng LAN");
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Lỗi khi gửi broadcast: " + ex.Message);
        //        }
        //    }
        //}
        //



        static string GetLocalIpAddress()
        {
            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    IPInterfaceProperties properties = networkInterface.GetIPProperties();
                    foreach (var address in properties.UnicastAddresses)
                    {
                        if (address.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return address.Address.ToString(); // Trả về địa chỉ IPv4
                        }
                    }
                }
            }
            return null;
        }

        // Hàm tính toán địa chỉ broadcast từ địa chỉ IP cục bộ
        static string GetBroadcastAddress(string localIp)
        {
            string[] ipParts = localIp.Split('.');
            if (ipParts.Length != 4) return null;

            // Giả sử subnet mask là 255.255.255.0
            // Tính toán địa chỉ broadcast cho mạng con này
            ipParts[3] = "255";  // Đặt phần cuối của địa chỉ IP thành 255 để tạo địa chỉ broadcast

            return string.Join(".", ipParts);
        }

        // Hàm gửi gói tin broadcast tới mạng LAN, nhận vào địa chỉ IP và cổng
        private static void BroadcastIPAddressAndPort(string ipAddress, int port, string message)
        {
            // Cấu hình địa chỉ endpoint broadcast
            IPEndPoint broadcastEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            // Khởi tạo UdpClient và bật chế độ Broadcast
            using (UdpClient udpClient = new UdpClient())
            {
                udpClient.EnableBroadcast = true;

                // Chuyển message thành byte array
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Gửi gói tin broadcast
                udpClient.Send(data, data.Length, broadcastEndPoint);
                Console.WriteLine("Gửi thông điệp broadcast tới mạng.");

                // Đóng UdpClient (sử dụng using sẽ tự động đóng)
            }
        }


        // Form load event: start the listening thread
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Listening.Start(); // Start listening for incoming clients
        }

        // Form closing event: stop the server and close all connections
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopListening(); // Stop all connections when the form closes
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Additional load logic (if needed)
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            // Additional painting logic (if needed)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ipAddress = GetLocalIPv4Address();
            string message = $"IP: {ipAddress}, Port: {port}";
            string broadcastAddress = GetBroadcastAddress(ipAddress);
            BroadcastIPAddressAndPort(broadcastAddress, 82, message);
        }

        private void UpdateDisplayImage(Image image)
        {
            if (button2.Visible)
            {
                userControl1.DisplayImage = image;
            }
            else
            {
                updateTimer.Stop();
                MessageBox.Show("off");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            userControl1 = new UserControl1
            {
                DisplayImage = pictureBox1.Image
            };
            splitContainer1.Panel2.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
            userControl1.BringToFront();
            button2.Show();

            if (updateTimer == null)
            {
                updateTimer = new System.Windows.Forms.Timer
                {
                    Interval = 10 // Update every second (adjust as needed)
                };
                updateTimer.Tick += (s, args) => UpdateDisplayImage(pictureBox1.Image);
            }

            updateTimer.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            userControl1 = new UserControl1
            {
                DisplayImage = pictureBox2.Image
            };
            splitContainer1.Panel2.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
            userControl1.BringToFront();
            button2.Show();

            if (updateTimer == null)
            {
                updateTimer = new System.Windows.Forms.Timer
                {
                    Interval = 10 // Update every second (adjust as needed)
                };
                updateTimer.Tick += (s, args) => UpdateDisplayImage(pictureBox2.Image);
            }

            updateTimer.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            userControl1 = new UserControl1
            {
                DisplayImage = pictureBox3.Image
            };
            splitContainer1.Panel2.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
            userControl1.BringToFront();
            button2.Show();

            if (updateTimer == null)
            {
                updateTimer = new System.Windows.Forms.Timer
                {
                    Interval = 10 // Update every second (adjust as needed)
                };
                updateTimer.Tick += (s, args) => UpdateDisplayImage(pictureBox3.Image);
            }

            updateTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Stop the timer if it's running
            if (updateTimer != null)
            {
                updateTimer.Stop();
                updateTimer.Dispose(); // Dispose of the timer when done
                updateTimer = null; // Nullify the reference to prevent reuse
            }

            // Remove and dispose userControl1 if it's not null
            if (userControl1 != null)
            {
                splitContainer1.Panel1.Controls.Remove(userControl1);
                userControl1.Dispose();
                userControl1 = null;
            }

            // Show the table layout panel again and hide button2
            tableLayoutPanel1.Show();
            button2.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            userControl1 = new UserControl1
            {
                DisplayImage = pictureBox4.Image
            };
            splitContainer1.Panel2.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
            userControl1.BringToFront();
            button2.Show();

            if (updateTimer == null)
            {
                updateTimer = new System.Windows.Forms.Timer
                {
                    Interval = 10 // Update every second (adjust as needed)
                };
                updateTimer.Tick += (s, args) => UpdateDisplayImage(pictureBox4.Image);
            }

            updateTimer.Start();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            userControl1 = new UserControl1
            {
                DisplayImage = pictureBox5.Image
            };
            splitContainer1.Panel2.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
            userControl1.BringToFront();
            button2.Show();


            if (updateTimer == null)
            {
                updateTimer = new System.Windows.Forms.Timer
                {
                    Interval = 10 // Update every second (adjust as needed)
                };
                updateTimer.Tick += (s, args) => UpdateDisplayImage(pictureBox5.Image);
            }

            updateTimer.Start();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            userControl1 = new UserControl1
            {
                DisplayImage = pictureBox6.Image
            };
            splitContainer1.Panel2.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
            userControl1.BringToFront();
            button2.Show();

            if (updateTimer == null)
            {
                updateTimer = new System.Windows.Forms.Timer
                {
                    Interval = 10 // Update every second (adjust as needed)
                };
                updateTimer.Tick += (s, args) => UpdateDisplayImage(pictureBox6.Image);
            }

            updateTimer.Start();
        }
    }
}
