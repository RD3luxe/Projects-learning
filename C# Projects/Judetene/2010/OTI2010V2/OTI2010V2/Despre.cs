using System;
using System.Windows.Forms;

namespace OTI2010V2
{
    public partial class Despre : Form
    {
        public Despre()
        {
            InitializeComponent();
        }

        private void Despre_FormClosing(object sender, FormClosingEventArgs e)
        {
            CIA2010.windowsOpen[0] = false;
        }
    }
}