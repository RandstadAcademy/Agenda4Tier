
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.ChainMessage
{
    class TelegramMessageServiceChain : AbstractMessageServiceChain
    {
        public TelegramMessageServiceChain(IChainableMessageService chain, List<String> allowedMessageType)
            :base(chain, allowedMessageType)
        {
            _messageType = "TELEGRAM";
        }

        protected override void DoSend(MessagePayload messagePayload)
        {

        }
    }
  
}
