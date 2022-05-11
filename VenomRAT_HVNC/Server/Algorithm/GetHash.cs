using System;
using System.IO;
using System.Security.Cryptography;

namespace VenomRAT_HVNC.Server.Algorithm
{
    public static class GetHash
    {
        public static string GetChecksum(string file)
        {
            string result;
            using (FileStream fileStream = File.OpenRead(file))
            {
                SHA256Managed sha256Managed = new SHA256Managed();
                byte[] value = sha256Managed.ComputeHash(fileStream);
                result = BitConverter.ToString(value).Replace("-", string.Empty);
            }
            return result;
        }
    }
}
