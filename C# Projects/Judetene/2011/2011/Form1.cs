using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace _2011
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rtMessage.Focus();
        }
        public void SendMessage(int type)
        {
            if (rtMessage.Text != String.Empty)
            {
                string message;
                rtChatBox.SelectionColor = type == 0 ? Color.Red : Color.Blue;
                message = string.Format("{0} : {1}", type == 0 ? "Maria" : "Ionel", rtMessage.Text) + Environment.NewLine;
                rtChatBox.AppendText(message);
                rtMessage.Text = String.Empty;
                rtMessage.Focus();
            }
            else
            {
                rtMessage.Focus();
            }
        }
        private void btMaria_Click(object sender, EventArgs e)
        {
            SendMessage(0);
        }
        private void btIonel_Click(object sender, EventArgs e)
        {
            SendMessage(1);
        }
        private void btDm_Click(object sender, EventArgs e)
        {
            if (rtChatBox.Text != String.Empty)
            {
                rtChatBox.Clear();
            }
        }
        private void btLm_Click(object sender, EventArgs e)
        {
            OpenFileDialog openMessage = new OpenFileDialog();
            openMessage.DefaultExt = "*.rtf";
            openMessage.Filter = "RTF FILE | *.rtf";
            openMessage.Title = "Open messages";
            if(openMessage.ShowDialog() == DialogResult.OK)
            {
                string str;
                using (StreamReader sw = new StreamReader(openMessage.FileName))
                {
                    str = sw.ReadToEnd();
                }
                rtChatBox.Clear();
                rtChatBox.SelectedRtf = str;
            }
        }
        private void btSm_Click(object sender, EventArgs e)
        {
            if(rtChatBox.Text.Length <= 0)
            {
                MessageBox.Show("Error,no text in chatbox to be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog saveMessage = new SaveFileDialog();
            saveMessage.DefaultExt = "*.rtf";
            saveMessage.Filter = "RTF Files|*.rtf";
            saveMessage.Title = "Save messages...";
            if(saveMessage.ShowDialog() == DialogResult.OK && saveMessage.FileName.Length > 0 && rtChatBox.Text.Length > 0)
            {
                rtChatBox.SaveFile(saveMessage.FileName);
            }
        }
    }
}