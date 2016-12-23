using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaServices
{
    public interface IContattiService
    {

        Contatto GetByID(int id);
        List<Contatto> GetAll();
        void SaveOrUpdate(Contatto contatto);
        void Delete(int id);

    }
}
