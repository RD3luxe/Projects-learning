using System;
using System.Drawing;
using System.Windows.Forms;

namespace OTI2009
{
    public partial class Rotire : Form
    {
        int mijloc;
        Point p1,p2;
        Graphics g;
        //set initial position
        int[,] coords = new int[2, 2] { { 80, 178 }, { 340, 178 } };
        int angle = 0;

        public Rotire()
        {
            InitializeComponent();
            mijloc = coords[1, 0] / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle ++;
            this.Invalidate();
        }

        private void Rotire_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Pen p = new Pen(Color.Red);
            p1 = new Point(x: coords[0, 0], y: coords[0, 1]);
            p2 = new Point(x: coords[1, 0], y: coords[1, 1]);
            if (timer1.Enabled)
            {
                p1.X = (int)(p1.X - Math.Round(mijloc * (Math.Sin(angle * Math.PI / 180))));
                p1.Y = (int)(p1.Y + Math.Round(mijloc * (Math.Cos(angle * Math.PI / 180))));
                p2.X = (int)(p2.X - Math.Round(mijloc * (Math.Sin((angle + 180) * Math.PI / 180))));
                p2.Y = (int)(p2.Y + Math.Round(mijloc * (Math.Cos((angle + 180) * Math.PI / 180))));
            }
            g.DrawLine(p,p1,p2);
        }

        private void Rotire_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.is_active[2] = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
            {
                button1.Text = "Opreste rotirea";
            }
            else
            {
                button1.Text = "Incepe rotirea";
            }
        }
    }
}