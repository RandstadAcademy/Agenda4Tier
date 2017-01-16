using PersistenceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain
{
    /// <summary>
    /// Questa classe fa parte del nostro modello di dominio e rappresenta un Contatto in agenda
    /// </summary>
    public class Contatto: AbstractDomainObject 
    {
        //mi setto una serie di proprietà pubbliche
      
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        private List<string> _messageTypes;


        private IList<Messaggio> _messaggi;
        public IList<Messaggio> Messaggi
        {
            get
            {
                return _messaggi;
            }
            set
            {
                _messaggi = value;
            }
        }


        public List<string> MessageTypes
        {
            get
            {
                return _messageTypes;
            }

            set
            {
                if (value ==  null)
                    value = new List<string>();
                _messageTypes = value;
            }
        }

        /// <summary>
        /// Costruttore della classe Contatto
        /// </summary>
        public Contatto()
        {
            MessageTypes = new List<string>();
        }


        /// <summary>
        /// Metodo che serve a effettuare una piccola validazione dell'input
        /// </summary>
        public override string DoValidate()
        {
            string MsgErrore = "";

            //verifico se le stringhe immesse siano vuote o null
            if (string.IsNullOrEmpty(Name))
                MsgErrore =  "Nome Errato";

            if (string.IsNullOrEmpty(Mail))
                MsgErrore = "Mail Errata";

            if (string.IsNullOrEmpty(Tel))
                MsgErrore = "Tel Errato";

            //se è andato tutto bene il messaggio di errore è vuoto
            return MsgErrore;
        }

        //ridefinizione del metodo ToString() ereditato da Object
        public override string ToString()
        {
            return this.Name + " - " + this.Mail + " - " + this.Tel;
        }


        public string MessageTypesToString() {

            string messagesTypes= String.Empty;

            foreach (string item in _messageTypes)
            {
                messagesTypes += item +", ";

            }

            return messagesTypes;
        }

    }
}
