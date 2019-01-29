namespace OTI2012
{
    partial class ProfesorPanel
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
            this.actions_menu = new System.Windows.Forms.MenuStrip();
            this.listaStudentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promovatiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.picatiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.listacompletaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.testeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaTeste = new System.Windows.Forms.ToolStripMenuItem();
            this.nume_lbl = new System.Windows.Forms.Label();
            this.log_out = new System.Windows.Forms.Button();
            this.listaStudenti = new System.Windows.Forms.Panel();
            this.nume_cmb = new System.Windows.Forms.ComboBox();
            this.mesaj_lbl = new System.Windows.Forms.Label();
            this.studenti_dgv = new System.Windows.Forms.DataGridView();
            this.add_pnl = new System.Windows.Forms.Panel();
            this.timp_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.raspunsuri_list = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.intrebare_lbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.add_btn = new System.Windows.Forms.Button();
            this.tip_intrebare = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.studenti_lst = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.intrebare = new System.Windows.Forms.Label();
            this.pct_txt = new System.Windows.Forms.TextBox();
            this.create_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.question_txt = new System.Windows.Forms.TextBox();
            this.nume_fisier = new System.Windows.Forms.TextBox();
            this.actions_menu.SuspendLayout();
            this.listaStudenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studenti_dgv)).BeginInit();
            this.add_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // actions_menu
            // 
            this.actions_menu.BackColor = System.Drawing.Color.White;
            this.actions_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaStudentiToolStripMenuItem,
            this.testeMenu,
            this.adaugaTeste});
            this.actions_menu.Location = new System.Drawing.Point(0, 0);
            this.actions_menu.Name = "actions_menu";
            this.actions_menu.Size = new System.Drawing.Size(922, 24);
            this.actions_menu.TabIndex = 0;
            this.actions_menu.Text = "menuStrip1";
            // 
            // listaStudentiToolStripMenuItem
            // 
            this.listaStudentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.promovatiMenu,
            this.picatiMenu,
            this.listacompletaMenu});
            this.listaStudentiToolStripMenuItem.Name = "listaStudentiToolStripMenuItem";
            this.listaStudentiToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.listaStudentiToolStripMenuItem.Text = "Lista Studenti";
            // 
            // promovatiMenu
            // 
            this.promovatiMenu.Name = "promovatiMenu";
            this.promovatiMenu.Size = new System.Drawing.Size(152, 22);
            this.promovatiMenu.Text = "Promovati";
            this.promovatiMenu.Click += new System.EventHandler(this.promovatiMenu_Click);
            // 
            // picatiMenu
            // 
            this.picatiMenu.Name = "picatiMenu";
            this.picatiMenu.Size = new System.Drawing.Size(152, 22);
            this.picatiMenu.Text = "Picati";
            this.picatiMenu.Click += new System.EventHandler(this.picatiMenu_Click);
            // 
            // listacompletaMenu
            // 
            this.listacompletaMenu.Name = "listacompletaMenu";
            this.listacompletaMenu.Size = new System.Drawing.Size(152, 22);
            this.listacompletaMenu.Text = "Lista completa";
            this.listacompletaMenu.Click += new System.EventHandler(this.listacompletaMenu_Click);
            // 
            // testeMenu
            // 
            this.testeMenu.Name = "testeMenu";
            this.testeMenu.Size = new System.Drawing.Size(74, 20);
            this.testeMenu.Text = "Lista Teste";
            this.testeMenu.Click += new System.EventHandler(this.tesetMenu_Click);
            // 
            // adaugaTeste
            // 
            this.adaugaTeste.Name = "adaugaTeste";
            this.adaugaTeste.Size = new System.Drawing.Size(85, 20);
            this.adaugaTeste.Text = "Adauga Test";
            this.adaugaTeste.Click += new System.EventHandler(this.adaugaTeste_Click);
            // 
            // nume_lbl
            // 
            this.nume_lbl.AutoSize = true;
            this.nume_lbl.BackColor = System.Drawing.Color.White;
            this.nume_lbl.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nume_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nume_lbl.Location = new System.Drawing.Point(745, 3);
            this.nume_lbl.Name = "nume_lbl";
            this.nume_lbl.Size = new System.Drawing.Size(143, 21);
            this.nume_lbl.TabIndex = 1;
            this.nume_lbl.Text = "Nume,prenume";
            // 
            // log_out
            // 
            this.log_out.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_out.ForeColor = System.Drawing.Color.Red;
            this.log_out.Location = new System.Drawing.Point(664, 0);
            this.log_out.Name = "log_out";
            this.log_out.Size = new System.Drawing.Size(75, 24);
            this.log_out.TabIndex = 2;
            this.log_out.Text = "Log out";
            this.log_out.UseVisualStyleBackColor = true;
            this.log_out.Click += new System.EventHandler(this.log_out_Click);
            // 
            // listaStudenti
            // 
            this.listaStudenti.Controls.Add(this.nume_cmb);
            this.listaStudenti.Controls.Add(this.mesaj_lbl);
            this.listaStudenti.Controls.Add(this.studenti_dgv);
            this.listaStudenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaStudenti.Location = new System.Drawing.Point(0, 24);
            this.listaStudenti.Name = "listaStudenti";
            this.listaStudenti.Size = new System.Drawing.Size(922, 474);
            this.listaStudenti.TabIndex = 3;
            // 
            // nume_cmb
            // 
            this.nume_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nume_cmb.FormattingEnabled = true;
            this.nume_cmb.Location = new System.Drawing.Point(32, 56);
            this.nume_cmb.Name = "nume_cmb";
            this.nume_cmb.Size = new System.Drawing.Size(159, 21);
            this.nume_cmb.TabIndex = 2;
            this.nume_cmb.Visible = false;
            this.nume_cmb.SelectedIndexChanged += new System.EventHandler(this.nume_cmb_SelectedIndexChanged);
            // 
            // mesaj_lbl
            // 
            this.mesaj_lbl.AutoSize = true;
            this.mesaj_lbl.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesaj_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.mesaj_lbl.Location = new System.Drawing.Point(346, 10);
            this.mesaj_lbl.Name = "mesaj_lbl";
            this.mesaj_lbl.Size = new System.Drawing.Size(66, 26);
            this.mesaj_lbl.TabIndex = 1;
            this.mesaj_lbl.Text = "Mesaj";
            // 
            // studenti_dgv
            // 
            this.studenti_dgv.AllowUserToAddRows = false;
            this.studenti_dgv.AllowUserToDeleteRows = false;
            this.studenti_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studenti_dgv.Location = new System.Drawing.Point(32, 83);
            this.studenti_dgv.Name = "studenti_dgv";
            this.studenti_dgv.Size = new System.Drawing.Size(856, 356);
            this.studenti_dgv.TabIndex = 0;
            this.studenti_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studenti_dgv_CellClick);
            this.studenti_dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.studenti_dgv_CellEndEdit);
            this.studenti_dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.studenti_dgv_CellEnter);
            // 
            // add_pnl
            // 
            this.add_pnl.Controls.Add(this.timp_txt);
            this.add_pnl.Controls.Add(this.label8);
            this.add_pnl.Controls.Add(this.raspunsuri_list);
            this.add_pnl.Controls.Add(this.button1);
            this.add_pnl.Controls.Add(this.intrebare_lbl);
            this.add_pnl.Controls.Add(this.label7);
            this.add_pnl.Controls.Add(this.label2);
            this.add_pnl.Controls.Add(this.add_btn);
            this.add_pnl.Controls.Add(this.tip_intrebare);
            this.add_pnl.Controls.Add(this.label6);
            this.add_pnl.Controls.Add(this.studenti_lst);
            this.add_pnl.Controls.Add(this.label5);
            this.add_pnl.Controls.Add(this.label4);
            this.add_pnl.Controls.Add(this.label3);
            this.add_pnl.Controls.Add(this.intrebare);
            this.add_pnl.Controls.Add(this.pct_txt);
            this.add_pnl.Controls.Add(this.create_btn);
            this.add_pnl.Controls.Add(this.label1);
            this.add_pnl.Controls.Add(this.question_txt);
            this.add_pnl.Controls.Add(this.nume_fisier);
            this.add_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add_pnl.Location = new System.Drawing.Point(0, 24);
            this.add_pnl.Name = "add_pnl";
            this.add_pnl.Size = new System.Drawing.Size(922, 474);
            this.add_pnl.TabIndex = 3;
            // 
            // timp_txt
            // 
            this.timp_txt.Location = new System.Drawing.Point(670, 209);
            this.timp_txt.Name = "timp_txt";
            this.timp_txt.Size = new System.Drawing.Size(150, 20);
            this.timp_txt.TabIndex = 24;
            this.timp_txt.Leave += new System.EventHandler(this.timp_txt_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(598, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 26);
            this.label8.TabIndex = 23;
            this.label8.Text = "Timp :";
            // 
            // raspunsuri_list
            // 
            this.raspunsuri_list.Location = new System.Drawing.Point(226, 248);
            this.raspunsuri_list.Multiline = true;
            this.raspunsuri_list.Name = "raspunsuri_list";
            this.raspunsuri_list.Size = new System.Drawing.Size(300, 70);
            this.raspunsuri_list.TabIndex = 22;
            this.raspunsuri_list.Leave += new System.EventHandler(this.raspunsuri_list_Leave);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(574, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 32);
            this.button1.TabIndex = 21;
            this.button1.Text = "Finalizare creare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // intrebare_lbl
            // 
            this.intrebare_lbl.AutoSize = true;
            this.intrebare_lbl.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intrebare_lbl.ForeColor = System.Drawing.Color.LimeGreen;
            this.intrebare_lbl.Location = new System.Drawing.Point(388, 142);
            this.intrebare_lbl.Name = "intrebare_lbl";
            this.intrebare_lbl.Size = new System.Drawing.Size(190, 26);
            this.intrebare_lbl.TabIndex = 20;
            this.intrebare_lbl.Text = "Intrebarea numarul ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkOrange;
            this.label7.Location = new System.Drawing.Point(409, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 26);
            this.label7.TabIndex = 19;
            this.label7.Text = "Adauga test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(598, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "Raspunsuri corecte :";
            // 
            // add_btn
            // 
            this.add_btn.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_btn.ForeColor = System.Drawing.Color.DarkRed;
            this.add_btn.Location = new System.Drawing.Point(93, 418);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(300, 32);
            this.add_btn.TabIndex = 17;
            this.add_btn.Text = "Adauga intrebare";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // tip_intrebare
            // 
            this.tip_intrebare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tip_intrebare.FormattingEnabled = true;
            this.tip_intrebare.Location = new System.Drawing.Point(226, 334);
            this.tip_intrebare.Name = "tip_intrebare";
            this.tip_intrebare.Size = new System.Drawing.Size(148, 21);
            this.tip_intrebare.TabIndex = 15;
            this.tip_intrebare.SelectedIndexChanged += new System.EventHandler(this.tip_intrebare_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(88, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pentru studentul :";
            // 
            // studenti_lst
            // 
            this.studenti_lst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studenti_lst.FormattingEnabled = true;
            this.studenti_lst.Location = new System.Drawing.Point(279, 104);
            this.studenti_lst.Name = "studenti_lst";
            this.studenti_lst.Size = new System.Drawing.Size(148, 21);
            this.studenti_lst.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(88, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tip test :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(88, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Puncte :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(88, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Raspunsuri :";
            // 
            // intrebare
            // 
            this.intrebare.AutoSize = true;
            this.intrebare.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intrebare.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.intrebare.Location = new System.Drawing.Point(88, 203);
            this.intrebare.Name = "intrebare";
            this.intrebare.Size = new System.Drawing.Size(111, 26);
            this.intrebare.TabIndex = 7;
            this.intrebare.Text = "Intrebare :";
            // 
            // pct_txt
            // 
            this.pct_txt.Location = new System.Drawing.Point(226, 372);
            this.pct_txt.Name = "pct_txt";
            this.pct_txt.Size = new System.Drawing.Size(148, 20);
            this.pct_txt.TabIndex = 5;
            this.pct_txt.Leave += new System.EventHandler(this.pct_txt_Leave);
            // 
            // create_btn
            // 
            this.create_btn.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_btn.ForeColor = System.Drawing.Color.DarkRed;
            this.create_btn.Location = new System.Drawing.Point(574, 74);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(154, 32);
            this.create_btn.TabIndex = 4;
            this.create_btn.Text = "Creaza fisier";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(88, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nume test :";
            // 
            // question_txt
            // 
            this.question_txt.Location = new System.Drawing.Point(226, 209);
            this.question_txt.Name = "question_txt";
            this.question_txt.Size = new System.Drawing.Size(300, 20);
            this.question_txt.TabIndex = 1;
            // 
            // nume_fisier
            // 
            this.nume_fisier.Location = new System.Drawing.Point(279, 67);
            this.nume_fisier.Name = "nume_fisier";
            this.nume_fisier.Size = new System.Drawing.Size(148, 20);
            this.nume_fisier.TabIndex = 0;
            // 
            // ProfesorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 498);
            this.Controls.Add(this.listaStudenti);
            this.Controls.Add(this.log_out);
            this.Controls.Add(this.nume_lbl);
            this.Controls.Add(this.add_pnl);
            this.Controls.Add(this.actions_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.actions_menu;
            this.MaximizeBox = false;
            this.Name = "ProfesorPanel";
            this.Text = "Panel profesori";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProfesorPanel_FormClosed);
            this.Load += new System.EventHandler(this.ProfesorPanel_Load);
            this.actions_menu.ResumeLayout(false);
            this.actions_menu.PerformLayout();
            this.listaStudenti.ResumeLayout(false);
            this.listaStudenti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studenti_dgv)).EndInit();
            this.add_pnl.ResumeLayout(false);
            this.add_pnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip actions_menu;
        private System.Windows.Forms.Label nume_lbl;
        private System.Windows.Forms.Button log_out;
        private System.Windows.Forms.ToolStripMenuItem listaStudentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promovatiMenu;
        private System.Windows.Forms.ToolStripMenuItem picatiMenu;
        private System.Windows.Forms.ToolStripMenuItem testeMenu;
        private System.Windows.Forms.ToolStripMenuItem listacompletaMenu;
        private System.Windows.Forms.ToolStripMenuItem adaugaTeste;
        private System.Windows.Forms.Panel listaStudenti;
        private System.Windows.Forms.DataGridView studenti_dgv;
        private System.Windows.Forms.Label mesaj_lbl;
        private System.Windows.Forms.ComboBox nume_cmb;
        private System.Windows.Forms.Panel add_pnl;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox question_txt;
        private System.Windows.Forms.TextBox nume_fisier;
        private System.Windows.Forms.TextBox pct_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label intrebare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox studenti_lst;
        private System.Windows.Forms.ComboBox tip_intrebare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label intrebare_lbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox raspunsuri_list;
        private System.Windows.Forms.TextBox timp_txt;
        private System.Windows.Forms.Label label8;
    }
}