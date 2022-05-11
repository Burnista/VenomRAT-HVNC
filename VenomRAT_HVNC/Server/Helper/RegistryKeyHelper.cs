using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace VenomRAT_HVNC.Server.Helper
{
    public static class RegistryKeyHelper
    {
        public static bool AddRegistryKeyValue(RegistryHive hive, string path, string name, string value, bool addQuotes = false)
        {
            bool result;
            try
            {
                using (RegistryKey registryKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenWritableSubKeySafe(path))
                {
                    if (registryKey == null)
                    {
                        result = false;
                    }
                    else
                    {
                        if (addQuotes && !value.StartsWith("\"") && !value.EndsWith("\""))
                        {
                            value = "\"" + value + "\"";
                        }
                        registryKey.SetValue(name, value);
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public static RegistryKey OpenReadonlySubKey(RegistryHive hive, string path)
        {
            RegistryKey result;
            try
            {
                result = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenSubKey(path, false);
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public static bool DeleteRegistryKeyValue(RegistryHive hive, string path, string name)
        {
            bool result;
            try
            {
                using (RegistryKey registryKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenWritableSubKeySafe(path))
                {
                    if (registryKey == null)
                    {
                        result = false;
                    }
                    else
                    {
                        registryKey.DeleteValue(name, true);
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public static bool IsDefaultValue(string valueName)
        {
            return string.IsNullOrEmpty(valueName);
        }

        public static RegistrySeeker.RegValueData[] AddDefaultValue(List<RegistrySeeker.RegValueData> values)
        {
            if (!values.Any((RegistrySeeker.RegValueData value) => RegistryKeyHelper.IsDefaultValue(value.Name)))
            {
                values.Add(RegistryKeyHelper.GetDefaultValue());
            }
            return values.ToArray();
        }

        public static RegistrySeeker.RegValueData[] GetDefaultValues()
        {
            return new RegistrySeeker.RegValueData[] { RegistryKeyHelper.GetDefaultValue() };
        }

        public static RegistrySeeker.RegValueData CreateRegValueData(string name, RegistryValueKind kind, object value = null)
        {
            RegistrySeeker.RegValueData regValueData = new RegistrySeeker.RegValueData
            {
                Name = name,
                Kind = kind
            };
            if (value == null)
            {
                regValueData.Data = new byte[0];
            }
            else
            {
                switch (regValueData.Kind)
                {
                    case RegistryValueKind.String:
                    case RegistryValueKind.ExpandString:
                        regValueData.Data = ByteConverter.GetBytes((string)value);
                        break;

                    case RegistryValueKind.Binary:
                        regValueData.Data = (byte[])value;
                        break;

                    case RegistryValueKind.DWord:
                        regValueData.Data = ByteConverter.GetBytes((uint)((int)value));
                        break;

                    case RegistryValueKind.MultiString:
                        regValueData.Data = ByteConverter.GetBytes((string[])value);
                        break;

                    case RegistryValueKind.QWord:
                        regValueData.Data = ByteConverter.GetBytes((ulong)((long)value));
                        break;
                }
            }
            return regValueData;
        }

        private static RegistrySeeker.RegValueData GetDefaultValue()
        {
            return RegistryKeyHelper.CreateRegValueData(RegistryKeyHelper.DEFAULT_VALUE, RegistryValueKind.String, null);
        }

        private static string DEFAULT_VALUE = string.Empty;
    }
}
