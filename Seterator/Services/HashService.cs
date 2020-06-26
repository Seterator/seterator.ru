using System.Security.Cryptography;
using System.Text;
using System.Collections.Immutable;
using System.Collections.Generic;

namespace Seterator.Services
{
    public class HashService
    {
        private HashAlgorithm hasher;

        public HashService()
        {
            hasher = SHA512.Create();
        }
        
        public IReadOnlyCollection<byte> Hash(string text, Encoding encoding)
        {
            byte[] hashArray = hasher.ComputeHash(encoding.GetBytes(text));
            var builder = ImmutableList.CreateBuilder<byte>();
            builder.AddRange(hashArray);
            return builder.ToImmutableList();
        }

        public IReadOnlyCollection<byte> Hash(string utf8string) => Hash(utf8string, Encoding.UTF8);
    }
}
