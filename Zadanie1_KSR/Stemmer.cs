//źródło: https://tartarus.org/martin/PorterStemmer/csharp.txt
using System;
// ReSharper disable InconsistentNaming

namespace Zadanie1_KSR
{
    /**
	  * Stemmer, implementing the Porter Stemming Algorithm
	  *
	  * The Stemmer class transforms a word into its root form.  The input
	  * word can be provided a character at time (by calling Add()), or at once
	  * by calling one of the various Stem(something) methods.
	  */
    class Stemmer
    {
        private char[] b;

        private int i, /* offset into b */
            i_end, /* offset to end of stemmed word */
            j,
            k;

        private static int INC = 50;
        /* unit of size whereby b is increased */

        public Stemmer()
        {
            b = new char[INC];
            i = 0;
            i_end = 0;
        }

        /**
		 * Add a character to the word being stemmed.  When you are finished
		 * adding characters, you can call Stem(void) to Stem the word.
		 */
        public void Add(char ch)
        {
            if (i == b.Length)
            {
                char[] new_b = new char[i + INC];
                for (int c = 0; c < i; c++)
                    new_b[c] = b[c];
                b = new_b;
            }

            b[i++] = ch;
        }


        /**
		 * After a word has been stemmed, it can be retrieved by toString(),
		 * or a reference to the internal buffer can be retrieved by getResultBuffer
		 * and getResultLength (which is generally more efficient.)
		 */
        public override string ToString()
        {
            return new String(b, 0, i_end);
        }

        /* Cons(i) is true <=> b[i] is a consonant. */
        private bool Cons(int i)
        {
            switch (b[i])
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u': return false;
                case 'y': return (i == 0) ? true : !Cons(i - 1);
                default: return true;
            }
        }

        /* M() measures the number of consonant sequences between 0 and j. if c is
           a consonant sequence and v a vowel sequence, and <..> indicates arbitrary
           presence,

              <c><v>       gives 0
              <c>vc<v>     gives 1
              <c>vcvc<v>   gives 2
              <c>vcvcvc<v> gives 3
              ....
        */
        private int M()
        {
            int n = 0;
            int i = 0;
            while (true)
            {
                if (i > j) return n;
                if (!Cons(i)) break;
                i++;
            }

            i++;
            while (true)
            {
                while (true)
                {
                    if (i > j) return n;
                    if (Cons(i)) break;
                    i++;
                }

                i++;
                n++;
                while (true)
                {
                    if (i > j) return n;
                    if (!Cons(i)) break;
                    i++;
                }

                i++;
            }
        }

        /* Vowelinstem() is true <=> 0,...j contains a vowel */
        private bool Vowelinstem()
        {
            int i;
            for (i = 0; i <= j; i++)
                if (!Cons(i))
                    return true;
            return false;
        }

        /* Doublec(j) is true <=> j,(j-1) contain a double consonant. */
        private bool Doublec(int j)
        {
            if (j < 1)
                return false;
            if (b[j] != b[j - 1])
                return false;
            return Cons(j);
        }

        /* Cvc(i) is true <=> i-2,i-1,i has the form consonant - vowel - consonant
           and also if the second c is not w,x or y. this is used when trying to
           restore an e at the end of a short word. e.g.

              cav(e), lov(e), hop(e), crim(e), but
              snow, box, tray.

        */
        private bool Cvc(int i)
        {
            if (i < 2 || !Cons(i) || Cons(i - 1) || !Cons(i - 2))
                return false;
            int ch = b[i];
            if (ch == 'w' || ch == 'x' || ch == 'y')
                return false;
            return true;
        }

        private bool Ends(String s)
        {
            int l = s.Length;
            int o = k - l + 1;
            if (o < 0)
                return false;
            char[] sc = s.ToCharArray();
            for (int i = 0; i < l; i++)
                if (b[o + i] != sc[i])
                    return false;
            j = k - l;
            return true;
        }

        /* Setto(s) sets (j+1),...k to the characters in the string s, readjusting
           k. */
        private void Setto(String s)
        {
            int l = s.Length;
            int o = j + 1;
            char[] sc = s.ToCharArray();
            for (int i = 0; i < l; i++)
                b[o + i] = sc[i];
            k = j + l;
        }

