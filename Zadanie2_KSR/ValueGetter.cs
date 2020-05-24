namespace Zadanie2_KSR
{
    public static class ValueGetter
    {
        public static double GetValueOfPlayer(FifaPlayer fp, string attributeName)
        {
            return attributeName switch
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