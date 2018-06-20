using HomeBudget.Controllers;
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

namespace HomeBudget.Views
{
    /// <summary>
    /// Interaction logic for ShopsView.xaml
    /// </summary>
    public partial class ShopsView : UserControl
    {
        private ShopController shopController;
        private DAL.AppContext db = new DAL.AppContext();
        System.Windows.Data.CollectionViewSource shopViewSource;

        public ShopsView()
        {
            InitializeComponent();
            shopController = new ShopController();
            shopViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("shopViewSource")));
        }

        private void saveShopButton_Click(object sender, RoutedEventArgs e)
        {
            shopNameInput.IsEnabled = false;
            string shopText = shopNameInput.Text.Trim();

            if (shopText.Length > 0)
            {
                shopController.Add(shopText);
            }

            shopNameInput.Text = "";

            shopNameInput.IsEnabled = true;

            //Refreshes datagrid, but in documentation they say that categoryDataGrid.Items.Refresh(); should be enough
            db.Shops.Load();
            shopDataGrid.Items.Refresh();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            db.Shops.Load();

            shopViewSource.Source = db.Shops.Local;
        }
    }
}
