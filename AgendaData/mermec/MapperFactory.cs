using AgendaData.mermec.concreteMappers;
using AgendaDomain.Security;
using PersistenceSystem.abstractions.mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData.mermec
{
    public class MapperFactory : IMapperFactory
    {
        public IDBMapper GetMapperByName(string type, string dbType)
        {
            if (type.Equals("Contatto"))
            {
                return new DBContatto(dbType);
            }
            else if (type.Equals("Messaggio"))
            {
                return new DBMessaggio(dbType);
            }
            else if (type.Equals("Ruolo"))
            {
                return new RuoloMapper(dbType);
            }
            else if (type.Equals("Utente"))
            {
                return new UtenteMapper(dbType);
            }
            return null;
        }
    }
}
