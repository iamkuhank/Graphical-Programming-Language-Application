using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessClassLibrary
{
   public class ClassShapeFactory
   {
      /// <summary>
      /// passing values on shape type
      /// </summary>
      /// <param name = "shapeType"></param>
      /// <return></return>
      public ClassShape GetShape(String shapeType)
      {
         if (shapeType == "circle")
         {
            return new ClassCircle();
         }
         else if (shapeType == "rectangle")
         {
            return new ClassRectangle();
         }
         else if (shapeType == "line")
         {
            return new ClassLine();
         }
         else if (shapeType == "triangle")
         {
            return new ClassTriangle();
         }
         else if (shapeType == "pentagon")
         {
            return new ClassPentagon();
         }
         return null;
      }
   }
}
