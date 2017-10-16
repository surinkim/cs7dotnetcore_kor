using System;
using System.Text;
using static System.Console;

namespace Ch10_Encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Encodings");
            WriteLine("[1] ASCII");
            WriteLine("[2] UTF-7");
            WriteLine("[3] UTF-8");
            WriteLine("[4] UTF-16 (Unicode)");
            WriteLine("[5] UTF-32");
            WriteLine("[any other key] Default");

            // 인코딩 방식을 선택한다. 
            Write("Press a number to choose an encoding: ");
            ConsoleKey number = ReadKey(false).Key;
            WriteLine();
            WriteLine();

            Encoding encoder;
            switch (number)
            {
                case ConsoleKey.D1:
                    encoder = Encoding.ASCII;
                    break;
                case ConsoleKey.D2:
                    encoder = Encoding.UTF7;
                    break;
                case ConsoleKey.D3:
                    encoder = Encoding.UTF8;
                    break;
                case ConsoleKey.D4:
                    encoder = Encoding.Unicode;
                    break;
                case ConsoleKey.D5:
                    encoder = Encoding.UTF32;
                    break;
                default:
                    encoder = Encoding.GetEncoding(0);
                    break;
            }

            // 인코딩 할 string을 정의한다.
            string message = "A pint of milk is £1.99";

            // string을 바이트 배열로 인코딩한다. 
            byte[] encoded = encoder.GetBytes(message);

            // 인코딩이 필요한 바이트 수를 확인한다.
            WriteLine($"{encoder.GetType().Name} uses {encoded.Length} bytes."); 
            
            // 루프를 돌면서 각 바이트를 출력한다. 
            WriteLine($"Byte  Hex  Char");
            foreach (byte b in encoded)
            {
                WriteLine($"{b,4} {b.ToString("X"),4} {(char)b,5}");
            }

            // 인코딩 된 바이트 배열을 다시 디코딩하여 출력한다.
            string decoded = encoder.GetString(encoded);
            WriteLine(decoded);

        }
    }
}
