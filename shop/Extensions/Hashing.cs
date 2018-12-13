using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace shop.Extensions
{
    public static class Hashing
    {
        public static string Hash(this string password)
        {
            return Convert.ToBase64String(
                SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(password))
                );
        }
    }
}
