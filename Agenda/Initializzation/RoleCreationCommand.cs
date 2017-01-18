using AgendaData.mermec.concreteMappers;
using AgendaDomain.Security;
using PersistenceSystem.abstractions;
using PersistenceSystem.querying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Initializzation
{
    class RoleCreationCommand : IInitializzationCommand

    {
        public void Execute()
        {
            if(!IsRoleExist("Administrator"))
                AddRuolo("Administrator");

            if (!IsRoleExist("User"))
                AddRuolo("User");
        }



        private static void AddRuolo(string ruoloName)
        {
            Ruolo r = new Ruolo();
            r.Name = ruoloName;
            DBFacade.Instance().SaveOrUpdate(r);
        }

        private bool IsRoleExist(string ruolo)
        {

            Query q = DBFacade.Instance().CreateQuery();
            q.AddCriteria(CriteriaFactory.MatchEqualCriteria("Name", ruolo));
            List<Ruolo> l = DBFacade.Instance().Find("Ruolo", q).Cast<Ruolo>().ToList();
            foreach (var ruoloEstratto in l)
            {
                if (ruoloEstratto.Name.Equals(ruolo))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
