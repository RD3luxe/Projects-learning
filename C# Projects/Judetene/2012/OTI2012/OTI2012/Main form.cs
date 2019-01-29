using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OTI2012
{
    public partial class Main_form : Form
    {
        public static string[] director_acc = new string[2] { "director", "director" };
        public static bool IsProfessor = false, IsLogged = false;
        public static int id_user = 0;
        public static string[] date;
        public static StudentPanel studenpnl;
        public static ProfesorPanel profesorpnl;
        public static DirectorPanel directorpnl;

        public Main_form()
        {
            InitializeComponent();
        }

        private void create_acc_Click(object sender, EventArgs e)
        {
            //open create form :)
            CreateAccount acc = new CreateAccount();
            acc.Show();
            this.Hide();
        }

        private void log_in_Click(object sender, EventArgs e)
        {
            if (user_txt.Text == string.Empty || pass_txt.Text == string.Empty)
            {
                MessageBox.Show("Campuri invalide , te rog sa introduci campuri valide.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_txt.Focus();
                return;
            }
            IsLogged = false;
            IsProfessor = false;
            if (user_txt.Text == director_acc[0] && user_txt.Text == director_acc[1])
            {
                //director control panel 
                IsProfessor = false;
                IsLogged = true;
                directorpnl = new DirectorPanel();
                directorpnl.main = this;
                directorpnl.TextMain[0] = user_txt;
                directorpnl.TextMain[1] = pass_txt;
                this.Hide();
                directorpnl.Show();
            }
            else
            {
                string sql = string.Format("SELECT Nick,Parola FROM Studenti WHERE Nick='{0}' AND Parola='{1}';", user_txt.Text, pass_txt.Text);
                string sql2 = string.Format("SELECT Nick,Pass FROM Profesori WHERE Nick='{0}' AND Pass='{1}';", user_txt.Text, pass_txt.Text);
                short countStudenti = MyData.countData(sql);
                short countProfesor = MyData.countData(sql2);
                if (countStudenti == 1)
                {
                    IsProfessor = false;
                    IsLogged = true;
                    string sqlQ = string.Format("SELECT ID_Student FROM Studenti WHERE Nick='{0}' and Parola='{1}';", user_txt.Text, pass_txt.Text);
                    id_user = MyData.selectData(sqlQ, "ID_Student");
                    string[] numestudent = new string[2] { "Nume", "Prenume" };
                    date = MyData.getData("Grades", numestudent, "ID_Student", id_user);
                    string update = string.Format("UPDATE Studenti SET Ultima_logare='{0}' WHERE ID_Student={1};",DateTime.Now,id_user);
                    MyData.execSql(update);
                    MessageBox.Show("Bine ai venit " + date[0] + " " + date[1] + " !", "Bine ai revenit !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //show student form.
                    studenpnl = new StudentPanel();
                    studenpnl.main = this;
                    studenpnl.TextMain[0] = user_txt;
                    studenpnl.TextMain[1] = pass_txt;
                    studenpnl.Show();
                    this.Hide();
                }
                else if (countProfesor == 1)
                {
                    IsProfessor = true;
                    IsLogged = true;
                    string sqlQ = string.Format("SELECT ID_Prof FROM Profesori WHERE Nick='{0}' and Pass='{1}';", user_txt.Text, pass_txt.Text);
                    id_user = MyData.selectData(sqlQ, "ID_Prof");
                    string[] numeprof = new string[2] { "Nume", "Prenume" };
                    string[] date = MyData.getData("Materii", numeprof, "IDProfesor", id_user);
                    string update = string.Format("UPDATE Profesori SET Ultima_logare='{0}' WHERE ID_Prof={1};", DateTime.Now, id_user);
                    MyData.execSql(update);
                    MessageBox.Show("Bine ai venit , profesor " + date[0] + " " + date[1] + " !", "Bine ai revenit !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //show prof form.
                    profesorpnl = new ProfesorPanel();
                    //set main
                    profesorpnl.main = this;
                    profesorpnl.Info[0] = user_txt;
                    profesorpnl.Info[1] = pass_txt;
                    profesorpnl.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nume sau parola gresita, te rog sa introduci din nou campurile.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    user_txt.Focus();
                    user_txt.Text = pass_txt.Text = string.Empty;
                }
            }
        }

        public static void CloseMain()
        {
            Application.Exit();
        }
    }

    class MyData
    {
        public static OleDbConnection connection = null;
        public static void OpenCon(ref OleDbConnection conn)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TesteDB.accdb;";
            try
            {
                conn = new OleDbConnection(connString);
                conn.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
        }        
        public static void readTable(string TableName,ref DataTable dt)
        {
            OpenCon(ref connection);
            try
            {
                string sql = "SELECT * FROM "+TableName+";";
                OleDbCommand comand = new OleDbCommand(sql, connection);
                OleDbDataAdapter adp = new OleDbDataAdapter(comand);
                adp.Fill(dt);
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        public static void readTable(string TableName,string ColumnName,ref DataTable dt)
        {
            OpenCon(ref connection);
            try
            {
                string sql = string.Format("SELECT {0} FROM {1};", ColumnName, TableName);
                OleDbCommand comand = new OleDbCommand(sql, connection);
                OleDbDataAdapter adp = new OleDbDataAdapter(comand);
                adp.Fill(dt);
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());

            }
            finally
            {
                connection.Close();
            }
        }
        public static DataTable readTable(string sql)
        {
            DataTable dt = new DataTable();
            OpenCon(ref connection);
            try
            {
                OleDbCommand comand = new OleDbCommand(sql, connection);
                OleDbDataAdapter adp = new OleDbDataAdapter(comand);
                adp.Fill(dt);
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static void execSql(string sql)
        {
            OpenCon(ref connection);
            try
            {
                OleDbCommand comand = new OleDbCommand(sql, connection);
                comand.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        public static int selectData(string sql, string what)
        {
            int data = 0;
            OpenCon(ref connection);
            try
            {
                OleDbCommand comand = new OleDbCommand(sql, connection);
                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    data = Convert.ToInt32(reader[what]);
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return data;
        }

        public static int takeMax(string table,string what)
        {
            int maxx = 0;
            OpenCon(ref connection);
            try
            {
                string sql = string.Format($"SELECT MAX({what}) FROM {table};");
                OleDbCommand command = new OleDbCommand(sql, connection);
                maxx = (int)command.ExecuteScalar();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return maxx;
        }

        public static int takeMax(string table, string what,string checker,string val)
        {
            int maxx = 0;
            OpenCon(ref connection);
            try
            {
                string sql = string.Format($"SELECT MAX({what}) FROM {table} WHERE {checker}='{val}';");
                OleDbCommand command = new OleDbCommand(sql, connection);
                maxx = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return maxx;
        }

        public static int Count(string sql)
        {
            int numara = 0;
            OpenCon(ref connection);
            try
            {
                OleDbCommand command = new OleDbCommand(sql, connection);
                numara = (int)command.ExecuteScalar();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return numara;
        }

        public static string stringSelector(string sql, string what)
        {
            string data = string.Empty;
            OpenCon(ref connection);
            try
            {
                OleDbCommand comand = new OleDbCommand(sql, connection);
                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    data = reader[what].ToString();
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return data;
        }

        public static string[] getData(string TableName,string[] DataSearch,string key,int keyvalue)
        {
            OpenCon(ref connection);
            string[] datavalues = new string[DataSearch.Length];
            try
            {
                string selectedData = DataSearch[0];
                if (DataSearch.Length >= 2)
                {
                    for (int i = 1; i < DataSearch.Length; i++)
                        selectedData = string.Format("{0},{1}", selectedData, DataSearch[i]);
                }
                string sql = string.Format("SELECT {0} FROM {1} WHERE {2}={3};",selectedData,TableName,key,keyvalue);
                OleDbCommand comand = new OleDbCommand(sql, connection);
                OleDbDataReader reader = comand.ExecuteReader();
                while(reader.Read())
                {
                    for (int i = 0; i < DataSearch.Length; i++)
                    {
                        datavalues[i] = reader[DataSearch[i]].ToString();
                    }
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return datavalues;
        }
        public static string[] getData(string sql, string[] DataSearch)
        {
            OpenCon(ref connection);
            string[] datavalues = new string[DataSearch.Length];
            try
            {
                string selectedData = DataSearch[0];
                OleDbCommand comand = new OleDbCommand(sql, connection);
                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < DataSearch.Length; i++)
                    {
                        datavalues[i] = reader[DataSearch[i]].ToString();
                    }
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return datavalues;
        }
        public static short countData(string sql)
        {
            OpenCon(ref connection);
            short count = 0;
            try
            {
                OleDbCommand comand = new OleDbCommand(sql, connection);
                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read()) count++;
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return count;
        }
    }
}