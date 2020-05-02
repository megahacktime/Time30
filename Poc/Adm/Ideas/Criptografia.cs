using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Ideas
{
    public class Criptografia
    {
        private static readonly string SaltKey = "5a8be807"; // 8 digitos
        private static readonly string VIKey = "42f5684de0ff987c"; // 16 dígitos
        private static Dictionary<string, string> keys { get; set; }

        /// <summary>
        /// gera um MD5 para o input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string getMD5(string input)
        {
            string r = null;
            if (keys == null) keys = new Dictionary<string, string>();
            // se não contém
            if (!keys.ContainsKey(input))
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    r = sBuilder.ToString();
                }
                keys[input] = r;
            }
            else
            {
                r = keys[input];
            }
            return r;
        }

        public static string Encrypt(string input, string shaaredKey)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(input);
            
            byte[] keyBytes = new Rfc2898DeriveBytes(shaaredKey, Encoding.UTF8.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.UTF8.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedInput, string sharedKey)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedInput);
            byte[] keyBytes = new Rfc2898DeriveBytes(sharedKey, Encoding.UTF8.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.UTF8.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}
