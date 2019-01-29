namespace CIARO2015
{
    partial class Traseu
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
            this.inchide_btn = new System.Windows.Forms.Button();
            this.traseu_img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.traseu_img)).BeginInit();
            this.SuspendLayout();
            // 
            // inchide_btn
            // 
            this.inchide_btn.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inchide_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.inchide_btn.Location = new System.Drawing.Point(655, 494);
            this.inchide_btn.Name = "inchide_btn";
            this.inchide_btn.Size = new System.Drawing.Size(180, 28);
            this.inchide_btn.TabIndex = 0;
            this.inchide_btn.Text = "Inchidere";
            this.inchide_btn.UseVisualStyleBackColor = true;
            this.inchide_btn.Click += new System.EventHandler(this.inchide_btn_Click);
            // 
            // traseu_img
            // 
            this.traseu_img.Image = global::CIARO2015.Properties.Resources.MareaNeagra;
            this.traseu_img.Location = new System.Drawing.Point(12, 12);
            this.traseu_img.Name = "traseu_img";
            this.traseu_img.Size = new System.Drawing.Size(823, 476);
            this.traseu_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.traseu_img.TabIndex = 1;
            this.traseu_img.TabStop = false;
            this.traseu_img.Paint += new System.Windows.Forms.PaintEventHandler(this.traseu_img_Paint);
            // 
            // Traseu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 530);
            this.Controls.Add(this.traseu_img);
            this.Controls.Add(this.inchide_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Traseu";
            this.Text = "Traseu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Traseu_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.traseu_img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button inchide_btn;
        private System.Windows.Forms.PictureBox traseu_img;
    }
}