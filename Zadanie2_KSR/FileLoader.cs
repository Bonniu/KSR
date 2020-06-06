using System;
using System.Collections.Generic;
using System.IO;
using Zadanie2_KSR.Fuzzy;
using Zadanie2_KSR.MembershipFunctions;

namespace Zadanie2_KSR
{
    public static class FileLoader
    {
        private const string Prefix = "..\\..\\..\\load_data\\";

        public static List<LinguisticVariable> LoadDataFromFile(string fileName)
        {
            var list = new List<LinguisticVariable>();
            var lines = File.ReadAllLines(Prefix + fileName);
            foreach (var line in lines)
            {
                try
                {
                    LinguisticVariable lv;
                    var strings = line.Split(";");
                    var text = strings[0];
                    var attributeName = strings[1];
                    var quantifierAbsolute = strings[2].ToLower().Contains("absolute");
                    var functionType = strings[3];
                    var a = Convert.ToDouble(strings[4].Replace(".", ","));
                    var b = Convert.ToDouble(strings[5].Replace(".", ","));
                    if (functionType.ToLower() == "triangular")
                    {
                        var c = Convert.ToDouble(strings[6].Replace(".", ","));
                        lv = new LinguisticVariable(text, attributeName, quantifierAbsolute,
                            new TriangularFunction(a, b, c));
                    }
                    else if (functionType.ToLower() == "trapezoidal")
                    {
                        var c = Convert.ToDouble(strings[6].Replace(".", ","));
                        var d = Convert.ToDouble(strings[7].Replace(".", ","));
                        lv = new LinguisticVariable(text, attributeName, quantifierAbsolute,
                            new TrapezoidalFunction(a, b, c, d));
                    }
                    else
                    {
                        lv = new LinguisticVariable(text, attributeName, quantifierAbsolute,
                            new GaussianFunction(a, b));
                    }

                    list.Add(lv);
                }
                catch (IndexOutOfRangeException)
                {
                    //ignored
                }
                catch (FormatException)
                {
                    //ignored
                }
            }
            return list;
        }
    }
}