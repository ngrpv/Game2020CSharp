using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1.Domain
{
    public interface IVizualizeable
    {
        public Point Location { get; set; }
    }
    
    public static  class Vizualizator
    {
        private static Dictionary<CarModel, Bitmap> carPictures = new Dictionary<CarModel, Bitmap>()
        {
            [CarModel.Police] = Resources.Police,
            [CarModel.Taxi] = Resources.taxi,
            [CarModel.RaceCar] = Resources.Audi,
            [CarModel.Truck] = Resources.truck,
        };
        
        public static PictureBox Initialize(IVizualizeable obj)
        {
            if (obj.GetType() != typeof(Car) && obj.GetType() != typeof(RoadPattern)) throw new ArgumentException();
            if (obj.GetType() == typeof(Car))
            {
                var car = obj as Car;
                var picture = new PictureBox();
                if (carPictures.ContainsKey(((Car) obj).CarModel))
                    picture.Image = carPictures[((Car) obj).CarModel];
                picture.Location = car.Location;
                picture.BackColor = Color.Transparent;
                picture.SizeMode = PictureBoxSizeMode.AutoSize;
                return picture;
            }
            if(obj.GetType() == typeof(RoadPattern))
            {
                var road = obj as RoadPattern;
                var picture = new PictureBox();
                picture.Image = Resources.road;
                picture.Location = road.Location;
                picture.BackColor = Color.Transparent;
                picture.SizeMode = PictureBoxSizeMode.AutoSize;
                return picture;
            }

            return null;
        }

        public static void UpdateLocation(PictureBox pictureBox, IVizualizeable obj)
        {
            pictureBox.Location = obj.Location;
        }

    }
    
}