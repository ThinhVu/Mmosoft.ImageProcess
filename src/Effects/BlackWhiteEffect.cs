namespace Mmosoft.ImageProcessing.Effects
{
    public class BlackWhiteFilter : IImageEffect
    {
        private byte _threshold;

        public BlackWhiteFilter(byte threshold)
        {
            _threshold = threshold;
        }

        public void Apply(Pixel[,] pxs)
        {
            new GrayScaleFilter().Apply(pxs);
            Pixel px;
            for (int scanLine = 0, height = pxs.GetLength(1); scanLine < height; scanLine++)
            {
                for (int x = 0, width = pxs.GetLength(0); x <  width; x++)
                {
                    px = pxs[x, scanLine];
                    px.R = px.G = px.B = (byte)(px.R < _threshold ? 0 : 255);
                    pxs[x, scanLine] = px;
                }
            }
        }
    }
}
