using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessClassLibrary
{
   public abstract class ClassShape
   {
      /// <summary>
      /// passing graphics value
      /// </summary>
      /// <param name = "g"></param>
      public abstract void draw(Graphics g);

      /// <summary>
      /// passing value from button click of main form to the shapes
      /// </summary>
      /// <param name="texturestyle"></param>
      /// <param name="bb"></param>
      /// <param name="c"></param>
      /// <param name="list"></param>
      public abstract void set(int texturestyle, Brush bb, Color c, params int[] list);
   }
}
