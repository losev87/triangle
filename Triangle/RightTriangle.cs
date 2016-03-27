using System;
using static System.Math;

namespace Triangle
{
    public class RightTriangle
    {
        private double[] _sides;

        public RightTriangle(decimal a, decimal b, decimal c)
        {
            _sides = new double[3] { (double)a, (double)b, (double)c };

            //ставим гипотенузу на первое место
            for (int i = _sides.Length - 1; i >= 1; i--)
                if (_sides[i] > _sides[i - 1]) { var tmp = _sides[i]; _sides[i] = _sides[i - 1]; _sides[i - 1] = tmp; }

            if ((a <= 0) || (b <= 0) || (c <= 0))
                throw new ArgumentOutOfRangeException("Значения сторон не корректны!");

            //определяем точность проверки соответствия длин сторон прямоугольному треугольнику
            int precision = Max(Max(Precision(a, 15), Precision(b, 15)), Precision(c, 15));
            if (precision > 0)
                precision--; 

            if (Round(Abs(Pow(_sides[0], 2) - (Pow(_sides[1], 2) + Pow(_sides[2], 2))), precision) > 0)
                throw new ArgumentException("Стороны не соответствуют прямоугольному треугольнику!");
        }

        private int Precision(decimal n, int maxPrecision)
        {
            var p = maxPrecision;
            for (int i = 0; i < maxPrecision; i++)
            {
                if (n - decimal.Round(n, i) == 0)
                {
                    p = i;
                    break;
                }
            }
            return p;
        }

        public double Area() => _sides[1] * _sides[2] / 2;
    }
}
