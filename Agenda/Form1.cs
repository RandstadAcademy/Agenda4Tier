using AgendaData.mermec;
using AgendaDomain;
using AgendaServices;
using PersistenceSystem.abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersistenceSystem;

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
        private IContattiService svc = new LoggedContattiService(new ContattiService());

        /// <summary>
        /// Costruttore di Form1 , InitializeComponents istanzia tutti i componenti del form e viene
        /// aggiunta da visual studio
        /// </summary>
        public Form1()
        {
            InitializeComponent();
               

            //DBFacade.Instance().MapperFactory = new MapperFactory();
        }

        private PersistenceSystemConfig CreateObjectFromProperties()
        {
            PersistenceSystemConfig psc = new PersistenceSystemConfig();
            psc.DBType = Properties.Settings.Default.DBType;
            psc.AccessConnectionString= Properties.Settings.Default.AccessConnectionString;
            psc.SqlConnectionString = Properties.Settings.Default.SqlConnectionString;
            psc.MapperFactoryClassName = Properties.Settings.Default.MapperFactoryClassName;
            psc.MapperFactoryDllName = Properties.Settings.Default.MapperFactoryDllName;
            return psc;
        }


        /// <summary>
        /// Funzione che viene richiamata quando viene scatenato l'evento Load
        /// Load è una condizione che scatta quando il programma parte e il form1 viene caricato
        /// </summary>

        private void Form1_Load(object sender, EventArgs e)
        {
            


            //Istanziamo un oggetto ContattiService che si occuperà di andare a recuperare i contatti
            //inoltrando la richiesta ai livelli inferiori dell'architettura

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
            IDSelected = contatto.Id;
        }

        /// <summary>
        /// Questo evento viene richiamato dopo che seleziono un contatto dalla lista
        /// e premo il bottone per cancellare
        /// </summary>
        private void buttonCancella_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Sicuro?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                //istanzio il service

                //verifico che il mio ID che ho settato quando ho evidenziato
                //un contatto in listBox sia valorizzato
                if (IDSelected != 0)
                {
                    //demando la cancellazione ai piani inferiori dell'architettura
                    svc.Delete(IDSelected);
                    LoadData();
                }
            }

           
        }

        /// <summary>
        /// Procedura utile a passare un contatto ad un Form per l'apertura dello stesso
        /// </summary>
        private void ChangeView(object sender, EventArgs e, Form form, Contatto contatto)
        {

            if (contatto.Id != 0)
            {
                form.ShowDialog();
                //faccio il refresh dei dati
                LoadData();
            }
            else
            {
                //Mostro un alert nel caso in cui premo il pulsante Aggiorna non essendo
                //presenti contatti in lista
                MessageBox.Show("Non sono presenti contatti nella lista");
            }
            form.Dispose();

        }

        /// <summary>
        /// Questo evento viene lanciato quando faccio doppio click su un elemento della listBox
        /// </summary>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Contatto contatto = (this.listBox1.Items[this.listBox1.SelectedIndex]) as Contatto;

            //passo l'oggetto contatto selezionato al form2
            //e poi faccio il refresh dopo che sono sicuro che è andato tutto apposto
            Form2 f = new Form2(contatto);
            ChangeView(sender, e,f,contatto);
        }

        /// <summary>
        /// Questo evento viene richiamato dopo che seleziono un contatto dalla lista
        /// e premo il bottone per aggiornare
        /// </summary>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Contatto contatto = (this.listBox1.Items[this.listBox1.SelectedIndex]) as Contatto;

            //passo l'oggetto contatto selezionato al form2
            //e poi faccio il refresh dopo che sono sicuro che è andato tutto apposto
            Form2 f = new Form2(contatto);
            ChangeView(sender, e, f, contatto);
        }

        /// <summary>
        /// Dialog Salvataggio necessaria per la scelta della directory ove salvare il  contatto
        /// </summary>
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// Questo evento viene richiamato dopo che seleziono un contatto dalla lista
        /// e premo il bottone per esportarlo in un file .txt
        /// </summary>
        private void buttonExport_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Questo evento viene richiamato dopo che seleziono un contatto dalla lista
        /// e premo il bottone per esportarlo in un file .txt
        /// </summary>
        private void buttonExport_Click_1(object sender, EventArgs e)
        {
            //istanzio il service
            Contatto contatto = null;

            //Setto il filtro estensione
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

            //verifico che il mio ID che ho settato quando ho evidenziato
            //un contatto in listBox sia valorizzato
            if (IDSelected != 0)
            {
                //Recupero il contatto tramite l'ID grazie al servizio GetByID
                contatto = svc.GetByID(IDSelected);

                //Apre la finestra di salvataggio
                //Verifica che il percorso sia corretto
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)
                {
                    //Scrive il contatto su file
                    File.WriteAllText(saveFileDialog1.FileName, "*** CONTATTO ***\n" + "Nome: " + contatto.Name + "\n" + "Email: " + contatto.Mail + "\n" + "Telefono: " + contatto.Tel);
                    saveFileDialog1.FileName = null;
                }
            }
            else
            {
                //Se non sono presenti contatti in lista mostra un alert
                MessageBox.Show("Nessun contatto presente in lista");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Contatto contatto = (this.listBox1.Items[this.listBox1.SelectedIndex]) as Contatto;

                FormMessage f = new FormMessage(contatto);
                ChangeView(sender, e, f, contatto);
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DBType.Equals("Access"))
                Properties.Settings.Default.DBType= "SqlServer";
            else
                Properties.Settings.Default.DBType = "Access";

            DBFacade.Instance().InitializeDB(Properties.Settings.Default.DBType);
            LoadData();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            List<Contatto> result = svc.Find(txtSearch.Text);

            listBox1.DataSource = result;
        }
    }
}
