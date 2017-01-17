using AgendaDomain;
using SecuritySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaServices
{
    public class AuthorizedContattiService: ContattiServiceDecorator
    {
        public AuthorizedContattiService(IContattiService contattiService) : base (contattiService)
        {

        }

        public override void Delete(int id)
        {
            if (!SimpleSecurityManager.Instance().Authorize("Administrator"))
                throw new Exception("Non autorizzato!!!");
            
            base.Delete(id);
            
            
        }

        public override List<Contatto> GetAll()
        {
            if (!SimpleSecurityManager.Instance().Authorize("Administrator"))
                throw new Exception("Non autorizzato!!!");

            List<Contatto> list = base.GetAll();
            
            return list;
        }

        public override Contatto GetByID(int id)
        {
            if (!SimpleSecurityManager.Instance().Authorize("Administrator"))
                throw new Exception("Non autorizzato!!!");

            Contatto contatto = base.GetByID(id);
            
            return contatto;
        }

        public override void SaveOrUpdate(Contatto contatto)
        {
            if (!SimpleSecurityManager.Instance().Authorize("Administrator"))
                throw new Exception("Non autorizzato!!!");

            base.SaveOrUpdate(contatto);
            
        }
    }
}
