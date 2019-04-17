using ImageProcess.Effects;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcess
{
    public class ImageProcess
    {
        private List<IImageEffect> _effects;

        public ImageProcess()
        {
            _effects = new List<IImageEffect>();
        }

        public void Add(IImageEffect filter)
        {
            _effects.Add(filter);
        }

        public void Process(Bitmap b)
        {
            var rectLock = new Rectangle(0, 0, b.Width, b.Height);
            BitmapData bitmapData = b.LockBits(rectLock, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Pixel[,] pxs = null;
            bitmapData.CopyDataTo(out pxs);             
            foreach (var filter in _effects)
                filter.Apply(pxs);
            pxs.CopyDataTo(bitmapData);
            b.UnlockBits(bitmapData);
        }
    }
}