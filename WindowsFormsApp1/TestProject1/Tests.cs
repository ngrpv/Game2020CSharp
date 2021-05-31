using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Threading;
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
            var hitboxLocation0 = car.HitBox.Location;
            Assert.AreEqual(new Point(x0+dx,y0+dy), car.Location);
            Assert.AreEqual(new Point(hitboxLocation0.X+dx, hitboxLocation0.Y+dy), car.HitBox.Location);
        }

        [Test]
        public void IsCollide()
        {
            var car1 = new Car(new Point(0, 0));
            var car2 = new Car(new Point(0, 0));
            Assert.True(car1.HitBox.IsCollide(car2.HitBox));
        }
        [Test]
        public void IsNotCollide()
        {
            var car1 = new Car(new Point(0, 0));
            var car2 = new Car(new Point(500, 500));
            Assert.False(car1.HitBox.IsCollide(car2.HitBox));
        }

        [Test]
        public void SlowsDownByTimer()
        {
            var startSpeed = 40;
            var car = new Car(new Point(500, 500), startSpeed);
            Thread.Sleep(200);
            Assert.IsTrue(car.Speed < startSpeed);
        }
    }
}