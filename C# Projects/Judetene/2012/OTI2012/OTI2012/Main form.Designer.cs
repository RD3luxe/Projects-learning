namespace OTI2012
{
    partial class Main_form
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
            this.create_acc = new System.Windows.Forms.Label();
            this.log_in = new System.Windows.Forms.Button();
            this.user_txt = new System.Windows.Forms.TextBox();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(35, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(39, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // create_acc
            // 
            this.create_acc.AutoSize = true;
            this.create_acc.BackColor = System.Drawing.Color.Yellow;
            this.create_acc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create_acc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.create_acc.Location = new System.Drawing.Point(33, 155);
            this.create_acc.Name = "create_acc";
            this.create_acc.Size = new System.Drawing.Size(121, 13);
            this.create_acc.TabIndex = 2;
            this.create_acc.Text = "Creare cont nou student";
            this.create_acc.Click += new System.EventHandler(this.create_acc_Click);
            // 
            // log_in
            // 
            this.log_in.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_in.Location = new System.Drawing.Point(160, 145);
            this.log_in.Name = "log_in";
            this.log_in.Size = new System.Drawing.Size(133, 30);
            this.log_in.TabIndex = 3;
            this.log_in.Text = "Connect";
            this.log_in.UseVisualStyleBackColor = true;
            this.log_in.Click += new System.EventHandler(this.log_in_Click);
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(160, 68);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(133, 20);
            this.user_txt.TabIndex = 4;
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(160, 98);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.PasswordChar = '*';
            this.pass_txt.Size = new System.Drawing.Size(133, 20);
            this.pass_txt.TabIndex = 5;
            // 
            // Main_form
            // 
            this.AcceptButton = this.log_in;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(329, 210);
            this.Controls.Add(this.pass_txt);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.log_in);
            this.Controls.Add(this.create_acc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Main_form";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label create_acc;
        private System.Windows.Forms.Button log_in;
        private System.Windows.Forms.TextBox user_txt;
        private System.Windows.Forms.TextBox pass_txt;
    }
}