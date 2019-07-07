using System;
using System.Drawing;

namespace Mmosoft.ImageProcessing.Effects
{
    public class MosaicEffect : IImageEffect
    {
        private int _top;
        private int _left;
        private int _width;
        private int _height;
        private int _size;

        /// <summary>
        /// Mosaic effect
        /// </summary>
        /// <param name="effectiveZone">A zone which mosaic effect will be applied in target image</param>
        /// <param name="size"></param>
        public MosaicEffect(Rectangle effectiveZone, int size)
        {
            Func<int /*actual value*/, 
                 int /*default value if actual value is invalid*/, 
                 int /*returned result*/> GetValidInput = (actualValue, defaultVal) => actualValue < 0 ? defaultVal : actualValue;

            _left = GetValidInput(effectiveZone.Left, 0);
            _top = GetValidInput(effectiveZone.Top, 0);
            _width = GetValidInput(effectiveZone.Width, 0);
            _height = GetValidInput(effectiveZone.Height, 0);

            if (size <= 1)
                throw new Exception("Mosaic size must greater than 1");

            _size = size;
        }

        public void Apply(Pixmap pxs)
        {
            int width = pxs.Width;
            int height = pxs.Height;
            // left/top corner
            if (_left > width) _left = width;
            if (_top > height) _top = height;
            // area
            if (_left + _width > width) _width = width - _left;
            if (_top + _height > height) _height = height - _top;

            int column = _left, row = _top; // index of pixel
            int endColumn = column + _width, endRow = row + _height;
            int nextX = 0, nextY = 0;
            int remainX = 0, remainY = 0;
            Rectangle censorZone;
            while (row < endRow)
            {
                nextY = row + _size;
                remainY = nextY < endRow ? _size : endRow - row;
                while (column < endColumn)
                {
                    nextX = column + _size;
                    remainX = nextX < endColumn ? _size : endColumn - column;
                    censorZone = new Rectangle(column, row, remainX, remainY);
                    ApplyForSingleZone(pxs, censorZone);
                    column += remainX;
                }
                // crlf
                column = _left;
                row += remainY;
            }
        }

        private void ApplyForSingleZone(Pixmap pxs, Rectangle zone)
        {
            // compute end index
            int endColumn = zone.X + zone.Width;
            int endRow = zone.Y + zone.Height;
            // compute mid color
            int totalPixel = zone.Width * zone.Height;
            int r = 0, g = 0, b = 0;
            Pixel px = new Pixel();
            for (int row = zone.Y; row < endRow; row++)
            {
                for (int col = zone.X; col < endColumn; col++)
                {
                    px = pxs[row, col];
                    r += px.R;
                    g += px.G;
                    b += px.B;
                }
            }

            // get mid color
            px.A = 255;
            px.R = (byte)(r / totalPixel);
            px.G = (byte)(g / totalPixel);
            px.B = (byte)(b / totalPixel);

            // replace image with mid pixel
            for (int row = zone.Y; row < endRow; row++)
            {
                for (int col = zone.X; col < endColumn; col++)
                {
                    pxs[row, col] = px;
                }
            }
        }        
    }
}