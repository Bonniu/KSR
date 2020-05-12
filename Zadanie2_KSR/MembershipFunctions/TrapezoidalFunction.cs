namespace Zadanie2_KSR.MembershipFunctions
{
    public class TrapezoidalFunction : MembershipFunction
    {
        public double CountValue(int a, int b, int c, int d, int x)
        {
            if (x > a && x < b)
            {
                return (double)(x - a) / (b - a);
            }
            if (x >= b && x <= c)
            {
                return 1;
            }
            if (x > c && x < d)
            {
                return (double)(d - x) / (d - c);
            }
            return 0;
        }
    }
}