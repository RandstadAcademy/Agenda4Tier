using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDomain;
using MessageService;

namespace AgendaServices
{
    public abstract class MessageServiceDecorator : IMessaggiService
    {
        protected IMessaggiService _messaggiservice;

        public MessageServiceDecorator(IMessaggiService messaggiservice)
        {
            _messaggiservice = messaggiservice;

        }

        public List<Messaggio> GetMessageList(Contatto contatto)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(MessagePayload messagePayload, Contatto contatto)
        {
            
        }
    }

}