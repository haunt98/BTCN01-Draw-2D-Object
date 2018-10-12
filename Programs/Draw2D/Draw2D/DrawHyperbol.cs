using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2D
{
    public class Hyperbol
    {
        public Point center { get; set; }

        public int a { get; set; }

        public int b { get; set; }

        public Hyperbol(Point c, int aa, int bb)
        {
            center = new Point(c.X, c.Y);
            a = aa;
            b = bb;
        }
    }

    public class DrawHyperbol
    {
        private Bitmap bitmap;

        public DrawHyperbol(Bitmap b)
        {
            bitmap = b;
        }

        public void DDA(Hyperbol hyperbol, Color color)
        {
        }

        public void Bresenham(Hyperbol hyperbol, Color color)
        {
        }

        public void MidPoint(Hyperbol hyperbol, Color color)
        {
        }
    }
}