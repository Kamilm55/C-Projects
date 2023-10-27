using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moveable_Shapes
{
    internal abstract class Shape
    {
        private int xLocation = 0;
        private int yLocation = 0;
        private string color = "red";
        private bool filled = true;

        protected Shape()
        {
        }

        protected Shape(string color, bool filled)
        {
            this.color = color;
            this.filled = filled;
        }

        protected Shape(int xLocation, int yLocation, string color, bool filled)
        {
            this.xLocation = xLocation;
            this.yLocation = yLocation;
            this.color = color;
            this.filled = filled;
        }

        //Properties
        public int XLocation {  get { return xLocation; } set { this.xLocation = value; } }
        public int YLocation { get { return yLocation; } set { this.yLocation = value; } }
       
        public string Color {  get { return this.color; } set { this.color = value; } }
        public bool IsFilled { get { return this.filled; } set { this.filled = value; } }

        public override string ToString()
        {
            return "\nX: "+ xLocation + "\nY: " + yLocation + "\nColor: " + color + "\n" + "IsFilled: " + filled;
        }

         // Delete
        public void DeleteShape (Brush customBrush, Graphics area, Pen p)
        {
            area.DrawEllipse(p, -1,-1,0,0);
        }

    }
}
