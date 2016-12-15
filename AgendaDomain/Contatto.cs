﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain
{
    /// <summary>
    /// Questa classe fa parte del nostro modello di dominio e rappresenta un Contatto in agenda
    /// </summary>
    public class Contatto
    {
        //mi setto una serie di proprietà pubbliche
        public int ID { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Costruttore della classe Contatto
        /// </summary>
        public Contatto()
        {
            MessageType = MessageType.Mail;
        }


        /// <summary>
        /// Metodo che serve a effettuare una piccola validazione dell'input
        /// </summary>
        public string Validate()
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

    }
}
