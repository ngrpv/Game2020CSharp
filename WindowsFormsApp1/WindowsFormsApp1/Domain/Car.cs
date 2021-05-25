using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public class Car : VisualizeableObject
    {
        public int Speed { get; private set; } = 20;
        public readonly int MinSpeed = 10;

        public readonly int MaxSpeed = 50;

        public int Velocity { get; private set; } = 4;
        //public readonly CarModel CarModel;

        public Car(Point location, Bitmap image, int speed): base(location, image)
        {
            Speed = speed;
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender, args) =>
            {
                if(Speed > MinSpeed) 
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
            }else if (Speed < MaxSpeed && dy > 0)
            {
                dy += 2;
            }
            base.Move((int) (dx*Speed * 20 / 100.0), (int) (dy*Speed * 50 / 1000.0));
        }
    }
    
}