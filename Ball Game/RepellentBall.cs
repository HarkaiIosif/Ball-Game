using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball_Game
{
    internal class RepellentBall:Ball
    {
        public RepellentBall(int x,int y,int dx,int dy,int radius,Color c,int speed) : base(x, y, dx, dy, radius, c, speed) 
        {
            this.type = "Repellent";
        }
        public override void Draw(Graphics g)
        {
            Pen p = new Pen(color);
            int coord1 = this.x - this.radius;
            int coord2 = this.y - this.radius;
            int width = 2 * radius;
            g.FillEllipse(new SolidBrush(color), coord1, coord2, width, width);
            p.Color = Color.Black;
            g.DrawEllipse(p, coord1, coord2, width, width);
        }
    }
}
