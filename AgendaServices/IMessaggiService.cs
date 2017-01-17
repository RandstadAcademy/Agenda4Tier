using AgendaDomain;
using MessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaServices
{
    public interface IMessaggiService
    {

         void SendMessage(MessagePayload messagePayload, Contatto contatto);
        List<Messaggio> GetMessageList(Contatto contatto);
    }
}
