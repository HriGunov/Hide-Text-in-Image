using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using HideTextInImage.Interfaces;

namespace HideTextInImage.Blenders.CharToPixel
{
  public  class PixelToChar : IBlendable
    {
        
        private int defaultUnitsSavedForSizeString = 32; // used so we can know when to stop  reading file

        public PixelToChar(IBlendPixelMethod blendMethod)
        {
            BlendMethod = blendMethod;
            UnitsSavedForSizeString = defaultUnitsSavedForSizeString;
        }

        public IBlendPixelMethod BlendMethod { get; set; }
        public int UnitsSavedForSizeString { get; set; }

        #region Blend
        /// <summary>
        /// Takes an image and hides the stream(text) in the image
        /// Make sure Image width by heigth are big enough for the text
        /// also encrypts text
        /// </summary>
        /// <param name="originalImagePath">path to an image</param>
        /// <param name="textPath">A text</param>
        /// <returns>Bitmap of the mixed imaged and stream</returns>
        public Bitmap BlendWhole(string originalImagePath, string textPath)
        {
            string text;
            using (StreamReader sr = new StreamReader(textPath))
            {
                text = sr.ReadToEnd();
            }
            Bitmap originalImage = new Bitmap(originalImagePath);
            

            // we use the stream to turn it in to a image
            Bitmap image = new Bitmap(originalImage.Width, originalImage.Height);
           
            int counter = 0; // originalTextEnd
         
            Random random = new Random(); //not so random
            List<char> charactersUsed = new List<char>();

            //first line
            for (int x = UnitsSavedForSizeString, y=0; x < image.Width; x++) //!!!!
            {
                if (counter < text.Length)
                {

                    int charectarAsInt =text[counter];
                    if (!charactersUsed.Contains((char) charectarAsInt))
                        charactersUsed.Add((char) charectarAsInt);

                    image.SetPixel(x, y, BlendMethod.BlendPixel(originalImage.GetPixel(x, y), charectarAsInt));
                    counter++;

                }
            }
            //second -> last line
            for (int y = 1; y < image.Height; y++)
            {
                for (int x = 0;  x < image.Width; x++) 
                {
                    if (counter < text.Length)
                    {

                        int charectarAsInt = text[counter];
                        if (!charactersUsed.Contains((char)charectarAsInt))
                            charactersUsed.Add((char)charectarAsInt);
                        
                        image.SetPixel(x, y, BlendMethod.BlendPixel(originalImage.GetPixel(x, y), charectarAsInt));
                        counter++;

                    }
                    else
                    {
                        int charectarAsInt = charactersUsed[random.Next(0, charactersUsed.Count)];  //get a randon that has already been used in the string

                        image.SetPixel(x, y, BlendMethod.BlendPixel(originalImage.GetPixel(x, y), charectarAsInt));
                    }
                }
            }


            //"secretly" puts lenght of message at the start of the image
            byte[] lengthOfMSGinBytes  = BitConverter.GetBytes(counter);
            for (int x = 0; x < 4; x++)
            {
                image.SetPixel(x, 0, BlendMethod.BlendPixel(originalImage.GetPixel(x, 0), lengthOfMSGinBytes[x]));
                
            }
            

            return image;            
        }

   
        #endregion

        #region UnBlend
        /// <summary>
        /// Unblends the 2 images and returns the text
        /// </summary>
        /// <param name="originalImagePath"></param>
        /// <param name="blendedImagePath"></param>
        /// <returns> text</returns>
        public string UnblendWhole(string originalImagePath, string blendedImagePath)
        {
            Bitmap originalImage = new Bitmap(originalImagePath);
            Bitmap blendedImage = new Bitmap(blendedImagePath);
            
            string text = "";

            int stopAtElementIndex = 0;
            int currentElementIndex = 0;
            BlendMethod.UnblendPixel(blendedImage.GetPixel(0, 0), originalImage.GetPixel(0, 0));
            var byteArray = new Byte[]{
                (byte) BlendMethod.UnblendPixel(blendedImage.GetPixel(0, 0), originalImage.GetPixel(0, 0)),
                (byte) BlendMethod.UnblendPixel(blendedImage.GetPixel(1, 0), originalImage.GetPixel(1, 0)),
                (byte) BlendMethod.UnblendPixel(blendedImage.GetPixel(2, 0), originalImage.GetPixel(2, 0)),
                (byte) BlendMethod.UnblendPixel(blendedImage.GetPixel(3, 0), originalImage.GetPixel(3, 0))};

                string colorAsBinary = String.Format("{0}{1}{2}{3}",
                    Convert.ToString(byteArray[3], 2).PadLeft(8, '0'),
                    Convert.ToString(byteArray[2], 2).PadLeft(8, '0'),
                    Convert.ToString(byteArray[1], 2).PadLeft(8, '0'),
                    Convert.ToString(byteArray[0], 2).PadLeft(8, '0'));

                stopAtElementIndex = Convert.ToInt32(colorAsBinary, 2);

            
            for (int x = UnitsSavedForSizeString; x < originalImage.Width; x++)
                {
                    //message end has not been reached
                    if (currentElementIndex < stopAtElementIndex)
                    {
                    char charFromColor = (char)BlendMethod.UnblendPixel(blendedImage.GetPixel(x, 0), originalImage.GetPixel(x, 0));
                    text += charFromColor;
                        currentElementIndex++;
                    }
                    else
                    {
                        return text;
                    }
                }
            


            
            for (int y = 1; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    //message end has not been reached
                    if (currentElementIndex < stopAtElementIndex)
                    {
                        var charFromColor = (char)BlendMethod.UnblendPixel(blendedImage.GetPixel(x, y), originalImage.GetPixel(x, y));
                        text += charFromColor;
                        currentElementIndex++;
                    }
                    else
                    {
                        return text;
                    }
                }
            }
            
            
            return text;
        }
#endregion
    }
}
