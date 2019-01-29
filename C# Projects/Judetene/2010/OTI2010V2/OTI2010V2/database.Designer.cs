namespace OTI2010V2
{
    partial class database
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.db_dgv = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.afisareEleviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugareElevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeElevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alfabeticaDupaNumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descrescătoareDupăAbsenţeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.db_dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // db_dgv
            // 
            this.db_dgv.AllowUserToDeleteRows = false;
            this.db_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.db_dgv.Location = new System.Drawing.Point(13, 70);
            this.db_dgv.Name = "db_dgv";
            this.db_dgv.Size = new System.Drawing.Size(508, 318);
            this.db_dgv.TabIndex = 0;
            this.db_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.db_dgv_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afisareEleviToolStripMenuItem,
            this.adaugareElevToolStripMenuItem,
            this.stergeElevToolStripMenuItem,
            this.sortareToolStripMenuItem,
            this.iesireToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // afisareEleviToolStripMenuItem
            // 
            this.afisareEleviToolStripMenuItem.Name = "afisareEleviToolStripMenuItem";
            this.afisareEleviToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.afisareEleviToolStripMenuItem.Text = "Afisare elevi";
            this.afisareEleviToolStripMenuItem.Click += new System.EventHandler(this.afisareEleviToolStripMenuItem_Click);
            // 
            // adaugareElevToolStripMenuItem
            // 
            this.adaugareElevToolStripMenuItem.Name = "adaugareElevToolStripMenuItem";
            this.adaugareElevToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.adaugareElevToolStripMenuItem.Text = "Adaugare elev";
            this.adaugareElevToolStripMenuItem.Click += new System.EventHandler(this.adaugareElevToolStripMenuItem_Click);
            // 
            // stergeElevToolStripMenuItem
            // 
            this.stergeElevToolStripMenuItem.Name = "stergeElevToolStripMenuItem";
            this.stergeElevToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.stergeElevToolStripMenuItem.Text = "Sterge elev";
            this.stergeElevToolStripMenuItem.Click += new System.EventHandler(this.stergeElevToolStripMenuItem_Click);
            // 
            // sortareToolStripMenuItem
            // 
            this.sortareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alfabeticaDupaNumeToolStripMenuItem,
            this.descrescătoareDupăAbsenţeToolStripMenuItem});
            this.sortareToolStripMenuItem.Name = "sortareToolStripMenuItem";
            this.sortareToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.sortareToolStripMenuItem.Text = "Sortare";
            // 
            // alfabeticaDupaNumeToolStripMenuItem
            // 
            this.alfabeticaDupaNumeToolStripMenuItem.Name = "alfabeticaDupaNumeToolStripMenuItem";
            this.alfabeticaDupaNumeToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.alfabeticaDupaNumeToolStripMenuItem.Text = "Alfabetica dupa nume";
            this.alfabeticaDupaNumeToolStripMenuItem.Click += new System.EventHandler(this.alfabeticaDupaNumeToolStripMenuItem_Click);
            // 
            // descrescătoareDupăAbsenţeToolStripMenuItem
            // 
            this.descrescătoareDupăAbsenţeToolStripMenuItem.Name = "descrescătoareDupăAbsenţeToolStripMenuItem";
            this.descrescătoareDupăAbsenţeToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.descrescătoareDupăAbsenţeToolStripMenuItem.Text = "Descrescătoare după absenţe ";
            this.descrescătoareDupăAbsenţeToolStripMenuItem.Click += new System.EventHandler(this.descrescătoareDupăAbsenţeToolStripMenuItem_Click);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.iesireToolStripMenuItem.Text = "Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 400);
            this.Controls.Add(this.db_dgv);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "database";
            this.Text = "Baza de date";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.database_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.db_dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView db_dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem afisareEleviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugareElevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeElevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alfabeticaDupaNumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descrescătoareDupăAbsenţeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
    }
}