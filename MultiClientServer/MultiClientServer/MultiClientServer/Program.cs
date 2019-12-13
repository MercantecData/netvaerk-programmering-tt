using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace MultiClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MyServer();
            
        }
        /******Her dannes en liste til at indholde forskellige bruger der connecter******/
        public static List<TcpClient> clients = new List<TcpClient>();
        
        public static void MyServer()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");//Ip til connection skal kobles til den relevante på computeren
            int port = 13356;
            TcpListener listener = new TcpListener(ip, port);//laver en listener variable af data fra ip og port 
            listener.Start();

            AcceptClients(listener);

            /******Dette loop er til for at serveren kan skrive tilbage til klients******/
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("Write message: ");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);//Omdanner skrevet text til bytes

                /******Senderbesked skrevet på serveren ud til alle forbundet******/
                foreach (TcpClient client in clients)
                {
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
            }
        }

        /******Et loop der asynkront holder udkig efter nye klienter******/
        public static  async void AcceptClients(TcpListener listener)//listener funktion
        {
            bool isRunning = true;
            while(isRunning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();//listener er sat til at returnere klient ved connection
                clients.Add(client);//Klient tilføjet til clients listen
                NetworkStream stream = client.GetStream();//Modtager stream til f.eks. text
                ReceiveMessage(stream);
            }
        }

        /******Kode til at modtage text pakker fra klient******/
        public static async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];
            bool isRunning = true;
            while(isRunning)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                string text = Encoding.UTF8.GetString(buffer, 0, read);//Omdanner bytes til text
                Console.WriteLine("client writes: " + text);
                isRunning = false;
            }
        }
    }
}
