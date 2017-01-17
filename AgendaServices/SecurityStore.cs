using AgendaDomain.Security;
using PersistenceSystem.abstractions;
using PersistenceSystem.querying;
using SecuritySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaServices
{
    public class SecurityStore : ISecurityStore
    {
        public ISecurityUser GetUserByUsername(string username)
        {
            Query q = DBFacade.Instance().CreateQuery();
            q.AddCriteria(CriteriaFactory.MatchEqualCriteria("Username", username));
            return (ISecurityUser) DBFacade.Instance().Find("Utente", q).FirstOrDefault();
        }

        public void RegisterUser(ISecurityUser user)
        {
            DBFacade.Instance().SaveOrUpdate((Utente) user);
        }
    }
}
