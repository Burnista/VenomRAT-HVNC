namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormAudio : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormAudio));
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2ShadowPanel1 = new global::Guna.UI2.WinForms.Guna2ShadowPanel();
			this.btnStartStopRecord = new global::System.Windows.Forms.Button();
			this.textBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2DragControl2 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2ShadowPanel2 = new global::Guna.UI2.WinForms.Guna2ShadowPanel();
			this.panel2.SuspendLayout();
			this.guna2ShadowPanel1.SuspendLayout();
			this.guna2ShadowPanel2.SuspendLayout();
			base.SuspendLayout();
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.guna2Separator1);
			this.panel2.Controls.Add(this.guna2ShadowPanel1);
			this.panel2.Controls.Add(this.guna2ControlBox1);
			this.panel2.Location = new global::System.Drawing.Point(9, 10);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(625, 329);
			this.panel2.TabIndex = 7;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(31, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(120, 20);
			this.label1.TabIndex = 129;
			this.label1.Text = "Audio Recorder";
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(0, 49);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(625, 20);
			this.guna2Separator1.TabIndex = 128;
			this.guna2ShadowPanel1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ShadowPanel1.Controls.Add(this.btnStartStopRecord);
			this.guna2ShadowPanel1.Controls.Add(this.textBox1);
			this.guna2ShadowPanel1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2ShadowPanel1.Location = new global::System.Drawing.Point(35, 92);
			this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
			this.guna2ShadowPanel1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel1.ShadowShift = 8;
			this.guna2ShadowPanel1.Size = new global::System.Drawing.Size(552, 201);
			this.guna2ShadowPanel1.TabIndex = 127;
			this.btnStartStopRecord.BackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.btnStartStopRecord.FlatAppearance.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.btnStartStopRecord.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.btnStartStopRecord.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.btnStartStopRecord.Location = new global::System.Drawing.Point(116, 117);
			this.btnStartStopRecord.Name = "btnStartStopRecord";
			this.btnStartStopRecord.Size = new global::System.Drawing.Size(297, 37);
			this.btnStartStopRecord.TabIndex = 8;
			this.btnStartStopRecord.Text = "Start Recording";
			this.btnStartStopRecord.UseVisualStyleBackColor = false;
			this.btnStartStopRecord.Click += new global::System.EventHandler(this.btnStartStopRecord_Click);
			this.textBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.textBox1.DefaultText = "";
			this.textBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.textBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.textBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.textBox1.DisabledState.Parent = this.textBox1;
			this.textBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.textBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.textBox1.FocusedState.Parent = this.textBox1;
			this.textBox1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.textBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.textBox1.HoverState.Parent = this.textBox1;
			this.textBox1.Location = new global::System.Drawing.Point(116, 63);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '\0';
			this.textBox1.PlaceholderForeColor = global::System.Drawing.Color.Black;
			this.textBox1.PlaceholderText = "25";
			this.textBox1.SelectedText = "";
			this.textBox1.ShadowDecoration.Parent = this.textBox1;
			this.textBox1.Size = new global::System.Drawing.Size(297, 36);
			this.textBox1.TabIndex = 7;
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(581, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox1.TabIndex = 10;
			this.guna2DragControl2.TargetControl = this.panel2;
			this.guna2ShadowPanel2.BackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel2.Controls.Add(this.panel2);
			this.guna2ShadowPanel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.guna2ShadowPanel2.FillColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2ShadowPanel2.Location = new global::System.Drawing.Point(0, 0);
			this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
			this.guna2ShadowPanel2.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel2.ShadowDepth = 8;
			this.guna2ShadowPanel2.ShadowShift = 2;
			this.guna2ShadowPanel2.Size = new global::System.Drawing.Size(637, 345);
			this.guna2ShadowPanel2.TabIndex = 123;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			base.ClientSize = new global::System.Drawing.Size(637, 345);
			base.Controls.Add(this.guna2ShadowPanel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Name = "FormAudio";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Audio Recorder";
			base.Load += new global::System.EventHandler(this.FormAudio_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.guna2ShadowPanel1.ResumeLayout(false);
			this.guna2ShadowPanel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Timer timer1;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::System.Windows.Forms.Panel panel2;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		private global::Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;

		private global::Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;

		private global::Guna.UI2.WinForms.Guna2TextBox textBox1;

		public global::System.Windows.Forms.Button btnStartStopRecord;

		private global::System.Windows.Forms.Label label1;
	}
}
