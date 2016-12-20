using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDomain;
using AgendaData;
using MessageService;

namespace AgendaServices
{
    public class MessaggiServices
    {

        public void SendMessage(MessagePayload messagePayload)
        {
            MessageFacade.Instance().Send(messagePayload);
        }
        
    }
}
