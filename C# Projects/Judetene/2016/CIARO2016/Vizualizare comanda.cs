using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CIARO2016
{
    public partial class Vizualizare_comanda : Form
    {
        public Vizualizare_comanda()
        {
            InitializeComponent();
        }

        private void Vizualizare_comanda_Load(object sender, EventArgs e)
        {
            InitGrid();
            textBox2.Text = MyData.selectData("Clienti", "kcal_zilnice", MyData.e_mail);
            textBox1.Text = Optiuni.total_k;
            textBox3.Text = Optiuni.total_p;
        }

        public void InitGrid()
        { 
            comenzi_dv.DataSource = Optiuni.date_comeni;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Elimina";
            btn.ValueType = typeof(Button);
            btn.UseColumnTextForButtonValue = true;
            btn.Text = "Elimina";
            comenzi_dv.Columns.Add(btn);
        }

        private void Vizualizare_comanda_FormClosed(object sender, FormClosedEventArgs e)
        {
            Start.CloseMainForm();
        }

        private void comenzi_dv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comenzi_dv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                textBox1.Text = (Convert.ToInt32(textBox1.Text) - (Convert.ToInt32(comenzi_dv["kcal",e.RowIndex].Value) * Convert.ToInt32(comenzi_dv["cantitate", e.RowIndex].Value))).ToString();
                textBox3.Text = (Convert.ToInt32(textBox3.Text) - (Convert.ToInt32(comenzi_dv["pret", e.RowIndex].Value) * Convert.ToInt32(comenzi_dv["cantitate", e.RowIndex].Value))).ToString();
                comenzi_dv.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void fin_btn_Click(object sender, EventArgs e)
        {
            string queryStatemnt = String.Empty;
            //add in comand table
            string id = MyData.selectData("Clienti", "id_client", MyData.e_mail);
            Random rnd = new Random();
            string id_comanda = (Convert.ToInt32(id) + rnd.Next(1000)).ToString();
            queryStatemnt = string.Format("INSERT INTO Comenzi(id_comanda,id_client,data_comanda)VALUES('{0}',{1},'{2}');",id_comanda,id,DateTime.Now);
            MyData.writeData("Comenzi",queryStatemnt);
            //add in subcomand table
            for (int i = 0; i < comenzi_dv.Rows.Count; i++)
            {
                int id_produs = Convert.ToInt32(readDataExcel("id_produs", "denumire_produs",comenzi_dv["Nume produs",i].Value.ToString()));
                queryStatemnt = string.Format("INSERT INTO Subcomenzi(id_comanda,id_produs,cantitate)VALUES('{0}',{1},{2});",id_comanda,id_produs,comenzi_dv.Rows[i].Cells["cantitate"].Value); //comenzi_dv["cantitate",i].Value 
                MyData.writeData("Subcomenzi", queryStatemnt);
            }
            MessageBox.Show("Comanda dumneavoastra a fost trimisa,va multumim !", "Comanda trimisa !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Start.auth.MainForm.Show();
        }

        private static string readDataExcel(string data_name,string data_pointer,string pointer_value)
        {
            string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Meniu.xlsx; Extended Properties = Excel 12.0;";
            OleDbConnection MyConnection = new OleDbConnection(connString);
            string result = String.Empty;
            try
            {
                MyConnection.Open();
                string SqlSintax = string.Format("SELECT {0} FROM [Sheet3$] WHERE {1} = '{2}';",data_name,data_pointer,pointer_value);
                OleDbCommand MyCommand = new OleDbCommand(SqlSintax, MyConnection);
                OleDbDataReader reader = MyCommand.ExecuteReader();
                while (reader.Read()) result = reader[data_name].ToString();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MyConnection.Close();
            }
            return result;
        }
    }
}