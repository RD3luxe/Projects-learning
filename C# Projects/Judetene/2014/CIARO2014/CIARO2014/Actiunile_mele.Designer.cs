namespace CIARO2014
{
    partial class Actiunile_mele
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
            this.components = new System.ComponentModel.Container();
            this.actiuni_dv = new System.Windows.Forms.DataGridView();
            this.lb = new System.Windows.Forms.Label();
            this.total_txt = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.actiuni_dv)).BeginInit();
            this.SuspendLayout();
            // 
            // actiuni_dv
            // 
            this.actiuni_dv.AllowUserToAddRows = false;
            this.actiuni_dv.AllowUserToDeleteRows = false;
            this.actiuni_dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actiuni_dv.Location = new System.Drawing.Point(0, 0);
            this.actiuni_dv.Name = "actiuni_dv";
            this.actiuni_dv.ReadOnly = true;
            this.actiuni_dv.Size = new System.Drawing.Size(783, 316);
            this.actiuni_dv.TabIndex = 0;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Lucida Handwriting", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.Location = new System.Drawing.Point(12, 336);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(274, 24);
            this.lb.TabIndex = 1;
            this.lb.Text = "Profit / Pierdere total :";
            // 
            // total_txt
            // 
            this.total_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_txt.Location = new System.Drawing.Point(292, 336);
            this.total_txt.Name = "total_txt";
            this.total_txt.ReadOnly = true;
            this.total_txt.Size = new System.Drawing.Size(132, 22);
            this.total_txt.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Actiunile_mele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(783, 375);
            this.Controls.Add(this.total_txt);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.actiuni_dv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Actiunile_mele";
            this.Text = "Actiunile mele";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Actiunile_mele_FormClosed);
            this.Load += new System.EventHandler(this.Actiunile_mele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.actiuni_dv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView actiuni_dv;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox total_txt;
        private System.Windows.Forms.Timer timer1;
    }
}