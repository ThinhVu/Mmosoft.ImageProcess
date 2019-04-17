namespace ImageProcess.Effects
{
    public class InvertColorFilterHandler : IImageEffect
    {
        public void Apply(Pixel[,] pxs)
        {
            int width = pxs.GetLength(0);
            int height = pxs.GetLength(1);
            Pixel px;
            for (int scanLine = 0; scanLine < height; scanLine++)
            {
                for (int x = 0; x < width; x++)
                {
                    px = pxs[x, scanLine];
                    px.R = (byte)(255 - px.R);
                    px.G = (byte)(255 - px.G);
                    px.B = (byte)(255 - px.B);
                    pxs[x, scanLine] = px;
                }
            }
        }
    }
}
