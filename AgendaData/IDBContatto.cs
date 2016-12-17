using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData
{
    interface IDBContatto
    {
        Contatto GetByID(int ID);
        List<Contatto> GetAll();
        void SaveOrUpdate(Contatto contatto);
        void Delete(int ID);
    }
}
