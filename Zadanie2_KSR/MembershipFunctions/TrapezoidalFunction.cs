using System;

namespace Zadanie2_KSR.MembershipFunctions
{
    public class TrapezoidalFunction : IMembershipFunction
    {
        public readonly double A;
        public readonly double B;
        public readonly double C;
        public readonly double D;

        public TrapezoidalFunction(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public double CountValue(double x)
        {
            if (x > A && x < B)
            {
                return (x - A) / (B - A);
            }

            if (x >= B && x <= C)
            {
                return 1;
            }

            if (x > C && x < D)
            {
                return (D - x) / (D - C);
            }

            return 0;
        }

        public double GetMin()
        {
            return A;
        }

        public double GetMax()
        {
            return D;
        }

        public double CountArea()
        {
            var x1 = D - A;
            var x2 = C - B;
            return (x1 + x2) * 1 / 2;
        }

        public override string ToString()
        {
            return "A: " + A + " B: " + B + " C: " + C + " D: " + D + " area: " + CountArea();
        }
    }
}