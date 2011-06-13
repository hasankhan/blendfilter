using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Imaging.Filters;
using System.Drawing;

namespace WpfApplication1
{
    class PencilSketch
    {
        public static Bitmap Sketch(Bitmap image)
        {
            var layerA = new SaturationCorrection(-71).Apply(image);

            var layerB = new Invert().Apply(layerA);
            layerB = new GaussianBlur().Apply(layerB);

            layerA = new BlendFilter(BlendMode.ColorDodge, layerB).Apply(layerA);
            layerA = new GammaCorrection(-5).Apply(layerA);

            //layerA = new BlendFilter(BlendMode.Overlay, layerA).Apply(image);
            return layerA;
        }
    }
}
