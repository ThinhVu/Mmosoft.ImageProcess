namespace Mmosoft.ImageProcessing.Blends
{
    // https://en.wikipedia.org/wiki/Blend_modes
    public interface IImageBlend
    {
        void Apply(Pixmap lowerLayer, Pixmap topLayer);
    }
}
