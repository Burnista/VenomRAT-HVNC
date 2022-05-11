namespace VenomRAT_HVNC.Server.Forms
{
	// Token: 0x02000091 RID: 145
	public partial class FormLogin : global::System.Windows.Forms.Form
	{
		// Token: 0x06000580 RID: 1408 RVA: 0x0004185A File Offset: 0x0004185A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0004187C File Offset: 0x0004187C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2Separator2 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.label1 = new global::System.Windows.Forms.Label();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2ShadowPanel1 = new global::Guna.UI2.WinForms.Guna2ShadowPanel();
			this.guna2GradientButton1 = new global::Guna.UI2.WinForms.Guna2GradientButton();
			this.guna2GradientButton2 = new global::Guna.UI2.WinForms.Guna2GradientButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.key = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.loginBtn = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.guna2Panel1.SuspendLayout();
			this.guna2ShadowPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.guna2DragControl1.TargetControl = this.guna2Panel1;
			this.guna2Panel1.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2Panel1.Controls.Add(this.guna2Separator2);
			this.guna2Panel1.Controls.Add(this.label1);
			this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
			this.guna2Panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.guna2Panel1.Location = new global::System.Drawing.Point(0, 0);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
			this.guna2Panel1.Size = new global::System.Drawing.Size(679, 57);
			this.guna2Panel1.TabIndex = 148;
			this.guna2Separator2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2Separator2.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator2.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator2.FillThickness = 4;
			this.guna2Separator2.Location = new global::System.Drawing.Point(0, -3);
			this.guna2Separator2.Name = "guna2Separator2";
			this.guna2Separator2.Size = new global::System.Drawing.Size(679, 10);
			this.guna2Separator2.TabIndex = 153;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(6, 15);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(226, 24);
			this.label1.TabIndex = 144;
			this.label1.Text = "Venom RAT/HVNC Login";
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(630, 7);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox1.TabIndex = 143;
			this.guna2ShadowPanel1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ShadowPanel1.Controls.Add(this.guna2GradientButton1);
			this.guna2ShadowPanel1.Controls.Add(this.guna2GradientButton2);
			this.guna2ShadowPanel1.Controls.Add(this.label3);
			this.guna2ShadowPanel1.Controls.Add(this.label2);
			this.guna2ShadowPanel1.Controls.Add(this.key);
			this.guna2ShadowPanel1.Controls.Add(this.pictureBox1);
			this.guna2ShadowPanel1.Controls.Add(this.guna2Panel1);
			this.guna2ShadowPanel1.Controls.Add(this.loginBtn);
			this.guna2ShadowPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.guna2ShadowPanel1.FillColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2ShadowPanel1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.guna2ShadowPanel1.Location = new global::System.Drawing.Point(0, 0);
			this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
			this.guna2ShadowPanel1.ShadowColor = global::System.Drawing.Color.Black;
			this.guna2ShadowPanel1.ShadowDepth = 20;
			this.guna2ShadowPanel1.ShadowShift = 2;
			this.guna2ShadowPanel1.Size = new global::System.Drawing.Size(679, 331);
			this.guna2ShadowPanel1.TabIndex = 0;
			this.guna2GradientButton1.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2GradientButton1.BorderThickness = 1;
			this.guna2GradientButton1.CheckedState.Parent = this.guna2GradientButton1;
			this.guna2GradientButton1.CustomImages.Parent = this.guna2GradientButton1;
			this.guna2GradientButton1.DisabledState.Parent = this.guna2GradientButton1;
			this.guna2GradientButton1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2GradientButton1.FillColor2 = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2GradientButton1.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.guna2GradientButton1.ForeColor = global::System.Drawing.Color.White;
			this.guna2GradientButton1.GradientMode = global::System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.guna2GradientButton1.HoverState.Parent = this.guna2GradientButton1;
			this.guna2GradientButton1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("guna2GradientButton1.Image");
			this.guna2GradientButton1.ImageSize = new global::System.Drawing.Size(25, 25);
			this.guna2GradientButton1.Location = new global::System.Drawing.Point(630, 296);
			this.guna2GradientButton1.Name = "guna2GradientButton1";
			this.guna2GradientButton1.ShadowDecoration.Parent = this.guna2GradientButton1;
			this.guna2GradientButton1.Size = new global::System.Drawing.Size(43, 32);
			this.guna2GradientButton1.TabIndex = 152;
			this.guna2GradientButton1.Click += new global::System.EventHandler(this.guna2GradientButton1_Click);
			this.guna2GradientButton2.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2GradientButton2.BorderThickness = 1;
			this.guna2GradientButton2.CheckedState.Parent = this.guna2GradientButton2;
			this.guna2GradientButton2.CustomImages.Parent = this.guna2GradientButton2;
			this.guna2GradientButton2.DisabledState.Parent = this.guna2GradientButton2;
			this.guna2GradientButton2.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2GradientButton2.FillColor2 = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2GradientButton2.Font = new global::System.Drawing.Font("Segoe UI", 9.75f);
			this.guna2GradientButton2.ForeColor = global::System.Drawing.Color.White;
			this.guna2GradientButton2.GradientMode = global::System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.guna2GradientButton2.HoverState.Parent = this.guna2GradientButton2;
			this.guna2GradientButton2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("guna2GradientButton2.Image");
			this.guna2GradientButton2.ImageSize = new global::System.Drawing.Size(25, 25);
			this.guna2GradientButton2.Location = new global::System.Drawing.Point(582, 296);
			this.guna2GradientButton2.Name = "guna2GradientButton2";
			this.guna2GradientButton2.ShadowDecoration.Parent = this.guna2GradientButton2;
			this.guna2GradientButton2.Size = new global::System.Drawing.Size(43, 32);
			this.guna2GradientButton2.TabIndex = 151;
			this.guna2GradientButton2.Click += new global::System.EventHandler(this.guna2GradientButton2_Click);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(4, 143, 110);
			this.label3.Location = new global::System.Drawing.Point(62, 310);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(35, 16);
			this.label3.TabIndex = 144;
			this.label3.Text = "5.0.4";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(7, 310);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(57, 16);
			this.label2.TabIndex = 144;
			this.label2.Text = "Version:";
			this.key.BorderColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.key.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.key.DefaultText = "";
			this.key.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.key.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.key.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.key.DisabledState.Parent = this.key;
			this.key.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.key.FillColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.key.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(4, 143, 110);
			this.key.FocusedState.Parent = this.key;
			this.key.Font = new global::System.Drawing.Font("Segoe UI", 9.75f);
			this.key.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.key.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(4, 143, 110);
			this.key.HoverState.Parent = this.key;
			this.key.Location = new global::System.Drawing.Point(170, 195);
			this.key.Name = "key";
			this.key.PasswordChar = '\0';
			this.key.PlaceholderForeColor = global::System.Drawing.Color.Gainsboro;
			this.key.PlaceholderText = "Enter your license";
			this.key.SelectedText = "";
			this.key.ShadowDecoration.Parent = this.key;
			this.key.Size = new global::System.Drawing.Size(356, 31);
			this.key.TabIndex = 150;
			this.key.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.key.Load += new global::System.EventHandler(this.Login_Load);
			this.pictureBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox1.ErrorImage = null;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new global::System.Drawing.Point(43, 75);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(590, 93);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 149;
			this.pictureBox1.TabStop = false;
			this.loginBtn.Animated = true;
			this.loginBtn.BackColor = global::System.Drawing.Color.Violet;
			this.loginBtn.BorderColor = global::System.Drawing.Color.Maroon;
			this.loginBtn.CheckedState.Parent = this.loginBtn;
			this.loginBtn.CustomImages.Parent = this.loginBtn;
			this.loginBtn.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.loginBtn.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.loginBtn.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.loginBtn.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.loginBtn.DisabledState.Parent = this.loginBtn;
			this.loginBtn.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.loginBtn.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.loginBtn.ForeColor = global::System.Drawing.Color.White;
			this.loginBtn.HoverState.Parent = this.loginBtn;
			this.loginBtn.Location = new global::System.Drawing.Point(170, 246);
			this.loginBtn.Name = "loginBtn";
			this.loginBtn.ShadowDecoration.Parent = this.loginBtn;
			this.loginBtn.Size = new global::System.Drawing.Size(356, 32);
			this.loginBtn.TabIndex = 147;
			this.loginBtn.Text = "Login";
			this.loginBtn.Click += new global::System.EventHandler(this.loginBtn_Click);
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(2, 196, 150);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(2, 196, 150);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(37, 37, 37);
			base.ClientSize = new global::System.Drawing.Size(679, 331);
			base.Controls.Add(this.guna2ShadowPanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormLogin";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
			base.Load += new global::System.EventHandler(this.FormLogin_Load);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			this.guna2ShadowPanel1.ResumeLayout(false);
			this.guna2ShadowPanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400051E RID: 1310
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400051F RID: 1311
		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		// Token: 0x04000520 RID: 1312
		private global::Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;

		// Token: 0x04000521 RID: 1313
		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		// Token: 0x04000522 RID: 1314
		private global::Guna.UI2.WinForms.Guna2Button loginBtn;

		// Token: 0x04000523 RID: 1315
		private global::Guna.UI2.WinForms.Guna2TextBox key;

		// Token: 0x04000524 RID: 1316
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000525 RID: 1317
		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		// Token: 0x04000526 RID: 1318
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000527 RID: 1319
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		// Token: 0x04000528 RID: 1320
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000529 RID: 1321
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400052A RID: 1322
		private global::Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;

		// Token: 0x0400052B RID: 1323
		private global::Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;

		// Token: 0x0400052C RID: 1324
		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator2;
	}
}
