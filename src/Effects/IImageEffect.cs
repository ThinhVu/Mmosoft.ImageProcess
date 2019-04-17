namespace ImageProcess.Effects
{
    public interface IImageEffect
    {
        /// <summary>
        /// Apply special effect for an image
        /// </summary>
        /// <param name="pxs"></param>
        void Apply(Pixel[,] pxs);
    }
}
