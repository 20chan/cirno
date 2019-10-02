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
    }
}