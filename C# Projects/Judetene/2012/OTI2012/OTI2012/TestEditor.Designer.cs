namespace OTI2012
{
    partial class TestEditor
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
            this.tip_cmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.question_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.question_txt = new System.Windows.Forms.TextBox();
            this.answers_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.canswers_txt = new System.Windows.Forms.TextBox();
            this.next_btn = new System.Windows.Forms.Button();
            this.timp_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.delete_btn = new System.Windows.Forms.Button();
            this.back_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pct_txt = new System.Windows.Forms.TextBox();
            this.saveTime_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tip_cmb
            // 
            this.tip_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tip_cmb.FormattingEnabled = true;
            this.tip_cmb.Location = new System.Drawing.Point(215, 261);
            this.tip_cmb.Name = "tip_cmb";
            this.tip_cmb.Size = new System.Drawing.Size(146, 21);
            this.tip_cmb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(55, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tip :";
            // 
            // question_lbl
            // 
            this.question_lbl.AutoSize = true;
            this.question_lbl.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.question_lbl.Location = new System.Drawing.Point(192, 17);
            this.question_lbl.Name = "question_lbl";
            this.question_lbl.Size = new System.Drawing.Size(143, 21);
            this.question_lbl.TabIndex = 2;
            this.question_lbl.Text = "Intrebarea x/y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(52, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Intrebare :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(53, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Raspunsuri :";
            // 
            // question_txt
            // 
            this.question_txt.Location = new System.Drawing.Point(177, 120);
            this.question_txt.Multiline = true;
            this.question_txt.Name = "question_txt";
            this.question_txt.Size = new System.Drawing.Size(303, 30);
            this.question_txt.TabIndex = 5;
            this.question_txt.Enter += new System.EventHandler(this.save_old);
            this.question_txt.Leave += new System.EventHandler(this.question_txt_TextChanged);
            // 
            // answers_txt
            // 
            this.answers_txt.Location = new System.Drawing.Point(215, 156);
            this.answers_txt.Multiline = true;
            this.answers_txt.Name = "answers_txt";
            this.answers_txt.Size = new System.Drawing.Size(265, 96);
            this.answers_txt.TabIndex = 6;
            this.answers_txt.Enter += new System.EventHandler(this.save_old);
            this.answers_txt.Leave += new System.EventHandler(this.answers_txt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(54, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Raspuns corect :";
            // 
            // canswers_txt
            // 
            this.canswers_txt.Location = new System.Drawing.Point(215, 323);
            this.canswers_txt.Multiline = true;
            this.canswers_txt.Name = "canswers_txt";
            this.canswers_txt.Size = new System.Drawing.Size(267, 96);
            this.canswers_txt.TabIndex = 8;
            this.canswers_txt.Enter += new System.EventHandler(this.save_old);
            this.canswers_txt.Leave += new System.EventHandler(this.canswers_TextChanged);
            // 
            // next_btn
            // 
            this.next_btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.next_btn.Location = new System.Drawing.Point(375, 447);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(107, 30);
            this.next_btn.TabIndex = 9;
            this.next_btn.Text = "Next";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // timp_txt
            // 
            this.timp_txt.Location = new System.Drawing.Point(177, 87);
            this.timp_txt.Multiline = true;
            this.timp_txt.Name = "timp_txt";
            this.timp_txt.Size = new System.Drawing.Size(167, 27);
            this.timp_txt.TabIndex = 10;
            this.timp_txt.Enter += new System.EventHandler(this.save_old);
            this.timp_txt.Leave += new System.EventHandler(this.timp_txt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(54, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Timp :";
            // 
            // delete_btn
            // 
            this.delete_btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.delete_btn.Location = new System.Drawing.Point(173, 447);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(98, 30);
            this.delete_btn.TabIndex = 12;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // back_btn
            // 
            this.back_btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.back_btn.Location = new System.Drawing.Point(58, 447);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(101, 30);
            this.back_btn.TabIndex = 13;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.save_btn.Location = new System.Drawing.Point(285, 447);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 30);
            this.save_btn.TabIndex = 14;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(54, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Puncte :";
            // 
            // pct_txt
            // 
            this.pct_txt.Location = new System.Drawing.Point(215, 288);
            this.pct_txt.Multiline = true;
            this.pct_txt.Name = "pct_txt";
            this.pct_txt.Size = new System.Drawing.Size(146, 27);
            this.pct_txt.TabIndex = 16;
            this.pct_txt.Enter += new System.EventHandler(this.save_old);
            this.pct_txt.Leave += new System.EventHandler(this.pct_txt_TextChanged);
            // 
            // saveTime_btn
            // 
            this.saveTime_btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveTime_btn.ForeColor = System.Drawing.Color.Red;
            this.saveTime_btn.Location = new System.Drawing.Point(382, 83);
            this.saveTime_btn.Name = "saveTime_btn";
            this.saveTime_btn.Size = new System.Drawing.Size(98, 30);
            this.saveTime_btn.TabIndex = 17;
            this.saveTime_btn.Text = "Save";
            this.saveTime_btn.UseVisualStyleBackColor = true;
            this.saveTime_btn.Click += new System.EventHandler(this.save_Click);
            // 
            // TestEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(541, 504);
            this.Controls.Add(this.saveTime_btn);
            this.Controls.Add(this.pct_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timp_txt);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.canswers_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.answers_txt);
            this.Controls.Add(this.question_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.question_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tip_cmb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TestEditor";
            this.Text = "TestEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestEditor_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tip_cmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label question_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox question_txt;
        private System.Windows.Forms.TextBox answers_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox canswers_txt;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.TextBox timp_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pct_txt;
        private System.Windows.Forms.Button saveTime_btn;
    }
}