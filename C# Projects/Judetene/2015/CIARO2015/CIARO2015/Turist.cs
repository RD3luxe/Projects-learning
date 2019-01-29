using System;
using System.Windows.Forms;
using System.Data;

namespace CIARO2015
{
    public partial class Turist : Form
    {
        public DataTable croaziera = new DataTable();
        public static string[] numePorturi = new string[13] { "Constanta", "Varna", "Burgas", "Istambul", "Kozlu", "Samsun", "Batumi", "Sokhumi", "Soci", "Anapa", "Yalta", "Sevastopol", "Odessa" };
        public static string index_cell;

        public Turist()
        {
            InitializeComponent();
            if (croaziera.Columns.Count == 0)
            {
                croaziera.Columns.Add("ID");
                croaziera.Columns.Add("Circuit");
                croaziera.Columns.Add("Data start");
                croaziera.Columns["Data start"].DataType = typeof(DateTime);
                croaziera.Columns.Add("Data final");
                croaziera.Columns["Data final"].DataType = typeof(DateTime);
                croaziera.Columns.Add("Preturi");
                croaziera.Columns.Add("Nr calatori");
            }
        }

        private void validare_btn_Click(object sender, EventArgs e)
        {
            index_cell = GetCellValue();
            Traseu tr = new Traseu();
            this.Hide();
            tr.Show();
        }

        private void Turist_FormClosed(object sender, FormClosedEventArgs e)
        {
            Calatorie.CloseMain();
        }

        private void Turist_Load(object sender, EventArgs e)
        {
            if(tip_lista.Items.Count == 0)
            {
                tip_lista.Items.AddRange(new object[]{"3 zile","5 zile","8 zile"});
            }
            tip_lista.SelectedIndex = 0;
        }

        private void tip_lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadData();
        }

        private void date_start_ValueChanged(object sender, EventArgs e)
        {
            index_cell = GetCellValue();
            string Sql = string.Format("UPDATE Croaziere SET Data_Start='{0}' WHERE Lista_Porturi='{1}';",date_start.Value,index_cell);
            MyData.setData(Sql, 1);
            MessageBox.Show("Data start a fost updatata pentru croaziera curenta.","Date Start Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ReadData();
            croaziere_dv.Refresh();
        }

        private void date_end_ValueChanged(object sender, EventArgs e)
        {
            index_cell = GetCellValue();
            string Sql = string.Format("UPDATE Croaziere SET Data_Final='{0}' WHERE Lista_Porturi='{1}';", date_end.Value,index_cell);
            MyData.setData(Sql, 1);
            MessageBox.Show("Data finala a fost updatata pentru croaziera curenta.", "Date Final Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReadData();
            croaziere_dv.Refresh();
        }

        public string GetCellValue()
        {
            string value = croaziere_dv.CurrentRow.Cells[1].Value.ToString();
            string[] split = value.Split(',');
            string index = string.Empty;
            for (int j = 0; j < split.Length; j++)
            {
                for (int i = 0; i < numePorturi.Length; i++)
                {
                    if (split[j] == numePorturi[i])
                    {
                        index += (i + 1).ToString() + ",";
                    }
                }
            }
            index = index.Remove(index.Length - 1);
            return index;
        }

        public void ReadData()
        {
            DataTable table = new DataTable();
            if (croaziera.Rows.Count > 0) croaziera.Rows.Clear();
            MyData.readTable("Croaziere", ref table, 1);
            int[] items = new int[3] { 3, 5, 8 };
            if (croaziere_dv.RowCount > 0)
            {
                for (int i = croaziere_dv.RowCount; i > 0; i--)
                {
                    croaziere_dv.Rows.RemoveAt(i);
                }
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["Tip_Croaziera"]) == items[tip_lista.SelectedIndex])
                {
                    string[] splitRows = table.Rows[i]["Lista_Porturi"].ToString().Split(',');
                    string newList = numePorturi[Convert.ToInt32(splitRows[0]) - 1];
                    DataRow row = croaziera.NewRow();
                    for (int j = 1; j < splitRows.Length; j++)
                    {
                        newList += "," + numePorturi[Convert.ToInt32(splitRows[j]) - 1];
                    }
                    row[0] = table.Rows[i]["ID_Croaziera"];
                    row[1] = newList;
                    row[2] = table.Rows[i]["Data_Start"];
                    row[3] = table.Rows[i]["Data_Final"];
                    row[4] = table.Rows[i]["Pret"];
                    row[5] = table.Rows[i]["Nr_pasageri"];
                    croaziera.Rows.Add(row);
                }
            }
            croaziere_dv.DataSource = croaziera;
            croaziere_dv.Columns["ID"].ReadOnly = true;
            croaziere_dv.Columns["Circuit"].ReadOnly = true;
            croaziere_dv.Columns["Data start"].ReadOnly = true;
            croaziere_dv.Columns["Data final"].ReadOnly = true;
            croaziere_dv.Columns["Preturi"].ReadOnly = true;
        }
    }
}