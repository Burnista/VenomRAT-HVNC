namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormFileSearcher : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormFileSearcher));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2ShadowPanel1 = new global::Guna.UI2.WinForms.Guna2ShadowPanel();
			this.numericUpDown1 = new global::System.Windows.Forms.NumericUpDown();
			this.btnOk = new global::Guna.UI2.WinForms.Guna2Button();
			this.txtExtnsions = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.guna2DragControl2 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2ShadowPanel2 = new global::Guna.UI2.WinForms.Guna2ShadowPanel();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.panel2.SuspendLayout();
			this.guna2ShadowPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			this.guna2ShadowPanel2.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(39, 26);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(34, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type:";
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(39, 78);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(51, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Max size:";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(126, 103);
			this.label3.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(23, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "MB";
			this.guna2DragControl1.TargetControl = this.panel2;
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.panel2.Controls.Add(this.guna2Separator1);
			this.panel2.Controls.Add(this.guna2ShadowPanel1);
			this.panel2.Controls.Add(this.guna2ControlBox1);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(449, 317);
			this.panel2.TabIndex = 7;
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(-2, 50);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(449, 10);
			this.guna2Separator1.TabIndex = 128;
			this.guna2ShadowPanel1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ShadowPanel1.Controls.Add(this.numericUpDown1);
			this.guna2ShadowPanel1.Controls.Add(this.btnOk);
			this.guna2ShadowPanel1.Controls.Add(this.txtExtnsions);
			this.guna2ShadowPanel1.Controls.Add(this.label1);
			this.guna2ShadowPanel1.Controls.Add(this.label3);
			this.guna2ShadowPanel1.Controls.Add(this.label2);
			this.guna2ShadowPanel1.FillColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2ShadowPanel1.Location = new global::System.Drawing.Point(26, 82);
			this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
			this.guna2ShadowPanel1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel1.ShadowShift = 8;
			this.guna2ShadowPanel1.Size = new global::System.Drawing.Size(386, 201);
			this.guna2ShadowPanel1.TabIndex = 127;
			this.numericUpDown1.Location = new global::System.Drawing.Point(42, 100);
			this.numericUpDown1.Margin = new global::System.Windows.Forms.Padding(2);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown1;
			int[] array = new int[4];
			array[0] = 200;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown1;
			int[] array2 = new int[4];
			array2[0] = 1;
			numericUpDown2.Minimum = new decimal(array2);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(80, 20);
			this.numericUpDown1.TabIndex = 128;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown1;
			int[] array3 = new int[4];
			array3[0] = 5;
			numericUpDown3.Value = new decimal(array3);
			this.btnOk.Animated = true;
			this.btnOk.BorderColor = global::System.Drawing.Color.Maroon;
			this.btnOk.CheckedState.Parent = this.btnOk;
			this.btnOk.CustomImages.Parent = this.btnOk;
			this.btnOk.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.btnOk.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.btnOk.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.btnOk.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.btnOk.DisabledState.Parent = this.btnOk;
			this.btnOk.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.btnOk.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnOk.ForeColor = global::System.Drawing.Color.White;
			this.btnOk.HoverState.Parent = this.btnOk;
			this.btnOk.Location = new global::System.Drawing.Point(217, 95);
			this.btnOk.Name = "btnOk";
			this.btnOk.ShadowDecoration.Parent = this.btnOk;
			this.btnOk.Size = new global::System.Drawing.Size(122, 27);
			this.btnOk.TabIndex = 127;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.txtExtnsions.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.txtExtnsions.DefaultText = "";
			this.txtExtnsions.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.txtExtnsions.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.txtExtnsions.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.txtExtnsions.DisabledState.Parent = this.txtExtnsions;
			this.txtExtnsions.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.txtExtnsions.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.txtExtnsions.FocusedState.Parent = this.txtExtnsions;
			this.txtExtnsions.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.txtExtnsions.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.txtExtnsions.HoverState.Parent = this.txtExtnsions;
			this.txtExtnsions.Location = new global::System.Drawing.Point(42, 44);
			this.txtExtnsions.Name = "txtExtnsions";
			this.txtExtnsions.PasswordChar = '\0';
			this.txtExtnsions.PlaceholderForeColor = global::System.Drawing.Color.Black;
			this.txtExtnsions.PlaceholderText = ".txt .pdf .doc";
			this.txtExtnsions.SelectedText = "";
			this.txtExtnsions.ShadowDecoration.Parent = this.txtExtnsions;
			this.txtExtnsions.Size = new global::System.Drawing.Size(297, 23);
			this.txtExtnsions.TabIndex = 8;
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(405, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox1.TabIndex = 10;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(22, 14);
			this.label4.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(103, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "File Searcher";
			this.guna2DragControl2.TargetControl = this.panel2;
			this.guna2ShadowPanel2.BackColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel2.Controls.Add(this.panel2);
			this.guna2ShadowPanel2.FillColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.guna2ShadowPanel2.Location = new global::System.Drawing.Point(0, 0);
			this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
			this.guna2ShadowPanel2.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2ShadowPanel2.ShadowDepth = 8;
			this.guna2ShadowPanel2.ShadowShift = 2;
			this.guna2ShadowPanel2.Size = new global::System.Drawing.Size(449, 317);
			this.guna2ShadowPanel2.TabIndex = 124;
			this.guna2ShadowPanel2.Paint += new global::System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel2_Paint);
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(448, 306);
			base.Controls.Add(this.guna2ShadowPanel2);
			this.DoubleBuffered = true;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormFileSearcher";
			base.ShowInTaskbar = false;
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File Searcher";
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.guna2ShadowPanel1.ResumeLayout(false);
			this.guna2ShadowPanel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			this.guna2ShadowPanel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.Timer timer1;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;

		private global::Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;

		private global::System.Windows.Forms.Panel panel2;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		private global::Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		private global::Guna.UI2.WinForms.Guna2TextBox txtExtnsions;

		private global::Guna.UI2.WinForms.Guna2Button btnOk;

		private global::System.Windows.Forms.Label label4;

		public global::System.Windows.Forms.NumericUpDown numericUpDown1;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
	}
}
