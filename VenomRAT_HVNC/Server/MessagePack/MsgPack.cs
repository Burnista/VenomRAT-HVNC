using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VenomRAT_HVNC.Server.Algorithm;

namespace Server.MessagePack
{
    public class MsgPack : IEnumerable
    {
        private void SetName(string value)
        {
            this.name = value;
            this.lowerName = this.name.ToLower();
        }

        private void Clear()
        {
            for (int i = 0; i < this.children.Count; i++)
            {
                this.children[i].Clear();
            }
            this.children.Clear();
        }

        private MsgPack InnerAdd()
        {
            MsgPack msgPack = new MsgPack();
            msgPack.parent = this;
            this.children.Add(msgPack);
            return msgPack;
        }

        private int IndexOf(string name)
        {
            int num = -1;
            int result = -1;
            string text = name.ToLower();
            foreach (MsgPack msgPack in this.children)
            {
                num++;
                if (text.Equals(msgPack.lowerName))
                {
                    result = num;
                    break;
                }
            }
            return result;
        }

        public MsgPack FindObject(string name)
        {
            int num = this.IndexOf(name);
            if (num == -1)
            {
                return null;
            }
            return this.children[num];
        }

        private MsgPack InnerAddMapChild()
        {
            if (this.valueType != MsgPackType.Map)
            {
                this.Clear();
                this.valueType = MsgPackType.Map;
            }
            return this.InnerAdd();
        }

        private MsgPack InnerAddArrayChild()
        {
            if (this.valueType != MsgPackType.Array)
            {
                this.Clear();
                this.valueType = MsgPackType.Array;
            }
            return this.InnerAdd();
        }

        public MsgPack AddArrayChild()
        {
            return this.InnerAddArrayChild();
        }

