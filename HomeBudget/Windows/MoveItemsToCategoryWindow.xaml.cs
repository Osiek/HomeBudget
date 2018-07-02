using HomeBudget.Controllers;
using HomeBudget.Models;
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
using System.Windows.Shapes;

namespace HomeBudget.Windows
{
    /// <summary>
    /// Interaction logic for MoveItemsToCategoryWindow.xaml
    /// </summary>
    public partial class MoveItemsToCategoryWindow : Window
    {
        public List<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        private bool saveChanges;
        public MoveItemsToCategoryWindow(List<Category> categories)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            categoryComboBox.DataContext = this;

            this.Categories = categories;
            this.SelectedCategory = Categories.First();
            this.saveChanges = false;
        }

        private void moveButton_Click(object sender, RoutedEventArgs e)
        {
            this.saveChanges = true;
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (this.saveChanges == false)
            {
                this.SelectedCategory = null;
            }
        }
    }
}
