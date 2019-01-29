namespace CIARO2016
{
    partial class Optiuni
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menu = new System.Windows.Forms.TabControl();
            this.calculator = new System.Windows.Forms.TabPage();
            this.g_txt = new System.Windows.Forms.TextBox();
            this.h_txt = new System.Windows.Forms.TextBox();
            this.varsta_txt = new System.Windows.Forms.TextBox();
            this.rez_txt = new System.Windows.Forms.TextBox();
            this.calc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.message_lb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comanda = new System.Windows.Forms.TabPage();
            this.pretTotal = new System.Windows.Forms.TextBox();
            this.totalKcal = new System.Windows.Forms.TextBox();
            this.nZilnic = new System.Windows.Forms.TextBox();
            this.comanda_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.meniu_dv = new System.Windows.Forms.DataGridView();
            this.gen_meniu = new System.Windows.Forms.TabPage();
            this.genMeniu_dv = new System.Windows.Forms.DataGridView();
            this.genereaza_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buget_txt = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grafic = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.grafic_kcal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menu.SuspendLayout();
            this.calculator.SuspendLayout();
            this.comanda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meniu_dv)).BeginInit();
            this.gen_meniu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genMeniu_dv)).BeginInit();
            this.grafic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafic_kcal)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Controls.Add(this.calculator);
            this.menu.Controls.Add(this.comanda);
            this.menu.Controls.Add(this.gen_meniu);
            this.menu.Controls.Add(this.grafic);
            this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Location = new System.Drawing.Point(0, 4);
            this.menu.Name = "menu";
            this.menu.SelectedIndex = 0;
            this.menu.Size = new System.Drawing.Size(651, 440);
            this.menu.TabIndex = 1;
            // 
            // calculator
            // 
            this.calculator.BackColor = System.Drawing.Color.Red;
            this.calculator.Controls.Add(this.g_txt);
            this.calculator.Controls.Add(this.h_txt);
            this.calculator.Controls.Add(this.varsta_txt);
            this.calculator.Controls.Add(this.rez_txt);
            this.calculator.Controls.Add(this.calc);
            this.calculator.Controls.Add(this.label4);
            this.calculator.Controls.Add(this.message_lb);
            this.calculator.Controls.Add(this.label2);
            this.calculator.Controls.Add(this.label1);
            this.calculator.Font = new System.Drawing.Font("Magneto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculator.ForeColor = System.Drawing.Color.Gold;
            this.calculator.Location = new System.Drawing.Point(4, 22);
            this.calculator.Name = "calculator";
            this.calculator.Padding = new System.Windows.Forms.Padding(3);
            this.calculator.Size = new System.Drawing.Size(643, 414);
            this.calculator.TabIndex = 0;
            this.calculator.Text = "CalculatorKcal";
            // 
            // g_txt
            // 
            this.g_txt.Font = new System.Drawing.Font("Magneto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_txt.Location = new System.Drawing.Point(239, 242);
            this.g_txt.Name = "g_txt";
            this.g_txt.Size = new System.Drawing.Size(130, 26);
            this.g_txt.TabIndex = 8;
            // 
            // h_txt
            // 
            this.h_txt.Font = new System.Drawing.Font("Magneto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.h_txt.Location = new System.Drawing.Point(239, 182);
            this.h_txt.Name = "h_txt";
            this.h_txt.Size = new System.Drawing.Size(130, 26);
            this.h_txt.TabIndex = 7;
            // 
            // varsta_txt
            // 
            this.varsta_txt.Font = new System.Drawing.Font("Magneto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varsta_txt.Location = new System.Drawing.Point(239, 122);
            this.varsta_txt.Name = "varsta_txt";
            this.varsta_txt.Size = new System.Drawing.Size(130, 26);
            this.varsta_txt.TabIndex = 6;
            // 
            // rez_txt
            // 
            this.rez_txt.Font = new System.Drawing.Font("Magneto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rez_txt.Location = new System.Drawing.Point(322, 338);
            this.rez_txt.Name = "rez_txt";
            this.rez_txt.ReadOnly = true;
            this.rez_txt.Size = new System.Drawing.Size(130, 26);
            this.rez_txt.TabIndex = 5;
            // 
            // calc
            // 
            this.calc.Font = new System.Drawing.Font("Magneto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calc.ForeColor = System.Drawing.Color.Crimson;
            this.calc.Location = new System.Drawing.Point(412, 167);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(183, 55);
            this.calc.TabIndex = 4;
            this.calc.Text = "Calculeaza";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Chartreuse;
            this.label4.Location = new System.Drawing.Point(52, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Greutate(kg) :";
            // 
            // message_lb
            // 
            this.message_lb.AutoSize = true;
            this.message_lb.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_lb.ForeColor = System.Drawing.Color.DarkBlue;
            this.message_lb.Location = new System.Drawing.Point(159, 338);
            this.message_lb.Name = "message_lb";
            this.message_lb.Size = new System.Drawing.Size(157, 27);
            this.message_lb.TabIndex = 2;
            this.message_lb.Text = "Necesar zilnic :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(52, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Inaltime(cm) :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(55, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Varsta(ani) :";
            // 
            // comanda
            // 
            this.comanda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.comanda.Controls.Add(this.pretTotal);
            this.comanda.Controls.Add(this.totalKcal);
            this.comanda.Controls.Add(this.nZilnic);
            this.comanda.Controls.Add(this.comanda_btn);
            this.comanda.Controls.Add(this.label6);
            this.comanda.Controls.Add(this.label5);
            this.comanda.Controls.Add(this.label3);
            this.comanda.Controls.Add(this.meniu_dv);
            this.comanda.ForeColor = System.Drawing.Color.Black;
            this.comanda.Location = new System.Drawing.Point(4, 22);
            this.comanda.Name = "comanda";
            this.comanda.Padding = new System.Windows.Forms.Padding(3);
            this.comanda.Size = new System.Drawing.Size(643, 414);
            this.comanda.TabIndex = 1;
            this.comanda.Text = "Comanda";
            // 
            // pretTotal
            // 
            this.pretTotal.Location = new System.Drawing.Point(165, 372);
            this.pretTotal.Name = "pretTotal";
            this.pretTotal.ReadOnly = true;
            this.pretTotal.Size = new System.Drawing.Size(100, 20);
            this.pretTotal.TabIndex = 7;
            // 
            // totalKcal
            // 
            this.totalKcal.Location = new System.Drawing.Point(164, 346);
            this.totalKcal.Name = "totalKcal";
            this.totalKcal.ReadOnly = true;
            this.totalKcal.Size = new System.Drawing.Size(100, 20);
            this.totalKcal.TabIndex = 6;
            // 
            // nZilnic
            // 
            this.nZilnic.Location = new System.Drawing.Point(164, 320);
            this.nZilnic.Name = "nZilnic";
            this.nZilnic.ReadOnly = true;
            this.nZilnic.Size = new System.Drawing.Size(100, 20);
            this.nZilnic.TabIndex = 5;
            // 
            // comanda_btn
            // 
            this.comanda_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.comanda_btn.Location = new System.Drawing.Point(387, 329);
            this.comanda_btn.Name = "comanda_btn";
            this.comanda_btn.Size = new System.Drawing.Size(196, 52);
            this.comanda_btn.TabIndex = 4;
            this.comanda_btn.Text = "Comanda ";
            this.comanda_btn.UseVisualStyleBackColor = true;
            this.comanda_btn.Click += new System.EventHandler(this.comanda_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Total Kcal :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Pret total :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Necesar zilnic :";
            // 
            // meniu_dv
            // 
            this.meniu_dv.AllowUserToAddRows = false;
            this.meniu_dv.AllowUserToDeleteRows = false;
            this.meniu_dv.BackgroundColor = System.Drawing.Color.Gray;
            this.meniu_dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.meniu_dv.GridColor = System.Drawing.Color.Black;
            this.meniu_dv.Location = new System.Drawing.Point(5, 3);
            this.meniu_dv.Name = "meniu_dv";
            this.meniu_dv.Size = new System.Drawing.Size(632, 283);
            this.meniu_dv.TabIndex = 0;
            this.meniu_dv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.meniu_dv_CellContentClick);
            this.meniu_dv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.meniu_dv_CellEndEdit);
            this.meniu_dv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.meniu_dv_CellValueChanged);
            // 
            // gen_meniu
            // 
            this.gen_meniu.BackColor = System.Drawing.Color.Peru;
            this.gen_meniu.Controls.Add(this.genMeniu_dv);
            this.gen_meniu.Controls.Add(this.genereaza_btn);
            this.gen_meniu.Controls.Add(this.label8);
            this.gen_meniu.Controls.Add(this.buget_txt);
            this.gen_meniu.Controls.Add(this.textBox1);
            this.gen_meniu.Controls.Add(this.label7);
            this.gen_meniu.Location = new System.Drawing.Point(4, 22);
            this.gen_meniu.Name = "gen_meniu";
            this.gen_meniu.Size = new System.Drawing.Size(643, 414);
            this.gen_meniu.TabIndex = 2;
            this.gen_meniu.Text = "Generare Meniu";
            // 
            // genMeniu_dv
            // 
            this.genMeniu_dv.AllowUserToAddRows = false;
            this.genMeniu_dv.AllowUserToDeleteRows = false;
            this.genMeniu_dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.genMeniu_dv.Location = new System.Drawing.Point(3, 107);
            this.genMeniu_dv.Name = "genMeniu_dv";
            this.genMeniu_dv.ReadOnly = true;
            this.genMeniu_dv.Size = new System.Drawing.Size(637, 304);
            this.genMeniu_dv.TabIndex = 5;
            this.genMeniu_dv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.genMeniu_dv_CellContentClick);
            // 
            // genereaza_btn
            // 
            this.genereaza_btn.Location = new System.Drawing.Point(425, 38);
            this.genereaza_btn.Name = "genereaza_btn";
            this.genereaza_btn.Size = new System.Drawing.Size(171, 37);
            this.genereaza_btn.TabIndex = 4;
            this.genereaza_btn.Text = "Genereaza";
            this.genereaza_btn.UseVisualStyleBackColor = true;
            this.genereaza_btn.Click += new System.EventHandler(this.genereaza_btn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Buget :";
            // 
            // buget_txt
            // 
            this.buget_txt.Location = new System.Drawing.Point(190, 64);
            this.buget_txt.Name = "buget_txt";
            this.buget_txt.Size = new System.Drawing.Size(100, 20);
            this.buget_txt.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(190, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Necesarul zilnic de kcal :";
            // 
            // grafic
            // 
            this.grafic.Controls.Add(this.label9);
            this.grafic.Controls.Add(this.grafic_kcal);
            this.grafic.Location = new System.Drawing.Point(4, 22);
            this.grafic.Name = "grafic";
            this.grafic.Size = new System.Drawing.Size(643, 414);
            this.grafic.TabIndex = 3;
            this.grafic.Text = "Grafic Kcal";
            this.grafic.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Grafic Kcal";
            // 
            // grafic_kcal
            // 
            chartArea1.Name = "ChartArea1";
            this.grafic_kcal.ChartAreas.Add(chartArea1);
            this.grafic_kcal.Location = new System.Drawing.Point(8, 25);
            this.grafic_kcal.Name = "grafic_kcal";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Kcal";
            this.grafic_kcal.Series.Add(series1);
            this.grafic_kcal.Size = new System.Drawing.Size(616, 366);
            this.grafic_kcal.TabIndex = 0;
            this.grafic_kcal.Text = "Grafic Kcal";
            // 
            // Optiuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 442);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Optiuni";
            this.Text = "Optiuni";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Optiuni_FormClosed);
            this.Load += new System.EventHandler(this.Optiuni_Load);
            this.menu.ResumeLayout(false);
            this.calculator.ResumeLayout(false);
            this.calculator.PerformLayout();
            this.comanda.ResumeLayout(false);
            this.comanda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meniu_dv)).EndInit();
            this.gen_meniu.ResumeLayout(false);
            this.gen_meniu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genMeniu_dv)).EndInit();
            this.grafic.ResumeLayout(false);
            this.grafic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafic_kcal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl menu;
        private System.Windows.Forms.TabPage calculator;
        private System.Windows.Forms.TabPage comanda;
        private System.Windows.Forms.TabPage gen_meniu;
        private System.Windows.Forms.TabPage grafic;
        private System.Windows.Forms.TextBox g_txt;
        private System.Windows.Forms.TextBox h_txt;
        private System.Windows.Forms.TextBox varsta_txt;
        private System.Windows.Forms.TextBox rez_txt;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label message_lb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView meniu_dv;
        private System.Windows.Forms.TextBox pretTotal;
        private System.Windows.Forms.TextBox totalKcal;
        private System.Windows.Forms.TextBox nZilnic;
        private System.Windows.Forms.Button comanda_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView genMeniu_dv;
        private System.Windows.Forms.Button genereaza_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox buget_txt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafic_kcal;
    }
}