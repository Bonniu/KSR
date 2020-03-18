using System.Collections.Generic;

namespace Zadanie1_KSR
{
    public class ArticleGenerator
    {
        private int nrOfFiles;
        public static readonly string FileNameBase = "reut2-";
        public static readonly string FolderPath = "..\\..\\..\\dane\\";
        public static readonly string FileNameExtension = ".sgm";

        public ArticleGenerator(int nrOfFiles)
        {
            this.nrOfFiles = nrOfFiles;
        }
        

        public List<Article> ReadAllFiles()
        {
            List<Article> articles = new List<Article>();
            FileParser fp = new FileParser();
            for (int i = 0; i < nrOfFiles; i++)
            {
                if (i < 10)
                {
                    fp.readFile(FolderPath + FileNameBase + "00" + i + FileNameExtension, articles);
                }
                else
                {
                    fp.readFile(FolderPath + FileNameBase + "0" + i + FileNameExtension, articles);
                }
            }

            return articles;
        }
    }
}