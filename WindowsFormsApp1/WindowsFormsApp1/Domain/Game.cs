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
        public readonly GameOptions Options = new ();
        public Car[] Bots;
        public const int MinBotsGeneratingTime = 300;
        public int BotsGeneratingFrequence = 1000;
        public bool IsOver { get; set; }
        
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
            Car.IsBot = false;
            Bots = new Car[15];
            ChangeStage(GameStage.Playing);
        }

        public void	 Start()
        {
            Start(new Car(new Point(960,800), Resources.Audi, 10));        
            Options.MediaPlayer.Play();
        }

        public void Stop()
        {
            StopMusic();
            BotsGeneratingFrequence = 1200;
            ChangeStage(GameStage.Stopped);
        }
        public void StopMusic()
        {
            Options.StopPLayer();
        }
    }
}