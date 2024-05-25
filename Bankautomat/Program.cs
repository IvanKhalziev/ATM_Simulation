using System;
using System.Windows.Forms;

namespace Bankautomat
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WillkommenForm willkommenForm = new WillkommenForm();
            // PinCodeForm pinCodeForm = new PinCodeForm();
            Application.Run(willkommenForm);
        }
    }
}
