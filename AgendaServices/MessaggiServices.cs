using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDomain;
using AgendaData;
using MessageService;
using PersistenceSystem.abstractions;
using PersistenceSystem.querying;
using PersistenceSystem;

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

        public List<Messaggio> GetMessageList(Contatto contatto)
        {
            Query q = DBFacade.Instance().CreateQuery();
            q.AddCriteria(CriteriaFactory.EqualsCriteria("Id_Contatto", contatto.Id));
            List<AbstractDomainObject> l = DBFacade.Instance().Find("Messaggio", q);
            return l.Cast<Messaggio>().ToList<Messaggio>();
            //List<Messaggio> c1 = new List<Messaggio>();
            //if (l != null) l.ForEach(d => c1.Add((Messaggio)d));
            //return c1;
        }
    }
}
