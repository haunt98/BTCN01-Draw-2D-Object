using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2D
{
    public class Circle
    {
        public Point center { get; set; }
        public int R { get; set; }

        public Circle(Point c, int r)
        {
            center = new Point(c.X, c.Y);
            R = r;
        }
    }

    public class DrawCircle
    {
        private Bitmap bitmap;

        public DrawCircle(Bitmap b)
        {
            bitmap = b;
        }

        // Use the idea from slide
        public void DDA(Circle circle2D, Color color)
        {
            Point center = circle2D.center;
            int R = circle2D.R;

            bitmap.SetPixel(center.X, center.Y + R, color);
            bitmap.SetPixel(center.X, center.Y - R, color);
            bitmap.SetPixel(center.X + R, center.Y, color);
            bitmap.SetPixel(center.X - R, center.Y, color);

            int x = 1;
            int y = (int)Math.Round(Math.Sqrt(R * R - x * x));

            while (x <= y)
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

        // Use the idea from below
        // https://www.slideshare.net/tahersb/bresenham-circle
        public void Bresenham(Circle circle2D, Color color)
        {
            // Explain Bresenham algorithm
            // F(x, y) = x^2 + y^2 - R^2
            // F(x + 1, y) and F(x + 1, y - 1)
            // one is positive and one is negative
            //
            // p_i = F(x_k + 1, y_k) + F(x_k + 1, y_k - 1)
            // p_i = 2(x_k + 1)^2 + y_k^2 + (y_k - 1)^2 - 2R^2
            // p_(i+1) - p_i = 2(2x_k + 3) + 2(y_(k+1)^2 - y_k^2) - 2(y_(k+1) - y_k)
            //
            // p_i < 0
            //      y_(k+1) = y_k
            //      p_(i+1) = p_i + 4x_(k+1) + 2
            // p_i >= 0
            //      y_(k+1) = y_k - 1
            //      p_(i+1) = p_i + 4x_(k+1) + 2 - 4y_(k+1)
            //
            // p_0 = 3 - 2R

            Point center = circle2D.center;
            int R = circle2D.R;

            int x = 0;
            int y = R;
            int x_increment = 1;
            int y_increment = -1;

            // error_step is p_i
            int error_step = 3 - 2 * R;

            while (x <= y)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);
                bitmap.SetPixel(center.X + y, center.Y + x, color);
                bitmap.SetPixel(center.X + y, center.Y - x, color);
                bitmap.SetPixel(center.X - y, center.Y + x, color);
                bitmap.SetPixel(center.X - y, center.Y - x, color);

                x += x_increment;
                if (error_step < 0)
                {
                    // p_(i+1) = p_i + 4x_(k+1) + 2
                    error_step += 4 * x + 2;
                }
                else
                {
                    y += y_increment;
                    // p_(i+1) = p_i + 4x_(k+1) + 2 - 4y_(k+1)
                    error_step += 4 * x + 2 - 4 * y;
                }
            }
        }

        public void MidPoint(Circle circle2D, Color color)
        {
            // Explain MidPoint algorithm
            // F(x, y) = x^2 + y^2 - R^2
            // F(x, y) < 0 inside circle
            // F(x, y) > 0 outside circle
            //
            // p_k = 4F(x_k + 1, y_k - 1/2)
            // p_k = 4(x_k + 1)^2 + 4(y_k - 1/2)^2 - 4R^2
            //
            // p_(k+1) = 4(x_k + 2)^2 + 4(y_(k+1)^2 - 1/2) - 4R^2
            // p_(k+1) = p_k + 8(x_k + 1) + 4(y_(k+1)^2 - y_k^2) - 4(y_(k+1) - y_k) + 4
            // p_k < 0
            //      y_(k+1) = y_k
            //      p_(k+1) = p_k + 8(x_k + 1) + 4
            //      or p_(k+1) = p_k + 8x_(k+1) + 4
            // p_k >= 0
            //      y_(k+1) = y_k - 1
            //      p_(k+1) = p_k + 8(x_k + 1) + 4 - 8y_(k+1)
            //      or p_(k+1) = p_k + 8x_(k+1) + 4 - 8y_(k+1)
            //
            // p_0 = 4F(x_0 + 1, y_0 - 1/2)
            // p_0 = 4F(1, R - 1/2)
            // p_0 = 5 - 4R

            Point center = circle2D.center;
            int R = circle2D.R;

            int x = 0;
            int y = R;
            int x_increment = 1;
            int y_increment = -1;

            // error_step is p_i
            int error_step = 5 - 4 * R;

            while (x <= y)
            {
                bitmap.SetPixel(center.X + x, center.Y + y, color);
                bitmap.SetPixel(center.X + x, center.Y - y, color);
                bitmap.SetPixel(center.X - x, center.Y + y, color);
                bitmap.SetPixel(center.X - x, center.Y - y, color);
                bitmap.SetPixel(center.X + y, center.Y + x, color);
                bitmap.SetPixel(center.X + y, center.Y - x, color);
                bitmap.SetPixel(center.X - y, center.Y + x, color);
                bitmap.SetPixel(center.X - y, center.Y - x, color);

                x += x_increment;
                if (error_step < 0)
                {
                    error_step += 8 * x + 4;
                }
                else
                {
                    y += y_increment;
                    error_step += 8 * x + 4 - 8 * y;
                }
            }
        }
    }
}