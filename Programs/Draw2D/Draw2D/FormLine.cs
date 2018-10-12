using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw2D
{
    public partial class FormLine : Form
    {
        private Line line;
        private Bitmap bitmap;
        private Random random = new Random();
        private int numRand;
        private List<Line> lineS = new List<Line>();

        public FormLine()
        {
            InitializeComponent();
        }

        private void button_drawLine_Click(object sender, EventArgs e)
        {
            // get location of point 1, point 2
            if (!get_p1p2())
            {
                return;
            }

            DrawLine drawLine = new DrawLine(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                drawLine.DDA(line, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                drawLine.Bresenham(line, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                drawLine.MidPoint(line, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("Xiaolin Wu"))
            {
                drawLine.XiaolinWu(line, Color.Blue);
            }

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private Boolean get_p1p2()
        {
            if (string.IsNullOrWhiteSpace(textBox_x1.Text) ||
                string.IsNullOrWhiteSpace(textBox_y1.Text) ||
                string.IsNullOrWhiteSpace(textBox_x2.Text) ||
                string.IsNullOrWhiteSpace(textBox_y2.Text))
            {
                MessageBox.Show("Missing x1, y1, x2, y2" + Environment.NewLine,
                    "Error");
                return false;
            }

            int x1, y1, x2, y2;
            if (!int.TryParse(textBox_x1.Text, out x1) ||
                !int.TryParse(textBox_y1.Text, out y1) ||
                !int.TryParse(textBox_x2.Text, out x2) ||
                !int.TryParse(textBox_y2.Text, out y2))
            {
                MessageBox.Show("Wrong format!" + Environment.NewLine +
                    "x1, y1, x2, y2 must be positive integer" + Environment.NewLine +
                    "x1, x2 must be less than " + bitmap.Width.ToString() + Environment.NewLine +
                    "y1, y2 must be less or qual than " + bitmap.Height.ToString() + Environment.NewLine,
                    "Error");
                return false;
            }
            line = new Line(new Point(x1, y1),
                new Point(x2, y2));

            if (!pointInside(line.p1) ||
                !pointInside(line.p2))
            {
                MessageBox.Show("x1, y1, x2, y2 is too big" + Environment.NewLine +
                    "x1, y1, x2, y2 must be positive integer" + Environment.NewLine +
                    "x1, x2 must be less than " + bitmap.Width.ToString() + Environment.NewLine +
                    "y1, y2 must be less than " + bitmap.Height.ToString() + Environment.NewLine,
                    "Error");
                return false;
            }

            return true;
        }

        private Boolean pointInside(Point p)
        {
            if (p.X < 0 || p.Y < 0 ||
                p.X >= bitmap.Width || p.Y >= bitmap.Height)
                return false;
            return true;
        }

        private void button_clearAll_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void FormLine_Load(object sender, EventArgs e)
        {
            // use bitmap for drawing
            bitmap = new Bitmap(pictureBox_draw.Width,
            pictureBox_draw.Height,
            PixelFormat.Format24bppRgb);

            // set bitmap to picture box
            pictureBox_draw.Image = bitmap;

            clearAll();

            // set up combo box for line drawing
            setComboBoxAlgo();
        }

        private void setComboBoxAlgo()
        {
            comboBox_algo.Items.Add("DDA");
            comboBox_algo.Items.Add("Bresenham");
            comboBox_algo.Items.Add("MidPoint");
            comboBox_algo.Items.Add("Xiaolin Wu");
            comboBox_algo.SelectedIndex = 0;
        }

        private void clearAll()
        {
            // graphics object
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            // free up resources
            graphics.Dispose();

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private void button_help_click(object sender, EventArgs e)
        {
            MessageBox.Show("Input:" + Environment.NewLine +
                "x1, y1 is cordinate of Point p1" + Environment.NewLine +
                "x2, y2 is cordinate of Point p2" + Environment.NewLine +
                "x1, y1, x2, y2 must be positive integer" + Environment.NewLine +
                "x1, x2 must be less than " + bitmap.Width.ToString() + Environment.NewLine +
                "y1, y2 must be less than " + bitmap.Height.ToString() + Environment.NewLine +
                Environment.NewLine +
                "You choose an algorithm (DDA, Bresenham, MidPoint, Xiaolin Wu)," + Environment.NewLine +
                "then press \"Draw Line\" button to draw a line from p1 to p2" + Environment.NewLine +
                "You can clear all drawings when you press \"Clear All\" button" + Environment.NewLine +
                Environment.NewLine +
                "If you want to draw random line, input the number of lines you want to draw, then press \"Draw Button\"" + Environment.NewLine +
                "First time press \"Draw Random\", the program automatically random generate a random list line" + Environment.NewLine +
                "Next time you press it, the program will use already-have random list line to draw" + Environment.NewLine +
                "To have new random list line, press \"Random Generate\"" + Environment.NewLine +
                "After drawing, the program will output the time it took to draw",
                "Help");
        }

        private void button_rand_click(object sender, EventArgs e)
        {
            if (!get_numRand())
            {
                return;
            }

            // clear all drawings before random
            clearAll();

            // if no random list line, or old one is not enough, create new one
            // otherwise, use the already have random list line
            if (lineS.Count < this.numRand)
            {
                randLineS(numRand);
            }

            // StopWatch object for calculating execution time of the algorithm
            // StartNew and Stop for make sure stopwatch is not redundant object
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            DrawLine drawLine2D = new DrawLine(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawLine2D.DDA(lineS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawLine2D.Bresenham(lineS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawLine2D.MidPoint(lineS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("Xiaolin Wu"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawLine2D.XiaolinWu(lineS[i], Color.Blue);
                }
                stopwatch.Stop();
            }

            // set running time to text box
            textBox_randLineTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private Boolean get_numRand()
        {
            if (string.IsNullOrWhiteSpace(textBox_randLineNum.Text))
            {
                MessageBox.Show("Number of lines to random is missing",
                    "Error");
                return false;
            }
            if (!int.TryParse(textBox_randLineNum.Text, out numRand))
            {
                MessageBox.Show("Number of lines to random is in wrong format",
                    "Error");
                return false;
            }
            if (numRand < 0)
            {
                MessageBox.Show("Number of lines to random must be positive integer",
                    "Error");
                return false;
            }

            return true;
        }

        private void randLineS(int num)
        {
            lineS.Clear();

            for (int i = 0; i < num; ++i)
            {
                lineS.Add(new Line(new Point(random.Next(bitmap.Width),
                    random.Next(bitmap.Height)),
                    new Point(random.Next(bitmap.Width),
                    random.Next(bitmap.Height))));
            }
        }

        private void button_randGen_Click(object sender, EventArgs e)
        {
            if (!get_numRand())
            {
                return;
            }
            randLineS(numRand);
        }
    }
}