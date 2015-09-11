using System.Text;
using System.Security.Cryptography;
using System;

namespace EFRepository.Extension
{
    public static class DataEncrypt
    {
        public static string Encrypt(this string text)
        {
            SHA512Managed sha512 = new SHA512Managed();
            sha512.Initialize();
            return Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(text)));
        }
    }
}