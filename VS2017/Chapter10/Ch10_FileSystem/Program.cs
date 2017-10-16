using System;
using static System.Console;
using System.IO;
using static System.IO.Directory;


namespace Ch10_FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // 디렉토리 경로를 정의한다.
            string dir = @"C:\Code\Ch10_Example"; // 윈도우 
            //string dir = @"/Users/markjprice/Code/Ch10_Example/"; // 맥OS

            // 디렉토리가 존재하는지 확인한다.
            WriteLine($"Does {dir} exist? {Exists(dir)}");
            // 디렉토리를 생성한다. 
            CreateDirectory(dir);
            WriteLine($"Does {dir} exist? {Exists(dir)}");
            // 디렉토리를 삭제한다.
            Delete(dir);
            WriteLine($"Does {dir} exist? {Exists(dir)}");

            string textFile = @"C:\Code\Ch10.txt"; // Windows 
            string backupFile = @"C:\Code\Ch10.bak"; // Windows 
            //string textFile = @"/Users/markjprice/Code/Ch10.txt"; // 맥OS 
            //string backupFile = @"/Users/markjprice/Code/Ch10.bak"; // 맥OS 

            // 파일이 존재하는지 확인한다. 
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // 파일을 생성하고 파일 안에 한 줄을 입력한다. 
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Dispose();
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // 파일을 복사하고 파일이 이미 존재한다면 덮어쓴다. 
            File.Copy(textFile, backupFile, true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            // 파일 삭제 
            File.Delete(textFile);
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // 텍스트 파일 읽기 
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Dispose();


            WriteLine($"File Name: {Path.GetFileName(textFile)}");
            WriteLine($"File Name without Extension:{ Path.GetFileNameWithoutExtension(textFile)}"); 
            WriteLine($"File Extension: {Path.GetExtension(textFile)}");
            WriteLine($"Random File Name: {Path.GetRandomFileName()}");
            WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

            //string backup = @"/Users/markjprice/Code/Ch10.bak"; // 맥OS 
            string backup = @"C:\Code\Ch10.bak"; // 윈도우 
            var info = new FileInfo(backup);
            WriteLine($"{backup} contains {info.Length} bytes.");
            WriteLine($"{backup} was last accessed {info.LastAccessTime}.");
            WriteLine($"{backup} has readonly set to {info.IsReadOnly}.");



        }
    }
}
