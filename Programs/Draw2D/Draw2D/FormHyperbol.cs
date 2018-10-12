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
    public partial class FormHyperbol : Form
    {
        public FormHyperbol()
        {
            InitializeComponent();
        }

        private Bitmap bitmap;
        private Hyperbol hyperbol;
        private List<Hyperbol> hyperbolS = new List<Hyperbol>();
        private Random random = new Random();
        private int numRand;

        private void FormHyperbol_Load(object sender, EventArgs e)
        {
            // use bitmap for drawing
            bitmap = new Bitmap(pictureBox_draw.Width,
            pictureBox_draw.Height,
            PixelFormat.Format24bppRgb);

            // set bitmap to picture box
            pictureBox_draw.Image = bitmap;

            clearAll();

            // set up combo box for hyperbol drawing
            setComboBoxHyperbol();
        }

        private void setComboBoxHyperbol()
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

        private void button_randDraw_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }

            // clear all drawings before random
            clearAll();

            // if no random list hyperbol, or old one is not enough, create new one
            // otherwise, use the already have random list hyperbol
            if (hyperbolS.Count < this.numRand)
            {
                randHyperbolS(numRand);
            }

            // StopWatch object for calculating execution time of the algorithm
            // StartNew and Stop for make sure stopwatch is not redundant object
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            DrawHyperbol drawHyperbol = new DrawHyperbol(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawHyperbol.DDA(hyperbolS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawHyperbol.Bresenham(hyperbolS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawHyperbol.MidPoint(hyperbolS[i], Color.Blue);
                }
                stopwatch.Stop();
            }

            // set running time to text box
            textBox_randTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private void button_randGen_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }

            randHyperbolS(numRand);
        }

        private void randHyperbolS(int num)
        {
            hyperbolS.Clear();

            for (int i = 0; i < num; ++i)
            {
                int x = random.Next(bitmap.Width);
                int y = random.Next(bitmap.Height);
                int max_a = x < bitmap.Width - x ? x : bitmap.Width - x;
                if (max_a == 0)
                {
                    --i;
                    continue;
                }
                int a = random.Next(1, max_a);
                int b = random.Next(1, 100);
                hyperbolS.Add(new Hyperbol(new Point(x, y), a, b));
            }
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Equation: X^2/a^2 - Y^2/b^2" + Environment.NewLine +
                Environment.NewLine +
                "Input:" + Environment.NewLine +
                "x, y is cordinate of point top" + Environment.NewLine +
                "a, b is radius of hyperbol" + Environment.NewLine +
                "x, y, x - a must be non negative integer" + Environment.NewLine +
                "a, b must be positive integer" + Environment.NewLine +
                "x, x + a must be less than " + bitmap.Width + Environment.NewLine +
                "y must be less than " + bitmap.Height + Environment.NewLine +
                Environment.NewLine +
                "You choose an algorithm (DDA, Bresenham, MidPoint)," + Environment.NewLine +
                "then press \"Draw Hyperbol\" button to draw an hyperbol frrom point center and radius" + Environment.NewLine +
                "You can clear all drawings when you press \"Clear All\" button" + Environment.NewLine +
                Environment.NewLine +
                "If you want to draw random hyperbol, input the number of hyperbols you want to draw, then press \"Draw Random\"" + Environment.NewLine +
                "First time press \"Draw Random\", the program automatically random generate a random list hyperbol" + Environment.NewLine +
                "Next time you press it, the program will use already-have random list hyperbol to draw" + Environment.NewLine +
                "To have new random list hyperbol, press \"Random Generate\"" + Environment.NewLine +
                "After drawing, the program will output the time it took to draw",
                "Help");
        }

        private Boolean get_randNum()
        {
            if (string.IsNullOrWhiteSpace(textBox_randNum.Text))
            {
                MessageBox.Show("Number of hyperbols to random is missing",
                    "Error");
                return false;
            }
            if (!int.TryParse(textBox_randNum.Text, out numRand))
            {
                MessageBox.Show("Number of hyperbols to random is in wrong format",
                    "Error");
                return false;
            }
            if (numRand < 0)
            {
                MessageBox.Show("Number of hyperbols to random must be positive integer",
                    "Error");
                return false;
            }

            return true;
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            if (!get_hyperbol())
            {
                return;
            }

            DrawHyperbol drawHyperbol = new DrawHyperbol(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                drawHyperbol.DDA(hyperbol, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                drawHyperbol.Bresenham(hyperbol, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                drawHyperbol.MidPoint(hyperbol, Color.Blue);
            }
        }

        private bool get_hyperbol()
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
                    "x, y, x - a must be non negative integer" + Environment.NewLine +
                    "a, b must be positive integer" + Environment.NewLine +
                    "x, x + a must be less than " + bitmap.Width + Environment.NewLine +
                    "y must be less than " + bitmap.Height + Environment.NewLine +
                    "Error");
                return false;
            }
            if (x < 0 || x > bitmap.Width ||
                y < 0 || y > bitmap.Width ||
                a <= 0 || b <= 0)
            {
                MessageBox.Show("Wrong format" + Environment.NewLine +
                    "x, y, x - a must be non negative integer" + Environment.NewLine +
                    "a, b must be positive integer" + Environment.NewLine +
                    "x, x + a must be less than " + bitmap.Width + Environment.NewLine +
                    "y must be less than " + bitmap.Height + Environment.NewLine +
                    "Error");
                return false;
            }
            hyperbol = new Hyperbol(new Point(x, y), a, b);

            return true;
        }
    }
}