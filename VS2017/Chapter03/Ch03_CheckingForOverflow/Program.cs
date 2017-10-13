using System;
using static System.Console;

namespace Ch03_CheckingForOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 앞의 코드를 여기에 입력 한다.
                checked
                {
                    int x = int.MaxValue - 1;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                    x++;
                    WriteLine(x);
                }
            }
            catch (OverflowException)
            {
                WriteLine("오버플로우 예외가 발생했지만 여기서 처리했음.");
            }

            unchecked
            {
                int y = int.MaxValue + 1;
                WriteLine(y); // -2147483648을 출력한다.

                y--;

                WriteLine(y); // 2147483647을 출력한다.

                y--;

                WriteLine(y); // 2147483646을 출력한다.
            }

        }
    }
}
