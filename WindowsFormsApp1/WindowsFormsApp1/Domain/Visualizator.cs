﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1.Domain
{
    public static  class Visualizator
    {
        private static Dictionary<CarModel, Bitmap> carPictures = new ()
        {
            [CarModel.Police] = Resources.Police,
            [CarModel.Taxi] = Resources.taxi,
            [CarModel.RaceCar] = Resources.Audi,
            [CarModel.Truck] = Resources.truck,
        };

        public static Bitmap GetCarImage(CarModel model) => carPictures[model];
        
        /*
        public static PictureBox Initialize(VisualizeableObject obj)
        {
            if (obj.GetType() != typeof(Car) && obj.GetType() != typeof(RoadPattern)) throw new ArgumentException();
            if (obj.GetType() == typeof(Car))
            {
                var car = obj as Car;
                //var picture = new PictureBox();
                if (carPictures.ContainsKey(((Car) obj).CarModel))
                {
                    var temp = carPictures[((Car) obj).CarModel];
                    //temp.MakeTransparent();
                    picture.Image = temp;
                }
                
                picture.Location = car.Location;
               // picture.Dock = DockStyle.Fill;
                // picture.BackgroundImageLayout = ImageLayout.None;
                picture.BackColor = Color.Transparent;
                picture.SizeMode = PictureBoxSizeMode.AutoSize;
                //picture.Size = new Size(50, 50);
                return picture;
            }
            if(obj.GetType() == typeof(RoadPattern))
            {
                var road = obj as RoadPattern;
                var picture = new PictureBox
                {
                    Image = Resources.road,
                    Location = road.Location,
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.AutoSize
                };
                return picture;
            }

            return null;
        }
        */

       

    }
    
}