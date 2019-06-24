using System.Drawing;

namespace Mmosoft.ImageProcessing.Statistics
{
    public class Histogram
    {
        public byte[] Red { get; private set; }
        public byte[] Green { get; private set; }
        public byte[] Blue { get; private set; }

        private Histogram()
        {
            Red = new byte[256];
            Green = new byte[256];
            Blue = new byte[256];
        }

        public static Histogram GetHistorgram(Bitmap b)
        {
            Pixmap pxs = new Pixmap(b);
            // 
            var hi = new Histogram();
            Pixel p;
            for (int i = 0, len0 = pxs.Width; i < len0; i++)
            {
                for (int j = 0, len1 = pxs.Height; j < len1; j++)
                {
                    p = pxs[i, j];
                    hi.Red[p.R]++;
                    hi.Blue[p.B]++;
                    hi.Green[p.G]++;
                }
            }

            return hi;
        }
    }
}
