using System;
using System.Text;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Network! \nWrite word: ");
            string text = Console.ReadLine();

            Console.WriteLine("No. 1 = ascii \nNo. 2 = Utf8");
            int input=int.Parse(Console.ReadLine());
            if (input == 1) {

                //Text oversat ved ascii opg 1-2
                var bytes = Encoding.ASCII.GetBytes(text);

                //Send over netværk
                text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);

            }

            else if (input == 2) {
                //Text oversat med utf8 opg 3-4
                var bytes = Encoding.UTF8.GetBytes(text);

                //Send over netværk
                text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);
            }

            else { Console.WriteLine("No can do"); }

            //opg 5
            //UTF8Encoding[] bytes2 = {68, 97, 118};

        }
    }
}
