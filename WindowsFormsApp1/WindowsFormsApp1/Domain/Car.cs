namespace WindowsFormsApp1.Domain
{
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
}