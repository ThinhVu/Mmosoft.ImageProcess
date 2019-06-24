using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mmosoft.ImageProcessing.Effects
{
    public class Additive : IImageEffect
    {
        private Channel _channel;
        private int _value;

        public Additive(Channel channel, int value)
        {
            _channel = channel;
            _value = value;
        }

        public void Apply(Pixel[,] pxs)
        {
            for (int i = 0, iMax = pxs.GetLength(0); i < iMax; i++)
            {
                for (int j = 0, jMax = pxs.GetLength(1); j < jMax; j++)
                {
                    switch (_channel)
                    {
                        case Channel.R:
                            pxs[i, j].R = GetByte(pxs[i, j].R + _value);
                            break;
                        case Channel.G:
                            pxs[i, j].G = GetByte(pxs[i, j].G + _value);
                            break;
                        case Channel.B:
                            pxs[i, j].B = GetByte(pxs[i, j].B + _value);
                            break;
                        case Channel.RGB:
                            pxs[i, j].R = GetByte(pxs[i, j].R + _value);
                            pxs[i, j].G = GetByte(pxs[i, j].G + _value);
                            pxs[i, j].B = GetByte(pxs[i, j].B + _value);
                            break;
                    }
                }
            }
        }

        private byte GetByte(int value)
        {
            if (value < 0)
                return 0;
            if (value > 255)
                return 255;
            return (byte)value;
        }
    }   
}