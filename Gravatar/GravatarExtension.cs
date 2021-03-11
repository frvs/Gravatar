using System;
using System.Security.Cryptography;
using System.Text;

namespace Gravatar
{
    public static class GravatarExtension
    {
        public static string ToGravatar(this string email) 
        {
            if(string.IsNullOrEmpty(email))
                return string.Empty;

            using var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(email);
            var hashBytes = md5.ComputeHash(inputBytes);

            var stringBuilder = new StringBuilder();

            foreach (var hashByte in hashBytes)
            {
                stringBuilder.Append(hashByte.ToString("X2"));
            }

            return $"https://www.gravatar.com/avatar/{stringBuilder.ToString().ToLower()}";
        }
    }
}
