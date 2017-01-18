using AgendaDomain.Security;
using PersistenceSystem.abstractions;
using PersistenceSystem.querying;
using SecuritySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Initializzation
{
    class CreateAdministratorCommand : IInitializzationCommand
    {
        private string _defaultAdministratorName = "Administrator";

        public void Execute()
        {
            if (!IsAdministratorExist())
                AddAdministrator();
        }

        private void AddAdministrator()
        {

            Utente u = new Utente();
            u.Mail = "admin@agenda.it";
            u.NameAndSurname = "Amministratore Sistema";
            u.Username = _defaultAdministratorName;
            u.Password = SimpleSecurityManager.Instance().CryptoPassword("admin");

            Query q = DBFacade.Instance().CreateQuery();
            q.AddCriteria(CriteriaFactory.MatchEqualCriteria("Name", _defaultAdministratorName));
            List<Ruolo> l = DBFacade.Instance().Find("Ruolo", q).Cast<Ruolo>().ToList();


            Ruolo rAdministrator = l.First<Ruolo>();

            u.Roles.Add(rAdministrator);

            DBFacade.Instance().SaveOrUpdate(u);
        }

        private bool IsAdministratorExist()
        {
            
            Query q = DBFacade.Instance().CreateQuery();
            q.AddCriteria(CriteriaFactory.MatchEqualCriteria("Username", _defaultAdministratorName));
            List<Utente> l = DBFacade.Instance().Find("Utente", q).Cast<Utente>().ToList();
            foreach (var utente in l)
            {
                if (utente.Username.Equals(_defaultAdministratorName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
