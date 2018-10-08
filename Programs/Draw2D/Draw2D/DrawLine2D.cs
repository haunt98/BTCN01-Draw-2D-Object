using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Draw2D
{
    public class Line2D
    {
        public Point p1 { get; set; }
        public Point p2 { get; set; }

        public Line2D(Point pp1, Point pp2)
        {
            p1 = new Point(pp1.X, pp1.Y);
            p2 = new Point(pp2.X, pp2.Y);
        }

        // if p1 and p2 is the same
        public Boolean isPoint()
        {
            return p1.Equals(p2);
        }
    }

    public class DrawLine2D
    {
        private Bitmap bitmap;

        public DrawLine2D(Bitmap b)
        {
            bitmap = b;
        }

        // Use the idea from the code in following links
        // https://www.tutorialspoint.com/computer_graphics/line_generation_algorithm.htm
        public void DDA(Line2D line2D, Color color)
        {
            Point p1 = line2D.p1;
            Point p2 = line2D.p2;

            if (line2D.isPoint())
            {
                bitmap.SetPixel(p1.X, p1.Y, color);
                return;
            }

            int Dx = p2.X - p1.X;
            int Dy = p2.Y - p1.Y;

            int steps = Math.Abs(Dx) > Math.Abs(Dy) ? Math.Abs(Dx) : Math.Abs(Dy);

            float x_increment = Dx / (float)steps;
            float y_increment = Dy / (float)steps;

            float x_precise = p1.X;
            float y_precise = p1.Y;
            int x_round, y_round;

            for (int i = 0; i < steps; ++i)
            {
                x_round = (int)Math.Round(x_precise, MidpointRounding.AwayFromZero);
                y_round = (int)Math.Round(y_precise, MidpointRounding.AwayFromZero);
                bitmap.SetPixel(x_round, y_round, color);
                x_precise += x_increment;
                y_precise += y_increment;
            }
        }

        // Use the idea from the code in following links
        // https://csustan.csustan.edu/~tom/Lecture-Notes/Graphics/Bresenham-Line/Bresenham-Line.pdf
        public void Bresenham(Line2D line2D, Color color)
        {
            Point p1 = line2D.p1;
            Point p2 = line2D.p2;

            if (line2D.isPoint())
            {
                bitmap.SetPixel(p1.X, p1.Y, color);
                return;
            }

            int Dx = p2.X - p1.X;
            int Dy = p2.Y - p1.Y;
            int x_increment, y_increment, x_draw, y_draw;

            if (Dy < 0)
            {
                Dy = -Dy;
                y_increment = -1;
            }
            else
            {
                y_increment = 1;
            }

            if (Dx < 0)
            {
                Dx = -Dx;
                x_increment = -1;
            }
            else
            {
                x_increment = 1;
            }

            // mulitply Dy, Dx by 2
            Dy <<= 1;
            Dx <<= 1;

            // value of x, y actually draw
            x_draw = p1.X;
            y_draw = p1.Y;
            bitmap.SetPixel(x_draw, y_draw, color);

            // for checking if y_draw need to be y or y + 1
            int error_step;

            if (Dx > Dy)
            {
                error_step = Dy - (Dx >> 1);
                while (x_draw != p2.X)
                {
                    x_draw += x_increment;
                    if (error_step >= 0)
                    {
                        y_draw += y_increment;
                        error_step -= Dx;
                    }
                    error_step += Dy;
                    bitmap.SetPixel(x_draw, y_draw, color);
                }
            }
            else
            {
                error_step = Dx - (Dy >> 1);
                while (y_draw != p2.Y)
                {
                    if (error_step >= 0)
                    {
                        x_draw += x_increment;
                        error_step -= Dy;
                    }
                    y_draw += y_increment;
                    error_step += Dx;
                    bitmap.SetPixel(x_draw, y_draw, color);
                }
            }
        }

        // Use the idea from the code in following links
        // https://www.geeksforgeeks.org/mid-point-line-generation-algorithm/
        public void MidPoint(Line2D line2D, Color color)
        {
            Point p1 = line2D.p1;
            Point p2 = line2D.p2;

            if (line2D.isPoint())
            {
                bitmap.SetPixel(p1.X, p1.Y, color);
                return;
            }

            int Dx = p2.X - p1.X;
            int Dy = p2.Y - p1.Y;
            int x_increment, y_increment, x_draw, y_draw;

            if (Dy < 0)
            {
                Dy = -Dy;
                y_increment = -1;
            }
            else
            {
                y_increment = 1;
            }

            if (Dx < 0)
            {
                Dx = -Dx;
                x_increment = -1;
            }
            else
            {
                x_increment = 1;
            }

            // value of x, y actually draw
            x_draw = p1.X;
            y_draw = p1.Y;
            bitmap.SetPixel(x_draw, y_draw, color);

            int decision;

            if (Dx > Dy)
            {
                decision = Dy - (Dx >> 1);
                while (x_draw != p2.X)
                {
                    x_draw += x_increment;

                    // Eest
                    if (decision < 0)
                    {
                        decision += Dy;
                    }
                    // North
                    else
                    {
                        decision += Dy - Dx;
                        y_draw += y_increment;
                    }

                    bitmap.SetPixel(x_draw, y_draw, color);
                }
            }
            else
            {
                decision = Dx - (Dy >> 1);
                while (y_draw != p2.Y)
                {
                    if (decision < 0)
                    {
                        decision += Dx;
                    }
                    else
                    {
                        decision += Dx - Dy;
                        x_draw += x_increment;
                    }

                    y_draw += y_increment;

                    bitmap.SetPixel(x_draw, y_draw, color);
                }
            }
        }

        // Use the idea from the code in following links
        // https://en.wikipedia.org/wiki/Xiaolin_Wu%27s_line_algorithm
        // https://www.geeksforgeeks.org/anti-aliased-line-xiaolin-wus-algorithm/
        // TODO find a way to setPixel with float color
        public void XiaolinWu(Line2D line2D)
        {
            Point p1 = line2D.p1;
            Point p2 = line2D.p2;

            Boolean isDyLargeThanDx = Math.Abs(p2.Y - p1.Y) > Math.Abs(p2.X - p1.X);

            // make a copy for changing x, y cordinate
            Point p1_copy = new Point(p1.X, p1.Y);
            Point p2_copy = new Point(p2.X, p2.Y);

            // check if slope m > 1
            // or draw from p2 to p1
            if (isDyLargeThanDx)
            {
                // x <--> y
                int temp = p1_copy.X;
                p1_copy.X = p1_copy.Y;
                p1_copy.Y = temp;
                temp = p2_copy.X;
                p2_copy.X = p2_copy.Y;
                p2_copy.Y = temp;
            }
            if (p1_copy.X > p2_copy.X)
            {
                // p1 <--> p2
                int temp = p1_copy.X;
                p1_copy.X = p2_copy.X;
                p2_copy.X = temp;
                temp = p1_copy.Y;
                p1_copy.Y = p2_copy.Y;
                p2_copy.Y = temp;
            }

            int Dx = p2_copy.X - p1_copy.X;
            int Dy = p2_copy.Y - p1_copy.Y;
            float slopeOrGradient = Dx == 0 ? 1 : (float)Dy / Dx;

            // point p1
            int x_end = roundXW(p1_copy.X);
            float y_end = p1_copy.Y + slopeOrGradient * (x_end - p1_copy.X);
            float x_gap = rf_partXW(p1_copy.X + (float)0.5);
            int x_from = x_end;
            int y_from = i_partXW(y_end);
            if (isDyLargeThanDx)
            {
            }
            else
            {
            }
        }

        private int i_partXW(float x)
        {
            return (int)Math.Floor(x);
        }

        private int roundXW(float x)
        {
            return i_partXW(x + (float)0.5);
        }

        private float f_partXW(float x)
        {
            return x - (float)Math.Floor(x);
        }

        private float rf_partXW(float x)
        {
            return 1 - f_partXW(x);
        }
    }
}