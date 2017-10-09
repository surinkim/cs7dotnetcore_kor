using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.CS7
{
    public partial class Person
    {
        // C# 1 – 5의 구문을 사용하여 속성을 정의한다.
        public string Origin
        {
            get
            {
                //C# 6부터 지원하는 문자열 보간 구문
                return $"{Name} was born on {HomePlanet}";
            }
        }


        //C# 6 이후의 람다 표현식을 사용한 두 번째 속성 정의.
        public string Greeting => $"{Name} says 'Hello!'";

        public int Age => (int)(System.DateTime.Today
          .Subtract(DateOfBirth).TotalDays / 365.25);

    }
}

