using System;
using System.Security.Cryptography;
using System.Text;

namespace MP09.UF01.P01.VisitaMedica.model.domain
{
    public class SHA256Security
    {
        public string Encripta(string valorOriginal)
        {
            string result = null;

            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(valorOriginal);
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);

                    result = Convert.ToBase64String(hashBytes);
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
