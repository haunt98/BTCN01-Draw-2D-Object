namespace Draw2D
{
    partial class FormMain
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
            this.button_openLineDraw = new System.Windows.Forms.Button();
            this.button_openCircleDraw = new System.Windows.Forms.Button();
            this.button_openEllipseDraw = new System.Windows.Forms.Button();
            this.button_openParabolDraw = new System.Windows.Forms.Button();
            this.button_openHyperbolDraw = new System.Windows.Forms.Button();
            this.button_helpMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_openLineDraw
            // 
            this.button_openLineDraw.Location = new System.Drawing.Point(12, 35);
            this.button_openLineDraw.Name = "button_openLineDraw";
            this.button_openLineDraw.Size = new System.Drawing.Size(75, 36);
            this.button_openLineDraw.TabIndex = 0;
            this.button_openLineDraw.Text = "Line Draw";
            this.button_openLineDraw.UseVisualStyleBackColor = true;
            this.button_openLineDraw.Click += new System.EventHandler(this.button_openLineDraw_Click);
            // 
            // button_openCircleDraw
            // 
            this.button_openCircleDraw.Location = new System.Drawing.Point(93, 35);
            this.button_openCircleDraw.Name = "button_openCircleDraw";
            this.button_openCircleDraw.Size = new System.Drawing.Size(75, 36);
            this.button_openCircleDraw.TabIndex = 1;
            this.button_openCircleDraw.Text = "Circle Draw";
            this.button_openCircleDraw.UseVisualStyleBackColor = true;
            this.button_openCircleDraw.Click += new System.EventHandler(this.button_openCircleDraw_Click);
            // 
            // button_openEllipseDraw
            // 
            this.button_openEllipseDraw.Location = new System.Drawing.Point(174, 35);
            this.button_openEllipseDraw.Name = "button_openEllipseDraw";
            this.button_openEllipseDraw.Size = new System.Drawing.Size(75, 36);
            this.button_openEllipseDraw.TabIndex = 2;
            this.button_openEllipseDraw.Text = "Ellipse Draw";
            this.button_openEllipseDraw.UseVisualStyleBackColor = true;
            this.button_openEllipseDraw.Click += new System.EventHandler(this.button_openEllipseDraw_Click);
            // 
            // button_openParabolDraw
            // 
            this.button_openParabolDraw.Location = new System.Drawing.Point(52, 77);
            this.button_openParabolDraw.Name = "button_openParabolDraw";
            this.button_openParabolDraw.Size = new System.Drawing.Size(75, 35);
            this.button_openParabolDraw.TabIndex = 3;
            this.button_openParabolDraw.Text = "Parabol Draw";
            this.button_openParabolDraw.UseVisualStyleBackColor = true;
            // 
            // button_openHyperbolDraw
            // 
            this.button_openHyperbolDraw.Location = new System.Drawing.Point(133, 77);
            this.button_openHyperbolDraw.Name = "button_openHyperbolDraw";
            this.button_openHyperbolDraw.Size = new System.Drawing.Size(75, 35);
            this.button_openHyperbolDraw.TabIndex = 4;
            this.button_openHyperbolDraw.Text = "Hyperbol Draw";
            this.button_openHyperbolDraw.UseVisualStyleBackColor = true;
            // 
            // button_helpMain
            // 
            this.button_helpMain.Location = new System.Drawing.Point(93, 153);
            this.button_helpMain.Name = "button_helpMain";
            this.button_helpMain.Size = new System.Drawing.Size(75, 35);
            this.button_helpMain.TabIndex = 5;
            this.button_helpMain.Text = "Help";
            this.button_helpMain.UseVisualStyleBackColor = true;
            this.button_helpMain.Click += new System.EventHandler(this.button_helpMain_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.button_helpMain);
            this.Controls.Add(this.button_openHyperbolDraw);
            this.Controls.Add(this.button_openParabolDraw);
            this.Controls.Add(this.button_openEllipseDraw);
            this.Controls.Add(this.button_openCircleDraw);
            this.Controls.Add(this.button_openLineDraw);
            this.Name = "FormMain";
            this.Text = "Draw 2D";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_openLineDraw;
        private System.Windows.Forms.Button button_openCircleDraw;
        private System.Windows.Forms.Button button_openEllipseDraw;
        private System.Windows.Forms.Button button_openParabolDraw;
        private System.Windows.Forms.Button button_openHyperbolDraw;
        private System.Windows.Forms.Button button_helpMain;
    }
}