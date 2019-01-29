namespace CIARO2015
{
    partial class Turist
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
            this.croaziere_dv = new System.Windows.Forms.DataGridView();
            this.date_start = new System.Windows.Forms.DateTimePicker();
            this.date_end = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.validare_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tip_lista = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.croaziere_dv)).BeginInit();
            this.SuspendLayout();
            // 
            // croaziere_dv
            // 
            this.croaziere_dv.AllowUserToAddRows = false;
            this.croaziere_dv.AllowUserToDeleteRows = false;
            this.croaziere_dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.croaziere_dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.croaziere_dv.Location = new System.Drawing.Point(30, 115);
            this.croaziere_dv.Name = "croaziere_dv";
            this.croaziere_dv.Size = new System.Drawing.Size(636, 330);
            this.croaziere_dv.TabIndex = 0;
            // 
            // date_start
            // 
            this.date_start.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.date_start.CustomFormat = "dd/mm/yyyy";
            this.date_start.Location = new System.Drawing.Point(769, 124);
            this.date_start.Name = "date_start";
            this.date_start.Size = new System.Drawing.Size(133, 20);
            this.date_start.TabIndex = 1;
            this.date_start.Value = new System.DateTime(2017, 1, 21, 7, 52, 54, 0);
            this.date_start.ValueChanged += new System.EventHandler(this.date_start_ValueChanged);
            // 
            // date_end
            // 
            this.date_end.Location = new System.Drawing.Point(769, 194);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(133, 20);
            this.date_end.TabIndex = 2;
            this.date_end.ValueChanged += new System.EventHandler(this.date_end_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(672, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(672, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data final :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(655, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stabiliti perioada voiajului :";
            // 
            // validare_btn
            // 
            this.validare_btn.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validare_btn.ForeColor = System.Drawing.Color.Purple;
            this.validare_btn.Location = new System.Drawing.Point(713, 267);
            this.validare_btn.Name = "validare_btn";
            this.validare_btn.Size = new System.Drawing.Size(161, 32);
            this.validare_btn.TabIndex = 6;
            this.validare_btn.Text = "Validare";
            this.validare_btn.UseVisualStyleBackColor = true;
            this.validare_btn.Click += new System.EventHandler(this.validare_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(25, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Selectati tipul de croaziera:";
            // 
            // tip_lista
            // 
            this.tip_lista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tip_lista.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tip_lista.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tip_lista.ForeColor = System.Drawing.Color.Red;
            this.tip_lista.FormattingEnabled = true;
            this.tip_lista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tip_lista.Location = new System.Drawing.Point(286, 47);
            this.tip_lista.Name = "tip_lista";
            this.tip_lista.Size = new System.Drawing.Size(167, 25);
            this.tip_lista.TabIndex = 8;
            this.tip_lista.SelectedIndexChanged += new System.EventHandler(this.tip_lista_SelectedIndexChanged);
            // 
            // Turist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(914, 469);
            this.Controls.Add(this.tip_lista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.validare_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.date_start);
            this.Controls.Add(this.croaziere_dv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Turist";
            this.Text = "Turist";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Turist_FormClosed);
            this.Load += new System.EventHandler(this.Turist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.croaziere_dv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView croaziere_dv;
        private System.Windows.Forms.DateTimePicker date_end;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button validare_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tip_lista;
        private System.Windows.Forms.DateTimePicker date_start;
    }
}