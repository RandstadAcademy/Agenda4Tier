using PersistenceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain
{
    public class Messaggio: AbstractDomainObject
    {

        public DateTime SendDate{ get; set; }
        public string MessageType { get; set; }
        public string MessageBody { get; set; }
        public string MessageObject { get; set; }


        public Contatto Recipient { get; set; }

      
        public override string DoValidate()
        {
            string MsgErrore = "";

            //verifico se le stringhe immesse siano vuote o null
            if (string.IsNullOrEmpty(MessageBody))
                MsgErrore += "Corpo del messaggio errato";

            if (string.IsNullOrEmpty(MessageObject))
                MsgErrore += "Oggetto del messaggio errato";

            if (Recipient==null)
                MsgErrore += "Non è stato settato nessun contatto";
            if (SendDate == null)
                MsgErrore += "Non è stata inserita alcuna data";

            //se è andato tutto bene il messaggio di errore è vuoto
            return MsgErrore;
        }

        public override string ToString()
        {
            return this.MessageType + " - " + this.MessageObject + " - " + this.MessageBody;
        }

    }
}
