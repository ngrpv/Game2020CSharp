using System;
using System.Drawing;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Views;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class CarTests
    {
        [TestCase( 0,0 ,10,10)]
        [TestCase( 1,1 ,11,11)]
        [TestCase( -2, -2 ,10,10)]
        public void Move_ShouldMoveOnDxDy(int x0, int y0, int dx, int dy)
        {
            var car = new Car(new Point(x0, y0));
            car.Move(dx,dy);
            Assert.AreEqual(new Point(x0+dx,y0+dy), car.Location);
        }
        
        /*[TestCase( 0,0 ,10,10)]
        [TestCase( 1,1 ,11,11)]
        [TestCase( -2, -2 ,10,10)]
        public void MoveTo_ShouldMoveToNewLocation(int x0, int y0, int x1, int x2)
        {
            var car = new Car(new Point(x0, y0), CarModel.Police);
            car.MoveTo(x1,x2);
            Assert.AreEqual(new Point(x1,x2), car.Location);
        }*/
    }
}