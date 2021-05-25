using System.Drawing;

namespace WindowsFormsApp1.Domain
{
    public class HitBox
    {
        private int difference;
        private Rectangle box;

        public HitBox(Car car)
        {
            box = new(car.Location.X + difference, car.Location.Y + difference, car.Image.Width - difference,
                car.Image.Height - difference);
        }
        public HitBox(Car car, int difference)
        {
            this.difference = difference;
            box = new(car.Location.X + difference, car.Location.Y + difference, car.Image.Width - difference,
                car.Image.Height - difference);
        }

        public bool IsCollide(HitBox otherHitbox)
        {
            return box.IntersectsWith(otherHitbox.box);
        }

        public void Refresh(Point location)
        {
            box.Location = location;
        }
    }
}