﻿using System;

namespace Zadanie1_KSR
{
    public class Article
    {
        private string originalText;
        private string place;
        private int wordCount;
        private string refactoredText;

        public Article(string originalText, string place)
        {
            this.originalText = originalText;
            this.place = place;
            char[] delimiters = {' ', '\t', '\n'};
            this.refactoredText = StopwordTool.RemoveStopwords(originalText);
            Stemmer s = new Stemmer();
            this.refactoredText = s.StemText(refactoredText);
            this.wordCount = refactoredText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

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

        public override string ToString()
        {
            return "[place=" + GetPlace() + ", wordCount=" + GetWordCount() + ", originalText=\n" + GetOriginalText() +
                   ", \nrefactoredText=\n" + GetRefactoredText() + "]";
        }
    }
}