using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public class Car : VisualizeableObject
    {
        public uint Speed { get; private set; } = 20;
        public readonly int MaxSpeed = 50;

        public uint Velocity { get; private set; } = 4;
        //public readonly CarModel CarModel;

        public Car(Point location, Bitmap image, uint speed): base(location, image)
        {
            Speed = speed;
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender, args) =>
            {
                if(Speed > 0) 
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
            if(Speed<MaxSpeed && dy<0)
                Speed += Velocity;
            base.Move((int) (dx*Speed * 20 / 10.0), (int) (dy*Speed * 20 / 1000.0));
        }
    }
    
}