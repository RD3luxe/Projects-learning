namespace OTI2012
{
    partial class TestForm
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
            this.image_p = new System.Windows.Forms.PictureBox();
            this.promovat_txt = new System.Windows.Forms.Label();
            this.rez_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_p)).BeginInit();
            this.SuspendLayout();
            // 
            // question_txt
            // 
            this.question_txt.AutoSize = true;
            this.question_txt.Font = new System.Drawing.Font("Lucida Handwriting", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.question_txt.Location = new System.Drawing.Point(98, 115);
            this.question_txt.Name = "question_txt";
            this.question_txt.Size = new System.Drawing.Size(129, 24);
            this.question_txt.TabIndex = 0;
            this.question_txt.Text = "Intrebare ?";
            // 
            // next_btn
            // 
            this.next_btn.Location = new System.Drawing.Point(685, 403);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(94, 30);
            this.next_btn.TabIndex = 1;
            this.next_btn.Text = "Next";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // prev_btn
            // 
            this.prev_btn.Location = new System.Drawing.Point(59, 403);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(94, 30);
            this.prev_btn.TabIndex = 2;
            this.prev_btn.Text = "Back";
            this.prev_btn.UseVisualStyleBackColor = true;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            // 
            // radio_pnl
            // 
            this.radio_pnl.Location = new System.Drawing.Point(74, 146);
            this.radio_pnl.Name = "radio_pnl";
            this.radio_pnl.Size = new System.Drawing.Size(659, 214);
            this.radio_pnl.TabIndex = 3;
            // 
            // nr_lbl
            // 
            this.nr_lbl.AutoSize = true;
            this.nr_lbl.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nr_lbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nr_lbl.Location = new System.Drawing.Point(577, 26);
            this.nr_lbl.Name = "nr_lbl";
            this.nr_lbl.Size = new System.Drawing.Size(67, 27);
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
            this.timp_lbl.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timp_lbl.ForeColor = System.Drawing.Color.Lime;
            this.timp_lbl.Location = new System.Drawing.Point(73, 26);
            this.timp_lbl.Name = "timp_lbl";
            this.timp_lbl.Size = new System.Drawing.Size(58, 26);
            this.timp_lbl.TabIndex = 5;
            this.timp_lbl.Text = "timer";
            // 
            // rez_panel
            // 
            this.rez_panel.BackColor = System.Drawing.Color.White;
            this.rez_panel.Controls.Add(this.image_p);
            this.rez_panel.Controls.Add(this.promovat_txt);
            this.rez_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rez_panel.Location = new System.Drawing.Point(0, 0);
            this.rez_panel.Name = "rez_panel";
            this.rez_panel.Size = new System.Drawing.Size(838, 462);
            this.rez_panel.TabIndex = 6;
            // 
            // image_p
            // 
            this.image_p.Location = new System.Drawing.Point(169, 158);
            this.image_p.Name = "image_p";
            this.image_p.Size = new System.Drawing.Size(130, 117);
            this.image_p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_p.TabIndex = 1;
            this.image_p.TabStop = false;
            // 
            // promovat_txt
            // 
            this.promovat_txt.AutoSize = true;
            this.promovat_txt.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promovat_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.promovat_txt.Location = new System.Drawing.Point(343, 185);
            this.promovat_txt.Name = "promovat_txt";
            this.promovat_txt.Size = new System.Drawing.Size(74, 30);
            this.promovat_txt.TabIndex = 0;
            this.promovat_txt.Text = "label1";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 462);
            this.Controls.Add(this.rez_panel);
            this.Controls.Add(this.timp_lbl);
            this.Controls.Add(this.nr_lbl);
            this.Controls.Add(this.radio_pnl);
            this.Controls.Add(this.prev_btn);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.question_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TestForm";
            this.Text = "Testul numarul <> / <>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestForm_FormClosing);
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.rez_panel.ResumeLayout(false);
            this.rez_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_p)).EndInit();
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
        private System.Windows.Forms.PictureBox image_p;
    }
}