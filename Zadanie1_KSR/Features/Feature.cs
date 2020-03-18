// ReSharper disable CommentTypo

using System;
using System.Collections.Generic;

namespace Zadanie1_KSR.Features
{
    public abstract class Feature
    {
        protected double value;

        protected List<string> ConvertTextToArray(string text)
        {
            char[] delimiters = {' ', '\t', '\n'};
            string[] tmp = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            List<string> returnList = new List<string>();
            foreach (var s in tmp)
            {
                returnList.Add(s);
            }

            return returnList;
        }

        public double GetValue()
        {
            return value;
        }
    }
}