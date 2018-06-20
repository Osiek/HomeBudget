using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using HomeBudget.Controllers;
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
        public string lastOpendLocation;
        CsvFileController csvFile;
        public List<string> importedList { get; set; }

        public ImportCsvWindow()
        {
            InitializeComponent();
            lastOpendLocation = "";
            csvFile = new CsvFileController(this);
        }

        private void Button_OpenFile(object sender, RoutedEventArgs e)
        {
            csvFile.Open(lastOpendLocation);
        }

        private void ImportCsvWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void columnSeparator_TextChanged(object sender, EventArgs e)
        {
            if(csvFile.IsFileOpened())
            {
                csvFile.SetSeparator(columnSeparator.Text);
                importedList = csvFile.GetTable();

                var list = new ObservableCollection<List<string>>();
                list.Add(importedList);
                this.importedDataPreview.ItemsSource = list;
                //importedDataPreview.ItemsSource = csvFile.GetTable();
            }


        }
    }
}
