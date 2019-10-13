using cirno.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        public void TestClosestPoint()
        {
            // Initialize
            var pt = new Vector(0, 0);
            var circle = new Circle(new Vector(1, 1), 1);

            // Test
            var closest = circle.GetClosestPoint(pt);

            // Validation
            Assert.AreEqual(new Vector(0.29f, 0.29f), closest.Round(2));
        }

        [TestMethod]
        public void TestClosestPointDistance()
        {
            // Initialize
            var pt = new Vector(0, 0);
            var circle = new Circle(new Vector(1, 1), 1);

            // Test
            var distance = circle.Distance(pt);

            // Validation
            Assert.AreEqual(0.41, Math.Round(distance,2));
        }
    }
}