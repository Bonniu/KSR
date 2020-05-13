using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Zadanie2_KSR.MembershipFunctions;

// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable StringLiteralTypo

namespace Zadanie2_KSR.Attributes
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class Attributes
    {
        public static readonly LinguisticVariable BardzoMlodyAge =
            new LinguisticVariable("bardzo młody", "Age", new TrapezoidalFunction(16, 16, 18, 21));

        public static readonly LinguisticVariable MlodyAge =
            new LinguisticVariable("młody", "Age", new TrapezoidalFunction(20, 22, 24, 25));

        public static readonly LinguisticVariable SredniAge =
            new LinguisticVariable("średni", "Age", new TrapezoidalFunction(24, 26, 29, 32));

        public static readonly LinguisticVariable StaryAge =
            new LinguisticVariable("stary", "Age", new TrapezoidalFunction(31, 34, 42, 42));

        public static List<LinguisticVariable> GetAllAgeVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoMlodyAge, MlodyAge, SredniAge, StaryAge
            };
        }

        public static readonly LinguisticVariable NiskiHeight =
            new LinguisticVariable("niski", "Height", new TriangularFunction(156, 156, 166));

        public static readonly LinguisticVariable SredniHeight =
            new LinguisticVariable("średni", "Height", new TriangularFunction(164, 170, 177));

        public static readonly LinguisticVariable WysokiHeight =
            new LinguisticVariable("wysoki", "Height", new TriangularFunction(175, 182, 188));

        public static readonly LinguisticVariable BardzoWysokiHeight =
            new LinguisticVariable("bardzo wysoki", "Height", new TriangularFunction(186, 205, 205));

        public static List<LinguisticVariable> GetAllHeightVariables()
        {
            return new List<LinguisticVariable>
            {
                NiskiHeight, SredniHeight, WysokiHeight, BardzoWysokiHeight
            };
        }

        public static readonly LinguisticVariable BardzoChudyWeight =
            new LinguisticVariable("bardzo chudy", "Weight", new GaussianFunction(50, 8));

        public static readonly LinguisticVariable ChudyWeight =
            new LinguisticVariable("chudy", "Weight", new GaussianFunction(70, 8));

        public static readonly LinguisticVariable SredniWeight =
            new LinguisticVariable("średni", "Weight", new GaussianFunction(90, 8));

        public static readonly LinguisticVariable GrubyWeight =
            new LinguisticVariable("gruby", "Weight", new GaussianFunction(110, 8));

        public static List<LinguisticVariable> GetAllWeightVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoChudyWeight, ChudyWeight, SredniWeight, GrubyWeight
            };
        }

        public static readonly LinguisticVariable SlabyOverall =
            new LinguisticVariable("słaby", "Overall", new TrapezoidalFunction(48, 48, 59, 65));

        public static readonly LinguisticVariable SredniOverall =
            new LinguisticVariable("średni", "Overall", new TrapezoidalFunction(60, 65, 70, 75));

        public static readonly LinguisticVariable DobryOverall =
            new LinguisticVariable("dobry", "Overall", new TrapezoidalFunction(70, 78, 85, 87));

        public static readonly LinguisticVariable BardzoDobryOverall =
            new LinguisticVariable("bardzo dobry", "Overall", new TrapezoidalFunction(85, 90, 94, 94));

        public static List<LinguisticVariable> GetAllOverallVariables()
        {
            return new List<LinguisticVariable>
            {
                SlabyOverall, SredniOverall, DobryOverall, BardzoDobryOverall
            };
        }

        public static readonly LinguisticVariable BardzoSlabeFinishing =
            new LinguisticVariable("bardzo słabe", "Finishing", new TrapezoidalFunction(2, 2, 25, 35));

        public static readonly LinguisticVariable SlabeFinishing =
            new LinguisticVariable("słabe", "Finishing", new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable SrednieFinishing =
            new LinguisticVariable("średnie", "Finishing", new TrapezoidalFunction(50, 55, 75, 80));

        public static readonly LinguisticVariable DobreFinishing =
            new LinguisticVariable("bardzo dobre", "Finishing", new TrapezoidalFunction(75, 80, 85, 87));

        public static readonly LinguisticVariable BardzoDobreFinishing =
            new LinguisticVariable("bardzo dobre", "Finishing", new TrapezoidalFunction(85, 90, 95, 95));

        public static List<LinguisticVariable> GetAllFinishingVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoSlabeFinishing, SlabeFinishing, SrednieFinishing, DobreFinishing, BardzoDobreFinishing
            };
        }

        public static readonly LinguisticVariable BardzoSlabyDribbling =
            new LinguisticVariable("bardzo słaby", "Dribbling", new TrapezoidalFunction(4, 4, 25, 35));

        public static readonly LinguisticVariable SlabyDribbling =
            new LinguisticVariable("słaby", "Dribbling", new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable SredniDribbling =
            new LinguisticVariable("średni", "Dribbling", new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable DobryDribbling =
            new LinguisticVariable("dobry", "Dribbling", new TrapezoidalFunction(68, 73, 85, 87));

        public static readonly LinguisticVariable BardzoDobryDribbling =
            new LinguisticVariable("bardzo dobry", "Dribbling", new TrapezoidalFunction(85, 90, 97, 97));

        public static List<LinguisticVariable> GetAllDribblingVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoSlabyDribbling, SlabyDribbling, SredniDribbling, DobryDribbling, BardzoDobryDribbling
            };
        }

        public static readonly LinguisticVariable BardzoSlabeCurve =
            new LinguisticVariable("bardzo słabe", "Curve", new TriangularFunction(6, 6, 35));

        public static readonly LinguisticVariable SlabeCurve =
            new LinguisticVariable("słabe", "Curve", new TriangularFunction(20, 35, 60));

        public static readonly LinguisticVariable SrednieCurve =
            new LinguisticVariable("średnie", "Curve", new TriangularFunction(50, 60, 70));

        public static readonly LinguisticVariable DobreCurve =
            new LinguisticVariable("dobre", "Curve", new TriangularFunction(68, 75, 87));

        public static readonly LinguisticVariable BardzoDobreCurve =
            new LinguisticVariable("bardzo dobre", "Curve", new TriangularFunction(85, 94, 94));

        public static List<LinguisticVariable> GetAllCurveVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoSlabeCurve, SlabeCurve, SrednieCurve, DobreCurve, BardzoDobreCurve
            };
        }

        public static readonly LinguisticVariable BardzoSlabeLongPassing =
            new LinguisticVariable("bardzo słabe", "LongPassing", new TrapezoidalFunction(8, 8, 25, 35));

        public static readonly LinguisticVariable SlabeLongPassing =
            new LinguisticVariable("słabe", "LongPassing", new TrapezoidalFunction(30, 35, 50, 60));

        public static readonly LinguisticVariable SrednieLongPassing =
            new LinguisticVariable("średnie", "LongPassing", new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable DobreLongPassing =
            new LinguisticVariable("dobre", "LongPassing", new TrapezoidalFunction(68, 73, 80, 85));

        public static readonly LinguisticVariable BardzoDobreLongPassing =
            new LinguisticVariable("bardzo dobre", "LongPassing", new TrapezoidalFunction(82, 85, 92, 92));

        public static List<LinguisticVariable> GetAllLongPassingVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoSlabeLongPassing, SlabeLongPassing, SrednieLongPassing, DobreLongPassing, BardzoDobreLongPassing
            };
        }

        public static readonly LinguisticVariable BardzoWolnySprint =
            new LinguisticVariable("bardzo wolny", "Sprint", new TrapezoidalFunction(11, 11, 25, 35));

        public static readonly LinguisticVariable WolnySprint =
            new LinguisticVariable("wolny", "Sprint", new TrapezoidalFunction(30, 35, 48, 55));

        public static readonly LinguisticVariable SredniSprint =
            new LinguisticVariable("średni", "Sprint", new TrapezoidalFunction(50, 55, 68, 70));

        public static readonly LinguisticVariable SzybkiSprint =
            new LinguisticVariable("szybki", "Sprint", new TrapezoidalFunction(68, 73, 80, 86));

        public static readonly LinguisticVariable BardzoSzybkiSprint =
            new LinguisticVariable("bardzo szybki", "Sprint", new TrapezoidalFunction(84, 90, 96, 96));

        public static List<LinguisticVariable> GetAllSprintVariables()
        {
            return new List<LinguisticVariable>
            {
                BardzoWolnySprint, WolnySprint, SredniSprint, SzybkiSprint, BardzoSzybkiSprint
            };
        }

        public static readonly LinguisticVariable SlabaShotPower =
            new LinguisticVariable("słaba", "ShotPower", new TrapezoidalFunction(14, 14, 45, 50));

        public static readonly LinguisticVariable SredniaShotPower =
            new LinguisticVariable("średnia", "ShotPower", new TrapezoidalFunction(45, 50, 60, 65));

        public static readonly LinguisticVariable DuzaShotPower =
            new LinguisticVariable("duża", "ShotPower", new TrapezoidalFunction(62, 68, 80, 82));

        public static readonly LinguisticVariable BardzoDuzaShotPower =
            new LinguisticVariable("bardzo duża", "ShotPower", new TrapezoidalFunction(80, 88, 95, 95));

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