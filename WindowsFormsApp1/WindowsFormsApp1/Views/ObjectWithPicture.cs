using System.Drawing;
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
            this.Obj = obj;
            this.Picture = picture;
        }
        
        public ObjectWithPicture(VisualizeableObject obj)
        {
            this.Obj = obj;
            this.Picture = Visualizator.Initialize(obj);
        }

        public void Move(int dx, int dy)
        {
            Obj.Move(dx, dy);
            this.UpdateLocation();
        }

        public void SetLocation(Point location)
        {
            Obj.Location = location;
            this.UpdateLocation();
        }

        public Point GetLocation()
            => Obj.Location;
    }
}