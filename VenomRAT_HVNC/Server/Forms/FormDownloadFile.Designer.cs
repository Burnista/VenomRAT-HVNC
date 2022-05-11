namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormDownloadFile : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormDownloadFile));
			this.label1 = new global::System.Windows.Forms.Label();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.labelsize = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labelfile = new global::System.Windows.Forms.Label();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(8, 59);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(64, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Downloaad:";
			this.timer1.Interval = 10000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.labelsize.AutoSize = true;
			this.labelsize.Location = new global::System.Drawing.Point(69, 59);
			this.labelsize.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelsize.Name = "labelsize";
			this.labelsize.Size = new global::System.Drawing.Size(13, 13);
			this.labelsize.TabIndex = 0;
			this.labelsize.Text = "..";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(8, 25);
			this.label3.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(26, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "File:";
			this.labelfile.AutoSize = true;
			this.labelfile.Location = new global::System.Drawing.Point(69, 25);
			this.labelfile.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelfile.Name = "labelfile";
			this.labelfile.Size = new global::System.Drawing.Size(13, 13);
			this.labelfile.TabIndex = 0;
			this.labelfile.Text = "..";
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			base.ClientSize = new global::System.Drawing.Size(442, 167);
			base.Controls.Add(this.labelfile);
			base.Controls.Add(this.labelsize);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormDownloadFile";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Download";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.SocketDownload_FormClosed);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		public global::System.Windows.Forms.Timer timer1;

		public global::System.Windows.Forms.Label labelsize;

		private global::System.Windows.Forms.Label label3;

		public global::System.Windows.Forms.Label labelfile;

		public global::System.Windows.Forms.Label label1;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
	}
}
