using System.Security.Cryptography;
using System.Text;

namespace Microservice.Core.Utils
{
    public static class CryptographyUtils
    {
        public static string HashPassword(string password)
        {
            using (var mySHA256 = SHA256.Create())
            {
                var hash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));

                var hashSB = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                    hashSB.Append(i.ToString("x2"));
                return hashSB.ToString();
            }
        }
    }
}