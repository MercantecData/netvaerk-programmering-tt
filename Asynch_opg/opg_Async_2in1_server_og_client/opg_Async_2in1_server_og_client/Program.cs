using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace opg_Async_2in1_server_og_client
{
    class Program
    {
        public static async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];

            int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.Write("\nResponse message from: " + receivedMessage);// Besked ved message overført
        }

        public static async void serverprog()
        {
            int port = 13356;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ip, port);

            TcpListener listener = new TcpListener(localEndPoint);

            listener.Start();

            Console.WriteLine("Awaiting Clients");
            TcpClient client = await listener.AcceptTcpClientAsync(); //venter på svar fra client
           

            NetworkStream stream = client.GetStream(); //besked modtagelse
            ReceiveMessage(stream);

            //mulighed for svar tilbage
            string text = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream.Write(buffer, 0, buffer.Length);
            //Console.ReadKey();

        }
       
        public static void clientprog()
        {
            TcpClient client = new TcpClient();

            int port = 13356;
            IPAddress ip = IPAddress.Parse("127.0.0.1");//IPAddress ip = IPAddress.Parse("172.16.113.102");
            
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            client.Connect(endPoint);

            NetworkStream stream = client.GetStream();
            ReceiveMessage(stream);

            Console.WriteLine("Write your message here: ");
            string text = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream.Write(buffer, 0, buffer.Length);
            //client.Close();    //Gør at den skriver "Response message from Client: " 1 eller 2 gange
        }


        static void Main(string[] args)
        {
            Console.WriteLine("\nServer part: ");
            serverprog();
            
            Console.WriteLine("\nClient part: ");
            clientprog();

            Console.ReadLine();
        }
    }
}
