using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VenomRAT_HVNC.HVNC.WebBuilder;
using KeyAuth;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormLogin
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            bool penis = true;
            if (penis)
            {
                if (!File.Exists("License.Venom"))
                {
                    File.WriteAllText("License.Venom", key.Text.Replace(" ", "").Replace("\t", ""));
                }
                Form1.islogin = true;
                WebBuilder.Username = key.Text.Replace(" ", "").Replace("\t", "");
                Close();
                MessageBox.Show(@"Login Success!", @"Venom RAT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Form1.islogin)
            {
                Environment.Exit(0);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Process.Start("https://venomcontrol.com/");
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/venomrat");
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists("License.Venom"))
            {
                string text = File.ReadAllText("License.Venom").Replace(" ", "").Replace("\t", "");
                key.Text = text;
            }
        }

		private static string name = "Venom HVNC";

		// Token: 0x0400051A RID: 1306
		private static string ownerid = "C8NXBjbe6J";

		// Token: 0x0400051B RID: 1307
		private static string secret = "7333ff725ddb0d1598f5022c5ea48ac7515aa705a219e847dfe2d24398670b27";

		// Token: 0x0400051C RID: 1308
		private static string version = "5.0.4";

        public static api KeyAuthApp = new api(name, ownerid, secret, version);
    }
}
