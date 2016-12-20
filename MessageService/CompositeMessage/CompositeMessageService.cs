using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.CompositeMessage
{
    class CompositeMessageService : IMessageService
    {
        
        private List<IMessageService> children;

        public CompositeMessageService()
        {
            children = new List<IMessageService>();
        }

        public void Add(IMessageService messageService)
        {
            children.Add(messageService);
        }

        public void Send(MessagePayload messagePayload)
        {
            foreach (IMessageService item in children)
            {
                item.Send(messagePayload);
            }
        }
    }
}
