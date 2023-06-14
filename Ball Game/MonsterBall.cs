using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Ball_Game
{
    internal class MonsterBall:Ball
    {
        public MonsterBall(int x,int y,int radius):base(x,y,0,0,radius,Color.Black,0) 
        {
            this.type = "Monster";
        }
    }
}
