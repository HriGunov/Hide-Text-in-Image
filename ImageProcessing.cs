using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideTextInImage
{
  public static  class ImageProcessing
    {
       //Takes an image and returns a "black and white" version of it
   public   static  Bitmap ToMonoChromatic(Bitmap  imageRef)
        {
            double redRatio = 0.30;
            double greenRatio = 0.59;
            double blueRatio = 0.11;

            Bitmap image = (Bitmap)imageRef.Clone();
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int grayShade = (int)(pixel.R * redRatio + pixel.G * greenRatio + pixel.B * blueRatio);
                    image.SetPixel(x, y, Color.FromArgb(grayShade, grayShade, grayShade));
                }
            }

            return image;
        } 
       
    }
}
