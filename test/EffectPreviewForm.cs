﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcess;

namespace test
{
    public partial class EffectPreviewForm : Form
    {
        ImageProcess.ImageProcess ip = new ImageProcess.ImageProcess();

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
            
            // setup effect
            ip.Add(new ImageProcess.Effects.GrayScaleFilter());
            ip.Add(new ImageProcess.Effects.ThreeD());
            ip.Add(new ImageProcess.Effects.Additive(Channel.RGB, -20));
            ip.Add(new ImageProcess.Effects.Additive(Channel.R, 80));
            ip.Add(new ImageProcess.Effects.Additive(Channel.G, 40));
            ip.Add(new ImageProcess.Effects.NoiseEffect(20));
            ip.Process(after);
                        
            beforeAfter1.After = after;
        }
    }
}