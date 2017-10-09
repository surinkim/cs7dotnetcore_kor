using Packt.CS7;
using System;
//using System.Text;
using static System.Console;

namespace Ch06_PeopleApp
{
    class Program
    {


    static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.UTF8;


            var p1 = new Person();
            p1.Name = "Bob Smith";
            p1.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine($"{p1.Name} was born on {p1.DateOfBirth:dddd, d MMMM  yyyy}");

            var p2 = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 17)
            };
            WriteLine($"{p2.Name} was born on {p2.DateOfBirth:d MMM yy}");

            p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine($"{p1.Name}'s favourite wonder is { p1.FavouriteAncientWonder}");

            p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            // p1.BucketList = (WondersOfTheAncientWorld)18; 
            WriteLine($"{p1.Name}'s bucket list is {p1.BucketList}");

            p1.Children.Add(new Person());
            p1.Children.Add(new Person());
            WriteLine($"{p1.Name} has {p1.Children.Count} children.");

            BankAccount.InterestRate = 0.5M;

            var ba1 = new BankAccount();
            ba1.AccountName = "Mrs. Jones";
            ba1.Balance = 1000;
            WriteLine($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C} interest."); 

            var ba2 = new BankAccount();
            ba2.AccountName = "Ms. Gerrier"; 
            ba2.Balance = 900; 
            WriteLine($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C} interest.");

            WriteLine($"{p1.Name} is a {Person.Species}");

            WriteLine($"{p1.Name} was born on {p1.HomePlanet}");

            var p3 = new Person();
            WriteLine($"{p3.Name} was instantiated at {p3.Instantiated:hh:mm:ss} on { p3.Instantiated:dddd, d MMMM yyyy}");


            var p4 = new Person("Aziz");
            WriteLine($"{p4.Name} was instantiated at { p4.Instantiated:hh: mm: ss} on {p4.Instantiated:dddd, d MMMM yyyy}");

            p1.WriteToConsole();
            WriteLine(p1.GetOrigin());


            Tuple<string, int> fruit4 = p1.GetFruitCS4();
            WriteLine($"There are {fruit4.Item2} {fruit4.Item1}.");

            (string, int) fruit7 = p1.GetFruitCS7();
            WriteLine($"{fruit7.Item1}, {fruit7.Item2} there are.");

            var fruitNamed = p1.GetNamedFruit();
            WriteLine($"Are there {fruitNamed.Number} {fruitNamed.Name}?");


            (string fruitName, int fruitNumber) = p1.GetFruitCS7();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");


            WriteLine(p1.SayHello());
            WriteLine(p1.SayHelloTo("Emily"));

            var max = new Person
            {
                Name = "Max",
                DateOfBirth = new DateTime(1972, 1, 27)
            };
            WriteLine(max.Origin);
            WriteLine(max.Greeting);
            WriteLine(max.Age);


        }
    }
}
