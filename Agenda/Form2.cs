using AgendaDomain;
using AgendaDomain.Communications;
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

        // * Abbiamo deciso di inserire una variabile privata che rappresenta l'ID
        // * Questa serve all'atto dell'aggiornamento e inserimento (nel caso di inserimento è 0)
        // 
        //private int ID = 0;

        private Contatto _current;

        /// <summary>
        /// Costruttore della classe form2 , la funzione InitializeComponent() è di sistema e viene aggiunta
        /// da visual studio, non fa altro che istanziare tutti gli elementi del form2
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            messageTypes.Items.AddRange(new MessageTypes().MessageTypesList.ToArray());

        }


        /// <summary>
        /// Abbiamo creato questo costruttore in modo da poterci portare dietro l'id
        /// in modo che possiamo farci delle operazioni
        /// </summary>
        public Form2(Contatto contatto)
        {
            InitializeComponent();

            messageTypes.Items.AddRange(new MessageTypes().MessageTypesList.ToArray());

            _current = contatto;

            //carioc is dati nellìinterfaccia
            LoadData();


        }

        private void LoadData()
        {
            if (_current == null)
                return;
            //setto le textbox con i valori presi dal contatto e come ultimo mi setto l'id
            txtNome.Text = _current.Name;
            txtMail.Text = _current.Mail;
            txtTelefono.Text = _current.Tel;


            foreach (string item in _current.MessageTypes)
            {
                messageTypes.SetItemChecked(getItemIndex(item), true);
            }
        }

        private int getItemIndex(string item)
        {
            int i = 0;
            foreach (string elem in messageTypes.Items)
            {
                if (item.Equals(elem))
                    return i;
                i++;
            }
            return -1;
        }

        /// <summary>
        /// Questa funzione non fa altro che scattare quando viene premuto il bottoncino Salva
        /// </summary>

        private void Salva_Click(object sender, EventArgs e)
        {
            

            ////Verifico che ogni textBox non sia lasciata vuota
            //if (!(String.IsNullOrEmpty(txtNome.Text) || 
            //        String.IsNullOrEmpty(txtMail.Text) || 
            //        String.IsNullOrEmpty(txtTelefono.Text)))
            //{

                //mi creo un contatto e me lo valorizzo con i valori presi dalle textbox
                Contatto contatto = new Contatto();
                if (_current != null)
                    contatto = _current;
                contatto.Name = txtNome.Text;
                contatto.Tel = txtTelefono.Text;
                contatto.Mail = txtMail.Text;
                SetMessageType(contatto);



                //richiamo il mio service per effettuare l'insert o l'update
                ContattiService cs = new ContattiService();


                //Chiamo il servizio SaveOrUpdate passando in input il contatto da salvare o aggiornare
                cs.SaveOrUpdate(contatto);
                //imposto la variabile che serve al form1 per continuare
                this.DialogResult = DialogResult.OK;
                this.Close();
            //}
            //else
            //{
                //Verifico che tutti i campi siano stati inseriti prima di procedere
                //all'aggiornamento o al salvataggio
                //MessageBox.Show("Inserire tutti i campi");
            //}
        }

        private void SetMessageType(Contatto contatto)
        {

            contatto.MessageTypes.Clear();
            foreach (string item in messageTypes.CheckedItems)
            {
                contatto.MessageTypes.Add(item);
            }



        }

      
    }
}
