using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2D
{
    public class Ellipse
    {
        public Point center { get; set; }
        public int a { get; set; }
        public int b { get; set; }

        public Ellipse(Point c, int aa, int bb)
        {
            center = new Point(c.X, c.Y);
            a = aa;
            b = bb;
        }
    }

    public class DrawEllipse
    {
        private Bitmap bitmap;

        public DrawEllipse(Bitmap b)
        {
            bitmap = b;
        }

        public void DDA(Ellipse ellipse, Color color)
        {
            // calculate y from x, then draw(x, round(y))
            // F(x, y) = x^2/a^2 + y^2/b^2 - 1
            // Dy/Dx = 2x/a^2
            // Dx/Dy = 2y/b^2
            // x incre faster than y <=> Dy/Dx < Dx/Dy
            // <=> 2x/a^2 - 2y/b^2 < 0
            // <=> x * b * b - y * a * a < 0

            Point center = ellipse.center;
            int a = ellipse.a;
            int b = ellipse.b;

            bitmap.SetPixel(center.X, center.Y + b, color);
            bitmap.SetPixel(center.X, center.Y - b, color);
            bitmap.SetPixel(center.X + a, center.Y, color);
            bitmap.SetPixel(center.X - a, center.Y, color);

            int x = 1;
            int y = (int)Math.Round(Math.Sqrt(b * b - b * b * x * x / (float)(a * a)));

            // x incre faster than y decre
            while (x * b * b - y * a * a < 0)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);

                ++x;
                y = (int)Math.Round(Math.Sqrt(b * b - b * b * x * x / (float)(a * a)));
            }

            // y decre faster than x incre
            while (x * b * b - y * a * a >= 0 && y >= 0 && x <= a)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);

                --y;
                x = (int)Math.Round(Math.Sqrt(a * a - a * a * y * y / (float)(b * b)));
            }
        }

        public void Bresenham(Ellipse ellipse, Color color)
        {
        }

        public void MidPoint(Ellipse ellipse, Color color)
        {
            // Explain MidPoint algorithm
            // F(x, y) = x^2/a^2 + y^2/b^2 - 1
            //
            // when x incre faster than y decre
            // F(x_k + 1, y_k - 1/2) = (x_k + 1)^2/a^2 + (y_k - 1/2)^2/b^2 - 1
            //
            // p_i = 4 * (a^2) * (b^2) * F(x_k + 1, y_k - 1/2)
            // p_i = 4 * (((x_k + 1)^2) * (b^2) + ((y_k - 1/2)^2) * (a^2) - (a^2) * (b^2))
            // p_(i+1) = 4 * (((x_k + 2)^2) * (b^2) + ((y_(k+1) - 1/2)^2) * (a^2) - (a^2) * (b^2))
            // p_(i+1) - p_i = 4 * ((b^2) * 2 (x_k + 1) + b^2 + (a^2) * (y_(k+1)^2 - y_k^2)
            //                          - (a^2) * (y_(k+1) - y_k))
            //
            // p_i < 0
            //      y_(k+1) = y_k
            //      p_(i+1) = p_i + (b^2) * 8 * x_(k+1) + 4 * b^2
            // p_i >= 0
            //      y_(k+1) = y_k - 1
            //      p_(i+1) = p_i + (b^2) * 8 * x_(k+1) + 4 * b^2 - (a^2) * 8 * y_(k+1)
            //
            // p_0 = 4 * (a^2) * (b^2) * F(x_0 + 1, y_0 - 1/2)
            // p_0 = 4 * (b^2) - 4 * (a^2) * b + a^2
            //
            // when y decre faster than x incre
            // F(x_k + 1/2, y_k - 1) = (x_k + 1/2)^2/a^2 + (y_k - 1)^2/b^2 - 1
            //
            // p_i = 4 * (a^2) * (b^2) * F(x_k + 1/2, y_k - 1)
            // p_(i+1) - p_i = 4 * (a^2) * (-2y_k + 3)
            //                          + 4 * b^2 * (x_(k+1)^2 - x_k^2)
            //                          + 4 * b^2 * (x_(k+1) - x_k)
            // p_(i+1) - p_i = 4 * (a^2) * (-2y_(k+1)) + 4 * a^2
            //                          + 4 * b^2 * (x_(k+1)^2 - x_k^2)
            //                          + 4 * b^2 * (x_(k+1) - x_k)
            //
            // p_i < 0
            //      x_(k+1) = x_k + 1
            //      p_(i+1) = p_i - 8 * (a^2) * y_(k+1) + 4 * a^2 + 8 * (b^2) * x_(k+1)
            //
            // p_i >= 0
            //      x_(k+1) = x_k
            //      p_(i+1) = p_i - 8 * (a^2) * y_(k+1) + 4 * a^2
            //
            // p_0 is where x * b * b - y * a * a = 0
            //      xx = a^2/sqrt(a^2 + b^2)
            //      yy = b^2/sqrt(a^2 + b^2)
            // p_0 = 4 * (a^2) * (b^2) * F(xx + 1/2, yy - 1)

            Point center = ellipse.center;
            int a = ellipse.a;
            int b = ellipse.b;

            int x = 0;
            int y = b;
            int x_incre = 1;
            int y_incre = -1;

            int error_step = 4 * b * b - 4 * a * a * b + a * a;

            // x incre faster than y decre
            while (x * b * b - y * a * a < 0)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);

                x += x_incre;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + (b^2) * 8 * x_(k+1) + 4 * b^2
                    error_step += b * b * 8 * x + 4 * b * b;
                }
                else
                {
                    y += y_incre;
                    // p_(i+1) = p_i + (b^2) * 8 * x_(k+1) + 4 * b^2 - (a^2) * 8 * y_(k+1)
                    error_step += b * b * 8 * x + 4 * b * b - a * a * 8 * y;
                }
            }

            // recalculate error_step
            float xx = (a * a) / (float)Math.Sqrt(a * a + b * b);
            float yy = (b * b) / (float)Math.Sqrt(a * a + b * b);
            float pp = 4 * b * b * (xx + 1 / 2) * (xx + 1 / 2) + 4 * a * a * (yy - 1) * (yy - 1)
                - 4 * a * a * b * b;
            error_step = (int)pp;

            // y decre faster than x incre
            while (x * b * b - y * a * a >= 0 && y >= 0 && x <= a)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);

                y += y_incre;
                if (error_step < 0)
                {
                    x += x_incre;
                    // p_(i+1) = p_i - 8 * (a^2) * y_(k+1) + 4 * a^2 + 8 * (b^2) * x_(k+1)
                    error_step += 0 - 8 * a * a * y + 4 * a * a + 8 * b * b * x;
                }
                else
                {
                    // p_(i+1) = p_i - 8 * (a^2) * y_(k+1) + 4 * a^2
                    error_step += 0 - 8 * a * a * y + 4 * a * a;
                }
            }
        }
    }
}