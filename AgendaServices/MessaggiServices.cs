using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDomain;
using AgendaData;
using MessageService;
using PersistenceSystem.abstractions;

namespace AgendaServices
{
    public class MessaggiServices
    {

        public void SendMessage(MessagePayload messagePayload,Contatto contatto)
        {


            Messaggio msg = new Messaggio();
            msg.MessageBody = messagePayload.Message.Body;
            msg.MessageObject = messagePayload.Message.Object;
            msg.MessageType = String.Join<string>(",", contatto.MessageTypes);
            msg.SendDate = DateTime.Today;
            msg.Recipient = contatto;

            DBFacade.Instance().SaveOrUpdate(msg);
            try
            { 
                MessageFacade.Instance().Send(messagePayload);
            }
            catch (Exception ex)
            {
                DBFacade.Instance().Delete(msg);
                throw ex;
            }
            


        }
        
    }
}
