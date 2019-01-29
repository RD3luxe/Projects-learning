namespace OTI2009
{
    partial class Database
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
            this.studenti_dgv = new System.Windows.Forms.DataGridView();
            this.add_btn = new System.Windows.Forms.Button();
            this.sterg_btn = new System.Windows.Forms.Button();
            this.media_btn = new System.Windows.Forms.Button();
            this.salvare_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studenti_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // studenti_dgv
            // 
            this.studenti_dgv.AllowUserToDeleteRows = false;
            this.studenti_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studenti_dgv.Location = new System.Drawing.Point(12, 13);
            this.studenti_dgv.Name = "studenti_dgv";
            this.studenti_dgv.Size = new System.Drawing.Size(573, 264);
            this.studenti_dgv.TabIndex = 0;
            this.studenti_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studenti_dgv_CellClick);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(71, 295);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(75, 23);
            this.add_btn.TabIndex = 1;
            this.add_btn.Text = "Adaug";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // sterg_btn
            // 
            this.sterg_btn.Location = new System.Drawing.Point(174, 295);
            this.sterg_btn.Name = "sterg_btn";
            this.sterg_btn.Size = new System.Drawing.Size(75, 23);
            this.sterg_btn.TabIndex = 2;
            this.sterg_btn.Text = "Sterg";
            this.sterg_btn.UseVisualStyleBackColor = true;
            this.sterg_btn.Click += new System.EventHandler(this.sterg_btn_Click);
            // 
            // media_btn
            // 
            this.media_btn.Location = new System.Drawing.Point(274, 295);
            this.media_btn.Name = "media_btn";
            this.media_btn.Size = new System.Drawing.Size(75, 23);
            this.media_btn.TabIndex = 3;
            this.media_btn.Text = "Media";
            this.media_btn.UseVisualStyleBackColor = true;
            this.media_btn.Click += new System.EventHandler(this.media_btn_Click);
            // 
            // salvare_btn
            // 
            this.salvare_btn.Location = new System.Drawing.Point(373, 295);
            this.salvare_btn.Name = "salvare_btn";
            this.salvare_btn.Size = new System.Drawing.Size(75, 23);
            this.salvare_btn.TabIndex = 4;
            this.salvare_btn.Text = "Salvare";
            this.salvare_btn.UseVisualStyleBackColor = true;
            this.salvare_btn.Click += new System.EventHandler(this.salvare_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(472, 295);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(75, 23);
            this.close_btn.TabIndex = 5;
            this.close_btn.Text = "Inchidere";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OrangeRed;
            this.ClientSize = new System.Drawing.Size(597, 337);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.salvare_btn);
            this.Controls.Add(this.media_btn);
            this.Controls.Add(this.sterg_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.studenti_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Database";
            this.Text = "Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Database_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.studenti_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView studenti_dgv;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button sterg_btn;
        private System.Windows.Forms.Button media_btn;
        private System.Windows.Forms.Button salvare_btn;
        private System.Windows.Forms.Button close_btn;
    }
}