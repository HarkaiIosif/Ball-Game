using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball_Game
{
    internal class MyMath
    {
        public static int EuclidianDistance(Ball b1, Ball b2)
        {
            int toRet = (int)Math.Sqrt(Math.Pow(b2.x - b1.x, 2) + Math.Pow(b2.y - b1.y, 2));
            return toRet;
        }
        public static Color MixColors(Ball b1, Ball b2)
        {
            Color toRet;
            int retR=(b1.color.R*b1.radius+b2.color.R*b2.radius)/(b1.radius+b2.radius);
            int retG = (b1.color.G * b1.radius + b2.color.G * b2.radius) / (b1.radius + b2.radius);
            int retB = (b1.color.B * b1.radius + b2.color.B * b2.radius) / (b1.radius + b2.radius);
            toRet=Color.FromArgb(retR, retG, retB);
            return toRet;
        }
    }
}
