namespace Draw2D
{
    partial class FormLine
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_x1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_y1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_x2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_y2 = new System.Windows.Forms.TextBox();
            this.button_drawLine = new System.Windows.Forms.Button();
            this.button_clearAllLine = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_algo = new System.Windows.Forms.ComboBox();
            this.pictureBox_draw = new System.Windows.Forms.PictureBox();
            this.button_helpLine = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_randDraw = new System.Windows.Forms.Button();
            this.textBox_randLineNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_randLineTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_randGen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x1";
            // 
            // textBox_x1
            // 
            this.textBox_x1.Location = new System.Drawing.Point(76, 8);
            this.textBox_x1.Name = "textBox_x1";
            this.textBox_x1.Size = new System.Drawing.Size(52, 20);
            this.textBox_x1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "y1";
            // 
            // textBox_y1
            // 
            this.textBox_y1.Location = new System.Drawing.Point(158, 8);
            this.textBox_y1.Name = "textBox_y1";
            this.textBox_y1.Size = new System.Drawing.Size(52, 20);
            this.textBox_y1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "x2";
            // 
            // textBox_x2
            // 
            this.textBox_x2.Location = new System.Drawing.Point(76, 34);
            this.textBox_x2.Name = "textBox_x2";
            this.textBox_x2.Size = new System.Drawing.Size(52, 20);
            this.textBox_x2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "y2";
            // 
            // textBox_y2
            // 
            this.textBox_y2.Location = new System.Drawing.Point(158, 35);
            this.textBox_y2.Name = "textBox_y2";
            this.textBox_y2.Size = new System.Drawing.Size(52, 20);
            this.textBox_y2.TabIndex = 7;
            // 
            // button_drawLine
            // 
            this.button_drawLine.Location = new System.Drawing.Point(445, 5);
            this.button_drawLine.Name = "button_drawLine";
            this.button_drawLine.Size = new System.Drawing.Size(75, 23);
            this.button_drawLine.TabIndex = 8;
            this.button_drawLine.Text = "Draw Line";
            this.button_drawLine.UseVisualStyleBackColor = true;
            this.button_drawLine.Click += new System.EventHandler(this.button_drawLine_Click);
            // 
            // button_clearAllLine
            // 
            this.button_clearAllLine.Location = new System.Drawing.Point(526, 5);
            this.button_clearAllLine.Name = "button_clearAllLine";
            this.button_clearAllLine.Size = new System.Drawing.Size(75, 23);
            this.button_clearAllLine.TabIndex = 9;
            this.button_clearAllLine.Text = "Clear All";
            this.button_clearAllLine.UseVisualStyleBackColor = true;
            this.button_clearAllLine.Click += new System.EventHandler(this.button_clearAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Choose algorithm";
            // 
            // comboBox_algo
            // 
            this.comboBox_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_algo.FormattingEnabled = true;
            this.comboBox_algo.Location = new System.Drawing.Point(318, 6);
            this.comboBox_algo.Name = "comboBox_algo";
            this.comboBox_algo.Size = new System.Drawing.Size(121, 21);
            this.comboBox_algo.TabIndex = 11;
            // 
            // pictureBox_draw
            // 
            this.pictureBox_draw.Location = new System.Drawing.Point(12, 64);
            this.pictureBox_draw.Name = "pictureBox_draw";
            this.pictureBox_draw.Size = new System.Drawing.Size(800, 375);
            this.pictureBox_draw.TabIndex = 12;
            this.pictureBox_draw.TabStop = false;
            // 
            // button_helpLine
            // 
            this.button_helpLine.Location = new System.Drawing.Point(607, 5);
            this.button_helpLine.Name = "button_helpLine";
            this.button_helpLine.Size = new System.Drawing.Size(75, 23);
            this.button_helpLine.TabIndex = 13;
            this.button_helpLine.Text = "Help";
            this.button_helpLine.UseVisualStyleBackColor = true;
            this.button_helpLine.Click += new System.EventHandler(this.button_help_click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Point p1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Point p2";
            // 
            // button_randDraw
            // 
            this.button_randDraw.Location = new System.Drawing.Point(325, 35);
            this.button_randDraw.Name = "button_randDraw";
            this.button_randDraw.Size = new System.Drawing.Size(85, 23);
            this.button_randDraw.TabIndex = 16;
            this.button_randDraw.Text = "Draw Random";
            this.button_randDraw.UseVisualStyleBackColor = true;
            this.button_randDraw.Click += new System.EventHandler(this.button_rand_click);
            // 
            // textBox_randLineNum
            // 
            this.textBox_randLineNum.Location = new System.Drawing.Point(552, 37);
            this.textBox_randLineNum.Name = "textBox_randLineNum";
            this.textBox_randLineNum.Size = new System.Drawing.Size(67, 20);
            this.textBox_randLineNum.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Number of lines to random";
            // 
            // textBox_randLineTime
            // 
            this.textBox_randLineTime.Enabled = false;
            this.textBox_randLineTime.Location = new System.Drawing.Point(737, 38);
            this.textBox_randLineTime.Name = "textBox_randLineTime";
            this.textBox_randLineTime.Size = new System.Drawing.Size(75, 20);
            this.textBox_randLineTime.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(625, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Time running random";
            // 
            // button_randGen
            // 
            this.button_randGen.Location = new System.Drawing.Point(216, 35);
            this.button_randGen.Name = "button_randGen";
            this.button_randGen.Size = new System.Drawing.Size(103, 23);
            this.button_randGen.TabIndex = 21;
            this.button_randGen.Text = "Random Generate";
            this.button_randGen.UseVisualStyleBackColor = true;
            this.button_randGen.Click += new System.EventHandler(this.button_randGen_Click);
            // 
            // FormLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 451);
            this.Controls.Add(this.button_randGen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_randLineTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_randLineNum);
            this.Controls.Add(this.button_randDraw);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_helpLine);
            this.Controls.Add(this.pictureBox_draw);
            this.Controls.Add(this.comboBox_algo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_clearAllLine);
            this.Controls.Add(this.button_drawLine);
            this.Controls.Add(this.textBox_y2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_x2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_y1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_x1);
            this.Controls.Add(this.label1);
            this.Name = "FormLine";
            this.Text = "Draw Line";
            this.Load += new System.EventHandler(this.FormLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_x1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_y1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_x2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_y2;
        private System.Windows.Forms.Button button_drawLine;
        private System.Windows.Forms.Button button_clearAllLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_algo;
        private System.Windows.Forms.PictureBox pictureBox_draw;
        private System.Windows.Forms.Button button_helpLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_randDraw;
        private System.Windows.Forms.TextBox textBox_randLineNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_randLineTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_randGen;
    }
}

