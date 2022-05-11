using System.Drawing;
using System.Threading;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    public class HandlePing
    {
        public void Ping(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").SetAsString("Po_ng");
                ThreadPool.QueueUserWorkItem(new WaitCallback(client.Send), msgPack.Encode2Bytes());
                object lockListviewClients = Settings.LockListviewClients;
                lock (lockListviewClients)
                {
                    if (client.LV != null)
                    {
                        client.LV.SubItems[Program.form1.lv_act.Index].Text = unpack_msgpack.ForcePathObject("Message").AsString;
                    }
                }
            }
            catch
            {
            }
        }

        public void Po_ng(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                object lockListviewClients = Settings.LockListviewClients;
                lock (lockListviewClients)
                {
                    if (client.LV != null)
                    {
                        client.LV.SubItems[Program.form1.lv_ping.Index].Text = unpack_msgpack.ForcePathObject("Message").AsInteger.ToString() + " MS";
                        if (unpack_msgpack.ForcePathObject("Message").AsInteger > 600L)
                        {
                            client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.Red;
                        }
                        else if (unpack_msgpack.ForcePathObject("Message").AsInteger > 300L)
                        {
                            client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.Orange;
                        }
                        else
                        {
                            client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.Green;
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
