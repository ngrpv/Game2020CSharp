using System;
using System.Drawing;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public static class RandomCarGenerator
    {
        private static Random _random = new();
        private static int botsStartY = -200;
        private static Point[] locations =
        {
            new(300, botsStartY), 
            new(450, botsStartY), 
            new(600, botsStartY), 
            new(750, botsStartY),
            new(1000, botsStartY), 
            new(1130, botsStartY), 
            new(1350, botsStartY),
            new(1500, botsStartY)
        };

        private static Bitmap[] carModels = 
        {
            Resources.taxi, Resources.truck, Resources.Ambulance, Resources.Black_viper,
            Resources.Mini_truck, Resources.Police
        };

        public static Car GetRandomCar()
        {
            var img = (Bitmap) ((Bitmap) carModels.GetValue(_random.Next(carModels.Length))).Clone();
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return new Car(locations[_random.Next(0, locations.Length)], img);
        }
    }
}