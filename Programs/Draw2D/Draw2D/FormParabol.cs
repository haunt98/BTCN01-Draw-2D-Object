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
    public partial class FormParabol : Form
    {
        public FormParabol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private Bitmap bitmap;
        private Parabol parabol;
        private List<Parabol> parabolS = new List<Parabol>();
        private Random random = new Random();
        private int numRand;

        private void FormParabol_Load(object sender, EventArgs e)
        {
            // use bitmap for drawing
            bitmap = new Bitmap(pictureBox_draw.Width,
            pictureBox_draw.Height,
            PixelFormat.Format24bppRgb);

            // set bitmap to picture box
            pictureBox_draw.Image = bitmap;

            clearAll();

            // set up combo box for parabol drawing
            setComboBoxParabol();
        }

        private void setComboBoxParabol()
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

        private void button_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Equation Y = (a/b) * X^2" + Environment.NewLine +
                Environment.NewLine +
                "Input:" + Environment.NewLine +
                "x, y must be non negative integer" + Environment.NewLine +
                "a, b must be positive integer" + Environment.NewLine +
                "x must be less than " + bitmap.Width + Environment.NewLine +
                "y must be less than " + bitmap.Height + Environment.NewLine +
                Environment.NewLine +
                "You choose an algorithm (DDA, Bresenham, MidPoint)," + Environment.NewLine +
                "then press \"Draw Parabol\" button to draw an parabol frrom point center and radius" + Environment.NewLine +
                "You can clear all drawings when you press \"Clear All\" button" + Environment.NewLine +
                Environment.NewLine +
                "If you want to draw random parabol, input the number of parabols you want to draw, then press \"Draw Random\"" + Environment.NewLine +
                "First time press \"Draw Random\", the program automatically random generate a random list parabol" + Environment.NewLine +
                "Next time you press it, the program will use already-have random list parabol to draw" + Environment.NewLine +
                "To have new random list parabol, press \"Random Generate\"" + Environment.NewLine +
                "After drawing, the program will output the time it took to draw",
                "Help");
        }

        private Boolean get_randNum()
        {
            if (string.IsNullOrWhiteSpace(textBox_randNum.Text))
            {
                MessageBox.Show("Number of parabols to random is missing",
                    "Error");
                return false;
            }
            if (!int.TryParse(textBox_randNum.Text, out numRand))
            {
                MessageBox.Show("Number of parabols to random is in wrong format",
                    "Error");
                return false;
            }
            if (numRand < 0)
            {
                MessageBox.Show("Number of parabols to random must be positive integer",
                    "Error");
                return false;
            }

            return true;
        }

        private void button_randGen_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }

            randParabolS(numRand);
        }

        private void button_randDraw_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }

            // clear all drawings before random
            clearAll();

            // if no random list parabol, or old one is not enough, create new one
            // otherwise, use the already have random list parabol
            if (parabolS.Count < this.numRand)
            {
                randParabolS(numRand);
            }

            // StopWatch object for calculating execution time of the algorithm
            // StartNew and Stop for make sure stopwatch is not redundant object
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            DrawParabol drawParabol = new DrawParabol(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawParabol.DDA(parabolS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawParabol.Bresenham(parabolS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawParabol.MidPoint(parabolS[i], Color.Blue);
                }
                stopwatch.Stop();
            }

            // set running time to text box
            textBox_randTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            if (!get_parabol())
            {
                return;
            }

            DrawParabol drawParapol = new DrawParabol(bitmap);
            if (comboBox_algo.Text.Equals("DDA"))
            {
                drawParapol.DDA(parabol, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("Bresenham"))
            {
                drawParapol.Bresenham(parabol, Color.Blue);
            }
            else if (comboBox_algo.Text.Equals("MidPoint"))
            {
                drawParapol.MidPoint(parabol, Color.Blue);
            }

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private Boolean get_parabol()
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
                    "a, b must be positive integer" + Environment.NewLine +
                    "x must be less than " + bitmap.Width + Environment.NewLine +
                    "y must be less than " + bitmap.Height + Environment.NewLine,
                    "Error");
                return false;
            }
            if (x < 0 || x > bitmap.Width ||
                y < 0 || y > bitmap.Width ||
                a <= 0 || b <= 0)
            {
                MessageBox.Show("Wrong format" + Environment.NewLine +
                    "x, y must be non negative integer" + Environment.NewLine +
                    "a, b must be positive integer" + Environment.NewLine +
                    "x must be less than " + bitmap.Width + Environment.NewLine +
                    "y must be less than " + bitmap.Height + Environment.NewLine,
                    "Error");
                return false;
            }
            parabol = new Parabol(new Point(x, y), a, b);

            return true;
        }

        private void randParabolS(int num)
        {
            parabolS.Clear();

            for (int i = 0; i < num; ++i)
            {
                int x = random.Next(bitmap.Width);
                int y = random.Next(bitmap.Height);
                int a = random.Next(1, 100);
                int b = random.Next(1, 100);
                parabolS.Add(new Parabol(new Point(x, y), a, b));
            }
        }
    }
}