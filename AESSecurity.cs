using System;
using System.Security.Cryptography;
using System.Text;

namespace MP09.UF01.P01.VisitaMedica.model.domain
{
    public class AESSecurity
    {
        private readonly string ENCRYPT_KEY = "clave-32-chars__________________";
        private readonly string ENCRYPT_ALGORITHM = "AES";

        public string Encripta(string valorOriginal)
        {
            string result = null;

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(ENCRYPT_KEY);
                    aesAlg.Mode = CipherMode.ECB;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    byte[] encrypted = null;

                    using (var msEncrypt = new System.IO.MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(valorOriginal);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }

                    result = Convert.ToBase64String(encrypted);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public string Desencripta(string encrypted)
        {
            string result = null;

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(ENCRYPT_KEY);
                    aesAlg.Mode = CipherMode.ECB;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    byte[] cipherText = Convert.FromBase64String(encrypted);

                    using (var msDecrypt = new System.IO.MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}

