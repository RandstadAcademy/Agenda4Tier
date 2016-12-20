using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.CompositeMessage
{
    class MailService : IMessageService
    {
        public void Add(IMessageService messageService)
        {
            
        }

        public void Send(MessagePayload messagePayload)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("randstadacademydotnet@gmail.com");
                mail.To.Add(messagePayload.Message.Mail);
                mail.Subject = messagePayload.Message.Object;
                mail.Body = messagePayload.Message.Body;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("randstadacademydotnet@gmail.com", "Casalino2016");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
