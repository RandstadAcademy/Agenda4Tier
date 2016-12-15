using AgendaData;
using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaServices
{
    public class ContattiService
    {
        public Contatto GetByID(int id)
        {
            DBContatto DBContatto = new DBContatto();
            return DBContatto.GetByID(id);

        }

        public List<Contatto> GetAll()
        {
            DBContatto DBContatto = new DBContatto();
            return DBContatto.GetAll();
        }

        public void SaveOrUpdate(Contatto contatto)
        {

            string error = contatto.Validate();
            if (string.IsNullOrEmpty(error))
            {
                ///nessun errore e procedo
                DBContatto DBContatto = new DBContatto();
                DBContatto.SaveOrUpdate(contatto);
                return;
            }

            throw new Exception(error);

        }

        public void Delete(int id)
        {
            DBContatto DBContatto = new DBContatto();
            DBContatto.Delete(id);
        }

    }
}
