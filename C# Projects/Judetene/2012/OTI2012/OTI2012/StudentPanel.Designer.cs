namespace OTI2012
{
    partial class StudentPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.numepren_txt = new System.Windows.Forms.Label();
            this.logout_btn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.all_course = new System.Windows.Forms.TabPage();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_allcourse = new System.Windows.Forms.DataGridView();
            this.my_course = new System.Windows.Forms.TabPage();
            this.promovat_chk = new System.Windows.Forms.CheckBox();
            this.medie_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.materii_db = new System.Windows.Forms.ComboBox();
            this.mycourse_dgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.test = new System.Windows.Forms.TabPage();
            this.lblteste = new System.Windows.Forms.Label();
            this.teste_dgv = new System.Windows.Forms.DataGridView();
            this.grafic_note = new System.Windows.Forms.TabPage();
            this.materii_cb = new System.Windows.Forms.ComboBox();
            this.materii_note = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.all_course.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_allcourse)).BeginInit();
            this.my_course.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mycourse_dgv)).BeginInit();
            this.test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teste_dgv)).BeginInit();
            this.grafic_note.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materii_note)).BeginInit();
            this.SuspendLayout();
            // 
            // numepren_txt
            // 
            this.numepren_txt.AutoSize = true;
            this.numepren_txt.BackColor = System.Drawing.Color.White;
            this.numepren_txt.Font = new System.Drawing.Font("Script MT Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numepren_txt.ForeColor = System.Drawing.Color.DarkBlue;
            this.numepren_txt.Location = new System.Drawing.Point(628, 3);
            this.numepren_txt.Name = "numepren_txt";
            this.numepren_txt.Size = new System.Drawing.Size(160, 19);
            this.numepren_txt.TabIndex = 0;
            this.numepren_txt.Text = "Nume prenume student ";
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.Transparent;
            this.logout_btn.Font = new System.Drawing.Font("Lucida Handwriting", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_btn.ForeColor = System.Drawing.Color.DarkOrange;
            this.logout_btn.Location = new System.Drawing.Point(566, 0);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(62, 25);
            this.logout_btn.TabIndex = 1;
            this.logout_btn.Text = "Log out";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.all_course);
            this.tabControl1.Controls.Add(this.my_course);
            this.tabControl1.Controls.Add(this.test);
            this.tabControl1.Controls.Add(this.grafic_note);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 455);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // all_course
            // 
            this.all_course.BackColor = System.Drawing.Color.Lime;
            this.all_course.Controls.Add(this.refresh_btn);
            this.all_course.Controls.Add(this.label1);
            this.all_course.Controls.Add(this.dgv_allcourse);
            this.all_course.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all_course.Location = new System.Drawing.Point(4, 28);
            this.all_course.Name = "all_course";
            this.all_course.Padding = new System.Windows.Forms.Padding(3);
            this.all_course.Size = new System.Drawing.Size(774, 423);
            this.all_course.TabIndex = 0;
            this.all_course.Text = "Toate cursurile";
            // 
            // refresh_btn
            // 
            this.refresh_btn.Font = new System.Drawing.Font("Script MT Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.refresh_btn.Location = new System.Drawing.Point(23, 57);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(116, 26);
            this.refresh_btn.TabIndex = 2;
            this.refresh_btn.Text = "Refresh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Script MT Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(261, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Toate cursurile disponibile";
            // 
            // dgv_allcourse
            // 
            this.dgv_allcourse.AllowUserToAddRows = false;
            this.dgv_allcourse.AllowUserToDeleteRows = false;
            this.dgv_allcourse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv_allcourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_allcourse.Location = new System.Drawing.Point(25, 92);
            this.dgv_allcourse.Name = "dgv_allcourse";
            this.dgv_allcourse.ReadOnly = true;
            this.dgv_allcourse.Size = new System.Drawing.Size(725, 315);
            this.dgv_allcourse.TabIndex = 0;
            this.dgv_allcourse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_allcourse_CellClick);
            // 
            // my_course
            // 
            this.my_course.BackColor = System.Drawing.Color.Turquoise;
            this.my_course.Controls.Add(this.promovat_chk);
            this.my_course.Controls.Add(this.medie_txt);
            this.my_course.Controls.Add(this.label3);
            this.my_course.Controls.Add(this.materii_db);
            this.my_course.Controls.Add(this.mycourse_dgv);
            this.my_course.Controls.Add(this.label2);
            this.my_course.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.my_course.Location = new System.Drawing.Point(4, 28);
            this.my_course.Name = "my_course";
            this.my_course.Padding = new System.Windows.Forms.Padding(3);
            this.my_course.Size = new System.Drawing.Size(774, 423);
            this.my_course.TabIndex = 1;
            this.my_course.Text = "Cursurile mele";
            // 
            // promovat_chk
            // 
            this.promovat_chk.AutoSize = true;
            this.promovat_chk.Enabled = false;
            this.promovat_chk.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promovat_chk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.promovat_chk.Location = new System.Drawing.Point(402, 381);
            this.promovat_chk.Name = "promovat_chk";
            this.promovat_chk.Size = new System.Drawing.Size(95, 27);
            this.promovat_chk.TabIndex = 5;
            this.promovat_chk.Text = "Promovat";
            this.promovat_chk.UseVisualStyleBackColor = true;
            // 
            // medie_txt
            // 
            this.medie_txt.Location = new System.Drawing.Point(266, 383);
            this.medie_txt.Name = "medie_txt";
            this.medie_txt.ReadOnly = true;
            this.medie_txt.Size = new System.Drawing.Size(118, 22);
            this.medie_txt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(95, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Medie generala : ";
            // 
            // materii_db
            // 
            this.materii_db.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materii_db.FormattingEnabled = true;
            this.materii_db.Location = new System.Drawing.Point(18, 53);
            this.materii_db.Name = "materii_db";
            this.materii_db.Size = new System.Drawing.Size(159, 24);
            this.materii_db.TabIndex = 2;
            this.materii_db.SelectedIndexChanged += new System.EventHandler(this.materii_db_SelectedIndexChanged);
            // 
            // mycourse_dgv
            // 
            this.mycourse_dgv.AllowUserToAddRows = false;
            this.mycourse_dgv.AllowUserToDeleteRows = false;
            this.mycourse_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mycourse_dgv.Location = new System.Drawing.Point(17, 87);
            this.mycourse_dgv.Name = "mycourse_dgv";
            this.mycourse_dgv.ReadOnly = true;
            this.mycourse_dgv.Size = new System.Drawing.Size(740, 283);
            this.mycourse_dgv.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(244, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Informatii cursuri inscris";
            // 
            // test
            // 
            this.test.BackColor = System.Drawing.Color.CornflowerBlue;
            this.test.Controls.Add(this.lblteste);
            this.test.Controls.Add(this.teste_dgv);
            this.test.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test.Location = new System.Drawing.Point(4, 28);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(774, 423);
            this.test.TabIndex = 2;
            this.test.Text = "Teste";
            // 
            // lblteste
            // 
            this.lblteste.AutoSize = true;
            this.lblteste.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblteste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblteste.Location = new System.Drawing.Point(277, 14);
            this.lblteste.Name = "lblteste";
            this.lblteste.Size = new System.Drawing.Size(194, 27);
            this.lblteste.TabIndex = 1;
            this.lblteste.Text = "Teste disponibile";
            // 
            // teste_dgv
            // 
            this.teste_dgv.AllowUserToAddRows = false;
            this.teste_dgv.AllowUserToDeleteRows = false;
            this.teste_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teste_dgv.Location = new System.Drawing.Point(8, 103);
            this.teste_dgv.Name = "teste_dgv";
            this.teste_dgv.ReadOnly = true;
            this.teste_dgv.Size = new System.Drawing.Size(758, 312);
            this.teste_dgv.TabIndex = 0;
            this.teste_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.teste_dgv_CellClick);
            // 
            // grafic_note
            // 
            this.grafic_note.Controls.Add(this.materii_cb);
            this.grafic_note.Controls.Add(this.materii_note);
            this.grafic_note.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grafic_note.Location = new System.Drawing.Point(4, 28);
            this.grafic_note.Name = "grafic_note";
            this.grafic_note.Size = new System.Drawing.Size(774, 423);
            this.grafic_note.TabIndex = 3;
            this.grafic_note.Text = "Grafic note";
            this.grafic_note.UseVisualStyleBackColor = true;
            // 
            // materii_cb
            // 
            this.materii_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materii_cb.FormattingEnabled = true;
            this.materii_cb.Location = new System.Drawing.Point(49, 47);
            this.materii_cb.Name = "materii_cb";
            this.materii_cb.Size = new System.Drawing.Size(159, 24);
            this.materii_cb.TabIndex = 3;
            this.materii_cb.SelectedIndexChanged += new System.EventHandler(this.materii_cb_SelectedIndexChanged);
            // 
            // materii_note
            // 
            chartArea5.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea5.AxisY.MaximumAutoSize = 10F;
            chartArea5.Name = "ChartArea1";
            this.materii_note.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.materii_note.Legends.Add(legend5);
            this.materii_note.Location = new System.Drawing.Point(3, 77);
            this.materii_note.Name = "materii_note";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Teste";
            this.materii_note.Series.Add(series5);
            this.materii_note.Size = new System.Drawing.Size(768, 343);
            this.materii_note.TabIndex = 0;
            this.materii_note.Text = "chart1";
            // 
            // StudentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 455);
            this.Controls.Add(this.logout_btn);
            this.Controls.Add(this.numepren_txt);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StudentPanel";
            this.Text = "Panel student";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentPanel_FormClosing);
            this.Load += new System.EventHandler(this.StudentPanel_Load);
            this.tabControl1.ResumeLayout(false);
            this.all_course.ResumeLayout(false);
            this.all_course.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_allcourse)).EndInit();
            this.my_course.ResumeLayout(false);
            this.my_course.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mycourse_dgv)).EndInit();
            this.test.ResumeLayout(false);
            this.test.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teste_dgv)).EndInit();
            this.grafic_note.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.materii_note)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numepren_txt;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage all_course;
        private System.Windows.Forms.TabPage my_course;
        private System.Windows.Forms.TabPage test;
        private System.Windows.Forms.TabPage grafic_note;
        private System.Windows.Forms.DataVisualization.Charting.Chart materii_note;
        private System.Windows.Forms.DataGridView dgv_allcourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.DataGridView mycourse_dgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox materii_db;
        private System.Windows.Forms.CheckBox promovat_chk;
        private System.Windows.Forms.TextBox medie_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox materii_cb;
        private System.Windows.Forms.Label lblteste;
        private System.Windows.Forms.DataGridView teste_dgv;
    }
}