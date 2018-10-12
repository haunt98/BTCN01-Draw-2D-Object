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
            // Explain Bresenham algorithm
            //
            // when x incre faster than y incre
            // F(x + 1, y) and F(x + 1, y + 1)
            // d1 = y - y_k
            // d2 = y_k + 1 - y
            // d1 - d2 < 0 choose y_k, otherwise y_k + 1
            // d1 - d2 = 2y - 2y_k -1
            //
            // p_i = b * (d1 - d2)
            // p_i = 2a * (x_k + 1)^2 - 2b * y_k - b
            // p_(i+1) - p_i = 4a * x_(k+1) + 2a - 2b * (y_(k+1) - y_k)
            //
            // p_i < 0
            //      y_(k+1) = y_k
            //      p_(i+1) = p_i + 4a * x_(k+1) + 2a
            // p_i >=0
            //      y_(k+1) = y_k + 1
            //      p_(i+1) = p_i + 4a * x_(k+1) + 2a - 2b
            // p_0 = 2a - b
            //
            // when y incre faster than x incre
            // F(x, y + 1) and F(x + 1, y + 1)
            // d1 = x^2 - x_k^2
            // d2 = (x_k + 1)^2 - x^2
            // d1 - d2 < 0 choose x_k, otherwise x_k + 1
            // d1 - d2 = 2x^2 - (2x_k^2 + 2x_k + 1)
            //
            // p_i = a * (d1 - d2)
            // p_i = 2b * (y_k + 1) - a * (2x_k^2 + 2x_k + 1)
            // p_(i+1) - p_i = 2b - 2a * (x_(k+1)^2 + x_(k+1) - x_k^2 - x_k)
            //
            // p_i < 0
            //      x_(k+1) = x_k
            //      p_(i+1) = p_i + 2b
            // p_i >= 0
            //      x_(k+1) = x_k + 1
            //      p_(i+1) = p_i + 2b - 4a * x_(k+1)

            Point top = parabol.top;
            int a = parabol.a;
            int b = parabol.b;

            // when x incre faster than y
            int x = 0;
            int y = 0;
            int x_incre = 1;
            int y_incre = 1;

            // p_0 = -b
            int error_step = -b;

            while (2 * a * x < b && x < bitmap.Width - top.X && x < top.X &&
                y < bitmap.Height - top.Y)
            {
                bitmap.SetPixel(top.X + x, top.Y + y, color);
                bitmap.SetPixel(top.X - x, top.Y + y, color);

                x += x_incre;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + 4a * x_(k+1) + 2a
                    error_step += 4 * a * x + 2 * a;
                }
                else
                {
                    y += y_incre;
                    // p_(i+1) = p_i + 4a * x_(k+1) + 2a - 2b
                    error_step += 4 * a * x - 2 * a - 2 * b;
                }
            }

            // when y incre faster than x incre

            // p_i = 2b * (y_k + 1) - a * (2x_k^2 + 2x_k + 1)
            error_step = 2 * b * (y + 1) - a * (2 * x * x + 2 * x + 1);

            while (2 * a * x >= b && x < bitmap.Width - top.X && x < top.X &&
                y < bitmap.Height - top.Y)
            {
                bitmap.SetPixel(top.X + x, top.Y + y, color);
                bitmap.SetPixel(top.X - x, top.Y + y, color);

                y += y_incre;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + 2b
                    error_step += 2 * b;
                }
                else
                {
                    x += x_incre;
                    // p_(i+1) = p_i + 2b - 4a * x_(k+1)
                    error_step += 2 * b - 4 * a * x;
                }
            }
        }

        public void MidPoint(Parabol parabol, Color color)
        {
            // Explain MidPoint algorithm
            // F(x, y) = y - (a/b)x^2
            //
            // when x incre faster than y incre
            // p_i = 2b * F(x + 1, y + 1/2)
            // p_i = 2b * y_k + b - 2a * (x_k + 1)^2
            // p_(i+1) - p_i = 2b * (y_(k+1) - y_k) - 4a * x_(k+1) - 2a
            //
            // p_i < 0 (outside)
            //      y_(k+1) = y_k + 1
            //      p_(i_1) = p_i + 2b - 4a * x_(k+1) - 2a
            // p_i >= 0
            //      y_(k+1) = y_k
            //      p_(i+1) = p_i - 4a * x_(k+1) - 2a
            // p_0 = b - 2a
            //
            // when y incre faster than x incre
            // p_i = 4b * F(x + 1/2, y + 1)
            // p_i = 4b * y_k + 4b - 4a * (x_k + 1/2)^2
            // p_(i+1) - p_i = 4b - 4a * (x_(k+1)^2 - x_k^2) - 4a * (x_(k+1) - x_k)
            //
            // p_i < 0
            //      x_(k+1) = x_k
            //      p_(i+1) = p_i + 4b
            // p_i >= 0
            //      x_(k+1) = x_k + 1
            //      p_(i+1) = p_i + 4b - 8a * x_(k+1) - 8a

            Point top = parabol.top;
            int a = parabol.a;
            int b = parabol.b;

            // when x incre faster than y incre
            int x = 0;
            int y = 0;
            int x_incre = 1;
            int y_incre = 1;

            // p_0 = b - 2a
            int error_step = b - 2 * a;

            while (2 * a * x < b && x < bitmap.Width - top.X && x < top.X &&
                y < bitmap.Height - top.Y)
            {
                bitmap.SetPixel(top.X + x, top.Y + y, color);
                bitmap.SetPixel(top.X - x, top.Y + y, color);

                x += x_incre;
                if (error_step < 0)
                {
                    y += y_incre;
                    // p_(i_1) = p_i + 2b - 4a * x_(k+1) - 2a
                    error_step += 2 * b - 4 * a * x - 2 * a;
                }
                else
                {
                    // p_(i+1) = p_i - 4a * x_(k+1) - 2a
                    error_step += 0 - 4 * a * x - 2 * a;
                }
            }

            // when y incre faster than x incre

            // p_i = 4b * y_k + 4b - 4a * (x_k + 1/2)^2
            error_step = 4 * b * y + 4 * b - a * (2 * x + 1) * (2 * x + 1);

            while (2 * a * x >= b && x < bitmap.Width - top.X && x < top.X &&
                    y < bitmap.Height - top.Y)
            {
                bitmap.SetPixel(top.X + x, top.Y + y, color);
                bitmap.SetPixel(top.X - x, top.Y + y, color);

                y += y_incre;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + 4b
                    error_step += 4 * b;
                }
                else
                {
                    x += x_incre;
                    // p_(i+1) = p_i + 4b - 8a * x_(k+1) - 8a
                    error_step += 4 * b - 8 * a * x - 8 * a;
                }
            }
        }
    }
}