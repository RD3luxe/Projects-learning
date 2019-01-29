namespace CIARO2015
{
    partial class Lista_croaziere
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
            this.lista_zile = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.croaziere_dv = new System.Windows.Forms.DataGridView();
            this.cls_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.croaziere_dv)).BeginInit();
            this.SuspendLayout();
            // 
            // lista_zile
            // 
            this.lista_zile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lista_zile.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_zile.ForeColor = System.Drawing.Color.Red;
            this.lista_zile.FormattingEnabled = true;
            this.lista_zile.Location = new System.Drawing.Point(469, 22);
            this.lista_zile.Name = "lista_zile";
            this.lista_zile.Size = new System.Drawing.Size(238, 26);
            this.lista_zile.TabIndex = 0;
            this.lista_zile.SelectedValueChanged += new System.EventHandler(this.lista_zile_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selectati tipul de croaziera :";
            // 
            // croaziere_dv
            // 
            this.croaziere_dv.AllowUserToAddRows = false;
            this.croaziere_dv.AllowUserToDeleteRows = false;
            this.croaziere_dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.croaziere_dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.croaziere_dv.Location = new System.Drawing.Point(12, 74);
            this.croaziere_dv.Name = "croaziere_dv";
            this.croaziere_dv.ReadOnly = true;
            this.croaziere_dv.RowHeadersWidth = 60;
            this.croaziere_dv.Size = new System.Drawing.Size(878, 306);
            this.croaziere_dv.TabIndex = 2;
            // 
            // cls_btn
            // 
            this.cls_btn.BackColor = System.Drawing.Color.LawnGreen;
            this.cls_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cls_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cls_btn.Location = new System.Drawing.Point(728, 401);
            this.cls_btn.Name = "cls_btn";
            this.cls_btn.Size = new System.Drawing.Size(162, 33);
            this.cls_btn.TabIndex = 3;
            this.cls_btn.Text = "Inchidere";
            this.cls_btn.UseVisualStyleBackColor = false;
            this.cls_btn.Click += new System.EventHandler(this.cls_btn_Click);
            // 
            // Lista_croaziere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(902, 446);
            this.Controls.Add(this.cls_btn);
            this.Controls.Add(this.croaziere_dv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lista_zile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Lista_croaziere";
            this.Text = "Lista croaziere";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Lista_croaziere_FormClosed);
            this.Load += new System.EventHandler(this.Lista_croaziere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.croaziere_dv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox lista_zile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView croaziere_dv;
        private System.Windows.Forms.Button cls_btn;
    }
}