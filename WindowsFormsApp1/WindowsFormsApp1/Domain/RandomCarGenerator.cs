using System;
using System.Drawing;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public static class RandomCarGenerator
    {
        private static Random _random = new();
        private static int botsStartY = -180;
        private static Point[] locations = {new(200, botsStartY), new(400, botsStartY), new(600, botsStartY), new(750, botsStartY), new(900,botsStartY), new (1100, botsStartY), new(1300, botsStartY)};

        private static Bitmap[] carModels = new[]
        {
            Resources.taxi, Resources.truck, Resources.Ambulance, Resources.Audi, Resources.Black_viper,
            Resources.Mini_truck, Resources.Police
        };
        //private static Array carModels = Enum.GetValues(typeof(CarModel));

        public static Car GetRandomCar()
        {
            var img = (Bitmap) carModels.GetValue(_random.Next(carModels.Length));
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return new(locations[_random.Next(0, locations.Length)], img);
        }
    }
}