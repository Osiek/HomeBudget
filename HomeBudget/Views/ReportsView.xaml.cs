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
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<decimal, string> Formatter { get; set; }
        public DateTime SelectedDateBegin { get; set; }
        public DateTime SelectedDateEnd { get; set; }
        public ReportsView()
        {
            InitializeComponent();
            reportController = new ReportController();

            SeriesCollection = new SeriesCollection();
            Labels = new List<string>();

            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;
            var currentDay = DateTime.Now.Day;

            SelectedDateBegin = new DateTime(currentYear, currentMonth, 1);
            SelectedDateEnd = new DateTime(currentYear, currentMonth, currentDay);

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ((ComboBoxItem)reportTypeComboBox.SelectedItem).Content.ToString();
            Dictionary<string, decimal> plotData = null;
            SeriesCollection.Clear();
            Labels.Clear();

            if (selectedItem == "Sklepy")
            {
                plotData = reportController.GetShopSummaryValues(SelectedDateBegin.ToString(), SelectedDateEnd.ToString());

            }
            else if (selectedItem == "Kategorie")
            {
                plotData = reportController.GetCategoriesSummaryValues(SelectedDateBegin.ToString(), SelectedDateEnd.ToString());
            }

            foreach (var row in plotData)
            {
                SeriesCollection.Add(new ColumnSeries
                {
                    Title = row.Key,
                    Values = new ChartValues<decimal> { row.Value }
                });

                Labels.Add(row.Key);
            }

            //Formatter = value => value.ToString("0.00");

        }
    }
}
