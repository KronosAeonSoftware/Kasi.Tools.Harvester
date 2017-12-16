using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kasi.Tools.Harvester.Domain.Utility
{
    public static class Encryption
    {
        public static string GetHash(string data)
        {
            var sha1 = SHA1CryptoServiceProvider.Create();

            return Encoding.UTF32.GetString(sha1.ComputeHash(Encoding.UTF32.GetBytes(data.ToCharArray())));
        }
    }
}
