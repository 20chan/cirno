using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cirno.Tests.Geometry {
    [TestClass]
    public class VectorTest {
        
        [TestMethod]
        public void GivenVector_WhenCallingDistance_ThenReturnDistanceFloat() {
            var rand = new Random();
            var aX = rand.NextFloat();
            var aY = rand.NextFloat();
            var bX = rand.NextFloat();
            var bY = rand.NextFloat();

            var pointA = new Vector(aX, aY);
            var pointB = new Vector(bX, bY);

            var vector2A = new Vector2(aX, aY);
            var vector2B = new Vector2(bX, bY);
            var expected = Vector2.Distance(vector2A, vector2B);

            var actual = pointA.Distance(pointB);

            Assert.AreEqual(expected, actual, 0.01f);
        }
    }
}