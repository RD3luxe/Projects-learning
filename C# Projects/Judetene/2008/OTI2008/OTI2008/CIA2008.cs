using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace OTI2008
{
    public partial class CIA2008 : Form
    {
        DataTable dt = new DataTable();
        OleDbConnection con;

        public CIA2008()
        {
            InitializeComponent();
            panel_text.Visible = false;
            tabel_pnl.Visible = false;
            rezultat.Visible = false;
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_text.Visible = true;
            tabel_pnl.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(wr_txt.Text == string.Empty)
            {
                MessageBox.Show("Introdu un text mai intai.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            show_txt.Text = "Textul introdus este " + wr_txt.Text;
        }

        private void tabelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_text.Visible = false;
            tabel_pnl.Visible = true;
            nr_cautat.Visible = false;
            cauta_btn.Visible = false;
            rezultat.Visible = false;
            proiecte_dgv.Visible = true;
            InitTable();
        }

        public void InitTable()
        {
            dt = new DataTable();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ProiecteDB.accdb;");
            con.Open();
            OleDbCommand comand = new OleDbCommand("SELECT * FROM Proiecte;", con);
            OleDbDataAdapter adp = new OleDbDataAdapter(comand);
            adp.Fill(dt);
            proiecte_dgv.DataSource = dt;
            con.Close();
        }

        private void cautareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_text.Visible = false;
            tabel_pnl.Visible = true;
            nr_cautat.Visible = true;
            rezultat.Visible = false;
            cauta_btn.Visible = true;
            proiecte_dgv.Visible = true;
            InitTable();
        }

        private void cauta_btn_Click(object sender, EventArgs e)
        {
            int da;
            if (!Int32.TryParse(nr_cautat.Text, out da))
            {
                MessageBox.Show("Trebuie sa introduci un numar pentru a cauta o inregistrare.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nr_cautat.Text = string.Empty;
                return;
            }
            con.Open();
            string sql = string.Format("SELECT Nume FROM Proiecte WHERE Nume='Popescu';");
            DataTable dt = new DataTable();
            rezultat.Visible = true;
            proiecte_dgv.Visible = false;
            OleDbCommand comand = new OleDbCommand(sql, con);
            OleDbDataAdapter adp = new OleDbDataAdapter(comand);
            adp.Fill(dt);
            if(rezultat.Text == string.Empty)
            {
                MessageBox.Show("Nici o inregistrare nu a fost gasita cu acel index.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //rezultat.Text = comand.ExecuteScalar().ToString(); /*Doar cand stim sigur ca inregistrarea exista.*/
            con.Close();
        }
    }
}