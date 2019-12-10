using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Netvaerk_prog_server
{
    class Program
    {
        static void Main(string[] args)
        {
            /***********Connection med hvilken som helst ip*****************/
            int port = 13356;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);

            /***********lytter efter en forbindelse***********/
            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();

            Console.WriteLine("Awaiting Clients");//venter på connection besked
            TcpClient client = listener.AcceptTcpClient();

            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[256];
            int numberOfBytesRead = stream.Read(buffer, 0, 256);

            string message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.WriteLine(message);

            /*************Svar tilbage til client*************/
            string text2 = "Hello we have established a connection!";
            byte[] buffer2 = Encoding.UTF8.GetBytes(text2);

            stream.Write(buffer2, 0, buffer2.Length);

        }
    }
}
