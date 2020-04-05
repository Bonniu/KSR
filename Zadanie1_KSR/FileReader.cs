using System.Collections.Generic;

namespace Zadanie1_KSR
{
    public class FileReader
    {
        private const string FileNameBase = "reut2-";
        private const string FolderPath = "..\\..\\..\\dane\\";
        private const string FileNameExtension = ".sgm";
        
        public static List<Article> ReadAllFiles()
        {
            List<Article> articles = new List<Article>();
            FileParser fp = new FileParser();
            for (int i = 0; i < 22; i++)
            {
                if (i < 10)
                {
                    fp.ReadFile(FolderPath + FileNameBase + "00" + i + FileNameExtension, articles);
                }
                else
                {
                    fp.ReadFile(FolderPath + FileNameBase + "0" + i + FileNameExtension, articles);
                }
            }

            return articles;
        }
    }
}