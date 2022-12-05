namespace TAiFYa_kursovaya
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.input = new System.Windows.Forms.TextBox();
            this.STTOut = new System.Windows.Forms.RichTextBox();
            this.STTstart = new System.Windows.Forms.Button();
            this.STTstep = new System.Windows.Forms.Button();
            this.showchart = new System.Windows.Forms.CheckBox();
            this.Mttstep = new System.Windows.Forms.Button();
            this.MTTstart = new System.Windows.Forms.Button();
            this.MTTOut = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.input.Location = new System.Drawing.Point(191, 38);
            this.input.Name = "input";
            this.input.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.input.Size = new System.Drawing.Size(323, 20);
            this.input.TabIndex = 3;
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            this.input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_KeyPress);
            this.input.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.input_PreviewKeyDown);
            // 
            // STTOut
            // 
            this.STTOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.STTOut.Location = new System.Drawing.Point(25, 114);
            this.STTOut.Name = "STTOut";
            this.STTOut.ReadOnly = true;
            this.STTOut.Size = new System.Drawing.Size(282, 381);
            this.STTOut.TabIndex = 4;
            this.STTOut.Text = "";
            // 
            // STTstart
            // 
            this.STTstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.STTstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.STTstart.Location = new System.Drawing.Point(182, 513);
            this.STTstart.Name = "STTstart";
            this.STTstart.Size = new System.Drawing.Size(125, 29);
            this.STTstart.TabIndex = 5;
            this.STTstart.Text = "Запустить";
            this.STTstart.UseVisualStyleBackColor = true;
            this.STTstart.Click += new System.EventHandler(this.button1_Click);
            // 
            // STTstep
            // 
            this.STTstep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.STTstep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.STTstep.Location = new System.Drawing.Point(25, 513);
            this.STTstep.Name = "STTstep";
            this.STTstep.Size = new System.Drawing.Size(128, 29);
            this.STTstep.TabIndex = 6;
            this.STTstep.Text = "Сделать Шаг";
            this.STTstep.UseVisualStyleBackColor = true;
            this.STTstep.Click += new System.EventHandler(this.button2_Click);
            // 
            // showchart
            // 
            this.showchart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showchart.Appearance = System.Windows.Forms.Appearance.Button;
            this.showchart.Image = ((System.Drawing.Image)(resources.GetObject("showchart.Image")));
            this.showchart.Location = new System.Drawing.Point(555, 0);
            this.showchart.Name = "showchart";
            this.showchart.Size = new System.Drawing.Size(91, 58);
            this.showchart.TabIndex = 8;
            this.showchart.UseVisualStyleBackColor = true;
            this.showchart.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Mttstep
            // 
            this.Mttstep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Mttstep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Mttstep.Location = new System.Drawing.Point(364, 513);
            this.Mttstep.Name = "Mttstep";
            this.Mttstep.Size = new System.Drawing.Size(128, 29);
            this.Mttstep.TabIndex = 11;
            this.Mttstep.Text = "Сделать Шаг";
            this.Mttstep.UseVisualStyleBackColor = true;
            this.Mttstep.Click += new System.EventHandler(this.Mttstep_Click);
            // 
            // MTTstart
            // 
            this.MTTstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MTTstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MTTstart.Location = new System.Drawing.Point(521, 513);
            this.MTTstart.Name = "MTTstart";
            this.MTTstart.Size = new System.Drawing.Size(125, 29);
            this.MTTstart.TabIndex = 10;
            this.MTTstart.Text = "Запустить";
            this.MTTstart.UseVisualStyleBackColor = true;
            this.MTTstart.Click += new System.EventHandler(this.MTTstart_Click);
            // 
            // MTTOut
            // 
            this.MTTOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MTTOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MTTOut.Location = new System.Drawing.Point(364, 114);
            this.MTTOut.Name = "MTTOut";
            this.MTTOut.ReadOnly = true;
            this.MTTOut.Size = new System.Drawing.Size(282, 381);
            this.MTTOut.TabIndex = 9;
            this.MTTOut.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Входное слово:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(482, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Алфавит: {0, 1}, Слово: {ww: w={0, 1}*}\r\n";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(21, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Одноленточная машина";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(360, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 28);
            this.label4.TabIndex = 15;
            this.label4.Text = "Многоленточная машина";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 567);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mttstep);
            this.Controls.Add(this.MTTstart);
            this.Controls.Add(this.MTTOut);
            this.Controls.Add(this.showchart);
            this.Controls.Add(this.STTstep);
            this.Controls.Add(this.STTstart);
            this.Controls.Add(this.STTOut);
            this.Controls.Add(this.input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Машина Тьюринга";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.RichTextBox STTOut;
        private System.Windows.Forms.Button STTstart;
        private System.Windows.Forms.Button STTstep;
        private System.Windows.Forms.CheckBox showchart;
        private System.Windows.Forms.Button Mttstep;
        private System.Windows.Forms.Button MTTstart;
        private System.Windows.Forms.RichTextBox MTTOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

