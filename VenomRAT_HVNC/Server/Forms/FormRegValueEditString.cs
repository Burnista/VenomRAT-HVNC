using System;
using System.Windows.Forms;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormRegValueEditString : Form
    {
        public FormRegValueEditString(RegistrySeeker.RegValueData value)
        {
            this._value = value;
            this.InitializeComponent();
            this.valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
            this.valueDataTxtBox.Text = global::VenomRAT_HVNC.Server.Helper.ByteConverter.ToString(value.Data);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this._value.Data = global::VenomRAT_HVNC.Server.Helper.ByteConverter.GetBytes(this.valueDataTxtBox.Text);
            base.Tag = this._value;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private readonly RegistrySeeker.RegValueData _value;
    }
}
