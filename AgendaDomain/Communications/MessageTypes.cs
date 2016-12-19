using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain.Communications
{
    public  class MessageTypes
    {
        public  const string MessageType_SMS = "SMS";
        public const string MessageType_MAIL = "MAIL";


        public List<string> MessageTypesList = new List<string>
        {
            MessageType_SMS, MessageType_MAIL
        };

    }
}