        /* R(s) is used further down. */
        private void R(String s)
        {
            if (M() > 0)
                Setto(s);
        }

        /* Step1() gets rid of plurals and -ed or -ing. e.g.
               caresses  ->  caress
               ponies    ->  poni
               ties      ->  ti
               caress    ->  caress
               cats      ->  cat

               feed      ->  feed
               agreed    ->  agree
               disabled  ->  disable

               matting   ->  mat
               mating    ->  mate
               meeting   ->  meet
               milling   ->  mill
               messing   ->  mess

               meetings  ->  meet

        */

        private void Step1()
        {
            if (b[k] == 's')
            {
                if (Ends("sses"))
                    k -= 2;
                else if (Ends("ies"))
                    Setto("i");
                else if (b[k - 1] != 's')
                    k--;
            }

            if (Ends("eed"))
            {
                if (M() > 0)
                    k--;
            }
            else if ((Ends("ed") || Ends("ing")) && Vowelinstem())
            {
                k = j;
                if (Ends("at"))
                    Setto("ate");
                else if (Ends("bl"))
                    Setto("ble");
                else if (Ends("iz"))
                    Setto("ize");
                else if (Doublec(k))
                {
                    k--;
                    int ch = b[k];
                    if (ch == 'l' || ch == 's' || ch == 'z')
                        k++;
                }
                else if (M() == 1 && Cvc(k)) Setto("e");
            }
        }

        /* Step2() turns terminal y to i when there is another vowel in the Stem. */
        private void Step2()
        {
            if (Ends("y") && Vowelinstem())
                b[k] = 'i';
        }

        /* Step3() maps double suffices to single ones. so -ization ( = -ize plus
           -ation) maps to -ize etc. note that the string before the suffix must give
           M() > 0. */
        private void Step3()
        {
            if (k == 0)
                return;

            switch (b[k - 1])
            {
                case 'a':
                    if (Ends("ational"))
                    {
                        R("ate");
                        break;
                    }

                    if (Ends("tional"))
                    {
                        R("tion");
                        break;
                    }

                    break;
                case 'c':
                    if (Ends("enci"))
                    {
                        R("ence");
                        break;
                    }

                    if (Ends("anci"))
                    {
                        R("ance");
                        break;
                    }

                    break;
                case 'e':
                    if (Ends("izer"))
                    {
                        R("ize");
                        break;
                    }

                    break;
                case 'l':
                    if (Ends("bli"))
                    {
                        R("ble");
                        break;
                    }

                    if (Ends("alli"))
                    {
                        R("al");
                        break;
                    }

                    if (Ends("entli"))
                    {
                        R("ent");
                        break;
                    }

                    if (Ends("eli"))
                    {
                        R("e");
                        break;
                    }

                    if (Ends("ousli"))
                    {
                        R("ous");
                        break;
                    }

                    break;
                case 'o':
                    if (Ends("ization"))
                    {
                        R("ize");
                        break;
                    }

                    if (Ends("ation"))
                    {
                        R("ate");
                        break;
                    }

                    if (Ends("ator"))
                    {
                        R("ate");
                        break;
                    }

                    break;
                case 's':
                    if (Ends("alism"))
                    {
                        R("al");
                        break;
                    }

                    if (Ends("iveness"))
                    {
                        R("ive");
                        break;
                    }

                    if (Ends("fulness"))
                    {
                        R("ful");
                        break;
                    }

                    if (Ends("ousness"))
                    {
                        R("ous");
                        break;
                    }

                    break;
                case 't':
                    if (Ends("aliti"))
                    {
                        R("al");
                        break;
                    }

                    if (Ends("iviti"))
                    {
                        R("ive");
                        break;
                    }

                    if (Ends("biliti"))
                    {
                        R("ble");
                        break;
                    }

                    break;
                case 'g':
                    if (Ends("logi"))
                    {
                        R("log");
                        break;
                    }

                    break;
                default:
                    break;
            }
        }

