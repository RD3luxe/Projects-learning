namespace CIARO2015
{
    partial class Administrare
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
            this.salvare_btn = new System.Windows.Forms.Button();
            this.actualizare_btn = new System.Windows.Forms.Button();
            this.lista_btn = new System.Windows.Forms.Button();
            this.generare_btn = new System.Windows.Forms.Button();
            this.initializare_btn = new System.Windows.Forms.Button();
            this.info_lb = new System.Windows.Forms.Label();
            this.harta_img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.harta_img)).BeginInit();
            this.SuspendLayout();
            // 
            // salvare_btn
            // 
            this.salvare_btn.BackColor = System.Drawing.Color.Aqua;
            this.salvare_btn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salvare_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.salvare_btn.Location = new System.Drawing.Point(841, 101);
            this.salvare_btn.Name = "salvare_btn";
            this.salvare_btn.Size = new System.Drawing.Size(162, 36);
            this.salvare_btn.TabIndex = 1;
            this.salvare_btn.Text = "Salvare coordonate";
            this.salvare_btn.UseVisualStyleBackColor = false;
            this.salvare_btn.Click += new System.EventHandler(this.salvare_btn_Click);
            // 
            // actualizare_btn
            // 
            this.actualizare_btn.BackColor = System.Drawing.Color.Aqua;
            this.actualizare_btn.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualizare_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.actualizare_btn.Location = new System.Drawing.Point(841, 233);
            this.actualizare_btn.Name = "actualizare_btn";
            this.actualizare_btn.Size = new System.Drawing.Size(162, 39);
            this.actualizare_btn.TabIndex = 2;
            this.actualizare_btn.Text = "Actualizare distante";
            this.actualizare_btn.UseVisualStyleBackColor = false;
            this.actualizare_btn.Click += new System.EventHandler(this.actualizare_btn_Click);
            // 
            // lista_btn
            // 
            this.lista_btn.BackColor = System.Drawing.Color.Aqua;
            this.lista_btn.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lista_btn.Location = new System.Drawing.Point(841, 398);
            this.lista_btn.Name = "lista_btn";
            this.lista_btn.Size = new System.Drawing.Size(162, 38);
            this.lista_btn.TabIndex = 3;
            this.lista_btn.Text = "Lista croaziere";
            this.lista_btn.UseVisualStyleBackColor = false;
            this.lista_btn.Click += new System.EventHandler(this.lista_btn_Click);
            // 
            // generare_btn
            // 
            this.generare_btn.BackColor = System.Drawing.Color.Aqua;
            this.generare_btn.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generare_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.generare_btn.Location = new System.Drawing.Point(841, 342);
            this.generare_btn.Name = "generare_btn";
            this.generare_btn.Size = new System.Drawing.Size(162, 37);
            this.generare_btn.TabIndex = 4;
            this.generare_btn.Text = "Generare croaziere";
            this.generare_btn.UseVisualStyleBackColor = false;
            this.generare_btn.Click += new System.EventHandler(this.generare_btn_Click);
            // 
            // initializare_btn
            // 
            this.initializare_btn.BackColor = System.Drawing.Color.Aqua;
            this.initializare_btn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initializare_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.initializare_btn.Location = new System.Drawing.Point(841, 43);
            this.initializare_btn.Name = "initializare_btn";
            this.initializare_btn.Size = new System.Drawing.Size(162, 40);
            this.initializare_btn.TabIndex = 0;
            this.initializare_btn.Text = "Initializare coordonate";
            this.initializare_btn.UseVisualStyleBackColor = false;
            this.initializare_btn.Click += new System.EventHandler(this.initializare_btn_Click);
            // 
            // info_lb
            // 
            this.info_lb.AutoSize = true;
            this.info_lb.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_lb.ForeColor = System.Drawing.Color.DarkOrange;
            this.info_lb.Location = new System.Drawing.Point(428, 13);
            this.info_lb.Name = "info_lb";
            this.info_lb.Size = new System.Drawing.Size(0, 20);
            this.info_lb.TabIndex = 6;
            this.info_lb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // harta_img
            // 
            this.harta_img.Image = global::CIARO2015.Properties.Resources.MareaNeagra;
            this.harta_img.Location = new System.Drawing.Point(12, 36);
            this.harta_img.Name = "harta_img";
            this.harta_img.Size = new System.Drawing.Size(823, 476);
            this.harta_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.harta_img.TabIndex = 5;
            this.harta_img.TabStop = false;
            this.harta_img.Click += new System.EventHandler(this.harta_img_Click);
            // 
            // Administrare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1015, 534);
            this.Controls.Add(this.info_lb);
            this.Controls.Add(this.harta_img);
            this.Controls.Add(this.generare_btn);
            this.Controls.Add(this.lista_btn);
            this.Controls.Add(this.actualizare_btn);
            this.Controls.Add(this.salvare_btn);
            this.Controls.Add(this.initializare_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Administrare";
            this.Text = "Lista croaziera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Administrare_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.harta_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button salvare_btn;
        private System.Windows.Forms.Button actualizare_btn;
        private System.Windows.Forms.Button lista_btn;
        private System.Windows.Forms.Button generare_btn;
        private System.Windows.Forms.Button initializare_btn;
        private System.Windows.Forms.PictureBox harta_img;
        private System.Windows.Forms.Label info_lb;
    }
}