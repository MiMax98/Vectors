using Microsoft.VisualStudio.TestTools.UnitTesting;
using UlamekBiblioteka;

namespace UlamekBibliotekaTestProject
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void LengthTest()
        {
            var vector = new Vector(3, -4, 0);
            var length = vector.Length;
            Assert.AreEqual(5, length);
        }

        [TestMethod]
        public void AddingTest()
        {
            var v1 = new Vector(2, -3, 1);
            var v2 = new Vector(4, 1, -3);
            var sum = v1 + v2;
            Assert.AreEqual(6, sum.X);
            Assert.AreEqual(-2, sum.Y);
            Assert.AreEqual(-2, sum.Z);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            var v1 = new Vector(2, -3, 1);
            var v2 = new Vector(4, 1, -3);
            var diff = v1 - v2;
            Assert.AreEqual(-2, diff.X);
            Assert.AreEqual(-4, diff.Y);
            Assert.AreEqual(4, diff.Z);
        }

        [TestMethod]
        public void EqualityTest()
        {
            var v1 = new Vector(3, 4, -5);
            var v2 = new Vector(3, 4, -5);
            var eq = v1 == v2;
            Assert.IsTrue(eq);
        }

        [TestMethod]
        public void InequalityTest()
        {
            var v1 = new Vector(3, 4, -5);
            var v2 = new Vector(1, 2, 7);
            var eq = v1 != v2;
            Assert.IsTrue(eq);
        }

        [TestMethod]
        public void DotProductTest()
        {
            var v1 = new Vector(1,2,3);
            var v2 = new Vector(1,5,7);
            var result = v1 * v2;
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void CrossProductTest()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(1, 5, 7);
            var result = v1 ^ v2;
            Assert.AreEqual(-1, result.X);
            Assert.AreEqual(-4, result.Y);
            Assert.AreEqual(3, result.Z);
        }

        [TestMethod]
        public void ScalarMultiplicationTest()
        {
            var vec = new Vector(1, -5, 7);
            var s = 3;
            var result = s * vec;
            Assert.AreEqual(3, result.X);
            Assert.AreEqual(-15, result.Y);
            Assert.AreEqual(21, result.Z);
        }
    }
}
