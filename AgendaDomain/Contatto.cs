using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain
{
    public class Contatto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public MessageType MessageType { get; set; }

        public Contatto()
        {
            MessageType = MessageType.Mail;
        }

        public string Validate()
        {
            string MsgErrore = "";


            if (string.IsNullOrEmpty(Name))
                MsgErrore =  "Nome Errato";

            if (string.IsNullOrEmpty(Mail))
                MsgErrore = "Mail Errata";

            if (string.IsNullOrEmpty(Tel))
                MsgErrore = "Tel Errato";

            return MsgErrore;
        }

        public override string ToString()
        {
            return this.Name + " - " + this.Mail + " - " + this.Tel;
        }

    }
}
