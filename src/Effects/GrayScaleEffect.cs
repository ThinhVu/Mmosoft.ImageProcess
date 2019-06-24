namespace Mmosoft.ImageProcessing.Effects
{
    public class GrayScaleFilter : IImageEffect
    {
        public void Apply(Pixmap pxs)
        {
            Pixel px;
            byte grayscale;

            for (int row = 0, height = pxs.Height; row < height; row++)
            {
                for (int col = 0, width = pxs.Width; col < width; col++)
                {
                    px = pxs[row, col];
                    grayscale = (byte)(0.299 * px.R + 0.587 * px.G + 0.114 * px.B);
                    px.R = grayscale;
                    px.G = grayscale;
                    px.B = grayscale;
                    pxs[row, col] = px;
                }
            }
        }
    }
}
