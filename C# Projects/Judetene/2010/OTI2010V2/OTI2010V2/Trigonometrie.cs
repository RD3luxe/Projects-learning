using System;
using System.Windows.Forms;

namespace OTI2010V2
{
    public partial class Trigonometrie : Form
    {
        public Trigonometrie()
        {
            InitializeComponent();
        }

        private void Trigonometrie_FormClosing(object sender, FormClosingEventArgs e)
        {
            CIA2010.windowsOpen[1] = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sin_btn_Click(object sender, EventArgs e)
        {
            functii_chart.Series[0].Points.Clear();
            functii_chart.Series[0].Name = "Sin";
            functii_chart.Series[0].Color = System.Drawing.Color.Red;
            for (int i = -360; i <= 360; i++)
            {
                double y = Math.Sin(i * Math.PI / 180);
                functii_chart.Series[0].Points.AddXY(i, y);
            }
        }

        private void cos_btn_Click(object sender, EventArgs e)
        {
            functii_chart.Series[0].Points.Clear();
            functii_chart.Series[0].Name = "Cos";
            functii_chart.Series[0].Color = System.Drawing.Color.Blue;
            for (int i = -360; i <= 360; i++)
            {
                double y = Math.Cos(i * Math.PI / 180);
                functii_chart.Series[0].Points.AddXY(i, y);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            functii_chart.Series[0].Name = "Functie";
            functii_chart.Series[0].Points.Clear();
        }

        private void Trigonometrie_Load(object sender, EventArgs e)
        {
            functii_chart.Series[0].Points.Dispose();
            functii_chart.ChartAreas[0].AxisY.Minimum = -2;
            functii_chart.ChartAreas[0].AxisY.Maximum = 2;
            functii_chart.ChartAreas[0].AxisY.Interval = 1;
            functii_chart.Series[0].Color = System.Drawing.Color.Red;
            functii_chart.Series[0].BorderWidth = 3;
            functii_chart.ChartAreas[0].AxisX.Minimum = -360;
            functii_chart.ChartAreas[0].AxisX.Maximum = 360;
            functii_chart.ChartAreas[0].AxisX.Interval = 90;
        }
    }
}