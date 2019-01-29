using System;
using System.Windows.Forms;

namespace CIARO2016
{
    public partial class Autentificare_client : Form
    {
        public static Start StartForm;
        public Start MainForm
        {
            set
            {
                StartForm = value;
            }
            get
            {
                return StartForm;
            }
        }
        public Autentificare_client()
        {
            InitializeComponent();
        }
        //close main form
        private void Autentificare_client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Start.CloseMainForm();
        }

        private void ComeIn_Btn_Click(object sender, EventArgs e)
        {
            short exist = 0;
            string query = string.Format("SELECT email,parola FROM Clienti WHERE email = '{0}' and parola = '{1}';",email_txt.Text,pass_txt.Text);
            exist = MyData.countApparitions(query);
            if (email_txt.Text == String.Empty || pass_txt.Text == String.Empty)
            {
                MessageBox.Show("Introdu datele toate datele,te rog.","Eroare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if(exist == 0)
            {
                MessageBox.Show("Nume sau parola incorect.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                email_txt.Text = "";
                pass_txt.Text = "";
            }
            else
            {
                string s = MyData.selectData("Clienti", "nume", email_txt.Text);
                s = s + " "+ MyData.selectData("Clienti", "prenume", email_txt.Text);
                MessageBox.Show("Bine ai revenit, " + s + "!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MyData.e_mail = email_txt.Text;
                Optiuni opt = new Optiuni();
                opt.Show();
                this.Hide();
            }
        }
    }
}