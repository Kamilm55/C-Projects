using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moveable_Shapes
{
    internal class Square : Rectangle/*,IMoveable*/
    {
        public Square() { }
        public Square(double side)
        {
            this.Width = side;
            this.Length = side;
        }
        public Square(double side, string color, bool filled)
        {
            this.Width = side;
            this.Length = side;
            this.Color = color;
            this.IsFilled = filled;
        }

        public override string ToString()
        {
            string baseString = base.ToString();
           /* string additionalInfo = $"Side: {Width}";
            string areaAndPerimeter = $"Area: {getArea()}, Perimeter: {getPerimeter()}";*/

            return $"{baseString}";
        }
    }
}
