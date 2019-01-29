using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace CIARO2015
{
    public partial class Administrare : Form
    {
        string[,] coordonate = new string[13, 2];
        public string[,] distante = new string[13, 13];
        string[] numePorturi = new string[13] { "Constanta", "Varna", "Burgas", "Istambul", "Kozlu", "Samsun", "Batumi", "Sokhumi", "Soci", "Anapa", "Yalta", "Sevastopol", "Odessa" };
        int x = 0, n = 13, k;
        bool can_init = false;
        int[] st = new int[400];

        public Administrare()
        {
            InitializeComponent();
            x = 0;
            info_lb.Visible = false;
            can_init = false;
        }

        private void harta_img_Click(object sender, EventArgs e)
        {
            if (can_init)
            {
                if (x >= 13)
                    return;

                MouseEventArgs g = (MouseEventArgs)e;
                Point p = g.Location;
                coordonate[x, 0] = p.X.ToString();
                coordonate[x, 1] = p.Y.ToString();
                info_lb.Text = "X : " + coordonate[x, 0] + "    Y : " + coordonate[x, 1];
                x++;
            }
        }

        private void Administrare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Calatorie.CloseMain();
        }

        private void initializare_btn_Click(object sender, EventArgs e)
        {
            can_init = !can_init;
            info_lb.Visible = !info_lb.Visible;
            x = 0;
        }
        private void salvare_btn_Click(object sender, EventArgs e)
        {
            int cnt = MyData.countData("Porturi", "ID_Port", 1);
            if (x < 13)
            {
                MessageBox.Show("Mai intai trebuie sa introduceti toate coordonatele porturilor !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string SqlStatement = string.Empty;
            if (cnt > 0)
            {
                string Sql = string.Format("DELETE * FROM Porturi;");
                MyData.setData(Sql, 1);
            }
            for (int i = 0; i < coordonate.GetLength(0); i++)
            {
                SqlStatement = string.Format("INSERT INTO Porturi(Nume_port,Pozitie_X,Pozitie_Y)VALUES('{0}',{1},{2});", numePorturi[i], Convert.ToInt32(coordonate[i, 0]), Convert.ToInt32(coordonate[i, 1]));
                MyData.setData(SqlStatement, 1);
            }
            if (cnt > 0)
            {
                MessageBox.Show("Datele din tabela 'Porturi' au fost updatate !", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Datele au fost salvate in tabela 'Porturi' !", "Salvare cu succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void actualizare_btn_Click(object sender, EventArgs e)
        {
            int compare_data = 0;
            bool done = true;
            string SqlStatement = string.Empty;
            ReadFile("Harta_Distantelor.txt");
            int count = MyData.countData("Distante", "ID_Port", 1);
            for (int i = 0; i < numePorturi.Length; i++)
            {
                for (int j = 0; j < numePorturi.Length; j++)
                {
                    int id_port1 = i + 1;
                    int id_port2 = j + 1;
                    if (count != 0)
                        compare_data = MyData.getData("Distante", "Distanta", id_port1, id_port2, numePorturi[j], 1);
                    if (count == 0)
                    {
                        SqlStatement = string.Format("INSERT INTO Distante(ID_Port,ID_Port_Destinatie,Nume_Port_Destinatie,Distanta)VALUES({0},{1},'{2}',{3});", id_port1, id_port2, numePorturi[j], distante[i, j]);
                        MyData.setData(SqlStatement, 1);
                    }
                    else if (compare_data != Convert.ToInt32(distante[i, j]))
                    {
                        SqlStatement = string.Format("UPDATE Distante SET Distanta = {0} WHERE Distanta = {1};", distante[i, j], compare_data);
                        MyData.setData(SqlStatement, 1);
                    }
                    else done = false;
                }
            }
            switch (done)
            {
                case true:
                    MessageBox.Show("Au fost adaugate datele in tabela 'Distante'.", "Adaugare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case false:
                    MessageBox.Show("Nu s-au gasit modificari facute pentru a actualiza baza de date.", "Instintare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void generare_btn_Click(object sender, EventArgs e)
        {
            int count_porturi = MyData.countData("Croaziere", "ID_Croaziera", 1);
            if (count_porturi == 0)
            {
                ReadFile("Harta_Distantelor.txt");
                int[] tipuri = new int[3] { 3, 5, 8 };
                for (int i = 0; i < tipuri.Length; i++)
                {
                    back(tipuri[i]);
                }
            }
            else
            {
                MessageBox.Show("Exista deja date in tabela 'Croaziere' !", "Date deja existente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }   
        }

        private void lista_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lista_croaziere lista = new Lista_croaziere();
            lista.Show();
        }

        //metoda backtracking
        void Init()
        {
            st[k] = 0;
        }
        bool succesor()
        {
            if (st[k] < n)
            {
                st[k]++;
                return true;
            }
            else
            {
                return false;
            }
        }
        bool valid()
        {
            bool ok = true;
            for (int i = 1; i < k - 1; i++)
            {
                if (st[i] == st[k])
                    ok = false;
            }
            if (k > 1)
            {
                if (!(st[k] > st[k - 1]))
                    ok = false;
            }
            return ok;
        }
        void tipar(int p)
        {
            int bani = 0;
            string numar = st[1].ToString();
            for(int y = 2; y <= k;y++) numar = numar + "," + st[y];
            string[] split = numar.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                bani += Convert.ToInt32(distante[Convert.ToInt32(st[1]) - 1, Convert.ToInt32(split[i]) - 1]);
            }
            bani = bani * 2;
            numar += "," + st[1].ToString();
            string query = string.Format("INSERT INTO Croaziere(ID_Croaziera,Tip_Croaziera,Lista_Porturi,Pret)VALUES({0},{0},'{1}',{2});",p, numar, bani);
            MyData.setData(query, 1);
        }

        void back(int type)
        {
            bool a;
            k = 1;
            Init();
            while (k > 0)
            {
                do { } while ((a = succesor()) && !valid());
                if (a)
                {
                    if (k == type)
                    {
                        tipar(type);
                    }
                    else
                    {
                        k++;
                        Init();
                    }
                }
                else
                {
                    k--;
                }
            }
            MessageBox.Show("Datele au fost salvate in tabela 'Croaziere' !", "Date salvate", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //genereaza un id unic pentru fiecare croaziera
        //public int GenerateID(int range = 1000)
        //{
        //    Random rnd = new Random();
        //    int ID_Croaziera = rnd.Next(range);
        //    int count_id = MyData.countData("Croaziere", "ID_Croaziera", ID_Croaziera, 1);
        //    return count_id == 0 ? ID_Croaziera : GenerateID();
        //}
        //citire fisier
        public void ReadFile(string FileName)
        {
            //verificam daca exista fisierul
            if (File.Exists(FileName))
            {
                //Declar filestream-ul
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                //variabila care o sa citeasca pozitie cu pozitie din fisier
                string len = null;
                //liniile si coloanele matricii
                int row = 0;
                //streamreade-rul acm
                using (StreamReader reader = new StreamReader(fs))
                {
                    //atata timp cat da de date in fisier si nu sunt nule le citeste
                    while ((len = reader.ReadLine()) != null)
                    {
                        //adaugam in matrice
                        string[] splitVector = len.Split(' ');
                        for (int i = 0; i < splitVector.Length; i++)
                        {
                            distante[row, i] = splitVector[i];
                        }
                        row++;
                    }
                }
            }
        }
    }
}