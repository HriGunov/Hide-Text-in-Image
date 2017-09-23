using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideTextInImage.Interfaces
{
   public interface IBlendPixelMethod 
    {
        Color BlendPixel(Color pixelToBeBlended, int valueToBeBlended);
        int UnblendPixel(Color pixelToBeUnblended, Color originalImagePixel);
    }
}
