using System;
using Microsoft.Win32;

namespace VenomRAT_HVNC.Server.Helper
{
    public static class RegistryKeyExtensions
    {
        public static string RegistryTypeToString(this RegistryValueKind valueKind, object valueData)
        {
            if (valueData == null)
            {
                return "(value not set)";
            }
            switch (valueKind)
            {
                case RegistryValueKind.String:
                case RegistryValueKind.ExpandString:
                    return valueData.ToString();

                case RegistryValueKind.Binary:
                    if (((byte[])valueData).Length == 0)
                    {
                        return "(zero-length binary value)";
                    }
                    return BitConverter.ToString((byte[])valueData).Replace("-", " ").ToLower();

                case RegistryValueKind.DWord:
                    return string.Format("0x{0} ({1})", ((uint)((int)valueData)).ToString("x8"), ((uint)((int)valueData)).ToString());

                case RegistryValueKind.MultiString:
                    return string.Join(" ", (string[])valueData);

                case RegistryValueKind.QWord:
                    return string.Format("0x{0} ({1})", ((ulong)((long)valueData)).ToString("x8"), ((ulong)((long)valueData)).ToString());
            }
            return string.Empty;
        }

        public static RegistryKey OpenReadonlySubKeySafe(this RegistryKey key, string name)
        {
            RegistryKey result;
            try
            {
                result = key.OpenSubKey(name, false);
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public static RegistryKey OpenWritableSubKeySafe(this RegistryKey key, string name)
        {
            RegistryKey result;
            try
            {
                result = key.OpenSubKey(name, true);
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public static string RegistryTypeToString(this RegistryValueKind valueKind)
        {
            switch (valueKind)
            {
                case RegistryValueKind.Unknown:
                    return "(Unknown)";

                case RegistryValueKind.String:
                    return "REG_SZ";

                case RegistryValueKind.ExpandString:
                    return "REG_EXPAND_SZ";

                case RegistryValueKind.Binary:
                    return "REG_BINARY";

                case RegistryValueKind.DWord:
                    return "REG_DWORD";

                case RegistryValueKind.MultiString:
                    return "REG_MULTI_SZ";

                case RegistryValueKind.QWord:
                    return "REG_QWORD";
            }
            return "REG_NONE";
        }
    }
}
