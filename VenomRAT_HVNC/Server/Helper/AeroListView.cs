using System;
using System.Windows.Forms;

namespace VenomRAT_HVNC.Server.Helper
{
    internal class AeroListView : ListView
    {
        public static int MakeWin32Long(short wLow, short wHigh)
        {
            return ((int)wLow << 16) | (int)wHigh;
        }

        private ListViewColumnSorter LvwColumnSorter { get; set; }

        public AeroListView()
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.LvwColumnSorter = new ListViewColumnSorter();
            base.ListViewItemSorter = this.LvwColumnSorter;
            base.View = View.Details;
            base.FullRowSelect = true;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
            {
                NativeMethods.SetWindowTheme(base.Handle, "explorer", null);
            }
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5)
            {
                NativeMethods.SendMessage(base.Handle, 295U, this._removeDots, IntPtr.Zero);
            }
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);
            if (e.Column == this.LvwColumnSorter.SortColumn)
            {
                this.LvwColumnSorter.Order = ((this.LvwColumnSorter.Order == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending);
            }
            else
            {
                this.LvwColumnSorter.SortColumn = e.Column;
                this.LvwColumnSorter.Order = SortOrder.Ascending;
            }
            if (!base.VirtualMode)
            {
                base.Sort();
            }
        }

        private const uint WM_CHANGEUISTATE = 295U;

        private const short UIS_SET = 1;

        private const short UISF_HIDEFOCUS = 1;

        private readonly IntPtr _removeDots = new IntPtr(AeroListView.MakeWin32Long(1, 1));
    }
}
