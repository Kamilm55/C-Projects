using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moveable_Shapes
{
    interface IMoveable
    {
        void MoveUp();
        void MoveDown();
        void MoveRight();
        void MoveLeft();
    }
}
