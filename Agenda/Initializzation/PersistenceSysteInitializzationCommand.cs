using PersistenceSystem;
using PersistenceSystem.abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Initializzation
{
    class PersistenceSysteInitializzationCommand : IInitializzationCommand
    {
        public void Execute()
        {
            PersistenceSystemConfig psc = CreateObjectFromProperties();
            DBFacade.Instance().InitializeSystem(psc);

        }
        private PersistenceSystemConfig CreateObjectFromProperties()
        {
            PersistenceSystemConfig psc = new PersistenceSystemConfig();
            psc.DBType = Properties.Settings.Default.DBType;
            psc.AccessConnectionString = Properties.Settings.Default.AccessConnectionString;
            psc.SqlConnectionString = Properties.Settings.Default.SqlConnectionString;
            psc.MapperFactoryClassName = Properties.Settings.Default.MapperFactoryClassName;
            psc.MapperFactoryDllName = Properties.Settings.Default.MapperFactoryDllName;
            return psc;
        }
    }
}
