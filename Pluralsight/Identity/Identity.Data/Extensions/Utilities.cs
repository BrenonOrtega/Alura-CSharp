using System;
using System.Security.Cryptography;
using System.Text;

namespace Identity.Data.Extensions
{
    public static class Utilities
    {
        public static string GetSha256(this string encript)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.ASCII.GetBytes(encript);
            var hashValue = sha.ComputeHash(bytes);

            return Encoding.ASCII.GetString(hashValue);
        }
    }
}