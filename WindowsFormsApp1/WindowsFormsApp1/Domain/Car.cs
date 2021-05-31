using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp1.Properties;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp1.Domain
{
    public class Car : VisualizeableObject
    {
        public int Speed { get; private set; } = 20;
        public readonly int MinSpeed = 10;
        public readonly int MaxSpeed = 70;
        public bool IsBot = true;
        private const int MaxY = 1030;
        private const int MinY = 700;
        private const int MaxX = 1600;
        private const int MinX = 230;

        public int Acceleration { get; } = 3;
        public HitBox HitBox { get; }

        public Car(Point location, Bitmap image, int speed) : base(location, image)
        {
            Speed = speed;
            HitBox = new HitBox(this);
            var timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (_, _) =>
            {
                if (Speed > MinSpeed)
                    Speed -= 1;
            };
            timer.Start();
        }

        public Car(Point location, Bitmap image) : this(location, image, 20)
        {
        }

        public Car(Point location) : this(location, Resources.Audi)
        {
        }

        public new void Move(int dx, int dy)
        {
            if (Speed < MaxSpeed && dy < 0)
            {
                Speed += Acceleration;
            }
            else if (Speed < MaxSpeed && dy > 0)
            {
                dy += 5;
                Speed = 10;
            }

            if (!IsBot)
            {
                if (Location.X > MaxX && dx > 0 || Location.X < MinX && dx < 0) dx = 0;
                if (Location.Y > MaxY && dy > 0 || Location.Y < MinY && dy < 0) dy = 0;
            }

            var dx1 = dx * 9;
            var dy1 = (int)(dy * Speed * 5 / 100.0);
            base.Move(dx1, dy1);
            HitBox.Refresh(dx1,dy1);
        }

        public void ShiftDown(int dy)
        {
            Move(0, dy); 
            //HitBox.Refresh(Location);
        }
    }
}