using Microsoft.VisualStudio.TestTools.UnitTesting;
using cirno.Geometry;
using static cirno.Tests.Geometry.GeometryTestHelper;


namespace cirno.Tests.Geometry {
    [TestClass]
    public class LineIntersectionTest {
        [TestMethod]
        public void TestLineLine() {
            AssertIntersect(L(0, 0, 1, 1), L(0, 1, 1, 0), V(0.5f, 0.5f));

            AssertIntersect(L(0, 0, 1, 0), L(0, 0, 0, 1), V(0f, 0f));
            AssertIntersect(L(1, 0, 2, 0), L(0, 0, 0, 1), V(0f, 0f));
            AssertIntersect(L(1, 0, 2, 0), L(0, 1, 0, 2), V(0f, 0f));

            AssertIntersect(L(-1, 1, 1, 1), L(0, 2, 0, 0), V(0f, 1f));
        }

        [TestMethod]
        public void TestLineLineNo() {
            AssertIntersect(L(0, 0, 0, 1), L(1, 0, 1, 1));

            AssertIntersect(L(0, 0, 1, 1), L(0, 0, 1, 1));
            AssertIntersect(L(0, 0, 1, 1), L(1, 1, 2, 2));
        }

        [TestMethod]
        public void TestLineSeg() {

        }

        [TestMethod]
        public void TestSegSeg() {

        }
    }
}
