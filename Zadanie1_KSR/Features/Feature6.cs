using System;
using System.Collections.Generic;

// ReSharper disable CommentTypo

namespace Zadanie1_KSR.Features
{
    public class Feature6 : Feature
    {
        public Feature6(Article article)
        {
            value = CountValue(article);
        }

        // Stosunek linii do ilości akapitów
        private double CountValue(Article article)
        {
            var linesCounter = article.GetOriginalText().Split("\n").Length - 1;
            var paragraphsCounter = article.GetOriginalText().Split("\n    ").Length;
            value = (double) linesCounter / paragraphsCounter;
            return value;
        }
    }
}