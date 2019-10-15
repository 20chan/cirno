using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cirno;
using cirno.Geometry;
using static cirno.Tests.Geometry.GeometryTestHelper;

namespace cirno.Tests.Geometry {
    [TestClass]
    public class LineTest {
        [TestMethod]
        public void TestLineSide() {
            var line0 = L(0, 0, 1, 1);
            Assert.AreEqual(-1, line0.GetSideOf(V(0, 1)));
            Assert.AreEqual(0, line0.GetSideOf(V(0.5f, 0.5f)));
            Assert.AreEqual(1, line0.GetSideOf(V(1, 0)));

            var line1 = L(0, 0, 0, 3);
            Assert.AreEqual(-1, line1.GetSideOf(V(-1, -1)));
            Assert.AreEqual(0, line1.GetSideOf(V(0, 0)));
            Assert.AreEqual(1, line1.GetSideOf(V(1, 10)));
        }

        [TestMethod]
        public void TestLinePerpendicular() {
            var line0 = L(0, 0, 1, 1);
            Assert.AreEqual(V(0.5f, 0.5f), line0.GetPerpendicularFootOn(V(0, 1)));
            Assert.AreEqual(V(1, 0), line0.GetPerpendicular(V(0, 1)));
        }

        [TestMethod]
        public void GivenLine_WhenCallingGetClosestPointWithAPoint_ThenReturnClosestPoint() {
            var point = new Vector(1f, 1f);
            var line = new Line(new Vector(0f, 0f), new Vector(0f ,1f));

            var expected = new Vector(0f, 1f);
            var actual = line.GetClosestPoint(point);

            Assert.IsTrue(expected.Equals(actual, 0.01f));
        }
        
        [TestMethod]
        public void GivenLine_WhenCallingGetClosestPointWithAnotherPoint_ThenReturnClosestPoint() {
            var point = new Vector(0.5f, 0.5f);
            var line = new Line(new Vector(0f, 0f), new Vector(0f ,1f));

            var expected = new Vector(0f, 0.5f);
            var actual = line.GetClosestPoint(point);

            Assert.IsTrue(expected.Equals(actual, 0.01f));
        }
        
        [TestMethod]
        public void GivenHorizontalLine_WhenCallingGetClosestPointWithPoint_ThenReturnClosestPoint() {
            var point = new Vector(0.5f, 0.5f);
            var line = new Line(new Vector(0f, 0f), new Vector(1f ,0f));

            var expected = new Vector(0.5f, 0f);
            var actual = line.GetClosestPoint(point);

            Assert.IsTrue(expected.Equals(actual, 0.01f));
        }
        
        [TestMethod]
        public void GivenSlopedLine_WhenCallingGetClosestPointWithPoint_ThenReturnClosestPoint() {
            var point = new Vector(0.5f, 0.5f);
            var line = new Line(new Vector(0f, 0f), new Vector(1f ,1f));

            var expected = new Vector(0.5f, 0.5f);
            var actual = line.GetClosestPoint(point);

            Assert.IsTrue(expected.Equals(actual, 0.01f));
        }

        [TestMethod]
        public void GivenLine_WhenCallingDistanceToAPoint_ThenReturnDistance() {
            var line = new Line(new Vector(0f, 0f), new Vector(0f ,1f));
            var point = new Vector(1f, 1f);

            var expected = 1f;
            var actual = line.Distance(point);

            Assert.AreEqual(expected, actual, 0.01f);
        }
    }
}
