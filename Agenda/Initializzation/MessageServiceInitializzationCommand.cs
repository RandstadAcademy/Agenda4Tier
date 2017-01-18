using MessageService;
using PersistenceSystem;
using System;

namespace Agenda.Initializzation
{
    internal class MessageServiceInitializzationCommand : IInitializzationCommand
    {
        public void Execute()
        {
            MessageServiceConfig psc = CreateObjectFromProperties();
            MessageFacade.Instance().InitializeSystem(psc);
        }
        private MessageServiceConfig CreateObjectFromProperties()
        {
            MessageServiceConfig psc = new MessageServiceConfig();
            psc.MailFrom = Properties.Settings.Default.MailFrom;
            psc.Port = Properties.Settings.Default.SmtpServerPort;
            psc.SmtpClient = Properties.Settings.Default.SmtpClient;
            psc.Password = Properties.Settings.Default.Password;
            psc.User = Properties.Settings.Default.Username;
            psc.Number = Properties.Settings.Default.SenderNumber;
            psc.UserSmsSend = Properties.Settings.Default.UserSmsSend;
            psc.PasswordSmsSend = Properties.Settings.Default.PasswordSmsSend;
            return psc;
        }
    }
}