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
        private readonly TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int portNumber;

        private static Image GrabDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenshot);
            graphics.CopyFromScreen(bounds.X,bounds.Y,0,0,bounds.Size, CopyPixelOperation.SourceCopy);
           
            return screenshot;
        }

        private void SendDesktopImage()
        {
          
                BinaryFormatter binFormatter = new BinaryFormatter();
                mainStream = client.GetStream();
                binFormatter.Serialize(mainStream, GrabDesktop());
         
        }

        public Form1()
        {
            ReceiveBroadcast(82);
        }


        private void ReceiveBroadcast(int port)
        {
            using (UdpClient udpClient = new UdpClient(port))
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
                            // If on a different thread, use Invoke to update the UI
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Nhận được gói tin(client): {receivedMessage}");
                                MessageBox.Show($"Từ địa chỉ IP(client): {endPoint.Address}, Cổng: {endPoint.Port}");

                                // Parsing the received message to extract IP and Port
                                string[] parts = receivedMessage.Split(new[] { ", " }, StringSplitOptions.None);
                                string ipAddress = parts[0].Replace("IP: ", "");  // Extract IP
                                string portString = parts[1].Replace("Port: ", "");  // Extract Port

                               
                            }));
                        }


                        string[] parts1 = receivedMessage.Split(new[] { ", " }, StringSplitOptions.None);
                        string ipAddress1 = parts1[0].Replace("IP: ", "");  // Extract IP
                        string portString1 = parts1[1].Replace("Port: ", "");  // Extract Port
                        //MessageBox.Show($"Nhận được góiww tin(client): {ipAddress1}");
                        //MessageBox.Show($"Nhận được góidddw tin(client): {portString1}");

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


        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    btnShare.Enabled = false;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up a Timer to delay hiding Form1
            Timer timer = new Timer();
            timer.Interval = 1; // Set delay in milliseconds (e.g., 1000 ms = 1 second)
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
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            
            portNumber = int.Parse(txtPort.Text);
            try
            {
                client.Connect(txtIP.Text,portNumber);
                btnConnect.Text = "Connected";
               // btnConnect.Enabled = false;
               // btnConnect.ForeColor = Color.White;
                MessageBox.Show("Connected");
                btnConnect.Enabled = false;
                btnShare.Enabled = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to connect..");
                btnConnect.Text = "Not Connected";
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if(btnShare.Text.StartsWith("Share"))
            {
                timer1.Start();
                btnShare.Text = "Stop Sharing";
            }
            else{
                timer1.Stop();
                btnShare.Text = "Share My Screen";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();
        }
        // private void btnShare_Click(object sender, EventArgs e)
        // {
        //     if(btnShare.Text.StartsWith("Share"))
        //     {
        //         timer1.Start();
        //         btnShare.Text = "Stop Sharing";
        //     }
        //     else{
        //         timer1.Stop();
        //         btnShare.Text = "Share My Screen";
        //     }
        // }
        // private void timer1_Tick(object sender, EventArgs e)
        // {
        //     SendDesktopImage();
        // }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software created by sojeb sikder. (c)SojebSoft");
        }
       
    }
}
