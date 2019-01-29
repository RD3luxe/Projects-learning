using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data;

namespace CIARO2016
{
    public partial class Start : Form
    {
        public static Autentificare_client auth;
        public Start()
        {
            InitializeComponent();
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            Creare_cont_client create_acc = new Creare_cont_client();
            this.Hide();
            create_acc.Show();
        }

        private void autentificare_btn_Click(object sender, EventArgs e)
        {
            auth = new Autentificare_client();
            auth.MainForm = this;
            this.Hide();
            auth.Show();
        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email,expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            else
            {
                return false;
            }
        }

        //close main form cand o alta forma e inchisa.
        public static void CloseMainForm()
        {
            Application.Exit();
        }
    }
    //database acces class
    public class MyData
    {
        public static OleDbConnection MyConnection = null;
        //folosim ca punct de referinta cand trebuie modificat ceva modificam in functie de e-mailul userului.
        public static string e_mail = String.Empty;
        //open db
        public static void OpenDB(ref OleDbConnection conn)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GOOD_FOOD.accdb";
            conn = null;
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
        //read from db
        public static void readDataTable(string TableName,ref DataGridView result)
        {
            OpenDB(ref MyConnection);
            try
            {
                string mySql = "SELECT * FROM " + TableName;
                OleDbCommand comm = new OleDbCommand(mySql, MyConnection);
                OleDbDataAdapter myCmd = new OleDbDataAdapter(comm);
                DataSet dt = new DataSet();
                myCmd.Fill(dt,TableName);
                result.DataSource = dt.Tables[TableName].DefaultView;
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MyConnection.Close();
            }
        }
        //count data 
        public static short countApparitions(string Query)
        {
            OpenDB(ref MyConnection);
            short count = 0;
            try
            {
                OleDbCommand command = new OleDbCommand(Query, MyConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read()) count++;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MyConnection.Close();
            }
            return count;
        }
        //add data
        public static void writeData(string TableName,string Query)
        {
            OpenDB(ref MyConnection);
            try
            {
                OleDbCommand cmd = new OleDbCommand(Query, MyConnection);
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MyConnection.Close();
            }
        }
        //select data
        public static string selectData(string TableName,string Data,string eMailPointer)
        {
            string myReturnedData = String.Empty;
            OpenDB(ref MyConnection);
            try
            {
                string query = string.Format("SELECT {0} FROM {1} WHERE email = '{2}';",Data,TableName,eMailPointer);
                OleDbCommand cmd = new OleDbCommand(query, MyConnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) myReturnedData = reader[Data].ToString();
            }
            catch(OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MyConnection.Close();
            }
            return myReturnedData;
        }
        //select all data
        public static void selectAllData(string TableName, string Data, string Pointer, string PointerValue,ref string[] array)
        {
            OpenDB(ref MyConnection);
            try
            {
                string query = string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}';", Data, TableName, Pointer, PointerValue);
                OleDbCommand cmd = new OleDbCommand(query, MyConnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    array[i] = reader[Data].ToString();
                    i++;
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MyConnection.Close();
            }
        }
        public static void selectAllData(string TableName, string Data, string Pointer,int PointerValue, ref string[] array)
        {
            OpenDB(ref MyConnection);
            try
            {
                string query = string.Format("SELECT {0} FROM {1} WHERE {2} = {3};", Data, TableName, Pointer, PointerValue);
                OleDbCommand cmd = new OleDbCommand(query, MyConnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    array[i] = reader[Data].ToString();
                    i++;
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MyConnection.Close();
            }
        }
        //better select data
        public static string selectData(string TableName, string Data, string Pointer,string PointerValue)
        {
            string myReturnedData = String.Empty;
            OpenDB(ref MyConnection);
            try
            {
                string query = string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}';", Data,TableName,Pointer,PointerValue);
                OleDbCommand cmd = new OleDbCommand(query, MyConnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) myReturnedData = reader[Data].ToString();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MyConnection.Close();
            }
            return myReturnedData;
        }
    }
}
/*v2 email validation
public static bool email_valid(string email)
{
    //checking if the e-mail has the correct format
    bool valid = true;
    if (!(email.IndexOf('@') > 0 && 
        email.IndexOf('@', email.IndexOf('@') + 1) <= 0 &&
        email.LastIndexOf('.') > email.IndexOf('@') &&
        email.LastIndexOf('.') != email.Length - 1 &&
        email.Substring(email.IndexOf('@')).Count(c => c == '.') <= 2 &&
        (email.IndexOf('.',email.IndexOf('@'))==email.LastIndexOf('.') ||
        email.LastIndexOf('.')-email.Substring(email.IndexOf('@')).IndexOf('.')>1)))
    {
        valid = false;
        error_string += "The E-mail does not have the correct format.\r\n";
    }
    return valid;
}
*/