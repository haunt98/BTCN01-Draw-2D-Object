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
            // F(x, y) = x^2/a^2 - y^2/b^2 - 1
            // => 2x/a^2 - 2y/b^2 * dy/dx = 0
            // dy/dx = xb^2/ya^2
            // y incre faster than x incre <=> dy/dx > 1
            // <=> xb^2 - ya^2 > 0
            // start from Point(a, 0)

            Point center = hyperbol.center;
            int a = hyperbol.a;
            int b = hyperbol.b;

            // y incre faster than x incre
            int y = 0;
            int x = (int)Math.Round(Math.Sqrt(a * a * (y * y + b * b) / (float)(b * b)));
            int x_incre = 1;
            int y_incre = 1;

            while (x * b * b - y * a * a > 0 && x < center.X && x < bitmap.Width - center.X &&
                    y < center.Y && y < bitmap.Height - center.Y)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);

                y += y_incre;
                x = (int)Math.Round(Math.Sqrt(a * a * (y * y + b * b) / (float)(b * b)));
            }

            // x incre faster than y incre
            y = (int)Math.Round(Math.Sqrt(b * b * (x * x - a * a) / (float)(a * a)));

            while (x * b * b - y * a * a <= 0 && x < center.X && x < bitmap.Width - center.X &&
                    y < center.Y && y < bitmap.Height - center.Y)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);

                x += x_incre;
                y = (int)Math.Round(Math.Sqrt(b * b * (x * x - a * a) / (float)(a * a)));
            }
        }

        public void Bresenham(Hyperbol hyperbol, Color color)
        {
        }

        public void MidPoint(Hyperbol hyperbol, Color color)
        {
        }
    }
}