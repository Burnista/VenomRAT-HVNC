using System;
using System.Collections.Generic;
using Microsoft.Win32;
using ProtoBuf;

namespace VenomRAT_HVNC.Server.Helper
{
    public class RegistrySeeker
    {
        public RegistrySeeker.RegSeekerMatch[] Matches
        {
            get
            {
                List<RegistrySeeker.RegSeekerMatch> matches = this._matches;
                if (matches == null)
                {
                    return null;
                }
                return matches.ToArray();
            }
        }

        public RegistrySeeker()
        {
            this._matches = new List<RegistrySeeker.RegSeekerMatch>();
        }

        public void BeginSeeking(string rootKeyName)
        {
            if (!string.IsNullOrEmpty(rootKeyName))
            {
                using (RegistryKey rootKey = RegistrySeeker.GetRootKey(rootKeyName))
                {
                    if (rootKey != null && rootKey.Name != rootKeyName)
                    {
                        string name = rootKeyName.Substring(rootKey.Name.Length + 1);
                        using (RegistryKey registryKey = rootKey.OpenReadonlySubKeySafe(name))
                        {
                            if (registryKey != null)
                            {
                                this.Seek(registryKey);
                            }
                            return;
                        }
                    }
                    this.Seek(rootKey);
                    return;
                }
            }
            this.Seek(null);
        }

        private void Seek(RegistryKey rootKey)
        {
            if (rootKey == null)
            {
                using (List<RegistryKey>.Enumerator enumerator = RegistrySeeker.GetRootKeys().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        RegistryKey registryKey = enumerator.Current;
                        this.ProcessKey(registryKey, registryKey.Name);
                    }
                    return;
                }
            }
            this.Search(rootKey);
        }

        private void Search(RegistryKey rootKey)
        {
            foreach (string text in rootKey.GetSubKeyNames())
            {
                RegistryKey key = rootKey.OpenReadonlySubKeySafe(text);
                this.ProcessKey(key, text);
            }
        }

        private void ProcessKey(RegistryKey key, string keyName)
        {
            if (key != null)
            {
                List<RegistrySeeker.RegValueData> list = new List<RegistrySeeker.RegValueData>();
                foreach (string name in key.GetValueNames())
                {
                    RegistryValueKind valueKind = key.GetValueKind(name);
                    object value = key.GetValue(name);
                    list.Add(RegistryKeyHelper.CreateRegValueData(name, valueKind, value));
                }
                this.AddMatch(keyName, RegistryKeyHelper.AddDefaultValue(list), key.SubKeyCount);
                return;
            }
            this.AddMatch(keyName, RegistryKeyHelper.GetDefaultValues(), 0);
        }

        private void AddMatch(string key, RegistrySeeker.RegValueData[] values, int subkeycount)
        {
            RegistrySeeker.RegSeekerMatch item = new RegistrySeeker.RegSeekerMatch
            {
                Key = key,
                Data = values,
                HasSubKeys = (subkeycount > 0)
            };
            this._matches.Add(item);
        }

        public static RegistryKey GetRootKey(string subkeyFullPath)
        {
            string[] array = subkeyFullPath.Split(new char[] { '\\' });
            RegistryKey result;
            try
            {
                string a = array[0];
                if (!(a == "HKEY_CLASSES_ROOT"))
                {
                    if (!(a == "HKEY_CURRENT_USER"))
                    {
                        if (!(a == "HKEY_LOCAL_MACHINE"))
                        {
                            if (!(a == "HKEY_USERS"))
                            {
                                if (!(a == "HKEY_CURRENT_CONFIG"))
                                {
                                    throw new Exception("Invalid rootkey, could not be found.");
                                }
                                result = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64);
                            }
                            else
                            {
                                result = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64);
                            }
                        }
                        else
                        {
                            result = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                        }
                    }
                    else
                    {
                        result = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                    }
                }
                else
                {
                    result = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
                }
            }
            catch (SystemException)
            {
                throw new Exception("Unable to open root registry key, you do not have the needed permissions.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static List<RegistryKey> GetRootKeys()
        {
            List<RegistryKey> list = new List<RegistryKey>();
            try
            {
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64));
            }
            catch (SystemException)
            {
                throw new Exception("Could not open root registry keys, you may not have the needed permission");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        private readonly List<RegistrySeeker.RegSeekerMatch> _matches;

        [ProtoContract]
        public class RegSeekerMatch
        {
            [ProtoMember(1)]
            public string Key { get; set; }

            [ProtoMember(2)]
            public RegistrySeeker.RegValueData[] Data { get; set; }

            [ProtoMember(3)]
            public bool HasSubKeys { get; set; }

            public override string ToString()
            {
                return string.Format("({0}:{1})", this.Key, this.Data);
            }
        }

        [ProtoContract]
        public class RegValueData
        {
            [ProtoMember(1)]
            public string Name { get; set; }

            [ProtoMember(2)]
            public RegistryValueKind Kind { get; set; }

            [ProtoMember(3)]
            public byte[] Data { get; set; }
        }
    }
}
