using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SandwichLibrary;

namespace ElevatedTrackSandwiches
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
            Welcome W = new Welcome();
            Application.Run(W);
        }
    }
}
