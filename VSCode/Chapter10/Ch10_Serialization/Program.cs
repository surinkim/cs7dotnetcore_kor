using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static System.Console;
using Newtonsoft.Json;


namespace Ch10_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // 객체 그래프를 생성한다.
            var people = new List<Person>
            {
              new Person(30000M) { FirstName = "Alice", LastName = "Smith",
                DateOfBirth = new DateTime(1974, 3, 14) },
              new Person(40000M) { FirstName = "Bob", LastName = "Jones",
                DateOfBirth = new DateTime(1969, 11, 23) },
              new Person(20000M) { FirstName = "Charlie", LastName = "Rose",
                DateOfBirth = new DateTime(1964, 5, 4),
                Children = new HashSet<Person>
                { new Person(0M) { FirstName = "Sally", LastName = "Rose",
                DateOfBirth = new DateTime(1990, 7, 12) } } }
            };

            // 쓰기용 파일을 생성한다. 
            string xmlFilepath = @"/Users/hyun/Code/Ch10_People.xml";
            // string xmlFilepath = @"C:\Code\Ch10_People.xml"; // Windows 
            FileStream xmlStream = File.Create(xmlFilepath);

            // Person의 리스트를 XML로 형식화하는 객체를 생성한다.
            var xs = new XmlSerializer(typeof(List<Person>));

            // 스트림에 객체 그래프를 직렬화한다.
            xs.Serialize(xmlStream, people);

            // 파일 잠금을 해제하기 위해 스트림을 닫는다.
            xmlStream.Dispose();

            WriteLine($"Written {new FileInfo(xmlFilepath).Length} bytes of XML to { xmlFilepath}"); 
            WriteLine();

            // 직렬화된 객체 그래프를 출력한다.
            WriteLine(File.ReadAllText(xmlFilepath));

            FileStream xmlLoad = File.Open(xmlFilepath, FileMode.Open);
            // 직렬화 된 객체 그래플 person의 리스트로 역직렬화 한다.
            var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
            foreach (var item in loadedPeople)
            {
                WriteLine($"{item.LastName} has {item.Children.Count} children."); 
            }
            xmlLoad.Dispose();

            // 쓰기용 파일을 생성한다.
            string jsonFilepath = @"/Users/hyun/Code/Ch10_People.json";
            //string jsonFilepath = @"C:\Code\Ch10_People.json"; // Windows 
            StreamWriter jsonStream = File.CreateText(jsonFilepath);

            // JSON으로 형식화하는 객체를 생성한다.
            var jss = new JsonSerializer();

            // 객체 그래프를 string에 직렬화한다.
            jss.Serialize(jsonStream, people);

            // 파일 잠금을 해제하기 위해 stream을 닫는다.
            jsonStream.Dispose();

            WriteLine();
            WriteLine($"Written {new FileInfo(jsonFilepath).Length} bytes of JSON to: { jsonFilepath}"); 

            // 직렬화 된 객체 그래프를 출력한다.
            WriteLine(File.ReadAllText(jsonFilepath));


        }
    }
}
