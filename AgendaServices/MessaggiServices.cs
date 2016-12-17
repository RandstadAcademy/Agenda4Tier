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
            if (c.MessageType.ToString().Equals("Sms"))
            {
                
            }

            if (c.MessageType.ToString().Equals("Mail"))
            {
                AbstractMessage am = new MailMessage();
                am.SendMessage(m);
            }

            if (c.MessageType.ToString().Equals("All"))
            {

            }
        }



    }
}
