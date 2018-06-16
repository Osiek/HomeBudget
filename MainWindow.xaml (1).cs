using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HomeBudget.DAL;

namespace HomeBudget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DAL.AppContext db = new DAL.AppContext();
        ImportCsvWindow importWindow;

        public MainWindow()
        {
            InitializeComponent();
            importWindow = new ImportCsvWindow() {
                ShowInTaskbar = false,
            };
            importWindow.Hide();
        }

        private void Button_ImportCsv(object sender, RoutedEventArgs e)
        {
            importWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            importWindow.Owner = Application.Current.MainWindow;

            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // categoryViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource entryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("entryViewSource")));
            System.Windows.Data.CollectionViewSource shopViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("shopViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // entryViewSource.Source = [generic data source]
            db.Entries.Load();
            db.Shops.Load();
            entryViewSource.Source = db.Entries.Local;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //this.importWindow = null;
            //importWindow.Close();
            
        }
    }
}
