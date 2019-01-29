namespace tester
{
    partial class test_form
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
            this.question_txt = new System.Windows.Forms.Label();
            this.next_btn = new System.Windows.Forms.Button();
            this.prev_btn = new System.Windows.Forms.Button();
            this.radio_pnl = new System.Windows.Forms.Panel();
            this.nr_lbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timp_lbl = new System.Windows.Forms.Label();
            this.rez_panel = new System.Windows.Forms.Panel();
            this.reset = new System.Windows.Forms.Button();
            this.promovat_txt = new System.Windows.Forms.Label();
            this.rez_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // question_txt
            // 
            this.question_txt.AutoSize = true;
            this.question_txt.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.question_txt.ForeColor = System.Drawing.Color.Black;
            this.question_txt.Location = new System.Drawing.Point(131, 142);
            this.question_txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.question_txt.Name = "question_txt";
            this.question_txt.Size = new System.Drawing.Size(170, 35);
            this.question_txt.TabIndex = 0;
            this.question_txt.Text = "Intrebare ?";
            // 
            // next_btn
            // 
            this.next_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.next_btn.Location = new System.Drawing.Point(913, 496);
            this.next_btn.Margin = new System.Windows.Forms.Padding(4);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(125, 37);
            this.next_btn.TabIndex = 1;
            this.next_btn.Text = "Next";
            this.next_btn.UseVisualStyleBackColor = false;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // prev_btn
            // 
            this.prev_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.prev_btn.Location = new System.Drawing.Point(79, 496);
            this.prev_btn.Margin = new System.Windows.Forms.Padding(4);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(125, 37);
            this.prev_btn.TabIndex = 2;
            this.prev_btn.Text = "Back";
            this.prev_btn.UseVisualStyleBackColor = false;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            // 
            // radio_pnl
            // 
            this.radio_pnl.Location = new System.Drawing.Point(99, 180);
            this.radio_pnl.Margin = new System.Windows.Forms.Padding(4);
            this.radio_pnl.Name = "radio_pnl";
            this.radio_pnl.Size = new System.Drawing.Size(879, 263);
            this.radio_pnl.TabIndex = 3;
            // 
            // nr_lbl
            // 
            this.nr_lbl.AutoSize = true;
            this.nr_lbl.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nr_lbl.ForeColor = System.Drawing.Color.Yellow;
            this.nr_lbl.Location = new System.Drawing.Point(769, 32);
            this.nr_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nr_lbl.Name = "nr_lbl";
            this.nr_lbl.Size = new System.Drawing.Size(81, 29);
            this.nr_lbl.TabIndex = 4;
            this.nr_lbl.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timp_lbl
            // 
            this.timp_lbl.AutoSize = true;
            this.timp_lbl.Font = new System.Drawing.Font("Arial", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timp_lbl.ForeColor = System.Drawing.Color.Red;
            this.timp_lbl.Location = new System.Drawing.Point(97, 32);
            this.timp_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timp_lbl.Name = "timp_lbl";
            this.timp_lbl.Size = new System.Drawing.Size(85, 33);
            this.timp_lbl.TabIndex = 5;
            this.timp_lbl.Text = "timer";
            // 
            // rez_panel
            // 
            this.rez_panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rez_panel.Controls.Add(this.reset);
            this.rez_panel.Controls.Add(this.promovat_txt);
            this.rez_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rez_panel.Location = new System.Drawing.Point(0, 0);
            this.rez_panel.Margin = new System.Windows.Forms.Padding(4);
            this.rez_panel.Name = "rez_panel";
            this.rez_panel.Size = new System.Drawing.Size(1146, 592);
            this.rez_panel.TabIndex = 6;
            this.rez_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.rez_panel_Paint);
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reset.ForeColor = System.Drawing.Color.Black;
            this.reset.Location = new System.Drawing.Point(284, 319);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(482, 121);
            this.reset.TabIndex = 2;
            this.reset.Text = "Înapoi la Tabelul cu Teste";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.button1_Click);
            // 
            // promovat_txt
            // 
            this.promovat_txt.AutoSize = true;
            this.promovat_txt.Font = new System.Drawing.Font("Arial", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.promovat_txt.ForeColor = System.Drawing.Color.Black;
            this.promovat_txt.Location = new System.Drawing.Point(306, 169);
            this.promovat_txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.promovat_txt.Name = "promovat_txt";
            this.promovat_txt.Size = new System.Drawing.Size(81, 29);
            this.promovat_txt.TabIndex = 0;
            this.promovat_txt.Text = "label1";
            this.promovat_txt.Click += new System.EventHandler(this.promovat_txt_Click);
            // 
            // test_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1146, 592);
            this.Controls.Add(this.rez_panel);
            this.Controls.Add(this.timp_lbl);
            this.Controls.Add(this.nr_lbl);
            this.Controls.Add(this.radio_pnl);
            this.Controls.Add(this.prev_btn);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.question_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "test_form";
            this.Text = "Testul numarul <> / <>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.test_form_FormClosing);
            this.Load += new System.EventHandler(this.test_form_Load);
            this.rez_panel.ResumeLayout(false);
            this.rez_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label question_txt;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button prev_btn;
        private System.Windows.Forms.Panel radio_pnl;
        private System.Windows.Forms.Label nr_lbl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timp_lbl;
        private System.Windows.Forms.Panel rez_panel;
        private System.Windows.Forms.Label promovat_txt;
        private System.Windows.Forms.Button reset;
    }
}