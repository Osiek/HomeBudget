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
        public DateTime DatePickerDisplayDate { get; set; }
        public DateTime DatePickerDisplayDateStart { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DatePickerDisplayDate = DateTime.Now;
            DatePickerDisplayDateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

    }
}
