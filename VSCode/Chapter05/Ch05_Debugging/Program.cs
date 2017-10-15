using System;
using static System.Console;

namespace Ch05_Debugging
{
    class Program
    {
        static double Add(double a, double b)
        {
            return a + b; // 의도적으로 버그를 만들었다.
        }

        static void Main(string[] args)
        {
            double a = 4.5; // var를 사용해도 좋다.
            double b = 2.5;
            double answer = Add(a, b);
            WriteLine($"{a} + {b} = {answer}");
            ReadLine(); //사용자가 ENTER를 누를 때까지 대기한다.
        }
    }
}
