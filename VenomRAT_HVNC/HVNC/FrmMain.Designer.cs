using System;

namespace VenomRAT_HVNC.HVNC
{
	public partial class FrmMain : global::System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ClientsOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.builderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2ControlBox5 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PortStatus = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.HVNCList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HVNCListenBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HVNCListenPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.TogglePort = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.hvncport = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hvncport)).BeginInit();
            this.SuspendLayout();
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1451, 716);
            this.guna2Panel1.TabIndex = 6;
            this.ClientsOnline.ForeColor = System.Drawing.Color.Gainsboro;
            this.ClientsOnline.LinkColor = System.Drawing.Color.Green;
            this.ClientsOnline.Name = "ClientsOnline";
            this.ClientsOnline.Size = new System.Drawing.Size(185, 23);
            this.ClientsOnline.Text = "Client in HVNC Panel 0";
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientsOnline});
            this.statusStrip1.Location = new System.Drawing.Point(0, 716);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1451, 29);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.builderToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 88);
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(186, 28);
            this.testToolStripMenuItem.Text = "Venom HVNC";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.HVNCList_DoubleClick);
            this.builderToolStripMenuItem.Name = "builderToolStripMenuItem";
            this.builderToolStripMenuItem.Size = new System.Drawing.Size(186, 28);
            this.builderToolStripMenuItem.Text = "Builder";
            this.builderToolStripMenuItem.Click += new System.EventHandler(this.builderToolStripMenuItem_Click);
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteExecuteToolStripMenuItem,
            this.closeConnectionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(186, 28);
            this.optionsToolStripMenuItem.Text = "Options";
            this.remoteExecuteToolStripMenuItem.Name = "remoteExecuteToolStripMenuItem";
            this.remoteExecuteToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.remoteExecuteToolStripMenuItem.Text = "Remote Execute";
            this.remoteExecuteToolStripMenuItem.Click += new System.EventHandler(this.remoteExecuteToolStripMenuItem_Click);
            this.closeConnectionToolStripMenuItem.Name = "closeConnectionToolStripMenuItem";
            this.closeConnectionToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.closeConnectionToolStripMenuItem.Text = "Close Connection";
            this.closeConnectionToolStripMenuItem.Click += new System.EventHandler(this.closeConnectionToolStripMenuItem_Click);
            this.guna2DragControl1.TargetControl = this.panel1;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.guna2Separator2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.guna2ControlBox5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1451, 74);
            this.panel1.TabIndex = 2;
            this.guna2Separator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2Separator2.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Separator2.FillThickness = 4;
            this.guna2Separator2.Location = new System.Drawing.Point(0, -1);
            this.guna2Separator2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(1451, 12);
            this.guna2Separator2.TabIndex = 145;
            this.pictureBox1.Location = new System.Drawing.Point(1, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 144;
            this.pictureBox1.TabStop = false;
            this.guna2ControlBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.HoverState.Parent = this.guna2ControlBox5;
            this.guna2ControlBox5.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox5.Location = new System.Drawing.Point(1389, 16);
            this.guna2ControlBox5.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox5.Name = "guna2ControlBox5";
            this.guna2ControlBox5.ShadowDecoration.Parent = this.guna2ControlBox5;
            this.guna2ControlBox5.Size = new System.Drawing.Size(60, 52);
            this.guna2ControlBox5.TabIndex = 139;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(60, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "HVNC";
            this.PortStatus.AutoSize = true;
            this.PortStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.PortStatus.ForeColor = System.Drawing.Color.White;
            this.PortStatus.Location = new System.Drawing.Point(1037, 722);
            this.PortStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PortStatus.Name = "PortStatus";
            this.PortStatus.Size = new System.Drawing.Size(61, 16);
            this.PortStatus.TabIndex = 146;
            this.PortStatus.Text = "Start Port";
            this.PortStatus.Visible = false;
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.HVNCList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.HVNCList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.HVNCList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HVNCList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1});
            this.HVNCList.ContextMenuStrip = this.contextMenuStrip1;
            this.HVNCList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HVNCList.ForeColor = System.Drawing.Color.Gainsboro;
            this.HVNCList.FullRowSelect = true;
            this.HVNCList.HideSelection = false;
            this.HVNCList.LabelEdit = true;
            this.HVNCList.Location = new System.Drawing.Point(0, 74);
            this.HVNCList.Margin = new System.Windows.Forms.Padding(4);
            this.HVNCList.Name = "HVNCList";
            this.HVNCList.Size = new System.Drawing.Size(1451, 642);
            this.HVNCList.SmallImageList = this.imageList1;
            this.HVNCList.TabIndex = 7;
            this.HVNCList.UseCompatibleStateImageBehavior = false;
            this.HVNCList.View = System.Windows.Forms.View.Details;
            this.columnHeader3.Text = "IP Address";
            this.columnHeader3.Width = 150;
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 938;
            this.HVNCListenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HVNCListenBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portToolStripMenuItem,
            this.HVNCListenPort,
            this.toolStripSeparator3});
            this.HVNCListenBtn.Name = "HVNCListenBtn";
            this.HVNCListenBtn.Size = new System.Drawing.Size(189, 32);
            this.HVNCListenBtn.Text = "listening Port";
            this.HVNCListenBtn.Click += new System.EventHandler(this.HVNCListenBtn_Click_1);
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.portToolStripMenuItem.Text = "Port :";
            this.HVNCListenPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.HVNCListenPort.Name = "HVNCListenPort";
            this.HVNCListenPort.Size = new System.Drawing.Size(100, 27);
            this.HVNCListenPort.Text = "9031";
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_NEGATIVE;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.TogglePort.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TogglePort.CheckedState.BorderRadius = 1;
            this.TogglePort.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.TogglePort.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.TogglePort.CheckedState.InnerBorderRadius = 0;
            this.TogglePort.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(189)))), ((int)(((byte)(144)))));
            this.TogglePort.CheckedState.InnerOffset = 2;
            this.TogglePort.CheckedState.Parent = this.TogglePort;
            this.TogglePort.Location = new System.Drawing.Point(1117, 719);
            this.TogglePort.Margin = new System.Windows.Forms.Padding(4);
            this.TogglePort.Name = "TogglePort";
            this.TogglePort.ShadowDecoration.Parent = this.TogglePort;
            this.TogglePort.Size = new System.Drawing.Size(59, 23);
            this.TogglePort.TabIndex = 148;
            this.TogglePort.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.TogglePort.UncheckedState.BorderRadius = 1;
            this.TogglePort.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.TogglePort.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.TogglePort.UncheckedState.InnerBorderRadius = 0;
            this.TogglePort.UncheckedState.InnerColor = System.Drawing.SystemColors.WindowText;
            this.TogglePort.UncheckedState.InnerOffset = 2;
            this.TogglePort.UncheckedState.Parent = this.TogglePort;
            this.TogglePort.CheckedChanged += new System.EventHandler(this.TogglePort_CheckedChanged);
            this.TogglePort.Click += new System.EventHandler(this.TogglePort_Click);
            this.hvncport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hvncport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.hvncport.BorderThickness = 0;
            this.hvncport.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hvncport.DisabledState.Parent = this.hvncport;
            this.hvncport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.hvncport.FocusedState.Parent = this.hvncport;
            this.hvncport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hvncport.ForeColor = System.Drawing.Color.Gainsboro;
            this.hvncport.Location = new System.Drawing.Point(1197, 719);
            this.hvncport.Margin = new System.Windows.Forms.Padding(4);
            this.hvncport.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.hvncport.Name = "hvncport";
            this.hvncport.ShadowDecoration.Parent = this.hvncport;
            this.hvncport.Size = new System.Drawing.Size(105, 23);
            this.hvncport.TabIndex = 156;
            this.hvncport.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.hvncport.UpDownButtonForeColor = System.Drawing.Color.White;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1451, 745);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.PortStatus);
            this.Controls.Add(this.hvncport);
            this.Controls.Add(this.TogglePort);
            this.Controls.Add(this.HVNCList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1387, 641);
            this.Name = "FrmMain";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HVNC";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(19)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hvncport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.ImageList imageList1;

		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		private global::System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;

		public global::System.Windows.Forms.StatusStrip statusStrip1;

		private global::System.Windows.Forms.ToolStripStatusLabel ClientsOnline;

		private global::System.Windows.Forms.Panel panel1;

		private global::System.Windows.Forms.Label label3;

		public global::System.Windows.Forms.ToolStripMenuItem HVNCListenBtn;

		private global::System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripTextBox HVNCListenPort;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::System.Windows.Forms.ImageList imageList2;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox5;

		private global::System.Windows.Forms.ColumnHeader columnHeader3;

		private global::System.Windows.Forms.PictureBox pictureBox1;

		public global::System.Windows.Forms.ListView HVNCList;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator2;

		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		private global::System.Windows.Forms.ToolStripMenuItem builderToolStripMenuItem;

		public global::System.Windows.Forms.Label PortStatus;

		private global::Guna.UI2.WinForms.Guna2ToggleSwitch TogglePort;

		private global::System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem remoteExecuteToolStripMenuItem;

		public global::Guna.UI2.WinForms.Guna2NumericUpDown hvncport;

		private global::System.Windows.Forms.ToolStripMenuItem closeConnectionToolStripMenuItem;
	}
}
