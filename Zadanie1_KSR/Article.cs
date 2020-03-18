using System;

namespace Zadanie1_KSR
{
    public class Article
    {
        private string originalText;
        private string place;
        private int wordCount;
        private string refactoredText;
        private FeaturesVector _featuresVector;

        public Article(string originalText, string place)
        {
            this.originalText = originalText;
            this.place = place;
            char[] delimiters = {' ', '\t', '\n'};
            refactoredText = StopwordTool.RemoveStopwords(originalText);
            Stemmer s = new Stemmer();
            refactoredText = s.StemText(refactoredText);
            wordCount = refactoredText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            _featuresVector = new FeaturesVector();
        }

        public FeaturesVector GetFeaturesVector()
        {
            return _featuresVector;
        }

        public void SetFeaturesVector(FeaturesVector featuresVector)
        {
            _featuresVector = featuresVector;
        }

        public string GetOriginalText()
        {
            return originalText;
        }

        public string GetRefactoredText()
        {
            return refactoredText;
        }

        public string GetPlace()
        {
            return place;
        }

        public int GetWordCount()
        {
            return wordCount;
        }

        //dodac pozniej wektor cech
        public override string ToString()
        {
            return "[place=" + GetPlace() + ", wordCount=" + GetWordCount() + ", originalText=\n" + GetOriginalText() +
                   ", \nrefactoredText=\n" + GetRefactoredText() + "]";
        }
    }
}