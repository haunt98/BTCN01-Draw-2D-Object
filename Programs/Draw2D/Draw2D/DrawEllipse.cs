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
            // calculate y from x, then draw(x, round(y)) or the opposite
            // F(x, y) = x^2/a^2 + y^2/b^2 - 1
            // => 2x/a^2 + (2y/b^2) * dy/dx = 0
            // slope dy/dx = -(xb^2)/(ya^2)
            //
            // x incre faster than y decre <=> dy/dx > -1
            // <=> x * b * b - y * a * a < 0
            // start from Point(0, b) move along -->>
            //
            // y incre faster than x decre <-> dy/dx < -1
            // start from Point(a, 0) move along <<--

            Point center = ellipse.center;
            int a = ellipse.a;
            int b = ellipse.b;

            // x incre faster than y decre
            int x = 0;
            int y = (int)Math.Round(Math.Sqrt(b * b - b * b * x * x / (float)(a * a)));
            int x_incre = 1;
            int y_incre = 1;

            while (x * b * b - y * a * a < 0 && x <= a && y >= 0)
            {
                if (x < bitmap.Width - center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X + x, center.Y + y, color);
                if (x < bitmap.Width - center.X && y < center.Y)
                    bitmap.SetPixel(center.X + x, center.Y - y, color);
                if (x < center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X - x, center.Y + y, color);
                if (x < center.X && y < center.Y)
                    bitmap.SetPixel(center.X - x, center.Y - y, color);

                x += x_incre;
                y = (int)Math.Round(Math.Sqrt(b * b - b * b * x * x / (float)(a * a)));
            }

            // y incre faster than x decre
            y = 0;
            x = (int)Math.Round(Math.Sqrt(a * a - a * a * y * y / (float)(b * b)));

            while (x * b * b - y * a * a >= 0 && x >= 0 && y <= b)
            {
                if (x < bitmap.Width - center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X + x, center.Y + y, color);
                if (x < bitmap.Width - center.X && y < center.Y)
                    bitmap.SetPixel(center.X + x, center.Y - y, color);
                if (x < center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X - x, center.Y + y, color);
                if (x < center.X && y < center.Y)
                    bitmap.SetPixel(center.X - x, center.Y - y, color);

                y += y_incre;
                x = (int)Math.Round(Math.Sqrt(a * a - a * a * y * y / (float)(b * b)));
            }
        }

        public void Bresenham(Ellipse ellipse, Color color)
        {
            // Explain Bresenham algorithm
            // draw in 1/4
            // F(x, y) = x^2/a^2 + y^2/b^2 - 1
            //
            // when x incre faster than y decre
            // F(x + 1, y) and F(x + 1, y - 1)
            // one is positive and one is negative
            //
            // p_i = a^2 * b^2 * (F(x_k + 1, y_k) + F(x_k + 1, y_k - 1))
            // p_(i+1) - p_i = 4b^2 * x_(k+1) + 2b^2
            //                  + 2a^2 * (y_(k+1)^2 - y_k^2)
            //                  - 2a^2 * (y_(k+1) - y_k)
            //
            // p_i < 0
            //      y_(k+1) = y_k
            //      p_(i+1) = p_i + 4b^2 * x_(k+1) + 2b^2
            // p_i >= 0
            //      y_(k+1) = y_k - 1
            //      p_(i+1) = p_i + 4b^2 * x_(k+1) + 2b^2 - 4a^2 * y_(k+1)
            //
            // p_0 is Point(0, b) move along -->>
            // p_0 = 2b^2 - 2(a^2)b + a^2
            //
            // when y incre faster than x decre
            // F(x, y + 1) and F(x - 1, y + 1)
            // one is positive and one is negative
            //
            // p_i = (a^2)(b^2)(F(x_k, y_k + 1) + F(x_k - 1, y_k + 1))
            // p_(i+1) - p_i = 2b^2 * (x_(k+1)^2 - x_k^2) + 2b^2 * (x_(k+1) - x_k)
            //                      + 4a^2 * y_(k+1) + 2a^2
            //
            // p_i < 0
            //      x_(k+1) = x_k
            //      p_(i+1) = p_i + 4a^2 * y_(k+1) + 2a^2
            // p_i >= 0
            //      x_(k+1) = x_k - 1
            //      p_(i+1) = p_i + 4a^2 * y_(k+1) + 2a^2 - 4b^2 * x_(k+1)
            //
            // p_0 is Point(a, 0) move along <<--
            // p_0 = 2a^2 - 2a(b^2) + b^2

            Point center = ellipse.center;
            int a = ellipse.a;
            int b = ellipse.b;

            // x incre faster than y decre
            int x = 0;
            int y = b;
            int x_incre = 1;
            int y_incre = -1;

            // p_0 = 2b^2 - 2(a^2)b + a^2
            int error_step = 2 * b * b - 2 * a * a * b + a * a;

            while (x * b * b - y * a * a < 0 && x <= a && y >= 0)
            {
                if (x < bitmap.Width - center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X + x, center.Y + y, color);
                if (x < bitmap.Width - center.X && y < center.Y)
                    bitmap.SetPixel(center.X + x, center.Y - y, color);
                if (x < center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X - x, center.Y + y, color);
                if (x < center.X && y < center.Y)
                    bitmap.SetPixel(center.X - x, center.Y - y, color);

                x += x_incre;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + 4 * (b^2) * x_(k+1) + 2b^2
                    error_step += 4 * b * b * x + 2 * b * b;
                }
                else
                {
                    y += y_incre;
                    // p_(i+1) = p_i + 4 * (b^2) * x_(k+1) + 2b^2 - 4a^2 * y_(k+1)
                    error_step += 4 * b * b * x + 2 * b * b - 4 * a * a * y;
                }
            }

            // y incre faster than x decre
            x = a;
            y = 0;
            x_incre = -1;
            y_incre = 1;

            // p_0 = 2a^2 - 2a(b^2) + b^2
            error_step = 2 * a * a - 2 * a * b * b + b * b;

            while (x * b * b - y * a * a >= 0 && x >= 0 && y <= b)
            {
                if (x < bitmap.Width - center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X + x, center.Y + y, color);
                if (x < bitmap.Width - center.X && y < center.Y)
                    bitmap.SetPixel(center.X + x, center.Y - y, color);
                if (x < center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X - x, center.Y + y, color);
                if (x < center.X && y < center.Y)
                    bitmap.SetPixel(center.X - x, center.Y - y, color);

                y += y_incre;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + 4a^2 * y_(k+1) + 2a^2
                    error_step += 4 * a * a * y + 2 * a * a;
                }
                else
                {
                    x += x_incre;
                    // p_(i+1) = p_i + 4a^2 * y_(k+1) + 2a^2 - 4b^2 * x_(k+1)
                    error_step += 4 * a * a * y + 2 * a * a - 4 * b * b * x;
                }
            }
        }

        public void MidPoint(Ellipse ellipse, Color color)
        {
            // Explain MidPoint algorithm
            // draw in 1/4
            // F(x, y) = x^2/a^2 + y^2/b^2 - 1
            //
            // when x incre faster than y decre
            // F(x_k + 1, y_k - 1/2) = (x_k + 1)^2/a^2 + (y_k - 1/2)^2/b^2 - 1
            //
            // p_i = 4(a^2)(b^2) * F(x_k + 1, y_k - 1/2)
            // p_(i+1) - p_i = 8b^2 * x_(k+1) + 4b^2
            //                  + 4a^2(y_(k+1)^2 - y_k^2) - 4a^2(y_(k+1) - y_k)
            //
            // p_i < 0
            //      y_(k+1) = y_k
            //      p_(i+1) = p_i + 8b^2 * x_(k+1) + 4b^2
            // p_i >= 0
            //      y_(k+1) = y_k - 1
            //      p_(i+1) = p_i + 8b^2 * x_(k+1) + 4b^2 - 8a^2 * y_(k+1)
            //
            // p_0 is Point(0, b) move along -->>
            // p_0 = 4b^2 - 4(a^2)b + a^2
            //
            // when y incre faster than x decre
            // F(x_k - 1/2, y_k + 1) = (x_k - 1/2)^2/a^2 + (y_k + 1)^2/b^2 - 1
            //
            // p_i = 4(a^2)(b^2) * F(x_k - 1/2, y_k + 1)
            // p_(i+1) - p_i = 8a^2 * y_(k+1) + 4a^2
            //                  + 4b^2(x_(k+1)^2 - x_k^2) - 4b^2(x_(k+1) - x_k)
            //
            // p_i < 0
            //      x_(k+1) = x_k
            //      p_(i+1) = p_i + 8a^2 * y_(k+1) + 4a^2
            //
            // p_i >= 0
            //      x_(k+1) = x_k - 1
            //      p_(i+1) = p_i + 8a^2 * y_(k+1) + 4a^2 - 8b^2 * x_(k+1)
            //
            // p_0 is Point(a, 0) move along <<--
            // p_0 = 4a^2 - 4a(b^2) + b^2

            Point center = ellipse.center;
            int a = ellipse.a;
            int b = ellipse.b;

            // x incre faster than y decre
            int x = 0;
            int y = b;
            int x_incre = 1;
            int y_incre = -1;

            // p_0 = 4b^2 - 4(a^2)b + a^2
            int error_step = 4 * b * b - 4 * a * a * b + a * a;

            while (x * b * b - y * a * a < 0 && x <= a && y >= 0)
            {
                if (x < bitmap.Width - center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X + x, center.Y + y, color);
                if (x < bitmap.Width - center.X && y < center.Y)
                    bitmap.SetPixel(center.X + x, center.Y - y, color);
                if (x < center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X - x, center.Y + y, color);
                if (x < center.X && y < center.Y)
                    bitmap.SetPixel(center.X - x, center.Y - y, color);

                x += x_incre;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + 8b^2 * x_(k+1) + 4b^2
                    error_step += 8 * b * b * x + 4 * b * b;
                }
                else
                {
                    y += y_incre;
                    // p_(i+1) = p_i + 8b^2 * x_(k+1) + 4b^2 - 8a^2 * y_(k+1)
                    error_step += 8 * b * b * x + 4 * b * b - 8 * a * a * y;
                }
            }

            // y decre faster than x incre
            x = a;
            y = 0;
            x_incre = -1;
            y_incre = 1;

            // p_0 = 4a^2 - 4a(b^2) + b^2
            error_step = 4 * a * a - 4 * a * b * b + b * b;

            while (x * b * b - y * a * a >= 0 && x >= 0 && y <= b)
            {
                if (x < bitmap.Width - center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X + x, center.Y + y, color);
                if (x < bitmap.Width - center.X && y < center.Y)
                    bitmap.SetPixel(center.X + x, center.Y - y, color);
                if (x < center.X && y < bitmap.Height - center.Y)
                    bitmap.SetPixel(center.X - x, center.Y + y, color);
                if (x < center.X && y < center.Y)
                    bitmap.SetPixel(center.X - x, center.Y - y, color);

                y += y_incre;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + 8a^2 * y_(k+1) + 4a^2
                    error_step += 8 * a * a * y + 4 * a * a;
                }
                else
                {
                    x += x_incre;
                    // p_(i+1) = p_i + 8a^2 * y_(k+1) + 4a^2 - 8b^2 * x_(k+1)
                    error_step += 8 * a * a * y + 4 * a * a - 8 * b * b * x;
                }
            }
        }
    }
}