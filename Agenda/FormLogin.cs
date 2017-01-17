using AgendaServices;
using PersistenceSystem;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            PersistenceSystemConfig psc = CreateObjectFromProperties();
            DBFacade.Instance().InitializeSystem(psc);
            SimpleSecurityManager ssm = SimpleSecurityManager.Instance();
            ISecurityStore store = new SecurityStore();
            ssm.Initialize(store);
        }

        private PersistenceSystemConfig CreateObjectFromProperties()
        {
            PersistenceSystemConfig psc = new PersistenceSystemConfig();
            psc.DBType = Properties.Settings.Default.DBType;
            psc.AccessConnectionString = Properties.Settings.Default.AccessConnectionString;
            psc.SqlConnectionString = Properties.Settings.Default.SqlConnectionString;
            psc.MapperFactoryClassName = Properties.Settings.Default.MapperFactoryClassName;
            psc.MapperFactoryDllName = Properties.Settings.Default.MapperFactoryDllName;
            return psc;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginResult result = SimpleSecurityManager.Instance().Login(txtUsername.Text, txtPassword.Text);
            if (result.Authenticated)
            {
                if (SimpleSecurityManager.Instance().Authorize("Administrator"))
                {
                    FormMenu frm = new FormMenu();
                    this.Hide();
                    frm.ShowDialog();
                    frm.Dispose();
                    return;
                }
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.ShowDialog();
                frm1.Dispose();
                return;
            }

            MessageBox.Show(result.AuthenticationMessage);
            
        }
    }
}
