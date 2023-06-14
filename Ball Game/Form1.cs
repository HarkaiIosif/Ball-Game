using System.Security.Cryptography.X509Certificates;

namespace Ball_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        Graphics g;
        List<Ball> Balls;
        readonly Random rnd = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            Balls = new List<Ball>();
            GenerateBalls();
            DrawBalls();
            for (int i = 0; i < 50; i++)
            {
                Turn();
                Task.Delay(10);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void GenerateBalls()
        {
            int ballnr = rnd.Next(10, 20);
            for (int i = 0; i < ballnr; i++)
            {
                int type = rnd.Next(1, 4);
                switch (type)
                {
                    case 1:
                        {
                            int radius = rnd.Next(10, 20);
                            int dx = GenerateDirection();
                            int dy = GenerateDirection();
                            int x = GenerateWidth(radius);
                            int y = GenerateHeight(radius);
                            Color color = GenerateColor();
                            int speed = GenerateSpeed();
                            Ball ball = new Ball(x, y, dx, dy, radius, color, speed);
                            Balls.Add(ball);
                            break;
                        }
                    case 2:
                        {
                            int radius = rnd.Next(10, 20);
                            int dx = GenerateDirection();
                            int dy = GenerateDirection();
                            int x = GenerateWidth(radius);
                            int y = GenerateHeight(radius);
                            Color color = GenerateColor();
                            int speed = GenerateSpeed();
                            RepellentBall ball = new RepellentBall(x, y, dx, dy, radius, color, speed);
                            Balls.Add(ball);
                            break;
                        }
                }


            }
            int mbradius = rnd.Next(10, 20);
            int mbx = GenerateWidth(mbradius);
            int mby = GenerateHeight(mbradius);
            MonsterBall mbball = new MonsterBall(mbx, mby, mbradius);
            Balls.Add(mbball);
            mbradius = rnd.Next(10, 20);
            mbx = GenerateWidth(mbradius);
            mby = GenerateHeight(mbradius);
            mbball = new MonsterBall(mbx, mby, mbradius);
            Balls.Add(mbball);
        }
        private void DrawBalls()
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                Balls[i].Draw(g);
            }
            pictureBox1.Image = bmp;
        }
        private int GenerateSpeed()
        {
            int toRet = rnd.Next(1, 4);
            return toRet;
        }
        private int GenerateDirection()
        {
            int toRet = rnd.Next(-3, 3);
            return toRet;
        }
        private int GenerateWidth(int radius)
        {
            int toRet = 0;
            toRet = rnd.Next(radius, pictureBox1.Width - radius);
            return toRet;
        }
        private int GenerateHeight(int radius)
        {
            int toRet = 0;
            toRet = rnd.Next(radius, pictureBox1.Height - radius);
            return toRet;
        }
        private Color GenerateColor()
        {
            int R = rnd.Next(60, 255);
            int G = rnd.Next(60, 255);
            int B = rnd.Next(60, 255);
            Color color = Color.FromArgb(R, G, B);
            return color;
        }
        public void Turn()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            for (int i = 0; i < Balls.Count; i++)
            {
                Balls[i].Move();
                CheckBorderCollision(Balls[i]);
                for (int j = 0; j < Balls.Count; j++)
                {
                    CheckCollision(Balls[i], Balls[j]);
                }
            }
            DrawBalls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Turn();
            }
        }
        public void CheckBorderCollision(Ball b)
        {
            if (b.x - b.radius <= 0) b.dx = -b.dx;
            if (b.y - b.radius <= 0) b.dy = -b.dy;
            if (b.x + b.radius >= pictureBox1.Width) b.dx = -b.dx;
            if (b.y + b.radius >= pictureBox1.Height) b.dy = -b.dy;
        }
        public void CheckCollision(Ball b1, Ball b2)
        {
            if (b1.radius + b2.radius >= MyMath.EuclidianDistance(b1, b2))
            {

                if (b1.type == "Regular" && b2.type == "Regular" && b1.radius > b2.radius)
                {
                    b1.radius += b2.radius;
                    b1.color = MyMath.MixColors(b1, b2);
                    Balls.Remove(b2);
                }
                if (b1.type == "Regular" && b2.type == "Regular" && b1.radius < b2.radius)
                {
                    b2.radius += b1.radius;
                    b2.color = MyMath.MixColors(b1, b2);
                    Balls.Remove(b1);
                }
                if (b1.type == "Regular" && b2.type == "Repellent")
                {
                    b1.dx = -b1.dx;
                    b1.dy = -b1.dy;
                    b2.dy = -b2.dy;
                    b2.dx = -b2.dx;
                }
                if (b1.type == "Regular" && b2.type == "Monster")
                {
                    b2.radius += b1.radius;
                    Balls.Remove(b1);
                }
                if (b2.type == "Regular" && b1.type == "Monster")
                {
                    b1.radius += b2.radius;
                    Balls.Remove(b2);
                }
                if (b1.type == "Repellent" && b2.type == "Repellent")
                {
                    b1.dx = -b1.dx;
                    b1.dy = -b1.dy;
                    b2.dx = -b2.dx;
                    b2.dy = -b2.dy;
                }
                if (b1.type == "Repellent" && b2.type == "Monster")
                {
                    b1.dx = -b1.dx;
                    b1.dy = -b1.dy;
                    b1.radius /= 2;
                    if (b1.radius == 0) Balls.Remove(b1);
                }
                if (b2.type == "Repellent" && b1.type == "Monster")
                {
                    b2.dx = -b2.dx;
                    b2.dy = -b2.dy;
                    b2.radius /= 2;
                    if (b2.radius == 0) Balls.Remove(b2);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Turn();
        }
    }
}