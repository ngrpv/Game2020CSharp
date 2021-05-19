using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1.Domain
{
    public static  class Visualizator
    {
        private static Dictionary<CarModel, Bitmap> carPictures = new Dictionary<CarModel, Bitmap>()
        {
            [CarModel.Police] = Resources.Police,
            [CarModel.Taxi] = Resources.taxi,
            [CarModel.RaceCar] = Resources.Audi,
            [CarModel.Truck] = Resources.truck,
        };
        
        public static PictureBox Initialize(VisualizeableObject obj)
        {
            if (obj.GetType() != typeof(Car) && obj.GetType() != typeof(RoadPattern)) throw new ArgumentException();
            if (obj.GetType() == typeof(Car))
            {
                var car = obj as Car;
                var picture = new PictureBox();
                if (carPictures.ContainsKey(((Car) obj).CarModel))
                {
                    var temp = carPictures[((Car) obj).CarModel];
                    temp.MakeTransparent();
                    picture.Image = temp;
                }
                
                picture.Location = car.Location;
              //  picture.Dock = DockStyle.Fill;
                 picture.BackgroundImageLayout = ImageLayout.None;
                picture.BackColor = Color.Transparent;
                picture.SizeMode = PictureBoxSizeMode.AutoSize;
                //picture.Size = new Size(50, 50);
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

        public static void UpdateLocation(ObjectWithPicture objectWithPicture)
        {
            objectWithPicture.Picture.Location = objectWithPicture.Obj.Location;
        }

    }
    
}