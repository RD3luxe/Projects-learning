using System;
using System.Windows.Forms;
using System.Data;

namespace CIARO2015
{
    public partial class Lista_croaziere : Form
    {
        public DataTable croaziera = new DataTable();
        string[] numePorturi = new string[13] { "Constanta", "Varna", "Burgas", "Istambul", "Kozlu", "Samsun", "Batumi", "Sokhumi", "Soci", "Anapa", "Yalta", "Sevastopol", "Odessa" };
        public Lista_croaziere()
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

        private void cls_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Calatorie.op.MainForm.Show();
        }

        private void Lista_croaziere_FormClosed(object sender, FormClosedEventArgs e)
        {
            Calatorie.CloseMain();
        }

        private void Lista_croaziere_Load(object sender, EventArgs e)
        {
            if(lista_zile.Items.Count == 0)
            {
                lista_zile.Items.AddRange(new object[] { "3 Zile", "5 Zile", "8 Zile" });
            }
            lista_zile.SelectedIndex = 0;   
        }

        private void lista_zile_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            if(croaziera.Rows.Count > 0) croaziera.Rows.Clear();
            MyData.readTable("Croaziere",ref table,1);
            int[] items = new int[3] { 3, 5, 8 };
            if(croaziere_dv.RowCount > 0)
            {
                for(int i = croaziere_dv.RowCount; i > 0;i--)
                {
                    croaziere_dv.Rows.RemoveAt(i);
                }
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["Tip_Croaziera"]) == items[lista_zile.SelectedIndex])
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
                    row[4] = table.Rows[i]["Pret"]+" RON";
                    row[5] = table.Rows[i]["Nr_pasageri"];
                    croaziera.Rows.Add(row);
                }
            }
            croaziere_dv.DataSource = croaziera;
        }
    }
}