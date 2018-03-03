using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace Spanzuratoare
{
    public partial class Spanzuratoarea : Form
    {
        public Point[,] human_coordonates = new Point[5, 2]
        {
            { new Point { X = 158, Y = 126 }, new Point { X = 120, Y = 178 }  }, //trunchi
            { new Point { X = 148, Y = 140 }, new Point { X = 143, Y = 179 }  }, //mana stanga
            { new Point { X = 149, Y = 137 }, new Point { X = 170, Y = 178 }  }, //mana dreapta
            { new Point { X = 119, Y = 178 }, new Point { X = 139, Y = 244 }  }, //picior stang
            { new Point { X = 119, Y = 176 }, new Point { X = 92, Y = 266  }  } //picior drept
        };
        public string location = string.Empty, nume_lista = string.Empty;
        public bool game_started = false, close_once = false;
        public static int[] timp = new int[3];            //timpul
        public static string[,] words = new string[200,4];//Intrebare , cuvant , litere ascunse , puncte pt cuvant
        public static int[] atribute_player = new int[5]; //puncte,incercari ramase,hinturi ramase,cuvantul curent,nr_max de cuvinte din lista.
        public int[] index_chars = new int[100];
        char[] cuvant,rupt;
        int[,] random_shop = new int[3,2];
        public SoundPlayer[] sounds = new SoundPlayer[4] 
        {
            new SoundPlayer("sound/corect.wav"),
            new SoundPlayer("sound/wrong.wav"),
            new SoundPlayer("sound/win.wav"),
            new SoundPlayer("sound/lose.wav")
        };
        int intial_time;

        public Spanzuratoarea()
        {
            InitializeComponent();
            game_started = false;
            cronometru.Enabled = false;
            startgamepnl.Visible = true;
            pnljoc.Visible = false;
            manager_pnl.Visible = false;
            victory_pnl.Visible = false;
            gameover_pnl.Visible = false;
            atribute_player[1] = 6;
            atribute_player[2] = 3;
        }

        private void add_word_Click(object sender, EventArgs e)
        {
            string correct_name = numelist_txt.Text + ".txt";
            word_txt.Text = word_txt.Text.ToUpper();
            if (numelist_txt.Text == string.Empty || time_txt.Text == string.Empty || question_txt.Text == string.Empty || word_txt.Text == string.Empty || litere_txt.Text == string.Empty || pct_txt.Text == string.Empty)
            {
                MessageBox.Show("Toate campurile trebuie completate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(!valideazaCamp(litere_txt.Text) || !valideazaCamp(pct_txt.Text))
            {
                MessageBox.Show("Punctele si numarul de litere ascunse trebuie sa fie numere.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(word_txt.Text.Length <= Convert.ToInt32(litere_txt.Text))
            {
                MessageBox.Show("Numarul de litere ascunse nu poate fii mai mare decat numarul literelor din cuvant.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                litere_txt.Text = word_txt.Text = "";
                return;
            }
            bool exista_data = false, exist_entry = false;
            string my_entry = string.Format("{0};{1};{2};{3}", question_txt.Text, word_txt.Text.ToUpper(), litere_txt.Text, pct_txt.Text);
            if (File.Exists(correct_name))
            {
                string line = null;
                FileStream fs = new FileStream(correct_name, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fs))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == time_txt.Text)
                        {
                            exista_data = true;
                        }
                        if (line == my_entry)
                        {
                            exist_entry = true;
                        }
                    }
                }
            }
            FileStream fs2 = new FileStream(correct_name, FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs2))
            {
                if (!exista_data) sw.WriteLine(time_txt.Text);
                if (!exist_entry) sw.WriteLine(my_entry);
            }
            if (exist_entry)
            {
                MessageBox.Show("Aceast cuvant exista deja in fisierul "+correct_name, "Cuvant existent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Cuvantul,intrebarea,punctele si literele ascunse au fost adaugate cu succes in fisierul " + correct_name + " .", "Cuvant adaugat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool valideazaCamp(string camp)
        {
            bool e_valid = false;
            int test;
            if (Int32.TryParse(camp, out test))
                e_valid = true;
            return e_valid;
        }

        private void use_hint_Click(object sender, EventArgs e)
        {
            if (atribute_player[2] == 0)
            {
                MessageBox.Show("Nu mai ai nici un hint pe care sa il poti folosi.", "Hinturi terminate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            atribute_player[2]--;
            status_user.Text = string.Format("Puncte : {0}               Incercari : {1} / 6         Hinturi : {2} / 3         Cuvantul : {3} / {4}", atribute_player[0], atribute_player[1], atribute_player[2], atribute_player[3], atribute_player[4]);
            cuvant = words[atribute_player[3] - 1, 1].ToCharArray();
            rupt = cuvant_lbl.Text.ToCharArray();
            Random rnd = new Random();
            int index = rnd.Next(words[atribute_player[3] - 1, 1].Length);
            if (rupt[index] != '_')
            {
                while(rupt[index] != '_')
                {
                    index = rnd.Next(words[atribute_player[3] - 1, 1].Length);
                }
            }
            for (int i = 0; i < cuvant.Length;i++)
            {
                if (cuvant[i] == cuvant[index] && index != i)
                {
                    rupt[i] = cuvant[index];
                }
            }
            rupt[index] = cuvant[index];
            cuvant_lbl.Text = new string(rupt);
            if (cuvant_lbl.Text.ToUpper() == words[atribute_player[3] - 1, 1].ToUpper())
            {
                player_win();
            }
        }

        private void alegeListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(game_started)
            {
                MessageBox.Show("Nu poti alege o lista de cuvinte in timp ce joci.", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Alege lista de cuvinte";
            opf.FileName = "";
            opf.DefaultExt = "*.txt";
            opf.Filter = "Text File(.txt) | *.txt";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(opf.FileName, FileMode.Open, FileAccess.Read);
                string len;
                int count_line = 0;
                nume_lista = opf.SafeFileName;
                using (StreamReader reader = new StreamReader(fs))
                {
                    while ((len = reader.ReadLine()) != null)
                    {
                        string[] split_line = len.Split(';');
                        for (int i = 0; i < split_line.Length; i++)
                        {
                            if (count_line == 0)
                            {
                                timp[i] = Convert.ToInt32(split_line[i]);
                            }
                            else
                            {
                                words[count_line-1,i] = split_line[i];
                            }
                        }
                        count_line++;
                    }
                }
                intial_time = timp[0];
                int length = Convert.ToInt32(words[0, 2]);
                int index = 0;
                char[] cuvant = words[0, 1].ToCharArray();
                char[] new_word = words[0, 1].ToCharArray();
                for (int i = 0; i < length; i++)
                {
                    Random rnd = new Random();
                    int random = rnd.Next(new_word.Length);
                    if (new_word[random] == '_')
                    {
                        length++;
                        continue;
                    }
                    for (int j = 0; j < cuvant.Length;j++)
                    {
                        if (cuvant[random] == cuvant[j])
                        {
                            new_word[j] = '_'; 
                        }
                    }
                    index_chars[index] = random;
                    index++;
                }
                cuvant_lbl.Text = new string(new_word);
                cate_litere.Text = "Cuvant din "+ new_word.Length.ToString()+ " litere.";
                atribute_player[3] = 1;
                atribute_player[4] = count_line-1;
                status_user.Text = string.Format("Puncte : {0}               Incercari : {1} / 6         Hinturi : {2} / 3         Cuvantul : {3} / {4}", atribute_player[0], atribute_player[1], atribute_player[2], atribute_player[3], atribute_player[4]);
                startgamepnl.Visible = true;
                victory_pnl.Visible = false;
                pnljoc.Visible = false;
                manager_pnl.Visible = false;
            }
        }

        private void Help_menu_Click(object sender, EventArgs e)
        {
            string helper = string.Format("1)Cum incep un joc ?\nAlegeti optiunea 'Alege lista' din Meniu dupa care apasati pe butonul Start Joc.\n2)Cum se joaca ?\nPe ecran va fii afisata o intrebare iar playerul trebuie sa ghiceasca cuvantul la care se refera acea intrebare .\nPlayerul poate folosi hinturile pentru a afisa o litera din cuvant.\nPentru a alege o litera dati click pe butonul cu litera dorita.\nFiecare intrebare are un numar diferit de puncte , dupa fiecare intrebare aveti posibilitatea de a cumpara un anumit obiect ce sa va ajute in continuare.\nLa sase litere gresite veti pierde jocul .Cand castigati punctele facute se vor salva intr-un fisier cu clasamentul punctelor.\nJocul incepe cu 3 hinturi,6 greseli maxime si 0 puncte.\nDistractie Placuta !");
            MessageBox.Show(helper,"Ajutor");
        }

        private void restartNivelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game_started)
            {
                cronometru.Enabled = false;
                DialogResult result = MessageBox.Show("Esti sigur ca vrei sa reincepi jocul ? \nNimic nu se va salva din ce ai facut in acest joc.", "Atentie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes:
                        game_started = false;
                        close_once = false;
                        cronometru.Enabled = false;
                        validchar_btn.Enabled = true;
                        use_hint.Enabled = true;
                        startgamepnl.Visible = true;
                        pnljoc.Visible = false;
                        manager_pnl.Visible = false;
                        gameover_pnl.Visible = false;
                        victory_pnl.Visible = false;
                        for (int i = 0; i < timp.Length; i++)
                        {
                            timp.SetValue(0,i);
                        }
                        atribute_player[1] = 6;
                        atribute_player[2] = 3;
                        atribute_player[0] = 0;
                        guess_wordtxt.Text = "";
                        nume_lista = string.Empty;
                        break;
                    case DialogResult.No:
                        cronometru.Enabled = true;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Jocul nu a inceput inca , nu poti sa il resetezi.", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void adaugaListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game_started)
            {
                cronometru.Enabled = false;
                MessageBox.Show("Nu poti adauga o lista de cuvinte in timp ce joci.", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cronometru.Enabled = true;
            }
            else
            {
                startgamepnl.Visible = false;
                pnljoc.Visible = false;
                gameover_pnl.Visible = false;
                victory_pnl.Visible = false;
                manager_pnl.Visible = true;
                adaugare_group.Visible = true;
                edit_group.Visible = false;
            }
        }

        private void modificaListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game_started)
            {
                cronometru.Enabled = false;
                MessageBox.Show("Nu poti modifica o lista de cuvinte in timp ce joci.", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cronometru.Enabled = true;
            }
            else
            {
                startgamepnl.Visible = false;
                pnljoc.Visible = false;
                gameover_pnl.Visible = false;
                victory_pnl.Visible = false;
                manager_pnl.Visible = true;
                adaugare_group.Visible = false;
                edit_group.Visible = true;
                edit_txt.Clear();
                location = string.Empty;
                textBox1.Text = string.Empty;
            }
        }

        private void cronometru_Tick(object sender, EventArgs e)
        {
            if (game_started)
            {
                if (timp[0] <= intial_time / 3 && timp_lbl.ForeColor != Color.Red)
                    timp_lbl.ForeColor = Color.Red;
                if (timp[0] < 0)
                {
                    timp[0] = timp[1] = timp[2] = 0;
                    cronometru.Enabled = false;
                    RunLose();
                    validchar_btn.Enabled = false;
                    use_hint.Enabled = false;
                }
                if (timp[0] > 0 || timp[1] >= 0 || timp[2] >= 0)
                {
                    timp[2]--;
                    if (timp[2] <= 0)
                    {
                        timp[1]--;
                        timp[2] = 60;
                        if (timp[1] <= 0)
                        {
                            timp[0]--;
                            timp[1] = 60;
                        }
                    }
                }
                timp_lbl.Text = string.Format("Timp Ramas : {0} min {1} secunde", timp[0] < 0 ? "0" : timp[0].ToString(), timp[0] < 0 ? "0" : timp[1].ToString());
            }
        }

        public void AskExit()
        {
            if(close_once)
            {
                Application.Exit();
                return;
            }
            if (game_started)
            {
                cronometru.Enabled = false;
                close_once = true;
                DialogResult results = MessageBox.Show("Esti sigur ca vrei sa iesi din joc in timp ce ruleaza? \nPunctele tale acumulate pana la acest cuvant nu se vor salva in fisier.", "Atentie !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                switch (results)
                {
                    case DialogResult.Yes:
                        Environment.Exit(0);
                        break;
                    case DialogResult.No:
                        cronometru.Enabled = true;
                        close_once = false;
                        break;
                }
            }
        }

        private void human_img_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 3);
            //spanzuratoare
            Point[] bara = new Point[2] { new Point { X = 78, Y = 23 }, new Point { X = 228, Y = 23 } };
            e.Graphics.DrawLine(pen, bara[0], bara[1]);
            Point[] funie = new Point[2] { new Point { X = 145, Y = 24 }, new Point { X = 145, Y = 94 } };
            e.Graphics.DrawLine(pen, funie[0], funie[1]);
            Point[] gat = new Point[2] { new Point { X = 145, Y = 93 }, new Point { X = 156, Y = 124 } };
            e.Graphics.DrawLine(pen, gat[0], gat[1]);
            //autogenereaza
            if (atribute_player[1] <= 5)
            { 
                Rectangle rt = new Rectangle(152, 84, 50, 50);
                e.Graphics.DrawEllipse(pen, rt);
            }
            if(atribute_player[1] <= 4)
                e.Graphics.DrawLine(pen,human_coordonates[0,0],human_coordonates[0,1]);
            if (atribute_player[1] <= 3)
                e.Graphics.DrawLine(pen, human_coordonates[1, 0], human_coordonates[1, 1]);
            if (atribute_player[1] <= 2)
                e.Graphics.DrawLine(pen, human_coordonates[2, 0], human_coordonates[2, 1]);
            if (atribute_player[1] <= 1)
                e.Graphics.DrawLine(pen, human_coordonates[3, 0], human_coordonates[3, 1]);
            if (atribute_player[1] <= 0)
                e.Graphics.DrawLine(pen, human_coordonates[4, 0], human_coordonates[4, 1]);
            pen.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = timp.Count(x => x != 0);
            if (count == 0)
            {
                MessageBox.Show("Alege o lista de cuvinte inainte de a incepe jocul.", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                game_started = true;
                cronometru.Enabled = true;
                pnljoc.Visible = true;
                startgamepnl.Visible = false;
                manager_pnl.Visible = false;
                Intrebare.Text = words[atribute_player[3]-1,0];
            }
        }

        private void exit_menu_Click(object sender, EventArgs e)
        {
            if (game_started)
            {
                AskExit();
            }
            else
            {
                Application.Exit();
            }
        }

        private void incarca_lista_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.FileName = "";
            opf.Title = "Alege lista ce va fii editata";
            opf.DefaultExt = "*.txt";
            opf.Filter = "Text File(.Txt) | *.txt";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(opf.FileName, FileMode.Open, FileAccess.Read);
                string read_all;
                using (StreamReader reader = new StreamReader(fs))
                {
                    read_all = reader.ReadToEnd();
                }
                edit_txt.Clear();
                edit_txt.SelectedText = read_all;
                location = opf.FileName;
                textBox1.Text = opf.SafeFileName;
            }
        }

        private void save_changes_Click(object sender, EventArgs e)
        {
            if(location == string.Empty)
            {
                MessageBox.Show("Mai intai alege lista pe care vrei sa o modifici.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            File.WriteAllText(location,edit_txt.Text);
            MessageBox.Show("Au fost salvate modificarile in fisierul " + textBox1.Text + ".", "Salvare cu succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buy_1_Click(object sender, EventArgs e)
        {
            if((timp[0] + random_shop[0,0]) > timp[0])
            {
                MessageBox.Show("Nu poti cumpara mai mult timp decat timpul initial.","Eroare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if(atribute_player[0] >= random_shop[0,1])
            {
                timp[0] += random_shop[0, 0];
                atribute_player[0] -= random_shop[0, 1];
                MessageBox.Show("Ai cumparat "+random_shop[0,0]+" minute cu "+random_shop[0,1]+" puncte.", "Obiect cumparat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buy_1.Enabled = false;
            }
            else
            {
                int pct_nev = random_shop[0, 1] - atribute_player[0];
                MessageBox.Show("Mai ai nevoie de "+pct_nev+" puncte.", "Puncte insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buy_2_Click(object sender, EventArgs e)
        {
            if ((atribute_player[2] + random_shop[1,0]) > 3)
            {
                MessageBox.Show("Poti avea maxim 3 hinturi.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (atribute_player[0] >= random_shop[1, 1])
            {
                atribute_player[2] += random_shop[1,0];
                atribute_player[0] -= random_shop[1,1];
                MessageBox.Show("Ai cumparat " + random_shop[1,0] + " hinturi cu " + random_shop[1,1] + " puncte.", "Obiect cumparat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buy_2.Enabled = false;
            }
            else
            {
                int pct_nev = random_shop[1,1] - atribute_player[0];
                MessageBox.Show("Mai ai nevoie de " + pct_nev + " puncte.", "Puncte insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buy_3_Click(object sender, EventArgs e)
        {
            if ((atribute_player[1] + random_shop[2, 0]) > 6)
            {
                MessageBox.Show("Nu poti avea mai mult de 6 incercari.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (atribute_player[0] >= random_shop[2, 1])
            {
                atribute_player[1] += random_shop[2, 0];
                atribute_player[0] -= random_shop[2, 1];
                MessageBox.Show("Ai cumparat " + random_shop[2, 0] + " incercari cu " + random_shop[2, 1] + " puncte.", "Obiect cumparat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buy_3.Enabled = false;
            }
            else
            {
                int pct_nev = random_shop[2, 1] - atribute_player[0];
                MessageBox.Show("Mai ai nevoie de " + pct_nev + " puncte.", "Puncte insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void continua_btn_Click(object sender, EventArgs e)
        {
            atribute_player[3]++;
            if (Convert.ToInt32(atribute_player[3]) > Convert.ToInt32(atribute_player[4]))
            {
                cronometru.Enabled = false;
                FileStream fs = new FileStream("clasament/clasament_final.txt", FileMode.Append, FileAccess.Write);
                string timp_terminat = string.Format("{0} min si {1} sec",timp[0],timp[1]);
                using (StreamWriter wr = new StreamWriter(fs))
                {
                    wr.WriteLine("Data : {0} | Puncte : {1} | Timp : {2} | Nume lista terminata : {3} |",DateTime.Now,atribute_player[0],timp_terminat, nume_lista);
                }
                MessageBox.Show("Salvare cu succes, vei fi redirectionat la meniul principal.","Succes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                game_started = false;
                close_once = false;
                cronometru.Enabled = false;
                startgamepnl.Visible = true;
                pnljoc.Visible = false;
                manager_pnl.Visible = false;
                gameover_pnl.Visible = false;
                validchar_btn.Enabled = true;
                use_hint.Enabled = true;
                victory_pnl.Visible = false;
                for (int i = 0; i < timp.Length; i++)
                {
                    timp.SetValue(0, i);
                }
                atribute_player[1] = 6;
                atribute_player[2] = 3;
                atribute_player[0] = 0;
                guess_wordtxt.Text = "";
            }
            else
            {
                int length = Convert.ToInt32(words[atribute_player[3] - 1, 2]);
                int index = 0;
                char[] cuvant = words[atribute_player[3] - 1, 1].ToCharArray();
                char[] new_word = words[atribute_player[3] - 1, 1].ToCharArray();
                for (int i = 0; i < length; i++)
                {
                    Random rnd = new Random();
                    int random = rnd.Next(new_word.Length);
                    if (new_word[random] == '_')
                    {
                        length++;
                        continue;
                    }
                    for (int j = 0; j < cuvant.Length; j++)
                    {
                        if (cuvant[random] == cuvant[j])
                        {
                            new_word[j] = '_';
                        }
                    }
                    index_chars[index] = random;
                    index++;
                }
                Intrebare.Text = words[atribute_player[3] - 1, 0];
                cuvant_lbl.Text = new string(new_word);
                cate_litere.Text = "Cuvant din " + new_word.Length.ToString() + " litere.";
                status_user.Text = string.Format("Puncte : {0}               Incercari : {1} / 6         Hinturi : {2} / 3         Cuvantul : {3} / {4}", atribute_player[0], atribute_player[1], atribute_player[2], atribute_player[3], atribute_player[4]);
                startgamepnl.Visible = false;
                gameover_pnl.Visible = false;
                victory_pnl.Visible = false;
                pnljoc.Visible = true;
                manager_pnl.Visible = false;
                cronometru.Enabled = true;
                validchar_btn.Enabled = true;
                use_hint.Enabled = true;
                guess_wordtxt.Text = "";
            }
        }

        private void save_and_exit_Click(object sender, EventArgs e)
        {
            //save in clasament_partial.txt
            cronometru.Enabled = false;
            FileStream fs = new FileStream("clasament/clasament_partial.txt", FileMode.Append, FileAccess.Write);
            string timp_terminat = string.Format("{0} min si {1} sec", timp[0], timp[1]);
            using (StreamWriter wr = new StreamWriter(fs))
            {
                wr.WriteLine("Data : {0} | Puncte : {1} | Timp : {2} | Nume lista incompleta : {3} | Cuvantul {4} / {5} |", DateTime.Now, atribute_player[0], timp_terminat, nume_lista,atribute_player[3],atribute_player[4]);
            }
            MessageBox.Show("Salvare cu succes, vei fi redirectionat la meniul principal.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            game_started = false;
            close_once = false;
            cronometru.Enabled = false;
            startgamepnl.Visible = true;
            pnljoc.Visible = false;
            manager_pnl.Visible = false;
            gameover_pnl.Visible = false;
            victory_pnl.Visible = false;
            validchar_btn.Enabled = true;
            use_hint.Enabled = true;
            for (int i = 0; i < timp.Length; i++)
            {
                timp.SetValue(0, i);
            }
            atribute_player[1] = 6;
            atribute_player[2] = 3;
            atribute_player[0] = 0;
            guess_wordtxt.Text = "";
        }

        private void Spanzuratoarea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(game_started)
            {
                AskExit();
                e.Cancel = true;
            }
        }

        private void validchar_btn_Click(object sender, EventArgs e)
        {
            if (guess_wordtxt.Text == string.Empty)
                return;
            if (guess_wordtxt.Text.Length >= 2)
                return;
            if (atribute_player[1] == 0)
                return;

            cuvant = words[atribute_player[3] - 1, 1].ToCharArray();
            rupt = cuvant_lbl.Text.ToCharArray();
            bool found = false;
            for (int j = 0; j < rupt.Length; j++)
            {
                if (rupt[j] == Convert.ToChar(guess_wordtxt.Text.ToUpper()))
                {
                    MessageBox.Show("Litera '"+ guess_wordtxt.Text.ToUpper() + "' a fost folosita deja .","Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            for (int i = 0; i < words[atribute_player[3] - 1, 1].Length; i++)
            {
                for (int j = 0; j < Convert.ToInt32(words[atribute_player[3] - 1, 2]); j++)
                {
                    if (Convert.ToChar(guess_wordtxt.Text.ToUpper()) == cuvant[i] && rupt[i] == '_')
                    {
                        rupt[i] = Convert.ToChar(guess_wordtxt.Text.ToUpper());
                        found = true;
                    }
                }
            }
            if (!found)
            {
                atribute_player[1]--;
                status_user.Text = string.Format("Puncte : {0}               Incercari : {1} / 6         Hinturi : {2} / 3         Cuvantul : {3} / {4}", atribute_player[0], atribute_player[1], atribute_player[2], atribute_player[3], atribute_player[4]);
                human_img.Invalidate();
                sounds[1].Play();
            }
            else
                sounds[0].PlaySync();
            if (atribute_player[1] == 0)
            {
                validchar_btn.Enabled = false;
                use_hint.Enabled = false;
                RunLose();
            }
            cuvant_lbl.Text = new string(rupt);
            guess_wordtxt.Text = "";
            guess_wordtxt.Focus();
            if (cuvant_lbl.Text.ToUpper() == words[atribute_player[3] - 1, 1].ToUpper())
            {
                player_win();
            }
        }

        public async void RunLose()
        {
            await System.Threading.Tasks.Task.Delay(200);
            player_lose();
        }

        public void player_lose()
        {
            sounds[3].PlaySync();
            if(atribute_player[1] <= 0)
                lose_lbl.Text = string.Format("Ai pierdut deoarece ai gresit de prea multe ori !!! \nAi ajuns pana la cuvantul numarul {0} din {1}.", atribute_player[3], atribute_player[4]);
            else
                lose_lbl.Text = string.Format("Ai pierdut deoarece ai ramas fara timp !!! \nAi ajuns pana la cuvantul numarul {0} din {1}.", atribute_player[3], atribute_player[4]);
            cronometru.Enabled = false;
            startgamepnl.Visible = false;
            pnljoc.Visible = false;
            manager_pnl.Visible = false;
            victory_pnl.Visible = false;
            gameover_pnl.Visible = true;
        }

        public void player_win()
        {
            sounds[1].Stop();
            sounds[2].Play();
            atribute_player[0] += Convert.ToInt32(words[atribute_player[3] - 1, 3]);
            puncte_lbl.Text = "Puncte : " + atribute_player[0];
            if ((Convert.ToInt32(atribute_player[3]) + 1) > Convert.ToInt32(atribute_player[4]))
            {
                cronometru.Enabled = false;
                continua_btn.Text = "Finalizeaza";
                buy_1.Enabled = false;
                buy_2.Enabled = false;
                buy_3.Enabled = false;
                save_and_exit.Visible = false;
                congrats_lbl.Text = string.Format("Felicitari , ai terminat lista in {0} minute si {1} secunde cu {2} puncte.\nApasa finalizare pentru ati salva scorul in clasament_final.txt.", timp[0], timp[1], atribute_player[0]);
            }
            else
            {
                continua_btn.Text = "Continua";
                save_and_exit.Visible = true;
                congrats_lbl.Text = string.Format("Felicitari ! Esti la cuvantul {0} din {1}.\nPoti cumpara ceva din magazin cu punctele obtinute.\nDupa care poti merge la urmatorul cuvant.", (Convert.ToInt32(atribute_player[3]) + 1).ToString(), atribute_player[4]);
                buy_1.Enabled = true;
                buy_2.Enabled = true;
                buy_3.Enabled = true;
            }
            Random rnd = new Random();
            random_shop[0, 0] = rnd.Next(5, 7);
            random_shop[0, 1] = rnd.Next(100, 250);
            for (int i = 1; i < random_shop.GetLength(0); i++)
            {
                int rnd1 = rnd.Next(1, 2);
                int rnd2 = rnd.Next(50, 250);
                random_shop[i, 0] = rnd1;
                random_shop[i, 1] = rnd2;
            }
            label1.Text = string.Format("+{0} minute [{1}] puncte", random_shop[0, 0].ToString(), random_shop[0, 1].ToString());
            label11.Text = string.Format("+{0} hint [{1}] puncte", random_shop[1, 0].ToString(), random_shop[1, 1].ToString());
            label12.Text = string.Format("+{0} incercari [{1}] puncte", random_shop[2, 0].ToString(), random_shop[2, 1].ToString());
            cronometru.Enabled = false;
            startgamepnl.Visible = false;
            pnljoc.Visible = false;
            manager_pnl.Visible = false;
            victory_pnl.Visible = true;
            gameover_pnl.Visible = false;
            validchar_btn.Enabled = true;
            use_hint.Enabled = true;
        }
    }
}