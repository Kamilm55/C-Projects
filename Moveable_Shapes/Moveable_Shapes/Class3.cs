using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moveable_Shapes
{
    internal class Rectangle : Shape
    {
        private double width = 1.0;
        private double length = 1.0;
        public Rectangle() { }
        public Rectangle(double width, double length)
        {
            this.width = width;
            this.length = length;
        }
        public Rectangle(double width, double length,string color,bool filled)
        {
            this.width = width;
            this.length = length;
            this.Color = color;
            this.IsFilled = filled;
        }
        public virtual double Width { get { return width; } set { this.width = value; } } 
        public virtual double Length { get { return length; } set { this.length = value; } }
        public override string ToString()
        {
            return base.ToString() +"Width: " + width + "\n" + "Length: " + length + "\n"  + "Area: " + getArea() + "\n" +"Perimeter: " + getPerimeter();
        }

        // Methods : area and perimeter
        public double getArea()
        {
            return width * length;
        }
        public double getPerimeter()
        {
            return 2 * (width + length) ;
        }
    }
}
