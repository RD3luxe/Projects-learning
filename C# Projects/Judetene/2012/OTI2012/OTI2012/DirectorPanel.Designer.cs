namespace OTI2012
{
    partial class DirectorPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.logout_btn = new System.Windows.Forms.Button();
            this.btn_modifica = new System.Windows.Forms.Button();
            this.lista_modifica = new System.Windows.Forms.ComboBox();
            this.lista_actiuni = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.add_pnl = new System.Windows.Forms.Panel();
            this.materii_combo = new System.Windows.Forms.ComboBox();
            this.adauga_btn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.add_label = new System.Windows.Forms.Label();
            this.prenume_txt = new System.Windows.Forms.TextBox();
            this.nume_txt = new System.Windows.Forms.TextBox();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.nick_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sterge_pnl = new System.Windows.Forms.Panel();
            this.sterge_lbl = new System.Windows.Forms.Label();
            this.date_dgv = new System.Windows.Forms.DataGridView();
            this.modifica_pnl = new System.Windows.Forms.Panel();
            this.modifica_dgv = new System.Windows.Forms.DataGridView();
            this.modifica_lbl = new System.Windows.Forms.Label();
            this.add_pnl.SuspendLayout();
            this.sterge_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_dgv)).BeginInit();
            this.modifica_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modifica_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(94, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Director";
            // 
            // logout_btn
            // 
            this.logout_btn.ForeColor = System.Drawing.Color.Green;
            this.logout_btn.Location = new System.Drawing.Point(17, 10);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(75, 23);
            this.logout_btn.TabIndex = 1;
            this.logout_btn.Text = "Log out";
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // btn_modifica
            // 
            this.btn_modifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modifica.ForeColor = System.Drawing.Color.Red;
            this.btn_modifica.Location = new System.Drawing.Point(502, 67);
            this.btn_modifica.Name = "btn_modifica";
            this.btn_modifica.Size = new System.Drawing.Size(242, 23);
            this.btn_modifica.TabIndex = 2;
            this.btn_modifica.Text = "Modifica";
            this.btn_modifica.UseVisualStyleBackColor = true;
            this.btn_modifica.Click += new System.EventHandler(this.btn_modifica_Click);
            // 
            // lista_modifica
            // 
            this.lista_modifica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lista_modifica.FormattingEnabled = true;
            this.lista_modifica.Location = new System.Drawing.Point(102, 67);
            this.lista_modifica.Name = "lista_modifica";
            this.lista_modifica.Size = new System.Drawing.Size(121, 21);
            this.lista_modifica.TabIndex = 3;
            this.lista_modifica.SelectedIndexChanged += new System.EventHandler(this.lista_modifica_SelectedIndexChanged);
            // 
            // lista_actiuni
            // 
            this.lista_actiuni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lista_actiuni.FormattingEnabled = true;
            this.lista_actiuni.Location = new System.Drawing.Point(338, 67);
            this.lista_actiuni.Name = "lista_actiuni";
            this.lista_actiuni.Size = new System.Drawing.Size(121, 21);
            this.lista_actiuni.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(58, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tip :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(261, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Actiune :";
            // 
            // add_pnl
            // 
            this.add_pnl.Controls.Add(this.materii_combo);
            this.add_pnl.Controls.Add(this.adauga_btn);
            this.add_pnl.Controls.Add(this.label10);
            this.add_pnl.Controls.Add(this.add_label);
            this.add_pnl.Controls.Add(this.prenume_txt);
            this.add_pnl.Controls.Add(this.nume_txt);
            this.add_pnl.Controls.Add(this.pass_txt);
            this.add_pnl.Controls.Add(this.nick_txt);
            this.add_pnl.Controls.Add(this.label7);
            this.add_pnl.Controls.Add(this.label6);
            this.add_pnl.Controls.Add(this.label5);
            this.add_pnl.Controls.Add(this.label4);
            this.add_pnl.Location = new System.Drawing.Point(13, 113);
            this.add_pnl.Name = "add_pnl";
            this.add_pnl.Size = new System.Drawing.Size(781, 369);
            this.add_pnl.TabIndex = 7;
            // 
            // materii_combo
            // 
            this.materii_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materii_combo.FormattingEnabled = true;
            this.materii_combo.Location = new System.Drawing.Point(203, 199);
            this.materii_combo.Name = "materii_combo";
            this.materii_combo.Size = new System.Drawing.Size(168, 21);
            this.materii_combo.TabIndex = 8;
            // 
            // adauga_btn
            // 
            this.adauga_btn.BackColor = System.Drawing.Color.Yellow;
            this.adauga_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adauga_btn.ForeColor = System.Drawing.Color.Red;
            this.adauga_btn.Location = new System.Drawing.Point(495, 283);
            this.adauga_btn.Name = "adauga_btn";
            this.adauga_btn.Size = new System.Drawing.Size(211, 43);
            this.adauga_btn.TabIndex = 12;
            this.adauga_btn.Text = "Adauga";
            this.adauga_btn.UseVisualStyleBackColor = false;
            this.adauga_btn.Click += new System.EventHandler(this.adauga_btn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Purple;
            this.label10.Location = new System.Drawing.Point(77, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "Materie :";
            // 
            // add_label
            // 
            this.add_label.AutoSize = true;
            this.add_label.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_label.ForeColor = System.Drawing.Color.Crimson;
            this.add_label.Location = new System.Drawing.Point(309, 22);
            this.add_label.Name = "add_label";
            this.add_label.Size = new System.Drawing.Size(161, 24);
            this.add_label.TabIndex = 8;
            this.add_label.Text = "Adauga <TIP>";
            // 
            // prenume_txt
            // 
            this.prenume_txt.Location = new System.Drawing.Point(538, 161);
            this.prenume_txt.Name = "prenume_txt";
            this.prenume_txt.Size = new System.Drawing.Size(168, 20);
            this.prenume_txt.TabIndex = 7;
            // 
            // nume_txt
            // 
            this.nume_txt.Location = new System.Drawing.Point(538, 120);
            this.nume_txt.Name = "nume_txt";
            this.nume_txt.Size = new System.Drawing.Size(168, 20);
            this.nume_txt.TabIndex = 6;
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(203, 159);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.Size = new System.Drawing.Size(168, 20);
            this.pass_txt.TabIndex = 5;
            this.pass_txt.Leave += new System.EventHandler(this.pass_txt_Leave);
            // 
            // nick_txt
            // 
            this.nick_txt.Location = new System.Drawing.Point(203, 118);
            this.nick_txt.Name = "nick_txt";
            this.nick_txt.Size = new System.Drawing.Size(168, 20);
            this.nick_txt.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Purple;
            this.label7.Location = new System.Drawing.Point(426, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "Prenume :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Purple;
            this.label6.Location = new System.Drawing.Point(426, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nume :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Purple;
            this.label5.Location = new System.Drawing.Point(67, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Purple;
            this.label4.Location = new System.Drawing.Point(60, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nickname :";
            // 
            // sterge_pnl
            // 
            this.sterge_pnl.Controls.Add(this.sterge_lbl);
            this.sterge_pnl.Controls.Add(this.date_dgv);
            this.sterge_pnl.Location = new System.Drawing.Point(13, 113);
            this.sterge_pnl.Name = "sterge_pnl";
            this.sterge_pnl.Size = new System.Drawing.Size(782, 369);
            this.sterge_pnl.TabIndex = 13;
            // 
            // sterge_lbl
            // 
            this.sterge_lbl.AutoSize = true;
            this.sterge_lbl.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sterge_lbl.Location = new System.Drawing.Point(313, 2);
            this.sterge_lbl.Name = "sterge_lbl";
            this.sterge_lbl.Size = new System.Drawing.Size(59, 26);
            this.sterge_lbl.TabIndex = 1;
            this.sterge_lbl.Text = "<TIP>";
            // 
            // date_dgv
            // 
            this.date_dgv.AllowUserToAddRows = false;
            this.date_dgv.AllowUserToDeleteRows = false;
            this.date_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.date_dgv.Location = new System.Drawing.Point(0, 48);
            this.date_dgv.Name = "date_dgv";
            this.date_dgv.ReadOnly = true;
            this.date_dgv.Size = new System.Drawing.Size(781, 321);
            this.date_dgv.TabIndex = 0;
            this.date_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.date_dgv_CellClick);
            // 
            // modifica_pnl
            // 
            this.modifica_pnl.Controls.Add(this.modifica_dgv);
            this.modifica_pnl.Controls.Add(this.modifica_lbl);
            this.modifica_pnl.Location = new System.Drawing.Point(12, 113);
            this.modifica_pnl.Name = "modifica_pnl";
            this.modifica_pnl.Size = new System.Drawing.Size(782, 369);
            this.modifica_pnl.TabIndex = 2;
            // 
            // modifica_dgv
            // 
            this.modifica_dgv.AllowUserToAddRows = false;
            this.modifica_dgv.AllowUserToDeleteRows = false;
            this.modifica_dgv.AllowUserToResizeColumns = false;
            this.modifica_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modifica_dgv.Location = new System.Drawing.Point(4, 67);
            this.modifica_dgv.Name = "modifica_dgv";
            this.modifica_dgv.Size = new System.Drawing.Size(775, 299);
            this.modifica_dgv.TabIndex = 1;
            this.modifica_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modifica_dgv_CellClick);
            this.modifica_dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.modifica_dgv_CellEndEdit);
            this.modifica_dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.modifica_dgv_CellEnter);
            this.modifica_dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.modifica_dgv_EditingControlShowing);
            this.modifica_dgv.Sorted += new System.EventHandler(this.modifica_dgv_Sorted);
            // 
            // modifica_lbl
            // 
            this.modifica_lbl.AutoSize = true;
            this.modifica_lbl.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifica_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.modifica_lbl.Location = new System.Drawing.Point(290, 5);
            this.modifica_lbl.Name = "modifica_lbl";
            this.modifica_lbl.Size = new System.Drawing.Size(164, 22);
            this.modifica_lbl.TabIndex = 0;
            this.modifica_lbl.Text = "Modifica <TIP>";
            // 
            // DirectorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(806, 494);
            this.Controls.Add(this.modifica_pnl);
            this.Controls.Add(this.sterge_pnl);
            this.Controls.Add(this.add_pnl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lista_actiuni);
            this.Controls.Add(this.lista_modifica);
            this.Controls.Add(this.btn_modifica);
            this.Controls.Add(this.logout_btn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DirectorPanel";
            this.Text = "Panel Director";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DirectorPanel_FormClosed);
            this.add_pnl.ResumeLayout(false);
            this.add_pnl.PerformLayout();
            this.sterge_pnl.ResumeLayout(false);
            this.sterge_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_dgv)).EndInit();
            this.modifica_pnl.ResumeLayout(false);
            this.modifica_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modifica_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button btn_modifica;
        private System.Windows.Forms.ComboBox lista_modifica;
        private System.Windows.Forms.ComboBox lista_actiuni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel add_pnl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox materii_combo;
        private System.Windows.Forms.Button adauga_btn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label add_label;
        private System.Windows.Forms.TextBox prenume_txt;
        private System.Windows.Forms.TextBox nume_txt;
        private System.Windows.Forms.TextBox pass_txt;
        private System.Windows.Forms.TextBox nick_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel sterge_pnl;
        private System.Windows.Forms.Label sterge_lbl;
        private System.Windows.Forms.DataGridView date_dgv;
        private System.Windows.Forms.Panel modifica_pnl;
        private System.Windows.Forms.Label modifica_lbl;
        private System.Windows.Forms.DataGridView modifica_dgv;
    }
}