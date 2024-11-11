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
        private readonly int port;
        private TcpListener server;
        private List<TcpClient> clients; // List to hold multiple clients
        private readonly Thread Listening;
        private readonly Dictionary<TcpClient, PictureBox> clientPictureMap; // Map clients to PictureBox controls

        public Form2(int Port)
        {
            port = Port;
            server = new TcpListener(IPAddress.Any, port);
            clients = new List<TcpClient>();
            clientPictureMap = new Dictionary<TcpClient, PictureBox>();
            Listening = new Thread(StartListening);
            InitializeComponent();
        }

        // Start listening for incoming client connections
        private void StartListening()
        {
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient(); // Accept a new client connection
                lock (clients) // Thread-safe access to the clients list
                {
                    clients.Add(client); // Add to the list of clients
                }

                // Find an available PictureBox for the client
                PictureBox assignedPictureBox = GetAvailablePictureBox();
                if (assignedPictureBox != null)
                {
                    clientPictureMap[client] = assignedPictureBox; // Map client to PictureBox
                }

                // Start a new thread to handle the client
                Thread clientThread = new Thread(() => ReceiveImage(client));
                clientThread.Start();
            }
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

        // Find an available PictureBox to display an image
        private PictureBox GetAvailablePictureBox()
        {
            // You can expand this to use more PictureBox controls, like pictureBox1, pictureBox2, etc.
            if (pictureBox1.Image == null)
            {
                return pictureBox1; // If pictureBox2 is free, return it
            }
            else if (pictureBox2.Image == null)
            {
                return pictureBox2; // If pictureBox1 is free, return it
            }
            else if (pictureBox3.Image == null)
            {
                return pictureBox3; // If pictureBox1 is free, return it
            }
            else if (pictureBox4.Image == null)
            {
                return pictureBox4; // If pictureBox1 is free, return it
            }
            else if (pictureBox5.Image == null)
            {
                return pictureBox5; // If pictureBox1 is free, return it
            }
            else if (pictureBox6.Image == null)
            {
                return pictureBox6; // If pictureBox1 is free, return it
            }

            // Add more conditions if you have more PictureBox controls
            return null; // Return null if no PictureBox is available
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // PictureBox click event (if needed)
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Additional PictureBox click event (if needed)
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
