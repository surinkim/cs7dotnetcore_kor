using System;
using System.IO;
using System.Xml;
using static System.Console;
using System.IO.Compression;

namespace Ch10_Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            // string 배열을 정의한다.
            string[] callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };

            // 텍스트 쓰기 헬퍼를 사용하여 쓸 파일을 정의한다.
            string textFile = @"/Users/hyun/Code/Ch10_Streams.txt";
            //string textFile = @"C:\Code\Ch10_Streams.txt"; // 윈도우 
            StreamWriter text = File.CreateText(textFile);

            // string 배열의 각 항목을 스트림에 쓴다.
            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Dispose(); // 스트림을 닫는다. 

            // 파일의 내용을 콘솔에 출력한다.
            WriteLine($"{textFile} contains {new FileInfo(textFile).Length} bytes."); 
            WriteLine(File.ReadAllText(textFile));

            // XML 쓰기 헬퍼를 사용하여 쓸 파일을 정의한다.
            string xmlFile = @"/Users/hyun/Code/Ch10_Streams.xml";
            //string xmlFile = @"C:\Code\Ch10_Streams.xml"; 

            FileStream xmlFileStream = File.Create(xmlFile);
            XmlWriter xml = XmlWriter.Create(xmlFileStream,
              new XmlWriterSettings { Indent = true });

            // 파일에 XML 선언부를 쓴다.
            xml.WriteStartDocument();

            // root 엘리먼트를 쓴다.
            xml.WriteStartElement("callsigns");

            // string 배열의 각 항목을 스트림에 쓴다.
            foreach (string item in callsigns)
            {
                xml.WriteElementString("callsign", item);
            }

            // root 엘리먼트를 닫는다.
            xml.WriteEndElement();
            xml.Dispose();
            xmlFileStream.Dispose();

            // 파일의 내용을 콘솔에 출력한다.
            WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes."); 
            WriteLine(File.ReadAllText(xmlFile));


            // XML 출력을 압축한다.
            string gzipFilePath = @"/Users/hyun/Code/Ch10.gzip";
            //string gzipFilePath = @"C:\Code\Ch10.gzip"; // 윈도우 

            FileStream gzipFile = File.Create(gzipFilePath);
            GZipStream compressor = new GZipStream(gzipFile,
            CompressionMode.Compress);
            XmlWriter xmlGzip = XmlWriter.Create(compressor);
            xmlGzip.WriteStartDocument();
            xmlGzip.WriteStartElement("callsigns");
            foreach (string item in callsigns)
            {
                xmlGzip.WriteElementString("callsign", item);
            }
            xmlGzip.Dispose();
            compressor.Dispose(); // also closes the underlying stream 

            // 압축 파일의 내용을 콘솔에 출력한다.
            WriteLine($"{gzipFilePath} contains {new FileInfo(gzipFilePath).Length} bytes."); 
            WriteLine(File.ReadAllText(gzipFilePath));

            // 압축 파일을 읽는다. 
            WriteLine("Reading the compressed XML file:");
                    gzipFile = File.Open(gzipFilePath, FileMode.Open); 
            GZipStream decompressor = new GZipStream(gzipFile,
            CompressionMode.Decompress);
                    XmlReader reader = XmlReader.Create(decompressor); 
            while (reader.Read()) 
            { 
            // callsign 엘리먼트인지 확인한다.
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign")) 
              { 
                reader.Read(); // 엘리먼트 안의 텍스트 노드로 이동한다. 
                WriteLine($"{reader.Value}"); // 값을 읽는다. 
                }
            }
            reader.Dispose(); 
            decompressor.Dispose();
        }
    }
}
