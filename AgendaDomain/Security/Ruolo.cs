using PersistenceSystem;
using SecuritySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain.Security
{
    public class Ruolo : AbstractDomainObject, IRole
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public override string ToString()
        {
            return _name;
        }
    }
}
