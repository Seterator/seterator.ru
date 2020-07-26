using System.Security.Cryptography;
using System.Text;
using System.Collections.Immutable;

namespace Seterator.Services
{
    public class HashService
    {
        private HashAlgorithm hasher;

        public HashService()
        {
            hasher = SHA512.Create();
        }
        
        public ImmutableArray<byte> Hash(string text, Encoding encoding)
        {
            byte[] hashArray = hasher.ComputeHash(encoding.GetBytes(text));
            return ImmutableArray.CreateRange(hashArray);
        }

        public ImmutableArray<byte> Hash(string utf8string) => Hash(utf8string, Encoding.UTF8);
    }
}
