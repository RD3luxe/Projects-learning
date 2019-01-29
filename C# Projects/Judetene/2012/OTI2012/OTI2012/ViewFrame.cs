using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OTI2012
{
    public partial class ViewFrame : Form
    {
        /// <summary>
        /// <student>0</student>
        /// <profesor>1</profesor>
        /// </summary>
        public int type = 0;
        public string[] data = new string[4];
        public string old_value;
        public bool editor_opened = false;
        TestEditor editor;

        public ViewFrame()
        {
            InitializeComponent();
        }

        private void ViewFrame_Load(object sender, EventArgs e)
        {
            if (type == 0)
            {
                AddTesteInBox(box_materii);
            }
            else if (type == 1)
            {
                AddStudentiInBox(box_materii);
            }
            editor_opened = false;
            getData();
        }

        public void getData()
        {
            DataTable dt;
            string sql = string.Empty;
            switch (type)
            {
                case 0:
                    sql = string.Format("SELECT ID_Test,Nume_fisier,Nota,Nota_finala FROM Teste_Materii WHERE ID_Student={0} AND Materie='{1}';", data[2], box_materii.SelectedItem.ToString());
                    test_lbl.Text = $"Notele elevului {data[0]} {data[1]}";
                    dt = MyData.readTable(sql);
                    lista_dgv.DataSource = dt;
                    lista_dgv.Columns["Nota_finala"].ReadOnly = true;
                    test_lbl.TextAlign = ContentAlignment.TopCenter;
                    break;
                case 1:
                    lista_dgv.Columns.Clear();
                    string[] correct_name = box_materii.SelectedItem.ToString().Split(' ');
                    string sql_materii = string.Format("SELECT ID_Student FROM Grades WHERE ID_Profesor LIKE '%{0}%' AND Nume='{1}' AND Prenume='{2}';", data[3], correct_name[0], correct_name[1]);
                    int id_student = MyData.selectData(sql_materii, "ID_Student");
                    sql = string.Format("SELECT ID_Test,Nume_fisier FROM Teste_Materii WHERE ID_Student={0} AND Materie='{1}';", id_student, data[2]);
                    test_lbl.Text = $"Modifica testele profesorului {data[0]} {data[1]}";
                    dt = MyData.readTable(sql);
                    lista_dgv.DataSource = dt;
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.Name = "change";
                    btn.HeaderText = "Modifica testul";
                    btn.ValueType = typeof(Button);
                    btn.Text = "Modifica";
                    btn.UseColumnTextForButtonValue = true;
                    lista_dgv.Columns.Add(btn);
                    test_lbl.TextAlign = ContentAlignment.TopLeft;
                    break;
            }
            lista_dgv.Columns["ID_Test"].ReadOnly = true;
            lista_dgv.Columns["Nume_fisier"].ReadOnly = true;
        }

        public void AddStudentiInBox(ComboBox box)
        {
            box.Items.Clear();
            string sql_materii = string.Format("SELECT Nume,Prenume FROM Grades WHERE ID_Profesor LIKE '%{0}%';",data[3]);
            DataTable date = MyData.readTable(sql_materii);
            if (date.Rows.Count > 0)
            {
                for (int i = 0; i < date.Rows.Count; i++)
                {
                    string item = $"{date.Rows[i]["Nume"].ToString()} {date.Rows[i]["Prenume"].ToString()}";
                    box.Items.Add(item);
                }
            }
            box.SelectedIndex = 0;
        }

        public bool has_students(string profesor)
        {
            string sql_materii = string.Format("SELECT Nume,Prenume FROM Grades WHERE ID_Profesor LIKE '%{0}%';", profesor);
            DataTable date = MyData.readTable(sql_materii);
            if (date.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddTesteInBox(ComboBox box)
        {
            box.Items.Clear(); 
            string sql_materii = string.Format("SELECT Materii_inscris FROM Grades WHERE ID_Student={0};", data[2]);
            string materii = MyData.stringSelector(sql_materii, "Materii_inscris");
            if (!string.IsNullOrEmpty(materii))
            {
                string[] split_materii = materii.Split(',');
                for (int i = 0; i < split_materii.Length; i++)
                {
                    sql_materii = string.Format($"SELECT Nume_Materie FROM TabelMaterii WHERE ID_Materie={split_materii[i]};");
                    string materie = MyData.stringSelector(sql_materii, "Nume_Materie");
                    box.Items.Add(materie);
                }
                box.SelectedIndex = 0;
            }
        }

        private void ViewFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            DirectorPanel.opened = false;
            if(editor != null)
            {
                editor.Close();
            }
        }

        private void box_materii_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }

        private void lista_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(type == 1 && e.RowIndex >= 0 && !editor_opened)
            {
                //open test editor
                string path = string.Format($"teste/{data[2]}/{data[0]}_{data[1]}/{lista_dgv["Nume_fisier", e.RowIndex].Value}.txt");
                if (File.Exists(path))
                {
                    editor = new TestEditor(path);
                    editor_opened = true;
                    editor.link = this;
                    editor.Show();
                }
                else
                {
                    MessageBox.Show("A aparut o eroare , se pare ca acel fisier nu exista.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void lista_dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(type == 0 && e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                old_value = lista_dgv[2, e.RowIndex].Value.ToString();
            }
        }

        private void lista_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(type == 0 && e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if(lista_dgv[2,e.RowIndex].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Nu poti lasa campuri goale.","Eroare",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    lista_dgv[2, e.RowIndex].Value = old_value;
                    return;
                }
                if(Convert.ToInt32(lista_dgv[2, e.RowIndex].Value) <= 0 || Convert.ToInt32(lista_dgv[2, e.RowIndex].Value) >  10)
                {
                    MessageBox.Show("Nota nu poate fii mai mica decat 1 sau mai mare de 10.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lista_dgv[2, e.RowIndex].Value = old_value;
                    return;
                }
                //after all exceptions save data.
                string sql = string.Format("UPDATE Teste_Materii SET Nota={0} WHERE ID_Student={1} AND Materie='{2}' AND ID_Test={3};", lista_dgv[2, e.RowIndex].Value,data[2],box_materii.SelectedItem,lista_dgv[0,e.RowIndex].Value);
                MyData.execSql(sql);
                //recalculam media
                saveTotal();
                MessageBox.Show("Nota modificata cu succes.","Modificare cu succes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                getData();
            }
        }
        
        public void saveTotal()
        {
            string sql = string.Format("SELECT Nota FROM Teste_Materii WHERE ID_Student={0} AND Materie='{1}';", data[2], box_materii.SelectedItem);
            DataTable dt = MyData.readTable(sql);
            double total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total += Convert.ToInt32(dt.Rows[i][0]);
            }
            total = total / dt.Rows.Count;
            total = Math.Ceiling(total);
            sql = string.Format("UPDATE Teste_Materii SET Nota_finala={0} WHERE ID_Student={1} AND Materie='{2}';", total, data[2], box_materii.SelectedItem);
            MyData.execSql(sql);
        }
    }
}