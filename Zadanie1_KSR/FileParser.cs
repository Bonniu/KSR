using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Zadanie1_KSR
{
    public class FileParser
    {
        //reut2-000.sgm
        public void readFile(string fileName)
        {
            string wholeText = File.ReadAllText(fileName);
            string[] articles = wholeText.Split("<PLACES>");
            for (int i = 1; i < articles.Length; i++)
                // for (int i = 1; i < 10; i++) 
            {
                if (getPlace(articles[i]) == "err")
                    continue;
                string place = getPlace(articles[i]);
                Console.WriteLine(place);
               // Console.WriteLine(articles[i]);
                string body = getBody(articles[i]);
                Console.WriteLine(body);
                
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

            if (!placesLine.Contains("</D><D>"))
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