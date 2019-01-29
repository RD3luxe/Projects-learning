namespace tester
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
            this.dgv_materii = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.materii_box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materii)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_materii
            // 
            this.dgv_materii.AllowUserToAddRows = false;
            this.dgv_materii.AllowUserToDeleteRows = false;
            this.dgv_materii.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgv_materii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materii.Location = new System.Drawing.Point(36, 226);
            this.dgv_materii.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_materii.Name = "dgv_materii";
            this.dgv_materii.ReadOnly = true;
            this.dgv_materii.Size = new System.Drawing.Size(591, 165);
            this.dgv_materii.TabIndex = 2;
            this.dgv_materii.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_materii_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(190, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Test De Cunoştiinţe Generale";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // materii_box
            // 
            this.materii_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.materii_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materii_box.FormattingEnabled = true;
            this.materii_box.Location = new System.Drawing.Point(36, 194);
            this.materii_box.Margin = new System.Windows.Forms.Padding(4);
            this.materii_box.Name = "materii_box";
            this.materii_box.Size = new System.Drawing.Size(201, 24);
            this.materii_box.TabIndex = 0;
            this.materii_box.SelectedIndexChanged += new System.EventHandler(this.materii_box_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(32, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alegeţi Categoria:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(682, 463);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_materii);
            this.Controls.Add(this.materii_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tester";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_materii;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox materii_box;
        private System.Windows.Forms.Label label2;
    }
}

