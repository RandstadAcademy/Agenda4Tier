using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{
    public class MessageFacade
    {

        private static MessageFacade _instance;
        private MessageServiceConfig _messageServiceConfig;

        internal MessageServiceConfig MessageServiceConfig
        {
            get
            {
                return _messageServiceConfig;
            }

            
        }

        public void InitializeSystem(MessageServiceConfig messageServiceConfig)
        {

            _messageServiceConfig = messageServiceConfig;

        }



        private MessageFacade()
        {

        }

        public static MessageFacade Instance()
        {
            if (_instance == null) 
                _instance = new MessageFacade();
            return _instance;
        }

        public void Send(MessagePayload messagePayload)
        {

            if (String.IsNullOrEmpty(messagePayload.Message.Object) || 
                    String.IsNullOrEmpty(messagePayload.Message.Body))
            {
                throw new Exception("Il corpo o l'oggetto sono vuoti");
            }
            MessageFactory factory = new MessageFactory();
            factory.GetMessageService(messagePayload.TypesList).Send(messagePayload);
            

            
        }

    }
}
