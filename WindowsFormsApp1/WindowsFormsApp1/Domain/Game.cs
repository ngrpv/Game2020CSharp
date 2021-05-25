using System;
using System.Drawing;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public class Game
    {
        public GameStage Stage { get; private set; } = GameStage.NotStarted;
        public Car Car;
        public Roads Roads;
        public GameOptions Options = new ();
        public Car[] Bots;
        
        public event Action<GameStage> StageChanged;

      public void ChangeStage(GameStage gameStage)
        {
            Stage = gameStage;
            StageChanged?.Invoke(Stage);
        }

        public void Start(Car car)
        {
            Roads = new Roads();
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
    }
}