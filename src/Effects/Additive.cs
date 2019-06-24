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

        public void Apply(Pixmap pxs)
        {
            Pixel px;

            for (int col = 0, iMax = pxs.Width; col < iMax; col++)
            {
                for (int row = 0, jMax = pxs.Height; row < jMax; row++)
                {
                    px = pxs[row, col];

                    switch (_channel)
                    {
                        case Channel.A:
                            px.A = GetByte(px.A + _value);
                            break;
                        case Channel.R:
                            px.R = GetByte(px.R + _value);
                            break;
                        case Channel.G:
                            px.G = GetByte(px.G + _value);
                            break;
                        case Channel.B:
                            px.B = GetByte(px.B + _value);
                            break;
                        case Channel.RGB:
                            px.R = GetByte(px.R + _value);
                            px.G = GetByte(px.G + _value);
                            px.B = GetByte(px.B + _value);
                            break;
                    }
                    pxs[row, col] = px;
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