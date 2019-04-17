using System.Runtime.InteropServices;
namespace ImageProcess
{
    /// <summary>
    /// A data structure which hold data of RGB color channel
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Pixel
    {
        public byte R;
        public byte G;
        public byte B;

        public Pixel(byte b, byte g, byte r)
        {
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
