using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw2D
{
    public partial class FormLine : Form
    {
        private Point p1, p2;
        private Bitmap bitmap;
        private Random RandomNumber = new Random();

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
                drawLine2D.DDA(p1, p2, Color.Blue);
            }
            else if (comboBox_lineAlgo.Text.Equals("Bresenham"))
            {
                drawLine2D.Bresenham(p1, p2, Color.Blue);
            }
            else if (comboBox_lineAlgo.Text.Equals("MidPoint"))
            {
                drawLine2D.MidPoint(p1, p2, Color.Blue);
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
                    "x1, x2 must be less or equal than " + pictureBox_draw.Width.ToString() + Environment.NewLine +
                    "y1, y2 must be less or qual than " + pictureBox_draw.Height.ToString() + Environment.NewLine,
                    "Error");
                return false;
            }

            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);

            if (!isPointInsidePictureBox(p1) ||
                !isPointInsidePictureBox(p2))
            {
                MessageBox.Show("x1, y1, x2, y2 is too big" + Environment.NewLine +
                    "x1, y1, x2, y2 must be positive integer" + Environment.NewLine +
                    "x1, x2 must be less or equal than " + pictureBox_draw.Width.ToString() + Environment.NewLine +
                    "y1, y2 must be less or qual than " + pictureBox_draw.Height.ToString() + Environment.NewLine,
                    "Error");
                return false;
            }

            return true;
        }

        private Boolean isPointInsidePictureBox(Point p)
        {
            if (p.X < 0 || p.Y < 0 ||
                p.X > pictureBox_draw.Width || p.Y > pictureBox_draw.Height)
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
            bitmap = new Bitmap(this.ClientRectangle.Width,
            this.ClientRectangle.Height,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb);

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

        private void button_helpLine_click(object sender, EventArgs e)
        {
            MessageBox.Show("x1, y1 is cordinate of Point p1" + Environment.NewLine +
                "x2, y2 is cordinate of Point p2" + Environment.NewLine +
                "x1, y1, x2, y2 must be positive integer" + Environment.NewLine +
                "x1, x2 must be less or equal than " + pictureBox_draw.Width.ToString() + Environment.NewLine +
                "y1, y2 must be less or qual than " + pictureBox_draw.Height.ToString() + Environment.NewLine +
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

        private void button_randomLine_Click(object sender, EventArgs e)
        {
            int num;
            if (string.IsNullOrWhiteSpace(textBox_randLineNum.Text))
            {
                MessageBox.Show("Number of lines to random is missing",
                    "Error");
                return;
            }
            else if (!int.TryParse(textBox_randLineNum.Text, out num))
            {
                MessageBox.Show("Number of lines to random is in wrong format",
                    "Error");
                return;
            }

            // clear all drawings before random
            clearAllDrawing();

            // get a random list of point
            List<Point> points_1 = randListPoints(num);
            List<Point> points_2 = randListPoints(num);

            // StopWatch object for calculating execution time of the algorithm
            // StartNew and Stop for make sure stopwatch is not redundant object
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            // DrawLine2D object
            DrawLine2D drawLine2D = new DrawLine2D(bitmap);
            if (comboBox_lineAlgo.Text.Equals("DDA"))
            {
                stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < num; ++i)
                {
                    drawLine2D.DDA(points_1[i], points_2[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_lineAlgo.Text.Equals("Bresenham"))
            {
                stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < num; ++i)
                {
                    drawLine2D.Bresenham(points_1[i], points_2[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_lineAlgo.Text.Equals("MidPoint"))
            {
                stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < num; ++i)
                {
                    drawLine2D.MidPoint(points_1[i], points_2[i], Color.Blue);
                }
                stopwatch.Stop();
            }
            else if (comboBox_lineAlgo.Text.Equals("Xiaolin Wu"))
            {
            }

            // Set excution time to text box
            textBox_randLineTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private List<Point> randListPoints(int num)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < num; ++i)
            {
                points.Add(new Point(RandomNumber.Next(pictureBox_draw.Width),
                    RandomNumber.Next(pictureBox_draw.Height)));
            }
            return points;
        }
    }
}