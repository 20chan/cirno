using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cirno.Tests.Geometry
{
    [TestClass]
    public class VectorTest
    {
        private float NextFloat(Random random)
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);
            return BitConverter.ToSingle(buffer,0);
        }
        
        [TestMethod]
        public void GivenVector_WhenCallingDistance_ThenReturnDistanceFloat()
        {
            var rand = new Random();
            var aX = NextFloat(rand);
            var aY = NextFloat(rand);
            var bX = NextFloat(rand);
            var bY = NextFloat(rand);
            
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