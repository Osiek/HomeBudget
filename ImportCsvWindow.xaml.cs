using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HomeBudget
{
    /// <summary>
    /// Interaction logic for ImportCsvWindow.xaml
    /// </summary>
    public partial class ImportCsvWindow : Window
    {
        public ImportCsvWindow()
        {
            InitializeComponent();
        }

        private void Button_OpenFile(object sender, RoutedEventArgs e)
        {

        }

        private void ImportCsvWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
