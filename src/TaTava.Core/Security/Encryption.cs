using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;

namespace TaTava.Core.Security
{
    public class Encryption : IEncryption
    {
        private byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    var toEncrypt = Encoding.Unicode.GetBytes(data);
                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }

        private string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            using (var memoryStream = new MemoryStream(data))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream, Encoding.Unicode))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }

        public string EncryptText(string text, string privateKey = "")
        {
            //TODO: privateKey değişmesi gerek.
            if (string.IsNullOrEmpty(text) || text == "null")
                return string.Empty;

            if (string.IsNullOrEmpty(privateKey))
                privateKey = "privateKeyDegistirilmelidir";

            using (var provider = new TripleDESCryptoServiceProvider())
            {
                provider.Key = Encoding.ASCII.GetBytes(privateKey.Substring(0, 16));
                provider.IV = Encoding.ASCII.GetBytes(privateKey.Substring(8, 8));

                var encryptedBinary = EncryptTextToMemory(text, provider.Key, provider.IV);
                return Convert.ToBase64String(encryptedBinary);
            }
        }

        //Example Password: 123456 ==> MTIzNDU2
        public string DecryptText(string text, string privateKey = "")
        {
            try
            {
                if (string.IsNullOrEmpty(text) || text == "null")
                    return string.Empty;

                //TODO: Buraya Appconfig'den gelen değer konulacak.
                if (string.IsNullOrEmpty(privateKey))
                    privateKey = "privateKeyDegistirilmelidir";

                using (var provider = new TripleDESCryptoServiceProvider())
                {
                    provider.Key = Encoding.ASCII.GetBytes(privateKey.Substring(0, 16));
                    provider.IV = Encoding.ASCII.GetBytes(privateKey.Substring(8, 8));

                    var buffer = Convert.FromBase64String(text);
                    return DecryptTextFromMemory(buffer, provider.Key, provider.IV);
                }
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }
    }
}