using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void button_randGen_Click(object sender, EventArgs e)
        {
            if (!get_randNum())
            {
                return;
            }
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("",
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
    }
}