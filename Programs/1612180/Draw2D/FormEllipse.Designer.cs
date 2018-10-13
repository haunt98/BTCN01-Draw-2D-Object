namespace Draw2D
{
    partial class FormEllipse
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_a = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_b = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_algo = new System.Windows.Forms.ComboBox();
            this.button_draw = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_help = new System.Windows.Forms.Button();
            this.button_randGen = new System.Windows.Forms.Button();
            this.button_randDraw = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox_draw = new System.Windows.Forms.PictureBox();
            this.textBox_randNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_randTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Point center";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "x";
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(122, 10);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(50, 20);
            this.textBox_x.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "y";
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(198, 9);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(50, 20);
            this.textBox_y.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Radius of Ellipse";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "a";
            // 
            // textBox_a
            // 
            this.textBox_a.Location = new System.Drawing.Point(122, 36);
            this.textBox_a.Name = "textBox_a";
            this.textBox_a.Size = new System.Drawing.Size(50, 20);
            this.textBox_a.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "b";
            // 
            // textBox_b
            // 
            this.textBox_b.Location = new System.Drawing.Point(198, 37);
            this.textBox_b.Name = "textBox_b";
            this.textBox_b.Size = new System.Drawing.Size(50, 20);
            this.textBox_b.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Choose algorithm";
            // 
            // comboBox_algo
            // 
            this.comboBox_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_algo.FormattingEnabled = true;
            this.comboBox_algo.Location = new System.Drawing.Point(370, 9);
            this.comboBox_algo.Name = "comboBox_algo";
            this.comboBox_algo.Size = new System.Drawing.Size(86, 21);
            this.comboBox_algo.TabIndex = 11;
            // 
            // button_draw
            // 
            this.button_draw.Location = new System.Drawing.Point(462, 8);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(75, 23);
            this.button_draw.TabIndex = 12;
            this.button_draw.Text = "Draw Ellipse";
            this.button_draw.UseVisualStyleBackColor = true;
            this.button_draw.Click += new System.EventHandler(this.button_draw_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(543, 8);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 13;
            this.button_clear.Text = "Clear All";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_help
            // 
            this.button_help.Location = new System.Drawing.Point(624, 8);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(75, 23);
            this.button_help.TabIndex = 14;
            this.button_help.Text = "Help";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // button_randGen
            // 
            this.button_randGen.Location = new System.Drawing.Point(278, 37);
            this.button_randGen.Name = "button_randGen";
            this.button_randGen.Size = new System.Drawing.Size(105, 23);
            this.button_randGen.TabIndex = 15;
            this.button_randGen.Text = "Random Generate";
            this.button_randGen.UseVisualStyleBackColor = true;
            this.button_randGen.Click += new System.EventHandler(this.button_randGen_Click);
            // 
            // button_randDraw
            // 
            this.button_randDraw.Location = new System.Drawing.Point(389, 37);
            this.button_randDraw.Name = "button_randDraw";
            this.button_randDraw.Size = new System.Drawing.Size(105, 23);
            this.button_randDraw.TabIndex = 16;
            this.button_randDraw.Text = "Draw Random";
            this.button_randDraw.UseVisualStyleBackColor = true;
            this.button_randDraw.Click += new System.EventHandler(this.button_randDraw_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Number of ellipses to random";
            // 
            // pictureBox_draw
            // 
            this.pictureBox_draw.Location = new System.Drawing.Point(16, 101);
            this.pictureBox_draw.Name = "pictureBox_draw";
            this.pictureBox_draw.Size = new System.Drawing.Size(683, 384);
            this.pictureBox_draw.TabIndex = 18;
            this.pictureBox_draw.TabStop = false;
            // 
            // textBox_randNum
            // 
            this.textBox_randNum.Location = new System.Drawing.Point(645, 41);
            this.textBox_randNum.Name = "textBox_randNum";
            this.textBox_randNum.Size = new System.Drawing.Size(54, 20);
            this.textBox_randNum.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(533, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Time running random";
            // 
            // textBox_randTime
            // 
            this.textBox_randTime.Enabled = false;
            this.textBox_randTime.Location = new System.Drawing.Point(645, 68);
            this.textBox_randTime.Name = "textBox_randTime";
            this.textBox_randTime.Size = new System.Drawing.Size(54, 20);
            this.textBox_randTime.TabIndex = 21;
            // 
            // FormEllipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 497);
            this.Controls.Add(this.textBox_randTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_randNum);
            this.Controls.Add(this.pictureBox_draw);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_randDraw);
            this.Controls.Add(this.button_randGen);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_draw);
            this.Controls.Add(this.comboBox_algo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_b);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_a);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEllipse";
            this.Text = "Draw Ellipse";
            this.Load += new System.EventHandler(this.FormEllipse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_a;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_algo;
        private System.Windows.Forms.Button button_draw;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_randGen;
        private System.Windows.Forms.Button button_randDraw;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox_draw;
        private System.Windows.Forms.TextBox textBox_randNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_randTime;
    }
}