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
            string baseString = base.ToString(); // Call the base class's ToString method if needed
            string circleInfo = $"Radius: {Radius}";
            string areaAndPerimeter = $"Area: {getArea()}, Perimeter: {getPerimeter()}";

            return $"{baseString}\n{circleInfo}\n{areaAndPerimeter}";
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

        // Draw
        public void DrawMe(int x, int y, int rd, Graphics area, Pen p)
        {

            area.DrawEllipse(p, x, y, rd, rd);
        }

        internal void DrawOrFillShape(Brush customBrush, Pen customPen, Graphics g)
        {
            if (this.IsFilled)
            {
                g.FillEllipse(customBrush, XLocation, YLocation, (int)Radius, (int)Radius);
            }
            else
            {
                this.DrawMe(XLocation, YLocation, (int)Radius, g, customPen);
            }
        }
    }
}
