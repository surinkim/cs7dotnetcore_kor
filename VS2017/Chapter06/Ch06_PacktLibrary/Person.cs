using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
    public partial class Person : object
    {
        // 필드 
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();

        public const string Species = "Homo Sapien";


        // 읽기 전용 필드
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        // 생성자 
        public Person()
        {
            // 읽기 전용 필드를 포함하여
            // 필드의 기본값을 설정한다.
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName)
        {
            Name = initialName;
            Instantiated = DateTime.Now;
        }

        // 메서드
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}";
        }

        // C# 4 및 닷넷 4.0의 System.Tuple 타입을 사용한 예
        public Tuple<string, int> GetFruitCS4()
        {
            return Tuple.Create("Apples", 5);
        }

        // C# 7이 지원하는 새로운 구문과 System.ValueTuple 타입을 사용한 예
        public (string, int) GetFruitCS7()
        {
            return ("Apples", 5);
        }

        public (string Name, int Number) GetNamedFruit()
        {
            return (Name: "Apples", Number: 5);
        }

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHelloTo(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }


    }

}
