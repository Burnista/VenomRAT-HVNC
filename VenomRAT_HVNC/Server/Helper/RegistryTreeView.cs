using System.Windows.Forms;

namespace VenomRAT_HVNC.Server.Helper
{
    public class RegistryTreeView : TreeView
    {
        public RegistryTreeView()
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
