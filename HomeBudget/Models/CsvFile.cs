using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    public class CsvFile
    {
        public string[] Content { get; set; }
        public string DirectoryPath { get; set; }
        public string FileName { get; set; }
        public string ColumnSeparator { get; set; }
        private OpenFileDialog FileDialog { get; set; }
        public List<string[]> ContentList {get; set;}

        public CsvFile(string lastDirectoryPath)
        {
            this.DirectoryPath = lastDirectoryPath;
            FileDialog = new OpenFileDialog();
            ContentList = new List<string[]>();
        }

        public bool? OpenFileDialog()
        {
            FileDialog.InitialDirectory = this.DirectoryPath;
            FileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            FileDialog.FilterIndex = 1;
            FileDialog.RestoreDirectory = true;

            Nullable<bool> result = FileDialog.ShowDialog();

            return result;
        }

        public void GetFileContent()
        {
            if(OpenFileDialog() == true) {
                this.DirectoryPath = System.IO.Path.GetDirectoryName(FileDialog.FileName);
                this.FileName = System.IO.Path.GetFileName(FileDialog.FileName);
                this.Content = File.ReadAllLines(this.DirectoryPath + "\\" + this.FileName);

                SeparateText();
            }
        }

        public void SeparateText()
        {
            this.ContentList.Clear();
            foreach (var line in Content)
            {
                var data = line.Split(new string[] { ColumnSeparator },StringSplitOptions.RemoveEmptyEntries);
                ContentList.Add(data);
                ContentList.ElementAt(0);
            }
        }

    }
}
