using System;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace HashPassword
{
	class Program
	{

         static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";

		static void Main(string[] args)
		{
			const int hashkey = 15;
			const string password = "Hello World";

			// var gen1 = BCrypt.Net.BCrypt.GenerateSalt(31);
			// var gen2 = BCrypt.Net.BCrypt.GenerateSalt();
			// var gen3 = BCrypt.Net.BCrypt.HashPassword(password);
			//var gen4 = BCrypt.Net.BCrypt.HashString(password);
			var gen5 = BCrypt.Net.BCrypt.HashString(password, hashkey);
			var gen6 = BCrypt.Net.BCrypt.Verify(password, gen5);
			//var gen6 = BCrypt.Net.BCrypt.HashString(password);

			//Console.WriteLine("Salt2 " +gen1 + "\nSalt1 " +gen2 );
			//	Console.WriteLine("Salt3 " +gen3 + "\nSalt4 " +gen4 );
			Console.WriteLine("Salt5 " + gen5);
			Console.WriteLine("\nSalt5 " + Encrypt(password));
			Console.WriteLine("\nSalt5 " + Encrypt(password));
			Console.WriteLine("\nSalt5 " + Encrypt(password));
            var ss = Encrypt(password);
			Console.WriteLine("\nSalt5 " + Decrypt(ss));

		}



		  public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
	}
}
