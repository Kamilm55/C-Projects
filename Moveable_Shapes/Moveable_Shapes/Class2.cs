using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moveable_Shapes
{
    internal class Circle:Shape
    {
        private double radius = 1.0;

        public Circle() { }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public Circle(double radius,string color,bool filled)
        {
            this.Radius = radius;
            this.Color = color;
            this.IsFilled = filled;
        }
        public double Radius {  get { return this.radius; } set {  this.radius = value; } }

        public override string ToString()
        {
            return base.ToString() + "Area: " + getArea() + "Perimeter: " + getPerimeter();
        }

        // Methods : area and perimeter
        public double getArea()
        {
          return  3.14 * radius * radius;
        }
        public double getPerimeter()
        {
            return 3.14  * 2 * radius;
        }
    }
}
