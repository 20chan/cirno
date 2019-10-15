using System;
using System.Numerics;
using cirno.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cirno.Tests.Geometry {
    [TestClass]
    public class CircleTest {
        [TestMethod]
        public void TestConcentricSelf() {
            var circle1 = new Circle(new Vector(0.0f, 0.0f), 1.0f);

            Assert.AreEqual(true, circle1.Concentric(circle1));
        }

        [TestMethod]
        public void TestConcentricOther() {
            var circle1 = new Circle(new Vector(0.0f, 0.0f), 1.0f);
            var circle2 = new Circle(new Vector(0.0f, 0.0f), 2.0f);

            Assert.AreEqual(true, circle1.Concentric(circle2));
            Assert.AreEqual(true, circle2.Concentric(circle1));
        }

        [TestMethod]
        public void TestNonConcentricOther() {
            var circle1 = new Circle(new Vector(0.0f, 0.0f), 1.0f);
            var circle2 = new Circle(new Vector(1.0f, 1.0f), 2.0f);

            Assert.AreEqual(false, circle1.Concentric(circle2));
            Assert.AreEqual(false, circle2.Concentric(circle1));
        }

        [TestMethod]
        public void GivenCircle_WhenCallingGetClosestPointWithAPoint_ThenReturnClosestPoint(){
            var circle = new Circle(new Vector(1f, 1f), 1f);
            var closest = circle.GetClosestPoint(new Vector(0f, 0f));
            Assert.IsTrue(closest.Equals(new Vector(0.29f, 0.29f), 0.01f));
        }

        [TestMethod]
        public void GivenCircle_WhenCallingDistanceToAPoint_ThenReturnDistance(){
            var rand = new Random();
            var circle = new Circle(new Vector(rand.NextFloat(), rand.NextFloat()), rand.NextFloat());
            var point = new Vector(rand.NextFloat(), rand.NextFloat());
            var closest = circle.GetClosestPoint(point);

            var expected = Vector2.Distance(new Vector2(closest.X, closest.Y), new Vector2(point.X, point.Y));
            var actual = circle.Distance(point);

            Assert.AreEqual(expected, actual, 0.01f);
        }
    }
}