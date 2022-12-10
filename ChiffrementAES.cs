using System.Security.Cryptography;
using System.Text;

namespace ouaiouai
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            string key = "MySuperKeyTopSecretToSecurMyData"; // 32 char minimal for AES key 
            string plainText = "This is the plain text to be encrypted.";

            string encrypted = Encrypt(plainText, key);
            string decrypted = Decrypt(encrypted, key);

            Console.WriteLine("Plain text: {0}", plainText);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);
        }

        static string Encrypt(string data, string key)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using (Aes encryptor = Aes.Create())
            {
                encryptor.Mode = CipherMode.ECB;
                encryptor.Key = keyBytes;

                ICryptoTransform encryptorTransform = encryptor.CreateEncryptor();

                byte[] encryptedData = encryptorTransform.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

                return Convert.ToBase64String(encryptedData);
            }
        }

        static string Decrypt(string data, string key)
        {
            byte[] dataBytes = Convert.FromBase64String(data);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            using (Aes encryptor = Aes.Create())
            {
                encryptor.Mode = CipherMode.ECB;
                encryptor.Key = keyBytes;

                ICryptoTransform decryptorTransform = encryptor.CreateDecryptor();

                byte[] decryptedData = decryptorTransform.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
        }
    }
}