using AgendaData.mermec.concreteMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData.mermec.abstractions.mappers
{
    class MapperFactory
    {
        public static IDBMapper GetMapperByName(string type, string dbType)
        {
            if (type.Equals("Contatto"))
            {
               
                return new DBContatto(dbType);
               
            }


            return null;

        }
    }
}
