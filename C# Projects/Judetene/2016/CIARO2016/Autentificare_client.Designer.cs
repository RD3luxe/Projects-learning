namespace CIARO2016
{
    partial class Autentificare_client
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
            this.ComeIn_Btn = new System.Windows.Forms.Button();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(64, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adresa e-mail :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(64, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parola :";
            // 
            // ComeIn_Btn
            // 
            this.ComeIn_Btn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComeIn_Btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ComeIn_Btn.Location = new System.Drawing.Point(145, 133);
            this.ComeIn_Btn.Name = "ComeIn_Btn";
            this.ComeIn_Btn.Size = new System.Drawing.Size(155, 40);
            this.ComeIn_Btn.TabIndex = 2;
            this.ComeIn_Btn.Text = "Intra";
            this.ComeIn_Btn.UseVisualStyleBackColor = true;
            this.ComeIn_Btn.Click += new System.EventHandler(this.ComeIn_Btn_Click);
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(225, 50);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(136, 20);
            this.email_txt.TabIndex = 3;
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(225, 93);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.PasswordChar = '*';
            this.pass_txt.Size = new System.Drawing.Size(136, 20);
            this.pass_txt.TabIndex = 4;
            // 
            // Autentificare_client
            // 
            this.AcceptButton = this.ComeIn_Btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(445, 200);
            this.Controls.Add(this.pass_txt);
            this.Controls.Add(this.email_txt);
            this.Controls.Add(this.ComeIn_Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Autentificare_client";
            this.Text = "Autentificare_client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Autentificare_client_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ComeIn_Btn;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.TextBox pass_txt;
    }
}