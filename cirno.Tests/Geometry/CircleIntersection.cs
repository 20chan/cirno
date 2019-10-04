using cirno.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static cirno.Tests.Geometry.GeometryTestHelper;


namespace cirno.Tests.Geometry {
    [TestClass]
    public class CircleIntersection {
        [TestMethod]
        public void TestCircleCircleIntersect() {
            var c1 = new Circle(V(0.0f, 0.0f), 1.0f);
            var c2 = new Circle(V(1.0f, 0.0f), 1.0f);
            var intersects = new[]{V(0.5f, 0.8660254f), V(0.5f, -0.8660254f) };

            AssertIntersect(c1, c2, intersects);
            AssertIntersect(c2, c1, intersects);
        }

        [TestMethod]
        public void TestCircleCircleTangent() {
            var c1 = new Circle(V(0.0f, 0.0f), 1.0f);
            var c2 = new Circle(V(2.0f, 0.0f), 1.0f);
            var intersects = new[]{V(1.0f, 0.0f)};

            AssertIntersect(c1, c2, intersects);
            AssertIntersect(c2, c1, intersects);
        }

        [TestMethod]
        public void TestCircleCircleNoIntersection() {
            var c1 = new Circle(V(3.0f, 3.0f), 0.73f);
            var c2 = new Circle(V(-3.0f, -3.0f), 2.0f);
            var intersects = new Vector[]{};

            AssertIntersect(c1, c2, intersects);
            AssertIntersect(c2,c1, intersects);
        }

        [TestMethod]
        public void TestCircleLineIntersect() {
            var line = L(V(0.0f, 0.0f), V(1.0f, 0.0f));
            var circle = new Circle(V(0.0f, 0.0f), 1.0f);
            var intersects = new Vector[] {V(-1, 0), V(1, 0)};
            
            AssertIntersect(circle, line, intersects);
            AssertIntersect(line, circle, intersects);
        }

        [TestMethod]
        public void TestCircleLineIntersect2() {
            var line = L(V(0.0f, 0.0f), V(1.0f, 1.0f));
            var circle = new Circle(V(0.0f, 0.0f), 1.0f);
            var intersects = new[] {V(0.7071068f, 0.7071068f), V(-0.7071068f, -0.7071068f)};
            
            AssertIntersect(circle, line, intersects);
            AssertIntersect(line, circle, intersects);
        }

        [TestMethod]
        public void TestCircleLineTangent() {
            var line = L(V(0.0f, 1.0f), V(1.0f, 1.0f));
            var circle = new Circle(V(0.0f, 0.0f), 1.0f);
            var intersects = new[] {V(0.0f, 1.0f)};
            
            AssertIntersect(circle, line, intersects);
            AssertIntersect(line, circle, intersects);
        }

        [TestMethod]
        public void TestCircleLineNoIntersection() {
            var line = L(V(0.0f, 1.01f), V(1.0f, 1.01f));
            var circle = new Circle(V(0.0f, 0.0f), 1.0f);
            var intersects = new Vector[] {};
            
            AssertIntersect(circle, line, intersects);
            AssertIntersect(line, circle, intersects);
        }

        [TestMethod]
        public void TestCircleSegmentIntersect() {
            
        }

        [TestMethod]
        public void TestCircleSegmentTangent() {
            
        }

        [TestMethod]
        public void TestCircleSegmentNoIntersect() {
            
        }
    }
}