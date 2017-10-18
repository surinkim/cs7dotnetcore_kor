using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Packt.CS7
{
    public static class Protector
    {
        // 권장되는 salt 크기는 최소한 8 바이트다. 여기서는 16 바이트를 사용한다.
        private static readonly byte[] salt =
          Encoding.Unicode.GetBytes("7BANANAS");

        // 권장되는 반복 횟수는 최소한 1000번이다. 여기서는 2000번 반복한다.
        private static readonly int iterations = 2000;

        public static string Encrypt(
          string plainText, string password)
        {
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(
              password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32); // 256 비트 키를 설정 
            aes.IV = pbkdf2.GetBytes(16); // 128 비트 IV를 설정 
            var ms = new MemoryStream();
            using (var cs = new CryptoStream(
              ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(
          string cryptoText, string password)
        {
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(
              password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            var ms = new MemoryStream();
            using (var cs = new CryptoStream(
              ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cryptoBytes, 0, cryptoBytes.Length);
            }
            return Encoding.Unicode.GetString(ms.ToArray());
        }

        private static Dictionary<string, User> Users = new Dictionary<string, User>();

        public static User Register(string username, string password)
        {
            // 랜덤 salt를 생성한다.
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            // salt를 사용하여 해시된 패스워드를 생성한다.
            var sha = SHA256.Create();
            var saltedPassword = password + saltText;
            var saltedhashedPassword = Convert.ToBase64String(
              sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));

            var user = new User
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedhashedPassword
            };
            Users.Add(user.Name, user);

            return user;
        }

        public static bool CheckPassword(string username, string password)
        {
            if (!Users.ContainsKey(username))
            {
                return false;
            }
            var user = Users[username];

            // salt를 사용하여 해시된 패스워드를 재생성한다.
            var sha = SHA256.Create();
            var saltedPassword = password + user.Salt;
            var saltedhashedPassword = Convert.ToBase64String(
              sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));

            return (saltedhashedPassword == user.SaltedHashedPassword);
        }

        public static string PublicKey;

        public static string ToXmlString(
          this RSA rsa, bool includePrivateParameters)
        {
            var p = rsa.ExportParameters(includePrivateParameters);
            XElement xml;
            if (includePrivateParameters)
            {
                xml = new XElement("RSAKeyValue"
                  , new XElement("Modulus", Convert.ToBase64String(p.Modulus))
                  , new XElement("Exponent",
                    Convert.ToBase64String(p.Exponent))
                  , new XElement("P", Convert.ToBase64String(p.P))
                  , new XElement("Q", Convert.ToBase64String(p.Q))
                  , new XElement("DP", Convert.ToBase64String(p.DP))
                  , new XElement("DQ", Convert.ToBase64String(p.DQ))
                  , new XElement("InverseQ",
                    Convert.ToBase64String(p.InverseQ))
                );
            }
            else
            {
                xml = new XElement("RSAKeyValue"
                  , new XElement("Modulus", Convert.ToBase64String(p.Modulus))
                  , new XElement("Exponent",
                    Convert.ToBase64String(p.Exponent))
                );
            }
            return xml?.ToString();
        }

        public static void FromXmlString(
          this RSA rsa, string parametersAsXml)
        {
            var xml = XDocument.Parse(parametersAsXml);
            var root = xml.Element("RSAKeyValue");
            var p = new RSAParameters
            {
                Modulus = Convert.FromBase64String(
                root.Element("Modulus").Value),
                Exponent = Convert.FromBase64String(
                root.Element("Exponent").Value)
            };
            if (root.Element("P") != null)
            {
                p.P = Convert.FromBase64String(root.Element("P").Value);
                p.Q = Convert.FromBase64String(root.Element("Q").Value);
                p.DP = Convert.FromBase64String(root.Element("DP").Value);
                p.DQ = Convert.FromBase64String(root.Element("DQ").Value);
                p.InverseQ = Convert.FromBase64String(
                  root.Element("InverseQ").Value);
            }
            rsa.ImportParameters(p);
        }

        public static string GenerateSignature(string data)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);

            var rsa = RSA.Create();
            //PublicKey = rsa.ToXmlString(false); // 개인키는 제외한다. 
            PublicKey = ToXmlString(rsa, false);


            return Convert.ToBase64String(rsa.SignHash(hashedData,
              HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        }

        public static bool ValidateSignature(
          string data, string signature)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);

            byte[] signatureBytes = Convert.FromBase64String(signature);

            var rsa = RSA.Create();
            //rsa.FromXmlString(PublicKey);
            FromXmlString(rsa, PublicKey);

            return rsa.VerifyHash(hashedData, signatureBytes,
              HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }


    }
}
