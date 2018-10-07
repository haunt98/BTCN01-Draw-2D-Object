using System;
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
    public partial class FormCircle : Form
    {
        public FormCircle()
        {
            InitializeComponent();
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            if (!get_pR())
            {
                return;
            }

            // DrawCircle 2D object
            DrawCircle2D drawCircle2D = new DrawCircle2D(bitmap);
            if (comboBox_algo.Text.Equals("8-way symmetry"))
            {
                drawCircle2D.EightSymmetry(pCenter, R, Color.Blue);
            }

            // refresh picture box every draw
            pictureBox_draw.Refresh();
        }

        private Point pCenter = new Point();
        private int R;
        private Bitmap bitmap;

        private Boolean get_pR()
        {
            int x, y;
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
                    "x, x + R must be less or equal than " + pictureBox_draw.Width + Environment.NewLine +
                    "y, y + R must be less or equal than " + pictureBox_draw.Height + Environment.NewLine,
                    "Error");
                return false;
            }
            pCenter.X = x;
            pCenter.Y = y;
            if (!insidePictureBox())
            {
                MessageBox.Show("x, y, R value is not suitable" + Environment.NewLine +
                    "x, y, R, x - R, y - R must be positive integer" + Environment.NewLine +
                    "x, x + R must be less or equal than " + pictureBox_draw.Width + Environment.NewLine +
                    "y, y + R must be less or equal than " + pictureBox_draw.Height + Environment.NewLine,
                    "Error");
                return false;
            }

            return true;
        }

        private Boolean insidePictureBox()
        {
            if (pCenter.X < 0 || pCenter.Y < 0 || R < 0 ||
                pCenter.X - R < 0 || pCenter.Y - R < 0 ||
                pCenter.X > pictureBox_draw.Width ||
                pCenter.X + R > pictureBox_draw.Width ||
                pCenter.Y > pictureBox_draw.Height ||
                pCenter.Y + R > pictureBox_draw.Height)
            {
                return false;
            }
            return true;
        }

        private void FormCircle_Load(object sender, EventArgs e)
        {
            // use bitmap for drawing
            bitmap = new Bitmap(this.ClientRectangle.Width,
            this.ClientRectangle.Height,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb);

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
    }
}