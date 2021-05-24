using System.Drawing;

namespace WindowsFormsApp1.Domain
{
    public class Car : VisualizeableObject
    {
        public int Speed { get; } = 40;
        //public readonly CarModel CarModel;

        public Car(Point location, Bitmap image) : base(location, image)
        {
            
        }
    }

    public enum CarModel
    {
        Truck,
        RaceCar,
        Police,
        Taxi,
    }
}