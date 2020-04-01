// ReSharper disable CommentTypo

using System;
using System.Collections.Generic;

namespace Zadanie1_KSR.Features
{
    public abstract class Feature
    {
        protected double value;
        protected string valueStr;

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

        public void SetValue(double value)
        {
            this.value = Math.Round(value, 3);
        }
    }
}

/*
    1. Stosunek słów kluczowych do wszystkich słów w pierwszych 10% tekstu
    2. Stosunek słów kluczowych do wszystkich słów w ostatnich 10% tekstu
    3. Stosunek słów kluczowych do wszystkich słów w dokumencie
    4. Stosunek słów kluczowych gdzie ilość liter (0,4] do wszystkich słów
    5. Stosunek słów kluczowych do wszystkich słów gdzie ilość liter słów kluczowych 8+
    6. Stosunek ilości linii do ilości akapitów
    7. Stosunek słów o długości >6 do wszystkich słów
    8. Stosunek słów o długości <=6 do wszystkich słów
    9. Ilość słów unikalnych
    10. Ilość słów, których długość wynosi [5,8]
*/