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

            // DrawCircle 2D object
            DrawCircle2D drawCircle2D = new DrawCircle2D(bitmap);
            if (comboBox_algo.Text.Equals("8-way symmetry"))
            {
                drawCircle2D.EightSymmetry(circle2D, Color.Blue);
            }

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private Circle2D circle2D;
        private Bitmap bitmap;
        private Random random = new Random();
        private int numRand;

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
                    "x, x + R must be less or equal than " + bitmap.Width + Environment.NewLine +
                    "y, y + R must be less or equal than " + bitmap.Height + Environment.NewLine,
                    "Error");
                return false;
            }
            circle2D = new Circle2D(new Point(x, y), R);

            if (!insidePictureBox())
            {
                MessageBox.Show("x, y, R value is not suitable" + Environment.NewLine +
                    "x, y, R, x - R, y - R must be positive integer" + Environment.NewLine +
                    "x, x + R must be less or equal than " + bitmap.Width + Environment.NewLine +
                    "y, y + R must be less or equal than " + bitmap.Height + Environment.NewLine,
                    "Error");
                return false;
            }

            return true;
        }

        private Boolean insidePictureBox()
        {
            Point center = circle2D.center;
            int R = circle2D.R;

            if (center.X < 0 || center.Y < 0 || R < 0 ||
                center.X - R < 0 || center.Y - R < 0 ||
                center.X > bitmap.Width ||
                center.X + R > bitmap.Width ||
                center.Y > bitmap.Height ||
                center.Y + R > bitmap.Height)
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

            clearAllDrawing();

            // set up combo box for circle drawing
            setComboBoxCircleDrawing();
        }

        private void setComboBoxCircleDrawing()
        {
            comboBox_algo.Items.Insert(0, "8-way symmetry");
            comboBox_algo.SelectedIndex = 0;
        }

        private void clearAllDrawing()
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
            clearAllDrawing();
        }

        private void button_rand_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }

            // clear all drawings before random
            clearAllDrawing();

            // get a random list of circle
            List<Circle2D> circle2DS = randListCircle2D(numRand);

            // StopWatch object for calculating execution time of the algorithm
            // StartNew and Stop for make sure stopwatch is not redundant object
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            // DrawCircle2D object
            DrawCircle2D drawCircle2D = new DrawCircle2D(bitmap);
            if (comboBox_algo.Text.Equals("8-way symmetry"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawCircle2D.EightSymmetry(circle2DS[i], Color.Blue);
                }
                stopwatch.Stop();
            }

            // set running time to text box
            textBox_timeRand.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private List<Circle2D> randListCircle2D(int numRand)
        {
            List<Circle2D> circle2DS = new List<Circle2D>();

            for (int i = 0; i < numRand; ++i)
            {
                int x = random.Next(bitmap.Width);
                int y = random.Next(bitmap.Height);
                int min_xy = x < y ? x : y;
                int min_wh = bitmap.Width - x < bitmap.Height - y
                    ? bitmap.Width - x : bitmap.Height - y;
                int min = min_xy < min_wh ? min_xy : min_wh;
                int R = random.Next(min);
                circle2DS.Add(new Circle2D(new Point(x, y), R));
            }

            return circle2DS;
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
            MessageBox.Show("x, y is cordinate of center point of circle" + Environment.NewLine +
                "R is radius of circle" + Environment.NewLine +
                "x, y, R, x - R, y - R must be positive integer" + Environment.NewLine +
                "x, x + R must be less or equal than " + bitmap.Width + Environment.NewLine +
                "y, y + R must be less or equal than " + bitmap.Height + Environment.NewLine,
                "Help");
        }
    }
}