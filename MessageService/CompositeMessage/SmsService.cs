using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.CompositeMessage
{
    class SmsService : IMessageService
    {
        public void Add(IMessageService messageService)
        {
            throw new NotImplementedException();
        }

        public void Send(MessagePayload messagePayload)
        {
            //SmsFacade.Instance().Initialize(....);
            //SmsFacade.Instance().SendSms(Messagio, Tel[]);
        }
    }
}
