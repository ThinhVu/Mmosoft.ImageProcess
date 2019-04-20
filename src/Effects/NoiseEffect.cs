using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcess.Effects
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

        public void Apply(Pixel[,] pxs)
        {
            InitNoise(pxs.GetLength(0) * pxs.GetLength(1));
            for (int i = 0, iMax = pxs.GetLength(0); i < iMax; i++)
            {
                for (int j = 0, jMax = pxs.GetLength(1); j < jMax; j++)
                {
                    if (ShoudMakeNoise())
                    {
                        pxs[i, j].R = GetByte(pxs[i, j].R + 30);
                        pxs[i, j].G = GetByte(pxs[i, j].G + 30);
                        pxs[i, j].B = GetByte(pxs[i, j].B + 30);
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