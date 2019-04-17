using System;
using System.Drawing;

namespace ImageProcess.Effects
{
    public class MosaicFilterHandler : IImageEffect
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
        public MosaicFilterHandler(Rectangle effectiveZone, int size)
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

        public void Apply(Pixel[,] pxs)
        {
            int width = pxs.GetLength(0);
            int height = pxs.GetLength(1);
            // left/top corner
            if (_left > width) _left = width;
            if (_top > height) _top = height;
            // area
            if (_left + _width > width) _width = width - _left;
            if (_top + _height > height) _height = height - _height;

            int x = _left, y = _top; // index of pixel
            int endX = x + _width, endY = y + _height;
            int nextX = 0, nextY = 0;
            int remainX = 0, remainY = 0;
            Rectangle censorZone;
            while (y < endY)
            {
                nextY = y + _size;
                remainY = nextY < endY ? _size : endY - y;
                while (x < endX)
                {
                    nextX = x + _size;
                    remainX = nextX < endX ? _size : endX - x;
                    censorZone = new Rectangle(x, y, remainX, remainY);
                    ApplyForSingleZone(pxs, censorZone);
                    x += remainX;
                }
                // crlf
                x = _left;
                y += remainY;
            }
        }

        private void ApplyForSingleZone(Pixel[,] pxs, Rectangle zone)
        {
            // compute end index
            int endX = zone.X + zone.Width;
            int endY = zone.Y + zone.Height;
            // compute mid color
            int totalPixel = zone.Width * zone.Height;
            int r = 0, g = 0, b = 0;
            Pixel px;
            for (int x = zone.X; x < endX; x++)
            {
                for (int y = zone.Y; y < endY; y++)
                {
                    px = pxs[x, y];
                    r += px.R;
                    g += px.G;
                    b += px.B;
                }
            }

            // get mid color
            px.R = (byte)(r / totalPixel);
            px.G = (byte)(g / totalPixel);
            px.B = (byte)(b / totalPixel);
            
            // replace image with censore
            for (int x = zone.X; x < endX; x++)
            {
                for (int y = zone.Y; y < endY; ++y)
                {
                    pxs[x, y] = px;
                }
            }
        }        
    }
}