using System;
using System.Windows.Forms;
using VenomRAT_HVNC.Server.Forms;

namespace VenomRAT_HVNC.Server
{
    // Token: 0x02000033 RID: 51
    internal static class Program
    {
        // Token: 0x060001C9 RID: 457 RVA: 0x00019554 File Offset: 0x00019554
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            Program.form1 = new Form1();
            Application.Run(Program.form1);
        }

        // Token: 0x040001C3 RID: 451
        public static Form1 form1;
    }
}