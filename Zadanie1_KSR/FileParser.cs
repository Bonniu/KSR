using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Zadanie1_KSR
{
    public class FileParser
    {
        //reut2-000.sgm
        public void readFile(string fileName, List<Article> articleList)
        {
            string wholeText = File.ReadAllText(fileName);
            string[] articles = wholeText.Split("<PLACES>");
            for (int i = 1; i < articles.Length; i++) // pierwszy to jakies reuters, i inne
            {
                string place = getPlace(articles[i]);
                string body = getBody(articles[i]);
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

        private string getPlace(string text)
        {
            string tmp = text.Split("\n")[0];
            string placesLine;
            if (tmp.Equals("</PLACES>"))
                return "err";
            if (tmp.Contains("</PLACES>"))
            {
                placesLine = tmp.Substring(3, tmp.IndexOf("</PLACES>") - 7);
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

        private string getBody(string article)
        {
            string text;
            try
            {
                text = article.Split("<BODY>")[1].Split("&#3;")[0];
            }
            catch (Exception ignored)
            {
                return "err";
            }

            text = text.Replace("&lt;", "<");
            return text;
        }
    }
}