using System.Collections.Generic;

namespace Zadanie2_KSR
{
    public static class ListToStringConverter
    {
        public static string ConvertSummarizersToString(IReadOnlyList<LinguisticVariable> list)
        {
            var text = list[0].Type + " " + list[0].Text;
            for (var i = 1; i < list.Count; i++)
            {
                text += " and " + list[i].Type + " " + list[i].Text;
            }

            return text;
        }
        
    }
}