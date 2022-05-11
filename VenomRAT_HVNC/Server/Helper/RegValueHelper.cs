using System;
using Microsoft.Win32;

namespace VenomRAT_HVNC.Server.Helper
{
    public class RegValueHelper
    {
        public static bool IsDefaultValue(string valueName)
        {
            return string.IsNullOrEmpty(valueName);
        }

        public static string GetName(string valueName)
        {
            if (!RegValueHelper.IsDefaultValue(valueName))
            {
                return valueName;
            }
            return RegValueHelper.DEFAULT_REG_VALUE;
        }

        public static string RegistryValueToString(RegistrySeeker.RegValueData value)
        {
            switch (value.Kind)
            {
                case RegistryValueKind.String:
                case RegistryValueKind.ExpandString:
                    return ByteConverter.ToString(value.Data);

                case RegistryValueKind.Binary:
                    if (value.Data.Length == 0)
                    {
                        return "(zero-length binary value)";
                    }
                    return BitConverter.ToString(value.Data).Replace("-", " ").ToLower();

                case RegistryValueKind.DWord:
                    {
                        uint num = ByteConverter.ToUInt32(value.Data);
                        return string.Format("0x{0:x8} ({1})", num, num);
                    }
                case RegistryValueKind.MultiString:
                    return string.Join(" ", ByteConverter.ToStringArray(value.Data));

                case RegistryValueKind.QWord:
                    {
                        ulong num2 = ByteConverter.ToUInt64(value.Data);
                        return string.Format("0x{0:x8} ({1})", num2, num2);
                    }
            }
            return string.Empty;
        }

        private static string DEFAULT_REG_VALUE = "(Default)";
    }
}
