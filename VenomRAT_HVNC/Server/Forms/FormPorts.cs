using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Interfaces;
using Server;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Forms
{
    public class FormPorts : Form
    {
        private static bool isOK;
        private IContainer components;
        private Panel panel2;
        private Guna2ControlBox guna2ControlBox1;
        private Guna2DragControl guna2DragControl1;
        private Guna2Button button1;
        private Guna2ShadowPanel guna2ShadowPanel1;
        private Guna2Separator guna2Separator1;
        private Guna2ShadowPanel guna2ShadowPanel2;
        private Label label1;
        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2NumericUpDown textPorts;

        public FormPorts()
        {
            this.InitializeComponent();
            this.Opacity = 0.0;
        }

        private void PortsFrm_Load(object sender, EventArgs e)
        {
            _ = Methods.FadeIn(this, 5);
            this.Text = Settings.Version + " | Welcome " + Environment.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Ports = this.textPorts.Value.ToString();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.SavedPort = this.textPorts.Value.ToString();
            Properties.Settings.Default.Save();
            FormPorts.isOK = true;
            this.Close();
        }

        private void PortsFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FormPorts.isOK)
                return;
            Program.form1.notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(((Control)this.textPorts).Text.Trim());
            }
            catch
            {
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.textPorts = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel2.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPorts)).BeginInit();
            this.guna2ShadowPanel2.SuspendLayout();
            this.SuspendLayout();
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.guna2Separator1);
            this.panel2.Controls.Add(this.guna2ShadowPanel1);
            this.panel2.Controls.Add(this.guna2ControlBox1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 464);
            this.panel2.TabIndex = 7;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 25);
            this.label1.TabIndex = 129;
            this.label1.Text = "Venom RAT Start Port Listening";
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2Separator1.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 60);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(929, 25);
            this.guna2Separator1.TabIndex = 128;
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.textPorts);
            this.guna2ShadowPanel1.Controls.Add(this.button1);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2ShadowPanel1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(52, 113);
            this.guna2ShadowPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2ShadowPanel1.ShadowShift = 8;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(825, 305);
            this.guna2ShadowPanel1.TabIndex = 127;
            this.textPorts.BackColor = System.Drawing.Color.Transparent;
            this.textPorts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.textPorts.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textPorts.DisabledState.Parent = this.textPorts;
            this.textPorts.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.textPorts.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(143)))), ((int)(((byte)(110)))));
            this.textPorts.FocusedState.Parent = this.textPorts;
            this.textPorts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textPorts.ForeColor = System.Drawing.Color.Gainsboro;
            this.textPorts.Location = new System.Drawing.Point(512, 134);
            this.textPorts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textPorts.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.textPorts.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.textPorts.Name = "textPorts";
            this.textPorts.ShadowDecoration.Parent = this.textPorts;
            this.textPorts.Size = new System.Drawing.Size(105, 33);
            this.textPorts.TabIndex = 128;
            this.textPorts.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.textPorts.UpDownButtonForeColor = System.Drawing.Color.Gainsboro;
            this.textPorts.Value = new decimal(new int[] {
            4444,
            0,
            0,
            0});
            this.button1.Animated = true;
            this.button1.BorderColor = System.Drawing.Color.Maroon;
            this.button1.CheckedState.Parent = this.button1;
            this.button1.CustomImages.Parent = this.button1;
            this.button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button1.DisabledState.Parent = this.button1;
            this.button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.HoverState.Parent = this.button1;
            this.button1.Location = new System.Drawing.Point(189, 133);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.ShadowDecoration.Parent = this.button1;
            this.button1.Size = new System.Drawing.Size(300, 34);
            this.button1.TabIndex = 126;
            this.button1.Text = "Port Listening";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(871, 15);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(55, 39);
            this.guna2ControlBox1.TabIndex = 10;
            this.guna2DragControl1.TargetControl = this.panel2;
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2ShadowPanel2.Controls.Add(this.panel2);
            this.guna2ShadowPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2ShadowPanel2.ShadowDepth = 8;
            this.guna2ShadowPanel2.ShadowShift = 2;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(955, 489);
            this.guna2ShadowPanel2.TabIndex = 8;
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.5D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 489);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPorts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listen ports";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PortsFrm_FormClosed);
            this.Load += new System.EventHandler(this.PortsFrm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textPorts)).EndInit();
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
