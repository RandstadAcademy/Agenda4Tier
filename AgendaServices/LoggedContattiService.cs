using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDomain;

namespace AgendaServices
{
    public class LoggedContattiService : ContattiServiceDecorator
    {

        public LoggedContattiService(IContattiService contattiService) : base (contattiService)
        {

        }

        public override void Delete(int id)
        {
            Debug.WriteLine("Delete operation started at: " + DateTime.Now.ToString());
            base.Delete(id);
            Debug.WriteLine("Delete operation ended at: " + DateTime.Now.ToString());
        }

        public override List<Contatto> GetAll()
        {
            Debug.WriteLine("GetAll operation started at: " + DateTime.Now.ToString());
            List<Contatto> list = base.GetAll();
            Debug.WriteLine("GetAll operation ended at: " + DateTime.Now.ToString());
            return list;
        }

        public override Contatto GetByID(int id)
        {
            Debug.WriteLine("GetByID operation started at: " + DateTime.Now.ToString());
            Contatto contatto = base.GetByID(id);
            Debug.WriteLine("GetByID operation ended at: " + DateTime.Now.ToString());
            return contatto;
        }

        public override void SaveOrUpdate(Contatto contatto)
        {
            Debug.WriteLine("SaveOrUpdate operation started at: " + DateTime.Now.ToString());
            base.SaveOrUpdate(contatto);
            Debug.WriteLine("SaveOrUpdate operation ended at: " + DateTime.Now.ToString());
        }

    }
}
