using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Test
{
    [TestClass]
    public class RightTriangleTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Исключение ArgumentException не было выброшено")]
        public void IncorrectIntSidesRightTriangleTest()
        {
            var t = new RightTriangle(3, 4, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Исключение ArgumentException не было выброшено")]
        public void IncorrectDecimalSidesRightTriangleTest()
        {
            var t = new RightTriangle(3.456m, 4.567m, 5.7272m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Исключение ArgumentOutOfRangeException не было выброшено")]
        public void IncorectSidesTest()
        {
            var t = new RightTriangle(-1, 0, 1);
        }

        [TestMethod]
        public void IntAreaTest()
        {
            var t = new RightTriangle(3, 4, 5);

            double expected = 3 * 4 / 2;
            double area = t.Area();

            Assert.AreEqual(expected, area, double.Epsilon, "Ошибка вычисления при корректных целых параметрах");
        }

        [TestMethod]
        public void DecimalAreaTest()
        {
            var t = new RightTriangle(3.456m, 4.567m, 5.72725m);

            double expected = (double)(3.456m * 4.567m / 2);
            double area = t.Area();

            Assert.AreEqual(expected, area, double.Epsilon, "Ошибка вычисления при корректных нецелочисленных параметрах");
        }
    }
}
