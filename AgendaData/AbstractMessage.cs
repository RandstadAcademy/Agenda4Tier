using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData
{
    public abstract class AbstractMessage
    {

        public abstract bool SendMessage(Messaggio messaggio);
    }
}
