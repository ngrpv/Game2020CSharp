using System;
using System.Drawing;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public static class RandomCarGenerator
    {
        private static Random _random = new();
        private static Point[] locations = {new(200, -40), new(400, -40), new(600, -40), new(800, -40)};

        private static Bitmap[] carModels = new[]
        {
            Resources.taxi, Resources.truck, Resources.Ambulance, Resources.Audi, Resources.Black_viper,
            Resources.Mini_truck, Resources.Police
        };
        //private static Array carModels = Enum.GetValues(typeof(CarModel));

        public static Car GetRandomCar()
            => new(locations[_random.Next(0, locations.Length)], (Bitmap)carModels.GetValue(_random.Next(carModels.Length)));
    }
}