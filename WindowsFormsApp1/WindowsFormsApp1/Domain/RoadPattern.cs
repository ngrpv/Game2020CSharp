using System.Drawing;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.Domain
{
    public class RoadPattern : VisualizeableObject
    {
        public RoadPattern(Point location) : base(location, Resources.road)
        {
        }
    }
}