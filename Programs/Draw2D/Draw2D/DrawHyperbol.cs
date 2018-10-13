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

            while (x * b * b - y * a * a > 0 && x >= 0 && x < bitmap.Width &&
                y >= 0 && y < bitmap.Height)
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
                x = (int)Math.Round(Math.Sqrt(a * a * (y * y + b * b) / (float)(b * b)));
            }

            // x incre faster than y incre

            while (x * b * b - y * a * a <= 0 && x >= 0 && x < bitmap.Width &&
                 y >= 0 && y < bitmap.Height)
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
                y = (int)Math.Round(Math.Sqrt(b * b * (x * x - a * a) / (float)(a * a)));
            }
        }

        // Use the idea from paper
        // EFFICIENT INTEGER ALGORITHMS FOR THE GENERATION OF CONIC SECTIONS
        // http://graphics.di.uoa.gr/Downloads/papers/journals/p7.pdf
        public void Bresenham(Hyperbol hyperbol, Color color)
        {
            // Explain Bresenham algorithm
            // F(x, y) = x^2/a^2 - y^2/b^2 - 1
            //
            // y increase faster than x increase
            // F(x, y + 1) or F(x + 1, y + 1)
            // d1 = x^2 - x_k^2
            // d2 = (x_k + 1)^2 - x^2
            // d1 - d2 < -1/2 choose x_k otherwise x_k + 1
            //
            // p_i = b^2 * (d1 - d2)
            // p_i = b^2 * (2x^2 - x_k^2 - (x_k + 1)^2)
            // p_i = 2a^2 * (y_k + 1)^2 + 2(a^2)(b^2) - b^2 * (2x_k^2 + 2x_k + 1)
            // p_(i+1) - p_i = 4a^2 * y_(k+1) + 2a^2 - 2b^2 * (x_(k+1)^2 + x_(k+1) - x_k^2 - x_k)
            //
            // p_i < - b^2/2
            //      x_(k+1) = x_k
            //      p_(i+1) = p_i + 4a^2 * y_(k+1) + 2a^2
            // p_i >= -b^2/2
            //      x_(k+1) = x_k + 1
            //      p_(i+1) = p_i + 4a^2 * y_(k+1) + 2a^2 - 4b^2 * x_(k+1)
            // start from Point(a, 0)
            // p_0 = 2a^2 - 2ab^2 - b^2
            //
            // x increase faster than y
            // F(x + 1, y) or F(x + 1, y + 1)
            // d1 = y^2 - y_k^2
            // d2 = (y_k + 1)^2 - y^2
            // d1 - d2 < -1/2 choose y_k otherwise y_k + 1
            //
            // p_i = a^2 * (d1 - d2)
            // p_i = a^2 *(2y^2 - y_k^2 - (y_k + 1)^2)
            // p_i = 2b^2 * (x_k + 1)^2 - 2(a^2)(b^2) - a^2 * (2y_k^2 + 2y_k + 1)
            // p_(i+1) - p_i = 4b^2 * x_(k+1) + 2b^2 - 2a^2 * (y_(k+1)^2 + y_(k+1) - y_k^2 - y_k)
            //
            // p_i < -a^2/2
            //      y_(k+1) = y_k
            //      p_(i+1) = p_i + 4b^2 * x_(k+1) + 2b^2
            // p_i >= -a^2/2
            //      y_(k+1) = y_k + 1
            //      p_(i+1) = p_i + 4b^2 * x_(k+1) + 2b^2 - 4a^2 * y_(k+1)

            Point center = hyperbol.center;
            int a = hyperbol.a;
            int b = hyperbol.b;

            // y incre faster than x incre
            int x = a;
            int y = 0;
            int x_incre = 1;
            int y_incre = 1;

            // p_0 = 2a^2 - 2ab^2 - b^2
            int error_step = 2 * a * a - 2 * a * b * b - b * b;

            while (x * b * b - y * a * a > 0 && x >= 0 && x < bitmap.Width &&
                    y >= 0 && y < bitmap.Height)
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
                if (error_step * 2 + b * b < 0)
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

            // x incre faster than y incre

            // p_i = 2b^2 * (x_k + 1)^2 - 2(a^2)(b^2) - a^2 * (2y_k^2 + 2y_k + 1)
            error_step = 2 * b * b * (x + 1) * (x + 1) - 2 * a * a * b * b - a * a * (2 * y * y + 2 * y + 1);

            while (x * b * b - y * a * a <= 0 && x >= 0 && x < bitmap.Width &&
                    y >= 0 && y < bitmap.Height)
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
                if (error_step * 2 + a * a < 0)
                {
                    // p_(i+1) = p_i + 4b^2 * x_(k+1) + 2b^2
                    error_step += 4 * b * b * x + 2 * b * b;
                }
                else
                {
                    y += y_incre;
                    // p_(i+1) = p_i + 4b^2 * x_(k+1) + 2b^2 - 4a^2 * y_(k+1)
                    error_step += 4 * b * b * x + 2 * b * b - 4 * a * a * y;
                }
            }
        }

        public void MidPoint(Hyperbol hyperbol, Color color)
        {
            // Explain MidPoint algorithm
            // F(x, y) = x^2/a^2 - y^2/b^2 - 1
            //
            // y increase faster than x increase
            // F(x + 1/2, y + 1)
            // p_i = 4(a^2)(b^2) * F(x + 1/2, y + 1)
            //
            // p_i = 4b^2 * (x_k + 1/2)^2 - 4a^2 * (y_k + 1)^2 - 4(a^2)(b^2)
            // p_(i+1) - p_i = 4b^2 * (x_(k+1)^2 + x_(k+1) - x_k^2 - x_k) - 8a^2 * y_(k+1) - 4a^2
            //
            // p_i < 0 (outside)
            //      x_(k+1) = x_k + 1
            //      p_(i+1) = p_i + 8b^2 * x_(k+1) - 8a^2 * y_(k+1) - 4a^2
            // p_i >= 0
            //      x_(k+1) = x_k
            //      p_(i+1) = p_i - 8a^2 * y_(k+1) - 4a^2
            // start from Point(a, 0)
            // p_0 = 4ab^2 + b^2 - 4a
            //
            // x increase faster than y increase
            // F(x + 1, y + 1/2) = (x + 1)^2/a^2 - (y + 1/2)^2/b^2 - 1
            // p_i = 4(a^2)(b^2) * F(x + 1, y + 1/2)
            //
            // p_i = 4b^2 * (x_k + 1)^2 - 4a^2 * (y_k + 1/2)^2 - 4(a^2)(b^2)
            // p_(i+1) - p_i = 8b^2 * x_(k+1) + 4b^2 - 4a^2 * (y_(k+1)^2 + y_(k+1) - y_k^2 - y_k)
            //
            // p_i < 0
            //      y_(k+1) = y_k
            //      p_(i+1) = p_i + 8b^2 * x_(k+1) + 4b^2
            // p_i >= 0
            //      y_(k+1) = y_k + 1
            //      p_(i+1) = p_i + 8b^2 * x_(k+1) + 4b^2 - 8a^2 * y_(k+1)

            Point center = hyperbol.center;
            int a = hyperbol.a;
            int b = hyperbol.b;

            // y incre faster than x incre
            int x = a;
            int y = 0;
            int x_incre = 1;
            int y_incre = 1;

            // p_0 = 4ab^2 + b^2 - 4a
            int error_step = 4 * a * b * b + b * b - 4 * a;

            while (x * b * b - y * a * a > 0 && x >= 0 && x < bitmap.Width &&
                    y >= 0 && y < bitmap.Height)
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
                    x += x_incre;
                    // p_(i+1) = p_i + 8b^2 * x_(k+1) - 8a^2 * y_(k+1) - 4a^2
                    error_step += 8 * b * b * x - 8 * a * a * y - 4 * a * a;
                }
                else
                {
                    // p_(i+1) = p_i - 8a^2 * y_(k+1) - 4a^2
                    error_step += 0 - 8 * a * a * y - 4 * a * a;
                }
            }

            // x incre faster than y incre

            // p_i = 4b^2 * (x_k + 1)^2 - 4a^2 * (y_k + 1/2)^2 - 4(a^2)(b^2)
            error_step = 4 * b * b * (x + 1) * (x + 1) - a * a * (2 * y + 1) * (2 * y + 1) - 4 * a * a * b * b;

            while (x * b * b - y * a * a <= 0 && x >= 0 && x < bitmap.Width &&
                    y >= 0 && y < bitmap.Height)
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
        }
    }
}