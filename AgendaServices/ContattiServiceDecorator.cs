using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDomain;

namespace AgendaServices
{
    public abstract class ContattiServiceDecorator : IContattiService
    {

        private IContattiService _contattiService;

        public ContattiServiceDecorator(IContattiService contattiService)
        {
            _contattiService = contattiService;
        }

        virtual public void Delete(int id)
        {
            _contattiService.Delete(id);
        }

        virtual public List<Contatto> GetAll()
        {
            return _contattiService.GetAll();
        }

        virtual public Contatto GetByID(int id)
        {
            return _contattiService.GetByID(id);
        }

        virtual public void SaveOrUpdate(Contatto contatto)
        {
            _contattiService.SaveOrUpdate(contatto);
        }
    }
}
