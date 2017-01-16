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
using System.Collections;

namespace Agenda
{
    public partial class VisualizzaMessaggiPerContattoForm : Form
    {
        private IList _list = new ArrayList();

        public VisualizzaMessaggiPerContattoForm()
        {
            InitializeComponent();
        }

        public VisualizzaMessaggiPerContattoForm(IList<Messaggio> list):this()
        {

            foreach (var item in list)
            {
                _list.Add(item);
            }
        }

        private void VisualizzaMessaggiPerContattoForm_Load(object sender, EventArgs e)
        {
            messagesListbox.DataSource = _list;
        }
    }
}
