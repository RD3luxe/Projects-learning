using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
//using System.IO;

namespace CIARO2016
{
    public partial class Optiuni : Form
    {
        int age, greutate, height, diff;
        int[,] stocare_val = new int[200, 200];
        public static string total_k,total_p;
        public static DataTable date_comeni = new DataTable();
        DataTable dt_fel1 = new DataTable();
        DataTable dt_fel2 = new DataTable();
        DataTable dt_fel3 = new DataTable();
        DataTable dt = new DataTable();

        public Optiuni()
        {
            InitializeComponent();
            InitComanda();
            date_comeni.Clear();
            if (date_comeni.Columns.Count <= 0)
            {
                date_comeni.Columns.Add("Nume produs");
                date_comeni.Columns.Add("kcal");
                date_comeni.Columns.Add("pret");
                date_comeni.Columns.Add("cantitate");
            }
            totalKcal.Text = "0";
            pretTotal.Text = "0";
            diff = 0;
            LoadChart();
        }

        private void Optiuni_Load(object sender, EventArgs e)
        {
            rez_txt.Visible = false;
            message_lb.Visible = false;
            //fill our datagridview and use data from there.
            string[] tabelColumns = new string[] { "Nume", "Fel", "Pret", "Kcal" };
            //create table 3 data tables ?!
            for (int i = 0; i < 4; i++)
            {
                dt_fel1.Columns.Add(tabelColumns[i]);
                dt_fel2.Columns.Add(tabelColumns[i]);
                dt_fel3.Columns.Add(tabelColumns[i]);
            }
            dt.Columns.Add("Felul 1");//0
            dt.Columns.Add("Felul 2");//1
            dt.Columns.Add("Felul 3");//2
            dt.Columns.Add("Total Kcal");//3
            dt.Columns.Add("Pret Total");//4
            //loop in datagrid view cu toate datele si selectam fiecare fel
            for (int i = 0; i < meniu_dv.Rows.Count; i++)
            {
                DataRow dr = null;
                switch (Convert.ToString(meniu_dv["felul", i].Value))
                {
                    case "1":
                        dr = dt_fel1.NewRow();
                        break;
                    case "2":
                        dr = dt_fel2.NewRow();
                        break;
                    case "3":
                        dr = dt_fel3.NewRow();
                        break;
                    default:
                        break;
                }
                dr[0] = meniu_dv["denumire_produs", i].Value;
                dr[1] = meniu_dv["felul", i].Value;
                dr[2] = meniu_dv["pret", i].Value;
                dr[3] = meniu_dv["Kcal", i].Value;
                switch (Convert.ToString(meniu_dv["felul", i].Value))
                {
                    case "1":
                        dt_fel1.Rows.Add(dr);
                        break;
                    case "2":
                        dt_fel2.Rows.Add(dr);
                        break;
                    case "3":
                        dt_fel3.Rows.Add(dr);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Optiuni_FormClosed(object sender, FormClosedEventArgs e)
        {
            Start.CloseMainForm();
        }

        private void calc_Click(object sender, EventArgs e)
        {
            if (g_txt.Text == String.Empty || h_txt.Text == String.Empty || varsta_txt.Text == String.Empty)
            {
                MessageBox.Show("Toate campurile sunt obligatorii.", "Numere incorecte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(!NotValidNumbers())
            {
                MessageBox.Show("Introdu numere valide.", "Numere incorecte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                rez_txt.Visible = true;
                message_lb.Visible = true;
                int s = 0;
                s = age + greutate + height;
                if(s < 250)
                {
                    rez_txt.Text = "1800";
                }
                else if(250 <= s && s <= 275)
                {
                    rez_txt.Text = "2200";
                }
                else if(s > 275)
                {
                    rez_txt.Text = "2500";
                }
                string query = string.Format("UPDATE Clienti SET kcal_zilnice = {0} WHERE email = '{1}';",Convert.ToInt32(rez_txt.Text),MyData.e_mail);
                MyData.writeData("Clienti", query);
                nZilnic.Text = MyData.selectData("Clienti", "kcal_zilnice", MyData.e_mail);
                textBox1.Text = nZilnic.Text;
                for (int i = 0; i < meniu_dv.RowCount && meniu_dv["amount", i].Value != (object)"1"; i++)
                {
                    meniu_dv["amount", i].Value = (object)"1";
                }
            }
        }

        private void meniu_dv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int value = Convert.ToInt32(meniu_dv[e.ColumnIndex,e.RowIndex].Value);
            if (meniu_dv.Columns[e.ColumnIndex].Name == "amount" && value <= -1)
            {
                meniu_dv[e.ColumnIndex, e.RowIndex].Value = (object)stocare_val[e.ColumnIndex, e.RowIndex];
                MessageBox.Show("Cantitate negativa.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (value < stocare_val[e.ColumnIndex, e.RowIndex] && stocare_val[e.ColumnIndex, e.RowIndex] != 0)
            {
                meniu_dv[e.ColumnIndex, e.RowIndex].Value = (object)stocare_val[e.ColumnIndex, e.RowIndex];
            }else if(value > stocare_val[e.ColumnIndex,e.RowIndex])
            {
                diff = value - stocare_val[e.ColumnIndex, e.RowIndex];
            }
        }

        private void meniu_dv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < meniu_dv.RowCount && meniu_dv["amount", i].Value != (object)"1"; i++)
            {
                meniu_dv["amount", i].Value = 1;
            }
            //e.ColumnIndex == 5
            if (meniu_dv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (Convert.ToInt32(meniu_dv["amount",e.RowIndex].Value) > stocare_val[e.ColumnIndex, e.RowIndex])
                {
                    totalKcal.Text = (Convert.ToInt32(totalKcal.Text) + (Convert.ToInt32(meniu_dv["Kcal", e.RowIndex].Value) * diff)).ToString();
                    pretTotal.Text = (Convert.ToInt32(pretTotal.Text) + (Convert.ToInt32(meniu_dv["pret", e.RowIndex].Value) * diff)).ToString();
                }else
                {
                    totalKcal.Text = (Convert.ToInt32(totalKcal.Text) + (Convert.ToInt32(meniu_dv["Kcal", e.RowIndex].Value) * Convert.ToInt32(meniu_dv["amount", e.RowIndex].Value))).ToString();
                    pretTotal.Text = (Convert.ToInt32(pretTotal.Text) + (Convert.ToInt32(meniu_dv["pret", e.RowIndex].Value) * Convert.ToInt32(meniu_dv["amount", e.RowIndex].Value))).ToString();
                }
                total_k = totalKcal.Text;
                total_p = pretTotal.Text;
                //genereaza automat liniile pentru tabel
                DataRow row = date_comeni.NewRow();
                bool found = false;
                for (int i = 0; i < date_comeni.Rows.Count && !found; i++)
                {
                    if (date_comeni.Rows[i]["Nume produs"].Equals(meniu_dv["denumire_produs", e.RowIndex].Value))
                    {
                        date_comeni.Rows[i]["cantitate"] = meniu_dv["amount", e.RowIndex].Value;
                        found = true;
                    }
                }
                if (!found)
                {
                    row[0] = meniu_dv["denumire_produs", e.RowIndex].Value;
                    row[1] = meniu_dv["kcal", e.RowIndex].Value;
                    row[2] = meniu_dv["pret", e.RowIndex].Value;
                    row[3] = meniu_dv["amount", e.RowIndex].Value;
                    date_comeni.Rows.Add(row);
                }
            }
        }

        public bool NotValidNumbers()
        {
            bool correct = true;
            if (!(Int32.TryParse(varsta_txt.Text, out age)))
            {
                correct = false;
            }
            if(!(Int32.TryParse(g_txt.Text,out greutate)))
            {
                correct = false;
            }
            if(!(Int32.TryParse(h_txt.Text,out height)))
            {
                correct = false;
            }
            return correct;
        }

        private void genereaza_btn_Click(object sender, EventArgs e)
        {
            //metoda 2 : x3 for loop in meniu_dv si verific daca e felul 1 sau 2 sau 3 si fac operatii pe datele din lui
            //delete rows
            for (int i = genMeniu_dv.Rows.Count - 1; i >= 0; i--) { genMeniu_dv.Rows.RemoveAt(i); }
            genMeniu_dv.Refresh();
            for (int i = 0; i < dt_fel1.Rows.Count; i++)
            {
                for (int j = 0; j < dt_fel2.Rows.Count; j++)
                {
                    for (int k = 0; k < dt_fel3.Rows.Count; k++)
                    { 
                        int TotalPrice = Convert.ToInt32(dt_fel1.Rows[i]["Pret"]) + Convert.ToInt32(dt_fel2.Rows[j]["Pret"]) + Convert.ToInt32(dt_fel3.Rows[k]["Pret"]);
                        int TotalKcal = Convert.ToInt32(dt_fel1.Rows[i]["Kcal"]) + Convert.ToInt32(dt_fel2.Rows[j]["Kcal"]) + Convert.ToInt32(dt_fel3.Rows[k]["Kcal"]);
                        if(TotalPrice <= Convert.ToInt32(buget_txt.Text) && TotalKcal <= Convert.ToInt32(nZilnic.Text))
                        {
                            DataRow row = dt.NewRow();
                            row[0] = dt_fel1.Rows[i]["Nume"];
                            row[1] = dt_fel2.Rows[j]["Nume"];
                            row[2] = dt_fel3.Rows[k]["Nume"]; 
                            row[3] = TotalKcal.ToString();
                            row[4] = TotalPrice.ToString();
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            //add datatable to datagridview
            genMeniu_dv.DataSource = dt;
            //create button column
            if (!(genMeniu_dv.Columns.Contains("choose")))
            {
                DataGridViewButtonColumn btn_col = new DataGridViewButtonColumn();
                btn_col.ValueType = typeof(Button);
                btn_col.HeaderText = "Alege";
                btn_col.Text = "Alege";
                btn_col.Name = "choose";
                btn_col.UseColumnTextForButtonValue = true;
                genMeniu_dv.Columns.Add(btn_col);
            }
        }

        private void genMeniu_dv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //e.ColumnIndex == 5
            if(genMeniu_dv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                MessageBox.Show("Comanda a fost trimisa !","Multumim pentru alegere.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                Start.auth.MainForm.Show();
            }
        }

        private void meniu_dv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            stocare_val[e.ColumnIndex, e.RowIndex] = Convert.ToInt32(meniu_dv[e.ColumnIndex, e.RowIndex].Value);
        }

        private void comanda_btn_Click(object sender, EventArgs e)
        {
            Vizualizare_comanda viz = new Vizualizare_comanda();
            this.Hide();
            viz.Show();
        }

        //v2 Read Excel
        private void ReadExcelFile(ref DataGridView dv)
        {
            string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Meniu.xlsx; Extended Properties = Excel 12.0;";
            OleDbConnection MyConnection = new OleDbConnection(connString);
            try
            {
                MyConnection.Open();
                OleDbDataAdapter MyCommand = new OleDbDataAdapter("select * from [Sheet3$]", MyConnection);
                DataSet DtSet = new DataSet();
                MyCommand.Fill(DtSet);
                dv.DataSource = DtSet.Tables[0];
            }
            catch(OleDbException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MyConnection.Close();
            }
        }
        //chart
        //Citeste din baza de date Comenzi in functie de id-ul clientului si ia toate "id_comanda" dupa citim din subcomenzi in functie de fiecare id comanda si afisam numele si kcal din baza excel
        public void LoadChart()
        {
            //stochez id-ul fiecarei comenzi ca o matrice...
            //get client id
            int id = Convert.ToInt32(MyData.selectData("Clienti", "id_client", MyData.e_mail));
            //cauta toate inregistrarile din comenzi si returneaza id-ul comenzilor
            string[] comenzi_array = new string[200];
            MyData.selectAllData("Comenzi", "id_comanda", "id_client", id, ref comenzi_array);
            //cautam in subcomenzi toate inregistrarile pentru fiecare id_comanda -_-
            MyData.OpenDB(ref MyData.MyConnection);
            for (int i = 0; i < comenzi_array.Length; i++)
            {
                try
                {
                    string query = string.Format("SELECT id_produs FROM Subcomenzi WHERE id_comanda = '{0}';", comenzi_array[i]);
                    OleDbCommand cmd = new OleDbCommand(query, MyData.MyConnection);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string nume_produs = readDataExcel("denumire_produs", "id_produs", Convert.ToInt32(reader["id_produs"]));
                        int kcal_produs = readDataExcell("Kcal", "id_produs", Convert.ToInt32(reader["id_produs"]));
                        grafic_kcal.Series["Kcal"].Points.AddXY(nume_produs, kcal_produs);
                    }
                    reader.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            MyData.MyConnection.Close();
        }

        private static string readDataExcel(string data_name, string data_pointer, int pointer_value)
        {
            string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Meniu.xlsx; Extended Properties = Excel 12.0;";
            OleDbConnection MyConnection = new OleDbConnection(connString);
            string result = String.Empty;
            try
            {
                MyConnection.Open();
                string SqlSintax = string.Format("SELECT {0} FROM [Sheet3$] WHERE {1} = {2};", data_name, data_pointer, pointer_value);
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

        private static int readDataExcell(string data_name, string data_pointer, int pointer_value)
        {
            string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Meniu.xlsx; Extended Properties = Excel 12.0;";
            OleDbConnection MyConnection = new OleDbConnection(connString);
            int result = 0;
            try
            {
                MyConnection.Open();
                string SqlSintax = string.Format("SELECT {0} FROM [Sheet3$] WHERE {1} = {2};", data_name, data_pointer, pointer_value);
                OleDbCommand MyCommand = new OleDbCommand(SqlSintax, MyConnection);
                OleDbDataReader reader = MyCommand.ExecuteReader();
                while (reader.Read()) result = Convert.ToInt32(reader[data_name]);
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
        //comanda 
        public void InitComanda()
        {
            nZilnic.Text = MyData.selectData("Clienti", "kcal_zilnice", MyData.e_mail);
            textBox1.Text = MyData.selectData("Clienti", "kcal_zilnice", MyData.e_mail);
            ReadExcelFile(ref meniu_dv);
            string[] myColumns = new string[] { "id_produs", "denumire_produs", "descriere", "pret", "kcal", "felul" };
            foreach (string cl in myColumns)
            {
                meniu_dv.Columns[cl].ReadOnly = true;
            }
            //adaugam coloanele noi.//Textbox
            DataGridViewTextBoxColumn amount_c = new DataGridViewTextBoxColumn();
            amount_c.HeaderText = "Cantitate";
            amount_c.Name = "amount"; 
            amount_c.ValueType = typeof(int);
            amount_c.ReadOnly = false;
            meniu_dv.Columns.Add(amount_c);
            //button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "adauga_btn";
            btn.ValueType = typeof(Button);
            btn.HeaderText = "Adauga";
            btn.Text = "Adauga";
            btn.UseColumnTextForButtonValue = true;
            btn.ReadOnly = false;
            meniu_dv.Columns.Add(btn);
        }
    }
}

////v1 Read from file.
//public void ReadFile(string file, ref string[,] matrix)
//{
//    if (File.Exists(file))
//    {
//        int row = 0;
//        FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
//        using (StreamReader reader = new StreamReader(fileStream))
//        {
//            string line;
//            while ((line = reader.ReadLine()) != null)
//            {
//                string[] splitData = line.Split(';');
//                for (int i = 0; i < splitData.Length - 1; i++)
//                {
//                    matrix[row,i] = splitData[i].ToString();
//                }
//                row++;
//            }
//        }
//    }
//}
//public DataTable AddMatrixToTable(ref string[] Matrix)
//{

//    //1  2  3 || a[0, 0] a[0, 1] a[0, 2]
//    //4  5  6 || a[1, 0] a[1, 1] a[1, 2]
//    //7  8  9 || a[2, 0] a[2, 1] a[2, 2]

//    DataTable table = new DataTable();
//    table.Columns.Add("Col1");
//    table.Columns.Add("Col2");
//    table.Columns.Add("Col3");
//    for (int i = 0; i < Matrix.GetLength(0); i++)
//    {
//        for (int j = 0; j < Matrix.GetLength(1) / table.Columns.Count; j++)
//        {
//            DataRow row = table.NewRow();
//            row[0] = Matrix[i, j];
//            row[1] = Matrix[i, j + 1];
//            row[2] = Matrix[i, j + 2];
//            table.Rows.Add(row);
//        }
//    }
//    return table;
//}