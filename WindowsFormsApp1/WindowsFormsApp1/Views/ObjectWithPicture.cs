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
    }
}