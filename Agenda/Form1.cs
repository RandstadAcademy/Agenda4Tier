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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //istanzio un Form2 che ho sistemato prima nel designer
            Form2 f = new Form2();

            //utilizzo una proprietà del form2 che scatta quando
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
            f.Dispose();
        }

        /// <summary>
        /// Questa funzione serve ad aggiornami la listbox
        /// </summary>
        public void LoadData()
        {
            ContattiService svc = new ContattiService();
            List<Contatto> contatti = svc.GetAll();
            listBox1.DataSource = contatti;
        }

        /// <summary>
        /// Questa funzione scatta quando selezioniamo un contatto sulla listobox
        /// e va ad aggiornare l'attributo ID privato che ci siamo creati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //il sender è colui che richiama l'evento, in questo caso la listbox
            ListBox lb = (ListBox)sender;

            //Creo un contatto e faccio in modo che venga riempito in base alla riga selezionata
            Contatto contatto = (Contatto)lb.Items[lb.SelectedIndex];
            IDSelected = contatto.ID;
        }

        private void buttonCancella_Click(object sender, EventArgs e)
        {
            ContattiService svc = new ContattiService();
            if (IDSelected != 0)
            {
                svc.Delete(IDSelected);
                LoadData();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            Contatto contatto = (Contatto)lb.Items[lb.SelectedIndex];
            IDSelected = contatto.ID;
            Form2 f = new Form2(IDSelected,this);
            f.Show();
        }
    }
}
