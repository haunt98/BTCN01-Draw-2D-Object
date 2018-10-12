﻿namespace Draw2D
{
    partial class FormHyperbol
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
            this.comboBox_algo = new System.Windows.Forms.ComboBox();
            this.button_draw = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_help = new System.Windows.Forms.Button();
            this.button_randGen = new System.Windows.Forms.Button();
            this.button_randDraw = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_randNum = new System.Windows.Forms.TextBox();
            this.textBox_randTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_draw = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_a = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_b = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose algorithm";
            // 
            // comboBox_algo
            // 
            this.comboBox_algo.FormattingEnabled = true;
            this.comboBox_algo.Location = new System.Drawing.Point(337, 14);
            this.comboBox_algo.Name = "comboBox_algo";
            this.comboBox_algo.Size = new System.Drawing.Size(121, 21);
            this.comboBox_algo.TabIndex = 1;
            // 
            // button_draw
            // 
            this.button_draw.Location = new System.Drawing.Point(464, 14);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(86, 23);
            this.button_draw.TabIndex = 2;
            this.button_draw.Text = "Draw Hyperbol";
            this.button_draw.UseVisualStyleBackColor = true;
            this.button_draw.Click += new System.EventHandler(this.button_draw_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(565, 17);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 3;
            this.button_clear.Text = "Clear All";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_help
            // 
            this.button_help.Location = new System.Drawing.Point(665, 17);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(75, 23);
            this.button_help.TabIndex = 4;
            this.button_help.Text = "Help";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // button_randGen
            // 
            this.button_randGen.Location = new System.Drawing.Point(243, 51);
            this.button_randGen.Name = "button_randGen";
            this.button_randGen.Size = new System.Drawing.Size(109, 23);
            this.button_randGen.TabIndex = 5;
            this.button_randGen.Text = "Random Generate";
            this.button_randGen.UseVisualStyleBackColor = true;
            this.button_randGen.Click += new System.EventHandler(this.button_randGen_Click);
            // 
            // button_randDraw
            // 
            this.button_randDraw.Location = new System.Drawing.Point(358, 51);
            this.button_randDraw.Name = "button_randDraw";
            this.button_randDraw.Size = new System.Drawing.Size(87, 23);
            this.button_randDraw.TabIndex = 6;
            this.button_randDraw.Text = "Draw Random";
            this.button_randDraw.UseVisualStyleBackColor = true;
            this.button_randDraw.Click += new System.EventHandler(this.button_randDraw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of hyperbols to random";
            // 
            // textBox_randNum
            // 
            this.textBox_randNum.Location = new System.Drawing.Point(621, 53);
            this.textBox_randNum.Name = "textBox_randNum";
            this.textBox_randNum.Size = new System.Drawing.Size(100, 20);
            this.textBox_randNum.TabIndex = 8;
            // 
            // textBox_randTime
            // 
            this.textBox_randTime.Enabled = false;
            this.textBox_randTime.Location = new System.Drawing.Point(621, 84);
            this.textBox_randTime.Name = "textBox_randTime";
            this.textBox_randTime.Size = new System.Drawing.Size(100, 20);
            this.textBox_randTime.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Time running random";
            // 
            // pictureBox_draw
            // 
            this.pictureBox_draw.Location = new System.Drawing.Point(41, 137);
            this.pictureBox_draw.Name = "pictureBox_draw";
            this.pictureBox_draw.Size = new System.Drawing.Size(699, 309);
            this.pictureBox_draw.TabIndex = 11;
            this.pictureBox_draw.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Point center";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "x";
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(101, 17);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(43, 20);
            this.textBox_x.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "y";
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(168, 17);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(43, 20);
            this.textBox_y.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "a";
            // 
            // textBox_a
            // 
            this.textBox_a.Location = new System.Drawing.Point(101, 48);
            this.textBox_a.Name = "textBox_a";
            this.textBox_a.Size = new System.Drawing.Size(43, 20);
            this.textBox_a.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "b";
            // 
            // textBox_b
            // 
            this.textBox_b.Location = new System.Drawing.Point(168, 48);
            this.textBox_b.Name = "textBox_b";
            this.textBox_b.Size = new System.Drawing.Size(43, 20);
            this.textBox_b.TabIndex = 20;
            // 
            // FormHyperbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 493);
            this.Controls.Add(this.textBox_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_a);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox_draw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_randTime);
            this.Controls.Add(this.textBox_randNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_randDraw);
            this.Controls.Add(this.button_randGen);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_draw);
            this.Controls.Add(this.comboBox_algo);
            this.Controls.Add(this.label1);
            this.Name = "FormHyperbol";
            this.Text = "Draw Hyperbol";
            this.Load += new System.EventHandler(this.FormHyperbol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_algo;
        private System.Windows.Forms.Button button_draw;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_randGen;
        private System.Windows.Forms.Button button_randDraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_randNum;
        private System.Windows.Forms.TextBox textBox_randTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox_draw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_a;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_b;
    }
}