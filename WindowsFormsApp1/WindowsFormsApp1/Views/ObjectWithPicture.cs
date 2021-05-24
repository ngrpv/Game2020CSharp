using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Views
{
    public class ObjectWithPicture
    {
        public PictureBox Picture { get;  }
        public VisualizeableObject Obj { get; }
        public ObjectWithPicture(VisualizeableObject obj, PictureBox picture)
        {
            Obj = obj;
            Picture = picture;
        }
        
        public ObjectWithPicture(VisualizeableObject obj) : this(obj, Visualizator.Initialize(obj))
        {
        }

        public void Move(int dx, int dy) 
        {
            Obj.Move(dx, dy);
            UpdatePictureLocation();
        }

        public void SetLocation(Point location)
        {
            Obj.Location = location;
            UpdatePictureLocation();
        }
        public  void UpdatePictureLocation()
        {
            Picture.Location = Obj.Location;
        }
        public Point GetLocation()
            => Obj.Location;
        
        public void ShiftDownByTimer(int ms, int dy)
        {
            Task.Factory.StartNew(() =>
            {
                while (Obj.Location.Y < 1100)
                {
                    Thread.Sleep(ms);
                    Move(0, dy);
                }
            });
        }
    }
}