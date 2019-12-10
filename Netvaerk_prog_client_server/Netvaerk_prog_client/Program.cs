using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Netvaerk_prog_client
{
    class Program
    {

        private static void clientprog() //client program
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

        private static void serverprog()//server program
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



        static void Main(string[] args)
        {
            bool runing = true;

            while (runing)
            {
                Console.WriteLine("\nChoose Program");
                Console.WriteLine("1 = Client program, 2 = Server Program, 3 = Exit");

                int select = int.Parse(Console.ReadLine());
                if (select == 1)
                {
                    clientprog();
                }

                else if (select == 2)
                {
                    serverprog();
                }

                else if (select == 3)
                {
                    runing = false;
                }
            }

        }
    }
}
