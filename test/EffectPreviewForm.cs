using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mmosoft.ImageProcessing;

namespace test
{
    public partial class EffectPreviewForm : Form
    {
        ImageProcess ip = new ImageProcess();

        public EffectPreviewForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            // before
            beforeAfter1.Before = (Bitmap)Image.FromFile("sample.jpg");
            
            // after
            var after = (Bitmap)Image.FromFile("sample.jpg");

            // ip.Add(new Mmosoft.ImageProcessing.Effects.Additive(Channel.RGB, 20)); // lighten
            // ip.Add(new Mmosoft.ImageProcessing.Effects.Additive(Channel.RGB, -20)); // darken
            // ip.Add(new Mmosoft.ImageProcessing.Effects.Additive(Channel.R, 80)); // more red
            // ip.Add(new Mmosoft.ImageProcessing.Effects.Additive(Channel.G, 40)); // more green
            // ip.Add(new Mmosoft.ImageProcessing.Effects.Additive(Channel.B, 40)); // more blue
            // ip.Add(new Mmosoft.ImageProcessing.Effects.Additive(Channel.A, -20)); // more transparent of course we can not see it in this preview
            // ip.Add(new Mmosoft.ImageProcessing.Effects.BlackWhiteFilter(140)); // filter with threshold 140
            // ip.Add(new Mmosoft.ImageProcessing.Effects.GrayScaleFilter()); // make gray image
            // ip.Add(new Mmosoft.ImageProcessing.Effects.InvertColorEffect()); // invert the color
            // ip.Add(new Mmosoft.ImageProcessing.Effects.MosaicEffect(new Rectangle(0, 0, after.Width, after.Height), 7)); // apply censored 7 pixel for entire image
            // ip.Add(new Mmosoft.ImageProcessing.Effects.NoiseEffect(20)); // make a white noise with 20 percentage of an image
            // ip.Add(new Mmosoft.ImageProcessing.Effects.ThreeD()); // make 3D effect
            ip.Process(after);
                        
            beforeAfter1.After = after;
        }
    }
}
