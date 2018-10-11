using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2D
{
    public class Parabol
    {
        public Point top { get; set; }
        public int a { get; set; }
        public int b { get; set; }

        public Parabol(Point t, int aa, int bb)
        {
            top = new Point(t.X, t.Y);
            a = aa;
            b = bb;
        }
    }

    public class DrawParabol
    {
        private Bitmap bitmap;

        public DrawParabol(Bitmap b)
        {
            bitmap = b;
        }

        public void DDA(Parabol parabol, Color color)
        {
            // calculate y from x, then draw(x, round(y)) or the opposite
            // F(x, y) = y - (a/b)x^2
            // => dy/dx - 2(a/b)x = 0
            // slope dy/dx = 2(a/b)x
            //
            // with a > 0
            // x incre faster than y incre <=> dy/dx < 1
            // <=> 2(a/b)x < 1
            // y incre faster than x incre <=> dy/dx > 1
            // <=> 2(a/b)x > 1

            Point top = parabol.top;
            int a = parabol.a;
            int b = parabol.b;

            int x, y, x_incre, y_incre;

            // x incre faster than y incre
            x = 0;
            y = (int)Math.Round((a * x * x / (float)b));
            x_incre = 1;

            while (2 * a * x < b && x < bitmap.Width - top.X && x < top.X &&
                y < bitmap.Height - top.Y)
            {
                bitmap.SetPixel(top.X + x, top.Y + y, color);
                bitmap.SetPixel(top.X - x, top.Y + y, color);

                x += x_incre;
                y = (int)Math.Round((a * x * x / (float)b));
            }

            // y incre faster than x incre
            y_incre = 1;

            while (2 * a * x >= b && x < bitmap.Width - top.X && x < top.X &&
                y < bitmap.Height - top.Y)
            {
                bitmap.SetPixel(top.X + x, top.Y + y, color);
                bitmap.SetPixel(top.X - x, top.Y + y, color);

                y += y_incre;
                x = (int)Math.Round(Math.Sqrt(b * y / (float)a));
            }
        }

        public void Bresenham(Parabol parabol, Color color)
        {
        }

        public void MidPoint(Parabol parabol, Color color)
        {
        }
    }
}