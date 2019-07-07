using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mmosoft.ImageProcessing.Effects
{
    public class Blur : IImageEffect
    {
        public int[,] _blurMask = new int[,]
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 } 
        };

        private int total = 9;

        public void Apply(Pixmap pxs)
        {
            Pixel[,] pxMask = new Pixel[3, 3];
            Pixel px;

            Pixmap pxsClone = pxs.DeepCopy();
            
            for (int row = 1, maxRow = pxs.Height - 1; row < maxRow; row++) // padding 1px
            {
                for (int col = 1, maxCol = pxs.Width - 1; col < maxCol; col++) // padding 1px
                {

                    pxMask[0, 0] = pxs[row - 1, col - 1];
                    pxMask[1, 0] = pxs[row - 1, col];
                    pxMask[2, 0] = pxs[row - 1, col + 1];
                    //      
                    pxMask[0, 1] = pxs[row, col - 1];
                    pxMask[1, 1] = pxs[row, col];
                    pxMask[2, 1] = pxs[row, col + 1];
                    //      
                    pxMask[0, 2] = pxs[row + 1, col - 1];
                    pxMask[1, 2] = pxs[row + 1, col];
                    pxMask[2, 2] = pxs[row + 1, col + 1];

                    int pxA = 0;
                    int pxR = 0;
                    int pxG = 0;
                    int pxB = 0;

                    for (int i = 0, len0 = _blurMask.GetLength(0); i < len0; i++)
                    {
                        for (int j = 0, len1 = _blurMask.GetLength(1); j < len1; j++)
                        {
                            pxA += pxMask[i, j].A * _blurMask[i, j];
                            pxR += pxMask[i, j].R * _blurMask[i, j];
                            pxG += pxMask[i, j].G * _blurMask[i, j];
                            pxB += pxMask[i, j].B * _blurMask[i, j];
                        }
                    }

                    px.A = (byte)(pxA / total);
                    px.R = (byte)(pxR / total);
                    px.G = (byte)(pxG / total);
                    px.B = (byte)(pxB / total);

                    pxsClone[row, col] = px;
                }
            }

            for (int row = 1, maxRow = pxs.Height - 1; row < maxRow; row++) // padding 1px
            {
                for (int col = 1, maxCol = pxs.Width - 1; col < maxCol; col++) // padding 1px
                {
                    pxs[row, col] = pxsClone[row, col];
                }
            }
        }
    }
}
