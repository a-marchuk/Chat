using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        private static TcpListener listener;
        private static List<ChatClient> clients = new List<ChatClient>();

        static async Task Main()
        {
            string serverIP;
            int serverPort;

            // Введення IP-адреси
            Console.Write("Enter server IP: ");
            serverIP = Console.ReadLine();

            // Введення порту
            Console.Write("Enter server port: ");
            while (!int.TryParse(Console.ReadLine(), out serverPort))
            {
                Console.WriteLine("Invalid port. Please enter a valid numeric value.");
                Console.Write("Enter server port: ");
            }

            listener = new TcpListener(IPAddress.Parse(serverIP), serverPort);
            listener.Start();

            Console.WriteLine($"Server is listening on {serverIP}:{serverPort}");

            while (true)
            {
                TcpClient tcpClient = await listener.AcceptTcpClientAsync();
                ChatClient client = new ChatClient(tcpClient);
                clients.Add(client);
                Task.Run(() => HandleClientComm(client));
            }
        }

        private static async Task HandleClientComm(ChatClient senderClient)
        {
            NetworkStream clientStream = senderClient.TcpClient.GetStream();

            byte[] message = new byte[1024];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = await clientStream.ReadAsync(message, 0, 1024);
                }
                catch (Exception)
                {
                    break;
                }

                if (bytesRead == 0)
                    break;

                string clientMessage = Encoding.UTF8.GetString(message, 0, bytesRead);
                Console.WriteLine($"{senderClient.ClientId}: {clientMessage}");

                // Розсилка повідомлення всім клієнтам (крім відправника)
                foreach (var recipientClient in clients)
                {
                    if (recipientClient != senderClient)
                    {
                        byte[] reply = Encoding.UTF8.GetBytes(clientMessage);
                        await recipientClient.TcpClient.GetStream().WriteAsync(reply, 0, reply.Length);
                    }
                }
            }

            clients.Remove(senderClient);
            senderClient.TcpClient.Close();
        }
    }

    class ChatClient
    {
        public TcpClient TcpClient { get; }
        public int ClientId { get; }

        private static int nextClientId = 1;

        public ChatClient(TcpClient tcpClient)
        {
            TcpClient = tcpClient;
            ClientId = nextClientId++;
        }
    }
}
