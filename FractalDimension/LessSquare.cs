using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalDimension
{
    class LessSquare
    {
        public static void GetCoefficient(IList<Tuple<double, double>> points, out double k, out double b)
        {
            double n = points.Count;
            double Sx = 0;  //сумма всех x
            double Sy = 0;  //сумма всех y
            double Sxx = 0; //сумма квадратов всех x
            double Sxy = 0; //сумма произведения всех x и y

            foreach (Tuple<double, double> point in points)
            {
                Sx += point.Item1;
                Sy += point.Item2;
                Sxx += point.Item1 * point.Item1;
                Sxy += point.Item1 * point.Item2;
            }

            k = (n * Sxy - Sy * Sx) / (n * Sxx - Sx * Sx);
            b = (Sxy * Sx - Sy * Sxx) / (Sx * Sx - n * Sxx);
        }
    }
}
