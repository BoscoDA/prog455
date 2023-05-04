using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utilities
{
    public static class HashUtil
    {

        public static string HashPassword(string password)
        {
            byte[] byteword = Encoding.Unicode.GetBytes(password);
            SHA512 sha512 = SHA512.Create();
            byteword = sha512.ComputeHash(byteword);

            StringBuilder result = new StringBuilder();
            foreach (byte b in byteword)
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }
    }
}
