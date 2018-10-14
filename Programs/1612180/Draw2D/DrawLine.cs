using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Draw2D
{
    public class Line
    {
        public Point p1 { get; set; }
        public Point p2 { get; set; }

        public Line(Point pp1, Point pp2)
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

    public class DrawLine
    {
        private Bitmap bitmap;

        public DrawLine(Bitmap b)
        {
            bitmap = b;
        }

        // Use the idea from the code in following links
        // https://www.tutorialspoint.com/computer_graphics/line_generation_algorithm.htm
        public void DDA(Line line2D, Color color)
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
                x_round = (int)Math.Round(x_precise);
                y_round = (int)Math.Round(y_precise);
                bitmap.SetPixel(x_round, y_round, color);
                x_precise += x_increment;
                y_precise += y_increment;
            }
        }

        // Use the idea from the code in following links
        // https://csustan.csustan.edu/~tom/Lecture-Notes/Graphics/Bresenham-Line/Bresenham-Line.pdf
        public void Bresenham(Line line2D, Color color)
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

            // if Dy, Dx is negative -> change step in each increment to -1
            // if slope > 1 or < -1, swap Dx with Dy, x with y
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

            // Explain Bresenham algorithm
            // From Point(x_i, y_i) next to Point(x_(i+1), y)
            // Need to know y near y_i or y_i + 1
            // d1 = y - y_i
            // d2 = (y_i + 1) - y
            // if d1 - d2 < 0, y = y_i
            // otherwise y = y_i + 1
            //
            // d1 - d2 = 2y - 2y_i - 1
            // as know Point(x_(i+1), y) on the line,
            // so y = (Dy/Dx) * x_(i+1) + b with b = y_0 - (Dy/Dx) * x0 and x_(i+1) = x_i + 1
            // d1 - d2 = 2(Dy/Dx) * x_i - 2y_i + (2b - 1 + 2(Dy/Dx))
            //
            // p_i = Dx * (d1 - d2)
            // d1 - d2 < 0 <=> p_i < 0 (Use p_i to avoid divide to Dx)
            // p_i = 2Dy * x_i - 2Dx * y_i + (2b * Dx - Dx + 2Dy)
            //
            // p_(i+1) - p_i = 2Dy - 2Dx * (y_(i+1) - y_i)
            //
            // with p_i < 0
            //      y_(i+1) = y_i
            //      p_(i+1) = p_i + 2Dy
            // with p_i >= 0
            //      y_(i+1) = y_i + 1
            //      p_(i+1) = p_i + 2Dy - 2Dx
            //
            // p_0 = 2Dy * x_0 - 2Dx * y_0 + (2b * Dx - Dx + 2Dy)
            // with b = y_0 - (Dy/Dx) * x0
            // p_0 = 2Dy - Dx

            // value of x, y actually draw
            x_draw = p1.X;
            y_draw = p1.Y;
            bitmap.SetPixel(x_draw, y_draw, color);

            // error_step is p_i
            int error_step;

            if (Dx > Dy)
            {
                // init error_step with p_0
                error_step = 2 * Dy - Dx;
                while (x_draw != p2.X)
                {
                    x_draw += x_increment;
                    if (error_step < 0)
                    {
                        error_step += 2 * Dy;
                    }
                    else
                    {
                        y_draw += y_increment;
                        error_step += 2 * Dy - 2 * Dx;
                    }
                    bitmap.SetPixel(x_draw, y_draw, color);
                }
            }
            else
            {
                error_step = 2 * Dx - Dy;
                while (y_draw != p2.Y)
                {
                    if (error_step < 0)
                    {
                        error_step += 2 * Dx;
                    }
                    else
                    {
                        x_draw += x_increment;
                        error_step += 2 * Dx - 2 * Dy;
                    }
                    y_draw += y_increment;
                    bitmap.SetPixel(x_draw, y_draw, color);
                }
            }
        }

        // Bresenham and MidPoint draw line is actually the same
        public void MidPoint(Line line2D, Color color)
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

            // if Dy, Dx is negative -> change step in each increment to -1
            // if slope > 1 or < -1, swap Dx with Dy, x with y
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

            // Explain MidPoint algorithm
            // in Bresenham algorithm, use d1 - d2 to determine y_(i+1)
            // in MidPoint, use y_i + 1/2
            //
            // F(x, y) = Ax + By + C, A > 0
            // F(x, y) < 0 above the line
            //         > 0 below the line
            //
            // mid point is Point(x_(i+1), y_i + 1/2)
            // p_i = 2F(x_(i+1), y_i + 1/2)
            // p_i < 0, line in half below mid point
            // p_i > 0, line in half above mid point
            //
            // p_(i+1) = p_i + 2Dy - 2Dx * (y_(i+1) - y_i)
            // p_0 = 2Dy - Dx
            // same as Bresenham

            // value of x, y actually draw
            x_draw = p1.X;
            y_draw = p1.Y;
            bitmap.SetPixel(x_draw, y_draw, color);

            // error_step is p_i
            int error_step;

            if (Dx > Dy)
            {
                // init error_step with p_0
                error_step = 2 * Dy - Dx;
                while (x_draw != p2.X)
                {
                    x_draw += x_increment;
                    if (error_step < 0)
                    {
                        error_step += 2 * Dy;
                    }
                    else
                    {
                        y_draw += y_increment;
                        error_step += 2 * Dy - 2 * Dx;
                    }
                    bitmap.SetPixel(x_draw, y_draw, color);
                }
            }
            else
            {
                error_step = 2 * Dx - Dy;
                while (y_draw != p2.Y)
                {
                    if (error_step < 0)
                    {
                        error_step += 2 * Dx;
                    }
                    else
                    {
                        x_draw += x_increment;
                        error_step += 2 * Dx - 2 * Dy;
                    }
                    y_draw += y_increment;
                    bitmap.SetPixel(x_draw, y_draw, color);
                }
            }
        }

        // Use the idea from the code in following links
        // https://en.wikipedia.org/wiki/Xiaolin_Wu%27s_line_algorithm
        // https://rosettacode.org/wiki/Xiaolin_Wu%27s_line_algorithm#C.23
        public void XiaolinWu(Line line2D, Color color)
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
            int x_incre, y_incre;
            float gradient;

            // if Dy, Dx is negative -> change step in each increment to -1
            y_incre = Dy < 0 ? -1 : 1;
            x_incre = Dx < 0 ? -1 : 1;

            // x incre faster than y incre
            if (Math.Abs(Dx) > Math.Abs(Dy))
            {
                gradient = Math.Abs(Dy) / (float)Math.Abs(Dx) * y_incre;

                int x_draw = p1.X;
                float float_y = p1.Y;

                while (x_draw != p2.X)
                {
                    float f_part_y = float_y - (float)Math.Floor(float_y);
                    float rf_part_y = 1 - f_part_y;

                    int y_draw = (int)Math.Floor(float_y);
                    if (y_draw >= 0 && y_draw < bitmap.Height)
                    {
                        int alpha = (int)Math.Round(rf_part_y * 255);

                        bitmap.SetPixel(x_draw, y_draw,
                            Color.FromArgb(alpha, color));
                    }
                    if (y_draw + y_incre >= 0 && y_draw + y_incre < bitmap.Height)
                    {
                        int alpha = (int)Math.Round(f_part_y * 255);

                        bitmap.SetPixel(x_draw, y_draw + y_incre,
                            Color.FromArgb(alpha, color));
                    }

                    x_draw += x_incre;
                    float_y += gradient;
                }
            }
            // y incre faster than x incre
            else
            {
                gradient = Math.Abs(Dx) / (float)Math.Abs(Dy) * x_incre;

                int y_draw = p1.Y;
                float float_x = p1.X;

                while (y_draw != p2.Y)
                {
                    float f_part_x = float_x - (float)Math.Floor(float_x);
                    float rf_part_x = 1 - f_part_x;

                    int x_draw = (int)Math.Floor(float_x);
                    if (x_draw >= 0 && x_draw < bitmap.Width)
                    {
                        int alpha = (int)Math.Round(rf_part_x * 255);

                        bitmap.SetPixel(x_draw, y_draw,
                            Color.FromArgb(alpha, color));
                    }
                    if (x_draw + x_incre >= 0 && x_draw + x_incre < bitmap.Width)
                    {
                        int alpha = (int)Math.Round(f_part_x * 255);

                        bitmap.SetPixel(x_draw + x_incre, y_draw,
                            Color.FromArgb(alpha, color));
                    }

                    y_draw += y_incre;
                    float_x += gradient;
                }
            }
        }
    }
}