using System.Drawing;
using WindowsFormsApp1.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void MovingCar()
        {
            var car = new Car(new Point(0, 0), 20);
            car.Move(10,10);
            Assert.AreEqual(new Point(10,10), car.Location);
        }
    }
}
