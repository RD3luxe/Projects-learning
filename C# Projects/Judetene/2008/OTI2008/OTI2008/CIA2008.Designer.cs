namespace OTI2008
{
    partial class CIA2008
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.afisariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cautareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wr_txt = new System.Windows.Forms.TextBox();
            this.show_txt = new System.Windows.Forms.TextBox();
            this.ok_btn = new System.Windows.Forms.Button();
            this.panel_text = new System.Windows.Forms.Panel();
            this.tabel_pnl = new System.Windows.Forms.Panel();
            this.proiecte_dgv = new System.Windows.Forms.DataGridView();
            this.cauta_btn = new System.Windows.Forms.Button();
            this.nr_cautat = new System.Windows.Forms.TextBox();
            this.rezultat = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.panel_text.SuspendLayout();
            this.tabel_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proiecte_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afisariToolStripMenuItem,
            this.iesireToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(480, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // afisariToolStripMenuItem
            // 
            this.afisariToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.tabelaToolStripMenuItem,
            this.cautareToolStripMenuItem});
            this.afisariToolStripMenuItem.Name = "afisariToolStripMenuItem";
            this.afisariToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.afisariToolStripMenuItem.Text = "Afisari";
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.iesireToolStripMenuItem.Text = "Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // tabelaToolStripMenuItem
            // 
            this.tabelaToolStripMenuItem.Name = "tabelaToolStripMenuItem";
            this.tabelaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tabelaToolStripMenuItem.Text = "Tabela";
            this.tabelaToolStripMenuItem.Click += new System.EventHandler(this.tabelaToolStripMenuItem_Click);
            // 
            // cautareToolStripMenuItem
            // 
            this.cautareToolStripMenuItem.Name = "cautareToolStripMenuItem";
            this.cautareToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cautareToolStripMenuItem.Text = "Cautare";
            this.cautareToolStripMenuItem.Click += new System.EventHandler(this.cautareToolStripMenuItem_Click);
            // 
            // wr_txt
            // 
            this.wr_txt.Location = new System.Drawing.Point(54, 51);
            this.wr_txt.Multiline = true;
            this.wr_txt.Name = "wr_txt";
            this.wr_txt.Size = new System.Drawing.Size(257, 73);
            this.wr_txt.TabIndex = 1;
            // 
            // show_txt
            // 
            this.show_txt.Location = new System.Drawing.Point(54, 157);
            this.show_txt.Multiline = true;
            this.show_txt.Name = "show_txt";
            this.show_txt.ReadOnly = true;
            this.show_txt.Size = new System.Drawing.Size(339, 124);
            this.show_txt.TabIndex = 2;
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(318, 66);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 46);
            this.ok_btn.TabIndex = 3;
            this.ok_btn.Text = "OK";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_text
            // 
            this.panel_text.Controls.Add(this.wr_txt);
            this.panel_text.Controls.Add(this.ok_btn);
            this.panel_text.Controls.Add(this.show_txt);
            this.panel_text.Location = new System.Drawing.Point(12, 40);
            this.panel_text.Name = "panel_text";
            this.panel_text.Size = new System.Drawing.Size(459, 324);
            this.panel_text.TabIndex = 4;
            // 
            // tabel_pnl
            // 
            this.tabel_pnl.Controls.Add(this.rezultat);
            this.tabel_pnl.Controls.Add(this.cauta_btn);
            this.tabel_pnl.Controls.Add(this.nr_cautat);
            this.tabel_pnl.Controls.Add(this.proiecte_dgv);
            this.tabel_pnl.Location = new System.Drawing.Point(12, 28);
            this.tabel_pnl.Name = "tabel_pnl";
            this.tabel_pnl.Size = new System.Drawing.Size(459, 345);
            this.tabel_pnl.TabIndex = 5;
            // 
            // proiecte_dgv
            // 
            this.proiecte_dgv.AllowUserToAddRows = false;
            this.proiecte_dgv.AllowUserToDeleteRows = false;
            this.proiecte_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.proiecte_dgv.Location = new System.Drawing.Point(36, 56);
            this.proiecte_dgv.Name = "proiecte_dgv";
            this.proiecte_dgv.ReadOnly = true;
            this.proiecte_dgv.Size = new System.Drawing.Size(357, 277);
            this.proiecte_dgv.TabIndex = 0;
            // 
            // cauta_btn
            // 
            this.cauta_btn.Location = new System.Drawing.Point(153, 12);
            this.cauta_btn.Name = "cauta_btn";
            this.cauta_btn.Size = new System.Drawing.Size(75, 23);
            this.cauta_btn.TabIndex = 2;
            this.cauta_btn.Text = "Cauta";
            this.cauta_btn.UseVisualStyleBackColor = true;
            this.cauta_btn.Click += new System.EventHandler(this.cauta_btn_Click);
            // 
            // nr_cautat
            // 
            this.nr_cautat.Location = new System.Drawing.Point(36, 16);
            this.nr_cautat.Name = "nr_cautat";
            this.nr_cautat.Size = new System.Drawing.Size(100, 20);
            this.nr_cautat.TabIndex = 1;
            // 
            // rezultat
            // 
            this.rezultat.Location = new System.Drawing.Point(36, 92);
            this.rezultat.Multiline = true;
            this.rezultat.Name = "rezultat";
            this.rezultat.ReadOnly = true;
            this.rezultat.Size = new System.Drawing.Size(178, 106);
            this.rezultat.TabIndex = 3;
            // 
            // CIA2008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 393);
            this.Controls.Add(this.tabel_pnl);
            this.Controls.Add(this.panel_text);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "CIA2008";
            this.Text = "CIA2008";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel_text.ResumeLayout(false);
            this.panel_text.PerformLayout();
            this.tabel_pnl.ResumeLayout(false);
            this.tabel_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proiecte_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem afisariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cautareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.TextBox wr_txt;
        private System.Windows.Forms.TextBox show_txt;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Panel panel_text;
        private System.Windows.Forms.Panel tabel_pnl;
        private System.Windows.Forms.DataGridView proiecte_dgv;
        private System.Windows.Forms.Button cauta_btn;
        private System.Windows.Forms.TextBox nr_cautat;
        private System.Windows.Forms.TextBox rezultat;
    }
}