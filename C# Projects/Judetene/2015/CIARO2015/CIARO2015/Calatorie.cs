using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace CIARO2015
{
    public partial class Calatorie : Form
    {
        public static bool IsAdmin = false;
        public static Operatii op;
        string[,] conturi = new string[4,3]
        {
            { "Administrator","agentie2015","1" },
            { "Turist","oti2015","0" },
            { "1","1","1" },
            { "0","0","0" }
        };
        public Calatorie()
        {
            InitializeComponent();
        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            if(name_txt.Text == String.Empty || pass_txt.Text == String.Empty)
            {
                MessageBox.Show("Toate campurile trebuie completate.", "Eroare !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for(int i = 0; i < conturi.GetLength(0);i++)
            {
                if(conturi[i,0].Equals(name_txt.Text) && conturi[i,1].Equals(pass_txt.Text))
                {
                    if(Convert.ToInt32(conturi[i,2]) == 1)
                    {
                        IsAdmin = true;
                    }else{
                        IsAdmin = false;
                    }
                    op = new Operatii();
                    op.MainForm = this;
                    this.Hide();
                    op.Show();
                }
            }
        }
        public static void CloseMain()
        {
            Application.Exit();
        }
    }

    public class MyData 
    {
        public static OleDbConnection conn = null;
        public static void OpenConnection(ref OleDbConnection con, int type)
        {
            try
            {
                string connectionString = null;
                if (type == 1)
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DBTimpSpatiu.accdb;";
                else
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Matrice.xlsx;Extended Properties = Excel 12.0;";
                con = new OleDbConnection(connectionString);
                con.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static void readTable(string TableName,ref DataTable table, int type)
        {
            OpenConnection(ref conn,type == 1? 1:2);
            try
            {
                string SqlSintax = null;
                if (type == 1)
                    SqlSintax = "Select * from "+TableName+";";
                else
                    SqlSintax = "Select * from ["+ TableName +"$];";
                OleDbCommand comand = new OleDbCommand(SqlSintax,conn);
                OleDbDataAdapter adp = new OleDbDataAdapter(comand);
                adp.Fill(table);
            }
            catch(OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static string getData(string TableName,string dt_search,string pointer,string pointer_val,int type)
        {
            OpenConnection(ref conn, type == 1 ? 1 : 2);
            string data = String.Empty;
            try
            {
                string SqlSintax = String.Empty;
                if (type == 1)
                    SqlSintax = string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}';", dt_search, TableName, pointer, pointer_val);
                else
                    SqlSintax = string.Format("SELECT {0} FROM [{1}$] WHERE {2} = '{3}';", dt_search, TableName, pointer, pointer_val);
                OleDbCommand comand = new OleDbCommand(SqlSintax,conn);
                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read()) data = reader[dt_search].ToString();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return data;
        }

        public static int getData(string TableName,string dt_search,int val1,int val2,string val3,int type)
        {
            OpenConnection(ref conn, type == 1 ? 1 : 2);
            int data = 0;
            try
            {
                string SqlSintax = String.Empty;
                if (type == 1)
                    SqlSintax = string.Format("SELECT {0} FROM {1} WHERE ID_Port = {2} AND ID_Port_Destinatie = {3} AND Nume_Port_Destinatie = '{4}';", dt_search,TableName,val1,val2,val3);
                else
                    SqlSintax = string.Format("SELECT {0} FROM [{1}$] WHERE ID_Port = {2} AND ID_Port_Destinatie = {3} AND Nume_Port_Destinatie = '{4}';", dt_search, TableName, val1, val2, val3);
                OleDbCommand comand = new OleDbCommand(SqlSintax, conn);
                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read()) data = Convert.ToInt32(reader[dt_search]);
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return data;
        }

        public static int countData(string Tablename,string what,int type)
        {
            int count = 0;
            string sql = string.Empty;
            OpenConnection(ref conn, type == 1 ? 1 : 2);
            try
            {
                if(type == 1)
                    sql = "SELECT " + what + " FROM " + Tablename + ";";
                else if(type == 2)
                    sql = "SELECT " + what + " FROM [" + Tablename + "$];";
                OleDbCommand comand = new OleDbCommand(sql,conn);
                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read()) count++;
            }
            catch(OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return count; 
        }

        public static int countData(string Tablename,string what,int value,int type)
        {
            int count = 0;
            string sql = string.Empty;
            OpenConnection(ref conn, type == 1 ? 1 : 2);
            try
            {
                string Tablexcel = string.Format("[{0}$]", Tablename);
                sql = string.Format("SELECT {3} FROM {0} WHERE {1} = {2};",type == 1? Tablename:Tablexcel,what,value,what);
                OleDbCommand comand = new OleDbCommand(sql, conn);
                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read()) count++;
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public static void setData(string SqlStatement,int type)
        {
            OpenConnection(ref conn, type == 1 ? 1 : 2);
            try
            {
                OleDbCommand comand = new OleDbCommand(SqlStatement,conn);
                comand.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}