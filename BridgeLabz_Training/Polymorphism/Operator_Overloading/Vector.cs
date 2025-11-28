using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Polymorphism.Operator_Overloading
{
    public class Vector
    {
        public int X;
        public int Y;

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Operator Overloading
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
    }
}