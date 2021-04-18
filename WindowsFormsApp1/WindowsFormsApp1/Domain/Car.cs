using System;
using System.Drawing;

namespace WindowsFormsApp1.Domain
{
    public class Car
    {
        private Point _location;
        public double Speed { get;}

        public Point Location => _location;

        public Car(Point location, double speed)
        {
            _location = location;
            Speed = speed;
        }

        public void MoveTo(int x, int y)
        {
            _location.X = x;
            _location.Y = y;
        }
        
        public void Move(int x, int y)
        {
            _location.X += x;
            _location.Y += y;
        }
    }
}