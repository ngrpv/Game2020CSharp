using System;

namespace WindowsFormsApp1.Domain
{
    public class Game
    {
        private GameStage stage = GameStage.NotStarted;
        private Player _player;
        private GameOptions options = new GameOptions();

        public event Action<GameStage> StageChanged;

        public void SetVolume(int volume)
        {
            options.Volume = volume;
        }
        
        public void ChangeStage(GameStage stage)
        {
            this.stage = stage;
            StageChanged?.Invoke(stage);
        }
    }

    public class RoadPattern
    {
        
    }
}