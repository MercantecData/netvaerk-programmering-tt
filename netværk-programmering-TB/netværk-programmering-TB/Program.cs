using System;
using System.Text;

namespace netværk_programmering_TB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            if (input == "1")
            {
                //Opg. 1-2
                var bytes = Encoding.ASCII.GetBytes(text);

                text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);
            }
            else if (input == "2")
            {
                //Opg. 3-4
                var bytes = Encoding.UTF8.GetBytes(text);

                text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);

            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }
           
        }
    }
}
