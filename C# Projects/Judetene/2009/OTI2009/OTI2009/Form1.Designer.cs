namespace OTI2009
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calculator = new System.Windows.Forms.ToolStripMenuItem();
            this.turn = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.quit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculator,
            this.turn,
            this.dataBase,
            this.quit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(230, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // calculator
            // 
            this.calculator.Name = "calculator";
            this.calculator.Size = new System.Drawing.Size(73, 20);
            this.calculator.Text = "Calculator";
            this.calculator.Click += new System.EventHandler(this.calculator_Click);
            // 
            // turn
            // 
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(50, 20);
            this.turn.Text = "Rotire";
            this.turn.Click += new System.EventHandler(this.turn_Click);
            // 
            // dataBase
            // 
            this.dataBase.Name = "dataBase";
            this.dataBase.Size = new System.Drawing.Size(40, 20);
            this.dataBase.Text = "B.D.";
            this.dataBase.Click += new System.EventHandler(this.dataBase_Click);
            // 
            // quit
            // 
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(46, 20);
            this.quit.Text = "Iesire";
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 185);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "CIA 2009";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem calculator;
        private System.Windows.Forms.ToolStripMenuItem turn;
        private System.Windows.Forms.ToolStripMenuItem dataBase;
        private System.Windows.Forms.ToolStripMenuItem quit;
    }
}

