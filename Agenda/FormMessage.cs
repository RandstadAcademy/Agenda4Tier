using AgendaDomain;
using AgendaServices;
using MessageService;
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
        private Contatto contatto = null;

       

        public FormMessage(Contatto contatto)
        {
            InitializeComponent();
      
            this.contatto = contatto;

            LoadData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormMessage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MessagePayload messagePayload = new MessagePayload();
                MessageService.Message message = new MessageService.Message();
                message.Body = txtboxMsg.Text;
                message.Object = txtboxObjectMsg.Text;
                message.Mail = contatto.Mail;
                message.PhoneNumber = contatto.Tel;
                messagePayload.Message = message;
                messagePayload.TypesList = contatto.MessageTypes;
                MessaggiServices service = new MessaggiServices();

                service.SendMessage(messagePayload, contatto);
                MessageBox.Show("Messaggio Inviato");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            
        }

        private void LoadData()
        {
            if (lblTypeMsg.Text.Equals("Sms"))
            {
                txtboxObjectMsg.Enabled = false;
            }
            lblNameContactSummary.Text = contatto.Name;
            lblEmailSummary.Text = contatto.Mail;
            lblTelSummary.Text = contatto.Tel;
            lblTypeMsg.Text = contatto.MessageTypesToString();
        }

    }
}
