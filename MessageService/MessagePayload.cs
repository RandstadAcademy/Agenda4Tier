using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{
    public class MessagePayload
    {
  
        private Message _message;

        public Message Message
        {
            set
            {
                if (value == null)
                    value = new Message();
                _message = value;
            }
            get
            {
                return _message;
            }
        }

        public List<string> TypesList { get; set; }
    }
}
