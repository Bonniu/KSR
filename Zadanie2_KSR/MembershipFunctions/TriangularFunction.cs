using System;

namespace Zadanie2_KSR.MembershipFunctions
{
    public class TriangularFunction : IMembershipFunction
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        public TriangularFunction(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double CountValue(int x)
        {
            if (x > _a && x < _b)
            {
                return (x - _a) / (_b - _a);
            }

            if (Math.Abs(x - _b) < 0.00000001)
            {
                return 1;
            }

            if (x > _b && x < _c)
            {
                return (_c - x) / (_c - _b);
            }

            return 0;
        }
    }
}