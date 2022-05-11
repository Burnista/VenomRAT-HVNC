using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormCertificate : Form
    {
        public FormCertificate()
        {
            this.InitializeComponent();
        }

        private void FormCertificate_Load(object sender, EventArgs e)
        {
            try
            {
                string text = Application.StartupPath + "\\BackupCertificate.zip";
                if (File.Exists(text))
                {
                    MessageBox.Show(this, "Found a zip backup, Extracting (BackupCertificate.zip)", "Certificate backup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ZipFile.ExtractToDirectory(text, Application.StartupPath);
                    Settings.ServerCertificate = new X509Certificate2(Settings.CertificatePath);
                    base.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.textBox1.Text))
                {
                    this.button1.Text = "Please wait";
                    this.button1.Enabled = false;
                    this.textBox1.Enabled = false;
                    await Task.Run(delegate ()
                    {
                        try
                        {
                            string text = Application.StartupPath + "\\BackupCertificate.zip";
                            Settings.ServerCertificate = CreateCertificate.CreateCertificateAuthority(this.textBox1.Text, 1024);
                            File.WriteAllBytes(Settings.CertificatePath, Settings.ServerCertificate.Export(X509ContentType.Pfx));
                            Program.form1.listView1.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                MessageBox.Show(this, "Do not forget to Save The BackupCertificate.zip", "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                base.Close();
                            }));
                        }
                        catch (Exception ex2)
                        {
                            Exception ex3 = ex2;
                            Exception ex = ex3;
                            Program.form1.listView1.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.button1.Text = "OK";
                                this.button1.Enabled = true;
                                this.textBox1.Enabled = true;
                            }));
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.button1.Text = "Ok";
                this.button1.Enabled = true;
            }
        }
    }
}
