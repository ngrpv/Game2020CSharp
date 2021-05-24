using System.Drawing;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public class Car : VisualizeableObject
    {
        public int Speed { get; } = 10;
        //public readonly CarModel CarModel;

        public Car(Point location, Bitmap image) : base(location, image)
        {
            
        }

        public Car(Point location) : base(location, Resources.Audi)
        {
            
        }

        public Car(Point location, Bitmap image, int speed): base(location, image)
        {
            Speed = speed;
        }

        public void Move(int dx, int dy)
        => base.Move((int)(dx*20/100.0), (int)(dy*20/100.0));
        
    }
    
}