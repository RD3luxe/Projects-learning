namespace _2011
{
    partial class Form1
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
            this.rtChatBox = new System.Windows.Forms.RichTextBox();
            this.rtMessage = new System.Windows.Forms.RichTextBox();
            this.btIonel = new System.Windows.Forms.Button();
            this.btMaria = new System.Windows.Forms.Button();
            this.btDm = new System.Windows.Forms.Button();
            this.btLm = new System.Windows.Forms.Button();
            this.btSm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtChatBox
            // 
            this.rtChatBox.Location = new System.Drawing.Point(12, 12);
            this.rtChatBox.Name = "rtChatBox";
            this.rtChatBox.ReadOnly = true;
            this.rtChatBox.Size = new System.Drawing.Size(512, 200);
            this.rtChatBox.TabIndex = 0;
            this.rtChatBox.Text = "";
            // 
            // rtMessage
            // 
            this.rtMessage.Location = new System.Drawing.Point(81, 227);
            this.rtMessage.Name = "rtMessage";
            this.rtMessage.Size = new System.Drawing.Size(373, 29);
            this.rtMessage.TabIndex = 1;
            this.rtMessage.Text = "";
            // 
            // btIonel
            // 
            this.btIonel.Location = new System.Drawing.Point(460, 227);
            this.btIonel.Name = "btIonel";
            this.btIonel.Size = new System.Drawing.Size(63, 28);
            this.btIonel.TabIndex = 2;
            this.btIonel.Text = "Ionel";
            this.btIonel.UseVisualStyleBackColor = true;
            this.btIonel.Click += new System.EventHandler(this.btIonel_Click);
            // 
            // btMaria
            // 
            this.btMaria.Location = new System.Drawing.Point(12, 227);
            this.btMaria.Name = "btMaria";
            this.btMaria.Size = new System.Drawing.Size(63, 28);
            this.btMaria.TabIndex = 3;
            this.btMaria.Text = "Maria";
            this.btMaria.UseVisualStyleBackColor = true;
            this.btMaria.Click += new System.EventHandler(this.btMaria_Click);
            // 
            // btDm
            // 
            this.btDm.Location = new System.Drawing.Point(121, 273);
            this.btDm.Name = "btDm";
            this.btDm.Size = new System.Drawing.Size(286, 22);
            this.btDm.TabIndex = 4;
            this.btDm.Text = "Sterge fereastra mesaje";
            this.btDm.UseVisualStyleBackColor = true;
            this.btDm.Click += new System.EventHandler(this.btDm_Click);
            // 
            // btLm
            // 
            this.btLm.Location = new System.Drawing.Point(420, 273);
            this.btLm.Name = "btLm";
            this.btLm.Size = new System.Drawing.Size(103, 22);
            this.btLm.TabIndex = 5;
            this.btLm.Text = "Incarcare mesaje";
            this.btLm.UseVisualStyleBackColor = true;
            this.btLm.Click += new System.EventHandler(this.btLm_Click);
            // 
            // btSm
            // 
            this.btSm.Location = new System.Drawing.Point(12, 273);
            this.btSm.Name = "btSm";
            this.btSm.Size = new System.Drawing.Size(103, 22);
            this.btSm.TabIndex = 6;
            this.btSm.Text = "Salveaza mesaje";
            this.btSm.UseVisualStyleBackColor = true;
            this.btSm.Click += new System.EventHandler(this.btSm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 303);
            this.Controls.Add(this.btSm);
            this.Controls.Add(this.btLm);
            this.Controls.Add(this.btDm);
            this.Controls.Add(this.btMaria);
            this.Controls.Add(this.btIonel);
            this.Controls.Add(this.rtMessage);
            this.Controls.Add(this.rtChatBox);
            this.Name = "Form1";
            this.Text = "M E S S E N G E R";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtChatBox;
        private System.Windows.Forms.RichTextBox rtMessage;
        private System.Windows.Forms.Button btIonel;
        private System.Windows.Forms.Button btMaria;
        private System.Windows.Forms.Button btDm;
        private System.Windows.Forms.Button btLm;
        private System.Windows.Forms.Button btSm;
    }
}

