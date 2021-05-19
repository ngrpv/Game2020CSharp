using System.Drawing;

namespace WindowsFormsApp1.Domain
{
    public abstract class VisualizeableObject
    {
        private Point _location;

        public VisualizeableObject(Point location)
        {
            _location = location;
        }
        public Point Location
        {
            get => _location;
            set => _location = value;
        }

        public void Move(int dx = 0, int dy = 0)
        {
            _location.X += dx;
            _location.Y += dy;
        }
    }
}