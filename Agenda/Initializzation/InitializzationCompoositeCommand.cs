using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Initializzation
{
    class InitializzationCompoositeCommand : IInitializzationCommand
    {
        private List<IInitializzationCommand> _commands = new List<IInitializzationCommand>();

        public void Add(IInitializzationCommand cmd)
        {
            _commands.Add(cmd);
        }

        public void Execute()
        {
            foreach (var item in _commands)
            {
                item.Execute();
            }
        }
    }
}
