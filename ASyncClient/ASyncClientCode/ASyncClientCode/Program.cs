using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ASyncClientCode
{
    class Program
    {
        public static async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];

            int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.WriteLine("\n" + receivedMessage);
        }

        static void Main()
        {
            TcpClient client = new TcpClient();

            int port = 13356;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPAddress ip = IPAddress.Parse("172.16.113.102");
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            client.Connect(endPoint);

            NetworkStream stream = client.GetStream();
            ReceiveMessage(stream);

            Console.WriteLine("Write your message here: ");
            string text = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream.Write(buffer, 0, buffer.Length);

            client.Close();
        }
    }
}
