using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDomain;
using AgendaData;

namespace AgendaServices
{
    public class MessaggiServices
    {

        public void SendMessage(Contatto c, Messaggio m)
        {

            AbstractMessage am = new MailMessage();

            am.SendMessage();
        }

        

    }
}
