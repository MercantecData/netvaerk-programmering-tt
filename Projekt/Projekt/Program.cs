using System;
using System.Text;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Network! \n solutions \nNo. 1 is assignments 1-4 \nNo. 2 is assignment 5");

            int userResponse = int.Parse(Console.ReadLine());
            switch (userResponse)
            {
                case 1:
                    Console.WriteLine("Hello Friend Write word to convert: ");
                    string text = Console.ReadLine();

                    Console.WriteLine("No. 1 = ascii \nNo. 2 = Utf8");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {

                        //Text oversat ved ascii opg 1-2
                        var bytes = Encoding.ASCII.GetBytes(text);

                        //Send over netværk
                        text = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine(text);

                    }

                    else if (input == 2)
                    {
                        //Text oversat med utf8 opg 3-4
                        var bytes = Encoding.UTF8.GetBytes(text);

                        //Send over netværk
                        text = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine(text);
                    }

                    else
                    {
                        Console.WriteLine("No can do");                     
                    } 
                    break;

                case 2:
                    //opg 5 byte array til string Decimal tal brugt til dette
                    Byte[] bytes2 = { 68, 97, 118, 101 };
                    string text2 = Encoding.UTF8.GetString(bytes2);
                    Console.WriteLine("\nbyte 68, 97, 118, 101 \nBecomes:");
                    Console.WriteLine(text2);
                    break;

                default:
                    Console.WriteLine("I'm sorry, I didn't understand that!");
                    break;
            }
           
            
        }
    }
}
