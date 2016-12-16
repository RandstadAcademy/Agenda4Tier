﻿using AgendaDomain;
using AgendaServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    /// <summary>
    /// Classe che rappresenta il form2, ovvero la finestrella che appare quando si preme Crea
    /// oppure quando con doppio click si tenta di aggiornare un utente
    /// Questa classe fa parte dell'INTERFACE TIER posto più in alto
    /// </summary>
    public partial class Form2 : Form
    {
        /*
         * Abbiamo deciso di inserire una variabile privata che rappresenta l'ID
         * Questa serve all'atto dell'aggiornamento e inserimento (nel caso di inserimento è 0)
         */
        private int ID = 0;

        /// <summary>
        /// Costruttore della classe form2 , la funzione InitializeComponent() è di sistema e viene aggiunta
        /// da visual studio, non fa altro che istanziare tutti gli elementi del form2
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Abbiamo creato questo costruttore in modo da poterci portare dietro l'id
        /// in modo che possiamo farci delle operazioni
        /// </summary>
        public Form2(Contatto contatto)
        {
            InitializeComponent();

            //setto le textbox con i valori presi dal contatto e come ultimo mi setto l'id
            txtNome.Text = contatto.Name;
            txtMail.Text = contatto.Mail;
            txtTelefono.Text = contatto.Tel;
            ID = contatto.ID;
        }

        /// <summary>
        /// Questa funzione non fa altro che scattare quando viene premuto il bottoncino Salva
        /// </summary>
        
        private void Salva_Click(object sender, EventArgs e)
        {
            //mi creo un contatto e me lo valorizzo con i valori presi dalle textbox
            Contatto contatto = new Contatto();
            contatto.Name = txtNome.Text;
            contatto.Tel = txtTelefono.Text;
            contatto.Mail = txtMail.Text;

            //nel caso di insert questo sarà 0
            contatto.ID = ID;

            //richiamo il mio service per effettuare l'insert o l'update
            ContattiService cs = new ContattiService();

            //Verifico che ogni textBox non sia lasciata vuota
            if (!(contatto.Name.Equals("") || contatto.Mail.Equals("") || contatto.Tel.Equals("")))            {
                cs.SaveOrUpdate(contatto);
                //imposto la variabile che serve al form1 per continuare
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Inserire tutti i campi");
            }
        }


    }
}
