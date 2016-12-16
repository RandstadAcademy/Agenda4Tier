using AgendaDomain;
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
    /// Rappresenta il Form1
    /// Questa classe fa parte dell'INTERFACE TIER posto più in alto
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Proprietà IDSelected che rappresenta la riga della listBox selezionata
        /// </summary>
        private int IDSelected { get; set; }

        /// <summary>
        /// Costruttore di Form1 , InitializeComponents istanzia tutti i componenti del form e viene
        /// aggiunta da visual studio
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Funzione che viene richiamata quando viene scatenato l'evento Load
        /// Load è una condizione che scatta quando il programma parte e il form1 viene caricato
        /// </summary>
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Setto la titlebar
            this.Text = "Agenda Accademy Mermec v.0.1";

            //Istanziamo un oggetto ContattiService che si occuperà di andare a recuperare i contatti
            //inoltrando la richiesta ai livelli inferiori dell'architettura
            ContattiService svc = new ContattiService();

            //qui richiamo la funzione del Service che altro non fa che richiamare un oggetto dei livelli
            //inferiori
            List<Contatto> contatti = svc.GetAll();

            //aggiorno la listbox
            listBox1.DataSource = contatti;
        }

        /// <summary>
        /// Questa funzione scatta quando premo il bottone Crea
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            //istanzio un Form2 che ho sistemato prima nel designer
            Form2 f = new Form2();

            //utilizzo una proprietà del form2 che setto quando vado a premere salva
            if (f.ShowDialog() == DialogResult.OK)
            {
                //faccio il refresh dei dati
                LoadData();
            }
            f.Dispose();
        }

        /// <summary>
        /// Questa funzione serve ad aggiornami la listbox
        /// </summary>
        public void LoadData()
        {
            //istanzio un service per i contatti
            ContattiService svc = new ContattiService();

            //estraggo tutti i contatti comunicando con i livelli inferiori
            List<Contatto> contatti = svc.GetAll();

            //sistemo la lista
            listBox1.DataSource = contatti;
        }

        /// <summary>
        /// Questa funzione scatta quando selezioniamo un contatto sulla listbox
        /// e va ad aggiornare l'attributo ID privato che ci siamo creati
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //il sender è colui che richiama l'evento, in questo caso la listbox
            ListBox lb = (ListBox)sender;

            //Creo un contatto e faccio in modo che venga riempito in base alla riga selezionata
            Contatto contatto = (Contatto)lb.Items[lb.SelectedIndex];

            //salvo il mio ID
            IDSelected = contatto.ID;
        }

        /// <summary>
        /// Questo evento viene richiamato dopo che seleziono un contatto dalla lista
        /// e premo il bottone per cancellare
        /// </summary>
        private void buttonCancella_Click(object sender, EventArgs e)
        {
            //istanzio il service
            ContattiService svc = new ContattiService();

            //verifico che il mio ID che ho settato quando ho evidenziato
            //un contatto in listBox sia valorizzato
            if (IDSelected != 0)
            {
                //demando la cancellazione ai piani inferiori dell'architettura
                svc.Delete(IDSelected);
                LoadData();
            }
        }

        /// <summary>
        /// Questo evento viene lanciato quando faccio doppio click su un elemento della listBox
        /// </summary>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            //Identifico la mia listbox
            ListBox lb = (ListBox)sender;

            //tiro fuori il contatto slezionato
            Contatto contatto = (Contatto)lb.Items[lb.SelectedIndex];
            //mi salvo l'id
            IDSelected = contatto.ID;
            //passo l'oggetto contatto selezionato al form2
            //e poi faccio il refresh dopo che sono sicuro che è andato tutto apposto
            Form2 f = new Form2(contatto);

            if (contatto.ID != 0 && f.ShowDialog() == DialogResult.OK )
            {
                //faccio il refresh dei dati
                LoadData();
            }
            f.Dispose();
        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //istanzio il service
            ContattiService svc = new ContattiService();

            //verifico che il mio ID che ho settato quando ho evidenziato
            //un contatto in listBox sia valorizzato
            if (IDSelected != 0)
            {
                Contatto contatto = svc.GetByID(IDSelected);
                Form2 f = new Form2(contatto);

                if (contatto.ID != 0 && f.ShowDialog() == DialogResult.OK)
                {
                    //faccio il refresh dei dati
                    LoadData();
                }
                f.Dispose();
            }else
            {
                MessageBox.Show("Non sono presenti contatti nella lista");
            }
        }
    }
}
