using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moveable_Shapes
{
    internal class Square : Rectangle
    {
        public Square() { }
        public Square(double side) { this.Width = side; this.Length = side; }
        public Square(double side, string color, bool filled)
        {
            this.Width = side;
            this.Length = side;
            this.Color = color;
            this.IsFilled = filled;
        }

        public double Side {  get; set; }
        //   override property
        // setWidth(side)
        public override double Width { set { this.Width = value; this.Length = value; } }
        // setLength(side)
        public override double Length { set { this.Width = value; this.Length = value; } }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
