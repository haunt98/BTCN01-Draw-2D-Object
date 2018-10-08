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
        private Line2D line2D;
        private Bitmap bitmap;
        private Random random = new Random();
        private int numRand;

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

            // DrawLine2D object
            DrawLine2D drawLine2D = new DrawLine2D(bitmap);
            if (comboBox_lineAlgo.Text.Equals("DDA"))
            {
                drawLine2D.DDA(line2D, Color.Blue);
            }
            else if (comboBox_lineAlgo.Text.Equals("Bresenham"))
            {
                drawLine2D.Bresenham(line2D, Color.Blue);
            }
            else if (comboBox_lineAlgo.Text.Equals("MidPoint"))
            {
                drawLine2D.MidPoint(line2D, Color.Blue);
            }
            else if (comboBox_lineAlgo.Text.Equals("Xiaolin Wu"))
            {
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
                    "x1, x2 must be less or equal than " + bitmap.Width.ToString() + Environment.NewLine +
                    "y1, y2 must be less or qual than " + bitmap.Height.ToString() + Environment.NewLine,
                    "Error");
                return false;
            }
            line2D = new Line2D(new Point(x1, y1),
                new Point(x2, y2));

            if (!isPointInsidePictureBox(line2D.p1) ||
                !isPointInsidePictureBox(line2D.p2))
            {
                MessageBox.Show("x1, y1, x2, y2 is too big" + Environment.NewLine +
                    "x1, y1, x2, y2 must be positive integer" + Environment.NewLine +
                    "x1, x2 must be less or equal than " + bitmap.Width.ToString() + Environment.NewLine +
                    "y1, y2 must be less or qual than " + bitmap.Height.ToString() + Environment.NewLine,
                    "Error");
                return false;
            }

            return true;
        }

        private Boolean isPointInsidePictureBox(Point p)
        {
            if (p.X < 0 || p.Y < 0 ||
                p.X > bitmap.Width || p.Y > bitmap.Height)
                return false;
            return true;
        }

        private void button_clearAll_Click(object sender, EventArgs e)
        {
            clearAllDrawing();
        }

        private void FormLine_Load(object sender, EventArgs e)
        {
            // use bitmap for drawing
            bitmap = new Bitmap(pictureBox_draw.Width,
            pictureBox_draw.Height,
            PixelFormat.Format24bppRgb);

            // set bitmap to picture box
            pictureBox_draw.Image = bitmap;

            clearAllDrawing();

            // set up combo box for line drawing
            setComboBoxLineDrawing();
        }

        private void setComboBoxLineDrawing()
        {
            comboBox_lineAlgo.Items.Insert(0, "DDA");
            comboBox_lineAlgo.Items.Insert(1, "Bresenham");
            comboBox_lineAlgo.Items.Insert(2, "MidPoint");
            comboBox_lineAlgo.Items.Insert(3, "Xiaolin Wu");
            comboBox_lineAlgo.SelectedIndex = 0;
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

        private void button_help_click(object sender, EventArgs e)
        {
            MessageBox.Show("x1, y1 is cordinate of Point p1" + Environment.NewLine +
                "x2, y2 is cordinate of Point p2" + Environment.NewLine +
                "x1, y1, x2, y2 must be positive integer" + Environment.NewLine +
                "x1, x2 must be less or equal than " + bitmap.Width.ToString() + Environment.NewLine +
                "y1, y2 must be less or qual than " + bitmap.Height.ToString() + Environment.NewLine +
                Environment.NewLine +
                "You choose an algorithm (DDA, Bresenham, MidPoint, Xiaolin Wu)," + Environment.NewLine +
                "then press \"Draw line\" button to draw a line from p1 to p2" + Environment.NewLine +
                "You can clear all drawings when you press \"Clear all\" button" + Environment.NewLine +
                Environment.NewLine +
                "If you want to draw random line, first you input the number of lines you want to draw," + Environment.NewLine +
                "then you press \"Random\" button, the program will randomize points and draw it to line," + Environment.NewLine +
                "after drawing, the program will output the time it took to draw" + Environment.NewLine,
                "Help");
        }

        private void button_rand_click(object sender, EventArgs e)
        {
            if (!get_numRand())
            {
                return;
            }

            // clear all drawings before random
            clearAllDrawing();

            // get a random list of line
            List<Line2D> line2DS = randListLine2D(numRand);

            // StopWatch object for calculating execution time of the algorithm
            // StartNew and Stop for make sure stopwatch is not redundant object
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            // DrawLine2D object
            DrawLine2D drawLine2D = new DrawLine2D(bitmap);
            if (comboBox_lineAlgo.Text.Equals("DDA"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawLine2D.DDA(line2DS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_lineAlgo.Text.Equals("Bresenham"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawLine2D.Bresenham(line2DS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_lineAlgo.Text.Equals("MidPoint"))
            {
                stopwatch.Restart();
                for (int i = 0; i < numRand; ++i)
                {
                    drawLine2D.MidPoint(line2DS[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_lineAlgo.Text.Equals("Xiaolin Wu"))
            {
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

        private List<Line2D> randListLine2D(int num)
        {
            List<Line2D> line2DS = new List<Line2D>();
            for (int i = 0; i < num; ++i)
            {
                line2DS.Add(new Line2D(new Point(random.Next(bitmap.Width),
                    random.Next(bitmap.Height)),
                    new Point(random.Next(bitmap.Width),
                    random.Next(bitmap.Height))));
            }
            return line2DS;
        }
    }
}