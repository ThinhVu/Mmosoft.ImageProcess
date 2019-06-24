namespace Mmosoft.ImageProcessing.Effects
{
    public class ThreeD : IImageEffect
    {
        public void Apply(Pixel[,] pxs)
        {
            int offset = 3;

            Pixel[,] pxsc = new Pixel[pxs.GetLength(0), pxs.GetLength(1)];

            for (int i = 0, iMax = pxs.GetLength(0); i < iMax; i++)
            {
                for (int j = 0, jMax = pxs.GetLength(1); j < jMax; j++)
                {
                    pxsc[i, j] = pxs[i, j];
                }
            }

            for (int i = offset, iMax = pxs.GetLength(0) - offset; i < iMax; i++)
            {
                for (int j = 0, jMax = pxs.GetLength(1); j < jMax; j++)
                {
                    pxsc[i, j].B = pxs[i + offset, j].B;
                    pxsc[i, j].R = pxs[i - offset, j].R;
                }
            }

            for (int i = 0, iMax = pxs.GetLength(0); i < iMax; i++)
            {
                for (int j = 0, jMax = pxs.GetLength(1); j < jMax; j++)
                {
                    pxs[i, j] = pxsc[i, j];
                }
            }
        }
    }
}
