using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable StringLiteralTypo

namespace Zadanie2_KSR
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class Attributes
    {
        public static readonly LinguisticVariable BardzoMlodyAge =
            new LinguisticVariable("very young", "Age", new TrapezoidalFunction(16, 16, 18, 21));

        public static readonly LinguisticVariable MlodyAge =
            new LinguisticVariable("young", "Age", new TrapezoidalFunction(20, 22, 24, 25));

        public static readonly LinguisticVariable SredniAge =
            new LinguisticVariable("average (age)", "Age", new TrapezoidalFunction(24, 26, 29, 32));

        public static readonly LinguisticVariable StaryAge =
            new LinguisticVariable("old", "Age", new TrapezoidalFunction(31, 34, 42, 42));

        public static List<LinguisticVariable> GetAllAgeVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoMlodyAge, MlodyAge, SredniAge, StaryAge
            };
        }

        public static readonly LinguisticVariable NiskiHeight =
            new LinguisticVariable("short", "Height", new TriangularFunction(156, 156, 166));

        public static readonly LinguisticVariable SredniHeight =
            new LinguisticVariable("average (height)", "Height", new TriangularFunction(164, 170, 177));

        public static readonly LinguisticVariable WysokiHeight =
            new LinguisticVariable("high", "Height", new TriangularFunction(175, 182, 188));

        public static readonly LinguisticVariable BardzoWysokiHeight =
            new LinguisticVariable("very high", "Height", new TriangularFunction(186, 205, 205));

        public static List<LinguisticVariable> GetAllHeightVariables()
        {
            return new List<LinguisticVariable>
            {
                NiskiHeight, SredniHeight, WysokiHeight, BardzoWysokiHeight
            };
        }

        public static readonly LinguisticVariable BardzoChudyWeight =
            new LinguisticVariable("very thin", "Weight", new GaussianFunction(50, 8));

        public static readonly LinguisticVariable ChudyWeight =
            new LinguisticVariable("thin", "Weight", new GaussianFunction(70, 8));

        public static readonly LinguisticVariable SredniWeight =
            new LinguisticVariable("average (weight)", "Weight", new GaussianFunction(90, 8));

        public static readonly LinguisticVariable GrubyWeight =
            new LinguisticVariable("thick", "Weight", new GaussianFunction(110, 8));

        public static List<LinguisticVariable> GetAllWeightVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoChudyWeight, ChudyWeight, SredniWeight, GrubyWeight
            };
        }

        public static readonly LinguisticVariable SlabyOverall =
            new LinguisticVariable("low overall", "Overall", new TrapezoidalFunction(48, 48, 59, 65));

        public static readonly LinguisticVariable SredniOverall =
            new LinguisticVariable("average overall", "Overall", new TrapezoidalFunction(60, 65, 70, 75));

        public static readonly LinguisticVariable DobryOverall =
            new LinguisticVariable("good overall", "Overall", new TrapezoidalFunction(70, 78, 85, 87));

        public static readonly LinguisticVariable BardzoDobryOverall =
            new LinguisticVariable("very good overall", "Overall", new TrapezoidalFunction(85, 90, 94, 94));

        public static List<LinguisticVariable> GetAllOverallVariables()
        {
            return new List<LinguisticVariable>
            {
                SlabyOverall, SredniOverall, DobryOverall, BardzoDobryOverall
            };
        }

        public static readonly LinguisticVariable BardzoSlabeFinishing =
            new LinguisticVariable("very bad finishing", "Finishing", new TrapezoidalFunction(2, 2, 25, 35));

        public static readonly LinguisticVariable SlabeFinishing =
            new LinguisticVariable("bad finishing", "Finishing", new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable SrednieFinishing =
            new LinguisticVariable("average finishing", "Finishing", new TrapezoidalFunction(50, 55, 75, 80));

        public static readonly LinguisticVariable DobreFinishing =
            new LinguisticVariable("good finishing", "Finishing", new TrapezoidalFunction(75, 80, 85, 87));

        public static readonly LinguisticVariable BardzoDobreFinishing =
            new LinguisticVariable("very good finishing", "Finishing", new TrapezoidalFunction(85, 90, 95, 95));

        public static List<LinguisticVariable> GetAllFinishingVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoSlabeFinishing, SlabeFinishing, SrednieFinishing, DobreFinishing, BardzoDobreFinishing
            };
        }

        public static readonly LinguisticVariable BardzoSlabyDribbling =
            new LinguisticVariable("very bad dribbling", "Dribbling", new TrapezoidalFunction(4, 4, 25, 35));

        public static readonly LinguisticVariable SlabyDribbling =
            new LinguisticVariable("bad dribbling", "Dribbling", new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable SredniDribbling =
            new LinguisticVariable("average dribbling", "Dribbling", new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable DobryDribbling =
            new LinguisticVariable("good dribbling", "Dribbling", new TrapezoidalFunction(68, 73, 85, 87));

        public static readonly LinguisticVariable BardzoDobryDribbling =
            new LinguisticVariable("very good dribbling", "Dribbling", new TrapezoidalFunction(85, 90, 97, 97));

        public static List<LinguisticVariable> GetAllDribblingVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoSlabyDribbling, SlabyDribbling, SredniDribbling, DobryDribbling, BardzoDobryDribbling
            };
        }

        public static readonly LinguisticVariable BardzoSlabeCurve =
            new LinguisticVariable("very weak curve", "Curve", new TriangularFunction(6, 6, 35));

        public static readonly LinguisticVariable SlabeCurve =
            new LinguisticVariable("weak curve", "Curve", new TriangularFunction(20, 35, 60));

        public static readonly LinguisticVariable SrednieCurve =
            new LinguisticVariable("average curve", "Curve", new TriangularFunction(50, 60, 70));

        public static readonly LinguisticVariable DobreCurve =
            new LinguisticVariable("good curve", "Curve", new TriangularFunction(68, 75, 87));

        public static readonly LinguisticVariable BardzoDobreCurve =
            new LinguisticVariable("very good curve", "Curve", new TriangularFunction(85, 94, 94));

        public static List<LinguisticVariable> GetAllCurveVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoSlabeCurve, SlabeCurve, SrednieCurve, DobreCurve, BardzoDobreCurve
            };
        }

        public static readonly LinguisticVariable BardzoSlabeLongPassing =
            new LinguisticVariable("very weak long passing", "LongPassing", new TrapezoidalFunction(8, 8, 25, 35));

        public static readonly LinguisticVariable SlabeLongPassing =
            new LinguisticVariable("weak long passing", "LongPassing", new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable SrednieLongPassing =
            new LinguisticVariable("average long passing", "LongPassing", new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable DobreLongPassing =
            new LinguisticVariable("good long passing", "LongPassing", new TrapezoidalFunction(68, 73, 80, 85));

        public static readonly LinguisticVariable BardzoDobreLongPassing =
            new LinguisticVariable("very good long passing", "LongPassing", new TrapezoidalFunction(82, 85, 92, 92));

        public static List<LinguisticVariable> GetAllLongPassingVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoSlabeLongPassing, SlabeLongPassing, SrednieLongPassing, DobreLongPassing, BardzoDobreLongPassing
            };
        }

        public static readonly LinguisticVariable BardzoWolnySprint =
            new LinguisticVariable("very slow", "Sprint", new TrapezoidalFunction(11, 11, 25, 35));

        public static readonly LinguisticVariable WolnySprint =
            new LinguisticVariable("slow", "Sprint", new TrapezoidalFunction(30, 35, 48, 55));

        public static readonly LinguisticVariable SredniSprint =
            new LinguisticVariable("average (sprint)", "Sprint", new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable SzybkiSprint =
            new LinguisticVariable("fast", "Sprint", new TrapezoidalFunction(68, 73, 80, 86));

        public static readonly LinguisticVariable BardzoSzybkiSprint =
            new LinguisticVariable("very fast", "Sprint", new TrapezoidalFunction(84, 90, 96, 96));

        public static List<LinguisticVariable> GetAllSprintVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoWolnySprint, WolnySprint, SredniSprint, SzybkiSprint, BardzoSzybkiSprint
            };
        }

        public static readonly LinguisticVariable SlabaShotPower =
            new LinguisticVariable("weak shot power", "ShotPower", new TrapezoidalFunction(14, 14, 45, 50));

        public static readonly LinguisticVariable SredniaShotPower =
            new LinguisticVariable("average shot power", "ShotPower", new TrapezoidalFunction(45, 50, 60, 65));

        public static readonly LinguisticVariable DuzaShotPower =
            new LinguisticVariable("high shot power", "ShotPower", new TrapezoidalFunction(62, 68, 80, 82));

        public static readonly LinguisticVariable BardzoDuzaShotPower =
            new LinguisticVariable("very high shot power", "ShotPower", new TrapezoidalFunction(80, 88, 95, 95));

        public static List<LinguisticVariable> GetAllShotPowerVariables()
        {
            return new List<LinguisticVariable>
            {
                SlabaShotPower, SredniaShotPower, DuzaShotPower, BardzoDuzaShotPower
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
    }
}