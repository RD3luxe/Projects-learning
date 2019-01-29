using System;
using System.Windows.Forms;
using System.IO;

namespace OTI2012
{
    public partial class TestEditor : Form
    {
        public ViewFrame link { get; set; }
        public int track_question = 0;
        public int max_questions = 0;
        private string numeFile = string.Empty, old_value = string.Empty;

        public TestEditor(string fileName)
        {
            InitializeComponent();
            track_question = 0;
            max_questions = countQuestions(fileName);
            LoadData(fileName,track_question);
            back_btn.Visible = false;
            if (max_questions <= 1)
            {
                next_btn.Visible = false;
            }
            numeFile = fileName;
        }

        //SYSTEM.IO STUFF
        public int countQuestions(string file)
        {
            int count = -1;
            if(File.Exists(file))
            {
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                using(StreamReader reader = new StreamReader(fs))
                {
                    while(reader.ReadLine() != null)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void SaveData(string file, int questionNumber, string newData)
        {
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                lines[questionNumber] = newData;
                File.WriteAllLines(file, lines);
            }
        }

        public void LoadData(string file,int questionNumber)
        {
            if (File.Exists(file))
            {
                question_lbl.Text = $"Intrebarea {(questionNumber+1)}/{max_questions}";
                string len = null;
                int count = 0;
                FileStream fs;
                fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!string.IsNullOrEmpty(len = sr.ReadLine()))
                    {
                        if (count == 0)
                        {
                            //punem in timp daca e prima intrebare.
                            timp_txt.Text = len;
                        }
                        else if (count == (questionNumber+1))
                        {
                            //punem intrebarea,raspunsuri si raspunsuri corecte
                            string[] take_data = len.Split(';');
                            question_txt.Text = take_data[0];
                            answers_txt.Text = $"{take_data[1]} {take_data[2]} {take_data[3]} {take_data[4]}";
                            canswers_txt.Text = take_data[5];
                            pct_txt.Text = take_data[6];
                            InitListBox(Convert.ToInt32(take_data[7]));
                            break;
                        }
                        count++;
                    }
                }
            }
            else
            {
                MessageBox.Show("File not found");
                return;
            }
        }

        public void DeleteQuestion(string file, int line)
        {
            if(File.Exists(file))
            {
                int j = 0;
                string[] lines = File.ReadAllLines(file);
                string[] lines_corrected = new string[lines.Length - 1];
                for(int i = 0; i < lines.Length;i++)
                {
                    if(i != line)
                    {
                        lines_corrected[j] = lines[i];
                        j++;
                    }
                }
                File.WriteAllLines(file, lines_corrected);
            }
        }

        public void InitListBox(int index)
        {
            if (tip_cmb.Items.Count == 0)
            {
                tip_cmb.Items.Add("Raspunsuri multiple");    //0
                tip_cmb.Items.Add("Raspuns unic");           //1
            }
            tip_cmb.SelectedIndex = index;
        }

        //textbox 
        private void timp_txt_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(timp_txt.Text))
            {
                MessageBox.Show("Nu poti lasa empty aceasta casuta.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timp_txt.Text = old_value;
                return;
            }
        }

