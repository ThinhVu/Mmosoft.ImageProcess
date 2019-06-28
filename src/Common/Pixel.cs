using System.Runtime.InteropServices;
namespace Mmosoft.ImageProcessing
{
    /// <summary>
    /// A data structure which hold data of RGB color channel
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Pixel
    {
        public byte A;
        public byte R;
        public byte G;
        public byte B;

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
            return string.Format("A: {0} R: {1}, G: {2}, B: {3}", A, R, G, B);
        }
    }
}
