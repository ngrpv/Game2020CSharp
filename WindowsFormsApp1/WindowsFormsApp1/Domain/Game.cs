using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public class Game
    {
        public GameStage Stage { get; private set; } = GameStage.NotStarted;
        public Car Car;
        public Roads roads;
        public GameOptions Options = new GameOptions();
        public Car[] Bots;
        
        public event Action<GameStage> StageChanged;
      // public event Action<GameStage> Update;

        public void SetVolume(int volume)
        {
            Options.Volume = volume;
        }
        
        public void ChangeStage(GameStage gameStage)
        {
            this.Stage = gameStage;
            StageChanged?.Invoke(Stage);
        }

        public void Start(Car car)
        {
            roads = new Roads();
            Car = car;
            Bots = new Car[10];
            ChangeStage(GameStage.Playing);
        }

        public void	 Start()
        {
            Start(new Car(new Point(960,800), Resources.Audi, 10));        
            Options.MediaPlayer.Play();
        }

        public void Stop()
        {
            Car = null;
            ChangeStage(GameStage.Stopped);
        }

        public void MoveCar(char keyChar)
        {
            switch (keyChar)
            {
                case (char)Keys.Up:
                case 'w':
                    Car.Move(0, -1);
                    break;
                case (char)Keys.Left:
                case 'a':
                    Car.Move(-1, 0);
                    break;
                case (char)Keys.Down:
                case 's':
                    Car.Move(0, 1);
                    break;
                case (char)Keys.Right:
                case 'd':
                    Car.Move(1, 0);
                    break;
            }
        }
    }

    /*public static class Physics
    {
        public void 
    }*/
}