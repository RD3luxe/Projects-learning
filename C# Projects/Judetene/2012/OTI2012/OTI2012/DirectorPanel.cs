using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace OTI2012
{
    public partial class DirectorPanel : Form
    {
        public ViewFrame frame;
        public static Main_form form;
        public static bool opened = false;
        public static string old_data = string.Empty;
        public DataTable table, table_materii;
        public static TextBox[] text_main = new TextBox[2];
        private int save_comboBox = 0,save_id = 0;
        private bool once = true;
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

        public DirectorPanel()
        {
            InitializeComponent();
            DataTable data = getMaterii();
            once = true;
            object[] obj = new object[data.Rows.Count];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                obj[i] = data.Rows[i]["Nume_Materie"];
            }
            materii_combo.Items.AddRange(obj);
            materii_combo.SelectedIndex = 0;
            lista_modifica.Items.AddRange(new object[] { "Profesori", "Studenti" });
            lista_actiuni.Items.AddRange(new object[] { "Adauga", "Sterge", "Modifica " });
            lista_actiuni.SelectedIndex = 0;
            lista_modifica.SelectedIndex = 0;
            add_pnl.Visible = false;
            sterge_pnl.Visible = false;
            modifica_pnl.Visible = false;
        }

        public DataTable getMaterii()
        {
            DataTable data = new DataTable();
            MyData.readTable("TabelMaterii", "Nume_Materie", ref data);
            return data;
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (Main_form.IsLogged)
            {
                if(frame != null)
                {
                    frame.Close();
                }
                Main_form.IsLogged = false;
                Main_form.IsProfessor = false;
                TextMain[0].Text = TextMain[1].Text = string.Empty;
                main.Show();
                TextMain[0].Focus();
                this.Hide();
                this.Dispose();
            }
        }

        private void DirectorPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_form.CloseMain();
        }

        private void btn_modifica_Click(object sender, EventArgs e)
        {
            ActiuniDirector(lista_actiuni.SelectedItem.ToString());
        }

        public void ActiuniDirector(string actiune)
        {
            if (actiune == lista_actiuni.Items[0].ToString()) 
            {
                //adauga
                sterge_pnl.Visible = false;
                modifica_pnl.Visible = false;
                add_pnl.Visible = true;
                add_label.Text = "Adauga " + lista_modifica.SelectedItem.ToString();
                if (lista_modifica.SelectedItem.ToString() != lista_modifica.Items[0].ToString())
                {
                    materii_combo.Visible = false;
                    label10.Visible = false;
                }
                else
                {
                    materii_combo.Visible = true;
                    label10.Visible = true;
                }
            }
            else if (actiune == lista_actiuni.Items[1].ToString()) 
            {
                //sterge
                add_pnl.Visible = false;
                modifica_pnl.Visible = false;
                sterge_pnl.Visible = true;
                sterge_lbl.Text = "Sterge "+lista_modifica.SelectedItem.ToString();
                CreateTable(1);
            }
            else if(actiune == lista_actiuni.Items[2].ToString())
            {
                //updateaza
                add_pnl.Visible = false;
                sterge_pnl.Visible = false;
                modifica_pnl.Visible = true;
                modifica_lbl.Text = "Modifica "+lista_modifica.SelectedItem.ToString();
                CreateTable(2);
            }
        }

        public void CreateTable(int type)
        {
            table = new DataTable();
            switch (type)
            {
                case 1:
                    string sqlselect = string.Empty;
                    if (lista_modifica.SelectedItem.ToString() == lista_modifica.Items[0].ToString())
                    {
                        sqlselect = string.Format("SELECT IDProfesor,Nume,Prenume FROM Materii;");
                        table = MyData.readTable(sqlselect);
                        string sql = string.Format("SELECT ID_Materie,Nume_Materie FROM TabelMaterii;");
                        table_materii = MyData.readTable(sql);
                        table.Columns.Add("Materie");
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            string materie_sql = string.Format("SELECT IDMaterie FROM Materii WHERE IDProfesor={0};", table.Rows[i][0]);
                            int materie_id = MyData.selectData(materie_sql, "IDMaterie");
                            for (int j = 0; j < table_materii.Rows.Count; j++)
                            {
                                if (Convert.ToInt32(table_materii.Rows[j][0]) == materie_id)
                                {
                                    table.Rows[i]["Materie"] = table_materii.Rows[j][1];
                                }
                            }
                        }
                    }
                    else
                    {
                        sqlselect = string.Format("SELECT ID_Student,Nume,Prenume FROM Grades;");
                        table = MyData.readTable(sqlselect);
                    }
                    date_dgv.Columns.Clear();
                    date_dgv.DataSource = table;
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Sterge " + lista_modifica.SelectedItem.ToString();
                    btn.Name = "delete_btn";
                    btn.Text = "Sterge";
                    btn.ValueType = typeof(Button);
                    btn.UseColumnTextForButtonValue = true;
                    date_dgv.Columns.Add(btn);
                    break;
                case 2:
                    string sqlmodifica = string.Empty;
                    if (lista_modifica.SelectedItem.ToString() == lista_modifica.Items[0].ToString())
                    {
                        sqlmodifica = string.Format("SELECT Materii.IDProfesor,Materii.Nume,Materii.Prenume,TabelMaterii.Nume_Materie,Profesori.Nick,Profesori.Pass FROM Materii,TabelMaterii,Profesori WHERE Profesori.IDMaterie=TabelMaterii.ID_Materie AND Profesori.ID_Prof=Materii.IDProfesor;");
                        table = MyData.readTable(sqlmodifica);
                        modifica_dgv.Columns.Clear();
                        modifica_dgv.DataSource = table;
                        //Remodelate coloana 4 intr-o lista dropdown
                        DataGridViewComboBoxColumn list_materii = new DataGridViewComboBoxColumn();
                        list_materii.HeaderText = "Materie";
                        list_materii.Name = "lst_materii";
                        DataTable dt = getMaterii();
                        object[] obj = new object[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            obj[i] = dt.Rows[i]["Nume_Materie"];
                        }
                        list_materii.Items.AddRange(obj);
                        modifica_dgv.Columns.RemoveAt(3);
                        modifica_dgv.Columns.Add(list_materii);
                        for (int i = 0; i < modifica_dgv.RowCount; i++)
                        {
                            modifica_dgv["lst_materii", i].Value = table.Rows[i]["Nume_Materie"];
                        }
                        //buton cu ce teste a adaugat
                        DataGridViewButtonColumn ts = new DataGridViewButtonColumn();
                        ts.Name = "teste_btn";
                        ts.HeaderText = "Teste adaugate";
                        ts.Text = "Editeaza";
                        ts.UseColumnTextForButtonValue = true;
                        ts.ValueType = typeof(Button);
                        modifica_dgv.Columns.Add(ts);
                        modifica_dgv.Columns["IDProfesor"].ReadOnly = true;
                    }
                    else
                    {
                        sqlmodifica = string.Format("SELECT Grades.ID_Student,Grades.Nume,Grades.Prenume,Studenti.Nick,Studenti.Parola,Grades.Materii_inscris FROM Studenti,Grades WHERE Grades.ID_Student=Studenti.ID_Student;");
                        table = MyData.readTable(sqlmodifica);
                        modifica_dgv.Columns.Clear();
                        modifica_dgv.DataSource = table;
                        modifica_dgv.Columns["Materii_inscris"].Name = "ID_Materii";
                        //buton teste windows
                        DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                        button.Name = "teste_btn";
                        button.HeaderText = "Teste";
                        button.Text = "Vezi teste";
                        button.ValueType = typeof(Button);
                        button.UseColumnTextForButtonValue = true;
                        modifica_dgv.Columns.Add(button);
                        modifica_dgv.Columns["ID_Student"].ReadOnly = true;
                    }
                    break;
            }
        }

        private void adauga_btn_Click(object sender, EventArgs e)
        {
            //same ca la creare cont :)
            if (lista_modifica.SelectedItem.ToString() != lista_modifica.Items[0].ToString())
            {
                if (nume_txt.Text == string.Empty || nick_txt.Text == string.Empty || prenume_txt.Text == string.Empty || pass_txt.Text == string.Empty)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (nick_txt.Text == Main_form.director_acc[0])
                {
                    MessageBox.Show("Nickname deja folosit,alege altul.", "Nick folosit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nume_txt.Text = string.Empty;
                    return;
                }
            }
            else
            {
                if (nume_txt.Text == string.Empty || nick_txt.Text == string.Empty || prenume_txt.Text == string.Empty || pass_txt.Text == string.Empty || materii_combo.SelectedIndex == -1)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (nick_txt.Text == Main_form.director_acc[0])
                {
                    MessageBox.Show("Nickname deja folosit,alege altul.", "Nick folosit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nume_txt.Text = string.Empty;
                    return;
                }
            }
            //verifica daca contul exista in baza de date Studenti si Profesori ( nickname-ul mai exact ) dupa verifica daca exista numele si prenumele in baza de date.
            string sql = string.Format("SELECT Nick,Parola FROM Studenti WHERE Nick='{0}';", nick_txt.Text);
            string sql2 = string.Format("SELECT Nick,Pass FROM Profesori WHERE Nick='{0}';", nick_txt.Text);
            short countStudenti = MyData.countData(sql);
            short countProfesor = MyData.countData(sql2);
            if (countProfesor >= 1 || countStudenti >= 1)
            {
                MessageBox.Show("Nickname deja folosit,alege altul.", "Nick folosit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nick_txt.Text = string.Empty;
                return;
            }
            string sqlQ = string.Format("SELECT ID_Student FROM Grades WHERE Nume='{0}' AND Prenume='{1}';", nume_txt.Text, prenume_txt.Text);
            string sqlprof = string.Format("SELECT IDProfesor FROM Materii WHERE Nume='{0}' AND Prenume='{1}';", nume_txt.Text, prenume_txt.Text);
            short countStudentNume = MyData.countData(sqlQ);
            short countprofNume = MyData.countData(sqlprof);
            if (countStudentNume >= 1 || countprofNume >= 1)
            {
                MessageBox.Show("Acel nume si prenume exista deja in baza de date.Poti avea doar un cont cu acealsi nume.", "Nume existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nume_txt.Text = prenume_txt.Text = string.Empty;
                return;
            }
            if (lista_modifica.SelectedItem.ToString() != lista_modifica.Items[0].ToString()) //add student 
            {
                string addsql = string.Format("INSERT INTO Studenti(Nick,Parola)VALUES('{0}','{1}');", nick_txt.Text, pass_txt.Text);
                MyData.execSql(addsql);
                string sqlID = string.Format("SELECT ID_Student FROM Studenti WHERE Nick='{0}' and Parola='{1}';", nick_txt.Text, pass_txt.Text);
                int id_student = MyData.selectData(sqlID, "ID_Student");
                string addNume = string.Format("INSERT INTO Grades(ID_Student,Nume,Prenume)VALUES({0},'{1}','{2}');", id_student, nume_txt.Text, prenume_txt.Text);
                MyData.execSql(addNume);
                MessageBox.Show("Student adaugat !", "Adaugare cu succces", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nume_txt.Text = pass_txt.Text = nick_txt.Text = prenume_txt.Text = string.Empty;
            }
            else //else add profesor
            {
                int id_materie = (Convert.ToInt32(materii_combo.SelectedIndex) + 1);
                string addprof = string.Format("INSERT INTO Profesori(Nick,Pass,IDMaterie)VALUES('{0}','{1}',{2});", nick_txt.Text, pass_txt.Text, id_materie);
                MyData.execSql(addprof);
                string sqlProfID = string.Format("SELECT ID_Prof FROM Profesori WHERE Nick='{0}' AND Pass='{1}';", nick_txt.Text, pass_txt.Text);
                int IdProf = MyData.selectData(sqlProfID, "ID_Prof");
                string add = string.Format("INSERT INTO Materii(IDMaterie,IDProfesor,Nume,Prenume)VALUES('{0}','{1}','{2}','{3}');", id_materie, IdProf, nume_txt.Text,prenume_txt.Text);
                MyData.execSql(add);
                string new_id = string.Empty;
                string[] selectMaterii = MyData.getData("TabelMaterii",new string[] { "ID_Profesori" },"ID_Materie", id_materie);
                if(selectMaterii[0].Length > 0)
                    new_id = selectMaterii[0] + "," + IdProf.ToString();
                else
                    new_id = IdProf.ToString();
                string addquery = string.Format("UPDATE TabelMaterii SET ID_Profesori='{0}' WHERE ID_Materie={1};",new_id, id_materie);
                MyData.execSql(addquery);
                MessageBox.Show("Profesor adaugat !", "Adaugare cu succces", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nume_txt.Text = pass_txt.Text = nick_txt.Text = prenume_txt.Text = string.Empty;
            }
        }

        private void lista_modifica_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiuniDirector(lista_actiuni.SelectedItem.ToString());
        }

        private void date_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(date_dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //ask first
                string mesaj = string.Empty;
                mesaj = string.Format("Esti sigur ca vrei sa stergi {0} {1} {2} ?",lista_modifica.SelectedIndex == 0? "profesorul":"studentul",date_dgv["Nume",e.RowIndex].Value.ToString(), date_dgv["Prenume", e.RowIndex].Value.ToString());
                DialogResult result = MessageBox.Show(mesaj,"Stergere",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                switch(result)
                {
                    case DialogResult.Yes:
                        //delete record
                        string sql = string.Empty;
                        if (lista_modifica.SelectedIndex == 0)
                        {
                            string materie_sql = string.Format("SELECT IDMaterie FROM Materii WHERE IDProfesor={0};", date_dgv["IDProfesor", e.RowIndex].Value);
                            int id_materie = MyData.selectData(materie_sql, "IDMaterie");
                            string[] selectMaterii = MyData.getData("TabelMaterii", new string[] { "ID_Profesori" }, "ID_Materie", id_materie);
                            sql = string.Format("DELETE ID_Prof,Nick,Pass,IDMaterie,Ultima_Logare FROM Profesori WHERE ID_Prof={0};", date_dgv["IDProfesor", e.RowIndex].Value);
                            MyData.execSql(sql);
                            sql = string.Format("DELETE IDMaterie,IDProfesor,Nume,Prenume,IDTesteAdaugate FROM Materii WHERE IDProfesor={0};", date_dgv["IDProfesor", e.RowIndex].Value);
                            MyData.execSql(sql);
                            string id_nou = string.Empty;
                            string[] new_idprofi = selectMaterii[0].Split(',');
                            for (int i = 0; i < new_idprofi.Length; i++)
                            {
                                if (new_idprofi[i] != date_dgv["IDProfesor", e.RowIndex].Value.ToString())
                                {
                                    //daca nu e egal cu id-ul profului nostru pe care il stergem ii dam add in noul string
                                    if (id_nou == string.Empty)
                                    {
                                        id_nou = new_idprofi[i];
                                    }
                                    else
                                    {
                                        id_nou += "," + new_idprofi[i];
                                    }
                                }
                            }
                            sql = string.Format("UPDATE TabelMaterii SET ID_Profesori='{0}' WHERE ID_Materie={1};", id_nou, id_materie);
                            MyData.execSql(sql);
                            sql = string.Format("DELETE ID_Student,ID_Prof,Materie,ID_Test,Nume_fisier,Nota,Nota_finala,Promovat,Promovat_Anul FROM Teste_Materii WHERE ID_Prof={0};", date_dgv["IDProfesor", e.RowIndex].Value);
                            MyData.execSql(sql);
                            //TODO:delete index from grades too
                            sql = string.Format("SELECT Materii_inscris,Id_Profesor,ID_Student FROM Grades WHERE Id_Profesor LIKE '%{0}%';", date_dgv["IDProfesor", e.RowIndex].Value);
                            DataTable dt = MyData.readTable(sql);
                            string[] broken,materii_index;
                            id_nou = string.Empty;
                            string materii_noi = string.Empty;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                broken = dt.Rows[i][1].ToString().Split(',');
                                materii_index = dt.Rows[i][0].ToString().Split(',');
                                id_nou = materii_noi = string.Empty;
                                for (int j = 0; j < broken.Length; j++)
                                {
                                    if (Convert.ToInt32(materii_index[j]) != id_materie)
                                    {
                                        //rewrite it
                                        if (materii_noi == string.Empty)
                                        {
                                            materii_noi = materii_index[j];
                                        }
                                        else
                                        {
                                            materii_noi += "," + materii_index[j];
                                        }
                                    }
                                    if (Convert.ToInt32(broken[j]) != Convert.ToInt32(date_dgv["IDProfesor", e.RowIndex].Value))
                                    {
                                        //rewrite it without current ID
                                        if (id_nou == string.Empty)
                                        {
                                            id_nou = broken[j];
                                        }
                                        else
                                        {
                                            id_nou += "," + broken[j];
                                        }
                                    }
                                }
                                sql = string.Format("UPDATE Grades SET Materii_inscris='{0}' , ID_Profesor='{1}' WHERE ID_Profesor LIKE '%{2}%' AND ID_Student={3};", materii_noi, id_nou, date_dgv["IDProfesor", e.RowIndex].Value,dt.Rows[i][2]); //add user ID
                                MyData.execSql(sql);
                                string path = string.Format($"teste/{modifica_dgv["Materie", e.RowIndex].Value.ToString()}/{modifica_dgv["Nume", e.RowIndex].Value.ToString()}_{modifica_dgv["Prenume", e.RowIndex].Value.ToString()}");
                                if (Directory.Exists(path))
                                {
                                    Directory.Delete(path,true);
                                }
                            }
                        }
                        else
                        {
                            sql = string.Format("DELETE ID_Student,Nick,Parola,Ultima_logare FROM Studenti WHERE ID_Student={0};", date_dgv["ID_Student", e.RowIndex].Value);
                            MyData.execSql(sql);
                            sql = string.Format("DELETE ID_Student,Nume,Prenume,Materii_inscris FROM Grades WHERE ID_Student={0};", date_dgv["ID_Student", e.RowIndex].Value);
                            MyData.execSql(sql);
                            sql = string.Format("DELETE ID_Student,ID_Prof,Materie,ID_Test,Nume_fisier,Nota,Nota_finala,Promovat,Promovat_Anul FROM Teste_Materii WHERE ID_Student={0};", date_dgv["ID_Student", e.RowIndex].Value);
                            MyData.execSql(sql);
                        }
                        //mesaj
                        mesaj = string.Format("{0} {1} {2} a fost sters din baza de date !", lista_modifica.SelectedIndex == 0 ? "Profesorul" : "Studentul", date_dgv["Nume", e.RowIndex].Value.ToString(), date_dgv["Prenume", e.RowIndex].Value.ToString());
                        MessageBox.Show(mesaj, "Camp sters !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //recreate table
                        CreateTable(1);
                        break;
                    case DialogResult.No:
                        //nu se intampla nimic
                        break;
                }
            }
        }

        private void modifica_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //ne asiguram ca nu e goala
            if (!(modifica_dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) || !(modifica_dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
            {
                if (string.IsNullOrEmpty(modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString()))
                {
                    MessageBox.Show("Nu poti avea empty data in nici o celula.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                    return;
                }
            }
            //updateaza baza de date cand o celula e editata
            string updateSql = string.Empty;
            if (lista_modifica.SelectedItem.ToString() == lista_modifica.Items[0].ToString())
            {
                //pt profesori alt switch alte coloane
                switch (Convert.ToInt32(e.ColumnIndex))
                {
                    case 1: //nume
                        if (CreateAccount.NumeAlreadyExisted(modifica_dgv["Nume", e.RowIndex].Value.ToString(), modifica_dgv["Prenume", e.RowIndex].Value.ToString()))
                        {
                            MessageBox.Show("Acel nume si prenume exista deja in baza de date.Poti avea doar un cont cu acealsi nume.", "Nume existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Materii SET Nume='{0}' WHERE IDProfesor={1};", modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), modifica_dgv[0, e.RowIndex].Value);
                        MyData.execSql(updateSql);
                        break;
                    case 2: //prenume
                        if (CreateAccount.NumeAlreadyExisted(modifica_dgv["Nume", e.RowIndex].Value.ToString(), modifica_dgv["Prenume", e.RowIndex].Value.ToString()))
                        {
                            MessageBox.Show("Acel nume si prenume exista deja in baza de date.Poti avea doar un cont cu acealsi nume.", "Prenume existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Materii SET Nume='{0}' WHERE IDProfesor={1};", modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), modifica_dgv[0, e.RowIndex].Value);
                        MyData.execSql(updateSql);
                        break;
                      
                    case 3: //nick
                        if (CreateAccount.NickAlreadyExisted(modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString()) || modifica_dgv[e.ColumnIndex, e.RowIndex].Equals(Main_form.director_acc[0]))
                        {
                            MessageBox.Show("Nickname deja folosit,alege altul.", "Nick folosit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Profesori SET Nick='{0}' WHERE ID_Prof={1};", modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), modifica_dgv[0, e.RowIndex].Value);
                        MyData.execSql(updateSql);
                        break;
                    case 4: //pass
                        if (modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString().Length < 6)
                        {
                            MessageBox.Show("Parola ta trebuie sa aiba cel putin 6 caractere.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Profesori SET Pass='{0}' WHERE ID_Prof={1};", modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), modifica_dgv[0, e.RowIndex].Value);
                        MyData.execSql(updateSql);
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(e.ColumnIndex))
                {
                    case 1: //nume
                        if (CreateAccount.NumeAlreadyExisted(modifica_dgv["Nume", e.RowIndex].Value.ToString(), modifica_dgv["Prenume", e.RowIndex].Value.ToString()))
                        {
                            MessageBox.Show("Acel nume si prenume exista deja in baza de date.Poti avea doar un cont cu acealsi nume.", "Nume existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Grades SET Nume='{0}' WHERE ID_Student={1};",modifica_dgv[e.ColumnIndex,e.RowIndex].Value.ToString(),modifica_dgv[0,e.RowIndex].Value);
                        break;
                    case 2: //prenume
                        if (CreateAccount.NumeAlreadyExisted(modifica_dgv["Nume", e.RowIndex].Value.ToString(), modifica_dgv["Prenume", e.RowIndex].Value.ToString()))
                        {
                            MessageBox.Show("Acel nume si prenume exista deja in baza de date.Poti avea doar un cont cu acealsi nume.","Prenume existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Grades SET Prenume='{0}' WHERE ID_Student={1};", modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), modifica_dgv[0, e.RowIndex].Value);
                        break;
                    case 3: //nick
                        if(CreateAccount.NickAlreadyExisted(modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString()) || modifica_dgv[e.ColumnIndex,e.RowIndex].Equals(Main_form.director_acc[0]))
                        {
                            MessageBox.Show("Nickname deja folosit,alege altul.", "Nick folosit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Studenti SET Nick='{0}' WHERE ID_Student={1};", modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), modifica_dgv[0, e.RowIndex].Value);
                        break;
                    case 4: //pass
                        //verificari pt parola
                        if(modifica_dgv[e.ColumnIndex,e.RowIndex].Value.ToString().Length < 6 )
                        {
                            MessageBox.Show("Parola ta trebuie sa aiba cel putin 6 caractere.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            modifica_dgv[e.ColumnIndex,e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Studenti SET Parola='{0}' WHERE ID_Student={1};", modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), modifica_dgv[0, e.RowIndex].Value); 
                        break;
                    case 5: //materii la care e inscris
                        //updateSql = string.Format("SELECT Materii_inscris FROM Grades WHERE ID_STUDENT='{0}';");
                        //string materii = MyData.stringSelector(updateSql,"Materii_inscris");
                        //string[] split_materii = materii.Split(',');
                        //if (split_materii.Length >= 3)
                        string[] myS = modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString().Split(',');
                        if(!checkForType(myS))
                        {
                            MessageBox.Show("Date introduse gresit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        if (myS.Length > 3 || verifyNoDub(myS))
                        {
                            MessageBox.Show("Elevul se poate inscrie maximum la 3 materii o singura data.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            modifica_dgv[e.ColumnIndex, e.RowIndex].Value = old_data;
                            return;
                        }
                        updateSql = string.Format("UPDATE Grades SET Materii_inscris='{0}' WHERE ID_Student={1};", modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), modifica_dgv[0, e.RowIndex].Value);
                        break;
                }
                MyData.execSql(updateSql);
            }
        }

        public static bool verifyNoDub(string[] str)
        {
            bool has_db = false;
            int index_max = MyData.takeMax("TabelMaterii", "ID_Materie");
            for (int i = 0; i < str.Length;i++)
            {
                for(int j = i+1;j < str.Length-1;j++)
                {
                    if(str[i] == str[j])
                    {
                        has_db = true;
                        break;
                    }
                }
            }
            for(int i = 0; i < str.Length;i++)
            {
                if(Convert.ToInt32(str[i]) > index_max)
                {
                    has_db = true;
                    break;
                }
            }
            return has_db;
        }

        public bool checkForType(string[] yeah)
        {
            bool is_int = true;int val;
            for (int i = 0; i < yeah.Length; i++)
            {
                if (!(Int32.TryParse(yeah[i], out val)))
                {
                    is_int = false;
                    break;
                }
            }
            return is_int;
        }

        private void modifica_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && !opened)
            {
                if (modifica_dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    frame = new ViewFrame();
                    if ((frame.has_students(modifica_dgv[0, e.RowIndex].Value.ToString()) && lista_modifica.SelectedItem.ToString() == lista_modifica.Items[0].ToString()) 
                       || lista_modifica.SelectedItem.ToString() != lista_modifica.Items[0].ToString() && !string.IsNullOrEmpty(modifica_dgv["ID_Materii", e.RowIndex].Value.ToString()))
                    {
                        if (lista_modifica.SelectedItem.ToString() != lista_modifica.Items[0].ToString())
                        {
                            //show formul cu testele pe care le-a dat elevul, si cu notele sale.
                            frame.type = 0;
                            frame.data[2] = modifica_dgv[0, e.RowIndex].Value.ToString();
                        }
                        else if (lista_modifica.SelectedItem.ToString() == lista_modifica.Items[0].ToString())
                        {
                            //pt profesori deschidem acelasi formular numai ca mai diferit.
                            frame.type = 1; 
                            frame.data[2] = modifica_dgv["lst_materii", e.RowIndex].Value.ToString();
                            frame.data[3] = modifica_dgv[0, e.RowIndex].Value.ToString();
                        }
                        opened = true;
                        frame.Width = 502;
                        frame.Height = 481;
                        frame.data[0] = modifica_dgv["Nume", e.RowIndex].Value.ToString();
                        frame.data[1] = modifica_dgv["Prenume", e.RowIndex].Value.ToString();
                        frame.Show();
                    }
                }
            }
        }

        //save old data for checking things..
        private void modifica_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (save_id != Convert.ToInt32(modifica_dgv[0, e.RowIndex].Value) && lista_modifica.SelectedItem.ToString() == lista_modifica.Items[0].ToString())
                {
                    save_id = Convert.ToInt32(modifica_dgv[0, e.RowIndex].Value);
                }
                if(!(modifica_dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) || !(modifica_dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
                    return;

                if (!string.IsNullOrEmpty(modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString()))
                {
                    old_data = modifica_dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
                }
            }
        }

        private void modifica_dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(lista_modifica.SelectedItem.ToString() != lista_modifica.Items[0].ToString())
            {
                return;
            }
            if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            {
                ComboBox comboBox = (ComboBox)e.Control;
                if (comboBox != null)
                {
                    save_comboBox = comboBox.SelectedIndex + 1;
                    comboBox.MouseDown -= new MouseEventHandler(m_ComboBoxColumn_MouseDown);
                    comboBox.MouseDown += new MouseEventHandler(m_ComboBoxColumn_MouseDown);
                    comboBox.SelectedIndexChanged -= new EventHandler(m_ComboBoxColumn_SelectedIndexChanged);
                    comboBox.SelectedIndexChanged += new EventHandler(m_ComboBoxColumn_SelectedIndexChanged);
                }
            }
        }

        public void m_ComboBoxColumn_MouseDown(object sender,MouseEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            save_comboBox = cmb.SelectedIndex+1;
        }

        private void modifica_dgv_Sorted(object sender, EventArgs e)
        {
            if (lista_modifica.SelectedItem.ToString() == lista_modifica.Items[0].ToString())
            {
                string sqlmodifica = string.Format("SELECT Materii.IDProfesor,Materii.Nume,Materii.Prenume,TabelMaterii.Nume_Materie,Profesori.Nick,Profesori.Pass FROM Materii,TabelMaterii,Profesori WHERE Profesori.IDMaterie=TabelMaterii.ID_Materie AND Profesori.ID_Prof=Materii.IDProfesor;");
                table = MyData.readTable(sqlmodifica);
                for (int i = 0; i < modifica_dgv.RowCount; i++)
                {
                    modifica_dgv["lst_materii", i].Value = table.Rows[i]["Nume_Materie"];
                }
            }
        }

        private void m_ComboBoxColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if((save_comboBox-1) == comboBox.SelectedIndex)
            {
                return;
            }
            if (comboBox.Text != null)
            {
                int index = comboBox.SelectedIndex+1;
                string updateSql = string.Empty;
                //Iau datele din TabelMaterii, verific daca exista userul la id-ul materiei respective folosind like dupa sterg din string id-ul si il adaug la indexul nou creat
                //exista id-ul returnam id-urile profesorilor.
                updateSql = string.Format("SELECT ID_Profesori FROM TabelMaterii WHERE ID_Materie={0};",save_comboBox);
                string myIds = MyData.stringSelector(updateSql, "ID_Profesori");
                string new_ids = string.Empty;
                if (!(string.IsNullOrEmpty(myIds)))
                {
                    string[] breaked_ids = myIds.Split(',');
                    if (breaked_ids.Length > 0)
                    {
                        for (int i = 0; i < breaked_ids.Length; i++)
                        {
                            int id = Convert.ToInt32(breaked_ids[i]);
                            if (id != save_id)
                            {
                                if (new_ids == string.Empty)
                                {
                                    new_ids = breaked_ids[i] + ",";
                                }
                                else
                                {
                                    new_ids += breaked_ids[i] + ",";
                                }
                            }
                        }
                        if (new_ids.Length > 0)
                        {
                            new_ids = new_ids.Remove(new_ids.Length - 1);
                        }
                    }
                }
                //update tabelul pt a sterge id-ul profesorului de la materia respectiva
                updateSql = string.Format("UPDATE TabelMaterii SET ID_Profesori='{0}' WHERE ID_Materie={1};",new_ids, save_comboBox);
                MyData.execSql(updateSql);
                //adaugam id-ul in materia noua
                updateSql = string.Format("SELECT ID_Profesori FROM TabelMaterii WHERE ID_Materie={0};",index);
                myIds = MyData.stringSelector(updateSql, "ID_Profesori");
                myIds = myIds.Length > 0 ? $"{myIds},{save_id}" : save_id.ToString();
                updateSql = string.Format("UPDATE TabelMaterii SET ID_Profesori='{0}' WHERE ID_Materie={1};", myIds,index);
                MyData.execSql(updateSql);
                //update db
                updateSql = string.Format("UPDATE Profesori SET IDMaterie={0} WHERE ID_Prof={1};",index,save_id);
                MyData.execSql(updateSql);
                //stergem toate testele date inainte pentru a preveni anumite probleme
                //TODO:stergem toate testele pe care le-a pus la aceea materie si resetam indexurile testelor
                updateSql = string.Format("DELETE ID_Student,ID_Prof,Materie,ID_Test,Nume_fisier,Nota,Nota_finala,Promovat,Promovat_Anul FROM Teste_Materii WHERE ID_Prof={0};",save_id);
                MyData.execSql(updateSql);
                //materii and grades modifica
                updateSql = string.Format("UPDATE Materii SET IDMaterie={0} WHERE IDProfesor={1};", index, save_id);
                MyData.execSql(updateSql);
                updateSql = string.Format("UPDATE Materii SET IDTesteAdaugate='' AND Numar_studenti='' WHERE IDProfesor={0};", save_id);
                MyData.execSql(updateSql);
                //grades
                updateSql = string.Format("SELECT Materii_inscris,Id_Profesor,ID_Student FROM Grades WHERE Id_Profesor LIKE '%{0}%';",save_id);
                DataTable dt = MyData.readTable(updateSql);
                string[] broken, materii_index;
                string id_nou = string.Empty;
                string materii_noi = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    broken = dt.Rows[i][1].ToString().Split(',');
                    materii_index = dt.Rows[i][0].ToString().Split(',');
                    id_nou = materii_noi = string.Empty;
                    for (int j = 0; j < broken.Length; j++)
                    {
                        if (Convert.ToInt32(materii_index[j]) != index)
                        {
                            //rewrite it
                            if (materii_noi == string.Empty)
                            {
                                materii_noi = materii_index[j];
                            }
                            else
                            {
                                materii_noi += "," + materii_index[j];
                            }
                        }
                        if (Convert.ToInt32(broken[j]) != save_id)
                        {
                            //rewrite it without current ID
                            if (id_nou == string.Empty)
                            {
                                id_nou = broken[j];
                            }
                            else
                            {
                                id_nou += "," + broken[j];
                            }
                        }
                    }
                    updateSql = string.Format("UPDATE Grades SET Materii_inscris='{0}' , ID_Profesor='{1}' WHERE ID_Profesor LIKE '%{2}%' AND ID_Student={3};", materii_noi, id_nou,save_id, dt.Rows[i][2]); //add user ID
                    MyData.execSql(updateSql);
                }
                //delete directory file
                //teste/<nume materie>/<nume profesor>
                string[] date = MyData.getData("Materii", new string[] { "Nume", "Prenume" },"IDProfesor", save_id);
                string path = string.Format($"teste/{comboBox.SelectedItem.ToString()}/{date[0]}_{date[1]}");
                if (Directory.Exists(path))
                {
                    Directory.Delete(path,true);
                }
            }
            comboBox.SelectedIndexChanged -= new EventHandler(m_ComboBoxColumn_SelectedIndexChanged);
            btn_modifica.Focus();
            if (once)
            {
                btn_modifica.PerformClick();
                once = false;
            }
            modifica_dgv.Refresh();
        }

        private void pass_txt_Leave(object sender, EventArgs e)
        {
            if(pass_txt.Text.Length < 6)
            {
                MessageBox.Show("Parola trebuie sa aiba cel putin 6 caractere.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pass_txt.Text = string.Empty;
                pass_txt.Focus();
            }
        }
    }
}