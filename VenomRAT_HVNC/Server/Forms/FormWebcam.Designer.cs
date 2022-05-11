namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormWebcam : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormWebcam));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.numericUpDown1 = new global::Guna.UI2.WinForms.Guna2NumericUpDown();
			this.comboBox1 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			this.guna2Separator2 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.btnSave = new global::Guna.UI2.WinForms.Guna2Button();
			this.button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.timerSave = new global::System.Windows.Forms.Timer(this.components);
			this.labelWait = new global::System.Windows.Forms.Label();
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.guna2ResizeBox1 = new global::Guna.UI2.WinForms.Guna2ResizeBox();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.panel1.Controls.Add(this.numericUpDown1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.guna2Separator2);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.guna2Separator1);
			this.panel1.Controls.Add(this.guna2ControlBox1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = global::System.Drawing.Color.White;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(703, 54);
			this.panel1.TabIndex = 3;
			this.numericUpDown1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numericUpDown1.BackColor = global::System.Drawing.Color.Transparent;
			this.numericUpDown1.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.numericUpDown1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.numericUpDown1.DisabledState.Parent = this.numericUpDown1;
			this.numericUpDown1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.numericUpDown1.FocusedState.Parent = this.numericUpDown1;
			this.numericUpDown1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.numericUpDown1.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown1.Location = new global::System.Drawing.Point(236, 8);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.ShadowDecoration.Parent = this.numericUpDown1;
			this.numericUpDown1.Size = new global::System.Drawing.Size(122, 36);
			this.numericUpDown1.TabIndex = 8;
			this.numericUpDown1.UpDownButtonFillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.numericUpDown1.UpDownButtonForeColor = global::System.Drawing.Color.White;
			global::Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown = this.numericUpDown1;
			int[] array = new int[4];
			array[0] = 50;
			guna2NumericUpDown.Value = new decimal(array);
			this.comboBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.comboBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.comboBox1.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.comboBox1.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.comboBox1.FocusedColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.comboBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.comboBox1.FocusedState.Parent = this.comboBox1;
			this.comboBox1.Font = new global::System.Drawing.Font("Segoe UI", 10f);
			this.comboBox1.ForeColor = global::System.Drawing.Color.White;
			this.comboBox1.HoverState.Parent = this.comboBox1;
			this.comboBox1.ItemHeight = 30;
			this.comboBox1.ItemsAppearance.BackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.comboBox1.ItemsAppearance.Parent = this.comboBox1;
			this.comboBox1.Location = new global::System.Drawing.Point(381, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.ShadowDecoration.Color = global::System.Drawing.Color.White;
			this.comboBox1.ShadowDecoration.Parent = this.comboBox1;
			this.comboBox1.Size = new global::System.Drawing.Size(140, 36);
			this.comboBox1.TabIndex = 8;
			this.guna2Separator2.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator2.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator2.FillThickness = 2;
			this.guna2Separator2.Location = new global::System.Drawing.Point(0, 45);
			this.guna2Separator2.Name = "guna2Separator2";
			this.guna2Separator2.Size = new global::System.Drawing.Size(700, 12);
			this.guna2Separator2.TabIndex = 132;
			this.btnSave.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
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
			this.btnSave.Location = new global::System.Drawing.Point(571, 8);
			this.btnSave.Name = "btnSave";
			this.btnSave.ShadowDecoration.Parent = this.btnSave;
			this.btnSave.Size = new global::System.Drawing.Size(33, 36);
			this.btnSave.TabIndex = 7;
			this.btnSave.Click += new global::System.EventHandler(this.BtnSave_Click);
			this.button1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
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
			this.button1.Location = new global::System.Drawing.Point(126, 8);
			this.button1.Name = "button1";
			this.button1.ShadowDecoration.Parent = this.button1;
			this.button1.Size = new global::System.Drawing.Size(33, 36);
			this.button1.TabIndex = 0;
			this.button1.Tag = "play";
			this.button1.Click += new global::System.EventHandler(this.Button1_Click);
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(0, -5);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(703, 12);
			this.guna2Separator1.TabIndex = 132;
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(659, 9);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox1.TabIndex = 17;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(17, 16);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(75, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "WebCam";
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(192, 19);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(30, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "FPS:";
			this.pictureBox1.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new global::System.Drawing.Point(0, 54);
			this.pictureBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(703, 411);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.Timer1_Tick);
			this.timerSave.Interval = 1000;
			this.timerSave.Tick += new global::System.EventHandler(this.TimerSave_Tick);
			this.labelWait.AutoSize = true;
			this.labelWait.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.labelWait.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelWait.ForeColor = global::System.Drawing.Color.White;
			this.labelWait.Location = new global::System.Drawing.Point(213, 178);
			this.labelWait.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelWait.Name = "labelWait";
			this.labelWait.Size = new global::System.Drawing.Size(101, 20);
			this.labelWait.TabIndex = 6;
			this.labelWait.Text = "Please wait...";
			this.guna2DragControl1.TargetControl = this.panel1;
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_POSITIVE;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ResizeBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ResizeBox1.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2ResizeBox1.FillColor = global::System.Drawing.Color.Gainsboro;
			this.guna2ResizeBox1.ForeColor = global::System.Drawing.Color.Black;
			this.guna2ResizeBox1.Location = new global::System.Drawing.Point(680, 445);
			this.guna2ResizeBox1.Name = "guna2ResizeBox1";
			this.guna2ResizeBox1.Size = new global::System.Drawing.Size(20, 20);
			this.guna2ResizeBox1.TabIndex = 7;
			this.guna2ResizeBox1.TargetControl = this;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(703, 465);
			base.Controls.Add(this.guna2ResizeBox1);
			base.Controls.Add(this.labelWait);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "FormWebcam";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remote Camera";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.FormWebcam_FormClosed);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Panel panel1;

		public global::System.Windows.Forms.PictureBox pictureBox1;

		public global::System.Windows.Forms.Timer timer1;

		private global::System.Windows.Forms.Timer timerSave;

		public global::System.Windows.Forms.Label labelWait;

		private global::System.Windows.Forms.Label label1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		private global::System.Windows.Forms.Label label2;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator2;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		public global::Guna.UI2.WinForms.Guna2Button button1;

		public global::Guna.UI2.WinForms.Guna2Button btnSave;

		private global::Guna.UI2.WinForms.Guna2ResizeBox guna2ResizeBox1;

		public global::Guna.UI2.WinForms.Guna2NumericUpDown numericUpDown1;

		public global::Guna.UI2.WinForms.Guna2ComboBox comboBox1;
	}
}
