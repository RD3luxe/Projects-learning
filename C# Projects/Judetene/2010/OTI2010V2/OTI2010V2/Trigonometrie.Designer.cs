namespace OTI2010V2
{
    partial class Trigonometrie
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.sin_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.cos_btn = new System.Windows.Forms.Button();
            this.functii_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.functii_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // sin_btn
            // 
            this.sin_btn.Location = new System.Drawing.Point(179, 12);
            this.sin_btn.Name = "sin_btn";
            this.sin_btn.Size = new System.Drawing.Size(75, 23);
            this.sin_btn.TabIndex = 0;
            this.sin_btn.Text = "SIN";
            this.sin_btn.UseVisualStyleBackColor = true;
            this.sin_btn.Click += new System.EventHandler(this.sin_btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Iesire";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(341, 12);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_btn.TabIndex = 2;
            this.delete_btn.Text = "Sterge";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // cos_btn
            // 
            this.cos_btn.Location = new System.Drawing.Point(260, 12);
            this.cos_btn.Name = "cos_btn";
            this.cos_btn.Size = new System.Drawing.Size(75, 23);
            this.cos_btn.TabIndex = 3;
            this.cos_btn.Text = "COS";
            this.cos_btn.UseVisualStyleBackColor = true;
            this.cos_btn.Click += new System.EventHandler(this.cos_btn_Click);
            // 
            // functii_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.functii_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.functii_chart.Legends.Add(legend2);
            this.functii_chart.Location = new System.Drawing.Point(12, 41);
            this.functii_chart.Name = "functii_chart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.functii_chart.Series.Add(series2);
            this.functii_chart.Size = new System.Drawing.Size(700, 417);
            this.functii_chart.TabIndex = 4;
            this.functii_chart.Text = "chart1";
            // 
            // Trigonometrie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(724, 470);
            this.Controls.Add(this.functii_chart);
            this.Controls.Add(this.cos_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sin_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Trigonometrie";
            this.Text = "Trigonometrie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Trigonometrie_FormClosing);
            this.Load += new System.EventHandler(this.Trigonometrie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.functii_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sin_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button cos_btn;
        private System.Windows.Forms.DataVisualization.Charting.Chart functii_chart;
    }
}