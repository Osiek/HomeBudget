using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Controllers
{
    class PathController
    {
        string extension;

        private OpenFileDialog FileDialog { get; set; }
        private string path;

        public PathController(string extension)
        {
            this.extension = extension;
            FileDialog = new OpenFileDialog();
        }

        public string GetSingleFilePath()
        {
            OpenFileDialog(false);
            return path;
        }

        public string GetDirPath()
        {
            return System.IO.Path.GetDirectoryName(FileDialog.FileName);
        }

        public string GetFileName()
        {
            return System.IO.Path.GetFileName(FileDialog.FileName);
        }

        private void OpenFileDialog(bool multiple)
        {

            //FileDialog.InitialDirectory = this.DirectoryPath;
            FileDialog.InitialDirectory = @"C:\";
            //FileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            //FileDialog.FilterIndex = 1;
            FileDialog.RestoreDirectory = true;

            Nullable<bool> result = FileDialog.ShowDialog();

            if(result == true)
            {
                path = GetDirPath();
                
            }

        }



    }
}