        /* Step4() deals with -ic-, -full, -ness etc. similar strategy to Step3. */
        private void Step4()
        {
            switch (b[k])
            {
                case 'e':
                    if (Ends("icate"))
                    {
                        R("ic");
                        break;
                    }

                    if (Ends("ative"))
                    {
                        R("");
                        break;
                    }

                    if (Ends("alize"))
                    {
                        R("al");
                        break;
                    }

                    break;
                case 'i':
                    if (Ends("iciti"))
                    {
                        R("ic");
                        break;
                    }

                    break;
                case 'l':
                    if (Ends("ical"))
                    {
                        R("ic");
                        break;
                    }

                    if (Ends("ful"))
                    {
                        R("");
                        break;
                    }

                    break;
                case 's':
                    if (Ends("ness"))
                    {
                        R("");
                        break;
                    }

                    break;
            }
        }

        /* Step5() takes off -ant, -ence etc., in context <c>vcvc<v>. */
        private void Step5()
        {
            if (k == 0)
                return;

            switch (b[k - 1])
            {
                case 'a':
                    if (Ends("al")) break;
                    return;
                case 'c':
                    if (Ends("ance")) break;
                    if (Ends("ence")) break;
                    return;
                case 'e':
                    if (Ends("er")) break;
                    return;
                case 'i':
                    if (Ends("ic")) break;
                    return;
                case 'l':
                    if (Ends("able")) break;
                    if (Ends("ible")) break;
                    return;
                case 'n':
                    if (Ends("ant")) break;
                    if (Ends("ement")) break;
                    if (Ends("ment")) break;
                    /* element etc. not stripped before the M */
                    if (Ends("ent")) break;
                    return;
                case 'o':
                    if (Ends("ion") && j >= 0 && (b[j] == 's' || b[j] == 't')) break;
                    if (Ends("ou")) break;
                    return;
                /* takes care of -ous */
                case 's':
                    if (Ends("ism")) break;
                    return;
                case 't':
                    if (Ends("ate")) break;
                    if (Ends("iti")) break;
                    return;
                case 'u':
                    if (Ends("ous")) break;
                    return;
                case 'v':
                    if (Ends("ive")) break;
                    return;
                case 'z':
                    if (Ends("ize")) break;
                    return;
                default:
                    return;
            }

            if (M() > 1)
                k = j;
        }

        /* Step6() removes a final -e if M() > 1. */
        private void Step6()
        {
            j = k;

            if (b[k] == 'e')
            {
                int a = M();
                if (a > 1 || a == 1 && !Cvc(k - 1))
                    k--;
            }

            if (b[k] == 'l' && Doublec(k) && M() > 1)
                k--;
        }

        /** Stem the word placed into the Stemmer buffer through calls to Add().
		 * Returns true if the stemming process resulted in a word different
		 * from the input.  You can retrieve the result with
		 * getResultLength()/getResultBuffer() or toString().
		 */
        public void Stem()
        {
            k = i - 1;
            if (k > 1)
            {
                Step1();
                Step2();
                Step3();
                Step4();
                Step5();
                Step6();
            }

            i_end = k + 1;
            i = 0;
        }

        /** Test program for demonstrating the Stemmer.  It reads text from a
		 * a list of files, stems each word, and writes the result to standard
		 * output. Note that the word stemmed is expected to be in lower case:
		 * forcing lower case must be done outside the Stemmer class.
		 * Usage: Stemmer file-name file-name ...
		 */
        public string StemText(string text)
        {
            char[] delimiters = {' ', '\t', '\n'};
            string[] tabWords = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string tab = "";
            Stemmer s = new Stemmer();
            foreach (var word in tabWords)
            {
                foreach (var charr in word.ToLower())
                {
                    s.Add(charr);
                }

                s.Stem();
                tab += CheckFirstLastChar(s.ToString()) + " ";
            }

            return tab;
        }

        private string CheckFirstLastChar(string word)
        {
            char[] tab = {'\"', '-', '\'', ',', '.', '/', '<', '>', '`', '(', ')'};
            string tmp = word;
            foreach (var ch in tab)
            {
                if (tmp.StartsWith(ch))
                {
                    tmp = tmp.Substring(1);
                }

                if (tmp.EndsWith(ch))
                {
                    tmp = tmp.Substring(0, tmp.Length - 1);
                }
            }

            return tmp;
        }
    }
}