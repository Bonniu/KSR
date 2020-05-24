using System;

namespace Zadanie2_KSR.MembershipFunctions
{
    public class GaussianFunction : IMembershipFunction
    {
        public readonly double AvgX;
        public readonly double Width;

        public GaussianFunction(double avgX, double width)
        {
            AvgX = avgX;
            Width = width;
        }

        public double CountValue(double x)
        {
            var tmpFraction = (x - AvgX) / Width;
            return Math.Exp(-tmpFraction * tmpFraction);
        }

        public double GetMin()
        {
            return int.MinValue;
        }

        public double GetMax()
        {
            return int.MaxValue;
        }
    }
}