using System.Drawing.Imaging;
namespace Mmosoft.ImageProcessing
{
    /// <summary>
    /// Processing data directly using Bitmap object is too slow.
    /// A better way is working with Pixel data in Pixel[,]
    /// 
    /// This class moving data between BitmapData object and Pixel[,] array.
    /// </summary>
    public static class Pixmap
    {
        /// <summary>
        /// Moving bitmap data of Bitmap object to Pixel[,] array
        /// </summary>
        /// <param name="bmData"></param>
        /// <param name="pxs"></param>
        unsafe public static void CopyDataTo(this BitmapData bmData, out Pixel[,] pxs)
        {
            pxs = new Pixel[bmData.Width, bmData.Height];
            byte* ptr = (byte*)bmData.Scan0;
            int lfBits = bmData.Stride - bmData.Width * 4;
            for (int scanLine = 0; scanLine < bmData.Height; ++scanLine)
            {
                for (int pxi = 0; pxi < bmData.Width; ++pxi)
                {
                    pxs[pxi, scanLine] = new Pixel(*ptr++, * ptr++, *ptr++, *ptr++);
                }
                ptr += lfBits; // shift lf bits
            }
        }

        /// <summary>
        /// Moving data from Pixel[,] array to bitmap data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bmData"></param>
        unsafe public static void CopyDataTo(this Pixel[,] data, BitmapData bmData)
        {
            byte* ptr = (byte*)bmData.Scan0;
            int lfBits = bmData.Stride - bmData.Width * 4; //4 = a, r, g, b
            Pixel px;
            for (int scanLine = 0; scanLine < data.GetLength(1); scanLine++)
            {
                for (int pxi = 0; pxi < data.GetLength(0); pxi++)
                {
                    px = data[pxi, scanLine];
                    *ptr++ = px.A;
                    *ptr++ = px.B;
                    *ptr++ = px.G;
                    *ptr++ = px.R;
                }
                ptr += lfBits;
            }
        }
    }
}