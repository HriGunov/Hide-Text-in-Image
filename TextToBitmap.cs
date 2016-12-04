using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace HideTextInImage
{
    public class TextToBitmap
    {
        public static Bitmap Create(string originalImagePath, string textPath)
        {
            Bitmap image = new Bitmap(originalImagePath);

            // old Dictionary<char, int> charUses = new Dictionary<char, int>();
            StreamReader text = new StreamReader(textPath);

            byte[] buffer;
            int originalTextEnd = 0;
            Color colorARGB;
            Random random = new Random(); //not so random
            List<char> charactersUsed = new List<char>();

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (!text.EndOfStream)
                    {
                        int charectarAsInt = text.Read();

                        //adds used char in dictionary

                        if (!charactersUsed.Contains((char)charectarAsInt))
                            charactersUsed.Add((char)charectarAsInt);



                        char debugStr = (char)charectarAsInt;
                        buffer = BitConverter.GetBytes(charectarAsInt);

                        colorARGB = Color.FromArgb(/*buffer[3]*/255, 0, buffer[1], buffer[0]);
                        image.SetPixel(x, y, colorARGB);

                        originalTextEnd++;


                    }
                    else
                    {
                        int charectarAsInt = charactersUsed[random.Next(0, charactersUsed.Count)];
                        buffer = BitConverter.GetBytes(charectarAsInt);

                        colorARGB = Color.FromArgb(/*buffer[3]*/255, 0, buffer[1], buffer[0]);
                        image.SetPixel(x, y, colorARGB);
                    }
                }
            }

            //secretly puts lenght of message in last pixel of image
            buffer = BitConverter.GetBytes(originalTextEnd);
            colorARGB = Color.FromArgb(/*buffer[3]*/255, buffer[2], buffer[1], buffer[0]);
            image.SetPixel(image.Width - 1, image.Height - 1, colorARGB);

           // image.Save(Environment.SpecialFolder.Desktop + @"\test\secret.png", ImageFormat.Png);
            return image;
            
        }


    }
}
