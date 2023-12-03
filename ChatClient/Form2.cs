using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChatClient
{
    public partial class Form2 : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public Form2()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(txtServerIP.Text, int.Parse(txtServerPort.Text));
                stream = client.GetStream();
                ReceiveMessages();
                lblStatus.Text = "Connected to server";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error connecting to server: " + ex.Message;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync(txtName.Text, txtMessage.Text);
        }

        private async void ReceiveMessages()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Виведення отриманого повідомлення в текстове поле з переносом на новий рядок
                    txtChat.Invoke(new Action(() =>
                    {
                        txtChat.AppendText(message + Environment.NewLine);
                    }));
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error receiving message: " + ex.Message;
                    break;
                }
            }
        }


        private async Task SendMessageAsync(string name, string message)
        {
            try
            {
                string messageBody = name + ": " + message;
                byte[] buffer = Encoding.UTF8.GetBytes(messageBody);
                await stream.WriteAsync(buffer, 0, buffer.Length);

                // Виведення відправленого повідомлення в текстове поле
                txtChat.Invoke(new Action(() =>
                {
                    txtChat.AppendText("You: " + message + Environment.NewLine);
                }));
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Error sending message: " + ex.Message;
            }
        }
    }
}
