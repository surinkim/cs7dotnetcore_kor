using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
    public partial class Person : IComparable<Person>
    {
        // 필드
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        // 메서드
        public void WriteToConsole()
        {
            WriteLine(
              $"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
        }

        // 출산 역할을 하는 메서드 
        public Person Procreate(Person partner)
        {
            var baby = new Person
            {
                Name = $"Baby of {this.Name} and {partner.Name}"
            };
            this.Children.Add(baby);
            partner.Children.Add(baby);
            return baby;
        }

        // 곱셈 역할을 하는 연산자 
        public static Person operator *(Person p1, Person p2)
        {
            return p1.Procreate(p2);
        }

        // Factorial 메서드 내부에 localFactorial 지역 메서드를 구현했다.
        public int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(
                  $"{nameof(number)} cannot be less than zero.");
            }

            int localFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }

            return localFactorial(number);
        }

        // 이벤트 
        public event EventHandler Shout;

        // 필드 
        public int AngerLevel;

        // 메서드 
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // Shout 이벤트에 대한 핸들러가 정의되어 있다면... 
                if (Shout != null)
                {
                    // ...이벤트를 발생시킨다. 
                    Shout(this, EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        // 메서드 오버라이드 
        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birth then the universe will explode!"); 
            }
            else
            {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }


    }



}
