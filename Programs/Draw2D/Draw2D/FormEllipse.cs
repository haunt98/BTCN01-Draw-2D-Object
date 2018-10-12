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
    public partial class FormEllipse : Form
    {
        public FormEllipse()
        {
            InitializeComponent();
        }

        private Bitmap bitmap;
        private Ellipse ellipse;
        private List<Ellipse> ellipseS = new List<Ellipse>();
        private Random random = new Random();
        private int numRand;

        private void FormEllipse_Load(object sender, EventArgs e)
        {
            // use bitmap for drawing
            bitmap = new Bitmap(pictureBox_draw.Width,
            pictureBox_draw.Height,
            PixelFormat.Format24bppRgb);

            // set bitmap to picture box
            pictureBox_draw.Image = bitmap;

            clearAll();

            // set up combo box for ellipse drawing
            setComboBoxEllipse();
        }

        private void setComboBoxEllipse()
        {
            comboBox_algo.Items.Add("DDA");
            comboBox_algo.Items.Add("Bresenham");
            comboBox_algo.Items.Add("MidPoint");
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

        private void button_draw_Click(object sender, EventArgs e)
        {
            if (!get_ellipse())
            {
                return;
            }

            DrawEllipse drawEllipse = new DrawEllipse(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                drawEllipse.DDA(ellipse, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                drawEllipse.Bresenham(ellipse, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                drawEllipse.MidPoint(ellipse, Color.Blue);
            }

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private Boolean get_ellipse()
        {
            if (string.IsNullOrWhiteSpace(textBox_x.Text) ||
                string.IsNullOrWhiteSpace(textBox_y.Text) ||
                string.IsNullOrWhiteSpace(textBox_a.Text) ||
                string.IsNullOrWhiteSpace(textBox_b.Text))
            {
                MessageBox.Show("Missing x, y, a, b",
                    "Error");
                return false;
            }

            int x, y, a, b;
            if (!int.TryParse(textBox_x.Text, out x) ||
                !int.TryParse(textBox_y.Text, out y) ||
                !int.TryParse(textBox_a.Text, out a) ||
                !int.TryParse(textBox_b.Text, out b))
            {
                MessageBox.Show("Wrong format" + Environment.NewLine +
                    "x, y must be non negative integer" + Environment.NewLine +
                    "a, b, x - a, y - b must be positive integer" + Environment.NewLine +
                    "x, x + a must be less than " + bitmap.Width + Environment.NewLine +
                    "y, y + b must be less than " + bitmap.Height + Environment.NewLine,
                    "Error");
                return false;
            }
            ellipse = new Ellipse(new Point(x, y), a, b);

            if (!ellipseInside())
            {
                MessageBox.Show("x, y, a, b value is not suitable" + Environment.NewLine +
                    "x, y must be non negative integer" + Environment.NewLine +
                    "a, b, x - a, y - b must be positive integer" + Environment.NewLine +
                    "x, x + a must be less than " + bitmap.Width + Environment.NewLine +
                    "y, y + b must be less than " + bitmap.Height + Environment.NewLine,
                    "Error");
                return false;
            }

            return true;
        }

        private Boolean ellipseInside()
        {
            Point center = ellipse.center;
            int a = ellipse.a;
            int b = ellipse.b;
            if (center.X < 0 || center.X >= bitmap.Width ||
                center.Y < 0 || center.Y >= bitmap.Height ||
                a <= 0 || center.X - a < 0 || center.X + a >= bitmap.Width ||
                b <= 0 || center.Y - b < 0 || center.Y + b >= bitmap.Height)
                return false;
            return true;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void button_randGen_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }

            randEllipseS(numRand);
        }

        private void randEllipseS(int num)
        {
            ellipseS.Clear();

            for (int i = 0; i < num; ++i)
            {
                int x = random.Next(bitmap.Width);
                int y = random.Next(bitmap.Height);
                // a <= x and a <= bitmap.Width - x
                int max_a = x < bitmap.Width - x ? x : bitmap.Width - x;
                // max_a can be 0
                if (max_a == 0)
                {
                    --i;
                    continue;
                }
                int a = random.Next(1, max_a);
                // b <= y and b <= bitmap.Height - y
                int max_b = y < bitmap.Height - y ? y : bitmap.Height - y;
                if (max_b == 0)
                {
                    --i;
                    continue;
                }
                int b = random.Next(1, max_b);
                ellipseS.Add(new Ellipse(new Point(x, y), a, b));
            }
        }

        private void button_randDraw_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }

            // clear all drawings before random
            clearAll();

            // if no random list ellipse, or old one is not enough, create new one
            // otherwise, use the already have random list ellipse
            if (ellipseS.Count < this.numRand)
            {
                randEllipseS(numRand);
            }

            // StopWatch object for calculating execution time of the algorithm
            // StartNew and Stop for make sure stopwatch is not redundant object
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            DrawEllipse drawEllipse = new DrawEllipse(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawEllipse.DDA(ellipseS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawEllipse.Bresenham(ellipseS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawEllipse.MidPoint(ellipseS[i], Color.Blue);
                }
                stopwatch.Stop();
            }

            // set running time to text box
            textBox_randTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private Boolean get_randNum()
        {
            if (string.IsNullOrWhiteSpace(textBox_randNum.Text))
            {
                MessageBox.Show("Number of ellipses to random is missing",
                    "Error");
                return false;
            }
            if (!int.TryParse(textBox_randNum.Text, out numRand))
            {
                MessageBox.Show("Number of ellipses to random is in wrong format",
                    "Error");
                return false;
            }
            if (numRand < 0)
            {
                MessageBox.Show("Number of ellipses to random must be positive integer",
                    "Error");
                return false;
            }

            return true;
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Equation: X^2/a^2 + Y^2/b^2 = 1" + Environment.NewLine +
                Environment.NewLine +
                "Input:" + Environment.NewLine +
                "x, y is cordinate of center point of ellipse" + Environment.NewLine +
                "a, b is radius of ellipse" + Environment.NewLine +
                "x, y must be non negative integer" + Environment.NewLine +
                "a, b, x - a, y - b must be positive integer" + Environment.NewLine +
                "x, x + a must be less than " + bitmap.Width + Environment.NewLine +
                "y, y + b must be less than " + bitmap.Height + Environment.NewLine +
                Environment.NewLine +
                "You choose an algorithm (DDA, Bresenham, MidPoint)," + Environment.NewLine +
                "then press \"Draw Ellipse\" button to draw an ellipse frrom point center and radius" + Environment.NewLine +
                "You can clear all drawings when you press \"Clear All\" button" + Environment.NewLine +
                Environment.NewLine +
                "If you want to draw random ellipse, input the number of ellipses you want to draw, then press \"Draw Random\"" + Environment.NewLine +
                "First time press \"Draw Random\", the program automatically random generate a random list ellipse" + Environment.NewLine +
                "Next time you press it, the program will use already-have random list ellipse to draw" + Environment.NewLine +
                "To have new random list ellipse, press \"Random Generate\"" + Environment.NewLine +
                "After drawing, the program will output the time it took to draw",
                "Help");
        }
    }
}