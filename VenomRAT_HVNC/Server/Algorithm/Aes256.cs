using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace VenomRAT_HVNC.Server.Algorithm
{
    public class Aes256
    {
        public Aes256(string masterKey)
        {
            if (string.IsNullOrEmpty(masterKey))
            {
                throw new ArgumentException("masterKey can not be null or empty.");
            }
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(masterKey, Aes256.Salt, 50000))
            {
                this._key = rfc2898DeriveBytes.GetBytes(32);
                this._authKey = rfc2898DeriveBytes.GetBytes(64);
            }
        }

        public string Encrypt(string input)
        {
            return Convert.ToBase64String(this.Encrypt(Encoding.UTF8.GetBytes(input)));
        }

        public byte[] Encrypt(byte[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input can not be null.");
            }
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Position = 32L;
                using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
                {
                    aesCryptoServiceProvider.KeySize = 256;
                    aesCryptoServiceProvider.BlockSize = 128;
                    aesCryptoServiceProvider.Mode = CipherMode.CBC;
                    aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                    aesCryptoServiceProvider.Key = this._key;
                    aesCryptoServiceProvider.GenerateIV();
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        memoryStream.Write(aesCryptoServiceProvider.IV, 0, aesCryptoServiceProvider.IV.Length);
                        cryptoStream.Write(input, 0, input.Length);
                        cryptoStream.FlushFinalBlock();
                        using (HMACSHA256 hmacsha = new HMACSHA256(this._authKey))
                        {
                            byte[] array = hmacsha.ComputeHash(memoryStream.ToArray(), 32, memoryStream.ToArray().Length - 32);
                            memoryStream.Position = 0L;
                            memoryStream.Write(array, 0, array.Length);
                        }
                    }
                }
                result = memoryStream.ToArray();
            }
            return result;
        }

        public string Decrypt(string input)
        {
            return Encoding.UTF8.GetString(this.Decrypt(Convert.FromBase64String(input)));
        }

        public byte[] Decrypt(byte[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input can not be null.");
            }
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(input))
            {
                using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
                {
                    aesCryptoServiceProvider.KeySize = 256;
                    aesCryptoServiceProvider.BlockSize = 128;
                    aesCryptoServiceProvider.Mode = CipherMode.CBC;
                    aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                    aesCryptoServiceProvider.Key = this._key;
                    using (HMACSHA256 hmacsha = new HMACSHA256(this._authKey))
                    {
                        byte[] a = hmacsha.ComputeHash(memoryStream.ToArray(), 32, memoryStream.ToArray().Length - 32);
                        byte[] array = new byte[32];
                        memoryStream.Read(array, 0, array.Length);
                        if (!this.AreEqual(a, array))
                        {
                            throw new CryptographicException("Invalid message authentication code (MAC).");
                        }
                    }
                    byte[] array2 = new byte[16];
                    memoryStream.Read(array2, 0, 16);
                    aesCryptoServiceProvider.IV = array2;
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] array3 = new byte[memoryStream.Length - 16L + 1L];
                        byte[] array4 = new byte[cryptoStream.Read(array3, 0, array3.Length)];
                        Buffer.BlockCopy(array3, 0, array4, 0, array4.Length);
                        result = array4;
                    }
                }
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private bool AreEqual(byte[] a1, byte[] a2)
        {
            bool result = true;
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                {
                    result = false;
                }
            }
            return result;
        }

        private const int KeyLength = 32;

        private const int AuthKeyLength = 64;

        private const int IvLength = 16;

        private const int HmacSha256Length = 32;

        private readonly byte[] _key;

        private readonly byte[] _authKey;

        private static readonly byte[] Salt = Encoding.ASCII.GetBytes("DcRatByqwqdanchun");
    }
}
