using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CalvinProject.Helpers
{
    public class PasswordManager
    {
        private const int nBytes = 128;
        private byte[] GetSalt(IConfiguration configuration)
        {
            return Encoding.ASCII.GetBytes(configuration.GetSection("key").GetSection("passcode").Value);
        }

        public string HashPassword(IConfiguration configuration, string password)
        {
            var saltBytes = GetSalt(configuration);
            var passwordBytes = Encoding.ASCII.GetBytes(password);

            var completePassword = passwordBytes.Concat(saltBytes).ToArray();
            using (HashAlgorithm hashAlg = new SHA256CryptoServiceProvider())
            {
                return Convert.ToBase64String(hashAlg.ComputeHash(completePassword));
            }
            //using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes))
            //{
            //    return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes());
            //}
        }
    }

}
