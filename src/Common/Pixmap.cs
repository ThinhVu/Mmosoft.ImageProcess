using System.Drawing;
using System.Drawing.Imaging;

namespace Mmosoft.ImageProcessing
{
    /// <summary>
    /// Processing data directly using Bitmap object is too slow.
    /// A better way is working with Pixel data in Pixmap
    /// 
    /// This class moving data between BitmapData object and Pixmap object.
    /// </summary>
    public class Pixmap
    {
        private const int PIXEL_BYTE_SIZE = 4; // A, R, G, B
        private const PixelFormat PIXEL_FORMAT = PixelFormat.Format32bppArgb;

        // contains pixel information in ARGB format
        private Pixel[,] _bitmapData;

        public int Width
        {
            get { return _bitmapData.GetLength(0); }
        }
        public int Height
        {
            get { return _bitmapData.GetLength(1); }
        }
        public Pixel this[int rowIndex, int columnIndex]
        {
            get
            {
                // _bitmapData is 2 dimensions array which have:
                //  + dimension 0 is width
                //  + dimensions 1 is height
                // so we need to swap the position of row, column param
                return _bitmapData[columnIndex, rowIndex];
            }
            set
            {
                _bitmapData[columnIndex, rowIndex] = value;
            }
        }

        public Pixmap()
        {
            _bitmapData = new Pixel[0, 0];
        }

        // internal use for deep copy
        private Pixmap(Pixel[,] pixelData)
        {
            int width = pixelData.GetLength(0);
            int height = pixelData.GetLength(1);

            _bitmapData = new Pixel[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _bitmapData[i, j] = pixelData[i, j];
                }
            }
        }

        public Pixmap(BitmapData bitmapData)
        {
            GetDataFrom(bitmapData);
        }

        public Pixmap(Bitmap bitmap)
        {
            var bitmapData = LockBits(bitmap);
            GetDataFrom(bitmapData);
            UnlockBits(bitmap, bitmapData);
        }

        /// <summary>
        /// Moving bitmap data of Bitmap object to Pixmap object
        /// </summary>
        /// <param name="bitmapData"></param>
        /// <param name="pxs"></param>
        unsafe public void GetDataFrom(BitmapData bitmapDataObject)
        {
            BitmapData bitmapData = bitmapDataObject;
            _bitmapData = new Pixel[bitmapData.Width, bitmapData.Height];
            byte* ptr = (byte*)bitmapData.Scan0;
            // left bits - the number of bits at the end of each line which don't contains pixel data
            int lfBits = bitmapData.Stride - bitmapData.Width * PIXEL_BYTE_SIZE;
            for (int scanLine = 0; scanLine < bitmapData.Height; ++scanLine)
            {
                for (int pxi = 0; pxi < bitmapData.Width; ++pxi)
                {
                    _bitmapData[pxi, scanLine] = new Pixel(*ptr++, * ptr++, *ptr++, *ptr++);
                }
                ptr += lfBits; // shift lf bits
            }
        }

        /// <summary>
        /// Moving data from Pixmap object to bitmap data object
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bmData"></param>
        unsafe public void MoveDataTo(BitmapData bmDataObject)
        {
            BitmapData bmData = bmDataObject;

            byte* ptr = (byte*)bmData.Scan0;
            int lfBits = bmData.Stride - bmData.Width * 4; //4 = a, r, g, b
            Pixel px;
            for (int scanLine = 0; scanLine < _bitmapData.GetLength(1); scanLine++)
            {
                for (int pxi = 0; pxi < _bitmapData.GetLength(0); pxi++)
                {
                    px = _bitmapData[pxi, scanLine];
                    *ptr++ = px.B;
                    *ptr++ = px.G;
                    *ptr++ = px.R;
                    *ptr++ = px.A;
                }
                ptr += lfBits;
            }
        }

        /// <summary>
        /// Moving data from PixMap object to existed bitmap object
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bmData"></param>
        unsafe public void MoveDataTo(Bitmap bitmapObject)
        {
            Bitmap bitmap = bitmapObject;
            var bitmapData = LockBits(bitmap);
            MoveDataTo(bitmapData);
            UnlockBits(bitmap, bitmapData);
        }

        /// <summary>
        /// Create bitmap image
        /// </summary>
        /// <returns></returns>
        unsafe public Bitmap CreateBitmap()
        {
            Bitmap bitmap = new Bitmap(_bitmapData.GetLength(0), _bitmapData.GetLength(1));
            MoveDataTo(bitmap);
            return bitmap;
        }

        public Pixmap DeepCopy()
        {
            return new Pixmap(_bitmapData);
        }

        private BitmapData LockBits(Bitmap bitmap)
        {
            return bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                PIXEL_FORMAT);
        }
        private void UnlockBits(Bitmap bitmap, BitmapData bitmapData)
        {
            bitmap.UnlockBits(bitmapData);
        }
    }
}