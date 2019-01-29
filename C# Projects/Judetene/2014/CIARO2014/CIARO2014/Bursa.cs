using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace CIARO2014
{
    public partial class Bursa : Form
    {
        public bool BursaStart = false;
        public DataTable act_tb = new DataTable();
        public static DataTable all_data = new DataTable();
        string[,] data = new string[9,5];
        public static bool[] opened = new bool[2] { false, false };
        public static Actiunile_mele act;
        public static Grafic_profit graf;
        public static int timp_grafic,valoare_grafic;

        public Bursa()
        {
            InitializeComponent();
            MyData.readTable("Actiuni",ref act_tb);
            rata_nr.TabStop = false;
            timp_bursa.Interval = Convert.ToInt32(rata_nr.Value);
            if (all_data.Columns.Count == 0)
            {
                all_data.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("Denumire"),
                    new DataColumn("Număr acțiuni"),
                    new DataColumn("Valoare acțiune INIȚIAL"),
                    new DataColumn("Valoare acțiune momentan "),
                    new DataColumn("Valoarea cu care a crescut acțiunea momentan"),
                    new DataColumn("Total Valoare Inițial"),
                    new DataColumn("Total valoare momentană"),
                    new DataColumn("Profit / Pierdere momentană"),
                    new DataColumn("Profit / Pierdere total")
                });
            }
            for (int i = 0; i < data.GetLength(1); i++)
            {
                data[0,i] = act_tb.Rows[i]["Denumire"].ToString();
                data[1,i] = act_tb.Rows[i]["NrActiuni"].ToString();
                data[2,i] = act_tb.Rows[i]["Valoare"].ToString();
                data[5,i] = (Convert.ToInt32(act_tb.Rows[i]["NrActiuni"]) * Convert.ToInt32(act_tb.Rows[i]["Valoare"])).ToString();
            }
            close_btn.Enabled = false;
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (act != null)
                act.Focus();
            ToggleBursa();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            ToggleBursa();
            write("rezultate.txt", Actiunile_mele.total);
        }

        private void timp_bursa_Tick(object sender, EventArgs e)
        {
            if (BursaStart)
            {
                timp_grafic = Convert.ToInt32(rata_nr.Value) + Convert.ToInt32(rata_nr.Increment);
                rata_nr.Value = timp_grafic;
                timp_bursa.Interval = Convert.ToInt32(rata_nr.Value);
                Random rnd = new Random();
                int nr = rnd.Next(-5, 6);
                int total = 0;
                Actiunile_mele.total = 0.ToString();
                for (int i = 0; i < 5; i++)
                {
                    data[4,i] = (nr).ToString();
                    data[3,i] = (Convert.ToInt32(act_tb.Rows[i]["Valoare"]) + nr).ToString();
                    data[6,i] = (Convert.ToInt32(act_tb.Rows[i]["NrActiuni"]) * Convert.ToInt32(data[3,i])).ToString();
                    data[7,i] = (Convert.ToInt32(data[1,i]) * Convert.ToInt32(data[4,i])).ToString();
                    data[8,i] = (Convert.ToInt32(data[6,i]) - Convert.ToInt32(data[5,i])).ToString();
                    total = Convert.ToInt32(Actiunile_mele.total) + Convert.ToInt32(data[8, i]);
                    Actiunile_mele.total = total.ToString();
                }
                if (opened[1])
                {
                    graf.get_Chart.Series["data"].Points.AddXY(timp_grafic, total);
                }
            }
        }

        public void CreateTable()
        {
            try
            {
                all_data.Clear();
            }
            catch (DataException e)
            {
                MessageBox.Show(e.ToString());
            }
            for (int i = 0; i < data.GetLength(1); i++)
            {
                all_data.Rows.Add(new object[]
                {
                    data[0, i],
                    data[1, i],
                    data[2, i],
                    data[3, i],
                    data[4, i],
                    data[5, i],
                    data[6, i],
                    data[7, i],
                    data[8, i]
                });
            }
        }

        private void actiunileMele_Click(object sender, EventArgs e)
        {
            CreateTable();
            if (!opened[0])
            {
                act = new Actiunile_mele();
                act.Show();
                opened[0] = true;
            }
        }

        private void graficProfit_Click(object sender, EventArgs e)
        {
            if (!opened[1])
            {
                opened[1] = true;
                graf = new Grafic_profit();
                graf.Show();
                graf.Focus();
            }
        }

        public void ToggleBursa()
        {
            CreateTable();
            start_btn.Enabled = !start_btn.Enabled;
            close_btn.Enabled = !close_btn.Enabled;
            BursaStart = !BursaStart;
            timp_bursa.Enabled = !timp_bursa.Enabled;
        }

        public void write(string FileName,string value)
        {
            FileStream fs = new FileStream(FileName, FileMode.Append, FileAccess.Write);
            using (StreamWriter sr = new StreamWriter(fs))
            {
                sr.WriteLine(value);
                sr.Dispose();
            }
        }

        private void rata_nr_ValueChanged(object sender, EventArgs e)
        {
            timp_bursa.Interval = Convert.ToInt32(rata_nr.Value);
        }
    }

    //Database class
    public class MyData
    {
        public static OleDbConnection con = null;
        public static void OpenConection(ref OleDbConnection conexiune)
        {
            try
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DBBursa.accdb;";
                conexiune = new OleDbConnection(connectionString);
                conexiune.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static void readTable(string TableName, ref DataTable dt)
        {
            OpenConection(ref con);
            try
            {
                string Sql = "SELECT * FROM " + TableName + ";";
                OleDbCommand comand = new OleDbCommand(Sql, con);
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
        }
    }
}