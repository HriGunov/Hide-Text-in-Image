using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideTextInImage.Interfaces
{
   public interface IBlendable 
    {
        IBlendPixelMethod BlendMethod { get; set; }
        int UnitsSavedForSizeString { get; set; }

        Bitmap BlendWhole(string originalImagePath, string textPath);
         
        string UnblendWhole(string originalImagePath, string blendedImagePath);
        
    }
}
