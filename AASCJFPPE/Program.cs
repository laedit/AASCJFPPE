using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace AASCJFPPE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#if DEBUG 
            AASCJFPPE.Properties.Settings.Default.PENom = "KERFYSER";
            AASCJFPPE.Properties.Settings.Default.PEPrenom = "Florence";
#endif
            InitializeApplication();

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                // TODO Temporary solution
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO Temporary solution
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine(DateTime.Now);
                writer.WriteLine(e.ExceptionObject.ToString());
            }
        }


        /// <summary>
        /// Initializes the application.
        /// </summary>
        private static void InitializeApplication()
        {
            if (String.IsNullOrEmpty(AASCJFPPE.Properties.Settings.Default.PENom))
            {
                SettingsForm sf = new SettingsForm();
                sf.ShowDialog();
            }
        }

    }
}
