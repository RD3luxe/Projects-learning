using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CIARO2014
{
    public partial class Grafic_profit : Form
    {
        public Chart get_Chart
        {
            get
            {
                return grafic;
            }
            set
            {
                grafic = value;
            }
        }
        public Grafic_profit()
        {
            InitializeComponent();
            grafic.Series["data"].Points.Clear();
        }
        private void Grafic_profit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Bursa.opened[1] = false;
        }
    }
}