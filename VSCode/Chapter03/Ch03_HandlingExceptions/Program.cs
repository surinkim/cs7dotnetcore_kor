using System.IO;
using System;
using static System.Console;

namespace Ch03_HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Before parsing");
            Write("What is your age? ");
            string input = Console.ReadLine();
            try
            {
                int age = int.Parse(input);
                WriteLine($"You are {age} years old.");
            }
            catch (OverflowException)
            {
                WriteLine("Your age is a valid number format but it is either too big or small.");
            }
            catch (FormatException)
            {
                WriteLine("The age you entered is not a valid number format.");
            }
            catch (Exception ex)
            {

                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            WriteLine("After parsing");


            string path = "/Users/hyun/Code/Chapter03"; // macOS 
            //string path = @"C:\Code\Chapter03"; // Windows 

            FileStream file = null;
            StreamWriter writer = null;
            try
            {

                if (Directory.Exists(path))
                {
                    file = File.OpenWrite(Path.Combine(path, "file.txt"));
                    writer = new StreamWriter(file);
                    writer.WriteLine("Hello, C#!");
                }
                else
                {
                    WriteLine($"{path} does not exist!");
                }
            }
            catch (Exception ex)
            {
                // 예외가 발생하면 여기서 처리된다. 
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                    WriteLine("The writer's unmanaged resources have been disposed.");
                }
                if (file != null)
                {
                    file.Dispose();
                    WriteLine("The file's unmanaged resources have been disposed.");
                }
            }

            using (FileStream file2 = File.OpenWrite(Path.Combine(path, "file2.txt")))
            {
                using (StreamWriter writer2 = new StreamWriter(file2))
                {
                    try
                    {
                        writer2.WriteLine("Welcome, .NET Core!");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{ex.GetType()} says {ex.Message}");
                    }
                } // writer2가 null이 아니면 자동으로 Dispose가 호출된다. 
            } // file2가 null이 아니면 자동으로 Dispose가 호출된다. 
        }
    }
}
