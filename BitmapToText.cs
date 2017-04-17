using System;
using System.Drawing;
using System.Security.Cryptography;

namespace HideTextInImage
{
  public   class BitmapToText
    {
        public static string Extract(Bitmap image, string originalImageHash = null, int stopAtCharNumber = -1)
        {

            Color curPixlColor = image.GetPixel(0, 0);
            int counter = 0;
            char charFromColor;
            string text = "";

            //checks if stopAtChar argument was given if not the loop will end at the last pixel of the image
            if (stopAtCharNumber < 0)
            {

                curPixlColor = image.GetPixel(image.Width - 1, image.Height - 1);
                stopAtCharNumber = PixelColorToNumber(curPixlColor.A, curPixlColor.R, curPixlColor.G, curPixlColor.B);
            }

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0, len = image.Width; x < image.Width; x++)
                {
                    if (counter < stopAtCharNumber)
                    {
                        curPixlColor = image.GetPixel(x, y);
                        charFromColor = (char)PixelColorToNumber(curPixlColor.A, curPixlColor.R, curPixlColor.G, curPixlColor.B);
                        text += charFromColor;
                        counter++;
                    }
                    else
                    {
                        return text;
                    }
                }
            }

            if (originalImageHash != null)
            {
                text = Sha256.Encrypt(text, originalImageHash);
            }

            return text;
        }

        //Only the blue and green values are used 
        static int PixelColorToNumber(int alpha, int red, int green, int blue)
        {                        
            string colorAsBinary = String.Format("{0}{1}",
                                                /* Convert.ToString(alpha, 2).PadLeft(8, '0'),
                                                 Convert.ToString(red, 2).PadLeft(8, '0'),*/
                                                Convert.ToString(green, 2).PadLeft(8, '0'),
                                                Convert.ToString(blue, 2).PadLeft(8, '0'));
            int decimalValue = Convert.ToInt32(colorAsBinary, 2);

            return decimalValue;
        }
    }
}
