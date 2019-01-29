using System;
using System.Windows.Forms;

namespace CIARO2016
{
    public partial class Creare_cont_client : Form
    {
        public Creare_cont_client()
        {
            InitializeComponent();
        }
        //close main form
        private void Creare_cont_client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Start.CloseMainForm();
        }

        private void repass_txt_Leave(object sender, EventArgs e)
        {
            if(pass_txt.Text != repass_txt.Text)
            {
                MessageBox.Show("Parolele nu coincid te rog sa reintroduci parolele.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pass_txt.Text = "";
                repass_txt.Text = "";
            }
        }

        private void createacc_btn_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT email FROM Clienti WHERE email = '{0}';", email_txt.Text);
            short email_exist = MyData.countApparitions(query);
            if (pass_txt.Text == String.Empty || repass_txt.Text == String.Empty || nume_txt.Text == String.Empty || email_txt.Text == String.Empty || pre_txt.Text == String.Empty || adr_txt.Text == String.Empty)
            {
                MessageBox.Show("Toate campurile sunt obligatorii.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!Start.emailIsValid(email_txt.Text))
            {
                MessageBox.Show("Emailul nu este valid! ", "Email Invalid", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                email_txt.Text = "";
            }//daca emailul exista deja throw error...
            else if(email_exist >= 1)
            {
                MessageBox.Show("Acest e-mail exista deja in baza de date. ", "Email Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                email_txt.Text = "";
            }
            else
            {
                //add to database.
                string Query = string.Format("INSERT INTO Clienti(parola,nume,prenume,adresa,email,kcal_zilnice)VALUES('{0}','{1}','{2}','{3}','{4}',2000);",pass_txt.Text,nume_txt.Text,pre_txt.Text,adr_txt.Text,email_txt.Text);
                MyData.writeData("Clienti",Query);
                MessageBox.Show("Contul a fost creat cu succes.", "Inregistrare cu succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Start.CloseMainForm();
            }
        }

        private void pass_txt_Leave(object sender, EventArgs e)
        {
            if(pass_txt.Text.Length < 4)
            {
                MessageBox.Show("Parola ta trebuie sa aiba cel putin 4 caractere.", "Parola prea scurta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                pass_txt.Text = "";
                repass_txt.Text = "";
            }
        }
    }
}