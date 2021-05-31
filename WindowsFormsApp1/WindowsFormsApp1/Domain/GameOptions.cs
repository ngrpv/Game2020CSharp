using System;
using System.Windows.Media;

namespace WindowsFormsApp1.Domain
{
    public class GameOptions
    {
        public double Volume {
            get => MediaPlayer.Volume;
            set => MediaPlayer.Volume = value;
        }
        
        public readonly System.Windows.Media.MediaPlayer MediaPlayer = new();
        
        public GameOptions()
        {
            MediaPlayer.Open(new Uri(@"C:\Users\Garipov\Desktop\C#Game\Game\WindowsFormsApp1\WindowsFormsApp1\Resources\Tron-Legacy.wav"));
            //Volume = 1;
            //  s.Volume /= 2;
        }

        public void StopPLayer()
        {
            MediaPlayer.Stop();
        }

        public void Play()
        {
         //   MediaPlayer.Stop();
            MediaPlayer.Volume = 50;
            MediaPlayer.Play();
        }
        
        public void Open()
        {
            
        }
    }
}