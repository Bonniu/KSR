using System;
using System.Collections.Generic;
using Zadanie1_KSR.Features;

namespace Zadanie1_KSR
{
    public class Article
    {
        private string originalText;
        private string place;
        private string classifiedPlace = "";
        private int wordCount;
        private string refactoredText;
        private List<Feature> featuresVector;

        public Article(string originalText, string place)
        {
            this.originalText = originalText;
            this.place = place;
            char[] delimiters = {' ', '\t', '\n'};
            refactoredText = StopwordTool.RemoveStopwords(originalText);
            Stemmer s = new Stemmer();
            refactoredText = s.StemText(refactoredText);
            wordCount = refactoredText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            featuresVector = new List<Feature>();
        }

        public List<Feature> GetFeaturesVector()
        {
            return featuresVector;
        }

        public void SetClassifiedPlace(string classifiedPlace)
        {
            this.classifiedPlace = classifiedPlace;
        }
        
        public void SetFeaturesVector(List<Feature> featuresVector)
        {
            this.featuresVector = featuresVector;
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