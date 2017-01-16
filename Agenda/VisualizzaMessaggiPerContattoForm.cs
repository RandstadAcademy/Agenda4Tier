using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgendaDomain;

namespace Agenda
{
    public partial class VisualizzaMessaggiPerContattoForm : Form
    {
        private List<Messaggio> _list;

        public VisualizzaMessaggiPerContattoForm()
        {
            InitializeComponent();
        }

        public VisualizzaMessaggiPerContattoForm(List<Messaggio> list):this()
        {
           
            this._list = list;
        }

        private void VisualizzaMessaggiPerContattoForm_Load(object sender, EventArgs e)
        {
            messagesListbox.DataSource = _list;
        }
    }
}
