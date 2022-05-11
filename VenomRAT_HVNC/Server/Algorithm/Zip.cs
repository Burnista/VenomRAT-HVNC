using System;
using System.IO;
using System.IO.Compression;

namespace VenomRAT_HVNC.Server.Algorithm
{
    public static class Zip
    {
        public static byte[] Decompress(byte[] input)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(input))
            {
                byte[] array = new byte[4];
                memoryStream.Read(array, 0, 4);
                int num = BitConverter.ToInt32(array, 0);
                using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    byte[] array2 = new byte[num];
                    gzipStream.Read(array2, 0, num);
                    result = array2;
                }
            }
            return result;
        }

        public static byte[] Compress(byte[] input)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] bytes = BitConverter.GetBytes(input.Length);
                memoryStream.Write(bytes, 0, 4);
                using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(input, 0, input.Length);
                    gzipStream.Flush();
                }
                result = memoryStream.ToArray();
            }
            return result;
        }
    }
}
