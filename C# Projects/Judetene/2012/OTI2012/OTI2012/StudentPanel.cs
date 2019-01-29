using System;
using System.Data;
using System.Windows.Forms;

namespace OTI2012
{
    public partial class StudentPanel : Form
    {
        string[] data;
        int max_materii = 4;
        public static string CurrentTest = string.Empty;
        public static bool test_opened = false;
        public static Main_form form;
        public static TextBox[] text_main = new TextBox[2];
        public Main_form main
        {
            get
            {
                return form;
            }
            set
            {
                form = value;
            }
        }
        public TextBox[] TextMain
        {
            get
            {
                return text_main;
            }
            set
            {
                text_main = value;
            }
        }

        public StudentPanel()
        {
            InitializeComponent();
            numepren_txt.Text = $"{Main_form.date[0]} {Main_form.date[1]}";
        }

        public void InitAllCourses()
        {
            dgv_allcourse.Columns.Clear();
            string sql = string.Format("SELECT TabelMaterii.ID_Materie,TabelMaterii.Nume_Materie,Materii.Nume,Materii.Prenume,Materii.IDTesteAdaugate FROM TabelMaterii,Materii WHERE TabelMaterii.ID_Materie=Materii.IDMaterie;");
            DataTable dt = MyData.readTable(sql);
            if (dt.Rows.Count > 0)
            {
                dgv_allcourse.DataSource = dt;
                dgv_allcourse.Columns["Nume"].HeaderText = "Nume profesor";
                dgv_allcourse.Columns["ID_Materie"].HeaderText = "ID Materie";
                dgv_allcourse.Columns["Nume_Materie"].HeaderText = "Nume Materie";
                DataGridViewTextBoxColumn nr_teste = new DataGridViewTextBoxColumn();
                nr_teste.Name = "nr_teste";
                nr_teste.HeaderText = "Numar teste";
                nr_teste.ValueType = typeof(string);
                dgv_allcourse.Columns.Add(nr_teste);
                int count = 0;
                for (int i = 0; i < dgv_allcourse.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IDTesteAdaugate"].ToString().Contains(","))
                    {
                        count = Convert.ToInt32(dt.Rows[i]["IDTesteAdaugate"].ToString().Split(',').Length);
                    }
                    else
                    {
                        if (dt.Rows[i]["IDTesteAdaugate"].ToString().Length != 0)
                        {
                            count = 1;
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    dgv_allcourse["nr_teste", i].Value = count.ToString();
                }
                dgv_allcourse.Columns.Remove("IDTesteAdaugate");
                dgv_allcourse.Columns.Add("count_st", "Studenti inscrisi");
                //numara cati elevi are fiecare profesor | start counting
                DataTable tb = new DataTable();
                sql = string.Format("SELECT Numar_studenti FROM Materii;");
                tb = MyData.readTable(sql);
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(tb.Rows[i][0].ToString()))
                    {
                        dgv_allcourse["count_st", i].Value = tb.Rows[i][0];
                    }
                    else
                    {
                        dgv_allcourse["count_st", i].Value = 0;
                    }
                }
                //button
                DataGridViewButtonColumn apply = new DataGridViewButtonColumn();
                apply.Name = "apply_btn";
                apply.HeaderText = "Alege materiile";
                apply.Text = "Aplica";
                apply.UseColumnTextForButtonValue = true;
                dgv_allcourse.Columns.Add(apply);
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if(test_opened)
            {
                MessageBox.Show("Nu poti da log-out atata timp cat dai un test.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Main_form.IsLogged)
            {
                Main_form.IsLogged = false;
                Main_form.IsProfessor = false;
                TextMain[0].Text = TextMain[1].Text = string.Empty;
                main.Show();
                TextMain[0].Focus();
                this.Hide();
                this.Dispose();
            }
        }

        private void StudentPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(TestForm.test_on)
            {
                MessageBox.Show("Nu poti iesi din test daca nu ai dat finalizare.", "Informatii", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            Main_form.CloseMain();
        }

        private void StudentPanel_Load(object sender, EventArgs e)
        {
            AddTesteInBox(materii_db);
            AddTesteInBox(materii_cb);
            InitAllCourses();
            LoadDateMaterii();
            LoadDateTeste();
        }

        public void AddTesteInBox(ComboBox box)
        {
            box.Items.Clear();
            string sql_materii = string.Format("SELECT Materii_inscris FROM Grades WHERE ID_Student={0};", Main_form.id_user);
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

        public void LoadDateTeste()
        {
            teste_dgv.Columns.Clear();
            string sql = string.Format("SELECT Teste_Materii.ID_Test,Teste_Materii.Nume_fisier,Teste_Materii.Materie,Teste_Materii.ID_Prof FROM Teste_Materii WHERE Teste_Materii.ID_Student={0} AND Teste_Materii.Nota=0;", Main_form.id_user);
            DataTable dt = MyData.readTable(sql);
            if (dt.Rows.Count != 0)
            {
                teste_dgv.DataSource = dt;
                teste_dgv.Columns["Nume_fisier"].HeaderText = "Nume test";
            }
        }

        public void ReloadAll()
        {
            LoadDateMaterii();
            LoadDateTeste();
            KeepTrakingName();
        }

        public void LoadDateMaterii()
        {
            mycourse_dgv.Columns.Clear();
            if (materii_db.Items.Count > 0)
            {
                string selectDates = string.Format("SELECT ID_Test,Nume_fisier,Nota,Promovat FROM Teste_Materii WHERE ID_Student={0} AND Materie='{1}' AND Nota<>0;", Main_form.id_user, materii_db.SelectedItem.ToString());
                DataTable dt = MyData.readTable(selectDates);
                if (dt.Rows.Count > 0)
                {
                    mycourse_dgv.DataSource = dt;
                    mycourse_dgv.Columns["Nume_fisier"].HeaderText = "Nume test";
                    mycourse_dgv.Columns.Add("name", "Nume profesor");
                    mycourse_dgv.Columns.Add("prename", "Prenume profesor");
                    //select name and prename using profesor ID 
                    string IdProf = string.Format("SELECT Materii_inscris,Id_Profesor FROM Grades WHERE ID_Student={0};", Main_form.id_user);
                    dt = MyData.readTable(IdProf);
                    string Id_materie = string.Format("SELECT ID_Materie FROM TabelMaterii WHERE Nume_Materie='{0}';", materii_db.SelectedItem.ToString());
                    int ID = MyData.selectData(Id_materie, "ID_Materie");
                    string[] splitData1 = dt.Rows[0][0].ToString().Split(',');
                    string[] splitData2 = dt.Rows[0][1].ToString().Split(',');
                    for (int i = 0; i < splitData1.Length; i++)
                    {
                        int IDS = Convert.ToInt32(splitData1[i]);
                        if (ID == IDS)
                        {
                            //am gasit date le folosim 
                            selectDates = string.Format("SELECT Nume,Prenume FROM Materii WHERE IDProfesor={0} AND IDMaterie={1};", splitData2[i], splitData1[i]);
                            data = MyData.getData(selectDates, new string[] { "Nume", "Prenume" });
                        }
                    }
                    //setam daca e sau nu promovat
                    for (int i = 0; i < mycourse_dgv.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(mycourse_dgv["Nota", i].Value) >= 5)
                        {
                            mycourse_dgv["Promovat", i].Value = true;
                        }
                        else
                        {
                            mycourse_dgv["Promovat", i].Value = false;
                        }
                        string update = string.Format("UPDATE Teste_Materii SET Promovat={2} WHERE Materie='{0}' AND ID_Test={1};", materii_db.SelectedItem.ToString(), mycourse_dgv["ID_Test", i].Value, mycourse_dgv["Promovat", i].Value);
                        MyData.execSql(update);
                    }
                    //calculam media + verificam daca e sau nu promovat
                    if (mycourse_dgv.Rows.Count > 0)
                    {
                        promovat_chk.Visible = true;
                        medie_txt.Visible = true;
                        label3.Visible = true;
                        float total = 0f, count = 0;
                        for (int i = 0; i < mycourse_dgv.Rows.Count; i++)
                        {
                            total += Convert.ToSingle(mycourse_dgv["Nota", i].Value);
                            count++;
                        }
                        double medie = total / count;
                        medie_txt.Text = string.Format("{0:0.00}",medie);
                        if (medie < 4.5)
                        {
                            promovat_chk.Checked = false;
                            medie = Math.Round(medie,2);
                        }
                        else if (medie == 4.5)
                        {
                            promovat_chk.Checked = true;
                            medie = Math.Ceiling(medie);
                        }
                        else
                        {
                            promovat_chk.Checked = true;
                            medie = Math.Round(medie,2);
                        }
                        string update = string.Format("UPDATE Teste_Materii SET Promovat_Anul={1} WHERE Materie='{0}';", materii_db.SelectedItem.ToString(), promovat_chk.Checked);
                        MyData.execSql(update);
                        update = string.Format("UPDATE Teste_Materii SET Nota_finala={0} WHERE ID_Student={1} AND Materie='{2}';", medie, Main_form.id_user, materii_db.SelectedItem.ToString());
                        MyData.execSql(update);
                    }
                    else
                    {
                        promovat_chk.Visible = false;
                        medie_txt.Visible = false;
                        label3.Visible = false;
                    }
                }
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            InitAllCourses();
            dgv_allcourse.Refresh();
        }

        private void dgv_allcourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgv_allcourse.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string sql = string.Format("SELECT Materii_inscris FROM Grades WHERE ID_Student={0};", Main_form.id_user);
                    string data = MyData.stringSelector(sql, "Materii_inscris");
                    //checking all exceptions
                    if (data.Split(',').Length >= max_materii)
                    {
                        MessageBox.Show($"Esti deja inscris la {max_materii} materii , nu poti alege altele decat la incheierea anului.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //daca exista
                    string[] splitData = data.Split(',');
                    for (int i = 0; i < splitData.Length; i++)
                    {
                        if (splitData[i] == dgv_allcourse["ID_Materie", e.RowIndex].Value.ToString())
                        {
                            MessageBox.Show("Esti inscris deja la aceasta materie , nu te poti inscrie de 2 ori.", "Atentionare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    data = data.Length <= 0 ? dgv_allcourse["ID_Materie", e.RowIndex].Value.ToString() : string.Format($"{data},{dgv_allcourse["ID_Materie", e.RowIndex].Value.ToString()}");
                    sql = string.Format("SELECT Id_Profesor FROM Grades WHERE ID_Student={0};", Main_form.id_user);
                    string id = MyData.stringSelector(sql, "Id_profesor");
                    sql = string.Format("SELECT IDProfesor FROM Materii WHERE Nume='{0}' AND Prenume='{1}';", dgv_allcourse["Nume", e.RowIndex].Value.ToString(), dgv_allcourse["Prenume", e.RowIndex].Value.ToString());
                    string realID = MyData.stringSelector(sql, "IDProfesor");
                    id = id.Length <= 0 ? realID : string.Format($"{id},{realID}");
                    sql = string.Format("UPDATE Grades SET Materii_inscris='{0}', Id_Profesor='{2}' WHERE ID_Student={1};", data, Main_form.id_user, id);
                    MyData.execSql(sql);
                    dgv_allcourse["count_st", e.RowIndex].Value = Convert.ToInt32(dgv_allcourse["count_st", e.RowIndex].Value) + 1;
                    sql = string.Format("UPDATE Materii SET Numar_studenti={0} WHERE IDMaterie={1} AND IDProfesor={2};", dgv_allcourse["count_st", e.RowIndex].Value, dgv_allcourse["ID_Materie", e.RowIndex].Value, realID);
                    MyData.execSql(sql);
                    AddTesteInBox(materii_db);
                    AddTesteInBox(materii_cb);
                    LoadDateMaterii();
                    LoadDateTeste();
                    MessageBox.Show($"Te-ai inscris cu succes la cursul de {dgv_allcourse["Nume_Materie", e.RowIndex].Value.ToString()} al dl-ului profesor {dgv_allcourse["Nume", e.RowIndex].Value.ToString()} {dgv_allcourse["Prenume", e.RowIndex].Value.ToString()}.", "Instintare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void materii_db_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDateMaterii();
            KeepTrakingName();
        }

        public void KeepTrakingName()
        {
            if (mycourse_dgv.Rows.Count > 0)
            {
                for (int j = 0; j < mycourse_dgv.Rows.Count; j++)
                {
                    mycourse_dgv["name", j].Value = data[0];
                    mycourse_dgv["prename", j].Value = data[1];
                }
            }
        }

        private void materii_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //index changed => redraw grafic
            //ia notele din baza de date si deseneaza 
            materii_note.ChartAreas[0].AxisY.Maximum = 10;
            materii_note.Series["Teste"].Points.Clear();
            string sql = string.Format("SELECT Nota,Nume_fisier FROM Teste_Materii WHERE Nota <> 0 AND ID_Student={0} AND Materie='{1}';", Main_form.id_user, materii_cb.SelectedItem.ToString());
            DataTable dt = MyData.readTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double da = Convert.ToDouble(dt.Rows[i][0]);
                materii_note.Series["Teste"].Points.AddXY(dt.Rows[i][1].ToString(), Convert.ToDouble(dt.Rows[i][0]));
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2 && teste_dgv.Columns.Count <= 4 && teste_dgv.Rows.Count > 0)
            {
                int value = Convert.ToInt32(teste_dgv["ID_Prof", 0].Value);
                string sql = string.Format("SELECT IDMaterie FROM Profesori WHERE ID_Prof={0};", value);
                int ID = MyData.selectData(sql, "IDMaterie");
                sql = string.Format("SELECT Nume,Prenume FROM Materii WHERE IDProfesor={0} AND IDMaterie={1};", value, ID);
                teste_dgv.Columns.Add("name", "Nume Profesor");
                teste_dgv.Columns.Add("prename", "Prenume Profesor");
                string[] data = MyData.getData(sql, new string[] { "Nume", "Prenume" });
                for (int i = 0; i < teste_dgv.Rows.Count; i++)
                {
                    teste_dgv["name", i].Value = data[0];
                    teste_dgv["prename", i].Value = data[1];
                }
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.HeaderText = "Test";
                button.ValueType = typeof(Button);
                button.Text = "Start";
                button.UseColumnTextForButtonValue = true;
                teste_dgv.Columns.Add(button);
                teste_dgv.Columns.RemoveAt(3);
            }
            else if (tabControl1.SelectedIndex == 2 && teste_dgv.Rows.Count <= 0 || tabControl1.SelectedIndex == 1 && mycourse_dgv.Rows.Count <= 0 || tabControl1.SelectedIndex == 3 && materii_cb.Items.Count <= 0)
            {
                MessageBox.Show("Nu ai nici un test disponibil sau nu esti inscris la nici un curs.", "Instintare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectTab(0);
            }
            KeepTrakingName();
        }

        private void teste_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (teste_dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && !test_opened)
                {
                    TestForm test = new TestForm();
                    string namePath = string.Format("{0}_{1}",teste_dgv["name",e.RowIndex].Value.ToString(),teste_dgv["prename",e.RowIndex].Value.ToString());
                    CurrentTest = $"teste/{teste_dgv["Materie", e.RowIndex].Value.ToString()}/{namePath}/{teste_dgv[1, e.RowIndex].Value.ToString()}.txt";
                    int max = MyData.takeMax("Teste_Materii", "ID_Test", "Materie", teste_dgv["Materie", e.RowIndex].Value.ToString());
                    test.Text = $"Testul {teste_dgv[0, e.RowIndex].Value}/{max}";
                    test.prop = teste_dgv;
                    test.IndexRow = e.RowIndex;
                    test.reload = this;
                    test.Show();
                    test.Focus();
                    test_opened = true;
                }
            }
        }
    }
}