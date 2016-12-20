﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.CompositeMessage
{
    class WhatsappService : IMessageService
    {
        public void Add(IMessageService messageService)
        {
            throw new NotImplementedException();
        }

        public void Send(MessagePayload messagePayload)
        {
            Debug.WriteLine("Send Whatsapp Message");
        }
    }
}
