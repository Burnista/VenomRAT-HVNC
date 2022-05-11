using System;
using System.Windows.Forms;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormRegValueEditMultiString : Form
    {
        public FormRegValueEditMultiString(RegistrySeeker.RegValueData value)
        {
            this._value = value;
            this.InitializeComponent();
            this.valueNameTxtBox.Text = value.Name;
            this.valueDataTxtBox.Text = string.Join("\r\n", global::VenomRAT_HVNC.Server.Helper.ByteConverter.ToStringArray(value.Data));
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this._value.Data = global::VenomRAT_HVNC.Server.Helper.ByteConverter.GetBytes(this.valueDataTxtBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            base.Tag = this._value;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private readonly RegistrySeeker.RegValueData _value;
    }
}
