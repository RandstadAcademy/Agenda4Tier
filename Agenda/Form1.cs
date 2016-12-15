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
    public partial class Form1 : Form
    {
        private int IDSelected { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ContattiService svc = new ContattiService();
            List<Contatto> contatti = svc.GetAll();
            listBox1.DataSource = contatti;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
            f.Dispose();
        }

        public void LoadData()
        {
            ContattiService svc = new ContattiService();
            List<Contatto> contatti = svc.GetAll();
            listBox1.DataSource = contatti;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
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
