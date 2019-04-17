using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcess.Statistics
{
    public class Histogram
    {
        private byte[] _red;
        public byte[] Red { get { return _red; } }

        private byte[] _green;
        public byte[] Green { get { return _green; } }

        private byte[] _blue;
        public byte[] Blue { get { return _blue; } }

        private Histogram()
        {
            _red = new byte[256];
            _green = new byte[256];
            _blue = new byte[256];
        }

        public static Histogram GetHistorgram(Bitmap b)
        {
            var rectLock = new Rectangle(0, 0, b.Width, b.Height);
            BitmapData bitmapData = b.LockBits(rectLock, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Pixel[,] pxs = null;
            bitmapData.CopyDataTo(out pxs);
            b.UnlockBits(bitmapData);

            // 
            var hi = new Histogram();
            Pixel p;
            for (int i = 0, len0 = pxs.GetLength(0); i < len0; i++)
            {
                for (int j = 0, len1 = pxs.GetLength(1); j < len1; j++)
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
