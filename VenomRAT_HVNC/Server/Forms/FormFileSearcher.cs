using System;
using System.Windows.Forms;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormFileSearcher : Form
    {
        public FormFileSearcher()
        {
            this.InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtExtnsions.Text) && this.numericUpDown1.Value > 0m)
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
