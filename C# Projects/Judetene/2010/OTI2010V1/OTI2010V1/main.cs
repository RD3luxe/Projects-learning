using System;
using System.IO;
using System.Windows.Forms;

namespace OTI2010V1
{
    public partial class main : Form
    {
        TextBox text;
        Button[,] buttons = new Button[10,10];
        int[,] matrix = new int[10, 10];
        Panel panel_btn;
        SaveFileDialog opf;
        public main()
        {
            InitializeComponent();
            text = new TextBox();
            panel_btn = new Panel();
        }

        public void DrawPanel()
        {
            panel_btn.AutoSize = true;
            panel_btn.Location = new System.Drawing.Point(8, 8);
            panel_btn.Name = "panel_btn";
            panel_btn.Size = new System.Drawing.Size(20,20);
            panel_btn.TabIndex = 4;
            this.Controls.Add(panel_btn);
            CreateMatrix();
        }

        public void CreateTextBox()
        {
            text.Location = new System.Drawing.Point(x: panel_btn.Size.Width+30, y: 45);
            text.Size = new System.Drawing.Size(width: 100, height: 126);
            text.ReadOnly = true;
            text.Multiline = true;
            text.TabIndex = 5;
            this.Controls.Add(text);
        }

        public void CreateMatrix()
        {
            //cream matricea random.
            int X_offset = 0;
            int Y_offset = 0;
            for (int i = 0; i < Convert.ToInt32(nr_txt.Text); i++)
            {
                for (int j = 0; j < Convert.ToInt32(nr_txt.Text); j++)
                {
                    Random rnd = new Random();
                    int nr_num = rnd.Next(0, 2);
                    text.Text += " " + nr_num.ToString();
                    Button btn = new Button();
                    btn.Size = new System.Drawing.Size(width: 50, height: 50);
                    btn.Location = new System.Drawing.Point(x: 20 + X_offset, y: 30 + Y_offset);
                    X_offset += 54;
                    btn.BackColor = nr_num == 1 ? System.Drawing.Color.Black : System.Drawing.Color.Aqua;
                    btn.Name = $"btn{i}_{j}";
                    btn.Click += new EventHandler(btn_click);
                    //this.Controls.Add(btn);
                    buttons[i, j] = btn;
                    panel_btn.Controls.Add(btn);
                    matrix[i, j] = nr_num;
                }
                text.Text += "\r\n";
                Y_offset += 55;
                X_offset = 0;
            }
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            int numar;
            if (Int32.TryParse(nr_txt.Text, out numar))
            {
                if (numar < 3 || numar > 9)
                {
                    MessageBox.Show("Numarul trebuie sa fie intre 3 si 9.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nr_txt.Text = string.Empty;
                    return;
                }
                jocToolStripMenuItem.Enabled = true;
                salvareToolStripMenuItem.Enabled = true;
                label1.Visible = false;
                nr_txt.Visible = false;
                ok_btn.Visible = false;
            }
            else
            {
                MessageBox.Show("Trebuie sa introduci un numar pentru validare.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nr_txt.Text = string.Empty;
                return;
            }
        }

        public void InitGame()
        {
            DrawPanel();
            CreateTextBox();
        }

        public void SearchForButton(Button b)
        {
            for(int i= 0;i < Convert.ToInt32(nr_txt.Text); i++)
            {
                for(int j = 0; j < Convert.ToInt32(nr_txt.Text); j++)
                {
                    //Locatii : [i-1,j] ---> jos || [i,j-1] --> stanga || [i+1,j] ---> sus || [i,j+1] --> dreapta
                    if (buttons[i, j].Name == b.Name)
                    {
                        //butttonul curent
                        buttons[i, j].BackColor = buttons[i, j].BackColor == System.Drawing.Color.Aqua ? System.Drawing.Color.Black : System.Drawing.Color.Aqua;
                        matrix[i, j] = matrix[i, j] == 1 ? 0 : 1;
                        //exista celula dreapta
                        if (j + 1 < Convert.ToInt32(nr_txt.Text))
                        {
                            buttons[i, j + 1].BackColor = buttons[i, j + 1].BackColor == System.Drawing.Color.Black ? System.Drawing.Color.Aqua : System.Drawing.Color.Black; //dreapta
                            matrix[i, j+1] = matrix[i, j + 1] == 1 ? 0 : 1;
                        }
                        //exista celula sus
                        if (i + 1 < Convert.ToInt32(nr_txt.Text))
                        {
                            buttons[i + 1, j].BackColor = buttons[i + 1, j].BackColor == System.Drawing.Color.Black ? System.Drawing.Color.Aqua : System.Drawing.Color.Black; //sus
                            matrix[i + 1, j] = matrix[i + 1, j] == 1 ? 0 : 1;
                        }
                        //exista celula jos
                        if (i - 1 >= 0)
                        {
                            buttons[i - 1, j].BackColor = buttons[i - 1, j].BackColor == System.Drawing.Color.Black ? System.Drawing.Color.Aqua : System.Drawing.Color.Black; //jos
                            matrix[i-1 , j] = matrix[i-1, j] == 1 ? 0 : 1;
                        }
                        //exista celula stanga
                        if (j - 1 >= 0)
                        {
                            buttons[i, j - 1].BackColor = buttons[i, j - 1].BackColor == System.Drawing.Color.Black ? System.Drawing.Color.Aqua : System.Drawing.Color.Black; //stanga
                            matrix[i, j - 1] = matrix[i, j - 1] == 1 ? 0 : 1;
                        }
                    }
                }
            }
        }
        
        public void btn_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            SearchForButton(b);
            //reset textbox
            text.Text = string.Empty;
            //read matrix again
            for (int i = 0; i < Convert.ToInt32(nr_txt.Text); i++)
            {
                for (int j = 0; j < Convert.ToInt32(nr_txt.Text); j++)
                {
                    text.Text += " " + matrix[i,j].ToString();
                }
                text.Text += "\r\n";
            }
            if(CheckForWinner(1) || CheckForWinner(2))
            {
                MessageBox.Show("Felicitari ai castigat !!!", "Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool CheckForWinner(int type)
        {
            bool winner = true;//consider ca matricea are toate 1 sau 0
            //daca matricea are numai 1 sau 0 a castigat.
            for (int i = 0; i < Convert.ToInt32(nr_txt.Text); i++)
            {
                for (int j = 0; j < Convert.ToInt32(nr_txt.Text); j++)
                {
                    switch (type)
                    {
                        //verific daca sunt toate 1 in cazul asta daca gasesc un 0 fac boolean-ul false;
                        case 1:
                            if (matrix[i, j] == 0)
                            {
                                winner = false;
                            }
                            break;
                        //aici verific daca sunt toate 0 in cazul asta daca gasesc un 1 ma intorc 
                        case 2:
                            if (matrix[i, j] == 1)
                            {
                                winner = false;
                            }
                            break;
                    }
                    //daca winner e false break nu mai are sens loop-ul
                    if (winner == false)
                        break;
                }
            }
            //return winner
            return winner;
        }

        private void jocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitGame();
        }

        private void salvareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Salveaza matricea";
            sf.DefaultExt = "*.txt";
            sf.Filter = "Text File | *.txt";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.Create, FileAccess.Write);
                using (StreamWriter wr = new StreamWriter(fs))
                {
                    for (int i = 0; i < Convert.ToInt32(nr_txt.Text); i++)
                    {
                        for (int j = 0; j < Convert.ToInt32(nr_txt.Text); j++)
                        {
                            wr.Write(matrix[i, j] + " ");
                        }
                        wr.Write("\r\n");
                    }
                }
                string fileName = Path.GetFileNameWithoutExtension(sf.FileName);
                /*
                 * sau
                 FileInfo fi = new FileInf(sf.FileName);
                 string fileName = fi.Name;
                */
                MessageBox.Show($"Matricea a fost salvata cu succes in fisierul {fileName}.","Salvare efectuata",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }    
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}