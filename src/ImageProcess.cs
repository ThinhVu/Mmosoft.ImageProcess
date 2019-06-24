using Mmosoft.ImageProcessing.Effects;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Mmosoft.ImageProcessing
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
            var pxs = new Pixmap(b);
            foreach (var filter in _effects)
                filter.Apply(pxs);
            pxs.MoveDataTo(b);
        }
    }
}