using System;

namespace Zadanie2_KSR.MembershipFunctions
{
    public class TriangularFunction : IMembershipFunction
    {
        public readonly double A;
        public readonly double B;
        public readonly double C;

        public TriangularFunction(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double CountValue(double x)
        {
            if (x > A && x < B)
            {
                return (x - A) / (B - A);
            }

            if (Math.Abs(x - B) < 0.00000001)
            {
                return 1;
            }

            if (x > B && x < C)
            {
                return (C - x) / (C - B);
            }

            return 0;
        }

        public double GetMin()
        {
            return A;
        }

        public double GetMax()
        {
            return C;
        }

        public double CountArea()
        {
            var a = C - A;
            return a * 1 / 2;
        }
    }
}