using System;
using static System.Console;
using Packt.CS7;


namespace Ch11_SigningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter some text to sign: ");
            string data = ReadLine();
            var signature = Protector.GenerateSignature(data);
            WriteLine($"Signature: {signature}");
            WriteLine("Public key used to check signature:");
            WriteLine(Protector.PublicKey);

            if (Protector.ValidateSignature(data, signature))
            {
                WriteLine("Correct! Signature is valid.");
            }
            else
            {
                WriteLine("Invalid signature.");
            }

            // 첫 번째 문자를 X로 바꿔서 잘못된 서명을 만든다.
            var fakeSignature = signature.Replace(signature[0], 'X');
            if (Protector.ValidateSignature(data, fakeSignature))
            {
                WriteLine("Correct! Signature is valid.");
            }
            else
            {
                WriteLine($"Invalid signature: {fakeSignature}");
            }

        }
    }
}
