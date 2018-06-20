using HomeBudget.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class CsvFileController
    {
        private string lastOpendLocation;
        private CsvFile csvFile;
        private ImportCsvWindow importCsvWindow;

        public CsvFileController(ImportCsvWindow importCsvWindow)
        {
            this.importCsvWindow = importCsvWindow;
        }

        public void Open(string lastOpendLocation)
        {
            csvFile = new CsvFile(GetPath(lastOpendLocation));
            csvFile.GetFileContent();
            importCsvWindow.pathToFile.Text = csvFile.DirectoryPath + "\\" + csvFile.FileName;
            importCsvWindow.lastOpendLocation = csvFile.DirectoryPath;
        }

        public string GetPath(string lastOpendLocation)
        {
            string dirPath;
            if (Directory.Exists(lastOpendLocation))
            {
                dirPath = lastOpendLocation;
            }
            else if (Directory.Exists(@"E:\Google Drive\Uczelnia\Semestr 7\Projekt kompetencyjny"))
            {
                dirPath = @"E:\Google Drive\Uczelnia\Semestr 7\Projekt kompetencyjny";
            }
            else
            {
                dirPath = @"C:\";
            }

            return dirPath;
        }

        public bool IsFileOpened()
        {
            if (csvFile != null) return true;
            return false;
        }

        public void SetSeparator(string separator)
        {
            csvFile.ColumnSeparator = separator;
            csvFile.SeparateText();
        }

        public List<string> GetTable()
        {
            var tmp = new List<string>() { "Patryk", "Marek" };
                       

            return tmp;
            //return csvFile.ContentList;
        }
    }
}
