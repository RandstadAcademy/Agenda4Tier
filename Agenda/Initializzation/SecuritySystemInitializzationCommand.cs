using AgendaServices;
using SecuritySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Initializzation
{
    class SecuritySystemInitializzationCommand : IInitializzationCommand
    {
        public void Execute()
        {
            SimpleSecurityManager ssm = SimpleSecurityManager.Instance();
            ISecurityStore store = new SecurityStore();
            ssm.Initialize(store);

        }
    }
}
