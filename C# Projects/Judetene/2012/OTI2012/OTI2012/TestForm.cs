using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OTI2012
{
    public partial class TestForm : Form
    {
        List<Quiz> intrebari = new List<Quiz>();
        string[,] raspunsuri_user;
        int current_question = 0;
        int[] answers = new int[4];
        string[] answerss = new string[4];
        public static int punctaj_user = 0;
        bool last_question = false;
        int[] timp = new int[3]; int initial_time = 0;
        public static bool test_on = false;
        public DataGridView prop { get; set; }
        public int IndexRow { get; set; }
        public StudentPanel reload { get; set; }

        public TestForm()
        {
            InitializeComponent();
        }

        public void SetQuestionNr()
        {
            int real_question_nr = Convert.ToInt32(current_question) + 1;
            nr_lbl.Text = $"Intrebarea : {real_question_nr} / {intrebari.Count}";
        }

        public void getQuiz()
        {
            if (File.Exists(StudentPanel.CurrentTest))
            {
                FileStream fs = new FileStream(StudentPanel.CurrentTest, FileMode.Open, FileAccess.Read);
                string len = null;
                int count = 0;
                using (StreamReader reader = new StreamReader(fs))
                {
                    while ((len = reader.ReadLine()) != null)
                    {
                        string[] splitedQuestion = len.Split(';');
                        if (count == 0)
                        {
                            timp[0] = Convert.ToInt32(splitedQuestion[0]);
                            timp[1] = Convert.ToInt32(splitedQuestion[1]);
                            timp[2] = Convert.ToInt32(splitedQuestion[2]);
                        }
                        else
                        {
                            intrebari.Add(new Quiz { Question = splitedQuestion[0], Answer1 = splitedQuestion[1], Answer2 = splitedQuestion[2], Answer3 = splitedQuestion[3], Answer4 = splitedQuestion[4], CorectAnswer = splitedQuestion[5], Points = Convert.ToInt32(splitedQuestion[6]), Type = Convert.ToInt32(splitedQuestion[7]) });
                        }
                        count++;
                    }
                }
                initial_time = timp[0];
                raspunsuri_user = new string[intrebari.Count + 1, 2];
            }
            else
            {
                MessageBox.Show("Se pare ca a aparut o eroare iar acel test a fost sters si nu poate fii accesat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            current_question = 0;
            prev_btn.Visible = false;
            rez_panel.Visible = false;
            last_question = false;
            test_on = true;
            getQuiz();
            AddQuestion();
        }

        public void AddQuestion()
        {
            int sum = 31;
            SetQuestionNr();
            question_txt.Text = intrebari[current_question].Question;
            answerss[0] = intrebari[current_question].Answer1;
            answerss[1] = intrebari[current_question].Answer2;
            answerss[2] = intrebari[current_question].Answer3;
            answerss[3] = intrebari[current_question].Answer4;
            switch (intrebari[current_question].Type)
            {
                case 0:
                    for (int i = 0; i < 4; i++)
                    {
                        CheckBox checkboxType = new CheckBox();
                        checkboxType.AutoSize = true;
                        checkboxType.Location = new System.Drawing.Point(33,sum);
                        checkboxType.Name = "check1Box1"+i;
                        checkboxType.TabIndex = i;
                        checkboxType.Size = new System.Drawing.Size(85, 17);
                        checkboxType.Text = answerss[i];
                        checkboxType.UseVisualStyleBackColor = true;
                        radio_pnl.Controls.Add(checkboxType);
                        sum += 35;
                    }
                    break;
                case 1:
                    for (int i = 0; i < 4; i++)
                    {
                        RadioButton radioType = new RadioButton();
                        radioType.AutoSize = true;
                        radioType.Location = new System.Drawing.Point(33,sum);
                        radioType.Name = "radio"+i;
                        radioType.TabIndex = i;
                        radioType.Size = new System.Drawing.Size(85, 17);
                        radioType.Text = answerss[i];
                        radioType.UseVisualStyleBackColor = true;
                        radio_pnl.Controls.Add(radioType);
                        sum += 35;
                    }
                    break;
            }
        }

        public void ReadAnswers()
        {
            if (intrebari[current_question].Type == 0)
            {
                foreach (Control c in radio_pnl.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox ck = (CheckBox)c;
                        string[] split_v = raspunsuri_user[current_question, 0].Split(',');
                        for (int i = 0; i < split_v.Length; i++)
                        {
                            if (ck.TabIndex == Convert.ToInt32(split_v[i]))
                            {
                                ck.Checked = true;
                            }
                        }
                    }
                }
            }
            else if (intrebari[current_question].Type == 1)
            {
                int indexed_answer = Convert.ToInt32(raspunsuri_user[current_question, 1]);
                foreach (Control c in radio_pnl.Controls)
                {
                    if (c is RadioButton)
                    {
                        RadioButton rb = (RadioButton)c;
                        if (rb.TabIndex == indexed_answer)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        public void SaveAnswers()
        {
            int index = 0;
            if (intrebari[current_question].Type == 0)
            {
                foreach (Control c in radio_pnl.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox ck = (CheckBox)c;
                        if (ck.Checked)
                        {
                            answers[index] = index;
                        }
                        else
                        {
                            answers[index] = -1;
                        }
                        index++;
                    }
                }
                raspunsuri_user[current_question,0] = string.Format($"{answers[0]},{answers[1]},{answers[2]},{answers[3]}");
            }
            else if (intrebari[current_question].Type == 1)
            {
                int index_ales = -1;
                foreach (Control c in radio_pnl.Controls)
                {
                    if (c is RadioButton)
                    {
                        RadioButton rb = (RadioButton)c;
                        if (rb.Checked)
                        {
                            index_ales = index;
                            break;
                        }
                        index++;
                    }
                }
                if (index_ales == -1)
                {
                    raspunsuri_user[current_question, 1] = string.Empty;
                }
                else
                {
                    raspunsuri_user[current_question, 1] = index.ToString();
                }
            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            SaveAnswers();
            if (last_question)
            {
                DialogResult = MessageBox.Show("Esti sigur ca vrei sa dai finalizare la test.", "Finalizare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (DialogResult)
                {
                    case DialogResult.Yes:
                        CalcPuncte();
                        TogglePanel(false);
                        CheckPromovation();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            if ((current_question + 2) >= intrebari.Count)
            {
                last_question = false;
                current_question = intrebari.Count - 1;
                next_btn.Text = "Finalizare";
            }
            else
            {
                current_question++;
                last_question = false;
            }
            if (!last_question)
            {
                SetQuestionNr();
                ReloadQuestions();
                prev_btn.Visible = true;
                if ((!(string.IsNullOrWhiteSpace(raspunsuri_user[current_question, 1])) && intrebari[current_question].Type == 1) 
                || (!(string.IsNullOrWhiteSpace(raspunsuri_user[current_question, 0])) && intrebari[current_question].Type == 0))
                {
                    ReadAnswers();
                }
            }
            if ((current_question + 2) > intrebari.Count)
            {
                last_question = true;
            }
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            SaveAnswers();
            current_question--;
            last_question = false;
            SetQuestionNr();
            ReloadQuestions();
            next_btn.Text = "Next";
            if ((!(string.IsNullOrWhiteSpace(raspunsuri_user[current_question, 1])) && intrebari[current_question].Type == 1) 
            || (!(string.IsNullOrWhiteSpace(raspunsuri_user[current_question, 0])) && intrebari[current_question].Type == 0))
            {
                ReadAnswers();
            }
            if (current_question == 0)
            {
                prev_btn.Visible = false;
            }
            else
            {
                prev_btn.Visible = true;
            }
        }

        public void CalcPuncte()
        {
            punctaj_user = 0;
            for (int i = 0; i < intrebari.Count; i++)
            {
                answerss[0] = intrebari[i].Answer1;
                answerss[1] = intrebari[i].Answer2;
                answerss[2] = intrebari[i].Answer3;
                answerss[3] = intrebari[i].Answer4;
                if (intrebari[i].Type == 0)
                {
                    string[] raspunsuri = raspunsuri_user[i, 0].Split(',');
                    if (intrebari[i].CorectAnswer.Contains(","))
                    {
                        int count_answers = 0;
                        string[] raspunsuri_corecte = intrebari[i].CorectAnswer.Split(',');
                        for (int j = 0; j < raspunsuri.Length; j++)
                        {
                            if (Convert.ToInt32(raspunsuri[j]) != -1)
                            {
                                for (int k = 0; k < raspunsuri_corecte.Length; k++)
                                {
                                    string raspuns_user = answerss[Convert.ToInt32(raspunsuri[j])];
                                    if (raspuns_user == raspunsuri_corecte[k])
                                    {
                                        count_answers++;
                                    }
                                }
                            }
                        }
                        if (count_answers == raspunsuri_corecte.Length)
                        {
                            punctaj_user += intrebari[i].Points;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < raspunsuri.Length; j++)
                        {
                            if (Convert.ToInt32(raspunsuri[j]) != -1)
                            {
                                string raspuns_user = answerss[Convert.ToInt32(raspunsuri[j])];
                                if (intrebari[i].CorectAnswer == raspuns_user)
                                {
                                    punctaj_user += intrebari[i].Points;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (intrebari[i].Type == 1 && !(string.IsNullOrWhiteSpace(raspunsuri_user[i, 1]))) 
                {
                    int ind = Convert.ToInt32(raspunsuri_user[i, 1]);
                    string correct = answerss[ind];
                    if (intrebari[i].CorectAnswer == correct)
                    {
                        punctaj_user += intrebari[i].Points;
                    }
                }
            }
        }

        public void ReloadQuestions()
        {
            for(int i = 0; i < radio_pnl.Controls.Count;i++)
            {
                radio_pnl.Controls[i].Dispose();
                i--;
            }
            AddQuestion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timp[0] <= initial_time/3 && timp_lbl.ForeColor != System.Drawing.Color.Red)
            {
                timp_lbl.ForeColor = System.Drawing.Color.Red;
            }
            timp[2]--;
            timp_lbl.Text = $"{timp[0]} min {timp[1]} sec";
            if (timp[2] <= 0)
            {
                timp[1]--;
                timp[2] = 60;
                if(timp[1] <= 0)
                {
                    timp[0]--;
                    timp[1] = 60;
                    if(timp[0] < 0)
                    {
                        timp[0] = timp[1] = timp[2] = 0;
                        timp_lbl.Text = $"{timp[0]} min {timp[1]} sec";
                        //show status form
                        CalcPuncte();
                        TogglePanel(false);
                        CheckPromovation();
                        timer1.Stop();
                    }
                }
            }
        }

        public void CheckPromovation()
        {
            test_on = false;
            rez_panel.Visible = true;
            int count = intrebari.Count / 2;
            promovat_txt.Text = punctaj_user < count+1 ? $"{punctaj_user} puncte\nImi pare rau ai picat testul.":$"{punctaj_user} puncte\nFelicitari , ai promovat testul.";
            promovat_txt.ForeColor = punctaj_user < count ? System.Drawing.Color.Red:System.Drawing.Color.LimeGreen;
            image_p.Image = punctaj_user < count ? System.Drawing.Image.FromFile("images/fail.jpg"):System.Drawing.Image.FromFile("images/promoted.png");
            //add in database all informations  
            string addSql = string.Format("UPDATE Teste_Materii SET Nota={0} WHERE ID_Student={1} AND Materie='{2}' AND ID_Test={3};", punctaj_user, Main_form.id_user, prop["Materie",IndexRow].Value.ToString(), prop[0, IndexRow].Value);
            MyData.execSql(addSql);
            reload.ReloadAll();
            prop.Refresh();
        }

        public void TogglePanel(bool value)
        {
            timp_lbl.Visible = value;
            nr_lbl.Visible = value;
            question_txt.Visible = value;
            prev_btn.Visible = value;
            next_btn.Visible = value;
            radio_pnl.Visible = value;
        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (test_on)
            {
                MessageBox.Show("Nu poti iesi din test daca nu ai dat finalizare.", "Informatii", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                StudentPanel.test_opened = false;
            }
        }
    }
}