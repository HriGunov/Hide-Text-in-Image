using System.Drawing;
using HideTextInImage.Interfaces;
namespace HideTextInImage
{
    class Blender 
    {
        public static Bitmap Blend(Bitmap originalImage, Bitmap secondImage)
        {
            Bitmap image = new Bitmap(originalImage.Width, originalImage.Height);
            //goes though the whole image
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    image.SetPixel(x, y, BlendPixel(originalImage.GetPixel(x, y), secondImage.GetPixel(x, y)));
                }
            }

            return image;

        }
        private static Color BlendPixel(Color originalImageColor, Color secondColor)
        {
            short mixedGreen = (short)((originalImageColor.G + secondColor.G) / 2);
            short mixedBlue = (short)((originalImageColor.B + secondColor.B) / 2);

            //if its ood then the have a loss of information
            bool sumOfGreenIsOdd = false;
            bool sumOfBlueIsOdd = false;

            if (mixedGreen * 2 != (short)(originalImageColor.G + secondColor.G))
            {
                sumOfGreenIsOdd = true;
            }
            if (mixedBlue * 2 != (short)(originalImageColor.B + secondColor.B))
            {
                sumOfBlueIsOdd = true;
            }
            
            //We change the red value to 6 bits and use the other 2 to store bool values ( if green/blue are odd)
            int red = originalImageColor.R >> 2;
            red = red << 2;

            if (sumOfBlueIsOdd)
            {
                red = (byte)(red | 1);
            }
            if (sumOfGreenIsOdd)
             {
                red = (byte)(red | 2);
            }

            Color blendedColor = new Color();


            blendedColor = Color.FromArgb(/*Alpha*/255, red, mixedGreen, mixedBlue);

            return blendedColor;
        }
       

        public static Bitmap UnBlend(Bitmap firstImage, Bitmap keyImage)
        {
            Bitmap unblendedImage = new Bitmap(firstImage.Width, firstImage.Height);
            Color newPixel;
            for ( int y=0 ; y < firstImage.Height; y++)
            {
                for (int x = 0; x < firstImage.Width; x++)
                {
                      newPixel = UnBlendPixel(firstImage.GetPixel(x, y), keyImage.GetPixel(x, y));
                    unblendedImage.SetPixel(x, y, newPixel);
                }
            }

            return unblendedImage;
        }
        //reverses the blendPixel function
        private static Color UnBlendPixel(Color firstColor, Color keyColor)
        {
            bool sumOfGreenIsOdd = false;
            bool sumOfBlueIsOdd = false;

            //checks the values of the first 2 bits of red
            byte testRed = firstColor.R;
            testRed = (byte)(testRed << 7);
            testRed = (byte)(testRed >> 7);

            if (testRed == 1)
            {
                sumOfBlueIsOdd = true;
            }

            testRed = firstColor.R;
            testRed = (byte)(testRed >> 1);
            testRed = (byte)(testRed << 7);
            testRed = (byte)(testRed >> 7);
            if (testRed == 1)
            {
                sumOfGreenIsOdd = true;
            }
            

            short originalGreen = (byte)(sumOfGreenIsOdd ?
                    ((firstColor.G * 2) + 1 -keyColor.G ): ((firstColor.G * 2) - keyColor.G) );

            short originalBlue = (byte)(sumOfBlueIsOdd?
                    ((firstColor.B * 2)+1 - keyColor.B): ((firstColor.B * 2) - keyColor.B));

            

            Color unblendedColor = new Color();

            unblendedColor = Color.FromArgb(255,0, originalGreen, originalBlue);

            return unblendedColor;
        }

    }
}
