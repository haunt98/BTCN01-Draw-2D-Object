﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw2D
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button_openLineDraw_Click(object sender, EventArgs e)
        {
            FormLine formLine = new FormLine();
            formLine.Show();
        }

        private void button_helpMain_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press button to choose which shape to draw" + Environment.NewLine +
                "(line, circle, ellipse, parabol, hyperbool)",
                "Help");
        }

        private void button_openCircleDraw_Click(object sender, EventArgs e)
        {
            FormCircle formCircle = new FormCircle();
            formCircle.Show();
        }

        private void button_openEllipseDraw_Click(object sender, EventArgs e)
        {
            FormEllipse formEllipse = new FormEllipse();
            formEllipse.Show();
        }

        private void button_openParabolDraw_Click(object sender, EventArgs e)
        {
            FormParabol formParabol = new FormParabol();
            formParabol.Show();
        }

        private void button_openHyperbolDraw_Click(object sender, EventArgs e)
        {
            FormHyperbol formHyperbol = new FormHyperbol();
            formHyperbol.Show();
        }
    }
}