using System;

namespace Zadanie2_KSR.MembershipFunctions
{
    public class GaussianFunction : IMembershipFunction
    {
        private readonly double _avgX;
        private readonly double _width;

        public GaussianFunction(double avgX, double width)
        {
            _avgX = avgX;
            _width = width;
        }

        public double CountValue(int x)
        {
            var tmpFraction = (x - _avgX) / _width;
            return Math.Exp(-tmpFraction * tmpFraction);
        }
    }
}