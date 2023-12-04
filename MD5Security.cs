using System;
using System.Security.Cryptography;
using System.Text;

namespace MP09.UF01.P01.VisitaMedica.model.domain
{
    public class MD5Security
    {
        public string Encripta(string valorOriginal)
        {
            string result = null;

            try
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(valorOriginal);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

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
