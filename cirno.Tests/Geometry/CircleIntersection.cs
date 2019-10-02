using cirno.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static cirno.Tests.Geometry.GeometryTestHelper;


namespace cirno.Tests.Geometry {
    [TestClass]
    public class CircleIntersection {
        [TestMethod]
        public void TestCircleCircleIntersect() {
            var c1 = new Circle(new Vector(0.0f, 0.0f), 1.0f);
            var c2 = new Circle(new Vector(1.0f, 0.0f), 1.0f);
            var intersects = new Vector[]{new Vector(0.5f, 0.8660254f), new Vector(0.5f, -0.8660254f) };

            AssertIntersect(c1, c2, intersects);
        }

        [TestMethod]
        public void TestCircleCircleTangent() {
            var c1 = new Circle(new Vector(0.0f, 0.0f), 1.0f);
            var c2 = new Circle(new Vector(2.0f, 0.0f), 1.0f);
            var intersects = new Vector[]{new Vector(1.0f, 0.0f)};

            AssertIntersect(c1, c2, intersects);
        }

        [TestMethod]
        public void TestCircleCircleNoIntersection() {
            var c1 = new Circle(new Vector(3.0f, 3.0f), 0.73f);
            var c2 = new Circle(new Vector(-3.0f, -3.0f), 2.0f);
            var intersects = new Vector[]{};

            AssertIntersect(c1, c2, intersects);
        }
    }
}