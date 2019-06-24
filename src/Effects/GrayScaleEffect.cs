namespace Mmosoft.ImageProcessing.Effects
{
    public class GrayScaleFilter : IImageEffect
    {
        public void Apply(Pixel[,] pxs)
        {
            Pixel px;
            byte grayscale;
            for (int i = 0, width = pxs.GetLength(0); i < width; i++)
            {
                for (int j = 0, height = pxs.GetLength(1); j < height; j++)
                {
                    px = pxs[i, j];
                    grayscale = (byte)(0.299 * px.R + 0.587 * px.G + 0.114 * px.B);
                    px.R = grayscale;
                    px.G = grayscale;
                    px.B = grayscale;
                    pxs[i, j] = px;
                }
            }
        }
    }
}
