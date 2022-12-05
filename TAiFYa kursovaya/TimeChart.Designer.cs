namespace TAiFYa_kursovaya
{
    partial class TimeChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.clearchart = new System.Windows.Forms.Button();
            this.checkstart = new System.Windows.Forms.CheckBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // clearchart
            // 
            this.clearchart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clearchart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearchart.Location = new System.Drawing.Point(105, 383);
            this.clearchart.Name = "clearchart";
            this.clearchart.Size = new System.Drawing.Size(163, 41);
            this.clearchart.TabIndex = 10;
            this.clearchart.Text = "Очистить";
            this.clearchart.UseVisualStyleBackColor = true;
            this.clearchart.Click += new System.EventHandler(this.clearchart_Click);
            // 
            // checkstart
            // 
            this.checkstart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkstart.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkstart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkstart.FlatAppearance.BorderSize = 2;
            this.checkstart.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.checkstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkstart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkstart.Location = new System.Drawing.Point(309, 383);
            this.checkstart.Name = "checkstart";
            this.checkstart.Size = new System.Drawing.Size(165, 42);
            this.checkstart.TabIndex = 9;
            this.checkstart.Text = "Старт";
            this.checkstart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkstart.UseVisualStyleBackColor = false;
            this.checkstart.CheckedChanged += new System.EventHandler(this.checkstart_CheckedChanged);
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(574, 361);
            this.chart.TabIndex = 8;
            this.chart.Text = "chart1";
            // 
            // TimeChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 437);
            this.ControlBox = false;
            this.Controls.Add(this.clearchart);
            this.Controls.Add(this.checkstart);
            this.Controls.Add(this.chart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeChart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Временная сложность";
            this.Load += new System.EventHandler(this.TimeChart_Load);
            this.ResizeBegin += new System.EventHandler(this.TimeChart_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.TimeChart_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clearchart;
        private System.Windows.Forms.CheckBox checkstart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}