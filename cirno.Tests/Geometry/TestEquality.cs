using Microsoft.VisualStudio.TestTools.UnitTesting;
using cirno.Geometry;
using static cirno.Tests.Geometry.GeometryTestHelper;

namespace cirno.Tests.Geometry {
    [TestClass]
    public class TestEquality {
        [TestMethod]
        public void TestLineEquality() {
            Assert.AreEqual(L(0, 0, 1, 1), L(0, 0, 1, 1));
            Assert.AreEqual(L(0, 0, 1, 1), L(0, 0, 2, 2));
            Assert.AreEqual(L(0, 0, 1, 1), L(1, 1, 2, 2));
            Assert.AreEqual(L(0, 0, 1, 1), L(5, 5, 2, 2));
        }
    }
}
