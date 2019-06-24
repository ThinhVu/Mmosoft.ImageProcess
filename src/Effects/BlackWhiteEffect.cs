namespace Mmosoft.ImageProcessing.Effects
{
    public class BlackWhiteFilter : IImageEffect
    {
        private byte _threshold;

        public BlackWhiteFilter(byte threshold)
        {
            _threshold = threshold;
        }

        public void Apply(Pixmap pxs)
        {
            new GrayScaleFilter().Apply(pxs);
            Pixel px;
            for (int row = 0, height = pxs.Height; row < height; row++)
            {
                for (int col = 0, width = pxs.Width; col <  width; col++)
                {
                    px = pxs[row, col];
                    px.R = px.G = px.B = (byte)(px.R < _threshold ? 0 : 255);
                    pxs[row, col] = px;
                }
            }
        }
    }
}
