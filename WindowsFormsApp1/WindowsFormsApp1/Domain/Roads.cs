using System.Drawing;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1.Domain
{
    public class Roads
    {
        public ObjectWithPicture UpperRoad { get; private set; }
        public ObjectWithPicture MiddleRoad { get; private set; }
        public ObjectWithPicture LowerRoad { get; private set; }
        public ObjectWithPicture[] RoadsArray;
        private static int PictureHeight = 1000;
        private static int clientHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height;

        #region Contrustors

        public Roads(Point location1, Point location2, Point location3)
        {
            (UpperRoad, MiddleRoad, LowerRoad) =
            (
                new(new RoadPattern(location1)),
                new(new RoadPattern(location2)),
                new(new RoadPattern(location3))
            );
            RoadsArray = new[] {UpperRoad, MiddleRoad, LowerRoad};
        }

        public Roads(int middleRoadY) : this(
            new(0, middleRoadY - PictureHeight), 
            new(0, 0),
            new(0, middleRoadY + PictureHeight))
        { }

        public Roads() : this(0)
        {
        }

        #endregion
        
        public void ShiftDown(int dy)
        {   
            MiddleRoad.SetLocation(new Point(0, MiddleRoad.GetLocation().Y+dy));
            RefreshLocations();
        }

        private void RefreshLocations()
        {
            if (LowerRoad.GetLocation().Y > clientHeight+100)
            {
                LowerRoad.SetLocation(new Point(0,MiddleRoad.GetLocation().Y-PictureHeight));
                (UpperRoad, MiddleRoad, LowerRoad) = (LowerRoad, UpperRoad, MiddleRoad);
            }
            UpperRoad.SetLocation(new Point(0,MiddleRoad.GetLocation().Y-PictureHeight));
            LowerRoad.SetLocation(new Point(0,MiddleRoad.GetLocation().Y+PictureHeight));
        }
    }
}