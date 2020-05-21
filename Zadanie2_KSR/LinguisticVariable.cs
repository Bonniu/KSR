using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    public class LinguisticVariable
    {
        public readonly string Text;
        public readonly string AttributeName;
        public readonly bool QuantifierAbsolute;
        public readonly string Type;
        public readonly IMembershipFunction MembershipFunction;

        public LinguisticVariable(string text, string attributeName, bool quantifierAbsolute,
            IMembershipFunction membershipFunction)
        {
            Text = text;
            AttributeName = attributeName;
            if (attributeName == "Quantifier")
                Type = "";
            else if (attributeName == "Age" || attributeName == "Height" ||
                     attributeName == "Weight" || attributeName == "Sprint")
                Type = "are";
            else
            {
                Type = "have";
            }

            QuantifierAbsolute = quantifierAbsolute;
            MembershipFunction = membershipFunction;
        }

        public override string ToString()
        {
            return "{Text='" + Text + "', AttributeName=" + AttributeName + ", MembershipFunction=" +
                   MembershipFunction + "}";
        }

        public double CountMembership(FifaPlayer fp)
        {
            return MembershipFunction.CountValue(GetValueOfPlayer(fp));
        }

        private double GetValueOfPlayer(FifaPlayer fp)
        {
            return AttributeName switch
            {
                "Age" => fp.GetAge(),
                "Height" => fp.GetHeight(),
                "Curve" => fp.GetCurve(),
                "Dribbling" => fp.GetDribbling(),
                "Sprint" => fp.GetSprintSpeed(),
                "Finishing" => fp.GetFinishing(),
                "Overall" => fp.GetOverall(),
                "LongPassing" => fp.GetPassing(),
                "Weight" => fp.GetWeight(),
                "ShotPower" => fp.GetShotPower(),
                _ => 0
            };
        }
    }
}