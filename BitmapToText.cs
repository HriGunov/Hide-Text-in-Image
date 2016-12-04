using System;
using System.Drawing;
using System.IO;

namespace BitmapToText
{
  public   class BitmapToText
    {
     public   static string Extract(Bitmap image, string extracteTextLoc, int stopAtCharNumber = -1)
        {
           
            Color curPixlColor = image.GetPixel(0, 0);
            //checks if stopAtChar argument was given if not the loop will end at the last pixel of the image
            if (stopAtCharNumber < 0)
            {

                curPixlColor = image.GetPixel(image.Width - 1, image.Height - 1);
                stopAtCharNumber = PixelColorToNumber(curPixlColor.A, curPixlColor.R, curPixlColor.G, curPixlColor.B);
            }

            //todo
            string text = "";

            int counter = 0;
            int xAxis = 0;
            int yAxis = 0;

            char charFromColor;
            do
            {
                
                if (counter + 1 >= image.Width)
                {
                    xAxis = (counter + 1) % image.Width;
                    yAxis = counter / image.Width;

                    curPixlColor = image.GetPixel((counter + 1) % image.Width, yAxis);

                }
                else
                {

                    curPixlColor = image.GetPixel(counter, yAxis);

                }
               
                charFromColor = (char)PixelColorToNumber(curPixlColor.A, curPixlColor.R, curPixlColor.G, curPixlColor.B);
                
                string curCharasStr = charFromColor.ToString();

                //To be changed to return a whole string
                using (StreamWriter sw = new StreamWriter(extracteTextLoc, true))
                {
                    // Add some text to the file.
                    sw.Write(curCharasStr);
                }

                //   extractedText.WriteLine(curCharasStr);
                counter++;

                
            } while (counter < stopAtCharNumber);



            Console.WriteLine("Easy");
            //extractedText.Write(text);
            return "s";

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
