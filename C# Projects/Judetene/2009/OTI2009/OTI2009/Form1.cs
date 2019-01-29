using System;
using System.Windows.Forms;

namespace OTI2009
{
    public partial class Main : Form
    {
        public static bool[] is_active = new bool[3];
        Calculator calc;
        Database db;
        Rotire rot;

        public Main()
        {
            InitializeComponent();
        }

        private void calculator_Click(object sender, EventArgs e)
        {
            if (is_active[0])
                return;

            calc = new Calculator();
            is_active[0] = true;
            calc.Show();
        }

        private void dataBase_Click(object sender, EventArgs e)
        {
            if (is_active[1])
                return;

            db = new Database();
            is_active[1] = true;
            db.Show();
        }

        private void turn_Click(object sender, EventArgs e)
        {
            if (is_active[2])
                return;

            rot = new Rotire();
            is_active[2] = true;
            rot.Show();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
