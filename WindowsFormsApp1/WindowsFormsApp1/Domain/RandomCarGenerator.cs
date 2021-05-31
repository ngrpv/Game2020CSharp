using System;
using System.Drawing;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public static class RandomCarGenerator
    {
        private static readonly Random Random = new();
        private const int BotsStartY = -200;

        private static readonly Point[] Locations =
        {
            new(300, BotsStartY), 
            new(450, BotsStartY), 
            new(650, BotsStartY), 
            new(800, BotsStartY),
            new(1000, BotsStartY), 
            new(1130, BotsStartY), 
            new(1350, BotsStartY),
            new(1500, BotsStartY)
        };

        private static readonly Bitmap[] CarModels = 
        {
            Resources.taxi, Resources.truck, Resources.Ambulance, Resources.Black_viper,
            Resources.Mini_truck, Resources.Police
        };

        public static Car GetRandomCar()
        {
            var img = (Bitmap) ((Bitmap) CarModels.GetValue(Random.Next(CarModels.Length))).Clone();
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return new Car(Locations[Random.Next(0, Locations.Length)], img, 20);
        }
    }
}