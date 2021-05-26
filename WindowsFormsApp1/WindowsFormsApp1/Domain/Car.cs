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
        public readonly int MinSpeed = 0;
        public readonly int MaxSpeed = 50;
        public bool IsBot = true;
        private int maxY = 1030;
        private int minY = 0;
        private int maxX = 1600;
        private int minX = 230;

        public int Velocity { get; private set; } = 3;
        public HitBox HitBox { get; private set; }

        public Car(Point location, Bitmap image, int speed) : base(location, image)
        {
            Speed = speed;
            HitBox = new HitBox(this, 15);
            var timer = new Timer();
            timer.Interval = 10;
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

        public Car(Point location) : base(location, Resources.Audi)
        {
        }

        public new void Move(int dx, int dy)
        {
            if (Speed < MaxSpeed && dy < 0)
            {
                Speed += Velocity;
            }
            else if (Speed < MaxSpeed && dy > 0)
            {
                dy += 5;
                Speed = 10;
            }

            if (!IsBot)
            {
                if (Location.X > maxX && dx > 0 || Location.X < minX && dx < 0) dx = 0;
                if (Location.Y > maxY && dy > 0 || Location.Y < minY && dy < 0) dy = 0;
            }

            base.Move((int) (dx * 90 / 10), (int) (dy * Speed * 50 / 1000.0));
            HitBox.Refresh(Location);
        }

        public void ShiftDown(int dy)
        {
            Move(0, dy);
            HitBox.Refresh(Location);
        }
    }
}