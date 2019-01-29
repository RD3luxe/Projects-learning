namespace OTI2009
{
    partial class Calculator
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sum_btn = new System.Windows.Forms.Button();
            this.inm_button = new System.Windows.Forms.Button();
            this.diff_btn = new System.Windows.Forms.Button();
            this.impartire_btn = new System.Windows.Forms.Button();
            this.nr1_txt = new System.Windows.Forms.TextBox();
            this.nr2_txt = new System.Windows.Forms.TextBox();
            this.rezultat_txt = new System.Windows.Forms.TextBox();
            this.square_btn = new System.Windows.Forms.Button();
            this.rad_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.quit_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nr.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nr.2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rezultat";
            // 
            // sum_btn
            // 
            this.sum_btn.Location = new System.Drawing.Point(264, 43);
            this.sum_btn.Name = "sum_btn";
            this.sum_btn.Size = new System.Drawing.Size(29, 23);
            this.sum_btn.TabIndex = 3;
            this.sum_btn.Text = "+";
            this.sum_btn.UseVisualStyleBackColor = true;
            this.sum_btn.Click += new System.EventHandler(this.sum_btn_Click);
            // 
            // inm_button
            // 
            this.inm_button.Location = new System.Drawing.Point(264, 101);
            this.inm_button.Name = "inm_button";
            this.inm_button.Size = new System.Drawing.Size(29, 23);
            this.inm_button.TabIndex = 4;
            this.inm_button.Text = "x";
            this.inm_button.UseVisualStyleBackColor = true;
            this.inm_button.Click += new System.EventHandler(this.inm_button_Click);
            // 
            // diff_btn
            // 
            this.diff_btn.Location = new System.Drawing.Point(330, 43);
            this.diff_btn.Name = "diff_btn";
            this.diff_btn.Size = new System.Drawing.Size(29, 23);
            this.diff_btn.TabIndex = 5;
            this.diff_btn.Text = "-";
            this.diff_btn.UseVisualStyleBackColor = true;
            this.diff_btn.Click += new System.EventHandler(this.diff_btn_Click);
            // 
            // impartire_btn
            // 
            this.impartire_btn.Location = new System.Drawing.Point(330, 101);
            this.impartire_btn.Name = "impartire_btn";
            this.impartire_btn.Size = new System.Drawing.Size(29, 23);
            this.impartire_btn.TabIndex = 6;
            this.impartire_btn.Text = "/";
            this.impartire_btn.UseVisualStyleBackColor = true;
            this.impartire_btn.Click += new System.EventHandler(this.impartire_btn_Click);
            // 
            // nr1_txt
            // 
            this.nr1_txt.Location = new System.Drawing.Point(66, 43);
            this.nr1_txt.Name = "nr1_txt";
            this.nr1_txt.Size = new System.Drawing.Size(148, 20);
            this.nr1_txt.TabIndex = 7;
            // 
            // nr2_txt
            // 
            this.nr2_txt.Location = new System.Drawing.Point(66, 74);
            this.nr2_txt.Name = "nr2_txt";
            this.nr2_txt.Size = new System.Drawing.Size(148, 20);
            this.nr2_txt.TabIndex = 8;
            // 
            // rezultat_txt
            // 
            this.rezultat_txt.Location = new System.Drawing.Point(66, 104);
            this.rezultat_txt.Name = "rezultat_txt";
            this.rezultat_txt.ReadOnly = true;
            this.rezultat_txt.Size = new System.Drawing.Size(148, 20);
            this.rezultat_txt.TabIndex = 9;
            // 
            // square_btn
            // 
            this.square_btn.Location = new System.Drawing.Point(39, 142);
            this.square_btn.Name = "square_btn";
            this.square_btn.Size = new System.Drawing.Size(75, 23);
            this.square_btn.TabIndex = 10;
            this.square_btn.Text = "^2";
            this.square_btn.UseVisualStyleBackColor = true;
            this.square_btn.Click += new System.EventHandler(this.square_btn_Click);
            // 
            // rad_btn
            // 
            this.rad_btn.Location = new System.Drawing.Point(139, 142);
            this.rad_btn.Name = "rad_btn";
            this.rad_btn.Size = new System.Drawing.Size(75, 23);
            this.rad_btn.TabIndex = 11;
            this.rad_btn.Text = "Radical";
            this.rad_btn.UseVisualStyleBackColor = true;
            this.rad_btn.Click += new System.EventHandler(this.rad_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(273, 142);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_btn.TabIndex = 12;
            this.delete_btn.Text = "Sterge";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // quit_btn
            // 
            this.quit_btn.Location = new System.Drawing.Point(273, 180);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(75, 23);
            this.quit_btn.TabIndex = 13;
            this.quit_btn.Text = "Iesire";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.quit_btn_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 215);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.rad_btn);
            this.Controls.Add(this.square_btn);
            this.Controls.Add(this.rezultat_txt);
            this.Controls.Add(this.nr2_txt);
            this.Controls.Add(this.nr1_txt);
            this.Controls.Add(this.impartire_btn);
            this.Controls.Add(this.diff_btn);
            this.Controls.Add(this.inm_button);
            this.Controls.Add(this.sum_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calculator_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sum_btn;
        private System.Windows.Forms.Button inm_button;
        private System.Windows.Forms.Button diff_btn;
        private System.Windows.Forms.Button impartire_btn;
        private System.Windows.Forms.TextBox nr1_txt;
        private System.Windows.Forms.TextBox nr2_txt;
        private System.Windows.Forms.TextBox rezultat_txt;
        private System.Windows.Forms.Button square_btn;
        private System.Windows.Forms.Button rad_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button quit_btn;
    }
}