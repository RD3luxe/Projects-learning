namespace CIARO2014
{
    partial class Bursa
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
            this.timp_bursa = new System.Windows.Forms.Timer(this.components);
            this.btn_pnl = new System.Windows.Forms.Panel();
            this.rata_nr = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.close_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.utilizator_mn = new System.Windows.Forms.MenuStrip();
            this.utilizator = new System.Windows.Forms.ToolStripMenuItem();
            this.actiunileMele = new System.Windows.Forms.ToolStripMenuItem();
            this.graficProfit = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rata_nr)).BeginInit();
            this.utilizator_mn.SuspendLayout();
            this.SuspendLayout();
            // 
            // timp_bursa
            // 
            this.timp_bursa.Interval = 1;
            this.timp_bursa.Tick += new System.EventHandler(this.timp_bursa_Tick);
            // 
            // btn_pnl
            // 
            this.btn_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_pnl.Controls.Add(this.rata_nr);
            this.btn_pnl.Controls.Add(this.label1);
            this.btn_pnl.Controls.Add(this.close_btn);
            this.btn_pnl.Controls.Add(this.start_btn);
            this.btn_pnl.Location = new System.Drawing.Point(0, 12);
            this.btn_pnl.Name = "btn_pnl";
            this.btn_pnl.Size = new System.Drawing.Size(543, 44);
            this.btn_pnl.TabIndex = 0;
            // 
            // rata_nr
            // 
            this.rata_nr.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.rata_nr.Location = new System.Drawing.Point(402, 18);
            this.rata_nr.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rata_nr.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.rata_nr.Name = "rata_nr";
            this.rata_nr.ReadOnly = true;
            this.rata_nr.Size = new System.Drawing.Size(120, 20);
            this.rata_nr.TabIndex = 4;
            this.rata_nr.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.rata_nr.ValueChanged += new System.EventHandler(this.rata_nr_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rata reimprospatare :";
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(153, 15);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(105, 23);
            this.close_btn.TabIndex = 1;
            this.close_btn.Text = "Inchide bursa";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(22, 15);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(113, 23);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Deschide bursa";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // utilizator_mn
            // 
            this.utilizator_mn.BackColor = System.Drawing.Color.Gray;
            this.utilizator_mn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizator});
            this.utilizator_mn.Location = new System.Drawing.Point(0, 0);
            this.utilizator_mn.Name = "utilizator_mn";
            this.utilizator_mn.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.utilizator_mn.Size = new System.Drawing.Size(543, 24);
            this.utilizator_mn.TabIndex = 1;
            this.utilizator_mn.Text = "menuStrip1";
            // 
            // utilizator
            // 
            this.utilizator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actiunileMele,
            this.graficProfit});
            this.utilizator.Name = "utilizator";
            this.utilizator.Size = new System.Drawing.Size(66, 20);
            this.utilizator.Text = "Utilizator";
            // 
            // actiunileMele
            // 
            this.actiunileMele.Name = "actiunileMele";
            this.actiunileMele.Size = new System.Drawing.Size(150, 22);
            this.actiunileMele.Text = "Actiunile mele";
            this.actiunileMele.Click += new System.EventHandler(this.actiunileMele_Click);
            // 
            // graficProfit
            // 
            this.graficProfit.Name = "graficProfit";
            this.graficProfit.Size = new System.Drawing.Size(150, 22);
            this.graficProfit.Text = "Grafic profit";
            this.graficProfit.Click += new System.EventHandler(this.graficProfit_Click);
            // 
            // Bursa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(543, 395);
            this.Controls.Add(this.utilizator_mn);
            this.Controls.Add(this.btn_pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.utilizator_mn;
            this.MaximizeBox = false;
            this.Name = "Bursa";
            this.Text = "Bursa";
            this.btn_pnl.ResumeLayout(false);
            this.btn_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rata_nr)).EndInit();
            this.utilizator_mn.ResumeLayout(false);
            this.utilizator_mn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timp_bursa;
        private System.Windows.Forms.Panel btn_pnl;
        private System.Windows.Forms.MenuStrip utilizator_mn;
        private System.Windows.Forms.ToolStripMenuItem utilizator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.ToolStripMenuItem actiunileMele;
        private System.Windows.Forms.ToolStripMenuItem graficProfit;
        private System.Windows.Forms.NumericUpDown rata_nr;
    }
}