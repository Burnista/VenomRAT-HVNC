using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;

namespace VenomRAT_HVNC.Server.Properties
{
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [DebuggerNonUserCode]
    [CompilerGenerated]
    public class Resources
    {
        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static ResourceManager ResourceManager
        {
            get
            {
                if (Resources.resourceMan == null)
                {
                    ResourceManager resourceManager = new ResourceManager("Server.Properties.Resources", typeof(Resources).Assembly);
                    Resources.resourceMan = resourceManager;
                }
                return Resources.resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static CultureInfo Culture
        {
            get
            {
                return Resources.resourceCulture;
            }
            set
            {
                Resources.resourceCulture = value;
            }
        }

        public static byte[] _7z
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("_7z", Resources.resourceCulture);
                return (byte[])@object;
            }
        }

        public static byte[] _7z1
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("_7z1", Resources.resourceCulture);
                return (byte[])@object;
            }
        }

        public static Bitmap arrow_down
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("arrow_down", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap arrow_up
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("arrow_up", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap avatar
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("avatar", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Icon DcRat
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("DcRat", Resources.resourceCulture);
                return (Icon)@object;
            }
        }

        public static Bitmap DcRat_png
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("DcRat_png", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static byte[] donut
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("donut", Resources.resourceCulture);
                return (byte[])@object;
            }
        }

        public static Bitmap keyboard
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("keyboard", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap keyboard_on
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("keyboard-on", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static byte[] Keylogger
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("Keylogger", Resources.resourceCulture);
                return (byte[])@object;
            }
        }

        public static Bitmap mouse
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("mouse", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap mouse_enable
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("mouse_enable", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static UnmanagedMemoryStream offline
        {
            get
            {
                return Resources.ResourceManager.GetStream("offline", Resources.resourceCulture);
            }
        }

        public static UnmanagedMemoryStream online
        {
            get
            {
                return Resources.ResourceManager.GetStream("online", Resources.resourceCulture);
            }
        }

        public static Bitmap play_button
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("play-button", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap save_image
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("save-image", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap save_image2
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("save-image2", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap settings
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("settings", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static string ShellcodeLoader
        {
            get
            {
                return Resources.ResourceManager.GetString("ShellcodeLoader", Resources.resourceCulture);
            }
        }

        public static Bitmap stop__1_
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("stop (1)", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap tomem
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("tomem", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap tomem1
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("tomem1", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        public static Bitmap uac
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("uac", Resources.resourceCulture);
                return (Bitmap)@object;
            }
        }

        private static ResourceManager resourceMan;

        private static CultureInfo resourceCulture;
    }
}
