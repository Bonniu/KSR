using System.Collections.Generic;
using System.Security.Cryptography;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR.Fuzzy
{
    public class FuzzySet
    {
        private IMembershipFunction membershipFunction;
        private string attributeName;

        public FuzzySet(string attributeName, IMembershipFunction membershipFunction)
        {
            this.attributeName = attributeName;
            this.membershipFunction = membershipFunction;
        }

        public List<FifaPlayer> Support(List<FifaPlayer> fifaPlayers)
        {
            List<FifaPlayer> list = new List<FifaPlayer>();
            foreach (var fp in fifaPlayers)
            {
                if (membershipFunction.CountValue(ValueGetter.GetValueOfPlayer(fp, attributeName)) > 0)
                    list.Add(fp);
            }

            return list;
        }

        public double SupportValue(List<FifaPlayer> fifaPlayers)
        {
            return Support(fifaPlayers).Count;
        }

        public double DegreeOfFuzziness(List<FifaPlayer> fifaPlayers)
        {
            //kwantyfikatory // ????????????????????
            // quantifier absolute
            if (attributeName.Contains("Absolute"))
                return (membershipFunction.GetMax() - membershipFunction.GetMin()) / fifaPlayers.Count;

            if (attributeName.Contains("Quantifier"))
                return (membershipFunction.GetMax() - membershipFunction.GetMin());

            // sumaryzatory --- raczej git
            double X = 0;
            double min = 444444;
            double max = -2;
            foreach (var x in fifaPlayers)
            {
                if (ValueGetter.GetValueOfPlayer(x, attributeName) >= max)
                    max = ValueGetter.GetValueOfPlayer(x, attributeName);
                if (ValueGetter.GetValueOfPlayer(x, attributeName) <= min)
                    min = ValueGetter.GetValueOfPlayer(x, attributeName);
            }

            X = max - min;
            return (membershipFunction.GetMax() - membershipFunction.GetMin()) / X;
        }
    }
}