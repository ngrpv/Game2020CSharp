using MediaPlayer;
namespace WindowsFormsApp1.Domain
{
    public class GameOptions
    {
        public int Volume
        {
            get => s.Volume;
            set => s.Volume = value;
        }

        
        public MediaPlayer.MediaPlayer s = new ()
        {
            FileName = @"C:\Users\Garipov\Desktop\C#Game\Assets\VEHCar.wav",
        };
        //private SoundPlayer _soundPlayer = new SoundPlayer(@"C:\Users\Garipov\Desktop\C#Game\Assets\VEHCar.wav");

        public GameOptions()
        {
            //Volume = 1;
            //_soundPlayer.Play();
            //s.Play();
            
            //Thread.Sleep(5000);
            //  s.Volume /= 2;
        }
        
        public void Open()
        {
            
        }
    }
}