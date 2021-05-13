using System.Media;

namespace WindowsFormsApp1.Domain
{
    public class GameOptions
    {
        public int Volume
        {
            get => s.Volume;
            set
            {
                s.Volume = value;
            }
        }

        private MediaPlayer.MediaPlayer s = new MediaPlayer.MediaPlayer()
        {
            FileName = @"C:\Users\Garipov\Desktop\C#Game\Assets\VEHCar.wav",
        };
        //private SoundPlayer _soundPlayer = new SoundPlayer(@"C:\Users\Garipov\Desktop\C#Game\Assets\VEHCar.wav");

        public GameOptions()
        {
            //_soundPlayer.Play();
            s.Play();
        }
        
        public void Open()
        {
            
        }
    }
}