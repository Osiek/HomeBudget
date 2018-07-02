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
    /// Interaction logic for MoveEntriesToShopWindow.xaml
    /// </summary>
    public partial class MoveEntriesToShopWindow : Window
    {
        public List<Shop> Shops { get; set; }
        public Shop SelectedShop { get; set; }
        private bool saveChanges;

        public MoveEntriesToShopWindow(List<Shop> shops)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            categoryComboBox.DataContext = this;

            this.Shops = shops;
            this.SelectedShop = Shops.First();
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
                this.SelectedShop = null;
            }
        }
    }
}
