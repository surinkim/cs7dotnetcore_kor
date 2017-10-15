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

        public string FavoriteIceCream { get; set; } // auto-syntax 

        private string favoritePrimaryColor;
        public string FavoritePrimaryColor
        {
            get
            {
                return favoritePrimaryColor;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException($"{value} is not a primary color.Choose from: red, green, blue."); 
                }
            }
        }

        // 인덱서 
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }

    }
}

