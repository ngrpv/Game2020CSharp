namespace WindowsFormsApp1.Domain
{
    public enum GameStage
    {
        NotStarted,
        Selection,
        Finished
    }
    
    public class Game
    {
        private GameStage stage = GameStage.NotStarted;
        private Player _player;
    }

    class Car
    {
        public double Speed { get;}
        public double Power { get; }
        public Car( double speed, double power)
        {
            Speed = speed;
            Power = power;
        }
    }

    class Terrain
    {
        
    }

    class Player
    {
        public string Name { get; set; }
    }

    class Wheel
    {
        
    }
}