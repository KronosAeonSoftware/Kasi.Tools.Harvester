using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kasi.Tools.Harvester.Domain.Utility
{
    public static class Encryption
    {
        public static string GetHash(string data)
        {
            var sha1 = SHA1CryptoServiceProvider.Create();
            var sb = new StringBuilder();

            sha1.ComputeHash(Encoding.UTF32.GetBytes(data.ToCharArray())).Select(x => x.ToString("X2")).ToList().ForEach(x => sb.Append(x));

            return sb.ToString();
        }
    }
}
