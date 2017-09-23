using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HideTextInImage.Interfaces;

namespace HideTextInImage.Blenders.CharToPixel
{
    class CharToPixelBlend : IBlendPixelMethod
    {
        public Color BlendPixel(Color pixelToBeBlended, int valueToBeBlended)
        {

        //splits int into 4 bytes  
        byte[]  buffer = BitConverter.GetBytes(valueToBeBlended);
        //uses the last 2 bytes to make a color 
        Color  newColor = Color.FromArgb(/*buffer[3]*/255, 0, buffer[1], buffer[0]);

          
            
        //sums and divides by 2 so the values can still fit in a byte
        short mixedGreen = (short)((pixelToBeBlended.G + newColor.G) / 2);
        short mixedBlue = (short)((pixelToBeBlended.B + newColor.B) / 2);

        //if its ood then the have a loss of information
        bool sumOfGreenIsOdd = false;
        bool sumOfBlueIsOdd = false;

        if (mixedGreen * 2 != (short)(pixelToBeBlended.G + newColor.G))
        {
            sumOfGreenIsOdd = true;
        }
        if (mixedBlue * 2 != (short)(pixelToBeBlended.B + newColor.B))
        {
            sumOfBlueIsOdd = true;
        }

        //We change the red value to 6 bits and use the other 2 to store bool values ( if green/blue are odd)
        int red = pixelToBeBlended.R >> 2;
        red = red << 2;

        if (sumOfBlueIsOdd)
        {
            red = (byte)(red | 1);
        }
        if (sumOfGreenIsOdd)
        {
            red = (byte)(red | 2);
        }

        Color blendedColor = Color.FromArgb(/*Alpha*/255, red, mixedGreen, mixedBlue);

        return blendedColor;



        }

        public int UnblendPixel(Color pixelToBeUnblended, Color originalImagePixel)
        {
             
            bool sumOfGreenIsOdd = false;
            bool sumOfBlueIsOdd = false;

            //checks the values of the first 2 bits of red
            byte testRed = pixelToBeUnblended.R;
            testRed = (byte)(testRed << 7);
            testRed = (byte)(testRed >> 7);

            if (testRed == 1)
            {
                sumOfBlueIsOdd = true;
            }

            testRed = pixelToBeUnblended.R;
            testRed = (byte)(testRed >> 1);
            testRed = (byte)(testRed << 7);
            testRed = (byte)(testRed >> 7);
            if (testRed == 1)
            {
                sumOfGreenIsOdd = true;
            }


            short originalGreen = (byte)(sumOfGreenIsOdd ?
                ((pixelToBeUnblended.G * 2) + 1 - originalImagePixel.G) : ((pixelToBeUnblended.G * 2) - originalImagePixel.G));

            short originalBlue = (byte)(sumOfBlueIsOdd ?
                ((pixelToBeUnblended.B * 2) + 1 - originalImagePixel.B) : ((pixelToBeUnblended.B * 2) - originalImagePixel.B));



            Color unblendedColor = Color.FromArgb(255, 0, originalGreen, originalBlue);

            

            string colorAsBinary = String.Format("{0}{1}",
                /* Convert.ToString(alpha, 2).PadLeft(8, '0'),
                 Convert.ToString(red, 2).PadLeft(8, '0'),*/
                Convert.ToString(originalGreen, 2).PadLeft(8, '0'),
                Convert.ToString(originalBlue, 2).PadLeft(8, '0'));

            int decimalValue = Convert.ToInt32(colorAsBinary, 2);

            return decimalValue;

        }
    }
}
