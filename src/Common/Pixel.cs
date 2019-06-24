using System.Runtime.InteropServices;
namespace Mmosoft.ImageProcessing
{
    /// <summary>
    /// A data structure which hold data of RGB color channel
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Pixel
    {
        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        // It's always return in inverse order
        // So Argb data will be returned as bgra
        public Pixel(byte b, byte g, byte r, byte a)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return string.Format("R: {0}, G: {1}, B: {2}", R, G, B);
        }
    }
}
