using cirno.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cirno.Tests.Geometry {
    public static class GeometryTestHelper {
        public static void AssertIntersect(IShape a, IShape b, params Vector[] intersects) {
            if (intersects.Length == 0) {
                Assert.IsFalse(a.Intersects(b));
                Assert.IsFalse(b.Intersects(a));

                Assert.IsFalse(a.TryGetIntersects(b, out _));
                Assert.IsFalse(b.TryGetIntersects(a, out _));
                return;
            }
            Assert.IsTrue(a.Intersects(b));
            Assert.IsTrue(b.Intersects(a));

            Assert.IsTrue(a.TryGetIntersects(b, out var i0));
            CollectionAssert.AreEquivalent(intersects, i0);
            Assert.IsTrue(b.TryGetIntersects(a, out var i1));
            CollectionAssert.AreEquivalent(intersects, i1);
        }

        public static Vector V(float x, float y) {
            return new Vector(x, y);
        }

        public static Line L(Vector p1, Vector p2) {
            return new Line(p1, p2);
        }

        public static Line L(float x1, float y1, float x2, float y2) {
            return new Line(new Vector(x1, y1), new Vector(x2, y2));
        }

        public static LineSegment S(Vector p1, Vector p2) {
            return new LineSegment(p1, p2);
        }

        public static LineSegment S(float x1, float y1, float x2, float y2) {
            return new LineSegment(new Vector(x1, y1), new Vector(x2, y2));
        }
    }
}
