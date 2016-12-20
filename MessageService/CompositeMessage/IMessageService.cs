using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.CompositeMessage
{
    public interface IMessageService
    {
        void Send(MessagePayload messagePayload);
        void Add(IMessageService messageService);
    }
}
