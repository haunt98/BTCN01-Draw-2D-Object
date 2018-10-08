using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2D
{
    public class Circle2D
    {
        public Point center { get; set; }
        public int R { get; set; }

        public Circle2D(Point c, int r)
        {
            center = new Point(c.X, c.Y);
            R = r;
        }
    }

    public class DrawCircle2D
    {
        private Bitmap bitmap;

        public DrawCircle2D(Bitmap b)
        {
            bitmap = b;
        }

        // Use the idea from slide
        public void EightSymmetry(Circle2D circle2D, Color color)
        {
            Point center = circle2D.center;
            int R = circle2D.R;

            bitmap.SetPixel(center.X, center.Y + R, color);
            bitmap.SetPixel(center.X, center.Y - R, color);
            bitmap.SetPixel(center.X + R, center.Y, color);
            bitmap.SetPixel(center.X - R, center.Y, color);
            int x = 1;
            int y = (int)Math.Round(Math.Sqrt(R * R - x * x));
            while (x < y)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);
                bitmap.SetPixel(center.X + y, center.Y + x, color);
                bitmap.SetPixel(center.X + y, center.Y - x, color);
                bitmap.SetPixel(center.X - y, center.Y + x, color);
                bitmap.SetPixel(center.X - y, center.Y - x, color);
                ++x;
                y = (int)Math.Round(Math.Sqrt(R * R - x * x));
            }
        }
    }
}