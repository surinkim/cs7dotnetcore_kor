using System;
using static System.Console;

namespace Ch02_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88; // object에 double 타입의 값을 저장한다. 
            object name = "Amir"; // object에 string 타입의 값을 저장한다.
            //int length1 = name.Length; // 컴파일 에러 발생!
            int length2 = ((string)name).Length; // string 멤버 사용을 위해 명시적으로 타입을 변환한다.

            // dynamic 변수에 string 값을 저장한다.
            dynamic anotherName = "Ahmed";
            // 컴파일은 되지만 런타임에 예외를 발생시킬 수 있다.
            int length = anotherName.Length;

            var population = 66_000_000; // 영국 인구는 6600만이다. 
            var weight = 1.88; // 킬로그램 
            var price = 4.99M; // 파운드
            var fruit = "Apples"; // string은 큰 따옴표를 사용
            var letter = 'Z'; // char는 작은 따옴표를 사용
            var happy = true; // bool은 true나 false 값을 가짐.

            WriteLine($"{default(int)}"); // 0 
            WriteLine($"{default(bool)}"); // False 
            WriteLine($"{default(DateTime)}"); // 1/01/0001 00:00:00 

            int ICannotBeNull = 4;
            int? ICouldBeNull = null;
            WriteLine(ICouldBeNull.GetValueOrDefault()); // 0 
            ICouldBeNull = 4;
            WriteLine(ICouldBeNull.GetValueOrDefault()); // 4

            // ICouldBeNull 변수를 사용하기 전에 null이 아닌지 체크한다. 
            if (ICouldBeNull != null)
            {
                // ICouldBeNull 변수로 필요한 작업을 진행한다. 
            }

            string authorName = null;
            // 만약 authorName이 null이라도 예외를 던지지 않고 null을 반환한다.
            int? howManyLetters = authorName?.Length;

            // 만약 howManyLetters가 null이면 result 값은 3이다.
            var result = howManyLetters ?? 3;
            WriteLine(result);

            // 배열의 크기를 선언한다. 
            string[] names = new string[4];
            // 각 인덱스 위치에 사람 이름을 저장한다. 
            names[0] = "Kate";
            names[1] = "Jack";
            names[2] = "Rebecca";
            names[3] = "Tom";
            for (int i = 0; i < names.Length; i++)
            {
                WriteLine(names[i]); // 각 인덱스 위치에서 사람 이름을 읽고 출력한다.
            }

            WriteLine($"The UK population is {population}.");
            Write($"The UK population is {population:N0}. ");
            WriteLine($"{weight}kg of {fruit} costs {price:C}.");

            Write("Type your first name and press ENTER: ");
            string firstName = ReadLine();
            Write("Type your age and press ENTER: ");
            string age = ReadLine();
            WriteLine($"Hello {firstName}, you look good for {age}.");



        }
    }
}
