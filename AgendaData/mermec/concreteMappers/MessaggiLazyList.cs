using AgendaDomain;
using PersistenceSystem.abstractions;
using PersistenceSystem.abstractions.mappers;
using PersistenceSystem.querying;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData.mermec.concreteMappers
{
    public class MessaggiLazyList : VirtualLazyList<Messaggio>
    {
        protected int _contactId;
        public MessaggiLazyList(AbstractMapper loader, int contactId)
            :base(loader)
        {

            _contactId = contactId;
        }
       

        public override List<Messaggio> GetData()
        {
            Debug.WriteLine("Entering GetData. Number of data: ");
            Query q = DBFacade.Instance().CreateQuery();
            q.AddCriteria(CriteriaFactory.EqualsCriteria("Id_Contatto", _contactId));
            List<Messaggio> t = _loader.find(q).Cast<Messaggio>().ToList();
            Debug.WriteLine("Exiting GetData. Number of data: " );
            return t;
        }
    }
}
