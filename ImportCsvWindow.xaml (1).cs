using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HomeBudget.DAL;
using HomeBudget.Models;
using Microsoft.Win32;

namespace HomeBudget
{
    /// <summary>
    /// Interaction logic for ImportCsvWindow.xaml
    /// </summary>
    public partial class ImportCsvWindow : Window
    {
        private DAL.AppContext db = new DAL.AppContext();
        private string lastOpendLocation;
        CsvFile csvFile;

        public ImportCsvWindow()
        {
            InitializeComponent();
            lastOpendLocation = "";
            csvFile = null;
        }

        private void Button_OpenFile(object sender, RoutedEventArgs e)
        {
            if (lastOpendLocation.Length > 0 && Directory.Exists(lastOpendLocation))
            {
                csvFile = new CsvFile(lastOpendLocation);
            } else if(Directory.Exists(@"E:\Google Drive\Uczelnia\Semestr 7\Projekt kompetencyjny"))
            {
                csvFile = new CsvFile(@"E:\Google Drive\Uczelnia\Semestr 7\Projekt kompetencyjny");
            } else
            {
                csvFile = new CsvFile(@"C:\");
            }

            csvFile.GetFileContent();
            pathToFile.Text = csvFile.DirectoryPath + "\\" + csvFile.FileName;
            this.lastOpendLocation = csvFile.DirectoryPath;
        }

        private void ImportCsvWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void columnSeparator_TextChanged(object sender, EventArgs e)
        {
            if(csvFile != null)
            {
                csvFile.ColumnSeparator = columnSeparator.Text;
                csvFile.SeparateText();

                importedDataPreview.ItemsSource = csvFile.ContentList.ToArray();
            }


        }
    }
}
