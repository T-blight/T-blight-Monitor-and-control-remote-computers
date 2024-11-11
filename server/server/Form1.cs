using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            var ipAddress = GetLocalIPv4Address();
            BroadcastIPAddressAndPort(ipAddress, 82);

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
            new Form2(int.Parse(txtPort.Text)).Show();
            btnListen.Enabled = false;
        }

        private string GetLocalIPv4Address()
        {
            string hostName = Dns.GetHostName(); // Lấy tên máy tính
            var ipAddresses = Dns.GetHostAddresses(hostName); // Lấy tất cả các địa chỉ IP

            // Tìm địa chỉ IPv4 đầu tiên
            var ipv4Address = ipAddresses.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return ipv4Address?.ToString() ?? "Không tìm thấy địa chỉ IPv4.";
        }


        //gửi thông tin máy chủ đến toàn LAN
        private void BroadcastIPAddressAndPort(string ipAddress, int port)
        {
            using (UdpClient udpClient = new UdpClient())
            {
                // Thiết lập broadcast (255.255.255.255) và port 82
                IPEndPoint broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, port);

                string message = $"IP: {ipAddress}, Port: {port}";
                byte[] data = Encoding.UTF8.GetBytes(message);

                udpClient.EnableBroadcast = true;

                try
                {
                    // Gửi tin nhắn broadcast chứa địa chỉ IP và cổng
                    udpClient.Send(data, data.Length, broadcastEndPoint);
                    //MessageBox.Show($"Đã gửi thông tin IP: {ipAddress} và Port: {port} cho toàn mạng LAN");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi gửi broadcast: " + ex.Message);
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
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up a Timer to delay hiding Form1
            Timer timer = new Timer();
            timer.Interval = 10; // Set delay in milliseconds (e.g., 1000 ms = 1 second)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer to prevent repeated ticks
            Timer timer = sender as Timer;
            timer.Stop();

            // Hide Form1 and show Form2
            this.Hide();

            var ipAddress = GetLocalIPv4Address();
            BroadcastIPAddressAndPort(ipAddress, 82);
            new Form2(int.Parse(txtPort.Text)).Show();
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