        private void canswers_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(canswers_txt.Text))
            {
                MessageBox.Show("Nu poti lasa empty aceasta casuta.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                canswers_txt.Text = old_value;
                return;
            }
            if(!ValidateType(1))
            {
                MessageBox.Show($"Raspunsul corect curent nu exista in raspunsurile date, intrebarea nu poate fii salvata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public bool ValidateType(int usuage)
        {
            string[] answers = answers_txt.Text.Split(' ');
            bool exist = false;//consideram ca nu exista
            if (tip_cmb.SelectedIndex == 0)
            {
                string[] cutAnswers = canswers_txt.Text.Split(',');
                //daca sunt mai multe raspunsri corecte decat raspunsri date nu e valid 
                if (cutAnswers.Length > answers.Length)
                {
                    MessageBox.Show("Nu poti avea mai multe raspunsuri corecte decat raspunsuri existente.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(usuage == 1)
                        canswers_txt.Text = old_value;
                    return false;
                }
                for (int i = 0; i < cutAnswers.Length; i++)
                {
                    //comparam raspunsul corect cu toate rasspunsurile
                    exist = false; //resetam variabila pentru fiecare raspuns 
                    for (int j = 0; j < answers.Length; j++)
                    {
                        //daca raspunsul corect nu e prin raspunsuri atunci nu e valid
                        if (cutAnswers[i] == answers[j])
                        {
                            //exista => variabila devine true;
                            exist = true;
                        }
                    }
                    //verificam dupa ce iesim din al 2-lea loop daca variabila e false, daca e inca false afisam mesaj de eroare si resetam textbox-ul 
                    if (!exist)
                    {
                        if (usuage == 1)
                            canswers_txt.Text = old_value;
                    }
                }
            }
            else if (tip_cmb.SelectedIndex == 1)
            {
                for (int i = 0; i < answers.Length; i++)
                {
                    if (canswers_txt.Text.Equals(answers[i]))
                    {
                        exist = true;
                    }
                }
                if (!exist)
                {
                    if (usuage == 1)
                        canswers_txt.Text = old_value;
                }
            }
            return exist;
        }

        private void question_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(question_txt.Text))
            {
                MessageBox.Show("Nu poti lasa empty aceasta casuta.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                question_txt.Text = old_value;
                return;
            }
        }

        private void answers_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(answers_txt.Text))
            {
                MessageBox.Show("Nu poti lasa empty aceasta casuta.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                answers_txt.Text = old_value;
                return;
            }
        }

        private void pct_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pct_txt.Text))
            {
                MessageBox.Show("Nu poti lasa empty aceasta casuta.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pct_txt.Text = old_value;
                return;
            }
            int result;
            if (!(Int32.TryParse(pct_txt.Text, out result)))
            {
                MessageBox.Show("Trebuie sa pui un numar.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pct_txt.Text = old_value;
                return;
            }
            int total_points = 10 - result;
            if (result < 0 || result > total_points)
            {
                MessageBox.Show("Trebuie sa pui un numar pozitiv si sa nu depaseasca punctajul maxim.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pct_txt.Text = old_value;
                return;
            }
        }

        //save old value here
        private void save_old(object sender,EventArgs e)
        {
            TextBox dat = (TextBox)sender;
            old_value = dat.Text;
        }

        //button area
        private void back_btn_Click(object sender, EventArgs e)
        {
            max_questions = countQuestions(numeFile);
            if (track_question - 1 <= 0 || max_questions == 1)
            {
                back_btn.Visible = false;
            }
            else
            {
                back_btn.Visible = true;
            }
            if (max_questions != 1)
            {
                next_btn.Visible = true;
                track_question--;
                LoadData(numeFile, track_question);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (max_questions - 1 <= 0)
            {
                MessageBox.Show("Nu poti lasa testul fara nici o intrebare.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //rewrite file without that line
            DeleteQuestion(numeFile,track_question+1);
            MessageBox.Show($"Intrebarea numarul {track_question+1} a fost stearsa cu succes.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData(numeFile, track_question);
            max_questions = countQuestions(numeFile);
            if (max_questions == track_question)
            {
                question_lbl.Text = $"Intrebarea {track_question}/{max_questions}";
                track_question = max_questions - 1;
                LoadData(numeFile, track_question);
            }
            else
            {
                question_lbl.Text = $"Intrebarea {(track_question + 1)}/{max_questions}";
            }
            if (max_questions == 1)
            {
                next_btn.Visible = false;
                back_btn.Visible = false;
            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            max_questions = countQuestions(numeFile);
            if (track_question+1 > max_questions-2 || max_questions == 1)
            {
                next_btn.Visible = false;
            }
            else
            {
                next_btn.Visible = true;
            }
            if (max_questions != 1)
            {
                back_btn.Visible = true;
                track_question++;
                LoadData(numeFile, track_question);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //string data;
            if (btn.Name == "saveTime_btn")
            {
                SaveData(numeFile, 0, timp_txt.Text);
                MessageBox.Show("Timpul a fost modificat cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //start all checking all exceptions//
                if (!ValidateType(0))
                {
                    MessageBox.Show("Raspunsul corect curent nu exista in raspunsurile date, intrebarea nu poate fii salvata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string[] spl = answers_txt.Text.Split(' ');
                string answ = string.Join(";",spl);
                string data = string.Format($"{question_txt.Text};{answ};{canswers_txt.Text};{pct_txt.Text};{tip_cmb.SelectedIndex}");
                SaveData(numeFile, track_question+1, data);
                MessageBox.Show("Intrebarea a fost modificata cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TestEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(link != null)
                link.editor_opened = false;
        }
    }
}