using System;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace OTI2012
{
    public partial class ProfesorPanel : Form
    {
        string path = string.Empty;
        int tip = 1;
        int tab = 0;
        int stock_data = 0;
        DataTable dt;
        ComboBox cmb;
        CheckedListBox lst_box;
        public Main_form main { get; set; }
        public TextBox[] info = new TextBox[2];
        TestEditor editor;
        public TextBox[] Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }
        int track_questions = 0;

        public ProfesorPanel()
        {
            InitializeComponent();
            listaStudenti.Visible = true;
            add_pnl.Visible = false;
            LoadDataStudenti();
            tab = 2;
            mesaj_lbl.Text = "Lista studenti inscrisi";
        }

        private void ProfesorPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_form.CloseMain();
        }

        private void promovatiMenu_Click(object sender, EventArgs e)
        {
            tip = 2;
            tab = 2;
            LoadDataStudenti();
        }

        private void picatiMenu_Click(object sender, EventArgs e)
        {
            tip = 3;
            tab = 2;
            LoadDataStudenti();
        }

        private void listacompletaMenu_Click(object sender, EventArgs e)
        {
            tip = 1;
            tab = 2;
            LoadDataStudenti();
        }

        public void LoadDataStudenti()
        {
            if (studenti_dgv.DataSource != null)
            {
                studenti_dgv.Columns.Clear();
            }
            string data = string.Empty;
            switch (tip)
            {
                case 1:
                    mesaj_lbl.Text = "Lista studenti inscrisi";
                    nume_cmb.Visible = false;
                    data = string.Format("SELECT Grades.ID_Student,Grades.Nume,Grades.Prenume,Studenti.Nick,Studenti.Parola,Studenti.Ultima_logare FROM Grades,Studenti WHERE Grades.ID_Student = Studenti.ID_Student AND Grades.ID_Profesor LIKE '%{0}%';", Main_form.id_user);
                    dt = MyData.readTable(data);
                    studenti_dgv.DataSource = dt;
                    for (int i = 0; i < studenti_dgv.Columns.Count; i++)
                    {
                        studenti_dgv.Columns[i].ReadOnly = true;
                    }
                    break;
                case 2:
                    nume_cmb.Visible = true;
                    mesaj_lbl.Text = "Lista studenti promovati";
                    data = string.Format("SELECT Grades.ID_Student,Grades.Nume,Grades.Prenume,Teste_Materii.Nota,Teste_Materii.Nume_fisier,Teste_Materii.Nota_finala FROM Grades,Teste_Materii WHERE Teste_Materii.ID_Student={1} AND Grades.ID_Student = Teste_Materii.ID_Student AND Teste_Materii.ID_Prof={0} AND Teste_Materii.Promovat_Anul=true AND Teste_Materii.Nota <> 0;", Main_form.id_user, getStudentID());
                    dt = MyData.readTable(data);
                    dt.Columns["Nume_fisier"].ColumnName = "Nume test";
                    dt.AcceptChanges();
                    studenti_dgv.DataSource = dt;
                    for (int i = 0; i < studenti_dgv.Columns.Count; i++)
                    {
                        if (studenti_dgv.Columns[i].Name == "Nota")
                            continue;
                        studenti_dgv.Columns[i].ReadOnly = true;
                    }
                    break;
                case 3:
                    nume_cmb.Visible = true;
                    mesaj_lbl.Text = "Lista studenti nepromovati";
                    data = string.Format("SELECT Grades.ID_Student,Grades.Nume,Grades.Prenume,Teste_Materii.Nota,Teste_Materii.Nume_fisier,Teste_Materii.Nota_finala FROM Grades,Teste_Materii WHERE Teste_Materii.ID_Student={1} AND Grades.ID_Student = Teste_Materii.ID_Student AND Teste_Materii.ID_Prof={0} AND Teste_Materii.Promovat_Anul=false AND Teste_Materii.Nota <> 0;", Main_form.id_user, getStudentID());
                    dt = MyData.readTable(data);
                    dt.Columns["Nume_fisier"].ColumnName = "Nume test";
                    dt.AcceptChanges();
                    studenti_dgv.DataSource = dt;
                    for (int i = 0; i < studenti_dgv.Columns.Count; i++)
                    {
                        if (studenti_dgv.Columns[i].Name == "Nota")
                            continue;
                        studenti_dgv.Columns[i].ReadOnly = true;
                    }
                    break;
            }
        }

        private void nume_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change index , reload datagridview
            if (tab == 1)
            {
                ListaTeste();
            }
            else if (tab == 2)
            {
                LoadDataStudenti();
            }
        }

        public void InitListaStudenti(ComboBox cb)
        {
            if (cb.Items.Count <= 0)
            {
                string sql = string.Format("SELECT Nume,Prenume FROM Grades WHERE ID_Profesor LIKE '%{0}%';", Main_form.id_user);
                DataTable dt = MyData.readTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string item_complet = string.Format($"{dt.Rows[i][0].ToString()} {dt.Rows[i][1].ToString()}");
                    cb.Items.Add(item_complet);
                }
                if (dt.Rows.Count > 0)
                    cb.SelectedIndex = 0;
                else
                    MessageBox.Show("Nu ai nici un elev inscris la cursurile tale.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProfesorPanel_Load(object sender, EventArgs e)
        {
            InitListaStudenti(nume_cmb);
            string nume = getName(Main_form.id_user, 1);
            string prename = getName(Main_form.id_user, 2);
            nume_lbl.Text = string.Format($"{nume} {prename}");
        }

        public string getName(int id, int type) //1 -> nume | 2 -> prenume
        {
            string sql = string.Empty,data = string.Empty;
            switch (type)
            {
                case 1:
                    sql = string.Format("SELECT Nume FROM Materii WHERE IDProfesor={0};", Main_form.id_user);
                    data = MyData.stringSelector(sql, "Nume");
                    break;
                case 2:
                    sql = string.Format("SELECT Prenume FROM Materii WHERE IDProfesor={0};", Main_form.id_user);
                    data = MyData.stringSelector(sql, "Prenume");
                    break;
            }
            return data;
        }

        public int getStudentID()
        {
            if (nume_cmb.Items.Count > 0)
            {
                string[] sr = nume_cmb.SelectedItem.ToString().Split(' ');
                string sql = string.Format("SELECT ID_Student FROM Grades WHERE ID_Profesor LIKE '%{0}%' AND Nume='{1}' AND Prenume='{2}';", Main_form.id_user, sr[0], sr[1]);
                int data = MyData.selectData(sql, "ID_Student");
                return data;
            }
            return 0;
        }

        private void log_out_Click(object sender, EventArgs e)
        {
            if(Main_form.IsLogged && Main_form.IsProfessor)
            {
                //log out
                if(editor != null)
                {
                    editor.Close();
                }
                Main_form.IsLogged = false;
                Main_form.IsProfessor = false;
                Info[0].Text = Info[1].Text = string.Empty;
                main.Show();
                Info[0].Focus();
                this.Hide();
                this.Dispose();
            }
        }

        private void adaugaTeste_Click(object sender, EventArgs e)
        {
            //add panel
            if (tip_intrebare.Items.Count <= 0)
            {
                tip_intrebare.Items.Add("Raspunsuri multiple");
                tip_intrebare.Items.Add("Raspunsuri unice");
            }
            if(studenti_lst.Items.Count <= 0)
            {
                studenti_lst.Items.Add("Toti");
                string sql = string.Format("SELECT Nume,Prenume FROM Grades WHERE ID_Profesor LIKE '%{0}%';", Main_form.id_user);
                DataTable dt = MyData.readTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string item_complet = string.Format($"{dt.Rows[i][0].ToString()} {dt.Rows[i][1].ToString()}");
                    studenti_lst.Items.Add(item_complet);
                }
            }
            InitCreate();
        }

        public void InitCreate()
        {
            studenti_lst.SelectedIndex = 0;
            tip_intrebare.SelectedIndex = 0;
            create_btn.Enabled = true;
            nume_fisier.Enabled = true;
            studenti_lst.Enabled = true;
            timp_txt.Visible = true;
            label8.Visible = true;
            listaStudenti.Visible = false;
            label2.Visible = false;
            track_questions = 0;
            CorectAnswerBox();
            nume_fisier.Text = question_txt.Text = raspunsuri_list.Text = pct_txt.Text = timp_txt.Text = string.Empty;
            add_pnl.Visible = true;
            intrebare_lbl.Text = $"Intrebarea numarul {track_questions + 1}";
        }

        private void tesetMenu_Click(object sender, EventArgs e)
        {
            tab = 1;
            ListaTeste();
        }

        public void ListaTeste()
        {
            if (studenti_dgv.DataSource != null)
            {
                studenti_dgv.Columns.Clear();
            }
            //teste all , delete , etc
            nume_cmb.Visible = true;
            listaStudenti.Visible = true;
            add_pnl.Visible = false;
            mesaj_lbl.Text = "Lista teste";
            mesaj_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            string sql = string.Format("SELECT ID_Test,Nume_fisier,Promovat FROM Teste_Materii WHERE ID_Student={0} AND ID_Prof={1};", getStudentID(), Main_form.id_user);
            dt = MyData.readTable(sql);
            studenti_dgv.DataSource = dt;
            studenti_dgv.Columns["Nume_fisier"].HeaderText = "Nume test";
            //butoane delete , modifica and reset
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "delete";
            btn.HeaderText = "Sterge test";
            btn.Text = "Sterge";
            btn.UseColumnTextForButtonValue = true;
            btn.ValueType = typeof(Button);
            studenti_dgv.Columns.Add(btn);
            btn = new DataGridViewButtonColumn();
            btn.Name = "modifica";
            btn.HeaderText = "Modifica test";
            btn.Text = "Modifica";
            btn.UseColumnTextForButtonValue = true;
            btn.ValueType = typeof(Button);
            studenti_dgv.Columns.Add(btn);
            btn = new DataGridViewButtonColumn();
            btn.Name = "reset";
            btn.HeaderText = "Reseteaza test";
            btn.Text = "Reset";
            btn.UseColumnTextForButtonValue = true;
            btn.ValueType = typeof(Button);
            studenti_dgv.Columns.Add(btn);
            for (int i = 0; i < studenti_dgv.Rows.Count; i++)
            {
                studenti_dgv.Columns[i].ReadOnly = true;
            }
        }

        private void studenti_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (tab == 1)
                return;
            if (tip == 2 || tip == 3)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 3)
                {
                    if (stock_data != Convert.ToInt32(studenti_dgv[e.ColumnIndex, e.RowIndex].Value) && studenti_dgv.Columns[e.ColumnIndex].Name == "Nota")
                    {
                        stock_data = Convert.ToInt32(studenti_dgv[e.ColumnIndex, e.RowIndex].Value);
                    }
                }
            }
        }

        private void studenti_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (tab == 1)
                return;
            if (tip == 2 || tip == 3 && e.ColumnIndex == 3)
            {
                if (e.RowIndex >= 0)
                {
                    if(Convert.ToInt32(studenti_dgv[e.ColumnIndex, e.RowIndex].Value) == stock_data)
                    { 
                        return;
                    }
                    if (Convert.ToInt32(studenti_dgv[e.ColumnIndex, e.RowIndex].Value) <= 0 || Convert.ToInt32(studenti_dgv[e.ColumnIndex, e.RowIndex].Value) > 10)
                    {
                        MessageBox.Show("Nu poti pune o nota mai mica de 1 sau mai mare de 10.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        studenti_dgv[e.ColumnIndex, e.RowIndex].Value = stock_data;
                        return;
                    }
                    string sql = string.Empty;
                    //start updating
                    sql = string.Format("UPDATE Teste_Materii SET Nota={0} WHERE ID_Student={1} AND ID_Prof={2} AND Nume_fisier='{3}';",studenti_dgv[e.ColumnIndex,e.RowIndex].Value,getStudentID(),Main_form.id_user, studenti_dgv[4, e.RowIndex].Value);
                    MyData.execSql(sql);
                    bool promotion = Convert.ToInt32(studenti_dgv[e.ColumnIndex, e.RowIndex].Value) >= 5 ? true : false;
                    sql = string.Format("UPDATE Teste_Materii SET Promovat={0} WHERE ID_Student={1} AND ID_Prof={2} AND Nume_fisier='{3}';", promotion, getStudentID(), Main_form.id_user, studenti_dgv[4, e.RowIndex].Value);
                    MyData.execSql(sql);
                    //now update all cuz yeah...
                    int medie = 0;
                    for(int i = 0; i < studenti_dgv.Rows.Count;i++)
                    {
                        medie += Convert.ToInt32(studenti_dgv["Nota",i].Value);
                    }
                    medie = medie / studenti_dgv.Rows.Count;
                    sql = string.Format("UPDATE Teste_Materii SET Nota_finala={0} WHERE ID_Student={1} AND ID_Prof={2};",medie, getStudentID(), Main_form.id_user);
                    MyData.execSql(sql);
                    promotion = medie >= 5 ? true : false;
                    sql = string.Format("UPDATE Teste_Materii SET Promovat_Anul={0} WHERE ID_Student={1} AND ID_Prof={2};", promotion, getStudentID(), Main_form.id_user);
                    MyData.execSql(sql);
                    //reset dgv ==> unbug method 
                    BeginInvoke(new MethodInvoker(LoadDataStudenti));
                }
            }
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if(nume_fisier.Text == string.Empty)
            {
                MessageBox.Show("Numele fisierului este gresit.", "Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //materii 
            string sql = string.Format("SELECT Nume_Materie FROM TabelMaterii WHERE ID_Profesori LIKE '%{0}%';", Main_form.id_user);
            string numeMaterie = MyData.stringSelector(sql, "Nume_Materie");
            path = string.Format($"teste/{numeMaterie}");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //exista folderul cu materie verific daca exista folderul cu numele profului
            path += $"/{getName(Main_form.id_user, 1)}_{getName(Main_form.id_user, 2)}";
            if (!Directory.Exists(path))
            {
                //directorul exista , creeam fisierul
                Directory.CreateDirectory(path);
            }
            path += $"/{nume_fisier.Text}.txt";
            //verific daca exista fisierul , daca exista eroare...
            if (File.Exists(path))
            {
                MessageBox.Show("Fisierul exista deja , acesta poate fii doar modificat.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            File.Create(path).Close();
            create_btn.Enabled = false;
            nume_fisier.Enabled = false;
            studenti_lst.Enabled = false;
            MessageBox.Show($"Testul a fost creat cu succes pentru studentul {studenti_lst.SelectedItem.ToString()}.\nAcum poti adauga intrebarile pentru a putea fii rezolvat.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AddQuestion(string quesiton)
        {
            if(File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                using (StreamWriter wr = new StreamWriter(fs))
                {
                    wr.WriteLine(quesiton);
                }
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if(create_btn.Enabled)
            {
                MessageBox.Show("Trebuie sa stabilesti mai intai fisierul si pentru cine creezi testul.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (question_txt.Text == string.Empty || raspunsuri_list.Text == string.Empty || pct_txt.Text == string.Empty || timp_txt.Text == string.Empty)
            {
                MessageBox.Show("Toate campurile sunt obligatorii.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToInt32(tip_intrebare.SelectedIndex) == 0)
            {
                if(lst_box != null)
                {
                    if(lst_box.SelectedItems.Count <= 0)
                    {
                        MessageBox.Show("Toate campurile sunt obligatorii.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            track_questions++;
            intrebare_lbl.Text = $"Intrebarea numarul {track_questions+1}";
            string c_answer = string.Empty;
            string[] split = raspunsuri_list.Text.Split(';');
            if (string.IsNullOrEmpty(raspunsuri_list.Text) || split.Length != 4)
            {
                MessageBox.Show("Toate campurile sunt obligatorii.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (Convert.ToInt32(tip_intrebare.SelectedIndex) == 0)
                {
                    for (int i = 0; i < lst_box.CheckedItems.Count; i++)
                    {
                        c_answer += $"{lst_box.CheckedItems[i].ToString()},";
                    }
                    c_answer = c_answer.Remove(c_answer.Length - 1);
                }
                else
                {
                    c_answer = cmb.SelectedItem.ToString();
                }
            }
            string question = string.Format($"{question_txt.Text};{raspunsuri_list.Text};{c_answer};{pct_txt.Text};{tip_intrebare.SelectedIndex}");
            if (track_questions == 1)
            {
                AddQuestion(timp_txt.Text);
            }
            AddQuestion(question);
            question_txt.Text = raspunsuri_list.Text = pct_txt.Text = string.Empty;
            timp_txt.Visible = false;
            label8.Visible = false;
            CorectAnswerBox();
            MessageBox.Show("Intrebare adaugata cu succes.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tip_intrebare_SelectedIndexChanged(object sender, EventArgs e)
        {
            CorectAnswerBox();
        }

        private void raspunsuri_list_Leave(object sender, EventArgs e)
        {
            CorectAnswerBox();
        }

        public void CorectAnswerBox()
        {
            string[] split = raspunsuri_list.Text.Split(';');
            switch (Convert.ToInt32(tip_intrebare.SelectedIndex))
            {
                case 0:
                    //raspunsuri multiple
                    if(cmb != null)
                    {
                        cmb.Visible = false;
                    }
                    if (lst_box != null)
                    {
                        lst_box.Items.Clear();
                    }
                    else
                    {
                        lst_box = new CheckedListBox();
                        lst_box.FormattingEnabled = true;
                        lst_box.Location = new System.Drawing.Point(603, 283);
                        lst_box.Name = "m_answer";
                        lst_box.Size = new System.Drawing.Size(217, 109);
                        lst_box.TabIndex = 21;
                        add_pnl.Controls.Add(lst_box);
                    }
                    //adaug raspunsurile daca exista
                    if (!string.IsNullOrEmpty(raspunsuri_list.Text) && split.Length == 4)
                    {
                        for (int i = 0; i < split.Length; i++)
                        {
                            lst_box.Items.Add(split[i]);
                        }
                        lst_box.Visible = true;
                        label2.Visible = true;
                    }
                    else
                    {
                        lst_box.Visible = false;
                        label2.Visible = false;
                    }
                    label2.Text = "Raspunsuri corecte :";
                    break;
                case 1:
                    //creez pt solo answer
                    if (lst_box != null)
                    {
                        lst_box.Visible = false;
                    }
                    if (cmb != null)
                    {
                        cmb.Items.Clear();
                    }
                    else
                    {
                        cmb = new ComboBox();
                        cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmb.FormattingEnabled = true;
                        cmb.Location = new System.Drawing.Point(603, 283);
                        cmb.Name = "s_answer";
                        cmb.Size = new System.Drawing.Size(207, 21);
                        cmb.TabIndex = 21;
                        add_pnl.Controls.Add(cmb);
                    }
                    //adaug raspunsurile daca exista
                    if (!string.IsNullOrEmpty(raspunsuri_list.Text) && split.Length == 4)
                    {
                        for (int i = 0; i < split.Length; i++)
                        {
                            cmb.Items.Add(split[i]);
                        }
                        cmb.SelectedIndex = 0;
                        cmb.Visible = true;
                        label2.Visible = true;
                    }
                    else
                    {
                        cmb.Visible = false;
                        label2.Visible = false;
                    }
                    label2.Text = "Raspuns corect :";
                    break;
            }
        }

        private void timp_txt_Leave(object sender, EventArgs e)
        {
            string[] sp = timp_txt.Text.Split(';');
            if(sp.Length != 3)
            {
                MessageBox.Show("Timp gresit adaugat , te rog sa reincerci iar .", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timp_txt.Text = string.Empty;
                return;
            }
            //TODO:parse that it's int
            bool is_int = true;
            for(int i = 0; i < sp.Length;i++)
            {
                if(!CheckInt(sp[i]))
                {
                    is_int = false;
                    break;
                }
            }
            if(!is_int)
            {
                MessageBox.Show("Trebuie sa introduci un int ca timp.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timp_txt.Text = string.Empty;
                return;
            }
        }

        private void pct_txt_Leave(object sender, EventArgs e)
        {
            //TODO:parse that it's int
            if(!CheckInt(pct_txt.Text))
            {
                MessageBox.Show("Trebuie sa introduci un int pentru punctaj.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pct_txt.Text = string.Empty;
                return;
            }
        }

        public bool CheckInt(string value)
        {
            int da;
            if(Int32.TryParse(value,out da))
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ask if he is sure about saving the test and then save in database to be used by all users.
            if (studenti_lst.Items.Count > 0)
            {
                string sql = string.Empty;  
                sql = string.Format("SELECT Nume_Materie FROM TabelMaterii WHERE ID_Profesori LIKE '%{0}%';", Main_form.id_user);
                string numeMaterie = MyData.stringSelector(sql, "Nume_Materie");
                if (studenti_lst.SelectedIndex == 0)
                {
                    //adaugam pentru toti elevi in baza de date: loop 
                    for (int i = 1; i < studenti_lst.Items.Count; i++)
                    {
                        string[] split_name = studenti_lst.Items[i].ToString().Split(' ');
                        MessageBox.Show(split_name[0]);
                        sql = string.Format("SELECT ID_Student FROM Grades WHERE Nume='{1}' AND Prenume='{2}' AND Id_Profesor LIKE '%{0}%';", Main_form.id_user, split_name[0], split_name[1]);//get id
                        int id = MyData.selectData(sql, "ID_Student");
                        // adaug testul
                        sql = string.Format("INSERT INTO Teste_Materii(ID_Student,Materie,ID_Prof,Nume_fisier)VALUES({0},'{1}',{2},'{3}');", id, numeMaterie, Main_form.id_user, nume_fisier.Text);
                        MyData.execSql(sql);
                        sql = string.Format("SELECT IDTesteAdaugate FROM Materii WHERE IDProfesor={0};", Main_form.id_user);
                        string teste = MyData.stringSelector(sql, "IDTesteAdaugate");
                        sql = string.Format("SELECT ID_Test FROM Teste_Materii WHERE ID_Student={0} AND Materie='{1}' AND ID_Prof={2};", id, numeMaterie, Main_form.id_user);
                        int ids = MyData.selectData(sql, "ID_Test");
                        teste = teste.Length > 0 ? string.Format($"{teste},{ids}") : string.Format($"{ids}");
                        sql = string.Format("UPDATE Materii SET IDTesteAdaugate='{0}' WHERE IDProfesor={1};", teste, Main_form.id_user);
                        MyData.execSql(sql);
                    }
                }
                else
                {
                    sql = string.Format("INSERT INTO Teste_Materii(ID_Student,Materie,ID_Prof,Nume_fisier)VALUES({0},'{1}',{2},'{3}');", getStudentID(), numeMaterie, Main_form.id_user, nume_fisier.Text);
                    MyData.execSql(sql);
                    sql = string.Format("SELECT IDTesteAdaugate FROM Materii WHERE IDProfesor={0};", Main_form.id_user);
                    string teste = MyData.stringSelector(sql, "IDTesteAdaugate");
                    sql = string.Format("SELECT ID_Test FROM Teste_Materii WHERE ID_Student={0} AND Materie='{1}' AND ID_Prof={2};", getStudentID(),numeMaterie,Main_form.id_user);
                    int id = MyData.selectData(sql, "ID_Test");
                    teste = teste.Length > 0 ? string.Format($"{teste},{id}") : string.Format($"{id}");
                    sql = string.Format("UPDATE Materii SET IDTesteAdaugate='{0}' WHERE IDProfesor={1};",teste,Main_form.id_user);
                    MyData.execSql(sql);
                }
                InitCreate();
                MessageBox.Show("Test adaugat cu succes !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void studenti_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(tip == 1)
            {
                if(e.RowIndex >= 0 && studenti_dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string sql = string.Empty;
                    sql = string.Format("SELECT Nume_Materie FROM TabelMaterii WHERE ID_Profesori LIKE '%{0}%';", Main_form.id_user);
                    string numeMaterie = MyData.stringSelector(sql, "Nume_Materie");
                    string path = string.Format($"teste/{numeMaterie}/{getName(Main_form.id_user, 1)}_{getName(Main_form.id_user, 2)}/{studenti_dgv[1, e.RowIndex].Value}.txt");
                    if (e.ColumnIndex == 3)
                    {
                        //sterge test
                        DialogResult res = MessageBox.Show($"Esti sigur ca vrei sa stergi acest test pentru elevul {nume_cmb.SelectedItem.ToString()} ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        switch (res)
                        {
                            case DialogResult.Yes:
                                sql = string.Format("SELECT ID_Test FROM Teste_Materii WHERE ID_Student={0} AND ID_Prof={1} AND Nume_fisier='{2}';", getStudentID(), Main_form.id_user, studenti_dgv[1, e.RowIndex].Value);
                                int id_test = MyData.selectData(sql, "ID_Test");
                                sql = string.Format("SELECT IDTesteAdaugate FROM Materii WHERE IDProfesor={0};",Main_form.id_user);
                                string id_teste = MyData.stringSelector(sql, "IDTesteAdaugate");
                                string[] splitTeste = id_teste.Split(',');
                                string[] new_data = new string[splitTeste.Length - 1];
                                int j = 0;
                                for(int i = 0; i < splitTeste.Length;i++)
                                {
                                    if(id_test != Convert.ToInt32(splitTeste[i]))
                                    {
                                        new_data[j] = splitTeste[i];
                                        j++;
                                    }
                                }
                                id_teste = string.Join(",", new_data);
                                sql = string.Format("UPDATE Materii SET IDTesteAdaugate='{0}' WHERE IDProfesor={1};", id_teste, Main_form.id_user);
                                MyData.execSql(sql);
                                //delete test
                                sql = string.Format("DELETE * FROM Teste_Materii WHERE ID_Student={0} AND ID_Prof={1} AND Nume_fisier='{2}';",getStudentID(),Main_form.id_user, studenti_dgv[1, e.RowIndex].Value);
                                MyData.execSql(sql);
                                if(File.Exists(path))
                                {
                                    File.Delete(path);
                                }
                                MessageBox.Show("Testul a fost sters cu succes din baza de date.","Informatie",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                //recreate
                                ListaTeste();
                                break;
                            case DialogResult.No:
                                break;
                        }

                    }
                    else if (e.ColumnIndex == 4)
                    {
                        //modifica test 
                        if (File.Exists(path))
                        {
                            editor = new TestEditor(path);
                            editor.Show();
                        }
                    }
                    else if (e.ColumnIndex == 5)
                    {
                        //reset test
                        sql = string.Format("UPDATE Teste_Materii SET Nota=0 AND Promovat=false WHERE ID_Test={0} AND ID_Student={1} AND ID_Prof={2};",studenti_dgv[0,e.RowIndex].Value.ToString(),getStudentID(),Main_form.id_user);
                        MyData.execSql(sql);
                        ListaTeste();
                        MessageBox.Show("Testul a fost reinitializat cu succes, acum studentul poate relua testul.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}