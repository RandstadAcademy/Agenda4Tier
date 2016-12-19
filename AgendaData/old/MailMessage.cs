using AgendaDomain;
using System;
using System.Net;
using System.Net.Mail;


namespace AgendaData
{
    public class MailMessage : AbstractMessage
    {
        public override bool SendMessage(Messaggio messaggio)
        {
            bool result = false;
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("randstadacademydotnet@gmail.com");
                mail.To.Add(messaggio.To);
                mail.Subject = messaggio.MessageObject;
                mail.Body = messaggio.Body;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("randstadacademydotnet@gmail.com", "Casalino2016");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            return result;
      

        }
    }
}
