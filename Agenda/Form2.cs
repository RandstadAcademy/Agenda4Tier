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
    /// Classe che rappresenta il form2, ovvero la finestrella che appare quando si preme Crea
    /// oppure quando con doppio click si tenta di aggiornare un utente
    /// </summary>
    public partial class Form2 : Form
    {
        /*
         * Abbiamo deciso di inserire una variabile privata che rappresenta l'ID
         * Questa serve all'atto dell'aggiornamento e inserimento (nel caso di inserimento è 0)
         */
        private int ID = 0;
        private Form1 form1;

        /// <summary>
        /// Costruttore della classe form2 , la funzione InitializeComponent() è di sistema e viene aggiunta
        /// da visual studio, non fa altro che istanziare tutti gli elementi del form2
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(int id,Form1 form)
        {
            form1 = form;
            InitializeComponent();
            ContattiService svc = new ContattiService();
            Contatto contatto = svc.GetByID(id);
            txtNome.Text = contatto.Name;
            txtMail.Text = contatto.Mail;
            txtTelefono.Text = contatto.Tel;
            ID = id;
        }

        private void Salva_Click(object sender, EventArgs e)
        {
            Contatto contatto = new Contatto();
            contatto.Name = txtNome.Text;
            contatto.Tel = txtTelefono.Text;
            contatto.Mail = txtMail.Text;
            contatto.ID = ID;
            AgendaServices.ContattiService f = new AgendaServices.ContattiService();
            f.SaveOrUpdate(contatto);
            this.DialogResult = DialogResult.OK;
            if (contatto.ID != 0)
            {
                form1.LoadData();
            }
            this.Close();
        }


    }
}
