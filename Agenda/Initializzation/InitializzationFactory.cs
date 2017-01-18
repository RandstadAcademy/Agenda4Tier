using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Initializzation
{
    class InitializzationFactory
    {
        public static IInitializzationCommand ConstructInitAppCommand()
        {
            InitializzationCompoositeCommand cmd = new InitializzationCompoositeCommand();
            cmd.Add(new PersistenceSysteInitializzationCommand());
            cmd.Add(new SecuritySystemInitializzationCommand());
       

            return cmd;
        }
        public static IInitializzationCommand ConstructFirstAppRunCommand()
        {
            InitializzationCompoositeCommand cmd = new InitializzationCompoositeCommand();
            cmd.Add(new RoleCreationCommand());
            cmd.Add(new CreateAdministratorCommand());
            
            return cmd;
        }
       
    }
}
