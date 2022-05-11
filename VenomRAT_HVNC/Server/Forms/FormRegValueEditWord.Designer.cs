namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormRegValueEditWord : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormRegValueEditWord));
			this.baseBox = new global::System.Windows.Forms.GroupBox();
			this.radioDecimal = new global::System.Windows.Forms.RadioButton();
			this.radioHexa = new global::System.Windows.Forms.RadioButton();
			this.label2 = new global::System.Windows.Forms.Label();
			this.valueNameTxtBox = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.valueDataTxtBox = new global::VenomRAT_HVNC.Server.Helper.WordTextBox();
			this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2ControlBox1 = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.guna2Separator2 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.label3 = new global::System.Windows.Forms.Label();
			this.cancelButton = new global::Guna.UI2.WinForms.Guna2Button();
			this.okButton = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.baseBox.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			base.SuspendLayout();
			this.baseBox.Controls.Add(this.radioDecimal);
			this.baseBox.Controls.Add(this.radioHexa);
			this.baseBox.ForeColor = global::System.Drawing.Color.White;
			this.baseBox.Location = new global::System.Drawing.Point(190, 103);
			this.baseBox.Name = "baseBox";
			this.baseBox.Size = new global::System.Drawing.Size(156, 68);
			this.baseBox.TabIndex = 14;
			this.baseBox.TabStop = false;
			this.baseBox.Text = "Base";
			this.radioDecimal.AutoSize = true;
			this.radioDecimal.Location = new global::System.Drawing.Point(14, 43);
			this.radioDecimal.Name = "radioDecimal";
			this.radioDecimal.Size = new global::System.Drawing.Size(63, 17);
			this.radioDecimal.TabIndex = 4;
			this.radioDecimal.Text = "Decimal";
			this.radioDecimal.UseVisualStyleBackColor = true;
			this.radioHexa.AutoSize = true;
			this.radioHexa.Checked = true;
			this.radioHexa.Location = new global::System.Drawing.Point(14, 18);
			this.radioHexa.Name = "radioHexa";
			this.radioHexa.Size = new global::System.Drawing.Size(86, 17);
			this.radioHexa.TabIndex = 3;
			this.radioHexa.TabStop = true;
			this.radioHexa.Text = "Hexadecimal";
			this.radioHexa.UseVisualStyleBackColor = true;
			this.label2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(9, 103);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(61, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Value data:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.valueNameTxtBox.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.valueNameTxtBox.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.valueNameTxtBox.ForeColor = global::System.Drawing.Color.White;
			this.valueNameTxtBox.Location = new global::System.Drawing.Point(12, 75);
			this.valueNameTxtBox.Name = "valueNameTxtBox";
			this.valueNameTxtBox.ReadOnly = true;
			this.valueNameTxtBox.Size = new global::System.Drawing.Size(401, 20);
			this.valueNameTxtBox.TabIndex = 13;
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(9, 58);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(66, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Value name:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.valueDataTxtBox.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			this.valueDataTxtBox.ForeColor = global::System.Drawing.Color.White;
			this.valueDataTxtBox.IsHexNumber = false;
			this.valueDataTxtBox.Location = new global::System.Drawing.Point(13, 121);
			this.valueDataTxtBox.MaxLength = 8;
			this.valueDataTxtBox.Name = "valueDataTxtBox";
			this.valueDataTxtBox.Size = new global::System.Drawing.Size(171, 20);
			this.valueDataTxtBox.TabIndex = 17;
			this.valueDataTxtBox.Type = global::VenomRAT_HVNC.Server.Helper.WordTextBox.WordType.DWORD;
			this.guna2Panel1.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
			this.guna2Panel1.Controls.Add(this.guna2Separator2);
			this.guna2Panel1.Controls.Add(this.guna2Separator1);
			this.guna2Panel1.Controls.Add(this.label3);
			this.guna2Panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.guna2Panel1.Location = new global::System.Drawing.Point(0, 0);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
			this.guna2Panel1.Size = new global::System.Drawing.Size(429, 49);
			this.guna2Panel1.TabIndex = 134;
			this.guna2ControlBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.guna2ControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.IconColor = global::System.Drawing.Color.White;
			this.guna2ControlBox1.Location = new global::System.Drawing.Point(385, 12);
			this.guna2ControlBox1.Name = "guna2ControlBox1";
			this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
			this.guna2ControlBox1.Size = new global::System.Drawing.Size(41, 32);
			this.guna2ControlBox1.TabIndex = 131;
			this.guna2Separator2.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator2.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator2.FillThickness = 2;
			this.guna2Separator2.Location = new global::System.Drawing.Point(0, 41);
			this.guna2Separator2.Name = "guna2Separator2";
			this.guna2Separator2.Size = new global::System.Drawing.Size(429, 12);
			this.guna2Separator2.TabIndex = 130;
			this.guna2Separator1.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2Separator1.FillStyle = global::System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Separator1.FillThickness = 2;
			this.guna2Separator1.Location = new global::System.Drawing.Point(0, -4);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(429, 12);
			this.guna2Separator1.TabIndex = 130;
			this.label3.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(15, 12);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(158, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Reg Value Edit Word";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelButton.Animated = true;
			this.cancelButton.BorderColor = global::System.Drawing.Color.Maroon;
			this.cancelButton.CheckedState.Parent = this.cancelButton;
			this.cancelButton.CustomImages.Parent = this.cancelButton;
			this.cancelButton.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.cancelButton.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.cancelButton.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.cancelButton.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.cancelButton.DisabledState.Parent = this.cancelButton;
			this.cancelButton.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.cancelButton.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cancelButton.ForeColor = global::System.Drawing.Color.White;
			this.cancelButton.HoverState.Parent = this.cancelButton;
			this.cancelButton.Location = new global::System.Drawing.Point(272, 177);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.ShadowDecoration.Parent = this.cancelButton;
			this.cancelButton.Size = new global::System.Drawing.Size(74, 27);
			this.cancelButton.TabIndex = 135;
			this.cancelButton.Text = "Cancel";
			this.okButton.Animated = true;
			this.okButton.BorderColor = global::System.Drawing.Color.Maroon;
			this.okButton.CheckedState.Parent = this.okButton;
			this.okButton.CustomImages.Parent = this.okButton;
			this.okButton.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.okButton.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.okButton.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.okButton.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.okButton.DisabledState.Parent = this.okButton;
			this.okButton.FillColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.okButton.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.okButton.ForeColor = global::System.Drawing.Color.White;
			this.okButton.HoverState.Parent = this.okButton;
			this.okButton.Location = new global::System.Drawing.Point(190, 177);
			this.okButton.Name = "okButton";
			this.okButton.ShadowDecoration.Parent = this.okButton;
			this.okButton.Size = new global::System.Drawing.Size(74, 27);
			this.okButton.TabIndex = 136;
			this.okButton.Text = "OK";
			this.guna2BorderlessForm1.AnimateWindow = true;
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_NEGATIVE;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			this.guna2BorderlessForm1.ShadowColor = global::System.Drawing.Color.FromArgb(8, 104, 81);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(24, 24, 24);
			base.ClientSize = new global::System.Drawing.Size(429, 222);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.guna2Panel1);
			base.Controls.Add(this.valueDataTxtBox);
			base.Controls.Add(this.baseBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.valueNameTxtBox);
			base.Controls.Add(this.label1);
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Name = "FormRegValueEditWord";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormRegValueEditWord";
			this.baseBox.ResumeLayout(false);
			this.baseBox.PerformLayout();
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.GroupBox baseBox;

		private global::System.Windows.Forms.RadioButton radioDecimal;

		private global::System.Windows.Forms.RadioButton radioHexa;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.TextBox valueNameTxtBox;

		private global::System.Windows.Forms.Label label1;

		private global::VenomRAT_HVNC.Server.Helper.WordTextBox valueDataTxtBox;

		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		private global::Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator2;

		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		private global::System.Windows.Forms.Label label3;

		private global::Guna.UI2.WinForms.Guna2Button cancelButton;

		private global::Guna.UI2.WinForms.Guna2Button okButton;

		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
	}
}
