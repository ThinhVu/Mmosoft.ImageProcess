using System;
using System.Collections.Generic;

namespace Mmosoft.ImageProcessing.Effects
{
    // white noise
    public class NoiseEffect : IImageEffect
    {
        private int _noisePercentage;
        private List<bool> _noise;
        private int _noiseCtr;
        
        public NoiseEffect(int noisePercentage)
        {
            if (0 <= noisePercentage && noisePercentage <= 100)
                _noisePercentage = noisePercentage;
            else
                throw new Exception("Invalid noise percentage");            
        }

        public void Apply(Pixmap pxs)
        {
            InitNoise(pxs.Width * pxs.Height);
            Pixel px;
            for (int row = 0, jMax = pxs.Height; row < jMax; row++)
            {
                for (int column = 0, iMax = pxs.Width; column < iMax; column++)
                {
                    if (ShoudMakeNoise())
                    {
                        px = pxs[row, column];
                        px.R = (byte)Math.Max(px.R + 30, 255);
                        px.G = (byte)Math.Max(px.G + 30, 255);
                        px.B = (byte)Math.Max(px.B + 30, 255);
                        pxs[row, column] = px;
                    }
                }
            }
        }

        private void InitNoise(int pixel)
        {
            int noisePixel = _noisePercentage * pixel / 100;
            int unnoisePixel = pixel - noisePixel;
            _noise = new List<bool>(pixel);
            for (int i = 0; i < noisePixel; i++)
                _noise.Add(true);
            for (int i = 0; i < unnoisePixel; i++)
                _noise.Add(false);
            Shuffle();
        }

        private void Shuffle()
        {
            // shuffle
            var r = new Random();
            for (int i = 0; i < _noise.Count; i++)
            {
                var j = r.Next(i, _noise.Count);
                var v = _noise[i];
                _noise[i] = _noise[j];
                _noise[j] = v;
            }
        }

        private bool ShoudMakeNoise()
        {
            if (_noiseCtr == _noise.Count)
            {
                Shuffle();
                _noiseCtr = 0;
            }            
            return _noise[_noiseCtr++];
        }
    }
}