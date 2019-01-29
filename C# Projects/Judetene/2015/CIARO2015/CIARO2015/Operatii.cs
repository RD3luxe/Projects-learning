using System;
using System.Windows.Forms;

namespace CIARO2015
{
    public partial class Operatii : Form
    {
        public static Calatorie adm;
        public Calatorie MainForm
        {
            get
            {
                return adm;
            }
            set
            {
                adm = value;
            }
        }

        public Operatii()
        {
            InitializeComponent();
        }

        private void Operatii_FormClosed(object sender, FormClosedEventArgs e)
        {
            Calatorie.CloseMain();
        }

        private void Operatii_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Name = Calatorie.IsAdmin ? "admin" : "turisti";
            item.Text = Calatorie.IsAdmin ? "Administrare" : "Turisti";
            meniu.Items.Add(item);
            item = new ToolStripMenuItem();
            item.Name = "iesire";
            item.Text = "Iesire";
            meniu.Items.Add(item);
        }

        private void meniu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Name.Equals("iesire"))
            {
                Calatorie.CloseMain();
            }
            if(e.ClickedItem.Name.Equals("admin"))
            {
                Administrare adm = new Administrare();
                adm.Show();
                this.Hide();
            }
            else if(e.ClickedItem.Name.Equals("turisti"))
            {
                Turist turist = new Turist();
                turist.Show();
                this.Hide();
            }
        }
    }
}