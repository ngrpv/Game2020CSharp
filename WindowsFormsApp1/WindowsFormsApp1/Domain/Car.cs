using System.Drawing;

namespace WindowsFormsApp1.Domain
{
    public class Car : VisualizeableObject
    {
        public int Speed { get; } = 10;
        public readonly CarModel CarModel;

        public Car(Point location, CarModel model) : base(location)
            => CarModel = model;

       
    }

    public enum CarModel
    {
        Truck,
        RaceCar,
        Police,
        Taxi,
    }
}