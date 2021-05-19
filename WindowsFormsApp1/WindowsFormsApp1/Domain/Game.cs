using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Domain
{
    public class Game
    {
        private GameStage stage = GameStage.NotStarted;
        public Car Car;
        public GameOptions Options = new GameOptions();
        
        public event Action<GameStage> StageChanged;
        public event Action<GameStage> Update;

        /*public void SetVolume(int volume)
        {
            options.Volume = volume;
        }*/
        
        public void ChangeStage(GameStage gameStage)
        {
            this.stage = gameStage;
            StageChanged?.Invoke(stage);
        }

        public void Start(Car car)
        {
            Car = car;
            ChangeStage(GameStage.Playing);
        }

        public void	 Start()
        {
            Start(new Car(new Point(960,800), CarModel.RaceCar));        
        }

        public void MoveCar(char keyChar)
        {
            switch (keyChar)
            {
                case 'w':
                    Car.Move(0, -1*Car.Speed);
                    break;
                case 'a':
                    Car.Move(-1*Car.Speed, 0);
                    break;
                case 's':
                    Car.Move(0, 1*Car.Speed);
                    break;
                case 'd':
                    Car.Move(1*Car.Speed, 0);
                    break;
            }
        }
    }

    public static class RandomCarGenerator
    {
        private static Random _random = new Random();
        private static Point[] locations = new[]
            {new Point(200, -40), new Point(400, -40), new Point(600, -40), new Point(800, -40)};
        public static Car GetRandomCar()
        {
            var model = _random.Next(4);
            var location = _random.Next(0, locations.Length);
            var car = new Car(locations[location], (CarModel) model);
            return car;
        }
    }
    
}