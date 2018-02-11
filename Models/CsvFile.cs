using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Models
{
    class CsvFile
    {
        string Content { get; set; }
        string DirectoryPath { get; set; }
        string FileName { get; set; }
        string ColumnSeparator { get; set; }
        private OpenFileDialog FileDialog { get; set; }

        public CsvFile(string lastDirectoryPath)
        {
            this.DirectoryPath = lastDirectoryPath;
            FileDialog = new OpenFileDialog();
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

        private void GetFilePath()
        {
            if(OpenFileDialog() == true) {
                this.DirectoryPath = System.IO.Path.GetDirectoryName(FileDialog.FileName);
                this.FileName = FileDialog.FileName;
            }
        }
    }
}
