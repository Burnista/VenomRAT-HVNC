using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace VenomRAT_HVNC.HVNC
{
    public partial class FrmTransfer : Form
    {
        public ProgressBar DuplicateProgesse
        {
            get
            {
                return this.DuplicateProgess;
            }
            set
            {
                this.DuplicateProgess = value;
            }
        }

        public Label FileTransferLabele
        {
            get
            {
                return this.FileTransferLabel;
            }
            set
            {
                this.FileTransferLabel = value;
            }
        }

        public Label PingTransfor
        {
            get
            {
                return this.PingTransform;
            }
            set
            {
                this.PingTransform = value;
            }
        }

        public FrmTransfer()
        {
            this.int_0 = 0;
            this.InitializeComponent();
        }

        private void FrmTransfer_Load(object sender, EventArgs e)
        {
        }

        public void DuplicateProfile(int int_1)
        {
            if (int_1 > this.int_0)
            {
                int_1 = this.int_0;
            }
            this.FileTransferLabel.Text = Conversions.ToString(int_1) + " / " + Conversions.ToString(this.int_0) + " MB";
            this.DuplicateProgess.Value = int_1;
        }

        public int int_0;
    }
}
