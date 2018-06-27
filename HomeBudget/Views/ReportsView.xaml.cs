using System;
using System.Collections.Generic;
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
using HomeBudget.Controllers;
using LiveCharts;
using LiveCharts.Wpf;

namespace HomeBudget.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        private ReportController reportController;

        public ReportsView()
        {
            InitializeComponent();
            reportController = new ReportController();
            reportController.GetShopSummaryValues("2018-01-01", "2018-06-26");
            reportController.GetCategoriesSummaryValues("2018-06-24", "2018-06-27");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
