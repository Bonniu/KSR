using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    public class LinguisticVariable
    {
        public string Text;
        public string AttributeName;
        public IMembershipFunction MembershipFunction;

        public LinguisticVariable(string text, string attributeName, IMembershipFunction membershipFunction)
        {
            Text = text;
            AttributeName = attributeName;
            MembershipFunction = membershipFunction;
        }

        public override string ToString()
        {
            return "{Text='" + Text + "', AttributeName=" + AttributeName + ", MembershipFunction=" + MembershipFunction + "}";
        }
    }
}