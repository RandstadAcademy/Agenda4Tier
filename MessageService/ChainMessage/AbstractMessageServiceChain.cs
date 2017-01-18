using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.ChainMessage
{
    public abstract class AbstractMessageServiceChain : IChainableMessageService
    {

        protected IChainableMessageService _chain;
        protected List<String> _allowedMessageType;
        protected string _messageType;

        public AbstractMessageServiceChain(IChainableMessageService chain, List<String> allowedMessageType)
        {
            _allowedMessageType = allowedMessageType;
            _chain = chain;
        }

        protected bool CanSendMessage()
        {
            string result = _allowedMessageType.Find(a => a.Equals(_messageType));

            return !string.IsNullOrEmpty(result);
        }


        public void Send(MessagePayload messagePayload)
        {
            if (CanSendMessage())
            {
                DoSend(messagePayload);
            }
            if (_chain != null)
                _chain.Send(messagePayload);
        }

        protected abstract void DoSend(MessagePayload messagePayload);
      
    }
}
