using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw2D
{
    public class DrawCircle2D
    {
        private Bitmap bitmap;

        public DrawCircle2D(Bitmap b)
        {
            bitmap = b;
        }

        // Use the idea from slide
        public void EightSymmetry(Point pCenter, int R, Color color)
        {
            bitmap.SetPixel(pCenter.X, pCenter.Y + R, color);
            bitmap.SetPixel(pCenter.X, pCenter.Y - R, color);
            bitmap.SetPixel(pCenter.X + R, pCenter.Y, color);
            bitmap.SetPixel(pCenter.X - R, pCenter.Y, color);
            int x = 1;
            int y = (int)Math.Round(Math.Sqrt(R * R - x * x), MidpointRounding.AwayFromZero);
            while (x < y)
            {
                bitmap.SetPixel(pCenter.X + x, pCenter.Y + y, color);
                bitmap.SetPixel(pCenter.X + x, pCenter.Y - y, color);
                bitmap.SetPixel(pCenter.X - x, pCenter.Y + y, color);
                bitmap.SetPixel(pCenter.X - x, pCenter.Y - y, color);
                bitmap.SetPixel(pCenter.X + y, pCenter.Y + x, color);
                bitmap.SetPixel(pCenter.X + y, pCenter.Y - x, color);
                bitmap.SetPixel(pCenter.X - y, pCenter.Y + x, color);
                bitmap.SetPixel(pCenter.X - y, pCenter.Y - x, color);
                ++x;
                y = (int)Math.Round(Math.Sqrt(R * R - x * x), MidpointRounding.AwayFromZero);
            }
        }
    }
}