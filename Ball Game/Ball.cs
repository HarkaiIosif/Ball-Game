namespace Ball_Game
{
    public class Ball
    {
        public int dx, dy;
        public int x, y;
        public int radius;
        public Color color;
        private int speed;
        public string type;
        public Ball(int x, int y, int dx, int dy, int radius,Color c,int speed)
        {
            this.dx = dx;
            this.dy = dy;
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.color = c;
            this.speed = speed;
            this.type = "Regular";
        }
        public virtual void Draw(Graphics g)
        {   Pen p=new Pen(color);
            int coord1=this.x-this.radius;
            int coord2=this.y-this.radius;
            int width = 2 * radius;
            g.DrawEllipse(p, coord1, coord2, width, width);
            g.FillEllipse(new SolidBrush(color), coord1, coord2,width,width);
        }
        public void Move()
        {
            int d1=0;
            int d2=0;
            for(int i=0;i<speed;i++)
            {
                if (dx>0)while (d1 < dx)
                {
                    this.x++;
                    d1++;
                }
                else while (d1 < Math.Abs(dx))
                    {
                        this.x--;
                        d1++;
                    }
                if(dy>0)while (d2 < dy)
                {
                    this.y++;
                    d2++;
                }
                else while(d2 < Math.Abs(dy))
                    {
                        this.y--;
                        d2++;
                }
            }
        }
        
    }
}