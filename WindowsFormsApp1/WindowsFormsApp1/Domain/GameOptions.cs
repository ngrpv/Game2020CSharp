//using MediaPlayer;

using System;
using System.Windows.Media;
namespace WindowsFormsApp1.Domain
{
    public class GameOptions
    {
        public double Volume
        {
            get => s.Volume;
            set => s.Volume = value;
        }


        public System.Windows.Media.MediaPlayer s = new();

        //private SoundPlayer _soundPlayer = new SoundPlayer(@"C:\Users\Garipov\Desktop\C#Game\Assets\VEHCar.wav");

        public GameOptions()
        {
            s.Open(new Uri(@"C:\Users\Garipov\Desktop\C#Game\Assets\VEHCar.wav"));
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