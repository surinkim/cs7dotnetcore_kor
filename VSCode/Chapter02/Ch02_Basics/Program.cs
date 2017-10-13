using System;
using System.Linq;
using System.Reflection;


namespace Ch02_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Xml.XmlReader reader;
            System.Xml.Linq.XElement element;
            System.Net.Http.HttpClient client;

            // 이 프로그램이 참조하는 어셈블리를 순회한다.
            foreach (var r in Assembly.GetEntryAssembly()
              .GetReferencedAssemblies())
            {
                // 세부 정보를 읽기 위해 어셈블리를 로드한다. 
                var a = Assembly.Load(new AssemblyName(r.FullName));
                // 전체 메서드 count를 저장할 변수를 선언한다.
                int methodCount = 0;
                // 어셈블리의 모든 유형을 순회한다.
                foreach (var t in a.DefinedTypes)
                {
                    // 메서드의 개수를 더해서 누적한다.
                    methodCount += t.GetMethods().Count();
                }
                // 타입과 메서드의 개수를 출력한다. 
                Console.WriteLine($"{a.DefinedTypes.Count():N0} types " + $"with {methodCount:N0} methods in {r.Name} assembly.");
            }

        }
    }
}
