using System;
using System.Security.Cryptography;
using System.Text;

namespace Seterator.Utils
{
    class PasswordHasher
    {
        private HashAlgorithm hasher;
        private static PasswordHasher defaultImplementation = new PasswordHasher();

        public static PasswordHasher Default => defaultImplementation;

        public PasswordHasher()
        {
            hasher = SHA512.Create();
        }
        
        public byte[] Hash(string password)
        {
            var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hash;
        }
    }
}
