namespace OTI2012
{
    partial class CreateAccount
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nick_txt = new System.Windows.Forms.TextBox();
            this.nume_txt = new System.Windows.Forms.TextBox();
            this.prenume_txt = new System.Windows.Forms.TextBox();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.repass_txt = new System.Windows.Forms.TextBox();
            this.register_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(91, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nickname :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(89, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parola  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(88, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rescrie parola  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(90, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nume   :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(90, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Prenume   :";
            // 
            // nick_txt
            // 
            this.nick_txt.Location = new System.Drawing.Point(254, 72);
            this.nick_txt.Name = "nick_txt";
            this.nick_txt.Size = new System.Drawing.Size(149, 20);
            this.nick_txt.TabIndex = 5;
            // 
            // nume_txt
            // 
            this.nume_txt.Location = new System.Drawing.Point(254, 98);
            this.nume_txt.Name = "nume_txt";
            this.nume_txt.Size = new System.Drawing.Size(149, 20);
            this.nume_txt.TabIndex = 6;
            // 
            // prenume_txt
            // 
            this.prenume_txt.Location = new System.Drawing.Point(254, 125);
            this.prenume_txt.Name = "prenume_txt";
            this.prenume_txt.Size = new System.Drawing.Size(149, 20);
            this.prenume_txt.TabIndex = 7;
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(254, 151);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.PasswordChar = '*';
            this.pass_txt.Size = new System.Drawing.Size(149, 20);
            this.pass_txt.TabIndex = 8;
            this.pass_txt.Leave += new System.EventHandler(this.pass_txt_Leave);
            // 
            // repass_txt
            // 
            this.repass_txt.Location = new System.Drawing.Point(254, 177);
            this.repass_txt.Name = "repass_txt";
            this.repass_txt.PasswordChar = '*';
            this.repass_txt.Size = new System.Drawing.Size(149, 20);
            this.repass_txt.TabIndex = 9;
            this.repass_txt.Leave += new System.EventHandler(this.repass_txt_Leave);
            // 
            // register_btn
            // 
            this.register_btn.BackColor = System.Drawing.Color.Aqua;
            this.register_btn.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_btn.ForeColor = System.Drawing.Color.Red;
            this.register_btn.Location = new System.Drawing.Point(134, 240);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(225, 33);
            this.register_btn.TabIndex = 10;
            this.register_btn.Text = "Inregistrare";
            this.register_btn.UseVisualStyleBackColor = false;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // CreateAccount
            // 
            this.AcceptButton = this.register_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(503, 300);
            this.Controls.Add(this.register_btn);
            this.Controls.Add(this.repass_txt);
            this.Controls.Add(this.pass_txt);
            this.Controls.Add(this.prenume_txt);
            this.Controls.Add(this.nume_txt);
            this.Controls.Add(this.nick_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateAccount";
            this.Text = "Creaza cont";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateAccount_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nick_txt;
        private System.Windows.Forms.TextBox nume_txt;
        private System.Windows.Forms.TextBox prenume_txt;
        private System.Windows.Forms.TextBox pass_txt;
        private System.Windows.Forms.TextBox repass_txt;
        private System.Windows.Forms.Button register_btn;
    }
}