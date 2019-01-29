using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace OTI2010V2
{
    public partial class database : Form
    {
	    public int row = 0;
	    public OleDbConnection con = null;
	    public DataTable table;

        public void Open(ref OleDbConnection conexiune)
        {
            string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Scoala.accdb;");
            try
            {
                conexiune = new OleDbConnection(connString);
                conexiune.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public DataTable createTable(string tableName)
        {
            DataTable dt = new DataTable();
            Open(ref con);
            try
            {
                string sql = string.Format($"SELECT * FROM {tableName};");
                OleDbCommand comand = new OleDbCommand(sql, con);
                OleDbDataAdapter adp = new OleDbDataAdapter(comand);
                adp.Fill(dt);
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public void execSql(string sql)
        {
            Open(ref con);
            try
            {
                OleDbCommand comand = new OleDbCommand(sql, con);
                comand.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public database()
        {
            InitializeComponent();
        }

        private void database_FormClosing(object sender, FormClosingEventArgs e)
        {
            CIA2010.windowsOpen[2] = false;
        }

        public void refreshTable()
        {
            table = createTable("Elevi");
            db_dgv.DataSource = table;
        }

        private void afisareEleviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void adaugareElevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = string.Format("INSERT INTO Elevi(Nume,Prenume,Clasa,Absente)VALUES('{0}','{1}','{2}',{3});", db_dgv[1, row].Value, db_dgv[2, row].Value, db_dgv[3, row].Value, db_dgv[4, row].Value);
            execSql(sql);
            refreshTable();
            MessageBox.Show("Inregistrare adaugata in baza de date.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void stergeElevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = string.Format("DELETE * FROM Elevi WHERE IDElev={0};", db_dgv[0, row].Value);
            execSql(sql);
            refreshTable();
            MessageBox.Show("Inregistrare a fost stearsa din baza de date.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void alfabeticaDupaNumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM Elevi ORDER BY Nume ASC;");
            OleDbCommand comand = new OleDbCommand(sql, con);
            OleDbDataAdapter adp = new OleDbDataAdapter(comand);
            table.Clear();
            adp.Fill(table);
            db_dgv.DataSource = table;
            MessageBox.Show("Elevi au fost afisati in ordine crescatoare dupa nume.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void descrescătoareDupăAbsenţeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM Elevi ORDER BY Absente DESC;");
            OleDbCommand comand = new OleDbCommand(sql, con);
            OleDbDataAdapter adp = new OleDbDataAdapter(comand);
            table.Clear();
            adp.Fill(table);
            db_dgv.DataSource = table;
            MessageBox.Show("Elevi au fost afisati in ordine descrescatoare dupa.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void db_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                row = e.RowIndex;
            }
        }
    }
}