        private void WriteMap(Stream ms)
        {
            int count = this.children.Count;
            if (count <= 15)
            {
                int value = 128 + (byte)count;
                ms.WriteByte((byte)value);
            }
            else if (count <= 65535)
            {
                byte value = 222;
                ms.WriteByte(value);
                byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes((short)count));
                ms.Write(array, 0, array.Length);
            }
            else
            {
                byte value = 223;
                ms.WriteByte(value);
                byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes(count));
                ms.Write(array, 0, array.Length);
            }
            for (int i = 0; i < count; i++)
            {
                WriteTools.WriteString(ms, this.children[i].name);
                this.children[i].Encode2Stream(ms);
            }
        }

        private void WirteArray(Stream ms)
        {
            int count = this.children.Count;
            if (count <= 15)
            {
                int value = 144 + (byte)count;
                ms.WriteByte((byte)value);
            }
            else if (count <= 65535)
            {
                byte value = 220;
                ms.WriteByte(value);
                byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes((short)count));
                ms.Write(array, 0, array.Length);
            }
            else
            {
                byte value = 221;
                ms.WriteByte(value);
                byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes(count));
                ms.Write(array, 0, array.Length);
            }
            for (int i = 0; i < count; i++)
            {
                this.children[i].Encode2Stream(ms);
            }
        }

        public void SetAsInteger(long value)
        {
            this.innerValue = value;
            this.valueType = MsgPackType.Integer;
        }

        public void SetAsUInt64(ulong value)
        {
            this.innerValue = value;
            this.valueType = MsgPackType.UInt64;
        }

        public ulong GetAsUInt64()
        {
            switch (this.valueType)
            {
                case MsgPackType.String:
                    return ulong.Parse(this.innerValue.ToString().Trim());

                case MsgPackType.Integer:
                    return Convert.ToUInt64((long)this.innerValue);

                case MsgPackType.UInt64:
                    return (ulong)this.innerValue;

                case MsgPackType.Float:
                    return Convert.ToUInt64((double)this.innerValue);

                case MsgPackType.Single:
                    return Convert.ToUInt64((float)this.innerValue);

                case MsgPackType.DateTime:
                    return Convert.ToUInt64((DateTime)this.innerValue);
            }
            return 0UL;
        }

        public long GetAsInteger()
        {
            switch (this.valueType)
            {
                case MsgPackType.String:
                    return long.Parse(this.innerValue.ToString().Trim());

                case MsgPackType.Integer:
                    return (long)this.innerValue;

                case MsgPackType.UInt64:
                    return Convert.ToInt64((long)this.innerValue);

                case MsgPackType.Float:
                    return Convert.ToInt64((double)this.innerValue);

                case MsgPackType.Single:
                    return Convert.ToInt64((float)this.innerValue);

                case MsgPackType.DateTime:
                    return Convert.ToInt64((DateTime)this.innerValue);
            }
            return 0L;
        }

        public double GetAsFloat()
        {
            switch (this.valueType)
            {
                case MsgPackType.String:
                    return double.Parse((string)this.innerValue);

                case MsgPackType.Integer:
                    return Convert.ToDouble((long)this.innerValue);

                case MsgPackType.Float:
                    return (double)this.innerValue;

                case MsgPackType.Single:
                    return (double)((float)this.innerValue);

                case MsgPackType.DateTime:
                    return (double)Convert.ToInt64((DateTime)this.innerValue);
            }
            return 0.0;
        }

        public void SetAsBytes(byte[] value)
        {
            this.innerValue = value;
            this.valueType = MsgPackType.Binary;
        }

        public byte[] GetAsBytes()
        {
            switch (this.valueType)
            {
                case MsgPackType.String:
                    return BytesTools.GetUtf8Bytes(this.innerValue.ToString());

                case MsgPackType.Integer:
                    return BitConverter.GetBytes((long)this.innerValue);

                case MsgPackType.Float:
                    return BitConverter.GetBytes((double)this.innerValue);

                case MsgPackType.Single:
                    return BitConverter.GetBytes((float)this.innerValue);

                case MsgPackType.DateTime:
                    {
                        long value = ((DateTime)this.innerValue).ToBinary();
                        return BitConverter.GetBytes(value);
                    }
                case MsgPackType.Binary:
                    return (byte[])this.innerValue;
            }
            return new byte[0];
        }

        public void Add(string key, string value)
        {
            MsgPack msgPack = this.InnerAddArrayChild();
            msgPack.name = key;
            msgPack.SetAsString(value);
        }

        public void Add(string key, int value)
        {
            MsgPack msgPack = this.InnerAddArrayChild();
            msgPack.name = key;
            msgPack.SetAsInteger((long)value);
        }

        public async Task<bool> LoadFileAsBytes(string fileName)
        {
            bool result;
            if (File.Exists(fileName))
            {
                byte[] value = null;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                value = new byte[fs.Length];
                await fs.ReadAsync(value, 0, (int)fs.Length);
                await fs.FlushAsync();
                fs.Close();
                fs.Dispose();
                this.SetAsBytes(value);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> SaveBytesToFile(string fileName)
        {
            bool result;
            if (this.innerValue != null)
            {
                FileStream fs = new FileStream(fileName, FileMode.Append);
                await fs.WriteAsync((byte[])this.innerValue, 0, ((byte[])this.innerValue).Length);
                await fs.FlushAsync();
                fs.Close();
                fs.Dispose();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public MsgPack ForcePathObject(string path)
        {
            MsgPack msgPack = this;
            string[] array = path.Trim().Split(new char[] { '.', '/', '\\' });
            if (array.Length == 0)
            {
                return null;
            }
            string text;
            if (array.Length > 1)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    text = array[i];
                    MsgPack msgPack2 = msgPack.FindObject(text);
                    if (msgPack2 == null)
                    {
                        msgPack = msgPack.InnerAddMapChild();
                        msgPack.SetName(text);
                    }
                    else
                    {
                        msgPack = msgPack2;
                    }
                }
            }
            text = array[array.Length - 1];
            int num = msgPack.IndexOf(text);
            if (num > -1)
            {
                return msgPack.children[num];
            }
            msgPack = msgPack.InnerAddMapChild();
            msgPack.SetName(text);
            return msgPack;
        }

        public void SetAsNull()
        {
            this.Clear();
            this.innerValue = null;
            this.valueType = MsgPackType.Null;
        }

        public void SetAsString(string value)
        {
            this.innerValue = value;
            this.valueType = MsgPackType.String;
        }

        public string GetAsString()
        {
            if (this.innerValue == null)
            {
                return "";
            }
            return this.innerValue.ToString();
        }

        public void SetAsBoolean(bool bVal)
        {
            this.valueType = MsgPackType.Boolean;
            this.innerValue = bVal;
        }

        public void SetAsSingle(float fVal)
        {
            this.valueType = MsgPackType.Single;
            this.innerValue = fVal;
        }

        public void SetAsFloat(double fVal)
        {
            this.valueType = MsgPackType.Float;
            this.innerValue = fVal;
        }

        public void DecodeFromBytes(byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bytes = Zip.Decompress(bytes);
                memoryStream.Write(bytes, 0, bytes.Length);
                memoryStream.Position = 0L;
                this.DecodeFromStream(memoryStream);
            }
        }

        public void DecodeFromFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            this.DecodeFromStream(fileStream);
            fileStream.Dispose();
        }

        public void DecodeFromStream(Stream ms)
        {
            byte b = (byte)ms.ReadByte();
            if (b <= 127)
            {
                this.SetAsInteger((long)((ulong)b));
                return;
            }
            if (b >= 128 && b <= 143)
            {
                this.Clear();
                this.valueType = MsgPackType.Map;
                int num = (int)(b - 128);
                for (int i = 0; i < num; i++)
                {
                    MsgPack msgPack = this.InnerAdd();
                    msgPack.SetName(ReadTools.ReadString(ms));
                    msgPack.DecodeFromStream(ms);
                }
                return;
            }
            if (b >= 144 && b <= 159)
            {
                this.Clear();
                this.valueType = MsgPackType.Array;
                int num = (int)(b - 144);
                for (int i = 0; i < num; i++)
                {
                    MsgPack msgPack = this.InnerAdd();
                    msgPack.DecodeFromStream(ms);
                }
                return;
            }
            if (b >= 160 && b <= 191)
            {
                int num = (int)(b - 160);
                this.SetAsString(ReadTools.ReadString(ms, num));
                return;
            }
            if (b >= 224 && b <= 255)
            {
                this.SetAsInteger((long)((sbyte)b));
                return;
            }
            if (b == 192)
            {
                this.SetAsNull();
                return;
            }
            if (b == 193)
            {
                throw new Exception("(never used) type $c1");
            }
            if (b == 194)
            {
                this.SetAsBoolean(false);
                return;
            }
            if (b == 195)
            {
                this.SetAsBoolean(true);
                return;
            }
            if (b == 196)
            {
                int num = ms.ReadByte();
                byte[] array = new byte[num];
                ms.Read(array, 0, num);
                this.SetAsBytes(array);
                return;
            }
            if (b == 197)
            {
                byte[] array = new byte[2];
                ms.Read(array, 0, 2);
                array = BytesTools.SwapBytes(array);
                int num = (int)BitConverter.ToUInt16(array, 0);
                array = new byte[num];
                ms.Read(array, 0, num);
                this.SetAsBytes(array);
                return;
            }
            if (b == 198)
            {
                byte[] array = new byte[4];
                ms.Read(array, 0, 4);
                array = BytesTools.SwapBytes(array);
                int num = BitConverter.ToInt32(array, 0);
                array = new byte[num];
                ms.Read(array, 0, num);
                this.SetAsBytes(array);
                return;
            }
            if (b == 199 || b == 200 || b == 201)
            {
                throw new Exception("(ext8,ext16,ex32) type $c7,$c8,$c9");
            }
            if (b == 202)
            {
                byte[] array = new byte[4];
                ms.Read(array, 0, 4);
                array = BytesTools.SwapBytes(array);
                this.SetAsSingle(BitConverter.ToSingle(array, 0));
                return;
            }
            if (b == 203)
            {
                byte[] array = new byte[8];
                ms.Read(array, 0, 8);
                array = BytesTools.SwapBytes(array);
                this.SetAsFloat(BitConverter.ToDouble(array, 0));
                return;
            }
            if (b == 204)
            {
                b = (byte)ms.ReadByte();
                this.SetAsInteger((long)((ulong)b));
                return;
            }
            if (b == 205)
            {
                byte[] array = new byte[2];
                ms.Read(array, 0, 2);
                array = BytesTools.SwapBytes(array);
                this.SetAsInteger((long)((ulong)BitConverter.ToUInt16(array, 0)));
                return;
            }
            if (b == 206)
            {
                byte[] array = new byte[4];
                ms.Read(array, 0, 4);
                array = BytesTools.SwapBytes(array);
                this.SetAsInteger((long)((ulong)BitConverter.ToUInt32(array, 0)));
                return;
            }
            if (b == 207)
            {
                byte[] array = new byte[8];
                ms.Read(array, 0, 8);
                array = BytesTools.SwapBytes(array);
                this.SetAsUInt64(BitConverter.ToUInt64(array, 0));
                return;
            }
            if (b == 220)
            {
                byte[] array = new byte[2];
                ms.Read(array, 0, 2);
                array = BytesTools.SwapBytes(array);
                int num = (int)BitConverter.ToInt16(array, 0);
                this.Clear();
                this.valueType = MsgPackType.Array;
                for (int i = 0; i < num; i++)
                {
                    MsgPack msgPack = this.InnerAdd();
                    msgPack.DecodeFromStream(ms);
                }
                return;
            }
            if (b == 221)
            {
                byte[] array = new byte[4];
                ms.Read(array, 0, 4);
                array = BytesTools.SwapBytes(array);
                int num = (int)BitConverter.ToInt16(array, 0);
                this.Clear();
                this.valueType = MsgPackType.Array;
                for (int i = 0; i < num; i++)
                {
                    MsgPack msgPack = this.InnerAdd();
                    msgPack.DecodeFromStream(ms);
                }
                return;
            }
            if (b == 217)
            {
                this.SetAsString(ReadTools.ReadString(b, ms));
                return;
            }
            if (b == 222)
            {
                byte[] array = new byte[2];
                ms.Read(array, 0, 2);
                array = BytesTools.SwapBytes(array);
                int num = (int)BitConverter.ToInt16(array, 0);
                this.Clear();
                this.valueType = MsgPackType.Map;
                for (int i = 0; i < num; i++)
                {
                    MsgPack msgPack = this.InnerAdd();
                    msgPack.SetName(ReadTools.ReadString(ms));
                    msgPack.DecodeFromStream(ms);
                }
                return;
            }
            if (b == 222)
            {
                byte[] array = new byte[2];
                ms.Read(array, 0, 2);
                array = BytesTools.SwapBytes(array);
                int num = (int)BitConverter.ToInt16(array, 0);
                this.Clear();
                this.valueType = MsgPackType.Map;
                for (int i = 0; i < num; i++)
                {
                    MsgPack msgPack = this.InnerAdd();
                    msgPack.SetName(ReadTools.ReadString(ms));
                    msgPack.DecodeFromStream(ms);
                }
                return;
            }
            if (b == 223)
            {
                byte[] array = new byte[4];
                ms.Read(array, 0, 4);
                array = BytesTools.SwapBytes(array);
                int num = BitConverter.ToInt32(array, 0);
                this.Clear();
                this.valueType = MsgPackType.Map;
                for (int i = 0; i < num; i++)
                {
                    MsgPack msgPack = this.InnerAdd();
                    msgPack.SetName(ReadTools.ReadString(ms));
                    msgPack.DecodeFromStream(ms);
                }
                return;
            }
            if (b == 218)
            {
                this.SetAsString(ReadTools.ReadString(b, ms));
                return;
            }
            if (b == 219)
            {
                this.SetAsString(ReadTools.ReadString(b, ms));
                return;
            }
            if (b == 208)
            {
                this.SetAsInteger((long)((sbyte)ms.ReadByte()));
                return;
            }
            if (b == 209)
            {
                byte[] array = new byte[2];
                ms.Read(array, 0, 2);
                array = BytesTools.SwapBytes(array);
                this.SetAsInteger((long)BitConverter.ToInt16(array, 0));
                return;
            }
            if (b == 210)
            {
                byte[] array = new byte[4];
                ms.Read(array, 0, 4);
                array = BytesTools.SwapBytes(array);
                this.SetAsInteger((long)BitConverter.ToInt32(array, 0));
                return;
            }
            if (b == 211)
            {
                byte[] array = new byte[8];
                ms.Read(array, 0, 8);
                array = BytesTools.SwapBytes(array);
                this.SetAsInteger(BitConverter.ToInt64(array, 0));
            }
        }

        public byte[] Encode2Bytes()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                this.Encode2Stream(memoryStream);
                byte[] array = new byte[memoryStream.Length];
                memoryStream.Position = 0L;
                memoryStream.Read(array, 0, (int)memoryStream.Length);
                result = Zip.Compress(array);
            }
            return result;
        }

        public void Encode2Stream(Stream ms)
        {
            switch (this.valueType)
            {
                case MsgPackType.Unknown:
                case MsgPackType.Null:
                    WriteTools.WriteNull(ms);
                    return;

                case MsgPackType.Map:
                    this.WriteMap(ms);
                    return;

                case MsgPackType.Array:
                    this.WirteArray(ms);
                    return;

                case MsgPackType.String:
                    WriteTools.WriteString(ms, (string)this.innerValue);
                    return;

                case MsgPackType.Integer:
                    WriteTools.WriteInteger(ms, (long)this.innerValue);
                    return;

                case MsgPackType.UInt64:
                    WriteTools.WriteUInt64(ms, (ulong)this.innerValue);
                    return;

                case MsgPackType.Boolean:
                    WriteTools.WriteBoolean(ms, (bool)this.innerValue);
                    return;

                case MsgPackType.Float:
                    WriteTools.WriteFloat(ms, (double)this.innerValue);
                    return;

                case MsgPackType.Single:
                    WriteTools.WriteFloat(ms, (double)((float)this.innerValue));
                    return;

                case MsgPackType.DateTime:
                    WriteTools.WriteInteger(ms, this.GetAsInteger());
                    return;

                case MsgPackType.Binary:
                    WriteTools.WriteBinary(ms, (byte[])this.innerValue);
                    return;

                default:
                    WriteTools.WriteNull(ms);
                    return;
            }
        }

        public string AsString
        {
            get
            {
                return this.GetAsString();
            }
            set
            {
                this.SetAsString(value);
            }
        }

        public long AsInteger
        {
            get
            {
                return this.GetAsInteger();
            }
            set
            {
                this.SetAsInteger(value);
            }
        }

        public double AsFloat
        {
            get
            {
                return this.GetAsFloat();
            }
            set
            {
                this.SetAsFloat(value);
            }
        }

        public MsgPackArray AsArray
        {
            get
            {
                lock (this)
                {
                    if (this.refAsArray == null)
                    {
                        this.refAsArray = new MsgPackArray(this, this.children);
                    }
                }
                return this.refAsArray;
            }
        }

        public MsgPackType ValueType
        {
            get
            {
                return this.valueType;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MsgPackEnum(this.children);
        }

        private string name;

        private string lowerName;

        private object innerValue;

        private MsgPackType valueType;

        private MsgPack parent;

        private List<MsgPack> children = new List<MsgPack>();

        private MsgPackArray refAsArray;
    }
}
