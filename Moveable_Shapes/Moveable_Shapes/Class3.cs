using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moveable_Shapes
{
    internal class Rectangle : Shape,IMoveable
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
            string baseString = base.ToString(); // Call the base class's ToString method if 
            string additionalInfo = $"Width: {width}, Length: {Length}";
            string areaAndPerimeter = $"Area: {getArea()}, Perimeter: {getPerimeter()}";



            return $"{baseString}\n{additionalInfo}\n{areaAndPerimeter}";
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
        //Draw
        public void DrawMe(int x, int y, int width , int length, Graphics area, Pen p)
        {
            area.DrawRectangle(p, x, y, width, length);
        }

        internal void DrawOrFillShape(Brush customBrush, Pen customPen, Graphics g)
        {
            if (this.IsFilled)
            {
                g.FillRectangle(customBrush, XLocation, YLocation, (int)Width, (int)Length);
            }
            else
            {
                this.DrawMe(XLocation, YLocation, (int)Width , (int)Length, g, customPen);
            }
        }
    }
}
