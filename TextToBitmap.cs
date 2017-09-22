using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace HideTextInImage
{
    public class TextToBitmap
    {

    //Creats a Bitmap version of a txt file where every character is represented by a pixel
    //and the rest are a combination of  the used characters
    //The bitmap representation  of the text has the proportions of the original image
    public static Bitmap Create(Bitmap imageRef, string textPath,string originalImageHash = null) 
    {
        Bitmap image = new Bitmap(imageRef.Width, imageRef.Height);
        string text;

        using (StreamReader sr = new StreamReader(textPath))
        {
            text = sr.ReadToEnd();
        }
            if (originalImageHash != null)
            {
                text = Sha256.Encrypt(text, originalImageHash);
            }


        byte[] buffer;
        int counter = 0; // originalTextEnd
        Color colorARGB;
        Random random = new Random(); //not so random
        List<char> charactersUsed = new List<char>();

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0, len = image.Width; x < image.Width; x++)
            {
                if (counter < text.Length)
                {

                    int charectarAsInt = (int)text[counter];
                    if (!charactersUsed.Contains((char)charectarAsInt))
                        charactersUsed.Add((char)charectarAsInt);

                    char debugStr = (char)charectarAsInt;
                    buffer = BitConverter.GetBytes(charectarAsInt);

                    colorARGB = Color.FromArgb(/*buffer[3]*/255, 0, buffer[1], buffer[0]);
                    image.SetPixel(x, y, colorARGB);
                    counter++;

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
        buffer = BitConverter.GetBytes(counter);
        colorARGB = Color.FromArgb(buffer[2], buffer[1], buffer[0]);
        image.SetPixel(image.Width - 1, image.Height - 1, colorARGB);


        // image.Save(Environment.SpecialFolder.Desktop + @"\test\secret.png", ImageFormat.Png);
        return image;

    }
        //This should not be in this file
        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }


    }
}
