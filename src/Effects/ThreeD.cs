namespace Mmosoft.ImageProcessing.Effects
{
    public class ThreeD : IImageEffect
    {
        public void Apply(Pixmap pxs)
        {
            int offset = 3;

            Pixmap pxsc = pxs.DeepCopy();
            Pixel pxscpx;
            for (int row = 0, jMax = pxs.Height; row < jMax; row++)
            {
                for (int col = offset, iMax = pxs.Width - offset; col < iMax; col++)
                {
                    pxscpx = pxsc[row, col];
                    pxscpx.B = pxs[row, col + offset].B;
                    pxscpx.R = pxs[row, col - offset].R;
                    pxsc[row, col] = pxscpx;
                }
            }

            for (int row = 0, jMax = pxs.Height; row < jMax; row++)
            {
                for (int col = 0, iMax = pxs.Width; col < iMax; col++)
                {
                    pxs[row, col] = pxsc[row, col];
                }
            }
        }
    }
}
