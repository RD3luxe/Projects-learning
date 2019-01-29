using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace OTI2009
{
    public partial class Database : Form
    {
        public OleDbConnection connection = null;
        DataTable data;
        int row = -1;

        public Database()
        {
            InitializeComponent();
            RefreshDgv();
        }

        public void OpenDB(ref OleDbConnection con)
        {
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Studenti.accdb;");
            try
            {
                con = new OleDbConnection(connectionString);
                con.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public DataTable getTable(string tableName)
        {
            DataTable dt = new DataTable();
            OpenDB(ref connection);
            try
            {
                string sql = string.Format($"SELECT * FROM {tableName};");
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

        public void execSql(string sql )
        {
            OpenDB(ref connection);
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

        private void add_btn_Click(object sender, EventArgs e)
        {
            //refresh
            if (row == -1)
            {
                MessageBox.Show("Mai intai trebuie sa selectezi randul.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = string.Format("INSERT INTO TabelaElevi (Nume,Nota1,Nota2)VALUES('{0}',{1},{2});", studenti_dgv["Nume", row].Value, studenti_dgv["Nota1", row].Value, studenti_dgv["Nota2", row].Value);
            execSql(sql);
            MessageBox.Show("Inregistrarea a fost adaugata cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDgv();
        }

        private void sterg_btn_Click(object sender, EventArgs e)
        {
            //refresh
            if (row == -1)
            {
                MessageBox.Show("Mai intai trebuie sa selectezi randul.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = string.Format("DELETE * FROM TabelaElevi WHERE ID={0};",studenti_dgv["ID", row].Value);
            execSql(sql);
            MessageBox.Show("Inregistrarea a fost stearsa cu succes.","Succes",MessageBoxButtons.OK,MessageBoxIcon.Information);
            RefreshDgv();
        }

        private void media_btn_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < studenti_dgv.Rows.Count-1;i++)
            {
                if (studenti_dgv["Nota1", i].Value.ToString() == string.Empty || studenti_dgv["Nota2", i].Value.ToString() == string.Empty)
                    continue;

                studenti_dgv["Medie", i].Value = Convert.ToInt32(studenti_dgv["Nota1", i].Value) + Convert.ToInt32(studenti_dgv["Nota2", i].Value);
            }
        }

        private void salvare_btn_Click(object sender, EventArgs e)
        {
            //refresh
            for (int i = 0; i < studenti_dgv.Rows.Count-1; i++)
            {
                string sql = string.Format("UPDATE TabelaElevi SET Medie={0} WHERE ID={1};",studenti_dgv["Medie",i].Value,studenti_dgv["ID",i].Value);
                execSql(sql);
            }
            RefreshDgv();
            MessageBox.Show("Tabelul a fost salvat cu succes.", "Salvare cu succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Main.is_active[1] = false;
            Application.Exit();
        }

        private void studenti_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        public void RefreshDgv()
        {
            data = getTable("TabelaElevi");
            studenti_dgv.DataSource = data;
        }

        private void Database_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.is_active[1] = false;
        }
    }
}