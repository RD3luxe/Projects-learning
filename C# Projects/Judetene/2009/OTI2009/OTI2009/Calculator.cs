using System;
using System.Windows.Forms;

namespace OTI2009
{
    public partial class Calculator : Form
    {
        int operatie = 0;
        public Calculator()
        {
            InitializeComponent();
        }

        private void square_btn_Click(object sender, EventArgs e)
        {
            if (!CheckOperation(1))
            {
                MessageBox.Show("Nu poti avea o inregistrare goala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckOperation(2))
            {
                MessageBox.Show("Trebuie sa introduci numere in casute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            operatie = 5;
        }

        private void rad_btn_Click(object sender, EventArgs e)
        {
            if (!CheckOperation(1))
            {
                MessageBox.Show("Nu poti avea o inregistrare goala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckOperation(2))
            {
                MessageBox.Show("Trebuie sa introduci numere in casute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            operatie = 6;
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (operatie == 0)
                return;

            if (!CheckOperation(1))
            {
                MessageBox.Show("Nu poti avea o inregistrare goala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckOperation(2))
            {
                MessageBox.Show("Trebuie sa introduci numere in casute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (operatie)
            {
                case 1:
                    rezultat_txt.Text = (Convert.ToInt32(nr1_txt.Text) + Convert.ToInt32(nr2_txt.Text)).ToString();
                    break;
                case 2:
                    rezultat_txt.Text = (Convert.ToInt32(nr1_txt.Text) - Convert.ToInt32(nr2_txt.Text)).ToString();
                    break;
                case 3:
                    rezultat_txt.Text = (Convert.ToInt32(nr1_txt.Text) / Convert.ToInt32(nr2_txt.Text)).ToString();
                    break;
                case 4:
                    rezultat_txt.Text = (Convert.ToInt32(nr1_txt.Text) * Convert.ToInt32(nr2_txt.Text)).ToString();
                    break;
                case 5:
                    rezultat_txt.Text = Math.Pow(Convert.ToInt32(nr1_txt.Text), Convert.ToInt32(nr2_txt.Text)).ToString();
                    break;
                case 6:
                    rezultat_txt.Text = string.Format($"Primul : {Math.Round(Math.Sqrt(Convert.ToInt32(nr1_txt.Text)), 2)}  Al 2-lea : {Math.Round(Math.Sqrt(Convert.ToInt32(nr2_txt.Text)), 2)}");
                    break;
            }
            nr2_txt.Text = nr1_txt.Text = string.Empty;
        }

        private void inm_button_Click(object sender, EventArgs e)
        {
            if (!CheckOperation(1))
            {
                MessageBox.Show("Nu poti avea o inregistrare goala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckOperation(2))
            {
                MessageBox.Show("Trebuie sa introduci numere in casute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            operatie = 4;
        }

        private void sum_btn_Click(object sender, EventArgs e)
        {
            if (!CheckOperation(1))
            {
                MessageBox.Show("Nu poti avea o inregistrare goala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckOperation(2))
            {
                MessageBox.Show("Trebuie sa introduci numere in casute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            operatie = 1;
        }

        private void diff_btn_Click(object sender, EventArgs e)
        {
            if (!CheckOperation(1))
            {
                MessageBox.Show("Nu poti avea o inregistrare goala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckOperation(2))
            {
                MessageBox.Show("Trebuie sa introduci numere in casute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            operatie = 2;
        }

        private void impartire_btn_Click(object sender, EventArgs e)
        {
            if (!CheckOperation(1))
            {
                MessageBox.Show("Nu poti avea o inregistrare goala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckOperation(2))
            {
                MessageBox.Show("Trebuie sa introduci numere in casute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(nr2_txt.Text) == 0)
            {
                MessageBox.Show("Nu poti impartii un numar la 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nr2_txt.Text = string.Empty;
                return;
            }
            operatie = 3;
        }

        public bool CheckOperation(int tip)
        {
            bool is_int = true;
            if (tip == 1 || tip == 3)
            {
                if (nr1_txt.Text == string.Empty || nr2_txt.Text == string.Empty)
                {
                    is_int = false;
                }
            }
            if (tip == 2 || tip == 3)
            {
                if (!IsNumber(nr1_txt.Text) || !IsNumber(nr2_txt.Text))
                {
                    is_int = false;
                    nr2_txt.Text = nr1_txt.Text = string.Empty;
                }
            }
            return is_int;
        }

        public bool IsNumber(string s)
        {
            int nr;
            if (Int32.TryParse(s, out nr))
            {
                return true;
            }
            return false;
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            Main.is_active[0] = false;
            Application.Exit();
        }

        private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.is_active[0] = false;
        }
    }
}