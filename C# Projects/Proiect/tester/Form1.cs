using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace tester
{
    public partial class Form1 : Form
    {
        string main_file = "materii.txt";
        List<string> materii = new List<string>();
        List<Teste> prop_teste = new List<Teste>();
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        public void ReloadData()
        {
            dt = new DataTable();
            dt.Columns.Add("Nume Test");
            dt.Columns.Add("Timp");
            dt.Columns.Add("Puncte");
            for (int i = 0; i < prop_teste.Count; i++)
            {
                if (prop_teste[i].indexMaterie == materii_box.SelectedIndex)
                {
                    //afiseaza in dgv
                    string correct_name = prop_teste[i].numeFisier.ToString().Remove(prop_teste[i].numeFisier.IndexOf('.'));
                    DataRow row = dt.NewRow();
                    row[0] = prop_teste[i].numeFisier;
                    //citeste timp si puncte daca exista
                    string path = string.Format($"{materii_box.SelectedItem.ToString()}/{prop_teste[i].numeFisier.ToString()}");
                    string[] valori = ReadItems(path);
                    row[1] = valori[0] == null ? "0" : valori[0];
                    row[2] = valori[1] == null ? "0" : valori[1];
                    dt.Rows.Add(row);
                }
            }
            dgv_materii.DataSource = dt;
            if (dgv_materii.Columns["start_btn"] == null)
            {
                DataGridViewButtonColumn start = new DataGridViewButtonColumn();
                start.Name = "start_btn";
                start.HeaderText = "Alege testul";
                start.Text = "Lanseaza";
                start.UseColumnTextForButtonValue = true;
                dgv_materii.Columns.Add(start);
            }
        }

        private void materii_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        public string[] ReadItems(string FileName)
        {
            string[] delimita = new string[2];
            if (File.Exists(FileName))
            {
                string[] linii = File.ReadAllLines(FileName);
                if (linii.Length > 0)
                {
                    string[] splitLinii = linii[linii.Length - 1].Split(';');
                    if (splitLinii.Length == 2)
                    {
                        delimita[0] = splitLinii[0];
                        delimita[1] = splitLinii[1];
                    }
                }
            }
            return delimita;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Nume Test");
            dt.Columns.Add("Timp");
            dt.Columns.Add("Punctaj");
            //first file
            if (File.Exists(main_file))
            {
                OpenMainFile();
                foreach (string materie in materii)
                {
                    materii_box.Items.Add(materie);
                }
                materii_box.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("File not found.");
            }
        }

        public void OpenTest(string test_n)
        {
            string path = string.Format($"{materii_box.SelectedItem.ToString()}/{test_n}");
            test_form open_test = new test_form();
            open_test.TestName = path;
            open_test.Show();
            this.Hide();
        }

        public void OpenMainFile()
        {
            string len = null;
            int counter = 0;
            FileStream fs = new FileStream(main_file, FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fs))
            {
                while ((len = reader.ReadLine()) != null)
                {
                    string[] split = len.Split(';');
                    //first line
                    if (counter == 0)
                    {
                        //, del
                        foreach (string s in split)
                        {
                            materii.Add(s);
                        }
                    }
                    else
                    {
                        prop_teste.Add(new Teste { indexMaterie = Convert.ToInt32(split[0]), numeFisier = split[1] });
                    }
                    counter++;
                }
            }
        }

        private void dgv_materii_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                OpenTest(dgv_materii[0, e.RowIndex].Value.ToString());
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu.CloseMain();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    //class
    public class Teste
    {
        public int indexMaterie { get; set; }
        public string numeFisier { get; set; }
    }
}