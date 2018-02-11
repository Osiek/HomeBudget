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

            string[] text;
            OpenFileDialog openCsvDialog = new OpenFileDialog();
            if()
            {
                openCsvDialog.InitialDirectory = lastOpendLocation;
            } else if(Directory.Exists(@"E:\Google Drive\Uczelnia\Semestr 7\Projekt kompetencyjny"))
            {
                openCsvDialog.InitialDirectory = @"E:\Google Drive\Uczelnia\Semestr 7\Projekt kompetencyjny";
            } else
            {
                openCsvDialog.InitialDirectory = @"C:\";
            }

            openCsvDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openCsvDialog.FilterIndex = 1;
            openCsvDialog.RestoreDirectory = true;
            Nullable<bool> result = openCsvDialog.ShowDialog();
            if (result == true)
            {
                lastOpendLocation = System.IO.Path.GetDirectoryName(openCsvDialog.FileName);
                pathToFile.Text = openCsvDialog.FileName;
                try
                {
                    text = File.ReadAllLines(openCsvDialog.FileName);
                } catch(Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    return;
                }
                

            }


        }

        private void ImportCsvWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ImportCsvWindow_Closing(object sender, CancelEventArgs e, int root)
        {
            if(root == 1)
            {
                e.Cancel = false;
            }
        }
    }
}
