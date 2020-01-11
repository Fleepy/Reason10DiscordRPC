using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reason10DRP
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            DiscordRPCStartup.DRPCC();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            void OnProcessExit(object sender, EventArgs e)
            {
                DiscordRPCStartup.ExitDiscordRPC();
            }
        }
        
    }

}
