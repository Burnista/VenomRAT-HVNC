namespace VenomRAT_HVNC.HVNC
{
	public partial class FrmTransfer : global::System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(global::VenomRAT_HVNC.HVNC.FrmTransfer));
			this.DuplicateProgess = new global::System.Windows.Forms.ProgressBar();
			this.FileTransferLabel = new global::System.Windows.Forms.Label();
			this.PingTransform = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.DuplicateProgess.Location = new global::System.Drawing.Point(12, 12);
			this.DuplicateProgess.Name = "DuplicateProgess";
			this.DuplicateProgess.Size = new global::System.Drawing.Size(453, 23);
			this.DuplicateProgess.TabIndex = 1;
			this.FileTransferLabel.AutoSize = true;
			this.FileTransferLabel.Location = new global::System.Drawing.Point(225, 44);
			this.FileTransferLabel.Name = "FileTransferLabel";
			this.FileTransferLabel.Size = new global::System.Drawing.Size(37, 13);
			this.FileTransferLabel.TabIndex = 4;
			this.FileTransferLabel.Text = "Status";
			this.PingTransform.AutoSize = true;
			this.PingTransform.Location = new global::System.Drawing.Point(255, 44);
			this.PingTransform.Name = "PingTransform";
			this.PingTransform.Size = new global::System.Drawing.Size(95, 13);
			this.PingTransform.TabIndex = 5;
			this.PingTransform.Text = "Ping: Measuring....";
			this.PingTransform.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(475, 66);
			base.Controls.Add(this.FileTransferLabel);
			base.Controls.Add(this.DuplicateProgess);
			base.Controls.Add(this.PingTransform);
			base.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			base.Name = "FrmTransfer";
			base.Opacity = 0.0;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new global::System.EventHandler(this.FrmTransfer_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.ProgressBar DuplicateProgess;

		private global::System.Windows.Forms.Label FileTransferLabel;

		private global::System.Windows.Forms.Label PingTransform;
	}
}
