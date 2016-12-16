using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData
{
    public class MailMessage : AbstractMessage
    {
        public override bool SendMessage()
        {


            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 465;
            client.Credentials = new System.Net.NetworkCredential("randstadacademydotnet@gmail.com", "Casalino2016");
            // Specify the e-mail sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("randstadacademydotnet@gmail.com",
               "Mermec Party",System.Text.Encoding.UTF8);
            // Set destinations for the e-mail message.
            MailAddress to = new MailAddress("griecoantonio4693@gmail.com");
            // Specify the message content.
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);
            message.Body = "This is a test e-mail message sent by an application. ";
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test message 1" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            
            // The userState can be any object that allows your callback 
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            client.SendAsync(message, userState);
            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            
            // Clean up.
            message.Dispose();
            Console.WriteLine("Goodbye.");


            return false;




        }
    }
}
