using System;
using System.Drawing;

namespace WindowsFormsApp1.Domain
{
    public class Car : IVizualizeable
    {
        public Point _location;
        public double Speed { get; } = 15; 
        public readonly CarModel CarModel; 

        public Point Location
        {
            get => _location;
            set => _location = value;
        }

        public Car(Point location, CarModel model)
        {
            _location = location;
           // Speed = speed;
            CarModel = model;
        }

        /*public void MoveTo(int x, int y)
        {
            Location= 
        }*/
        
        public void Move(int dx, int dy)
        {
            Location = new Point(Location.X + (int)(Speed*dx), Location.Y + (int)(Speed * dy));
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