using System;
using System.Collections.Generic;
using System.IO;

namespace Zadanie1_KSR
{
    public class FileParser
    {
        //reut2-000.sgm
        public void ReadFile(string fileName, List<Article> articleList)
        {
            var wholeText = File.ReadAllText(fileName);
            var articles = wholeText.Split("<PLACES>");
            for (var i = 1; i < articles.Length; i++) // pierwszy to jakies reuters, i inne
            {
                var place = GetPlace(articles[i]);
                var body = GetBody(articles[i]);
                if (place == "err" || body == "err")
                    continue;
                //west-germany, usa, france, uk, canada, japan
                if (place != "west-germany" &&
                    place != "usa" &&
                    place != "france" &&
                    place != "uk" &&
                    place != "canada" &&
                    place != "japan")
                    continue;

                articleList.Add(new Article(body, place));
            }
        }

        private string GetPlace(string text)
        {
            string tmp = text.Split("\n")[0];
            string placesLine;
            if (tmp.Equals("</PLACES>"))
                return "err";
            if (tmp.Contains("</PLACES>"))
            {
                placesLine = tmp.Substring(3, tmp.IndexOf("</PLACES>", StringComparison.Ordinal) - 7);
            }
            else
            {
                placesLine = tmp.Substring(3, tmp.Length);
            }

            if (!placesLine.Contains("</D><D>")) // to znaczy ze sa wiecej niz 1 places
            {
                return placesLine;
            }
            else
            {
                return "err";
            }
        }

        private string GetBody(string article)
        {
            string text;
            try
            {
                text = article.Split("<BODY>")[1].Split("&#3;")[0];
            }
            catch (Exception)
            {
                return "err";
            }

            text = text.Replace("&lt;", "<");
            return text;
        }
    }
}