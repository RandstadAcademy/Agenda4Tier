using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData.mermec.abstractions.mappers
{
    interface IDBMapper
    {
        AbstractDomainObject GetById(int Id);
        List<AbstractDomainObject> GetAll();
        void SaveOrUpdate(AbstractDomainObject data);
        void Delete(AbstractDomainObject data);
    }
}
