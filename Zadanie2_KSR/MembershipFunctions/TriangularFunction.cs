namespace Zadanie2_KSR.MembershipFunctions
{
    public class TriangularFunction : MembershipFunction
    {
        public double CountValue(int a, int b, int c, int x)
        {
            if (x > a && x < b)
            {
                return (double) (x - a) / (b - a);
            }

            if (x == b)
            {
                return 1;
            }

            if (x > b && x < c)
            {
                return (double) (c - x) / (c - b);
            }

            return 0;
        }
    }
}