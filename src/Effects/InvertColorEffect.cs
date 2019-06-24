namespace Mmosoft.ImageProcessing.Effects
{
    public class InvertColorEffect : IImageEffect
    {
        public void Apply(Pixmap pxs)
        {
            int width = pxs.Width;
            int height = pxs.Height;
            Pixel px;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    px = pxs[row, col];
                    px.R = (byte)(255 - px.R);
                    px.G = (byte)(255 - px.G);
                    px.B = (byte)(255 - px.B);
                    pxs[row, col] = px;
                }
            }
        }
    }
}
