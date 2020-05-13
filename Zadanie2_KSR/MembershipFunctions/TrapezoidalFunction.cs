namespace Zadanie2_KSR.MembershipFunctions
{
    public class TrapezoidalFunction : IMembershipFunction
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        private readonly double _d;

        public TrapezoidalFunction(double a, double b, double c, double d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public double CountValue(int x)
        {
            if (x > _a && x < _b)
            {
                return (x - _a) / (_b - _a);
            }

            if (x >= _b && x <= _c)
            {
                return 1;
            }

            if (x > _c && x < _d)
            {
                return (_d - x) / (_d - _c);
            }

            return 0;
        }
    }
}