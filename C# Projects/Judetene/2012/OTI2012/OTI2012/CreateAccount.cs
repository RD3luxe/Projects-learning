using System;
using System.Windows.Forms;

namespace OTI2012
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CreateAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_form.CloseMain();
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            if (nume_txt.Text == string.Empty || nick_txt.Text == string.Empty || prenume_txt.Text == string.Empty || pass_txt.Text == string.Empty || repass_txt.Text == string.Empty)
            {
                MessageBox.Show("Toate campurile sunt obligatorii.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (nick_txt.Text == Main_form.director_acc[0])
            {
                MessageBox.Show("Nickname deja folosit,alege altul.", "Nick folosit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nick_txt.Text = string.Empty;
                return;
            }
            //verifica daca contul exista in baza de date Studenti si Profesori ( nick -ul mai exact ) dupa verifica daca exista numele si prenumele in baza de date.
            if(NickAlreadyExisted(nick_txt.Text))
            {
                MessageBox.Show("Nickname deja folosit,alege altul.", "Nick folosit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nick_txt.Text = string.Empty;
            }
            if (NumeAlreadyExisted(nume_txt.Text, prenume_txt.Text))
            {
                MessageBox.Show("Acel nume si prenume exista deja in baza de date.Poti avea doar un cont cu acealsi nume.", "Nume existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nume_txt.Text = prenume_txt.Text = string.Empty;
            }
            //update table
            string addsql = string.Format("INSERT INTO Studenti(Nick,Parola)VALUES('{0}','{1}');",nick_txt.Text, pass_txt.Text);
            MyData.execSql(addsql);
            string sqlID = string.Format("SELECT ID_Student FROM Studenti WHERE Nick='{0}' and Parola='{1}';",nick_txt.Text, pass_txt.Text);
            int id_student = MyData.selectData(sqlID, "ID_Student");
            string addNume = string.Format("INSERT INTO Grades(ID_Student,Nume,Prenume)VALUES({0},'{1}','{2}');",id_student,nume_txt.Text,prenume_txt.Text);
            MyData.execSql(addNume);
            MessageBox.Show("Cont creat cu succes, acum te poti loga !", "Succes !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Main_form.CloseMain();
        }

        public static bool NickAlreadyExisted(string nick)
        {
            string sql = string.Format("SELECT Nick FROM Studenti WHERE Nick='{0}';", nick);
            string sql2 = string.Format("SELECT Nick FROM Profesori WHERE Nick='{0}';", nick);
            short countStudenti = MyData.countData(sql);
            short countProfesor = MyData.countData(sql2);
            if (countProfesor >= 1 || countStudenti >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool NumeAlreadyExisted(string nume,string prenume)
        {
            string sqlQ = string.Format("SELECT ID_Student FROM Grades WHERE Nume='{0}' AND Prenume='{1}';", nume, prenume);
            string sqlprof = string.Format("SELECT IDProfesor FROM Materii WHERE Nume='{0}' AND Prenume='{1}';", nume, prenume);
            short countStudentNume = MyData.countData(sqlQ);
            short countprofNume = MyData.countData(sqlprof);
            if (countStudentNume >= 1 || countprofNume >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void repass_txt_Leave(object sender, EventArgs e)
        {
            if (!pass_txt.Text.Equals(repass_txt.Text))
            {
                MessageBox.Show("Parolele nu coincid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pass_txt.Text = repass_txt.Text = string.Empty;
                pass_txt.Focus();
            }
        }

        private void pass_txt_Leave(object sender, EventArgs e)
        {
            if (pass_txt.Text.Length < 6)
            {
                MessageBox.Show("Parola ta trebuie sa aiba cel putin 6 caractere.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pass_txt.Text = string.Empty;
                pass_txt.Focus();
            }
        }
    }
}