using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.ChainMessage
{
    class WhatsappMessageServiceChain : AbstractMessageServiceChain
    {
        public WhatsappMessageServiceChain(IChainableMessageService chain, List<String> allowedMessageType)
            :base(chain, allowedMessageType)
        {
            _messageType = "WHATSAPP";
        }

        protected override void DoSend(MessagePayload messagePayload)
        {
            
        }
    }
}
