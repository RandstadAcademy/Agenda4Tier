using Agenda.Initializzation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {

            InitializzationFactory.ConstructInitAppCommand().Execute();
            //verifichiamo che sia il primo avvio
            FirstRunInitializzation();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }

        private static void FirstRunInitializzation()
        {
            bool firstStart = Properties.Settings.Default.FirstTimeApp;
            //if (firstStart)
            //{
                IInitializzationCommand cmd = InitializzationFactory.ConstructFirstAppRunCommand();
                cmd.Execute();
                Properties.Settings.Default.FirstTimeApp = false;
                //Properties.Settings.Default.Save();
            //}
        }
    }
}
