using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable StringLiteralTypo

namespace Zadanie2_KSR.Fuzzy
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public static class Summarizers
    {
        public static readonly LinguisticVariable VeryYoungAge =
            new LinguisticVariable("very young", "Age", true, new TrapezoidalFunction(16, 16, 18, 21));

        public static readonly LinguisticVariable YoungAge =
            new LinguisticVariable("young", "Age", true, new TrapezoidalFunction(20, 22, 24, 25));

        public static readonly LinguisticVariable AverageAge =
            new LinguisticVariable("average (age)", "Age", true, new TrapezoidalFunction(24, 26, 29, 32));

        public static readonly LinguisticVariable OldAge =
            new LinguisticVariable("old", "Age", true, new TrapezoidalFunction(31, 34, 42, 42));

        public static List<LinguisticVariable> GetAllAgeVariables()
        {
            return new List<LinguisticVariable>
            {
                VeryYoungAge, YoungAge, AverageAge, OldAge
            };
        }

        public static readonly LinguisticVariable ShortHeight =
            new LinguisticVariable("short", "Height", true, new TriangularFunction(156, 156, 166));

        public static readonly LinguisticVariable AverageHeight =
            new LinguisticVariable("average (height)", "Height", true, new TriangularFunction(164, 170, 177));

        public static readonly LinguisticVariable HighHeight =
            new LinguisticVariable("high", "Height", true, new TriangularFunction(175, 182, 188));

        public static readonly LinguisticVariable VeryHighHeight =
            new LinguisticVariable("very high", "Height", true, new TriangularFunction(186, 205, 205));

        public static List<LinguisticVariable> GetAllHeightVariables()
        {
            return new List<LinguisticVariable>
            {
                ShortHeight, AverageHeight, HighHeight, VeryHighHeight
            };
        }

        public static readonly LinguisticVariable VeryThinWeight =
            new LinguisticVariable("very thin", "Weight", true, new GaussianFunction(50, 8, 50, 110));

        public static readonly LinguisticVariable ThinWeight =
            new LinguisticVariable("thin", "Weight", true, new GaussianFunction(70, 8, 50, 110));

        public static readonly LinguisticVariable AverageWeight =
            new LinguisticVariable("average (weight)", "Weight", true, new GaussianFunction(90, 8, 50, 110));

        public static readonly LinguisticVariable ThickWeight =
            new LinguisticVariable("thick", "Weight", true, new GaussianFunction(110, 8, 50, 110));

        public static List<LinguisticVariable> GetAllWeightVariables()
        {
            return new List<LinguisticVariable>
            {
                VeryThinWeight, ThinWeight, AverageWeight, ThickWeight
            };
        }

        public static readonly LinguisticVariable LowOverall =
            new LinguisticVariable("low overall", "Overall", true, new TrapezoidalFunction(48, 48, 59, 65));

        public static readonly LinguisticVariable AverageOverall =
            new LinguisticVariable("average overall", "Overall", true, new TrapezoidalFunction(60, 65, 70, 75));

        public static readonly LinguisticVariable GoodOverall =
            new LinguisticVariable("good overall", "Overall", true, new TrapezoidalFunction(70, 78, 85, 87));

        public static readonly LinguisticVariable VeryGoodOverall =
            new LinguisticVariable("very good overall", "Overall", true, new TrapezoidalFunction(85, 90, 94, 94));

        public static List<LinguisticVariable> GetAllOverallVariables()
        {
            return new List<LinguisticVariable>
            {
                LowOverall, AverageOverall, GoodOverall, VeryGoodOverall
            };
        }

        public static readonly LinguisticVariable VeryBadFinishing =
            new LinguisticVariable("very bad finishing", "Finishing", true, new TrapezoidalFunction(2, 2, 25, 35));

        public static readonly LinguisticVariable BadFinishing =
            new LinguisticVariable("bad finishing", "Finishing", true, new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable AverageFinishing =
            new LinguisticVariable("average finishing", "Finishing", true, new TrapezoidalFunction(50, 55, 75, 80));

        public static readonly LinguisticVariable GoodFinishing =
            new LinguisticVariable("good finishing", "Finishing", true, new TrapezoidalFunction(75, 80, 85, 87));

        public static readonly LinguisticVariable VeryGoodFinishing =
            new LinguisticVariable("very good finishing", "Finishing", true, new TrapezoidalFunction(85, 90, 95, 95));

        public static List<LinguisticVariable> GetAllFinishingVariables()
        {
            return new List<LinguisticVariable>
            {
                VeryBadFinishing, BadFinishing, AverageFinishing, GoodFinishing, VeryGoodFinishing
            };
        }

        public static readonly LinguisticVariable VeryBadDribbling =
            new LinguisticVariable("very bad dribbling", "Dribbling", true, new TrapezoidalFunction(4, 4, 25, 35));

        public static readonly LinguisticVariable BadDribbling =
            new LinguisticVariable("bad dribbling", "Dribbling", true, new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable AverageDribbling =
            new LinguisticVariable("average dribbling", "Dribbling", true, new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable GoodDribbling =
            new LinguisticVariable("good dribbling", "Dribbling", true, new TrapezoidalFunction(68, 73, 85, 87));

        public static readonly LinguisticVariable VeryGoodDribbling =
            new LinguisticVariable("very good dribbling", "Dribbling", true, new TrapezoidalFunction(85, 90, 97, 97));

        public static List<LinguisticVariable> GetAllDribblingVariables()
        {
            return new List<LinguisticVariable>
            {
                VeryBadDribbling, BadDribbling, AverageDribbling, GoodDribbling, VeryGoodDribbling
            };
        }

        public static readonly LinguisticVariable VeryWeakCurve =
            new LinguisticVariable("very weak curve", "Curve", true, new TriangularFunction(6, 6, 35));

        public static readonly LinguisticVariable WeakCurve =
            new LinguisticVariable("weak curve", "Curve", true, new TriangularFunction(20, 35, 60));

        public static readonly LinguisticVariable AverageCurve =
            new LinguisticVariable("average curve", "Curve", true, new TriangularFunction(50, 60, 70));

        public static readonly LinguisticVariable GoodCurve =
            new LinguisticVariable("good curve", "Curve", true, new TriangularFunction(68, 75, 87));

        public static readonly LinguisticVariable VeryGoodCurve =
            new LinguisticVariable("very good curve", "Curve", true, new TriangularFunction(85, 94, 94));

        public static List<LinguisticVariable> GetAllCurveVariables()
        {
            return new List<LinguisticVariable>
            {
                VeryWeakCurve, WeakCurve, AverageCurve, GoodCurve, VeryGoodCurve
            };
        }

        public static readonly LinguisticVariable VeryWeakLongPassing =
            new LinguisticVariable("very weak long passing", "LongPassing", true,
                new TrapezoidalFunction(8, 8, 25, 35));

        public static readonly LinguisticVariable WeakLongPassing =
            new LinguisticVariable("weak long passing", "LongPassing", true, new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable AverageLongPassing =
            new LinguisticVariable("average long passing", "LongPassing", true,
                new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable GoodLongPassing =
            new LinguisticVariable("good long passing", "LongPassing", true, new TrapezoidalFunction(68, 73, 80, 85));

        public static readonly LinguisticVariable VeryGoodLongPassing =
            new LinguisticVariable("very good long passing", "LongPassing", true,
                new TrapezoidalFunction(82, 85, 92, 92));

        public static List<LinguisticVariable> GetAllLongPassingVariables()
        {
            return new List<LinguisticVariable>
            {
                VeryWeakLongPassing, WeakLongPassing, AverageLongPassing, GoodLongPassing, VeryGoodLongPassing
            };
        }

        public static readonly LinguisticVariable VerySlowSprint =
            new LinguisticVariable("very slow", "Sprint", true, new TrapezoidalFunction(11, 11, 25, 35));

        public static readonly LinguisticVariable SlowSprint =
            new LinguisticVariable("slow", "Sprint", true, new TrapezoidalFunction(30, 35, 48, 55));

        public static readonly LinguisticVariable AverageSprint =
            new LinguisticVariable("average (sprint)", "Sprint", true, new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable FastSprint =
            new LinguisticVariable("fast", "Sprint", true, new TrapezoidalFunction(68, 73, 80, 86));

        public static readonly LinguisticVariable VeryFastSprint =
            new LinguisticVariable("very fast", "Sprint", true, new TrapezoidalFunction(84, 90, 96, 96));

        public static List<LinguisticVariable> GetAllSprintVariables()
        {
            return new List<LinguisticVariable>
            {
                VerySlowSprint, SlowSprint, AverageSprint, FastSprint, VeryFastSprint
            };
        }

        public static readonly LinguisticVariable WeakShotPower =
            new LinguisticVariable("weak shot power", "ShotPower", true, new TrapezoidalFunction(14, 14, 45, 50));

        public static readonly LinguisticVariable AverageShotPower =
            new LinguisticVariable("average shot power", "ShotPower", true, new TrapezoidalFunction(45, 50, 60, 65));

        public static readonly LinguisticVariable HighShotPower =
            new LinguisticVariable("high shot power", "ShotPower", true, new TrapezoidalFunction(62, 68, 80, 82));

        public static readonly LinguisticVariable VeryHighShotPower =
            new LinguisticVariable("very high shot power", "ShotPower", true, new TrapezoidalFunction(80, 88, 95, 95));

        public static List<LinguisticVariable> GetAllShotPowerVariables()
        {
            return new List<LinguisticVariable>
            {
                WeakShotPower, AverageShotPower, HighShotPower, VeryHighShotPower
            };
        }


        public static List<LinguisticVariable> GetAllVariables()
        {
            var list = new List<LinguisticVariable>();
            list.AddRange(GetAllAgeVariables());
            list.AddRange(GetAllHeightVariables());
            list.AddRange(GetAllWeightVariables());
            list.AddRange(GetAllOverallVariables());
            list.AddRange(GetAllFinishingVariables());
            list.AddRange(GetAllDribblingVariables());
            list.AddRange(GetAllCurveVariables());
            list.AddRange(GetAllLongPassingVariables());
            list.AddRange(GetAllSprintVariables());
            list.AddRange(GetAllShotPowerVariables());
            return list;
        }

        public static LinguisticVariable GetVariableFromString(string text)
        {
            return GetAllVariables().Find(x => x.Text == text);
        }
    }
}