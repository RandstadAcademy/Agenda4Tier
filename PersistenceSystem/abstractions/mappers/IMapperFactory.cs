using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.abstractions.mappers
{
    public interface IMapperFactory
    {
        IDBMapper GetMapperByName(string type, string dbType);
    }
}
