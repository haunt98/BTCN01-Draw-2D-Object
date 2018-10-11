namespace Draw2D
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose algorithm";
            // 
            // comboBox_algo
            // 
            this.comboBox_algo.FormattingEnabled = true;
            this.comboBox_algo.Location = new System.Drawing.Point(138, 22);
            this.comboBox_algo.Name = "comboBox_algo";
            this.comboBox_algo.Size = new System.Drawing.Size(121, 21);
            this.comboBox_algo.TabIndex = 1;
            // 
            // button_draw
            // 
            this.button_draw.Location = new System.Drawing.Point(285, 19);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(86, 23);
            this.button_draw.TabIndex = 2;
            this.button_draw.Text = "Draw Hyperbol";
            this.button_draw.UseVisualStyleBackColor = true;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(378, 22);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 3;
            this.button_clear.Text = "Clear All";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_help
            // 
            this.button_help.Location = new System.Drawing.Point(460, 19);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(75, 23);
            this.button_help.TabIndex = 4;
            this.button_help.Text = "Help";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // button_randGen
            // 
            this.button_randGen.Location = new System.Drawing.Point(138, 60);
            this.button_randGen.Name = "button_randGen";
            this.button_randGen.Size = new System.Drawing.Size(109, 23);
            this.button_randGen.TabIndex = 5;
            this.button_randGen.Text = "Random Generate";
            this.button_randGen.UseVisualStyleBackColor = true;
            this.button_randGen.Click += new System.EventHandler(this.button_randGen_Click);
            // 
            // button_randDraw
            // 
            this.button_randDraw.Location = new System.Drawing.Point(267, 60);
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
            this.label2.Location = new System.Drawing.Point(360, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of hyperbols to random";
            // 
            // textBox_randNum
            // 
            this.textBox_randNum.Location = new System.Drawing.Point(520, 65);
            this.textBox_randNum.Name = "textBox_randNum";
            this.textBox_randNum.Size = new System.Drawing.Size(100, 20);
            this.textBox_randNum.TabIndex = 8;
            // 
            // textBox_randTime
            // 
            this.textBox_randTime.Enabled = false;
            this.textBox_randTime.Location = new System.Drawing.Point(520, 91);
            this.textBox_randTime.Name = "textBox_randTime";
            this.textBox_randTime.Size = new System.Drawing.Size(100, 20);
            this.textBox_randTime.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Time running random";
            // 
            // pictureBox_draw
            // 
            this.pictureBox_draw.Location = new System.Drawing.Point(91, 137);
            this.pictureBox_draw.Name = "pictureBox_draw";
            this.pictureBox_draw.Size = new System.Drawing.Size(529, 158);
            this.pictureBox_draw.TabIndex = 11;
            this.pictureBox_draw.TabStop = false;
            // 
            // FormHyperbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 346);
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
    }
}