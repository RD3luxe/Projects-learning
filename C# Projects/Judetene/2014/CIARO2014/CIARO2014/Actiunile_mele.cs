using System;
using System.Windows.Forms;

namespace CIARO2014
{
    public partial class Actiunile_mele : Form
    {
        public static string total = "0";
        public Actiunile_mele()
        {
            InitializeComponent();
        }

        private void Actiunile_mele_FormClosed(object sender, FormClosedEventArgs e)
        {
            Bursa.opened[0] = false;
        }

        private void Actiunile_mele_Load(object sender, EventArgs e)
        {
            actiuni_dv.DataSource = Bursa.all_data;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            total_txt.Text = total;
        }
    }
}