using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Week5AuthenticationAuthorization.Utilities
{
    public class SHA256Util
    {
        public static string CreateHash(string password)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                var bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static bool VerifyPasswordWithHash(string input, string password)
        {
            if (CreateHash(input) == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}