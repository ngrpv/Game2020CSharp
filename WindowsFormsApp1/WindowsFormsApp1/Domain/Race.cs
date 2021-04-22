namespace WindowsFormsApp1.Domain
{
    public class Race
    {
        public int Score { get; set; }

        public int Time { get; set; }
        
        public Player Player { get; }

        public Car Car { get; }

        public Race (Player player, Car car)
        {
            Player = player;
            Car = car;
        }


    }
}
