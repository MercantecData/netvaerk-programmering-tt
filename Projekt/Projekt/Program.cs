using System;
using System.Text;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Network!");
            string text = "Morgenmad er ånsvagt godt!";
            //Text oversat ved ascii
            //var bytes = Encoding.ASCII.GetBytes(text);
            
            //Text oversat med utf8
            var bytes = Encoding.UTF8.GetBytes(text);


            //Send over netværk
            text = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(text);

        }
    }
}
