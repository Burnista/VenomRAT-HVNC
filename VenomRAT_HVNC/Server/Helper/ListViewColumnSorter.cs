using System.Collections;
using System.Windows.Forms;

namespace VenomRAT_HVNC.Server.Helper
{
    public class ListViewColumnSorter : IComparer
    {
        public ListViewColumnSorter()
        {
            this.ColumnToSort = 0;
            this.OrderOfSort = SortOrder.None;
            this.ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            ListViewItem listViewItem = (ListViewItem)x;
            ListViewItem listViewItem2 = (ListViewItem)y;
            int num = this.ObjectCompare.Compare(listViewItem.SubItems[this.ColumnToSort].Text, listViewItem2.SubItems[this.ColumnToSort].Text);
            if (this.OrderOfSort == SortOrder.Ascending)
            {
                return num;
            }
            if (this.OrderOfSort == SortOrder.Descending)
            {
                return -num;
            }
            return 0;
        }

        public int SortColumn
        {
            get
            {
                return this.ColumnToSort;
            }
            set
            {
                this.ColumnToSort = value;
            }
        }

        public SortOrder Order
        {
            get
            {
                return this.OrderOfSort;
            }
            set
            {
                this.OrderOfSort = value;
            }
        }

        private int ColumnToSort;

        private SortOrder OrderOfSort;

        private CaseInsensitiveComparer ObjectCompare;
    }
}
