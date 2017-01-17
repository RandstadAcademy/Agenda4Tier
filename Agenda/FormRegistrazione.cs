using AgendaDomain.Security;
using PersistenceSystem.abstractions;
using SecuritySystem;
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
    public partial class FormRegistrazione : Form
    {
        public FormRegistrazione()
        {
            InitializeComponent();
            checkedListBoxRuoli.Items.AddRange(DBFacade.Instance().GetAll("Ruolo").ToArray());
        }



        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegistra_Click(object sender, EventArgs e)
        {
            try
            {
                Utente utente = new Utente();
                utente.Mail = txtMail.Text;
                utente.Username = txtUsername.Text;
                utente.Password = txtPassword.Text;
                utente.NameAndSurname = txtNome.Text + " " + txtCognome.Text;
                utente.Roles = new List<IRole>(checkedListBoxRuoli.CheckedItems.Cast<IRole>());
                SimpleSecurityManager.Instance().RegisterUser(utente);
                MessageBox.Show("Utente registrato!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
            
    }
}
