using System;
using System.Windows.Forms;

namespace OTI2010V2
{
    public partial class CIA2010 : Form
    {
        public static bool[] windowsOpen = new bool[3];

        public CIA2010()
        {
            InitializeComponent();
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show form despre 
            if (windowsOpen[0])
                return;

            windowsOpen[0] = true;
            Despre dp = new Despre();
            dp.Show();
        }

        private void trigonometrieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (windowsOpen[1])
                return;

            windowsOpen[1] = true;
            Trigonometrie tr = new Trigonometrie();
            tr.Show();
        }

        private void bazaDeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (windowsOpen[2])
                return;

            windowsOpen[2] = true;
            database db = new database();
            db.Show();
        }
    }
}