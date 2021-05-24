
using System;
using System.Windows.Media;
namespace WindowsFormsApp1.Domain
{
    public class GameOptions
    {
        public double Volume
        {
            get => MediaPlayer.Volume;
            set => MediaPlayer.Volume = value;
        }
        
        public System.Windows.Media.MediaPlayer MediaPlayer = new();
        
        public GameOptions()
        {
            MediaPlayer.Open(new Uri(@"C:\Users\Garipov\Desktop\C#Game\Assets\Tron-Legacy.wav"));
            //Volume = 1;
            //  s.Volume /= 2;
        }
        
        public void Open()
        {
            
        }
    }
}