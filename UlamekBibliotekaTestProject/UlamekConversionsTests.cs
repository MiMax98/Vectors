using Microsoft.VisualStudio.TestTools.UnitTesting;
using UlamekBiblioteka;

namespace UlamekBibliotekaTestProject
{
    [TestClass]
    public class UlamekConversionsTests
    {
        [TestMethod]
        public void UlamekToInt()
        {
            var u = new Ulamek { Licznik = 5, Mianownik = 3 };
            var result = u.ToInt32(null);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void UlamekToString()
        {
            var u = new Ulamek { Licznik = 5, Mianownik = 3 };
            var result = u.ToString(null);
            Assert.AreEqual("5/3", result);
        }
        [TestMethod]
        public void UlamekToDecimal()
        {
            var u = new Ulamek { Licznik = 2, Mianownik = 4 };
            var result = u.ToDecimal(null);
            Assert.AreEqual(0.5m, result);
        }
        [TestMethod]
        public void UlamekToDouble()
        {
            var u = new Ulamek { Licznik = 1, Mianownik = 2 };
            var result = u.ToDouble(null);
            Assert.AreEqual(0.5, result);
        }
        [TestMethod]
        public void UlamekToDateTime()
        {
            var u = new Ulamek { Licznik = 5, Mianownik = 2 };
            var result = u.ToDateTime(null);
            Assert.AreEqual(new System.DateTime(2), result);
        }
    }
}
