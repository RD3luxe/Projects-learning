namespace OTI2012
{
    partial class ViewFrame
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
            this.lista_dgv = new System.Windows.Forms.DataGridView();
            this.test_lbl = new System.Windows.Forms.Label();
            this.box_materii = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.lista_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lista_dgv
            // 
            this.lista_dgv.AllowUserToAddRows = false;
            this.lista_dgv.AllowUserToDeleteRows = false;
            this.lista_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista_dgv.Location = new System.Drawing.Point(13, 121);
            this.lista_dgv.Name = "lista_dgv";
            this.lista_dgv.Size = new System.Drawing.Size(461, 308);
            this.lista_dgv.TabIndex = 0;
            this.lista_dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.lista_dgv_CellBeginEdit);
            this.lista_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lista_dgv_CellContentClick);
            this.lista_dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.lista_dgv_CellEndEdit);
            // 
            // test_lbl
            // 
            this.test_lbl.AutoSize = true;
            this.test_lbl.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_lbl.ForeColor = System.Drawing.Color.Olive;
            this.test_lbl.Location = new System.Drawing.Point(93, 9);
            this.test_lbl.Name = "test_lbl";
            this.test_lbl.Size = new System.Drawing.Size(159, 30);
            this.test_lbl.TabIndex = 1;
            this.test_lbl.Text = "Textele <elevului> \r\n     la <materia>";
            // 
            // box_materii
            // 
            this.box_materii.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_materii.FormattingEnabled = true;
            this.box_materii.Location = new System.Drawing.Point(13, 92);
            this.box_materii.Name = "box_materii";
            this.box_materii.Size = new System.Drawing.Size(157, 21);
            this.box_materii.TabIndex = 2;
            this.box_materii.SelectedIndexChanged += new System.EventHandler(this.box_materii_SelectedIndexChanged);
            // 
            // ViewFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 442);
            this.Controls.Add(this.box_materii);
            this.Controls.Add(this.test_lbl);
            this.Controls.Add(this.lista_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewFrame";
            this.Text = "Modificare";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewFrame_FormClosed);
            this.Load += new System.EventHandler(this.ViewFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lista_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lista_dgv;
        private System.Windows.Forms.Label test_lbl;
        private System.Windows.Forms.ComboBox box_materii;
    }
}