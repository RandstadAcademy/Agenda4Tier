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
    public partial class FormMenu : Form
    {
       
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnRegistrazione_Click(object sender, EventArgs e)
        {
            FormRegistrazione frm = new FormRegistrazione();
            frm.ShowDialog();
            frm.Dispose();
        }
        
    }
}
