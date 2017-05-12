using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CyberSeguranca
{
  public class Program
    {
        static void Main(string[] args)
        {
            string frase;
            //usuário digita uma frase
            Console.WriteLine("Digite uma frase");
            //aplicação lê esta frase
            frase = Console.ReadLine();
            //frase é criptografada pelo método GenerateSHA256String
            Console.WriteLine("sua frase" + GenerateSHA256String(frase));
            Console.WriteLine("sua frase 256 criptograda" + GenerateSHA512String(frase));
            Console.ReadKey();
        }
        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
       
    }
}

