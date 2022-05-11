using System;
using System.Collections.Generic;

namespace VenomRAT_HVNC.Server.Helper.HexEditor
{
    public class ByteCollection
    {
        public int Length
        {
            get
            {
                return this._bytes.Count;
            }
        }

        public ByteCollection()
        {
            this._bytes = new List<byte>();
        }

        public ByteCollection(byte[] bytes)
        {
            this._bytes = new List<byte>(bytes);
        }

        public void Add(byte item)
        {
            this._bytes.Add(item);
        }

        public void Insert(int index, byte item)
        {
            this._bytes.Insert(index, item);
        }

        public void Remove(byte item)
        {
            this._bytes.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this._bytes.RemoveAt(index);
        }

        public void RemoveRange(int startIndex, int count)
        {
            this._bytes.RemoveRange(startIndex, count);
        }

        public byte GetAt(int index)
        {
            return this._bytes[index];
        }

        public void SetAt(int index, byte item)
        {
            this._bytes[index] = item;
        }

        public char GetCharAt(int index)
        {
            return Convert.ToChar(this._bytes[index]);
        }

        public byte[] ToArray()
        {
            return this._bytes.ToArray();
        }

        private List<byte> _bytes;
    }
}
