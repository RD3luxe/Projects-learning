namespace CIARO2015
{
    partial class Operatii
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
            this.meniu = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // meniu
            // 
            this.meniu.Location = new System.Drawing.Point(0, 0);
            this.meniu.Name = "meniu";
            this.meniu.Size = new System.Drawing.Size(417, 24);
            this.meniu.TabIndex = 1;
            this.meniu.Text = "menuStrip1";
            this.meniu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.meniu_ItemClicked);
            // 
            // Operatii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 82);
            this.Controls.Add(this.meniu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.meniu;
            this.MaximizeBox = false;
            this.Name = "Operatii";
            this.Text = "Operatii";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Operatii_FormClosed);
            this.Load += new System.EventHandler(this.Operatii_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip meniu;
    }
}