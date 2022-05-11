namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormRemoteDesktop : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormRemoteDesktop));
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.timerSave = new global::System.Windows.Forms.Timer(this.components);
			this.labelWait = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.numericUpDown2 = new global::Guna.UI2.WinForms.Guna2NumericUpDown();
			this.numericUpDown1 = new global::Guna.UI2.WinForms.Guna2NumericUpDown();
			this.btnSave = new global::Guna.UI2.WinForms.Guna2Button();
			this.btnKeyboard = new global::Guna.UI2.WinForms.Guna2Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnMouse = new global::Guna.UI2.WinForms.Guna2Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2ResizeBox1 = new global::Guna.UI2.WinForms.Guna2ResizeBox();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.pictureBox1.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.pictureBox1.Location = new global::System.Drawing.Point(0, 67);
			this.pictureBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(1038, 584);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.FormRemoteDesktop_Load);
			this.pictureBox1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
			this.timer1.Interval = 2000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.timerSave.Interval = 1500;
			this.timerSave.Tick += new global::System.EventHandler(this.TimerSave_Tick);
			this.labelWait.AutoSize = true;
			this.labelWait.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.labelWait.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.labelWait.ForeColor = global::System.Drawing.Color.White;
			this.labelWait.Location = new global::System.Drawing.Point(456, 340);
			this.labelWait.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelWait.Name = "labelWait";
			this.labelWait.Size = new global::System.Drawing.Size(53, 20);
			this.labelWait.TabIndex = 3;
			this.labelWait.Text = "Wait...";
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.panel2.Controls.Add(this.guna2Separator1);
			this.panel2.Controls.Add(this.numericUpDown2);
			this.panel2.Controls.Add(this.numericUpDown1);
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Controls.Add(this.btnKeyboard);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.btnMouse);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.guna2ControlBox1);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.ForeColor = global::System.Drawing.Color.White;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1038, 67);
			this.panel2.TabIndex = 7;
			this.guna2Separator1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(0, -4);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(1038, 10);
			this.guna2Separator1.TabIndex = 133;
			this.numericUpDown2.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.numericUpDown2.BackColor = global::System.Drawing.Color.White;
			this.numericUpDown2.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.numericUpDown2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.numericUpDown2.DisabledState.Parent = this.numericUpDown2;
			this.numericUpDown2.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.numericUpDown2.FocusedState.FillColor = global::System.Drawing.Color.White;
			this.numericUpDown2.FocusedState.ForeColor = global::System.Drawing.Color.White;
			this.numericUpDown2.FocusedState.Parent = this.numericUpDown2;
			this.numericUpDown2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.numericUpDown2.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown2.Location = new global::System.Drawing.Point(493, 23);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.ShadowDecoration.Color = global::System.Drawing.Color.White;
			this.numericUpDown2.ShadowDecoration.Parent = this.numericUpDown2;
			this.numericUpDown2.Size = new global::System.Drawing.Size(79, 28);
			this.numericUpDown2.TabIndex = 9;
			this.numericUpDown2.UpDownButtonFillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.numericUpDown2.UpDownButtonForeColor = global::System.Drawing.Color.White;
			this.numericUpDown1.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.numericUpDown1.BackColor = global::System.Drawing.Color.White;
			this.numericUpDown1.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.numericUpDown1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.numericUpDown1.DisabledState.Parent = this.numericUpDown1;
			this.numericUpDown1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.numericUpDown1.FocusedState.Parent = this.numericUpDown1;
			this.numericUpDown1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.numericUpDown1.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown1.Location = new global::System.Drawing.Point(394, 23);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.ShadowDecoration.Parent = this.numericUpDown1;
			this.numericUpDown1.Size = new global::System.Drawing.Size(79, 28);
			this.numericUpDown1.TabIndex = 9;
			this.numericUpDown1.UpDownButtonFillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.numericUpDown1.UpDownButtonForeColor = global::System.Drawing.Color.White;
			global::Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown = this.numericUpDown1;
			int[] array = new int[4];
			array[0] = 30;
			guna2NumericUpDown.Value = new decimal(array);
			this.btnSave.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.btnSave.BorderRadius = 5;
			this.btnSave.CheckedState.Parent = this.btnSave;
			this.btnSave.CustomImages.Parent = this.btnSave;
			this.btnSave.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.btnSave.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.btnSave.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.btnSave.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.btnSave.DisabledState.Parent = this.btnSave;
			this.btnSave.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.btnSave.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnSave.ForeColor = global::System.Drawing.Color.White;
			this.btnSave.HoverState.Parent = this.btnSave;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageSize = new global::System.Drawing.Size(30, 30);
			this.btnSave.Location = new global::System.Drawing.Point(599, 22);
			this.btnSave.Name = "btnSave";
			this.btnSave.ShadowDecoration.Parent = this.btnSave;
			this.btnSave.Size = new global::System.Drawing.Size(89, 30);
			this.btnSave.TabIndex = 9;
			this.btnSave.Tag = "play";
			this.btnSave.Text = "Capture";
			this.btnSave.Click += new global::System.EventHandler(this.BtnSave_Click);
			this.btnKeyboard.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.btnKeyboard.BorderRadius = 5;
			this.btnKeyboard.CheckedState.Parent = this.btnKeyboard;
			this.btnKeyboard.CustomImages.Parent = this.btnKeyboard;
			this.btnKeyboard.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.btnKeyboard.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.btnKeyboard.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.btnKeyboard.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.btnKeyboard.DisabledState.Parent = this.btnKeyboard;
			this.btnKeyboard.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.btnKeyboard.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnKeyboard.ForeColor = global::System.Drawing.Color.White;
			this.btnKeyboard.HoverState.Parent = this.btnKeyboard;
			this.btnKeyboard.Image = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.Image")));
			this.btnKeyboard.ImageSize = new global::System.Drawing.Size(30, 30);
			this.btnKeyboard.Location = new global::System.Drawing.Point(814, 22);
			this.btnKeyboard.Name = "btnKeyboard";
			this.btnKeyboard.ShadowDecoration.Parent = this.btnKeyboard;
			this.btnKeyboard.Size = new global::System.Drawing.Size(107, 30);
			this.btnKeyboard.TabIndex = 9;
			this.btnKeyboard.Tag = "play";
			this.btnKeyboard.Text = "Keyboard";
			this.btnKeyboard.Click += new global::System.EventHandler(this.btnKeyboard_Click);
			this.label2.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.label2.Location = new global::System.Drawing.Point(489, 7);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(51, 16);
			this.label2.TabIndex = 17;
			this.label2.Text = "Screen";
			this.btnMouse.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.btnMouse.BorderRadius = 5;
			this.btnMouse.CheckedState.Parent = this.btnMouse;
			this.btnMouse.CustomImages.Parent = this.btnMouse;
			this.btnMouse.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.btnMouse.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.btnMouse.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.btnMouse.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.btnMouse.DisabledState.Parent = this.btnMouse;
			this.btnMouse.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.btnMouse.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnMouse.ForeColor = global::System.Drawing.Color.White;
			this.btnMouse.HoverState.Parent = this.btnMouse;
			this.btnMouse.Image = ((System.Drawing.Image)(resources.GetObject("btnMouse.Image")));
			this.btnMouse.ImageSize = new global::System.Drawing.Size(30, 30);
			this.btnMouse.Location = new global::System.Drawing.Point(704, 22);
			this.btnMouse.Name = "btnMouse";
			this.btnMouse.ShadowDecoration.Parent = this.btnMouse;
			this.btnMouse.Size = new global::System.Drawing.Size(89, 30);
			this.btnMouse.TabIndex = 9;
			this.btnMouse.Tag = "play";
			this.btnMouse.Text = "Mouse";
			this.btnMouse.Click += new global::System.EventHandler(this.Button3_Click);
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.label1.Location = new global::System.Drawing.Point(391, 7);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(49, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "Quality";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.label7.Location = new global::System.Drawing.Point(3, 22);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(130, 20);
			this.label7.TabIndex = 20;
			this.label7.Text = "Remote Desktop";
			this.button1.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.button1.BorderRadius = 5;
			this.button1.CheckedState.Parent = this.button1;
			this.button1.CustomImages.Parent = this.button1;
			this.button1.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.button1.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.button1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.button1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.button1.DisabledState.Parent = this.button1;
			this.button1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.button1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.HoverState.Parent = this.button1;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageSize = new global::System.Drawing.Size(30, 30);
			this.button1.Location = new global::System.Drawing.Point(176, 22);
			this.button1.Name = "button1";
			this.button1.ShadowDecoration.Parent = this.button1;
			this.button1.Size = new global::System.Drawing.Size(102, 29);
			this.button1.TabIndex = 9;
			this.button1.Tag = "play";
			this.button1.Text = "  Start/Stop";
			this.button1.Click += new global::System.EventHandler(this.Button1_Click);
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(994, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox1.TabIndex = 24;
			this.guna2DragControl1.TargetControl = this.panel2;
			this.guna2ResizeBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ResizeBox1.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2ResizeBox1.FillColor = global::System.Drawing.Color.White;
			this.guna2ResizeBox1.ForeColor = global::System.Drawing.Color.Black;
			this.guna2ResizeBox1.Location = new global::System.Drawing.Point(1018, 632);
			this.guna2ResizeBox1.Name = "guna2ResizeBox1";
			this.guna2ResizeBox1.Size = new global::System.Drawing.Size(20, 20);
			this.guna2ResizeBox1.TabIndex = 8;
			this.guna2ResizeBox1.TargetControl = this;
			this.guna2ResizeBox1.Click += new global::System.EventHandler(this.FormRemoteDesktop_Load);
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_POSITIVE;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1038, 652);
			base.Controls.Add(this.guna2ResizeBox1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.labelWait);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			this.MinimumSize = new global::System.Drawing.Size(442, 300);
			base.Name = "FormRemoteDesktop";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remote Desktop";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.FormRemoteDesktop_FormClosed);
			base.Load += new global::System.EventHandler(this.FormRemoteDesktop_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.FormRemoteDesktop_KeyDown);
			base.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.FormRemoteDesktop_KeyUp);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		public global::System.Windows.Forms.PictureBox pictureBox1;

		public global::System.Windows.Forms.Timer timer1;

		private global::System.Windows.Forms.Timer timerSave;

		public global::System.Windows.Forms.Label labelWait;

		private global::System.Windows.Forms.Panel panel2;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::Guna.UI2.WinForms.Guna2ResizeBox guna2ResizeBox1;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		public global::Guna.UI2.WinForms.Guna2NumericUpDown numericUpDown2;

		public global::Guna.UI2.WinForms.Guna2NumericUpDown numericUpDown1;

		public global::Guna.UI2.WinForms.Guna2Button btnSave;

		public global::Guna.UI2.WinForms.Guna2Button btnKeyboard;

		private global::System.Windows.Forms.Label label2;

		public global::Guna.UI2.WinForms.Guna2Button btnMouse;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label7;

		public global::Guna.UI2.WinForms.Guna2Button button1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
	}
}
