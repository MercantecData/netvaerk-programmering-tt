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
                Console.WriteLine("");

            }
            else if (input == "2")
            {
                //Opg. 3-4
                var bytes = Encoding.UTF8.GetBytes(text);

                text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);
                Console.WriteLine("");

            }
            else
            {
                Console.WriteLine("Invalid Input!");
                Console.WriteLine("");
            }

            //Opg. 5
            Byte[] bytesArrayToStringConverterThingThatHopefullyWorksLikeItIsProgrammedToDo = { 83, 85, 67, 67, 32, 77, 89, 32, 65, 83, 83, 44, 32, 76, 79, 76 };
            string byteConvertText = Encoding.UTF8.GetString(bytesArrayToStringConverterThingThatHopefullyWorksLikeItIsProgrammedToDo);
            Console.WriteLine(byteConvertText);
           
        }
    }
}
