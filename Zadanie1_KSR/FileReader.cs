using System.Collections.Generic;

namespace Zadanie1_KSR
{
    public class FileReader
    {
        private readonly int _nrOfFiles;
        private const string FileNameBase = "reut2-";
        private const string FolderPath = "..\\..\\..\\dane\\";
        private const string FileNameExtension = ".sgm";

        public FileReader(int nrOfFiles)
        {
            _nrOfFiles = nrOfFiles;
        }
        

        public List<Article> ReadAllFiles()
        {
            List<Article> articles = new List<Article>();
            FileParser fp = new FileParser();
            for (int i = 0; i < _nrOfFiles; i++)
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