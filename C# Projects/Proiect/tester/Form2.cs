using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace tester
{
    public partial class test_form : Form
    {
        public string TestName { get; set; }
        public test_form()
        {
            InitializeComponent();
        }
        List<Quiz> intrebari = new List<Quiz>();
        string[,] raspunsuri_user;
        int current_question = 0;
        int[] answers = new int[4];
        string[] answerss = new string[4];
        public static int punctaj_user = 0;
        bool last_question = false;
        int[] timp = new int[3]; int initial_time = 0;
        public static bool test_on = false;
        public static bool reset_menu = false;
        bool closeOnce = false;

        public void SetQuestionNr()
        {
            int real_question_nr = Convert.ToInt32(current_question) + 1;
            nr_lbl.Text = $"Intrebarea : {real_question_nr} / {intrebari.Count}";
        }

        public void getQuiz()
        {
            FileStream fs = new FileStream(TestName, FileMode.Open, FileAccess.Read);
            string len = null;
            int count = 0;
            string[] linii = File.ReadAllLines(TestName);
            bool have_time = false;
            if(linii[linii.Length-1].Split(';').Length == 2)
            {
                have_time = true;
            }
            using (StreamReader reader = new StreamReader(fs))
            {
                if(have_time && count == linii.Length - 1)
                {
                    count = count + 1;
                }
                while ((len = reader.ReadLine()) != null && count < linii.Length-1)
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
                        //string intrebare = splitedQuestion[0];
                        //string r1 = splitedQuestion[1];
                        //string r2 = splitedQuestion[2];
                        //string r3 = splitedQuestion[3];
                        //string r4 = splitedQuestion[4];
                        //string rcorrect = splitedQuestion[5];
                        //string pct = splitedQuestion[6];
                        //string tip = splitedQuestion[7];
                        intrebari.Add(new Quiz { Question = splitedQuestion[0], Answer1 = splitedQuestion[1], Answer2 = splitedQuestion[2], Answer3 = splitedQuestion[3], Answer4 = splitedQuestion[4], CorectAnswer = splitedQuestion[5], Points = Convert.ToInt32(splitedQuestion[6]), Type = Convert.ToInt32(splitedQuestion[7]) });
                    }
                    count++;
                }
            }
            initial_time = timp[0];
            raspunsuri_user = new string[intrebari.Count + 1, 2];
        }
        
        public void StartQuiz()
        {
            closeOnce = false;
            reset_menu = false;
            current_question = 0;
            prev_btn.Visible = false;
            rez_panel.Visible = false;
            last_question = false;
            test_on = true;
            getQuiz();
            AddQuestion();
        }

        private void test_form_Load(object sender, EventArgs e)
        {
            this.Text = TestName;
            StartQuiz();
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
                        checkboxType.Location = new System.Drawing.Point(33, sum);
                        checkboxType.Name = "check1Box1" + i;
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
                        radioType.Location = new System.Drawing.Point(33, sum);
                        radioType.Name = "radio" + i;
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
                raspunsuri_user[current_question, 0] = string.Format($"{answers[0]},{answers[1]},{answers[2]},{answers[3]}");
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
                DialogResult = MessageBox.Show("Sunteţi sigur ca doriţi sa încheiaţi testul?", "Încheiere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (DialogResult)
                {
                    case DialogResult.Yes:
                        if (CheckIfAllQuestionsHaveAnswer())
                        {
                            MessageBox.Show("Trebuie sa raspunzi la toate intrebarile pentru a da finalizare.", "Atentionare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
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
                if ((!(string.IsNullOrEmpty(raspunsuri_user[current_question, 1])) && intrebari[current_question].Type == 1)
                || (!(string.IsNullOrEmpty(raspunsuri_user[current_question, 0])) && intrebari[current_question].Type == 0))
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
            if ((!(string.IsNullOrEmpty(raspunsuri_user[current_question, 1])) && intrebari[current_question].Type == 1)
            || (!(string.IsNullOrEmpty(raspunsuri_user[current_question, 0])) && intrebari[current_question].Type == 0))
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
        public bool CheckIfAllQuestionsHaveAnswer()
        {
            bool notAnswered = false;
            for(int i = 0; i < answerss.Length;i++)
            {
                string raspuns = raspunsuri_user[i, 1];
                if ((string.IsNullOrEmpty(raspunsuri_user[i, 1]) && intrebari[i].Type == 1)
                || (string.IsNullOrEmpty(raspunsuri_user[i, 0]) && intrebari[i].Type == 0))
                { 
                    notAnswered = true;
                    break;
                }
            }
            return notAnswered;
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
                else if (intrebari[i].Type == 1 && !(string.IsNullOrEmpty(raspunsuri_user[i, 1])))
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
            for (int i = 0; i < radio_pnl.Controls.Count; i++)
            {
                radio_pnl.Controls[i].Dispose();
                i--;
            }
            AddQuestion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timp[0] <= initial_time / 3 && timp_lbl.ForeColor != System.Drawing.Color.Red)
            {
                timp_lbl.ForeColor = System.Drawing.Color.Red;
            }
            timp[2]--;
            timp_lbl.Text = $"{timp[0]} min {timp[1]} sec";
            if (timp[2] <= 0)
            {
                timp[1]--;
                timp[2] = 60;
                if (timp[1] <= 0)
                {
                    timp[0]--;
                    timp[1] = 60;
                    if (timp[0] < 0)
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
            promovat_txt.ForeColor = punctaj_user < count ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            promovat_txt.Text = punctaj_user < count ? $"{punctaj_user} puncte\nDin păcate aţi picat testul." : $"{punctaj_user} puncte\nFelicitari , aţi promovat testul.";
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

        public void ShowMain()
        {
            string[] linii = File.ReadAllLines(TestName);
            string puncte_timp = string.Format($"{timp[0]},{timp[1]},{timp[2]};{punctaj_user}");
            if (linii[linii.Length - 1].Split(';').Length == 2)
            {
                linii[linii.Length - 1] = puncte_timp;
            }
            else
            {
                linii[linii.Length - 1] = linii[linii.Length - 1] + Environment.NewLine + puncte_timp;
            }
            File.WriteAllLines(TestName, linii);
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void test_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (test_on)
            {
                MessageBox.Show("Nu puteţi ieşii din test fără a răspunde la toate întrebările", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                if(!reset_menu && !closeOnce)
                {
                    closeOnce = true;
                    ShowMain();
                }
            }
        }

        class Quiz
        {
            public string Question { get; set; }
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public string Answer4 { get; set; }
            public string CorectAnswer { get; set; }
            public int Points { get; set; }
            public int Type { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
              reset_menu = true;
              ShowMain();
        }

        private void promovat_txt_Click(object sender, EventArgs e)
        {

        }

        private void rez_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}