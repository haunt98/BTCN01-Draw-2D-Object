namespace Draw2D
{
    partial class FormCircle
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_algo = new System.Windows.Forms.ComboBox();
            this.button_draw = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.pictureBox_draw = new System.Windows.Forms.PictureBox();
            this.button_randDraw = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_numRand = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_timeRand = new System.Windows.Forms.TextBox();
            this.button_help = new System.Windows.Forms.Button();
            this.button_drawGen = new System.Windows.Forms.Button();
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
            this.label2.Location = new System.Drawing.Point(83, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "y";
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(101, 11);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(57, 20);
            this.textBox_x.TabIndex = 3;
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(182, 11);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(57, 20);
            this.textBox_y.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "R";
            // 
            // textBox_R
            // 
            this.textBox_R.Location = new System.Drawing.Point(266, 11);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.Size = new System.Drawing.Size(57, 20);
            this.textBox_R.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(348, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Choose algorithm";
            // 
            // comboBox_algo
            // 
            this.comboBox_algo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_algo.FormattingEnabled = true;
            this.comboBox_algo.Location = new System.Drawing.Point(442, 10);
            this.comboBox_algo.Name = "comboBox_algo";
            this.comboBox_algo.Size = new System.Drawing.Size(121, 21);
            this.comboBox_algo.TabIndex = 8;
            // 
            // button_draw
            // 
            this.button_draw.Location = new System.Drawing.Point(569, 9);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(75, 23);
            this.button_draw.TabIndex = 9;
            this.button_draw.Text = "Draw Circle";
            this.button_draw.UseVisualStyleBackColor = true;
            this.button_draw.Click += new System.EventHandler(this.button_draw_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(650, 41);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 10;
            this.button_clear.Text = "Clear all";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // pictureBox_draw
            // 
            this.pictureBox_draw.Location = new System.Drawing.Point(16, 71);
            this.pictureBox_draw.Name = "pictureBox_draw";
            this.pictureBox_draw.Size = new System.Drawing.Size(709, 330);
            this.pictureBox_draw.TabIndex = 11;
            this.pictureBox_draw.TabStop = false;
            // 
            // button_randDraw
            // 
            this.button_randDraw.Location = new System.Drawing.Point(144, 39);
            this.button_randDraw.Name = "button_randDraw";
            this.button_randDraw.Size = new System.Drawing.Size(99, 23);
            this.button_randDraw.TabIndex = 12;
            this.button_randDraw.Text = "Draw Random";
            this.button_randDraw.UseVisualStyleBackColor = true;
            this.button_randDraw.Click += new System.EventHandler(this.button_randDraw_click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Number of circles to random";
            // 
            // textBox_numRand
            // 
            this.textBox_numRand.Location = new System.Drawing.Point(394, 42);
            this.textBox_numRand.Name = "textBox_numRand";
            this.textBox_numRand.Size = new System.Drawing.Size(57, 20);
            this.textBox_numRand.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(457, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Time running random";
            // 
            // textBox_timeRand
            // 
            this.textBox_timeRand.Enabled = false;
            this.textBox_timeRand.Location = new System.Drawing.Point(569, 42);
            this.textBox_timeRand.Name = "textBox_timeRand";
            this.textBox_timeRand.Size = new System.Drawing.Size(74, 20);
            this.textBox_timeRand.TabIndex = 16;
            // 
            // button_help
            // 
            this.button_help.Location = new System.Drawing.Point(650, 9);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(75, 23);
            this.button_help.TabIndex = 17;
            this.button_help.Text = "Help";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // button_drawGen
            // 
            this.button_drawGen.Location = new System.Drawing.Point(28, 39);
            this.button_drawGen.Name = "button_drawGen";
            this.button_drawGen.Size = new System.Drawing.Size(110, 23);
            this.button_drawGen.TabIndex = 18;
            this.button_drawGen.Text = "Random Generate";
            this.button_drawGen.UseVisualStyleBackColor = true;
            this.button_drawGen.Click += new System.EventHandler(this.button_drawGen_Click);
            // 
            // FormCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 420);
            this.Controls.Add(this.button_drawGen);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.textBox_timeRand);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_numRand);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_randDraw);
            this.Controls.Add(this.pictureBox_draw);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_draw);
            this.Controls.Add(this.comboBox_algo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_R);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCircle";
            this.Text = "Draw Circle 2D";
            this.Load += new System.EventHandler(this.FormCircle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_R;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_algo;
        private System.Windows.Forms.Button button_draw;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.PictureBox pictureBox_draw;
        private System.Windows.Forms.Button button_randDraw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_numRand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_timeRand;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_drawGen;
    }
}