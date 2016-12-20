using MessageService.CompositeMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{
    class MessageFactory
    {
        public IMessageService GetMessageService(List<string> list)
        {
            CompositeMessageService compositeMessageService = new CompositeMessageService();
            foreach (string item in list)
            {
                IMessageService messageService = null;
                if (item.Equals("SMS"))
                    messageService = new SmsService();
                if (item.Equals("MAIL"))
                    messageService = new MailService();
                if (item.Equals("TELEGRAM"))
                    messageService = new TelegramService();
                if (item.Equals("WHATSAPP"))
                    messageService = new WhatsappService();

                compositeMessageService.Add(messageService);
            }

            return compositeMessageService;
        }
    }
}
