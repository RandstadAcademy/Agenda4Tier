using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{
    public class MessageServiceConfig
    {

        public string SmtpClient { get; set; }
        public string MailFrom { get; set; }
        public string User{ get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Number { get; set; }
        public string UserSmsSend { get; set; }
        public string PasswordSmsSend { get; set; }
    }
}
