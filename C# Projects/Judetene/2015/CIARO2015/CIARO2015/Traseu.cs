using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace CIARO2015
{
    public partial class Traseu : Form
    {
        List<Point> points = new List<Point>();
        public Traseu()
        {
            InitializeComponent();
            string[] items = Turist.index_cell.Split(',');
            for (int i = 0; i < items.Length; i++)
            {
                string punct_x = MyData.getData("Porturi","Pozitie_X","Nume_port",Turist.numePorturi[Convert.ToInt32(items[i])-1],1);
                string punct_y = MyData.getData("Porturi", "Pozitie_Y", "Nume_port", Turist.numePorturi[Convert.ToInt32(items[i])-1], 1);
                Point punct = new Point();
                punct.X = Convert.ToInt32(punct_x);
                punct.Y = Convert.ToInt32(punct_y);
                points.Add(punct);
            }
        }

        private void Traseu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Calatorie.CloseMain();
        }

        private void inchide_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Calatorie.op.MainForm.Show();
        }

        private void traseu_img_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < points.Count-1;i++)
            {
                Pen myPen = new Pen(Color.Red, 5);
                Pen myRectPen = new Pen(i==0? Color.Green:Color.Blue, 3);
                Rectangle rect = new Rectangle();
                rect.X = points[i].X - 3;
                rect.Y = points[i].Y - 4;
                rect.Width = 15;
                rect.Height = 15;
                e.Graphics.DrawRectangle(myRectPen,rect);
                e.Graphics.DrawLine(myPen,points[i],points[i+1]);
                myPen.Dispose();
                myRectPen.Dispose();
            }
        }
    }
}