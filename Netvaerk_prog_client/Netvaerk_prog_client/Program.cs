using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Netvaerk_prog_client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            
            /**************Connection oprettelse**************/
            int port = 13356;
            //IPAddress ip = IPAddress.Parse("172.16.115.102");//remote
            //IPAddress ip = IPAddress.Parse("127.0.0.1");//local
            Console.WriteLine("Write the IPadress you want to connect to: ");
            string ipaddresse = Console.ReadLine();
            IPAddress ip = IPAddress.Parse(ipaddresse);//fået fra variable
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            
            client.Connect(endPoint);
            
            NetworkStream stream = client.GetStream();
            
            /***************Besked til server****************/
            //string text = "Test Hello Network!";
            Console.WriteLine("Write a Message to the receiver: ");
            string text = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            
            stream.Write(buffer, 0, buffer.Length);
            
            /***************Svar fra server****************/
            byte[] buffer2 = new byte[256];
            int numberOfBytesRead = stream.Read(buffer2, 0, 256);

            string message2 = Encoding.UTF8.GetString(buffer2, 0, numberOfBytesRead);

            Console.WriteLine(message2);
            

            client.Close();


            
        }
    }
}
