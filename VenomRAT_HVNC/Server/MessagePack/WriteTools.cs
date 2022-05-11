using System;
using System.IO;

namespace Server.MessagePack
{
    internal class WriteTools
    {
        public static void WriteNull(Stream ms)
        {
            ms.WriteByte(192);
        }

        public static void WriteString(Stream ms, string strVal)
        {
            byte[] utf8Bytes = BytesTools.GetUtf8Bytes(strVal);
            int num = utf8Bytes.Length;
            if (num <= 31)
            {
                int value = 160 + (byte)num;
                ms.WriteByte((byte)value);
            }
            else if (num <= 255)
            {
                byte value = 217;
                ms.WriteByte(value);
                value = (byte)num;
                ms.WriteByte(value);
            }
            else if (num <= 65535)
            {
                byte value = 218;
                ms.WriteByte(value);
                byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes((short)num));
                ms.Write(array, 0, array.Length);
            }
            else
            {
                byte value = 219;
                ms.WriteByte(value);
                byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes(num));
                ms.Write(array, 0, array.Length);
            }
            ms.Write(utf8Bytes, 0, utf8Bytes.Length);
        }

        public static void WriteBinary(Stream ms, byte[] rawBytes)
        {
            int num = rawBytes.Length;
            if (num <= 255)
            {
                byte value = 196;
                ms.WriteByte(value);
                value = (byte)num;
                ms.WriteByte(value);
            }
            else if (num <= 65535)
            {
                byte value = 197;
                ms.WriteByte(value);
                byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes((short)num));
                ms.Write(array, 0, array.Length);
            }
            else
            {
                byte value = 198;
                ms.WriteByte(value);
                byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes(num));
                ms.Write(array, 0, array.Length);
            }
            ms.Write(rawBytes, 0, rawBytes.Length);
        }

        public static void WriteFloat(Stream ms, double fVal)
        {
            ms.WriteByte(203);
            ms.Write(BytesTools.SwapDouble(fVal), 0, 8);
        }

        public static void WriteSingle(Stream ms, float fVal)
        {
            ms.WriteByte(202);
            ms.Write(BytesTools.SwapBytes(BitConverter.GetBytes(fVal)), 0, 4);
        }

        public static void WriteBoolean(Stream ms, bool bVal)
        {
            if (bVal)
            {
                ms.WriteByte(195);
                return;
            }
            ms.WriteByte(194);
        }

        public static void WriteUInt64(Stream ms, ulong iVal)
        {
            ms.WriteByte(207);
            byte[] bytes = BitConverter.GetBytes(iVal);
            ms.Write(BytesTools.SwapBytes(bytes), 0, 8);
        }

        public static void WriteInteger(Stream ms, long iVal)
        {
            if (iVal >= 0L)
            {
                if (iVal <= 127L)
                {
                    ms.WriteByte((byte)iVal);
                    return;
                }
                if (iVal <= 255L)
                {
                    ms.WriteByte(204);
                    ms.WriteByte((byte)iVal);
                    return;
                }
                if (iVal <= 65535L)
                {
                    ms.WriteByte(205);
                    ms.Write(BytesTools.SwapInt16((short)iVal), 0, 2);
                    return;
                }
                if (iVal <= (long)((ulong)(1)))
                {
                    ms.WriteByte(206);
                    ms.Write(BytesTools.SwapInt32((int)iVal), 0, 4);
                    return;
                }
                ms.WriteByte(211);
                ms.Write(BytesTools.SwapInt64(iVal), 0, 8);
                return;
            }
            else
            {
                if (iVal <= -2147483648L)
                {
                    ms.WriteByte(211);
                    ms.Write(BytesTools.SwapInt64(iVal), 0, 8);
                    return;
                }
                if (iVal <= -32768L)
                {
                    ms.WriteByte(210);
                    ms.Write(BytesTools.SwapInt32((int)iVal), 0, 4);
                    return;
                }
                if (iVal <= -128L)
                {
                    ms.WriteByte(209);
                    ms.Write(BytesTools.SwapInt16((short)iVal), 0, 2);
                    return;
                }
                if (iVal <= -32L)
                {
                    ms.WriteByte(208);
                    ms.WriteByte((byte)iVal);
                    return;
                }
                ms.WriteByte((byte)iVal);
                return;
            }
        }
    }
}
