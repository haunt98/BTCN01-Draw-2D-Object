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
    public partial class FormCircle : Form
    {
        public FormCircle()
        {
            InitializeComponent();
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            if (!get_circle2D())
            {
                return;
            }

            DrawCircle drawCircle2D = new DrawCircle(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                drawCircle2D.DDA(circle, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                drawCircle2D.Bresenham(circle, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                drawCircle2D.MidPoint(circle, Color.Blue);
            }

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private Circle circle;
        private Bitmap bitmap;
        private Random random = new Random();
        private int numRand;
        private List<Circle> circleS = new List<Circle>();

        private Boolean get_circle2D()
        {
            int x, y, R;
            if (string.IsNullOrWhiteSpace(textBox_x.Text) ||
                string.IsNullOrWhiteSpace(textBox_y.Text) ||
                string.IsNullOrWhiteSpace(textBox_R.Text))
            {
                MessageBox.Show("Missing x, y, R",
                    "Error");
                return false;
            }
            if (!int.TryParse(textBox_x.Text, out x) ||
                !int.TryParse(textBox_y.Text, out y) ||
                !int.TryParse(textBox_R.Text, out R))
            {
                MessageBox.Show("Wrong format" + Environment.NewLine +
                    "x, y, R, x - R, y - R must be positive integer" + Environment.NewLine +
                    "x, x + R must be less than " + bitmap.Width + Environment.NewLine +
                    "y, y + R must be less than " + bitmap.Height + Environment.NewLine,
                    "Error");
                return false;
            }
            circle = new Circle(new Point(x, y), R);

            if (!circleInside())
            {
                MessageBox.Show("x, y, R value is not suitable" + Environment.NewLine +
                    "x, y, R, x - R, y - R must be positive integer" + Environment.NewLine +
                    "x, x + R must be less than " + bitmap.Width + Environment.NewLine +
                    "y, y + R must be less than " + bitmap.Height + Environment.NewLine,
                    "Error");
                return false;
            }

            return true;
        }

        private Boolean circleInside()
        {
            Point center = circle.center;
            int R = circle.R;

            if (center.X < 0 || center.Y < 0 || R < 0 ||
                center.X - R < 0 || center.Y - R < 0 ||
                center.X >= bitmap.Width ||
                center.X + R >= bitmap.Width ||
                center.Y >= bitmap.Height ||
                center.Y + R >= bitmap.Height)
            {
                return false;
            }
            return true;
        }

        private void FormCircle_Load(object sender, EventArgs e)
        {
            // use bitmap for drawing
            bitmap = new Bitmap(pictureBox_draw.Width,
            pictureBox_draw.Height,
            PixelFormat.Format24bppRgb);

            // set bitmap to picture box
            pictureBox_draw.Image = bitmap;

            clearAll();

            // set up combo box for circle drawing
            setComboBoxAlgo();
        }

        private void setComboBoxAlgo()
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

        private void button_clear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void button_randDraw_click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }

            // clear all drawings before random
            clearAll();

            // if no random list circle, or old one is not enough, create new one
            // otherwise, use the already have random list circle
            if (circleS.Count < this.numRand)
            {
                randCircleS(numRand);
            }

            // StopWatch object for calculating execution time of the algorithm
            // StartNew and Stop for make sure stopwatch is not redundant object
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            DrawCircle drawCircle2D = new DrawCircle(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawCircle2D.DDA(circleS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawCircle2D.Bresenham(circleS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawCircle2D.MidPoint(circleS[i], Color.Blue);
                }
                stopwatch.Stop();
            }

            // set running time to text box
            textBox_timeRand.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private void randCircleS(int num)
        {
            circleS.Clear();

            for (int i = 0; i < num; ++i)
            {
                int x = random.Next(bitmap.Width);
                int y = random.Next(bitmap.Height);
                int min_xy = x < y ? x : y;
                int min_wh = bitmap.Width - x < bitmap.Height - y
                    ? bitmap.Width - x : bitmap.Height - y;
                int min = min_xy < min_wh ? min_xy : min_wh;
                int R = random.Next(min);
                circleS.Add(new Circle(new Point(x, y), R));
            }
        }

        private Boolean get_randNum()
        {
            if (string.IsNullOrWhiteSpace(textBox_numRand.Text))
            {
                MessageBox.Show("Number of circles to random is missing",
                    "Error");
                return false;
            }
            if (!int.TryParse(textBox_numRand.Text, out numRand))
            {
                MessageBox.Show("Number of circles to random is in wrong format",
                    "Error");
                return false;
            }
            if (numRand < 0)
            {
                MessageBox.Show("Number of circles to random must be positive integer",
                    "Error");
                return false;
            }

            return true;
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Equation: X^2 + Y^2 = R^2" + Environment.NewLine +
                Environment.NewLine +
                "Input:" + Environment.NewLine +
                "x, y is cordinate of center point of circle" + Environment.NewLine +
                "R is radius of circle" + Environment.NewLine +
                "x, y, R, x - R, y - R must be positive integer" + Environment.NewLine +
                "x, x + R must be less than " + bitmap.Width + Environment.NewLine +
                "y, y + R must be less than " + bitmap.Height + Environment.NewLine +
                Environment.NewLine +
                "You choose an algorithm (DDA, Bresenham, MidPoint)," + Environment.NewLine +
                "then press \"Draw Circle\" button to draw a circle frrom point center and radius" + Environment.NewLine +
                "You can clear all drawings when you press \"Clear All\" button" + Environment.NewLine +
                Environment.NewLine +
                "If you want to draw random circle, input the number of circles you want to draw, then press \"Draw Random\"" + Environment.NewLine +
                "First time press \"Draw Random\", the program automatically random generate a random list circle" + Environment.NewLine +
                "Next time you press it, the program will use already-have random list circle to draw" + Environment.NewLine +
                "To have new random list circle, press \"Random Generate\"" + Environment.NewLine +
                "After drawing, the program will output the time it took to draw",
                "Help");
        }

        private void button_drawGen_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }
            randCircleS(numRand);
        }
    }
}