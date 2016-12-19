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
    public partial class FormMessage : Form
    {
        private int ID = 0;
        private Contatto contatto = null;
        

        public FormMessage()
        {
            InitializeComponent();
        }

        public FormMessage(Contatto contatto)
        {
            InitializeComponent();
            this.contatto = contatto;
            lblNameContactSummary.Text = contatto.Name;
           // lblTypeMsg.Text = contatto.MessageType.ToString();
            lblTelSummary.Text = contatto.Tel;
            lblEmailSummary.Text = contatto.Mail;
            if (lblTypeMsg.Text.Equals("Sms"))
            {
                txtboxObjectMsg.Enabled = false;
            }
            ID = contatto.Id;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormMessage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessaggiServices ms = new MessaggiServices();
            Messaggio messaggio = null;

            if ((!(String.IsNullOrEmpty(txtboxObjectMsg.Text) ||
                  String.IsNullOrEmpty(txtboxMsg.Text))) || 
                  (!String.IsNullOrEmpty(txtboxMsg.Text)
                  && txtboxObjectMsg.Enabled==false))
            {
                messaggio = new Messaggio();
                messaggio.Body = txtboxMsg.Text;
                messaggio.MessageObject = txtboxObjectMsg.Text;
                messaggio.From = "randstadacademydotnet@gmail.com";
                messaggio.To = contatto.Mail;
                messaggio.Tel = contatto.Tel;
                ms.SendMessage(contatto, messaggio);
                MessageBox.Show("Messaggio inviato");
            }else
            {
                MessageBox.Show("Si prega di inserire tutti i campi");
            }
        }
    }
}
